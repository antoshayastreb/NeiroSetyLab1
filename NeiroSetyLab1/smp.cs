using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeiroSetyLab1
{
    class smp
    {
        //static int n { get; set; }

        static int n = 20;

        public int[] xx = new int[n];

        public int[] xy = new int[n];

        public int[] zx = new int[n];

        public int[] zy = new int[n];

        public int[] klaster = new int[n];

        public double[,] d = new double[n, n];

        public int zi = 0;
        
        public int xi = 1;
        
        public int k = 0;

        public int T { get; set; }

        public void setRand()
        {
            Random rand = new Random();
            for (int i = 0; i < n; i++)
            {
                xx[i] = rand.Next(9);
                xy[i] = rand.Next(9);
            }
        }

        public void compute()
        {
            zx[0] = xx[0];
            zy[0] = xy[0];

            klaster[0] = 1;

            

            while (xi < n)
            {
                double mind = 10.0;

                for (int i = 0; i <= zi; i++)
                {
                    d[i, xi] = Math.Sqrt(Math.Pow(xx[xi] - zx[i], 2) + Math.Pow(xy[xi] - zy[i], 2));

                    if (d[i, xi] < mind)
                    {
                        mind = d[i, xi];
                        k = i;
                    }
                }

                if (mind < T)
                {
                    klaster[xi] = k + 1;
                    xi++;
                }
                else
                {
                    zi++;
                    zx[zi] = xx[xi];
                    zy[zi] = xy[xi];
                }
            }
        }
    }
}
