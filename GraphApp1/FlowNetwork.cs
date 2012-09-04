using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GraphApp.src
{
    public class FlowNetwork : Graph
    {
        private Vertex source, sink;

        public FlowNetwork() : base()
        {
            Directed = true;
        }

        public Vertex GetSource()
        {
            return source;
        }

        public void SetSource(Vertex s)
        {
            source = s;
        }

        public Vertex GetSink()
        {
            return sink;
        }

        public void SetSink(Vertex s)
        {
            sink = s;
        }

        public void UpdateEdgeFlow(FlowEdge fe)
        {
            FlowEdge edge = FindEdge(fe);
            if (edge != null)
            {
                edge.CurrentFlow = edge.CurrentFlow + fe.CurrentFlow;
            }
        }

        public FlowEdge FindEdge(FlowEdge fe)
        {
            foreach (FlowEdge flowEdge in edges)
            {
                if (flowEdge.Equals(fe))
                {
                    return flowEdge;
                }
            }

            return null;
        }
    }
}
