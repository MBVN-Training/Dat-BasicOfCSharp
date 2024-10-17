using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExerciseC_
{
    public class DVD : LibraryItem
    {
        public double RunTime { get; set; }
        public DVD() { }

        public DVD(LibraryItem library, double runTime)
        : base(library.GetId(), library.GetTitle(), library.GetAuthor(), library.GetPublicationDate())  // Gọi constructor của lớp cha
        {
            RunTime = runTime;
        }

        public double GetRunTime()
        {
            return RunTime;
        }

        public void SetRunTime(double runTime)
        {
            RunTime = runTime;
        }

        public override string ToString()
        {
            return base.ToString() + $", Run Time: {RunTime} minutes, Type: DVD";
        }
    }
}
