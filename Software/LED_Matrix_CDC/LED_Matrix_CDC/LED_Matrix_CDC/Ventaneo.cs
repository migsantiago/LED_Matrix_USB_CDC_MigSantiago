using System;
using System.Collections.Generic;
using System.Text;

//Clase que implementa ventanas para señales que serán entregadas
//a la FFT

namespace LED_Matrix_CDC
{
    class Ventaneo
    {
        /////////////////////////////////////////////////////////////////////
        //Ventana de Hamming
        public static void Hamming(double[] senal)
        {
            double v;
            int N = senal.GetLength(0);

            for (int n = 0; n < N; ++n)
            {
                v = 0.54 - (0.46 * 
                    Math.Cos((2D * Math.PI * (double)n) / ((double)N - 1D)));
                senal[n] *= v;
            }                 
        }
        /////////////////////////////////////////////////////////////////////

        /////////////////////////////////////////////////////////////////////
        //Ventana de Hann
        public static void Hann(double[] senal)
        {
            double v;
            int N = senal.GetLength(0);

            for (int n = 0; n < N; ++n)
            {
                v = 0.5 * (1D -
                    Math.Cos((2D * Math.PI * (double)n) / ((double)N - 1D)));
                senal[n] *= v;
            }
        }
        /////////////////////////////////////////////////////////////////////

        /////////////////////////////////////////////////////////////////////
        //http://archive.chipcenter.com/dsp/DSP000308F1.html
        //http://en.wikipedia.org/wiki/Window_function#cite_note-K-term_windows-8
        //Ventana Nuttall para FFT de alto rango dinámico
        public static void Nuttall(double[] senal)
        {
            double v;
            int N = senal.GetLength(0);

            for (int n = 0; n < N; ++n)
            {
                v = 0.355768
                    - (0.487396 * Math.Cos((2D * Math.PI * (double)n) / ((double)N - 1D)))
                    + (0.144232 * Math.Cos((4D * Math.PI * (double)n) / ((double)N - 1D)))
                    - (0.012604 * Math.Cos((6D * Math.PI * (double)n) / ((double)N - 1D)));
                senal[n] *= v;
            }
        }
        /////////////////////////////////////////////////////////////////////

    }
}
