using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GraphApp.src
{
    public class Graph
    {
        protected List<Vertex> vertices;
        protected List<Edge> edges;

        private int vertexCount;
        private int edgeCount;

        private AdjacencyMatrix matrix;

        public string Name { get; set; }

        private bool directed;
        public bool Directed 
        {
            get
            {
                return directed;
            }
            set
            {
                directed = value;
                foreach (Edge e in edges)
                {
                    e.Directed = directed;
                }
            }
        }

        private bool showEdgeLabels;
        public bool ShowEdgeLabels
        {
            get
            {
                return showEdgeLabels;
            }
            set
            {
                showEdgeLabels = value;
                foreach (Edge e in edges)
                {
                    e.ShowLabel = showEdgeLabels;
                }
            }
        }

        public Graph()
        {
            vertices = new List<Vertex>();
            edges = new List<Edge>();

            matrix = new AdjacencyMatrix(float.PositiveInfinity);
        }

        public List<Edge> GetAllOutEdges()
        {
            List<Edge> retList = new List<Edge>();
            foreach (Vertex v in vertices)
            {
                retList.AddRange(v.GetOutEdges());
            }

            return retList;
        }

        public virtual void AddVertex(Vertex v)
        {
            v.SetGraph(this);
            vertexCount++;
            v.Label = vertexCount.ToString();
            vertices.Add(v);
            matrix.AddVertex();
        }

        public virtual void RemoveVertex(Vertex v)
        {
            int index = vertices.IndexOf(v);
            bool success = vertices.Remove(v);
            if (success)
            {
                vertexCount--;
                v.SetGraph(null);
                //Delete all edges going to and from this vertex
                foreach (Edge e in v.GetInEdges())
                {
                    RemoveEdge(e);
                }
                foreach (Edge e in v.GetOutEdges())
                {
                    RemoveEdge(e);
                }

                matrix.RemoveVertex(index);
            }
        }

        public virtual void Clear()
        {
            vertexCount = 0;
            edgeCount = 0;

            foreach (Vertex v in vertices)
            {
                v.SetGraph(null);
            }

            vertices.Clear();
            edges.Clear();
            matrix.Clear();
        }

        public void UpdateMatrix()
        {
            for (int i = 0; i < edges.Count; i += 2)
            {
                Edge e = edges[i];
                int fromIndex = vertices.IndexOf(e.GetFromVertex());
                int toIndex = vertices.IndexOf(e.GetToVertex());
                matrix.SetValueAt(fromIndex, toIndex, e.Weight);
                if (!Directed)
                {
                    matrix.SetValueAt(toIndex, fromIndex, e.Weight);
                }
            }
        }

        public virtual void AddEdge(Edge e)
        {
            //Check to see if the vertices belong to a different graph
            //Not necessarily null
            if (e.GetFromVertex().GetGraph() != this)
            {
                AddVertex(e.GetFromVertex());
            }

            if (e.GetToVertex().GetGraph() != this)
            {
                AddVertex(e.GetToVertex());
            }

            int fromIndex = vertices.IndexOf(e.GetFromVertex());
            int toIndex = vertices.IndexOf(e.GetToVertex());

            float val = matrix.GetValueAt(fromIndex, toIndex);

            Edge oppositeEdge = new Edge(e.GetToVertex(), e.GetFromVertex(), e.Weight);
            if (!float.IsInfinity(val))
            {
                //update existing edge
                matrix.SetValueAt(fromIndex, toIndex, e.Weight);
                if (!Directed)
                {
                    matrix.SetValueAt(toIndex, fromIndex, e.Weight);
                }
                Edge existing = FindEdge(e);
                existing.Weight = e.Weight;
                Edge otherEdge = FindEdge(new Edge(e.GetToVertex(), e.GetFromVertex()));
                if (otherEdge == null)
                {
                    return;
                }
                otherEdge.Weight = e.Weight;
                return;
            }

            vertices[fromIndex].AddOutEdge(e);
            vertices[toIndex].AddInEdge(e);

            if (!Directed)
            {
                vertices[toIndex].AddOutEdge(oppositeEdge);
                vertices[fromIndex].AddInEdge(oppositeEdge);
            }

            edges.Add(e);
   
            if (!Directed)
            {
                edges.Add(oppositeEdge);
                edgeCount++;
            }

            edgeCount++;

            float edgeWeight = e.Weight;
            
            matrix.SetValueAt(fromIndex, toIndex, edgeWeight);
            if (!Directed)
            {
                matrix.SetValueAt(toIndex, fromIndex, edgeWeight);
            }

            e.Directed = directed;
            oppositeEdge.Directed = directed;
            e.ShowLabel = showEdgeLabels;
            oppositeEdge.ShowLabel = showEdgeLabels;
        }

        //Returns an edge which connects the vertices specified in e
        //instead of doing a reference comparison
        public Edge FindEdge(Edge e)
        {
            foreach (Edge edge in edges)
            {
                if (e.Equals(edge))
                {
                    return edge;
                }
            }

            return null;
        }

        public virtual void RemoveEdge(Edge e)
        {
            bool success = edges.Remove(e);
            if (success)
            {
                edgeCount--;

                int fromIndex = vertices.IndexOf(e.GetFromVertex());
                int toIndex = vertices.IndexOf(e.GetToVertex());
                //If fromIndex or toIndex is -1, the vertex has already been removed, so don't worry about updating
                //their information
                if (fromIndex >= 0)
                {
                    vertices[fromIndex].RemoveOutEdge(e);
                }
                if (toIndex >= 0)
                {
                    vertices[toIndex].RemoveInEdge(e);
                }
                if (fromIndex < 0 || toIndex < 0)
                {
                    return;
                }

                matrix.SetValueAt(fromIndex, toIndex, float.PositiveInfinity);    
            }
        }

        public List<Vertex> GetVertices()
        {
            return vertices;
        }

        public List<Edge> GetEdges()
        {
            return edges;
        }

        public void CopyTo(Graph to)
        {
            //Only the linked structure needs to be copied
            //The matrix gets copied implicitly
            if (to as FlowNetwork != null)
            {
                copyLinkedGraph(to as FlowNetwork);
            }
            else
            {
                copyLinkedGraph(to);
            }
        }

        private void copyLinkedGraph(Graph to)
        {
            to.Clear();
            to.Directed = this.Directed;

            for (int i = 0; i < this.GetVertices().Count; i++)
            {
                vertices[i].Tag = i;
                Vertex v = new Vertex();
                v.Tag = i;
                to.AddVertex(v);
            }
            
            for (int i = this.GetEdges().Count-1; i >= 0; i--)
            {
                Edge currentEdge = this.GetEdges()[i];

                Vertex v1 = new Vertex();
                v1.Label = currentEdge.GetFromVertex().Label;
                int cd = (int)currentEdge.GetFromVertex().Tag;
                if ((int)to.GetVertices()[cd].Tag == cd)
                {
                    v1 = to.GetVertices()[cd];
                }

                Vertex v2 = new Vertex();
                v2.Label = currentEdge.GetToVertex().Label;
                int cd2 = (int)currentEdge.GetToVertex().Tag;
                if ((int)to.GetVertices()[cd2].Tag == cd2)
                {
                    v2 = to.GetVertices()[cd2];
                }

                Edge e = currentEdge;
                e = new Edge(v1, v2, currentEdge.Weight);
                
                to.AddEdge(e);
            }
        }

        private void copyLinkedGraph(FlowNetwork to)
        {
            to.Clear();

            for (int i = 0; i < this.GetVertices().Count; i++)
            {
                vertices[i].Tag = i;
                Vertex v = new Vertex();
                v.Tag = i;
                to.AddVertex(v);
            }

            for (int i = 0; i < this.GetEdges().Count; i++)
            {
                Edge currentEdge = this.GetEdges()[i];

                Vertex v1 = new Vertex();
                v1.Label = currentEdge.GetFromVertex().Label;
                int cd = (int)currentEdge.GetFromVertex().Tag;
                if ((int)to.GetVertices()[cd].Tag == cd)
                {
                    v1 = to.GetVertices()[cd];
                }

                Vertex v2 = new Vertex();
                v2.Label = currentEdge.GetToVertex().Label;
                int cd2 = (int)currentEdge.GetToVertex().Tag;
                if ((int)to.GetVertices()[cd2].Tag == cd2)
                {
                    v2 = to.GetVertices()[cd2];
                }

                FlowEdge fe = currentEdge as FlowEdge;
                Edge e = new FlowEdge(v1, v2, fe.CurrentFlow, fe.Capacity);

                to.AddEdge(e);
            }

            FlowNetwork fn = this as FlowNetwork;
            if (fn != null)
            {
                to.SetSource(fn.GetSource());
                to.SetSink(fn.GetSink());
            }
        }

        public float[,] GetRawMatrix()
        {
            return matrix.GetRawMatrix();
        }

        public void PrintMatrix()
        {
            Console.WriteLine(matrix.ToString());
        }
    }
}
