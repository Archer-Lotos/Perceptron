using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplicationPerceptron
{
        class Perceptron
        {
            private double[] enters;
            private double outer;
            private double[] weights;
            private Random rand = new Random();

            public Perceptron()
            {
                enters = new double[2];
                weights = new double[enters.Length];
                for (int i = 0; i < enters.Length; i++)
                {
                    weights[i] = rand.Next(0, 10) * 0.2 + 0.1;
                }
            }

            public void countOuter()
            {
                outer = 0;
                for (int i = 0; i < enters.Length; i++)
                {
                    outer += enters[i] * weights[i];
                }
                if (outer > 0.5)
                {
                    outer = 1;
                }
                else
                {
                    outer = 0;
                }
            }

            public int StartStuding()
            {
                double[,] patterns = {
{1,0, 1},
{1,1, 0}
};

                double globalError;
                int rd = 0;
                for (int it = 0; it < 10000; it++)
                {
                    globalError = 0;
                    for (int p = 0; p < 2; p++)
                    {
                        enters[0] = patterns[p, 0];
                        enters[1] = patterns[p, 1];
                        countOuter();
                        double error = patterns[p, 2] - outer;
                        globalError += Math.Abs(error);
                        for (int i = 0; i < enters.Length; i++)
                        {
                            weights[i] += 0.1 * error * enters[i];
                        }
                    }

                    if (globalError == 0)
                    {
                        rd = it;
                        break;
                    }
                }
                return rd;
            }

            public void test()
            {

                double[,] patterns = {
{1,0, 1},
{1,1, 0}
};

                int w = StartStuding();
                Console.WriteLine(w);

                for(int p=0; p<2; p++){
                    enters[0] = patterns[p, 0];
                    enters[1] = patterns[p, 1];
                countOuter();
                Console.WriteLine(outer);
                }
            }
        }
}
