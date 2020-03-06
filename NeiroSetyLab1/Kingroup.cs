using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeiroSetyLab1
{
    class Kingroup
    {
        static int n = 10;
        static int k = 3;
        public int stop = 0;
        public int[] xx = new int[] { 8, 5, 1, 9, 6, 7, 6, 4, 6, 8 };
        public int[] xy = new int[] { 9, 5, 1, 1, 6, 6, 8, 7, 7, 1 };
        public int[] zx = new int[k];
        public int[] zy = new int[k];
        public int[] zx1 = new int[k];
        public int[] zy1 = new int[k];
        public int[] klasteri = new int[n];
        public double d1 = 0.0;
        public double d2 = 0.0;
        public double mind = 100.0;
        public int c = 0;
        public int j = 0;
        public int sumx = 0;
        public int sumy = 0;
        public int kk = 0;

        double funsqr(int a, int b, int c, int d)
        {
            return Math.Sqrt(Math.Pow(a - b, 2) + Math.Pow(c - d, 2));
        }

        public void compute()
        {

            for (int i = 0; i < n; i++)
            {
                klasteri[i] = 0;
            }

            for (int i = 0; i < k; i++)
            {
                zx[i] = 0;
                zy[i] = 0;
                zx1[i] = 0;
                zy1[i] = 0;
            }

            for (int iz = 0; iz < k; iz++)
            {
                zx[iz] = xx[iz];
                zy[iz] = xy[iz];
                klasteri[iz] = iz + 1;
            }

            while ((c == 1) && (stop < 100))
            {
                c = 0;
                for (int iz = 0; iz < k; iz++)
                {
                    zx1[iz] = zx[iz];
                    zy1[iz] = zy[iz];
                }

                for (int i = 0; i < n; i++)
                {
                    for (int iz = 0; iz < k; iz++)
                    {
                        d1 = funsqr(xx[i], zx[iz], xy[i], zy[iz]);
                        if (d1 < mind)
                        {
                            mind = d1;
                            j = iz;
                        }
                    }
                    klasteri[i] = j + 1;
                    mind = 100.0;
                }



                for (int iz = 0; iz < k; iz++)
                {
                    sumx = 0;
                    sumy = 0;
                    kk = 0;
                    for (int i = 0; i < n; i++)
                    {
                        if (klasteri[i] == (iz + 1))
                        {
                            sumx += xx[i];
                            sumy += xy[i];
                            kk++;
                        }
                    }
                    if (kk != 0)
                    {
                        zx[iz] = sumx / kk;
                        zy[iz] = sumy / kk;
                    }
                    else
                    {
                        zx[iz] = sumx;
                        zy[iz] = sumy;
                    }

                    for (iz = 0; iz < k; iz++)
                    {
                        if ((zx1[iz] != zx[iz]) && (zy1[iz] != zy[iz]))
                        {
                            c = 1;
                        }
                    }


                }

                stop++;
            }
        }
    }
}
