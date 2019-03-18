/* -----------------------------------------------------------------
 * Project: LED Matrix with CDC
 * Author: Santiago Villafuerte (migsantiago.com - san.link@yahoo.com.mx)
 * -----------------------------------------------------------------*/

using System;
using System.Collections.Generic;
using System.Timers;

namespace LED_Matrix_CDC
{
    class Process_Ev
    {
        /**********************************************************************************************************************************************/
        /* Objects */

        static Main_Form main_form;

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

        static NAudio_Ctrl naudio = new NAudio_Ctrl();

        static Timer tmrDrawFFT = new Timer();

        const int TMR_AUDIO_FFT = 10;
        const int FFT_POWER = 10;
        static int MIN_SAMPLES_FOR_FFT = (int)Math.Pow(2D, (Double)FFT_POWER);
        static double MAX_FREQ_TO_PLOT = 12000D;
        static Double AMPLITUDE_LIMIT_PER_LED = (1 / 7D);

        /**********************************************************************************************************************************************/
        /* Types */

        private struct Point
        {
            public Double x;
            public Double y;

            public Point(Double x, Double y)
            {
                this.x = x;
                this.y = y;
            }
        };

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

            if (main_form.serialPort1.IsOpen)
            {
                main_form.serialPort1.Write(usb_buffer, 0, usb_buffer.Length);
            }
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

        /// <summary>
        /// It will enable the FFT sampling
        /// </summary>
        /// <param name="maxLeveldB">The highest LED will represent this level in dB (0.0 is gain 1)</param>
        /// <param name="maxFrequency">The right most band represents this family of Hz</param>
        public static void Enable_Audio_FFT(Double maxLeveldB, Double maxFrequency)
        {
            MAX_FREQ_TO_PLOT = maxFrequency;
            AMPLITUDE_LIMIT_PER_LED = maxLeveldB;

            tmrDrawFFT.Enabled = false;
            tmrDrawFFT.Interval = TMR_AUDIO_FFT;
            tmrDrawFFT.Elapsed += handleTmrDrawFFT;
            naudio.Start_Audio_Capture();
            tmrDrawFFT.Enabled = true;
        }

        /// <summary>
        /// Disable the FFT plotting
        /// </summary>
        public static void Disable_Audio_FFT()
        {
            tmrDrawFFT.Enabled = false;
            tmrDrawFFT.Interval = TMR_AUDIO_FFT;
            tmrDrawFFT.Elapsed -= handleTmrDrawFFT;
        }

        /// <summary>
        /// Time to draw an FFT
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private static void handleTmrDrawFFT(object sender, ElapsedEventArgs e)
        {
            Process_Audio_Data();
        }

        /// <summary>
        /// Call this function whenever data has to be processed
        /// </summary>
        public static void Process_Audio_Data()
        {
            if (!naudio.isRecording())
                return;

            Int32 fft_samples = MIN_SAMPLES_FOR_FFT;
            NAudio_Ctrl.DataInfo dataInfo;

            if (!naudio.getWaveFormat(out dataInfo))
                return;

            Int32 sample_freq = dataInfo.SampleRate;

            double[] audioSamples;
            if (!naudio.getAudioSamples(out audioSamples))
                return;

            if (audioSamples.Length < fft_samples)
                return;

            /* Small data array */
            Double[] data_r = new Double[fft_samples];
            Double[] data_i = new Double[fft_samples];

            /* Copy some data only */
            int i = 0;
            for (i = 0; i < fft_samples; ++i)
            {
                data_r[i] = audioSamples[i];
            }

            /* Apply a Hamming window */
            Ventaneo.Hamming(data_r);

            /* Get the FFT */
            const int pot = FFT_POWER; /* 2 ^ pot = fft_samples */
            Fourier.FFT(1, pot, data_r, data_i);
            double[] freq_resp = new double[(fft_samples / 2) + 1];
            for (i = 0; i < (1 + (fft_samples / 2)); ++i) /* Include the Nyquist frequency */
            {
                freq_resp[i] = Math.Sqrt(data_r[i] * data_r[i] + data_i[i] * data_i[i]);
            }
            for (i = 0; i < freq_resp.GetLength(0); ++i)
            {
                freq_resp[i] /= fft_samples;
            }
            for (i = 1; i < (freq_resp.GetLength(0) - 1); ++i)
            {
                freq_resp[i] *= 2;
            }

            ///* Get the max frequency values */
            //Double[] Max_Freq_Values = null;
            //if (Max_Freq_Values == null)
            //{
            //    Max_Freq_Values = new Double[(fft_samples / 2) + 1];
            //}
            //for (i = 0; i < (1 + (fft_samples / 2)); ++i)
            //{
            //    if (freq_resp[i] > Max_Freq_Values[i])
            //    {
            //        Max_Freq_Values[i] = freq_resp[i];
            //    }
            //}

            /* Draw the frequency response graphic */
            int j = 0;
            List<Point> fxy = new List<Point>();
            double x = 0;
            foreach (double r in freq_resp)
            {
                x = sample_freq / (double)fft_samples * (double)j++;
                fxy.Add(new Point(x, r));
            }

            ///* Draw the max frequency response graphic */
            //j = 0;
            //PointPairList fxy_max = new PointPairList();
            //foreach (double r in naudio.Max_Freq_Values)
            //{
            //    x = sample_freq / (double)fft_samples * (double)j++;
            //    fxy_max.Add(x, r);
            //}

            /* Group data into bands */
            const int bands = 7;
            Double[] band_limits = new Double[bands];
            for (i = 0; i < bands; ++i)
            {
                band_limits[i] = (MAX_FREQ_TO_PLOT / bands) * (Double)(i + 1);
            }

            Double[] band_data = new Double[bands];
            j = 0; /* Frequency index */
            for (i = 0; i < bands; ++i)
            {
                while (fxy[j].x < band_limits[i])
                {
                    band_data[i] += fxy[j].y;
                    ++j;
                }
            }

            /* Calculate the limits of each band for each LED */
            Double[] led_limits = new Double[7];
            for (i = 0; i < 7; ++i)
            {
                led_limits[i] = AMPLITUDE_LIMIT_PER_LED * ((Double)i + 1);
            }

            /* LED matrix */
            Boolean[,] led_matrix = new Boolean[7, 7];

            for (int band = 0; band < 7; ++band)
            {
                for (int level = 0; level < 7; ++level)
                {
                    if (band_data[band] > led_limits[level])
                    {
                        led_matrix[band, level] = true;
                    }
                }
            }

            Draw_Raw_Frame(led_matrix);
        }
    }
}
