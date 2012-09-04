using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace GraphApp.src
{
    public class Vertex
    {
        private int inDegree, outDegree;
        private List<Edge> inEdges, outEdges;
        private string label;
        private Graph graph;

        [Browsable(false)]
        public Object Tag { get; set; }
        [Browsable(false)]
        public string Label
        {
            get
            {
                return label;
            }
            set
            {
                label = value;
            }
        }

        public Vertex()
        {
            inEdges = new List<Edge>();
            outEdges = new List<Edge>();
        }

        public void AddInEdge(Edge e)
        {
            inEdges.Add(e);
            inDegree++;
        }

        public void AddOutEdge(Edge e)
        {
            outEdges.Add(e);
            outDegree++;
        }

        public void RemoveAllEdges()
        {
            outEdges.Clear();
            inEdges.Clear();
            inDegree = 0;
            outDegree = 0;
        }

        public void RemoveInEdge(Edge e)
        {
            inEdges.Remove(e);
            inDegree--;
        }

        public void RemoveOutEdge(Edge e)
        {
            outEdges.Remove(e);
            outDegree--;
        }

        public List<Edge> GetInEdges()
        {
            return inEdges;
        }

        public List<Edge> GetOutEdges()
        {
            return outEdges;
        }

        public int GetInDegree()
        {
            return inDegree;
        }

        public int GetOutDegree()
        {
            return outDegree;
        }

        public int GetTotalDegree()
        {
            return inDegree + outDegree;
        }

        public override string ToString()
        {
            return label;
        }

        public List<Vertex> GetAllNeighbors()
        {
            List<Vertex> verts = new List<Vertex>();
            foreach (Edge e in outEdges)
            {
                verts.Add(e.GetToVertex());
            }

            return verts;
        }

        public Graph GetGraph()
        {
            return graph;
        }

        public void SetGraph(Graph g)
        {
            graph = g;
        }
    }
}
