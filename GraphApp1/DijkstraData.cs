using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GraphApp.src
{
    public class DijkstraData : IComparable<DijkstraData>
    {
        public float D;
        public bool InTree, InQ;
        public Vertex V, Predecessor;
        public float EdgeLength;

        public int CompareTo(DijkstraData other)
        {
            return this.D.CompareTo(other.D);
        }
    }
}
