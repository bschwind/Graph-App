using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GraphApp.src
{
    public class PrimData : IComparable<PrimData>
    {
        public bool InMST, Seen;
        public float D;
        public float EdgeLength;
        public Vertex V, Predecessor;

        public int CompareTo(PrimData other)
        {
            return this.D.CompareTo(other.D);
        }
    }
}
