using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GraphApp.src.helpers;

namespace GraphApp.src
{
    public static class GraphAlgorithms
    {
        public static Graph KruskalMST(Graph g)
        {
            Graph copy = new Graph();
            Graph mst = new Graph();
            //Create a copy to preserve g's state
            g.CopyTo(copy);

            List<Edge> edges = copy.GetEdges();
            List<Vertex> vertices = copy.GetVertices();

            for (int i = 0; i < vertices.Count; i++)
            {
                //Associate each vertex with a set of vertices
                //Initially, each vertex belongs to its own set
                List<Vertex> vertexSet = new List<Vertex>();
                vertexSet.Add(vertices[i]);
                vertices[i].Tag = vertexSet;
                mst.AddVertex(vertices[i]);
            }

            //We don't want to consider edges going in the opposite direction
            List<Edge> filteredEdges = new List<Edge>();
            for (int i = 0; i < edges.Count; i += 2)
            {
                filteredEdges.Add(edges[i]);
            }

            filteredEdges.Sort(delegate(Edge e1, Edge e2)
                        {
                            return e1.Weight.CompareTo(e2.Weight);
                        });


            //Have counter that counts number of edges used.
            //If it equals the total number of edges then the original graph was disconnected

            int edgeIndex = 0;
            //Loop through all the edges
            while (edgeIndex < filteredEdges.Count/* && mst.GetEdges().Count < g.GetVertices().Count - 1*/)
            {
                //Walk up the array instead of removing the vertex
                Edge minEdge = filteredEdges[edgeIndex];

                //Get the sets associated with the vertices on the minEdge
                List<Vertex> fromSet = minEdge.GetFromVertex().Tag as List<Vertex>;
                List<Vertex> toSet = minEdge.GetToVertex().Tag as List<Vertex>;

                //If these two sets are not the same set...
                if (!fromSet.Equals(toSet))
                {
                    //...then add the edge to the MST
                    string fromLabel = minEdge.GetFromVertex().Label;
                    string toLabel = minEdge.GetToVertex().Label;
                    mst.AddEdge(minEdge);
                    minEdge.GetFromVertex().Label = fromLabel;
                    minEdge.GetToVertex().Label = toLabel;

                    //Merge the two vertices' sets together
                    List<Vertex> newList = fromSet.Union(toSet).ToList<Vertex>();
                    foreach (Vertex v in newList)
                    {
                        v.Tag = newList;
                    }
                    minEdge.GetFromVertex().Tag = newList;
                    minEdge.GetToVertex().Tag = newList;
                }

                //Offset by 2 because we're ignoring edges that go in the opposite direction
                edgeIndex++;
            }

            return mst;
        }

        public static Graph PrimMST(Graph g)
        {
            if (g.Directed)
            {
                Output.WriteLine("Can't run Prim's algorithm on a directed graph");
                return null;
            }

            Graph copy = new Graph();
            Graph mst = new Graph();
            //Create a copy to preserve g's state
            g.CopyTo(copy);

            List<Vertex> vertices = copy.GetVertices();
            foreach (Vertex vert in vertices)
            {
                mst.AddVertex(vert);
            }

            PrimData v = new PrimData();
            v.Predecessor = null;
            v.Seen = true;
            v.V = vertices[0];
            v.D = 0;
            v.InMST = true;
            v.EdgeLength = float.PositiveInfinity;
            vertices[0].Tag = v;

            foreach (Vertex u in vertices)
            {
                if (!v.V.Equals(u))
                {
                    PrimData pd = new PrimData();
                    pd.D = float.PositiveInfinity;
                    pd.V = u;
                    pd.InMST = false;
                    pd.Seen = false;
                    u.Tag = pd;
                }
            }

            Heap<PrimData> q = new Heap<PrimData>(true);
            q.Add(vertices[0].Tag as PrimData);

            while (q.HasNext())
            {
                PrimData pd = q.Next();
                if (pd.Predecessor == null)
                {
                    //mst.AddVertex(pd.V);
                }
                else
                {
                    string label = pd.V.Label;
                    mst.AddEdge(new Edge(pd.Predecessor, pd.V, pd.EdgeLength));
                    pd.V.Label = label;
                    pd.InMST = true;
                }

                foreach (Edge e in pd.V.GetOutEdges())
                {
                    Vertex connectedVertex = e.GetToVertex();
                    PrimData data = connectedVertex.Tag as PrimData;
                    if (!data.Seen)
                    {
                        q.Add(data);
                        data.Predecessor = pd.V;
                        data.EdgeLength = e.Weight;
                        data.Seen = true;
                    }

                    if (data.D > e.Weight && !data.InMST)
                    {
                        data.D = e.Weight;
                        data.Predecessor = pd.V;
                        data.EdgeLength = e.Weight;
                        q.Update(data);
                    }
                }
                /*foreach (Edge e in pd.V.GetInEdges())
                {
                    Vertex connectedVertex = e.GetFromVertex();
                    PrimData data = connectedVertex.Tag as PrimData;
                    if (!data.Seen)
                    {
                        q.Add(data);
                        data.Predecessor = pd.V;
                        data.EdgeLength = e.Weight;
                        data.Seen = true;
                    }

                    if (data.D > e.Weight && !data.InMST)
                    {
                        data.D = e.Weight;
                        data.Predecessor = pd.V;
                        data.EdgeLength = e.Weight;
                        q.Update(data);
                    }
                }*/
            }

            return mst;
        }

        public static Graph Dijkstra(Graph g, int vert, bool directed)
        {
            Output.WriteLine("[Dijkstra Output]");

            //If I get a negative edge weight, tell user to use label correcting instead of dijkstra's

            //Change this to assume g is an undirected graph

            //Keep a heap of vertices, based on their distance label
            //Each one is initially infinity, except the intial vertex, which is 0

            Graph copy = new Graph();
            Graph tree = new Graph();
            //Create a copy to preserve g's state
            g.CopyTo(copy);

            List<Vertex> vertices = copy.GetVertices();
            List<Edge> edges = copy.GetEdges();

            DijkstraData v = new DijkstraData();
            v.Predecessor = null;
            v.InQ = false;
            v.V = vertices[vert];
            v.D = 0;
            v.InTree = false;
            v.EdgeLength = float.PositiveInfinity;
            vertices[vert].Tag = v;

            Heap<DijkstraData> q = new Heap<DijkstraData>(true);
            q.Add(vertices[vert].Tag as DijkstraData);
            (vertices[vert].Tag as DijkstraData).InQ = true;

            foreach (Vertex u in vertices)
            {
                if (!v.V.Equals(u))
                {
                    DijkstraData dd = new DijkstraData();
                    dd.D = float.PositiveInfinity;
                    dd.V = u;
                    dd.InTree = false;
                    u.Tag = dd;
                    q.Add(dd);
                    dd.InQ = true;
                }
            }

            foreach (Edge e in edges)
            {
                if (e.Weight < 0)
                {
                    Output.WriteLine("Negative edge weight detected. Use Label Correcting instead of Dijkstra");
                    return null;
                }
            }

            while (q.HasNext())
            {
                DijkstraData dd = q.Next();
                dd.InQ = false;
                /*if (dd.Predecessor == null)
                {
                    tree.AddVertex(dd.V);
                    dd.InTree = true;
                }
                else
                {
                    tree.AddEdge(new Edge(dd.Predecessor, dd.V, dd.EdgeLength));
                    dd.InTree = true;
                }*/

                foreach (Edge e in dd.V.GetOutEdges())
                {
                    Vertex connectedVertex = e.GetToVertex();
                    DijkstraData data = connectedVertex.Tag as DijkstraData;

                    if (data.InQ)
                    {
                        if (dd.D + e.Weight < data.D)
                        {
                            if (dd.D + e.Weight < data.D)
                            {
                                data.D = dd.D + e.Weight;
                                q.Update(data);
                            }
                        }
                    }
                }

                //If this is a directed graph, don't consider in edges
                if (directed)
                {
                    continue;
                }
                foreach (Edge e in dd.V.GetInEdges())
                {
                    Vertex connectedVertex = e.GetFromVertex();
                    DijkstraData data = connectedVertex.Tag as DijkstraData;

                    if (data.InQ)
                    {
                        if (dd.D + e.Weight < data.D)
                        {
                            data.D = dd.D + e.Weight;
                            q.Update(data);
                        }
                    }
                }
            }

            Output.WriteLine("Distance from selected vertex to:");

            foreach (Vertex vertex in vertices)
            {
                Output.WriteLine(vertex.ToString() +  " = " + (vertex.Tag as DijkstraData).D);
            }

            Output.WriteLine("[End Dijkstra Output]");
            return tree;
        }

        public static Graph LabelCorrecting(Graph g, int vert)
        {
            Output.WriteLine("[Label Correcting Output]");
            //Not working, I think because of the two loops for in and out edges

            //Change this to assume g is an undirected graph

            //Keep a heap of vertices, based on their distance label
            //Each one is initially infinity, except the intial vertex, which is 0

            Graph copy = new Graph();
            Graph tree = new Graph();
            //Create a copy to preserve g's state
            g.CopyTo(copy);

            List<Vertex> vertices = copy.GetVertices();
            List<Edge> edges = copy.GetEdges();

            DijkstraData v = new DijkstraData();
            v.Predecessor = null;
            v.InQ = false;
            v.V = vertices[vert];
            v.D = 0;
            v.InTree = false;
            v.EdgeLength = float.PositiveInfinity;
            vertices[vert].Tag = v;

            Heap<DijkstraData> q = new Heap<DijkstraData>(true);
            q.Add(vertices[vert].Tag as DijkstraData);
            (vertices[vert].Tag as DijkstraData).InQ = true;

            foreach (Vertex u in vertices)
            {
                if (!v.V.Equals(u))
                {
                    DijkstraData dd = new DijkstraData();
                    dd.D = float.PositiveInfinity;
                    dd.V = u;
                    dd.InTree = false;
                    dd.InQ = false;
                    u.Tag = dd;
                }
            }

            float maxEdgeWeight = float.NegativeInfinity;
            foreach (Edge e in edges)
            {
                if (Math.Abs(e.Weight) > maxEdgeWeight)
                {
                    maxEdgeWeight = Math.Abs(e.Weight);
                }
            }
            int n = vertices.Count;
            float negativeCycleCheck = n * -maxEdgeWeight;

            while (q.HasNext())
            {
                DijkstraData dd = q.Next();
                dd.InQ = false;
                /*if (dd.Predecessor == null)
                {
                    tree.AddVertex(dd.V);
                }
                else
                {
                    tree.AddEdge(new Edge(dd.Predecessor, dd.V, dd.EdgeLength));
                    dd.InTree = true;
                }*/

                foreach (Edge e in dd.V.GetOutEdges())
                {
                    Vertex connectedVertex = e.GetToVertex();
                    DijkstraData data = connectedVertex.Tag as DijkstraData;

                    if (data.D > dd.D + e.Weight)
                    {
                        data.D = dd.D + e.Weight;
                        if (data.D < negativeCycleCheck)
                        {
                            throw new Exception("Negative cycle detected!");
                        }
                        data.Predecessor = dd.V;
                        if (!q.Contains(data))
                        {
                            q.Add(data);
                            data.InQ = true;
                        }
                    }
                }

                if (g.Directed)
                {
                    continue;
                }

                foreach (Edge e in dd.V.GetInEdges())
                {
                    Vertex connectedVertex = e.GetFromVertex();
                    DijkstraData data = connectedVertex.Tag as DijkstraData;

                    if (data.D > dd.D + e.Weight)
                    {
                        data.D = dd.D + e.Weight;
                        if (data.D < negativeCycleCheck)
                        {
                            throw new Exception("Negative cycle detected!");
                        }
                        data.Predecessor = dd.V;
                        if (!q.Contains(data))
                        {
                            q.Add(data);
                            data.InQ = true;
                        }
                    }
                }
            }

            Output.WriteLine("Distance from selected vertex to:");

            foreach (Vertex vertex in vertices)
            {
                Output.WriteLine(vertex.ToString() + " = " + (vertex.Tag as DijkstraData).D);
            }


            Output.WriteLine("[End Label Correcting Output]");
            return tree;
        }

        public static float[,] AllPairsShortestPath(Graph g)
        {
            Output.WriteLine("[All Pairs Shortest Path Output]");

            g.UpdateMatrix();
            float[,] D = g.GetRawMatrix();
            int n = g.GetVertices().Count;

            //Set up a matrix called pred, tells you the predecessor for each vertex

            //Set labels
            //Where edges don't exist, values of positive infinity are already inserted
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (i == j)
                    {
                        D[i, j] = 0;
                    }
                }
            }

            for (int k = 0; k < n; k++)
            {
                for (int i = 0; i < n; i++)
                {
                    for (int j = 0; j < n; j++)
                    {
                        if (D[i, k] + D[k, j] < D[i, j])
                        {
                            D[i, j] = D[i, k] + D[k, j];
                        }
                    }
                }
            }

            PrintMatrix(D, g.GetVertices().Count);

            Output.WriteLine("[End All Pairs Shortest Path Output]");
            return D;
        }

        public static Graph GenerateRandomGraph(int n)
        {
            float prob = 0.2f;

            Graph g = new Graph();
            g.Directed = false;

            for (int i = 0; i < n; i++)
            {
                Vertex v = new Vertex();
                g.AddVertex(v);
            }

            Random r = new Random();

            //Randomly decide when to add an edge between any two pairs
            foreach (Vertex v in g.GetVertices())
            {
                foreach (Vertex u in g.GetVertices())
                {
                    if (!v.Equals(u))
                    {
                        double random = r.NextDouble();
                        if (random >= 0 && random <= prob)
                        {
                            g.AddEdge(new Edge(v, u, (float)r.NextDouble()));
                        }
                    }
                }
            }

            foreach (Vertex v in g.GetVertices())
            {
                VertexClassification vc = ClassifyVertex(v);
                Output.WriteLine("Vertex " + v.ToString() + " is " + vc.ToString());
            }

            return g;
        }

        public static Graph CreateResidualNetwork(FlowNetwork fn)
        {
            FlowNetwork copy = new FlowNetwork();
            fn.CopyTo(copy);

            Graph g = new Graph();

            g.Directed = true;

            for (int i = 0; i < copy.GetVertices().Count; i++)
            {
                Vertex v = copy.GetVertices()[i];
                v.Tag = i;
                v.RemoveAllEdges();
                g.AddVertex(v);
            }

            foreach (FlowEdge e in copy.GetEdges())
            {
                float backflow = e.CurrentFlow;
                float capacity = e.Capacity;
                float forwardFlow = capacity - backflow;

                Vertex fromVertex = e.GetFromVertex();
                Vertex toVertex = e.GetToVertex();
                int fromIndex = (int)fromVertex.Tag;
                int toindex = (int)toVertex.Tag;

                Vertex newTo = g.GetVertices()[toindex];
                Vertex newFrom = g.GetVertices()[fromIndex];

                if (backflow > 0)
                {
                    Edge backEdge = new Edge(newTo, newFrom, backflow);
                    g.AddEdge(backEdge);
                }

                if (forwardFlow > 0)
                {
                    Edge forwardEdge = new Edge(newFrom, newTo, forwardFlow);
                    g.AddEdge(forwardEdge);
                }
            }

            return g;
        }

        public static List<Edge> BreadthFirstSearch(Graph g, int source, int goal)
        {
            //Does a breadth-first search and finds the shortest path between the source and the goal
            //Returns null if no path exists
            bool found = false;
            bool directed = g.Directed;

            List<object> tags = new List<object>();
            List<Edge> path = new List<Edge>();

            foreach (Vertex v in g.GetVertices())
            {
                tags.Add(v.Tag);
                v.Tag = null;
            }

            Queue<Vertex> q = new Queue<Vertex>();
            Vertex sourceVert = g.GetVertices()[source];
            Vertex goalVert = g.GetVertices()[goal];
            q.Enqueue(sourceVert);
            sourceVert.Tag = new BFSData(null);
            while (q.Count > 0)
            {
                Vertex next = q.Dequeue();

                if (next.Equals(goalVert))
                {
                    found = true;
                    break;
                }

                foreach (Edge e in next.GetOutEdges())
                {
                    Vertex toVert = e.GetToVertex();
                    if (toVert.Tag != null)
                    {
                        continue;
                    }
                    else
                    {
                        toVert.Tag = e;
                        q.Enqueue(toVert);
                    }
                }
                if (!directed)
                {
                    foreach (Edge e in next.GetInEdges())
                    {
                        Vertex toVert = e.GetFromVertex();
                        if (toVert.Tag != null)
                        {
                            continue;
                        }
                        else
                        {
                            toVert.Tag = e;
                            q.Enqueue(toVert);
                        }
                    }
                }
            }

            if (!found)
            {
                return null;
            }

            Edge currentEdge = goalVert.Tag as Edge;
            path.Add(currentEdge);
            while (!currentEdge.GetFromVertex().Equals(sourceVert))
            {
                Vertex nextVert = currentEdge.GetFromVertex();
                currentEdge = nextVert.Tag as Edge;
                path.Add(currentEdge);
            }

            path.Reverse();

            for (int i = 0; i < tags.Count; i++)
            {
                g.GetVertices()[i].Tag = tags[i];
            }

            return path;
        }

        public static float MaximumFlow(FlowNetwork fn, int source, int sink)
        {
            float maxFlow = 0f;

            int sourceIndex = source;
            int sinkIndex = sink;

            foreach (FlowEdge e in fn.GetEdges())
            {
                e.CurrentFlow = 0f;
            }
                
            Graph g = CreateResidualNetwork(fn);

            List<Edge> augmentingPath = BreadthFirstSearch(g, sourceIndex, sinkIndex);

            while (augmentingPath != null)
            {
                float minFlow = float.MaxValue;
                //find min flow
                foreach (Edge e in augmentingPath)
                {
                    if (e.Weight < minFlow)
                    {
                        minFlow = e.Weight;
                    }
                }

                maxFlow += minFlow;

                foreach (Edge e in augmentingPath)
                {
                    //Update residual graph
                    Edge currentForwardResid = g.FindEdge(e);
                    Edge currentBackwardResid = g.FindEdge(new Edge(e.GetToVertex(), e.GetFromVertex()));
                    float newForwardWeight = currentForwardResid.Weight - minFlow;
                    if (newForwardWeight <= 0f)
                    {
                        g.RemoveEdge(currentForwardResid);
                    }
                    else
                    {
                        currentForwardResid.Weight = newForwardWeight;
                    }
                    if (currentBackwardResid != null)
                    {
                        float newBackwardWeight = currentBackwardResid.Weight + minFlow;
                        currentBackwardResid.Weight = newBackwardWeight;
                    }
                    else
                    {
                        currentBackwardResid = new Edge(e.GetToVertex(), e.GetFromVertex(), minFlow);
                        g.AddEdge(currentBackwardResid);
                    }

                    //Update flow network
                    FlowEdge fe = fn.FindEdge(new FlowEdge(e.GetFromVertex(), e.GetToVertex(), 0, 0));
                    fe.CurrentFlow = fe.CurrentFlow + minFlow;
                }

                augmentingPath = BreadthFirstSearch(g, sourceIndex, sinkIndex);
                //augmentingPath = null;
            }

            return maxFlow;
        }

        public static void MinimumDominatingSet(Graph g)
        {
            Output.WriteLine("[Minimum Dominating Set Output]");

            //MDS takes an undirected graph
            CombinationGenerator cg = new CombinationGenerator(g.GetVertices().Count, 0);
            bool setFound = false;
            List<Vertex> verts = new List<Vertex>(g.GetVertices().Count);
            List<Vertex> neighborhood = new List<Vertex>();
            List<Vertex[]> domSet = new List<Vertex[]>();
            bool restricted = false;
            int setLen = 0;

            while (cg.HasNext())
            {
                int[] array = cg.GetNext();
                int[] tally = new int[array.Length];
                array.CopyTo(tally, 0);

                Vertex[] possibleSet = new Vertex[cg.CurrentLevel()];
                int possibleSetCounter = 0;
                List<Vertex> neighbors = new List<Vertex>();

                for (int i = 0; i < array.Length; i++)
                {
                    if (array[i] != 1)
                    {
                        continue;
                    }

                    possibleSet[possibleSetCounter] = g.GetVertices()[i];
                    possibleSetCounter++;

                    neighbors.AddRange(g.GetVertices()[i].GetAllNeighbors());
                }

                foreach (Vertex v in neighbors)
                {
                    int index = g.GetVertices().IndexOf(v);
                    if (index == -1)
                    {
                        continue;
                    }

                    tally[index] = 1;
                }

                bool validSet = true;
                for (int i = 0; i < tally.Length; i++)
                {
                    if (tally[i] != 1)
                    {
                        validSet = false;
                        break;
                    }
                }

                if (validSet)
                {
                    setFound = true;
                    if (!restricted)
                    {
                        cg.RestrictToCurrentLevel();
                        restricted = true;
                        setLen = possibleSet.Length;
                    }

                    if (setLen == possibleSet.Length)
                    {
                        domSet.Add(possibleSet);
                    }
                }
            }

            //Tally method
            //Initiate tally to be the generated array, (create a copy!)
            //go through the neighborhood of each vertex with value 1
            //for each neighbor, change their value in the tally to 1
            //If tally is all 1s, then you have everything

            if (setFound)
            {
                //print out the found set and find the others
                Output.WriteLine("Found minimum dominating sets:");
                foreach (Vertex[] v in domSet)
                {
                    string separator = "";
                    for (int i = 0; i < v.Length; i++)
                    {
                        Output.Write(separator + v[i].ToString());
                        separator = ",";
                    }
                    Output.WriteLine();
                }
            }

            Output.WriteLine("[End Minimum Dominating Set Output]");
        }

        public static void MinimumDominatingSet(Graph g, int seed)
        {
            Output.WriteLine("[Minimum Dominating Set Output]");

            //MDS takes an undirected graph
            CombinationGenerator cg = new CombinationGenerator(g.GetVertices().Count, seed);
            bool setFound = false;
            List<Vertex> verts = new List<Vertex>(g.GetVertices().Count);
            List<Vertex> neighborhood = new List<Vertex>();
            List<Vertex[]> domSet = new List<Vertex[]>();
            bool restricted = false;
            int setLen = 0;

            while (cg.HasNext())
            {
                int[] array = cg.GetNext();
                int[] tally = new int[array.Length];
                array.CopyTo(tally, 0);

                Vertex[] possibleSet = new Vertex[cg.CurrentLevel()];
                int possibleSetCounter = 0;
                List<Vertex> neighbors = new List<Vertex>();

                for (int i = 0; i < array.Length; i++)
                {
                    if (array[i] != 1)
                    {
                        continue;
                    }

                    possibleSet[possibleSetCounter] = g.GetVertices()[i];
                    possibleSetCounter++;

                    neighbors.AddRange(g.GetVertices()[i].GetAllNeighbors());
                }

                foreach (Vertex v in neighbors)
                {
                    int index = g.GetVertices().IndexOf(v);
                    if (index == -1)
                    {
                        continue;
                    }

                    tally[index] = 1;
                }

                bool validSet = true;
                for (int i = 0; i < tally.Length; i++)
                {
                    if (tally[i] != 1)
                    {
                        validSet = false;
                        break;  //we break, because we only want to find one dominating set
                    }
                }

                if (validSet)
                {
                    setFound = true;
                    if (!restricted)
                    {
                        cg.RestrictToCurrentLevel();
                        restricted = true;
                        setLen = possibleSet.Length;
                    }

                    if (setLen == possibleSet.Length)
                    {
                        domSet.Add(possibleSet);
                        break;
                    }
                }
            }

            //Tally method
            //Initiate tally to be the generated array, (create a copy!)
            //go through the neighborhood of each vertex with value 1
            //for each neighbor, change their value in the tally to 1
            //If tally is all 1s, then you have everything

            if (setFound)
            {
                //print out the found set and find the others
                Output.WriteLine("Found minimum dominating sets:");
                foreach (Vertex[] v in domSet)
                {
                    string separator = "";
                    for (int i = 0; i < v.Length; i++)
                    {
                        Output.Write(separator + v[i].ToString());
                        separator = ",";
                    }
                    Output.WriteLine();
                }
            }

            Output.WriteLine("[End Minimum Dominating Set Output]");
        }

        public static void PrintMatrix(float[,] array, int n)
        {
            Output.WriteLine("[Matrix Output]");

            string s = "";
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    s += array[i, j] + " ";
                    if (j == n - 1)
                    {
                        s += "\r\n";
                    }
                }
            }

            Output.WriteLine(s);

            Output.WriteLine("[End Matrix Output]");
        }

        public static VertexClassification ClassifyVertex(Vertex v)
        {
            int myDegree = v.GetTotalDegree();

            List<Vertex> verts = v.GetAllNeighbors();

            bool regular = true;
            foreach (Vertex u in verts)
            {
                if (myDegree != u.GetTotalDegree())
                {
                    regular = false;
                    break;
                }
            }

            if (regular)
            {
                return VertexClassification.Regular;
            }

            bool veryStrong = true;
            foreach (Vertex u in verts)
            {
                if (myDegree <= u.GetTotalDegree())
                {
                    veryStrong = false;
                    break;
                }
            }

            if (veryStrong)
            {
                return VertexClassification.VeryStrong;
            }

            bool strong = true;
            foreach (Vertex u in verts)
            {
                if (myDegree < u.GetTotalDegree())
                {
                    strong = false;
                    break;
                }
            }

            if (strong)
            {
                return VertexClassification.Strong;
            }

            bool veryWeak = true;
            foreach (Vertex u in verts)
            {
                if (myDegree >= u.GetTotalDegree())
                {
                    veryWeak = false;
                    break;
                }
            }

            if (veryWeak)
            {
                return VertexClassification.VeryWeak;
            }

            bool weak = true;
            foreach (Vertex u in verts)
            {
                if (myDegree > u.GetTotalDegree())
                {
                    weak = false;
                    break;
                }
            }

            if (weak)
            {
                return VertexClassification.Weak;
            }

            return VertexClassification.Typical;
        }
    }
}
