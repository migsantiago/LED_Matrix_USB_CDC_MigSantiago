/*-------------------------------------------------------------------
 * FileName: main.c
 * Project: LED Matrix with CDC
 * Author: Santiago Villafuerte (migsantiago.com - san.link@yahoo.com.mx)
 *-----------------------------------------------------------------*/

/*-------------------------------------------------------------------
 * Headers
 * ----------------------------------------------------------------*/

/* USB Headers */
#include <usb/usb.h>
#include <usb/usb_device.h>
#include <usb/usb_device_cdc.h>

/* Application headers */
#include "commands.h"
#include "matrix.h"
#include <system.h>
#include <system_config.h>
#include "time_delay.h"

/*-------------------------------------------------------------------
 * Typedefs
 * ----------------------------------------------------------------*/

typedef void (*Process_Function_T)(uint8_t* command, uint8_t* column_data);

/*-------------------------------------------------------------------
 * Local objects
 * ----------------------------------------------------------------*/

/* The current data to draw on the matrix */
uint8_t Column_Data[MAX_COLUMNS] =
{
    0x1C, 0x22, 0x55, 0x63, 0x5D, 0x22, 0x1C
};

/* Pointer to a function to process a command */
Process_Function_T Proc_F;

/* Current power on command */
PIC_Command_T Current_Command = DRAW_TIME;

uint8_t ReceivedDataBuffer[CDC_DATA_OUT_EP_SIZE];
uint8_t ToSendDataBuffer[CDC_DATA_IN_EP_SIZE];

/*-------------------------------------------------------------------
 * Local prototypes
 * ----------------------------------------------------------------*/

static void Initialize_Timer_2(void);
static void UserInit(void);
static void Initialize_CDC(void);

/*-------------------------------------------------------------------
 * Function definitions
 * ----------------------------------------------------------------*/

MAIN_RETURN main(void)
{
   uint8_t count = 0;

    SYSTEM_Initialize(SYSTEM_STATE_USB_START);
    UserInit();

    USBDeviceInit();
    USBDeviceAttach();
    
    while(1)
    {
        SYSTEM_Tasks();

        #if defined(USB_POLLING)
            // Interrupt or polling method.  If using polling, must call
            // this function periodically.  This function will take care
            // of processing and responding to SETUP transactions
            // (such as during the enumeration process when you first
            // plug in).  USB hosts require that USB devices should accept
            // and process SETUP packets in a timely fashion.  Therefore,
            // when using polling, this function should be called
            // regularly (such as once every 1.8ms or faster** [see
            // inline code comments in usb_device.c for explanation when
            // "or faster" applies])  In most cases, the USBDeviceTasks()
            // function does not take very long to execute (ex: <100
            // instruction cycles) before it returns.
            USBDeviceTasks();
        #endif

         /* Verify if Timer0 ticked (1ms) */
         if(PIR1bits.TMR2IF)
         {
             Process_Timer_2_Tick(NULL, Column_Data);
         }

         /* Keep this running to always draw the matrix */
         Redraw_Matrix(Column_Data);

        /* If the USB device isn't configured yet, we can't really do anything
         * else since we don't have a host to talk to.  So jump back to the
         * top of the while loop. */
        if( USBGetDeviceState() < CONFIGURED_STATE )
        {
            /* Jump back to the top of the while loop. */
            continue;
        }

        /* If we are currently suspended, then we need to see if we need to
         * issue a remote wakeup.  In either case, we shouldn't process any
         * keyboard commands since we aren't currently communicating to the host
         * thus just continue back to the start of the while loop. */
        if( USBIsDeviceSuspended()== true )
        {
            /* Jump back to the top of the while loop. */
            continue;
        }

        /* Receive the data */
        count += getsUSBUSART(&ReceivedDataBuffer[count], CDC_DATA_OUT_EP_SIZE - count);

        //Check if we have received CDC_DATA_OUT_EP_SIZE bytes
        if(CDC_DATA_OUT_EP_SIZE == count)
        {
           count = 0;

            /* Service the command */
            switch((PIC_Command_T)ReceivedDataBuffer[0])
            {
                case DRAW_RAW_FRAME:
                    Current_Command = DRAW_RAW_FRAME;
                    Proc_F = Process_DRAW_RAW_FRAME;
                    break;

                case SET_RTC:
                    Proc_F = Process_SET_RTC;
                    break;

                case DRAW_A_NUMBER:
                    Current_Command = DRAW_A_NUMBER;
                    Proc_F = Process_DRAW_A_NUMBER;
                    break;

                case DRAW_TIME:
                    Current_Command = DRAW_TIME;
                    Proc_F = Process_DRAW_TIME;
                    break;

                case SET_ROTATION:
                    Proc_F = Process_SET_ROTATION;
                    break;

                case GAME_OF_LIFE:
                    Current_Command = GAME_OF_LIFE;
                    Proc_F = Process_GAME_OF_LIFE;
                    break;

                default:
                    Proc_F = Process_UNUSED;
                    break;
            }
            (*Proc_F)(ReceivedDataBuffer, Column_Data);

//            if(USBUSARTIsTxTrfReady() == true)
//            {
//               memcpy(ToSendDataBuffer, ReceivedDataBuffer, CDC_DATA_OUT_EP_SIZE);
//               putUSBUSART(ToSendDataBuffer, CDC_DATA_OUT_EP_SIZE);
//            }

            CDCTxService();
        }
    }//end while
}//end main

static void UserInit(void)
{
   ADCON1 |= 0x0F;                 // Default all pins to digital

    /* Setup the pinout */
    TRIS_COL_0   = 0;
    TRIS_COL_1   = 0;
    TRIS_COL_2   = 0;
    TRIS_COL_3   = 0;
    TRIS_COL_4   = 0;
    TRIS_COL_5   = 0;
    TRIS_PIC_SDA = 0;
    TRIS_PIC_SCL = 0;
    TRIS_GATE_4  = 0;
    TRIS_GATE_5  = 0;
    TRIS_GATE_6  = 0;
    TRIS_USB_LED = 0;
    TRIS_SPARE_0 = 0;
    TRIS_SPARE_1 = 0;
    TRIS_COL_6   = 0;
    TRIS_GATE_0  = 0;
    TRIS_GATE_1  = 0;
    TRIS_GATE_2  = 0;
    TRIS_GATE_3  = 0;

    /* Set the initial values of each pin */
    LAT_PIC_SDA = 0;
    LAT_PIC_SCL = 0;
    LAT_USB_LED = 0;
    LAT_SPARE_0 = 0;
    LAT_SPARE_1 = 0;

    Initialize_Matrix();
    Initialize_Timer_2();
}

static void Initialize_Timer_2(void)
{
    PIR1bits.TMR2IF = 0;
    PIE1bits.TMR2IE = 0;
    IPR1bits.TMR2IP = 0;

    TMR2 = 0;
    PR2 = TIMER_2_PR2;

    T2CON = 0x17; /* Pre 1:3, post 1:16 */
}

static void Initialize_CDC(void)
{
   CDCInitEP();

   line_coding.bCharFormat = 0;
   line_coding.bDataBits = 8;
   line_coding.bParityType = 0;
   line_coding.dwDTERate = 115200;
}

bool USER_USB_CALLBACK_EVENT_HANDLER(USB_EVENT event, void *pdata, uint16_t size)
{
    switch( (int) event )
    {
        case EVENT_TRANSFER:
            break;

        case EVENT_SOF:
            /* This will be called every 1ms when enumerated */
            break;

        case EVENT_SUSPEND:
            break;

        case EVENT_RESUME:
            break;

        case EVENT_CONFIGURED:
            /* When the device is configured, we can (re)initialize the 
             * demo code. */
           Initialize_CDC();
            break;

        case EVENT_SET_DESCRIPTOR:
            break;

        case EVENT_EP0_REQUEST:
            /* We have received a non-standard USB request.  The HID driver
             * needs to check to see if the request was for it. */
            USBCheckCDCRequest();
            break;

        case EVENT_BUS_ERROR:
            break;

        case EVENT_TRANSFER_TERMINATED:
            break;

        default:
            break;
    }
    return true;
}
