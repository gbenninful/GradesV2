using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GradesV2
{
    public class ThrowAwayGradeBook : GradeBook
    {
        public ThrowAwayGradeBook(string name) : base(name)
        {
            Console.WriteLine("ThrowAwayGradeBook ctor");

        }

        public override void DoSomething()
        {
            
        }
        public override GradeStatistics ComputeStatistics()
        {
            //Using LINQ instead of foreach
            float lowest = _grades.Concat(new[] {float.MaxValue}).Min();

            _grades.Remove(lowest);
            return base.ComputeStatistics();
        }
    }
}
