using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExerciseC_
{
    public class Magazine : LibraryItem
    {
        public Magazine() { }
        public Magazine(LibraryItem library) : base(library.GetId(), library.GetTitle(), library.GetAuthor(), library.GetPublicationDate())
        {
        }
        public override string ToString()
        {
            return base.ToString() + ", Type: Magazine";
        }

    }
}
