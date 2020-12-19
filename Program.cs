using System;

namespace Milne_Simpson_method
{
    class Program
    {
        static double h = 0.1;
        static int steps = Convert.ToInt32(5 / h) + 1;
        static void Main(string[] args)
        {
            double[] x = new double[steps + 1];
            double[] y = new double[steps + 1];
            double[] yp = new double[steps + 1];
            double[] f = new double[steps + 1];
            x[0] = 0;
            y[0] = yp[0] = f[0] = 1;
            y[1] = yp[1] = f[1] = 1.1170;
            y[2] = yp[2] = f[2] = 1.2755;
            y[3] = yp[3] = f[3] = 1.4779;
            for (int i = 1; i < steps; i++)
            {
                x[i] = x[i - 1] + h;
            }

            milne(f, y, x);
            milneP(f, yp, x);
            Console.Read();
        }
        static double dy(double t, double y)
        {
            return y + 3 * t - (t * t);
        }
        static void milne(double[] f, double[] y, double[] x)
        {
            double pold = 0, yold = 0;
            for (int k = 4; k < steps; k++)
            {
                //Predictor
                double pnew = y[k - 4] + (4 * h / 3) * (2 * f[k - 3] - f[k - 2] + 2 * f[k - 1]);
                //Modifier
                double pmod = pnew + 28 * (yold - pold) / 29;
                f[k] = dy(x[k], pmod);
                //Corrector
                y[k] = y[k - 2] + (h / 3) * (f[k - 2] + 4 * f[k - 1] + f[k]);
                pold = pnew;
                yold = y[k];
                f[k + 1] = dy(x[k], y[k]);
            }
            Console.WriteLine("Modifier:");
            for (int i = 0; i < steps; i++)
            {
                Console.WriteLine(x[i].ToString() + "        " + y[i].ToString());
            }
        }

        static void milneP(double[] f, double[] y, double[] x)
        {
            double pold = 0, yold = 0;
            for (int k = 4; k < steps; k++)
            {
                //Predictor
                double pnew = y[k - 4] + (4 * h / 3) * (2 * f[k - 3] - f[k - 2] + 2 * f[k - 1]);

                f[k] = dy(x[k], pnew);
                //Corrector
                y[k] = y[k - 2] + (h / 3) * (f[k - 2] + 4 * f[k - 1] + f[k]);
                pold = pnew;
                yold = y[k];
                f[k + 1] = dy(x[k], y[k]);
            }
            Console.WriteLine("No Modifier:");
            for (int i = 0; i < steps; i++)
            {
                Console.WriteLine(x[i].ToString() + "        " + y[i].ToString());
            }
        }
    }
}
