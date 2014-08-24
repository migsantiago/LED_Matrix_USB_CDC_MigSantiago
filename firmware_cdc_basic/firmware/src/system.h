/* -----------------------------------------------------------------
 * Project: LED Matrix with CDC
 * Author: Santiago Villafuerte (migsantiago.com - san.link@yahoo.com.mx)
 * -----------------------------------------------------------------*/

/********************************************************************
 Software License Agreement:

 The software supplied herewith by Microchip Technology Incorporated
 (the "Company") for its PIC(R) Microcontroller is intended and
 supplied to you, the Company's customer, for use solely and
 exclusively on Microchip PIC Microcontroller products. The
 software is owned by the Company and/or its supplier, and is
 protected under applicable copyright laws. All rights are reserved.
 Any use in violation of the foregoing restrictions may subject the
 user to criminal sanctions under applicable laws, as well as to
 civil liability for the breach of the terms and conditions of this
 license.

 THIS SOFTWARE IS PROVIDED IN AN "AS IS" CONDITION. NO WARRANTIES,
 WHETHER EXPRESS, IMPLIED OR STATUTORY, INCLUDING, BUT NOT LIMITED
 TO, IMPLIED WARRANTIES OF MERCHANTABILITY AND FITNESS FOR A
 PARTICULAR PURPOSE APPLY TO THIS SOFTWARE. THE COMPANY SHALL NOT,
 IN ANY CIRCUMSTANCES, BE LIABLE FOR SPECIAL, INCIDENTAL OR
 CONSEQUENTIAL DAMAGES, FOR ANY REASON WHATSOEVER.
 *******************************************************************/

#ifndef SYSTEM_H
#define SYSTEM_H

#include <xc.h>
#include <stdbool.h>

#define MAIN_RETURN void

#define GetInstructionClock() 12000000 /* Hz */

/* TRIS directions */
#define TRIS_IN             1
#define TRIS_OUT            0

/* TRIS */
#define TRIS_COL_0         TRISAbits.TRISA0
#define TRIS_COL_1         TRISAbits.TRISA1
#define TRIS_COL_2         TRISAbits.TRISA2
#define TRIS_COL_3         TRISAbits.TRISA3
#define TRIS_COL_4         TRISAbits.TRISA4
#define TRIS_COL_5         TRISAbits.TRISA5
#define TRIS_PIC_SDA       TRISBbits.TRISB0
#define TRIS_PIC_SCL       TRISBbits.TRISB1
#define TRIS_GATE_4        TRISBbits.TRISB2
#define TRIS_GATE_5        TRISBbits.TRISB3
#define TRIS_GATE_6        TRISBbits.TRISB4
#define TRIS_USB_LED       TRISBbits.TRISB5
#define TRIS_SPARE_0       TRISBbits.TRISB6
#define TRIS_SPARE_1       TRISBbits.TRISB7
#define TRIS_COL_6         TRISCbits.TRISC0
#define TRIS_GATE_0        TRISCbits.TRISC1
#define TRIS_GATE_1        TRISCbits.TRISC2
#define TRIS_GATE_2        TRISCbits.TRISC6
#define TRIS_GATE_3        TRISCbits.TRISC7

/* LAT */
#define LAT_COL_0          LATAbits.LATA0
#define LAT_COL_1          LATAbits.LATA1
#define LAT_COL_2          LATAbits.LATA2
#define LAT_COL_3          LATAbits.LATA3
#define LAT_COL_4          LATAbits.LATA4
#define LAT_COL_5          LATAbits.LATA5
#define LAT_PIC_SDA        LATBbits.LATB0
#define LAT_PIC_SCL        LATBbits.LATB1
#define LAT_GATE_4         LATBbits.LATB2
#define LAT_GATE_5         LATBbits.LATB3
#define LAT_GATE_6         LATBbits.LATB4
#define LAT_USB_LED        LATBbits.LATB5
#define LAT_SPARE_0        LATBbits.LATB6
#define LAT_SPARE_1        LATBbits.LATB7
#define LAT_COL_6          LATCbits.LATC0
#define LAT_GATE_0         LATCbits.LATC1
#define LAT_GATE_1         LATCbits.LATC2
#define LAT_GATE_2         LATCbits.LATC6
#define LAT_GATE_3         LATCbits.LATC7

#define MAX_ROWS           (7)
#define MAX_COLUMNS        (7)

/**
 * The USB endpoint has to be used to store the CDC buffers
 */
#define FIXED_ADDRESS_MEMORY
#define IN_DATA_BUFFER_ADDRESS_TAG      @0x500    // for CDC device (XC8)
#define OUT_DATA_BUFFER_ADDRESS_TAG     @0x540
#define CONTROL_BUFFER_ADDRESS_TAG      @0x580

/*** System States **************************************************/
typedef enum
{
    SYSTEM_STATE_USB_START,
    SYSTEM_STATE_USB_SUSPEND,
    SYSTEM_STATE_USB_RESUME
} SYSTEM_STATE;

/*********************************************************************
* Function: void SYSTEM_Initialize( SYSTEM_STATE state )
*
* Overview: Initializes the system.
*
* PreCondition: None
*
* Input:  SYSTEM_STATE - the state to initialize the system into
*
* Output: None
*
********************************************************************/
void SYSTEM_Initialize( SYSTEM_STATE state );

/*********************************************************************
* Function: void SYSTEM_Tasks(void)
*
* Overview: Runs system level tasks that keep the system running
*
* PreCondition: System has been initalized with SYSTEM_Initialize()
*
* Input: None
*
* Output: None
*
********************************************************************/
void SYSTEM_Tasks(void);

#endif //SYSTEM_H
