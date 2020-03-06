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
        

        public int stop = 0;
        public int[] xx;
        public int[] xy;
        public int[] zx1;
        public int[] zx;
        public int[] zy;
        public int[] zy1;
        public int[] klaster = new int[n];
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

        public int k { get; set; }

        public void compute()
        {
            this.zx = new int[k];
            this.zy = new int[k];
            this.zx1 = new int[k];
            this.zy1 = new int[k];
            this.xx = new int[n];
            this.xy = new int[n];

            Random rnd = new Random();
            for (int i=0; i<n; i++)
            {
                xx[i] = rnd.Next(10);
                xy[i] = rnd.Next(10);
            }

            for (int i = 0; i < n; i++)
            {
                klaster[i] = 0;
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
                klaster[iz] = iz + 1;
            }

            int c = 0;
            double mind = 0.0;
            double d1 = 0.0;
            int j = 0;
            int sumx = 0;
            int sumy = 0;
            int kk = 0;
            //алгоритм k-внутригрупповых средних
            do
            {
                c = 0;
                //сохранение значений кластеров за тот шаг
                for (int iz = 0; iz < k; iz++)
                {
                    zx1[iz] = zx[iz];
                    zy1[iz] = zy[iz];
                }
                //распределение образов
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
                    klaster[i] = j + 1;
                    mind = 100.0;
                }
                //пересчет координат центров
                for (int iz = 0; iz < k; iz++)
                {
                    sumx = 0;
                    sumy = 0;
                    kk = 0;
                    for (int i = 0; i < n; i++)
                    {
                        if (klaster[i] == (iz + 1))
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
                }
                //проверка значений центров кластеров на предыдущем шаге и на этом
                for (int iz = 0; iz < k; iz++)
                {
                    if ((zx1[iz] != zx[iz]) && (zy1[iz] != zy[iz]))
                    {
                        c = 1;
                    }
                }
            } while (c == 1);
            //конец цикла

        }
    }
}
