using System;
using System.Collections.Generic;
using System.Text;

//Fuente Paul Borke
//http://local.wasp.uwa.edu.au/~pbourke/miscellaneous/dft/

namespace LED_Matrix_CDC
{
    class Fourier
    {
        /*
           This computes an in-place complex-to-complex FFT 
           re and im are the real and imaginary arrays of 2^m points.
           dir =  1 gives forward transform
           dir = -1 gives reverse transform
        */
        public static void FFT(int dir, long m, double[] re, double[] im)
        {
           long n,i,i1,j,k,i2,l,l1,l2;
           double c1,c2,tx,ty,t1,t2,u1,u2,z;

           /* Calculate the number of points */
           n = 1;
           for (i=0;i<m;i++) 
              n *= 2;

           /* Do the bit reversal */
           i2 = n >> 1;
           j = 0;
           for (i=0;i<n-1;i++) {
              if (i < j) {
                 tx = re[i];
                 ty = im[i];
                 re[i] = re[j];
                 im[i] = im[j];
                 re[j] = tx;
                 im[j] = ty;
              }
              k = i2;
              while (k <= j) {
                 j -= k;
                 k >>= 1;
              }
              j += k;
           }

           /* Compute the FFT */
           c1 = -1.0; 
           c2 = 0.0;
           l2 = 1;
           for (l=0;l<m;l++) {
              l1 = l2;
              l2 <<= 1;
              u1 = 1.0; 
              u2 = 0.0;
              for (j=0;j<l1;j++) {
                 for (i=j;i<n;i+=l2) {
                    i1 = i + l1;
                    t1 = u1 * re[i1] - u2 * im[i1];
                    t2 = u1 * im[i1] + u2 * re[i1];
                    re[i1] = re[i] - t1; 
                    im[i1] = im[i] - t2;
                    re[i] += t1;
                    im[i] += t2;
                 }
                 z =  u1 * c1 - u2 * c2;
                 u2 = u1 * c2 + u2 * c1;
                 u1 = z;
              }
              c2 = Math.Sqrt((1.0 - c1) / 2.0);
              if (dir == 1) 
                 c2 = -c2;
              c1 = Math.Sqrt((1.0 + c1) / 2.0);
           }
           
           /* Scaling for forward transform */
           /*if (dir == 1) {
              for (i=0;i<n;i++) {
                 re[i] /= n;
                 im[i] /= n;
              }
           }
           */
        }

    }
}
