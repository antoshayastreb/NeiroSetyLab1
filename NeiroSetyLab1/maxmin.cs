using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeiroSetyLab1
{
    class maxmin
    {
        static int n = 10;
        public int[] xx = new int[n];
        public int[] xy = new int[n];
        public int[] zx = new int[n];
        public int[] zy = new int[n];
        public int[] zx1 = new int[n];
        public int[] zy1 = new int[n];
        public int klaster;
        public double[] d = new double[n];

        public void compute()
        {
            Random rnd = new Random();
            for (int i=0; i<n; i++)
            {
                xx[i] = rnd.Next(10);
                xy[i] = rnd.Next(10);
            }

            zx[0] = xx[0];
            zy[0] = xy[0];
            klaster = 1;

            double maxd = 0;


            for (int i = 1; i < n; i++)
            {
                if (maxd < evkl(zx[0], zy[0], xx[i], xy[i]))
                {
                    maxd = evkl(zx[0], zy[0], xx[i], xy[i]);
                    zx[1] = xx[i];
                    zy[1] = xy[i];
                }

            }

            klaster++;

            int k = 2;

            double arif = 0;

            while (k<10)
            {
                for (int j = 0; j < klaster; j++)
                {
                    double mind = 100;
                    int zx11 = 0;
                    int zy11 = 0;

                    for (int i = 1; i < n; i++)
                    {


                        if (mind > evkl(zx[j], zy[j], xx[i], xy[i]))
                        {
                            mind = evkl(zx[j], zy[j], xx[i], xy[i]);
                            zx11 = xx[i];
                            zy11 = xy[i];
                        }

                    }

                    d[j] = mind;
                    zx1[j] = zx11;
                    zy1[j] = zy11;
                }

                maxd = 0;
                int d1 = 0;

                for (int i = 0; i < klaster; i++)
                {
                    if (maxd < d[i])
                    {
                        maxd = d[i];
                        d1 = i;
                    }
                       

                }



                for (int i = 1; i < klaster; i++)
                {
                    arif += evkl(zx[i - 1], zy[i - 1], zx[i], zy[i]);
                }

                if (maxd >= (arif / klaster))
                {
                    zx[klaster] = zx1[d1];
                    zy[klaster] = zy1[d1];
                    klaster++;
                    k++;
                }
                else
                {
                    k = 10;
                }
                
            }


        }

        double evkl(int ax, int ay, int bx, int by)
        {
            return Math.Sqrt(Math.Pow((ax - bx), 2) + Math.Pow((ay - by), 2));
        }
    }
}
