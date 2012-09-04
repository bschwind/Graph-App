using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GraphApp.src;
using GraphApp.src.helpers;

namespace GraphApp.src.Testing
{
    public static class Tester
    {
        public static bool RunTests()
        {
            TestMatrixStuff();
            TestDijkstra();
            TestLabelCorrecting();
            TestAllPairs();
            TestRandomGraph();
            TestResidualNetwork();
            TestBFS();
            TestMaxFlow();
            TestDominatingSets();

            return true;
        }

        private static void TestDominatingSets()
        {
            Graph g = new Graph();
            g.Directed = false;

            Vertex v1 = new Vertex();
            Vertex v2 = new Vertex();
            Vertex v3 = new Vertex();
            Vertex v4 = new Vertex();
            Vertex v5 = new Vertex();
            Vertex v6 = new Vertex();
            Vertex v7 = new Vertex();

            g.AddEdge(new Edge(v1, v2));
            g.AddEdge(new Edge(v2, v3));
            g.AddEdge(new Edge(v3, v4));
            g.AddEdge(new Edge(v4, v5));
            g.AddEdge(new Edge(v5, v6));
            g.AddEdge(new Edge(v6, v7));

            //GraphAlgorithms.MinimumDominatingSet(g);

            g.AddEdge(new Edge(v7, v1));
            GraphAlgorithms.MinimumDominatingSet(g);
        }

        private static void TestMaxFlow()
        {
            FlowNetwork fn = new FlowNetwork();

            Vertex v1 = new Vertex();
            Vertex v2 = new Vertex();
            Vertex v3 = new Vertex();
            Vertex v4 = new Vertex();
            Vertex v5 = new Vertex();
            Vertex v6 = new Vertex();

            fn.AddVertex(v1);
            fn.AddVertex(v2);
            fn.AddVertex(v3);
            fn.AddVertex(v4);
            fn.AddVertex(v5);
            fn.AddVertex(v6);

            fn.SetSource(v1);
            fn.SetSink(v6);

            fn.AddEdge(new FlowEdge(v1, v2, 0f, 2f));
            fn.AddEdge(new FlowEdge(v1, v3, 0f, 2f));
            fn.AddEdge(new FlowEdge(v2, v4, 0f, 2f));
            fn.AddEdge(new FlowEdge(v3, v4, 1f, 2f));
            fn.AddEdge(new FlowEdge(v3, v5, 0f, 2f));
            fn.AddEdge(new FlowEdge(v4, v6, 1f, 2f));
            fn.AddEdge(new FlowEdge(v5, v6, 0f, 2f));

            //float maxFlow = GraphAlgorithms.MaximumFlow(fn);

            //Console.WriteLine("Max flow is " + maxFlow);
        }

        private static void TestBFS()
        {
            Graph g = new Graph();
            Vertex v1 = new Vertex();
            Vertex v2 = new Vertex();
            Vertex v3 = new Vertex();
            Vertex v4 = new Vertex();
            Vertex v5 = new Vertex();
            Vertex v6 = new Vertex();
            Vertex v7 = new Vertex();

            g.AddVertex(v1);
            g.AddVertex(v2);
            g.AddVertex(v3);
            g.AddVertex(v4);
            g.AddVertex(v5);
            g.AddVertex(v6);
            g.AddVertex(v7);

            g.AddEdge(new Edge(v1, v2));
            g.AddEdge(new Edge(v1, v3));
            g.AddEdge(new Edge(v2, v6));
            g.AddEdge(new Edge(v2, v4));
            g.AddEdge(new Edge(v6, v4));
            g.AddEdge(new Edge(v4, v5));

            List<Edge> path = GraphAlgorithms.BreadthFirstSearch(g, 0, 4);
        }

        private static void TestResidualNetwork()
        {
            //Create graph from Figure 6.10
            FlowNetwork fn = new FlowNetwork();
            Vertex v1 = new Vertex();
            Vertex v2 = new Vertex();
            Vertex v3 = new Vertex();
            Vertex v4 = new Vertex();

            fn.AddVertex(v1);
            fn.AddVertex(v2);
            fn.AddVertex(v3);
            fn.AddVertex(v4);

            fn.SetSource(v1);
            fn.SetSink(v4);

            fn.AddEdge(new FlowEdge(v1, v3, 3, 4));
            fn.AddEdge(new FlowEdge(v1, v2, 2, 2));
            fn.AddEdge(new FlowEdge(v2, v3, 2, 3));
            fn.AddEdge(new FlowEdge(v3, v4, 5, 5));
            fn.AddEdge(new FlowEdge(v2, v4, 0, 1));

            Graph g = GraphAlgorithms.CreateResidualNetwork(fn);
        }

        private static void TestRandomGraph()
        {
            Graph g = GraphAlgorithms.GenerateRandomGraph(30);
        }

        private static void TestDijkstra()
        {
            //Graph for figure 4.15 part A
            Graph g = new Graph();
            Vertex u1 = new Vertex();
            Vertex u2 = new Vertex();
            Vertex u3 = new Vertex();
            Vertex u4 = new Vertex();
            Vertex u5 = new Vertex();
            Vertex u6 = new Vertex();

            g.AddEdge(new Edge(u1, u2, 2));
            g.AddEdge(new Edge(u1, u3, 8));
            g.AddEdge(new Edge(u2, u3, 5));
            g.AddEdge(new Edge(u2, u4, 3));
            g.AddEdge(new Edge(u3, u2, 6));
            g.AddEdge(new Edge(u3, u5, 0));
            g.AddEdge(new Edge(u4, u3, 1));
            g.AddEdge(new Edge(u4, u5, 7));
            g.AddEdge(new Edge(u4, u6, 6));
            g.AddEdge(new Edge(u5, u4, 4));
            g.AddEdge(new Edge(u6, u5, 2));

            Console.WriteLine("Dijkstra Output:");
            Graph tree = GraphAlgorithms.Dijkstra(g, 0, true);
        }

        private static void TestLabelCorrecting()
        {
            //Graph for figure 5.10 part A
            Graph g = new Graph();
            g.Directed = true;
            Vertex v1 = new Vertex();
            Vertex v2 = new Vertex();
            Vertex v3 = new Vertex();
            Vertex v4 = new Vertex();
            Vertex v5 = new Vertex();
            Vertex v6 = new Vertex();

            g.AddEdge(new Edge(v1, v2, 10));
            g.AddEdge(new Edge(v1, v3, 15));
            g.AddEdge(new Edge(v2, v3, 25));
            g.AddEdge(new Edge(v3, v2, -20));
            g.AddEdge(new Edge(v2, v4, 0));
            g.AddEdge(new Edge(v2, v5, 5));
            g.AddEdge(new Edge(v4, v5, -5));
            g.AddEdge(new Edge(v5, v4, 10));
            g.AddEdge(new Edge(v5, v3, 30));

            Console.WriteLine("Label Correcting Output:");
            Graph labelCorrect = GraphAlgorithms.LabelCorrecting(g, 0);
        }

        private static void TestMatrixStuff()
        {
            Graph g = new Graph();
            g.Directed = true;
            Vertex v1 = new Vertex();
            Vertex v2 = new Vertex();
            Vertex v3 = new Vertex();
            Vertex v4 = new Vertex();

            g.AddVertex(v1);
            g.AddVertex(v2);
            g.AddVertex(v3);
            g.AddVertex(v4);

            g.AddEdge(new Edge(v2, v1, 25f));
            g.AddEdge(new Edge(v1, v3, 10f));

            g.RemoveEdge(g.GetEdges()[1]);

            g.AddEdge(new Edge(v4, v2, 7f));

            g.RemoveVertex(v1);
            g.RemoveVertex(v2);

            g.AddEdge(new Edge(v3, v4, 30f));
            g.AddEdge(new Edge(v4, v3, 27f));

            Console.WriteLine("Testing graph insertion and deletion");

            g.PrintMatrix();

            Console.WriteLine();
            Graph g2 = new Graph();
            g.CopyTo(g2);
            g2.PrintMatrix();
        }

        private static void TestAllPairs()
        {
            //Graph for figure 4.15 part B
            Graph g = new Graph();
            Vertex v1 = new Vertex();
            Vertex v2 = new Vertex();
            Vertex v3 = new Vertex();
            Vertex v4 = new Vertex();
            Vertex v5 = new Vertex();
            Vertex v6 = new Vertex();
            Vertex v7 = new Vertex();
            Vertex v8 = new Vertex();
            Vertex v9 = new Vertex();
            Vertex v10 = new Vertex();
            Vertex v11 = new Vertex();
            Vertex v12 = new Vertex();
            g.AddVertex(v1);
            g.AddVertex(v2);
            g.AddVertex(v3);
            g.AddVertex(v4);
            g.AddVertex(v5);
            g.AddVertex(v6);
            g.AddVertex(v7);
            g.AddVertex(v8);
            g.AddVertex(v9);
            g.AddVertex(v10);
            g.AddVertex(v11);
            g.AddVertex(v12);

            g.AddEdge(new Edge(v1, v2, 5));
            g.AddEdge(new Edge(v1, v4, 10));
            g.AddEdge(new Edge(v2, v3, 7));
            g.AddEdge(new Edge(v2, v5, 1));
            g.AddEdge(new Edge(v3, v6, 4));
            g.AddEdge(new Edge(v4, v5, 3));
            g.AddEdge(new Edge(v5, v6, 3));
            g.AddEdge(new Edge(v1, v2, 5));
            g.AddEdge(new Edge(v4, v7, 11));
            g.AddEdge(new Edge(v1, v2, 5));
            g.AddEdge(new Edge(v5, v8, 7));
            g.AddEdge(new Edge(v6, v9, 5));
            g.AddEdge(new Edge(v7, v10, 9));
            g.AddEdge(new Edge(v7, v8, 2));
            g.AddEdge(new Edge(v8, v11, 1));
            g.AddEdge(new Edge(v8, v9, 0));
            g.AddEdge(new Edge(v9, v12, 12));
            g.AddEdge(new Edge(v11, v12, 4));

            float[,] d = GraphAlgorithms.AllPairsShortestPath(g);

            GraphAlgorithms.PrintMatrix(d, g.GetVertices().Count);
        }
    }
}
