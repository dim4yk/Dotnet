using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace L7
{
    class Program
    {
        static Random rand = new Random();
        public static Thread t;

        static void Main(string[] args)
        {

            int[,] A = MatrixGenerator(20, 30, true);
            int[,] B = MatrixGenerator(30, 20, true);

            int[,] C = null;

            t = new Thread(() => { C = Multiplication(A, B); });
            Console.WriteLine("Action starts...");
            Thread.Sleep(2000);
            t.Start();

            t.Join();
            MatrixPrint(C);

            Console.WriteLine("Wait 7 sec.");
            Thread.Sleep(7000);
           
        }

            public static int[,] MatrixGenerator(int n, int m, bool random = false)
            {
                if (n <= 0 || m <= 0)
                {
                    Console.WriteLine("Matrix sizes must be > 0");
                    return null;
                }

                int[,] MatrixArr = new int[n, m];
                if (random == false)
                {
                    for (int row = 0; row < n; row++)
                    {
                        for (int col = 0; col < m; col++)
                        {
                            MatrixArr[row, col] = 0;
                        }
                    }
                }
                else
                {
                    for (int row = 0; row < n; row++)
                    {
                        for (int col = 0; col < m; col++)
                        {
                            MatrixArr[row, col] = rand.Next(0, 999);
                        }
                    }
                }
                return MatrixArr;
            }


            public static int[,] Multiplication(int[,] A, int[,] B)
            {
                if (A.GetLength(0) <= 0 || A.GetLength(1) <= 0 || B.GetLength(0) <= 0 || B.GetLength(1) <= 0)
                {
                    Console.WriteLine("Matrix can't be multiplied. Matrix sizes must be > 0");
                    return null;
                }

                if (A.GetLength(0) != B.GetLength(1) || A.GetLength(1) != B.GetLength(0))
                {
                    Console.WriteLine("Matrix can't be multiplied. Count of colomns must be equals count of rows");
                    return null;
                }

                int[,] C = new int[A.GetLength(0), B.GetLength(1)];

                
            
                for (int row = 0; row < A.GetLength(0); row++)
                {
                    for (int col = 0; col < B.GetLength(1); col++)
                    {
                        C[row, col] = 0;
                    Console.Clear();
                    Console.WriteLine("Element in action:" + "C[" + (row+1) + ", " + (col+1) + "]");
                    for (int i = 0; i < B.GetLength(0); i++)
                        {
                            C[row, col] = C[row, col] + A[row, i] * B[i, col];
                        
                            if (Console.KeyAvailable)
                            {
                            Console.WriteLine("Key pressed! Thread aborting...");
                            if (t != null)
                            {
                                try
                                {
                                    t.Abort();
                                }
                                catch (ThreadAbortException)
                                {
                                    Console.WriteLine("Process was stopped by user!");
                                }
                            }
                            }
                        }
                    }
                }
                return C;
            }

            public static void MatrixPrint(int[,] A)
            {
                if (A != null)
                {
                    for (int row = 0; row < A.GetLength(0); row++)
                    {
                        for (int col = 0; col < A.GetLength(1); col++)
                        {
                            Console.Write("{0}\t", A[row, col]);

                        }
                        Console.WriteLine();
                    }
                }
                else
                {
                    Console.WriteLine("Nothing to print, cause matrix is empty!");
                }

            }
        
        }
}
