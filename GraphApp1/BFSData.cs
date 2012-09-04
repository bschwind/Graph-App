using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GraphApp.src
{
    public class BFSData
    {
        public Edge PredecessorEdge;

        public BFSData(Edge pe)
        {
            PredecessorEdge = pe;
        }
    }
}
