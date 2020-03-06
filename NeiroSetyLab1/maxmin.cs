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
        public int[] xx;
        public int[] xy;
        public int[] zx;
        public int[] zy;
        public int[] zx1;
        public int[] zy1;
        public int[] klaster;
        public double[ , ] d;
        public int zk;
        public int zi;
        public int k;
        public double maxd;
        public double mind;


        public void compute()
        {
            this.zx = new int[n];
            this.zy = new int[n];
            this.zx1 = new int[n];
            this.zy1 = new int[n];
            this.xx = new int[n];
            this.xy = new int[n];
            this.klaster = new int[n];
            this.d = new double[n,n]; 

            Random rnd = new Random();
            for (int i=0; i<n; i++)
            {
                xx[i] = rnd.Next(10);
                xy[i] = rnd.Next(10);
            }

            for (int i = 0; i < n; i++)
            {
                zx[i] = 0;
                zy[i] = 0;
                klaster[i] = 0;
                for (int j = 0; j < n; j++)
                {
                    d[i, j] = 0;
                }
            }
            this.zk = 0;
            zx[zk] = xx[0];
            zy[zk] = xy[0];
            zk++;
            klaster[0] = 1;
            this.zi = 0;
            this.k = 0;
            this.maxd = 0.0;
            this.mind = 100.0;

            //поиск дальне стоящей точки от первого z
            for (int i = 0; i < n; i++)
            {
                d[0, i] = evkl(zx[zk - 1], xx[i], zy[zk - 1], xy[i]);
                if (d[0, i] > maxd)
                {
                    k = i;
                    maxd = d[0, i];
                }
            }
            zx[zk] = xx[k];
            zy[zk] = xy[k];
            zk++;
            double dd;
            while (zk < n)
            {
                for (int i = 0; i < n; i++)
                {
                    for (int zk2 = 0; zk2 < zk; zk2++)
                        if ((xx[i] != zx[zk2]) || (xy[i] != zy[zk2]))
                        {
                            d[zk2, i] = evkl(zx[zk2], xx[i], zy[zk2], xy[i]);
                        }
                        else d[zk2, i] = 0;
                }
                mind = 100.0;
                maxd = 0.0;
                int kk = 0;
                bool f = true;
                for (int i = 0; i < n; i++)
                {
                    f = true;
                    mind = 100.0;
                    for (int zk2 = 0; zk2 < zk; zk2++)
                    {
                        if (d[zk2, i] == 0)
                        {
                            f = false;
                        }
                    }
                    if (f == true)
                    {
                        mind = 100.0;
                        for (int zk2 = 0; zk2 < zk; zk2++)
                        {
                            if (d[zk2, i] < mind)
                            {
                                mind = d[zk2, i];
                                k = i;
                            }
                        }

                        if (mind > maxd)
                        {
                            maxd = mind;
                            kk = k;
                        }
                    }
                }
                dd = 0.0;
                for (int i = 0; i < zk - 1; i++)
                {
                    dd += evkl(zx[i + 1], zx[i], zy[i + 1], zy[i]);
                }

                double kz = 1.0 / zk;

                if (maxd >= dd * kz)
                {
                    zx[zk] = xx[kk];
                    zy[zk] = xy[kk];
                    zk++;
                }
                else break;
            }
            dd = 0.0;
            mind = 100;
            k = 0;
            int c = 0;
            for (int i = 1; i < n; i++)
            {
                c = 0;
                mind = 100.0;
                for (int j = 0; j < zk; j++)
                    if ((xx[i] == zx[j]) && (xy[i] == zy[j]))
                    {
                        c = 1;
                        klaster[i] = j + 1;
                    }

                if (c == 0)
                {
                    for (int j = 0; j < zk; j++)
                    {
                        dd = evkl(xx[i], zx[j], xy[i], zy[j]);
                        if (dd < mind)
                        {
                            mind = dd;
                            klaster[i] = j + 1;
                        }
                    }
                }
            }



        }

        double evkl(int ax, int ay, int bx, int by)
        {
            return Math.Sqrt(Math.Pow((ax - bx), 2) + Math.Pow((ay - by), 2));
        }
    }
}
