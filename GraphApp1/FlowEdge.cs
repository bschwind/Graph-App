using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GraphApp.src
{
    public class FlowEdge : Edge
    {
        public float CurrentFlow { get; set; }
        public float Capacity { get; set; }

        public FlowEdge(Vertex from, Vertex to, float currentFlow, float capacity) : base(from, to)
        {
            Directed = true;
            CurrentFlow = currentFlow;
            Capacity = capacity;
        }
    }
}
