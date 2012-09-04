using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace GraphApp.src
{
    public class Edge : IComparable<Edge>
    {
        private Vertex fromVertex, toVertex;

        [Browsable(false)]
        public bool Directed { get; set; }
        public bool ShowLabel { get; set; }
        public float Weight { get; set; }

        public Edge(Vertex from, Vertex to)
        {
            if (from == null || to == null)
            {
                throw new Exception("Can't create an edge with one or more null vertices");
            }

            fromVertex = from;
            toVertex = to;

            Weight = 1;
        }

        public Edge(Vertex from, Vertex to, float weight) : this(from, to)
        {
            Weight = weight;
        }

        public Edge(Vertex from, Vertex to, float weight, bool directed)
            : this(from, to, weight)
        {
            Weight = weight;
            Directed = directed;
        }

        public void SetFromVertex(Vertex v)
        {
            fromVertex = v;
        }

        public void SetToVertex(Vertex v)
        {
            toVertex = v;
        }

        public Vertex GetFromVertex()
        {
            return fromVertex;
        }

        public Vertex GetToVertex()
        {
            return toVertex;
        }

        public override string ToString()
        {
            return "[" + fromVertex.ToString() + ", " + toVertex.ToString() + "], Weight = " + Weight.ToString();
        }

        public int CompareTo(Edge other)
        {
            return this.Weight.CompareTo(other.Weight);
        }

        public bool Equals(Edge other)
        {
            return this.fromVertex.Label.Equals(other.fromVertex.Label)
                && this.toVertex.Label.Equals(other.toVertex.Label);
        }
    }
}
