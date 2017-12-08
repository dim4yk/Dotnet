using System;
using System.Collections.Generic;
using System.Text;

namespace Project1
{
    class Test
    {
        public static void Main(string[] args) {
            Exam[] TestExams = new Exam[] {
                new Exam("Math",5,new DateTime(2017,6,3)),
                new Exam("Computer science", 4, new DateTime(2017, 6, 9)) };

            Student stud = new Student(new Person("Simon", "Willson", new DateTime(1991, 3, 2)), Education.Master, 222,TestExams);

            Console.WriteLine(stud.ToShortString());

            Console.WriteLine("\nIndexator:\n");
            Console.WriteLine("Bachelor:" + stud[Education.Bachelor]);
            Console.WriteLine("Master:" + stud[Education.Master]);
            Console.WriteLine("Second Education:" + stud[Education.SecondEducation]);

            Console.WriteLine(stud.ToString());


            Exam[] TestExams2 = new Exam[] {
                new Exam("Biology",3,new DateTime(2017,6,17)),
                new Exam("Economic", 4, new DateTime(2017, 6, 23)) };

            stud.AddExams(TestExams2);
            Console.WriteLine("\n Added exams: \n" + stud.ToString());



            Console.WriteLine("Enter dimension use comma (,) or semicolon (;)");
            string dim = Console.ReadLine();
            string[] mas = null;

            for (int i = 0; i < dim.Length; i++) {
                if (dim[i] == ',')
                {
                    mas = dim.Split(',');
                }
                else if (dim[i] == ';') {
                    mas = dim.Split(';');
                }
            }

            int nRows = Int32.Parse(mas[0].Trim());
            int nColumns = Int32.Parse(mas[1].Trim());

            Exam[] array1 = new Exam[nColumns];

            for (int i = 0; i < nColumns; i++) {
                array1[i] = new Exam();
            }

            Double sInterv1 = Environment.TickCount;

            for (int i = 0; i < nColumns; i++) {
                array1[i].subject = "English";
                array1[i].mark = 5;
            }

            Double eInterv1 = Environment.TickCount;

            Double difference = eInterv1 - sInterv1;

            Console.WriteLine("First difference: " + difference);



            Exam[,] array2 = new Exam[nRows,nColumns];

            for (int i = 0; i < nRows; i++)
            {
                for(int j = 0; j < nColumns; j++)
                {
                    array2[i,j] = new Exam();
                }                    
            }

            Double sInterv2 = Environment.TickCount;


            for (int i = 0; i < nRows; i++)
            {
                for (int j = 0; j < nColumns; j++)
                {
                    array2[i, j].subject = "Deutch";
                    array2[i, j].mark = 4;
                }
            }

            Double eInterv2 = Environment.TickCount;

            difference = eInterv2 - sInterv2;

            Console.WriteLine("Second difference: " + difference);


            Exam[][] array3 = new Exam[nRows] [];

            for (int i = 0; i < nRows; i++)
            {
                array3[i] = new Exam[nRows+1-i];
            }

            for (int i = 0; i < nRows; i++) {
                for (int j = 0; j < array3[i].Length; j++) {
                    array3[i][j] = new Exam();
                }
            }

            Double sInterv3 = Environment.TickCount;


            for (int i = 0; i < nRows; i++)
            {
                for (int j = 0; j < array3[i].Length; j++)
                {
                    array3[i][j].subject = "Dutch";
                    array3[i][j].mark = 5;
                }
            }

            Double eInterv3 = Environment.TickCount;

            difference = eInterv3 - sInterv3;

            Console.WriteLine("Third difference: " + difference);

            Console.ReadKey();
        }
    }
}
