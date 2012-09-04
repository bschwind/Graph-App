using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GraphApp.src
{
    public class GraphApp
    {
        private List<Graph> graphs;
        private Graph currentGraph;

        public GraphApp()
        {
            graphs = new List<Graph>();
        }

        public GraphApp(string fileName)
        {
            //Load the graph data from the file
        }

        public void SaveToFile(string fileName)
        {
            //Write code to save the current state of the app
        }

        //Creates a new graph, sets it as the current graph
        public Graph NewGraph(string name)
        {
            Graph g = new Graph();
            g.Name = name;
            graphs.Add(g);
            currentGraph = g;

            return g;
        }

        //Creates a new FlowNetwork, sets it as the current graph
        public FlowNetwork NewFlowNetwork(string name)
        {
            FlowNetwork g = new FlowNetwork();
            g.Name = name;
            graphs.Add(g);
            currentGraph = g;

            return g;
        }

        public Graph NewRandomGraph(string name, int n)
        {
            Graph g = GraphAlgorithms.GenerateRandomGraph(n);
            g.Name = name;
            graphs.Add(g);
            currentGraph = g;

            return g;
        }

        public void DeleteGraph(Graph g)
        {
            checkNullGraph(g);

            graphs.Remove(g);
            if (graphs.Count > 0)
            {
                currentGraph = graphs[0];
            }
        }

        public void SetCurrentGraph(Graph g)
        {
            checkNullGraph(g);
            currentGraph = g;
        }

        public Vertex AddVertex()
        {
            checkNullGraph(currentGraph);
            Vertex v = new Vertex();
            currentGraph.AddVertex(v);
            return v;
        }

        public bool RemoveVertex(Vertex v)
        {
            checkNullGraph(currentGraph);
            currentGraph.RemoveVertex(v);
            return true;
        }

        public Edge AddEdge(Vertex from, Vertex to)
        {
            checkNullGraph(currentGraph);

            Edge e = new Edge(from, to, 1f);

            currentGraph.AddEdge(e);
            return e;
        }

        public FlowEdge AddFlowEdge(Vertex from, Vertex to)
        {
            checkNullGraph(currentGraph);
            FlowEdge fe = new FlowEdge(from, to, 0, 1f);
            currentGraph.AddEdge(fe);
            return fe;
        }

        public bool RemoveEdge(Edge e)
        {
            checkNullGraph(currentGraph);
            currentGraph.RemoveEdge(e);
            return true;
        }

        private void checkNullGraph(Graph g)
        {
            if (g == null)
            {
                throw new Exception("Can't operate a null graph");
            }
        }
    }
}
