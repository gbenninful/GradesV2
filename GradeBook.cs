using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GradesV2
{
    public class GradeBook : GradeTracker
    {
        protected List<float> _grades;
       

        public GradeBook(string name = "There is no name")
        {
            Console.WriteLine("GradeBook ctor");
            _grades = new List<float>();
            Name = name;

            if (name == null)
            {
                throw new ArgumentNullException("Use a valid name");
            }

        }

        public override void AddGrade(float grade)
        {
            if (grade >= 0 && grade <= 100)
            {
                _grades.Add(grade);
            }

        }

        public override GradeStatistics ComputeStatistics()
        {
            var stats = new GradeStatistics();

            float sum = 0f;

            foreach (float grade in _grades)
            {
                stats.HighestGrade = Math.Max(grade, stats.HighestGrade);
                stats.LowestGrade = Math.Min(grade, stats.LowestGrade);

                sum = sum + grade;
            }

            stats.AverageGrade = sum / _grades.Count;

            return stats;
        }

        public override void WriteGrades(TextWriter textWriter)
        {
            textWriter.WriteLine("Here comes the grades");

            foreach (var grade in _grades)
            {
                textWriter.WriteLine(grade);
            }
            textWriter.WriteLine("**************");
        }

        public override void DoSomething()
        {
            
        }

        public override IEnumerator GetEnumerator()
        {
            return _grades.GetEnumerator();
        }
    }
}
