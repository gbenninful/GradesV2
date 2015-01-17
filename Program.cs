using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GradesV2
{
    class Program
    {
        static void Main(string[] args)
        {
            IGradeTracker book = CreateGradeBook();

            try
            {
                using (FileStream stream = File.Open("grades.txt", FileMode.Open))
                using (StreamReader reader = new StreamReader(stream))
                {
                    string line = reader.ReadLine();

                    while (line != null)
                    {
                        float grade = float.Parse(line);
                        book.AddGrade(grade);
                        line = reader.ReadLine();
                    }
                }
            }

            catch (FileNotFoundException)
            {
                Console.WriteLine("Could not locate file grades.txt");
                return;
            }

            foreach (float grade in book)
            {
                Console.WriteLine(grade);
            }

            book.NameChanged += OnNameChanged;

            try
            {
                Console.WriteLine("Please enter the name of your book");
                book.Name = Console.ReadLine();
            }
            catch (ArgumentException)
            {
                Console.WriteLine("Sorry, that's an Invalid Name");
            }


            GradeStatistics stats = book.ComputeStatistics();

            WriteNames(book.Name);

            Console.WriteLine(stats.AverageGrade);
            Console.WriteLine(stats.LowestGrade);
            Console.WriteLine(stats.HighestGrade);

            Console.ReadLine();
        }

        private static IGradeTracker CreateGradeBook()
        {
            IGradeTracker book = new ThrowAwayGradeBook("Brody Marlon's book");
            return book;
        }

        private static void OnNameChanged(object sender, NameChangedEventArgs args)
        {
            Console.WriteLine("The book name changed from {0} to {1}", args.OldValue, args.NewValue);
        }



        private static void WriteNames(params string[] names)
        {
            foreach (string name in names)
            {
                Console.WriteLine(name);
            }
        }

    }
}


