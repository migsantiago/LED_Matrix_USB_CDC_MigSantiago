/* -----------------------------------------------------------------
 * Project: LED Matrix with CDC
 * Author: Santiago Villafuerte (migsantiago.com - san.link@yahoo.com.mx)
 * -----------------------------------------------------------------*/

using System;
using System.Collections.Generic;
using System.Text;

namespace LED_Matrix_CDC
{
    class Process_Ev
    {
        /**********************************************************************************************************************************************/
        /* Objects */

        static Main_Form main_form = new Main_Form();

        public enum Matrix_Rotation_T
        {
            ROTATE_0_DEG = 0,
            ROTATE_90_DEG,
            ROTATE_180_DEG,
            ROTATE_270_DEG
        };

        /* List of commands to send to the PIC */
        public enum PIC_Command
        {
            UNUSED = 0,                 /* Unused */
            DRAW_RAW_FRAME,             /* Draw the sent frame */
            SET_RTC,                    /* Send the current time to the PIC */
            DRAW_A_NUMBER,              /* Draw a number */
            DRAW_TIME,                  /* Draw the current time */
            SET_ROTATION,               /* Set the matrix rotation */
            GAME_OF_LIFE,               /* Play the game of life */
            MAX_COMMANDS
        };

        const Int32 OUT_BUFFER_SIZE = 64;

        /**********************************************************************************************************************************************/
        /* Methods */

        /// <summary>
        /// Get a reference to the main form
        /// </summary>
        /// <param name="frm"></param>
        public static void Set_Main_Form_Ref(Main_Form frm)
        {
            main_form = frm;
        }

        /// <summary>
        /// Start capturing audio
        /// </summary>
        public static Boolean Initialize()
        {
            Boolean result = true;

            return result;
        }

        /// <summary>
        /// Call this to destroy classes
        /// </summary>
        public static void Shutdown()
        {

        }

        /// <summary>
        /// Just draw a number on the matrix
        /// </summary>
        public static void Draw_A_Number(Byte number)
        {
            Byte[] usb_buffer = new Byte[OUT_BUFFER_SIZE];
            usb_buffer[0] = (Byte)PIC_Command.DRAW_A_NUMBER;
            usb_buffer[1] = number; /* number to draw */

            main_form.serialPort1.Write(usb_buffer, 0, usb_buffer.Length);
        }

        /// <summary>
        /// Send the current time to the PIC
        /// </summary>
        public static void Set_PIC_Time()
        {
            Byte[] usb_buffer = new Byte[OUT_BUFFER_SIZE];
            usb_buffer[0] = (Byte)PIC_Command.SET_RTC;
            usb_buffer[1] = (Byte)DateTime.Now.Hour;
            usb_buffer[2] = (Byte)DateTime.Now.Minute;
            usb_buffer[3] = (Byte)DateTime.Now.Second;

            main_form.serialPort1.Write(usb_buffer, 0, usb_buffer.Length);
        }

        /// <summary>
        /// Draw the current time in the matrix
        /// </summary>
        public static void Draw_Time()
        {
            Byte[] usb_buffer = new Byte[OUT_BUFFER_SIZE];
            usb_buffer[0] = (Byte)PIC_Command.DRAW_TIME;

            main_form.serialPort1.Write(usb_buffer, 0, usb_buffer.Length);
        }

        public static void Set_Matrix_Rotation(Matrix_Rotation_T rotate)
        {
            Byte[] usb_buffer = new Byte[OUT_BUFFER_SIZE];
            usb_buffer[0] = (Byte)PIC_Command.SET_ROTATION;
            usb_buffer[1] = (Byte)rotate;

            main_form.serialPort1.Write(usb_buffer, 0, usb_buffer.Length);
        }

        public static void Play_Game_Of_Life()
        {
            Byte[] usb_buffer = new Byte[OUT_BUFFER_SIZE];
            usb_buffer[0] = (Byte)PIC_Command.GAME_OF_LIFE;

            main_form.serialPort1.Write(usb_buffer, 0, usb_buffer.Length);
        }

        public static void Draw_Raw_Frame(Boolean[,] matrix)
        {
            Byte[] usb_buffer = new Byte[OUT_BUFFER_SIZE];
            usb_buffer[0] = (Byte)PIC_Command.DRAW_RAW_FRAME;

            for (int band = 0; band < 7; ++band)
            {
                for (int level = 0; level < 7; ++level)
                {
                    if (matrix[level, band])
                    {
                        usb_buffer[level + 1] |= Convert_Band_Into_Matrix_Bits(band);
                    }
                }
            }
            main_form.serialPort1.Write(usb_buffer, 0, usb_buffer.Length);
        }

        /// <summary>
        /// Convert a column into its corresponding PIC column
        /// </summary>
        /// <param name="band"></param>
        /// <returns></returns>
        private static Byte Convert_Band_Into_Matrix_Bits(int band)
        {
            Dictionary<int, Byte> map = new Dictionary<int, byte>();

            map.Add(0, 0x40);
            map.Add(1, 0x20);
            map.Add(2, 0x10);
            map.Add(3, 0x08);
            map.Add(4, 0x04);
            map.Add(5, 0x02);
            map.Add(6, 0x01);

            return map[band];
        }
    }
}
