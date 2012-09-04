using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using GraphApp.src.helpers;

namespace GraphApp.src.gui
{
    public partial class GraphAppGUI : UserControl
    {
        private GraphApp app;
        private int graphCounter;  //Counter which keeps track of how many graphs we have
        private AppTool currentTool;
        
        public GraphAppGUI()
        {
            InitializeComponent();
            Output.Initialize(textBox1);

            app = new GraphApp();

            AppTool.SelectTool.AddFilter(new SelectionFilter(typeof(Vertex)));
            AppTool.SelectTool.AddFilter(new SelectionFilter(typeof(Edge)));
            AppTool.SelectTool.AddFilter(new SelectionFilter(typeof(FlowEdge)));
        }

        public GraphPanel CurrentGraphPanel
        {
            get
            {
                if (graphTabControl.SelectedIndex < 0)
                {
                    return null;
                }
                return graphTabControl.TabPages[graphTabControl.SelectedIndex].Controls[0] as GraphPanel;
            }
        }

        private void onNewGraphClick(object sender, EventArgs e)
        {
            string graphName = "Graph " + graphCounter;

            Graph newGraph = app.NewGraph(graphName);
            newGraph.ShowEdgeLabels = true;

            makeNewGraphPanel(newGraph);  
        }

        private void onNewFlowNetwork(object sender, EventArgs e)
        {
            string graphName = "Graph " + graphCounter;

            FlowNetwork newGraph = app.NewFlowNetwork(graphName);
            newGraph.ShowEdgeLabels = true;

            makeNewGraphPanel(newGraph);
        }

        private void makeNewGraphPanel(Graph newGraph)
        {
            graphTabControl.TabPages.Add(newGraph.Name);

            GraphPanel gp = new GraphPanel();
            gp.CurrentTool = currentTool;
            gp.Graph = newGraph;

            gp.MouseClick += new MouseEventHandler(gp_MouseClick);
            gp.MouseDown += new MouseEventHandler(gp_MouseDown);
            gp.MouseUp += new MouseEventHandler(gp_MouseUp);
            gp.MouseMove += new MouseEventHandler(gp_MouseMove);

            gp.Dock = DockStyle.Fill;
            graphTabControl.TabPages[graphCounter].Controls.Add(gp);
            graphTabControl.TabPages[graphCounter].ContextMenuStrip = graphRightClickMenu;
            graphTabControl.SelectTab(graphTabControl.TabCount - 1);
            graphCounter++;

            selectedItemPropertyGrid.SelectedObject = newGraph;
        }

        public void AddRandomGraph(int n)
        {
            Graph g = app.NewRandomGraph("Random graph", n);

            makeNewGraphPanel(g);

            g.ShowEdgeLabels = false;

            updateCurrentTool(AppTool.AddVertexTool);

            float angleAmount = 360f / n;
            float currentAngle = 0f;
            Vector2 center = new Vector2(256, 170);
            float radius = 150;

            foreach(Vertex v in g.GetVertices())
            {
                Vector2 dir = new Vector2((float)Math.Cos(MathHelper.ToRadians(currentAngle)) * radius, (float)Math.Sin(MathHelper.ToRadians(currentAngle)) * radius);
                Vector2 pos = center + dir;
                CurrentGraphPanel.AddVertex(v, pos.ToPoint());

                currentAngle += angleAmount;
            }

            foreach (Edge e in g.GetEdges())
            {
                int guiIndex1 = g.GetVertices().IndexOf(e.GetFromVertex());
                int guiIndex2 = g.GetVertices().IndexOf(e.GetToVertex());

                CurrentGraphPanel.AddEdge(CurrentGraphPanel.Vertices[guiIndex1], CurrentGraphPanel.Vertices[guiIndex2], e);
            }

            selectedItemPropertyGrid.SelectedObject = g;
        }

        //Takes a graph, creates a new tab for it, and fills in the GUI components
        private void populateGraph(Graph g)
        {
            int n = g.GetVertices().Count;

            makeNewGraphPanel(g);

            updateCurrentTool(AppTool.AddVertexTool);

            float angleAmount = 360f / n;
            float currentAngle = 0f;
            Vector2 center = new Vector2(256, 170);
            float radius = 150;

            foreach (Vertex v in g.GetVertices())
            {
                Vector2 dir = new Vector2((float)Math.Cos(MathHelper.ToRadians(currentAngle)) * radius, (float)Math.Sin(MathHelper.ToRadians(currentAngle)) * radius);
                Vector2 pos = center + dir;
                CurrentGraphPanel.AddVertex(v, pos.ToPoint());

                currentAngle += angleAmount;
            }

            foreach (Edge e in g.GetEdges())
            {
                int guiIndex1 = g.GetVertices().IndexOf(e.GetFromVertex());
                int guiIndex2 = g.GetVertices().IndexOf(e.GetToVertex());

                CurrentGraphPanel.AddEdge(CurrentGraphPanel.Vertices[guiIndex1], CurrentGraphPanel.Vertices[guiIndex2], e);
            }

            selectedItemPropertyGrid.SelectedObject = g;
        }

        //Takes a graph, creates a new tab for it, and fills in the GUI components
        //The vertices are created where each vertex is in verts
        private void populateGraph(Graph g, List<GUIVertex> verts)
        {
            int n = g.GetVertices().Count;

            makeNewGraphPanel(g);

            updateCurrentTool(AppTool.AddVertexTool);

            float angleAmount = 360f / n;
            Vector2 center = new Vector2(256, 170);

            for (int i = 0; i < g.GetVertices().Count; i++ )
            {
                Point addPoint = verts[i].Pos;
                for (int j = 0; j < verts.Count; j++)
                {
                    if (g.GetVertices()[i].Label.Equals(verts[j]))
                    {
                        addPoint = verts[j].Pos;
                        break;
                    }
                }

                CurrentGraphPanel.AddVertex(g.GetVertices()[i], addPoint);
            }

            foreach (Edge e in g.GetEdges())
            {
                int guiIndex1 = g.GetVertices().IndexOf(e.GetFromVertex());
                int guiIndex2 = g.GetVertices().IndexOf(e.GetToVertex());

                CurrentGraphPanel.AddEdge(CurrentGraphPanel.Vertices[guiIndex1], CurrentGraphPanel.Vertices[guiIndex2], e);
            }

            selectedItemPropertyGrid.SelectedObject = g;
        }

        private void onGraphDelete(object sender, EventArgs e)
        {
            if (graphCounter <= 0)
            {
                return;
            }

            //We want to delete the graph that is on the current tab
            GraphPanel gp = graphTabControl.TabPages[graphTabControl.SelectedIndex].Controls[0] as GraphPanel;
            Graph victim = gp.Graph;
            app.DeleteGraph(victim);
            int deleteIndex = graphTabControl.SelectedIndex;
            graphTabControl.TabPages.Remove(graphTabControl.TabPages[deleteIndex]);

            graphCounter--;

            Console.WriteLine("Deleted " + victim.Name);

            if(graphCounter <= 0)
            {
                selectedItemPropertyGrid.SelectedObject = null;
            }
        }

        void gp_MouseClick(object sender, MouseEventArgs e)
        {
            //Add a vertex if we're using the vertex tool
            AddVertexTool avt = currentTool as AddVertexTool;
            if (avt != null)
            {
                avt.AddVertex(app, this, e.Location);
                return;
            }
        }

        void gp_MouseDown(object sender, MouseEventArgs e)
        {
            SelectTool st = currentTool as SelectTool;
            if (st != null)
            {
                st.StartSelect(e.Location);
                return;
            }

            AddEdgeTool aet = currentTool as AddEdgeTool;
            if (aet != null)
            {
                aet.Begin(this, e.Location);
                return;
            }

            MoveObjectTool mt = currentTool as MoveObjectTool;
            if (mt != null)
            {
                mt.Begin(e.Location, CurrentGraphPanel.GetSelection());
                return;
            }
        }

        void gp_MouseMove(object sender, MouseEventArgs e)
        {
            if (currentTool != null)
            {
                currentTool.Update(e);
                CurrentGraphPanel.Refresh();
            }
        }

        void gp_MouseUp(object sender, MouseEventArgs e)
        {
            SelectTool st = currentTool as SelectTool;
            if (st != null)
            {
                st.EndSelect(app, this, e.Location, true);
                List<ISelectable> currentSelection = CurrentGraphPanel.GetSelection();
                if (currentSelection.Count == 1)
                {
                    selectedItemPropertyGrid.SelectedObject = currentSelection[0].GetItem();
                }
                else if (currentSelection.Count > 0)
                {
                    object[] selectedObjects = new object[currentSelection.Count];
                    for (int i = 0; i < currentSelection.Count; i++)
                    {
                        selectedObjects[i] = currentSelection[i].GetItem();
                    }

                    selectedItemPropertyGrid.SelectedObjects = selectedObjects;
                }
                else
                {
                    selectedItemPropertyGrid.SelectedObject = CurrentGraphPanel.Graph;
                }
                return;
            }

            AddEdgeTool aet = currentTool as AddEdgeTool;
            if (aet != null)
            {
                aet.End(app, this, e.Location);
                return;
            }

            MoveObjectTool mt = currentTool as MoveObjectTool;
            if (mt != null)
            {
                mt.End(e.Location);
                return;
            }
        }

        private void onTabChange(object sender, EventArgs e)
        {
            int tabIndex = graphTabControl.SelectedIndex;
            if (tabIndex < 0)
            {
                return;
            }
            GraphPanel gp = graphTabControl.TabPages[graphTabControl.SelectedIndex].Controls[0] as GraphPanel;
            Graph currentGraph = gp.Graph;
            app.SetCurrentGraph(currentGraph);

            selectedItemPropertyGrid.SelectedObject = currentGraph;

            gp.CurrentTool = currentTool;
            Console.WriteLine("Changed to " + currentGraph.Name);
        }

        private void onQuit(object sender, EventArgs e)
        {
            //Close the application
        }

        private void onVertexToolClick(object sender, EventArgs e)
        {
            Console.WriteLine("Add vertex tool selected");
            updateCurrentTool(AppTool.AddVertexTool);
        }

        private void onSelectToolClick(object sender, EventArgs e)
        {
            Console.WriteLine("Select tool selected");
            updateCurrentTool(AppTool.SelectTool);
        }

        private void onAddEdgeToolClick(object sender, EventArgs e)
        {
            Console.WriteLine("Edge tool selected");
            updateCurrentTool(AppTool.AddEdgeTool);
        }

        private void onMoveToolClick(object sender, EventArgs e)
        {
            Console.WriteLine("Move tool selected");
            updateCurrentTool(AppTool.MoveTool);
        }

        private void updateCurrentTool(AppTool tool)
        {
            currentTool = tool;
            if (CurrentGraphPanel != null)
            {
                CurrentGraphPanel.CurrentTool = tool;
            }
        }

        private void onDeleteSelected(object sender, EventArgs e)
        {
            if (CurrentGraphPanel != null)
            {
                CurrentGraphPanel.DeleteSelection(app);
                selectedItemPropertyGrid.SelectedObject = CurrentGraphPanel.Graph;
            }
        }

        private void onGenerateRandomGraph(object sender, EventArgs e)
        {
            this.AddRandomGraph(10);
        }

        private void onPropertyChange(object s, PropertyValueChangedEventArgs e)
        {
            Refresh();
        }

        private void onFilterVertexClick(object sender, EventArgs e)
        {
            if (vertexFilterButton.Checked)
            {
                AppTool.SelectTool.AddFilter(new SelectionFilter(typeof(Vertex)));
            }
            else
            {
                AppTool.SelectTool.RemoveFilter(new SelectionFilter(typeof(Vertex)));
            }
        }

        private void onFilterEdgeClick(object sender, EventArgs e)
        {
            if (edgeFilterButton.Checked)
            {
                AppTool.SelectTool.AddFilter(new SelectionFilter(typeof(Edge)));
                AppTool.SelectTool.AddFilter(new SelectionFilter(typeof(FlowEdge)));
            }
            else
            {
                AppTool.SelectTool.RemoveFilter(new SelectionFilter(typeof(Edge)));
                AppTool.SelectTool.RemoveFilter(new SelectionFilter(typeof(FlowEdge)));
            }
        }

        private void onPrimButtonClick(object sender, EventArgs e)
        {
            if (CurrentGraphPanel == null || CurrentGraphPanel.Graph.GetVertices().Count <= 0)
            {
                return;
            }

            List<GUIVertex> verts = CurrentGraphPanel.Vertices;
            Graph g = CurrentGraphPanel.Graph;
            Graph prim = GraphAlgorithms.PrimMST(g);
            prim.Name = "Prim MST";
            populateGraph(prim, verts);
        }

        private void onKruskalClick(object sender, EventArgs e)
        {
            if (CurrentGraphPanel == null || CurrentGraphPanel.Graph.GetVertices().Count <= 0)
            {
                return;
            }

            List<GUIVertex> verts = CurrentGraphPanel.Vertices;
            Graph g = CurrentGraphPanel.Graph;
            Graph kruskal = GraphAlgorithms.KruskalMST(g);
            kruskal.Name = "Kruskal MST";
            populateGraph(kruskal, verts);
        }

        private void onDijkstraClick(object sender, EventArgs e)
        {
            if (CurrentGraphPanel == null)
            {
                return;
            }

            //Make sure one vertex is selected
            List<ISelectable> selection = CurrentGraphPanel.GetSelection();
            GUIVertex vert;
            if (selection.Count <= 0 || selection.Count > 1)
            {
                return;
            }
            else if (selection[0] as GUIVertex == null)
            {
                return;
            }
            else
            {
                vert = selection[0] as GUIVertex;
            }

            List<GUIVertex> verts = CurrentGraphPanel.Vertices;
            Graph g = CurrentGraphPanel.Graph;
            GraphAlgorithms.Dijkstra(g, g.GetVertices().IndexOf(vert.Vertex), g.Directed);
        }

        private void onLabelCorrecting(object sender, EventArgs e)
        {
            if (CurrentGraphPanel == null)
            {
                return;
            }

            //Make sure one vertex is selected
            List<ISelectable> selection = CurrentGraphPanel.GetSelection();
            GUIVertex vert;
            if (selection.Count <= 0 || selection.Count > 1)
            {
                return;
            }
            else if (selection[0] as GUIVertex == null)
            {
                return;
            }
            else
            {
                vert = selection[0] as GUIVertex;
            }

            List<GUIVertex> verts = CurrentGraphPanel.Vertices;
            Graph g = CurrentGraphPanel.Graph;
            GraphAlgorithms.LabelCorrecting(g, g.GetVertices().IndexOf(vert.Vertex));
        }

        private void onAllPairs(object sender, EventArgs e)
        {
            if (CurrentGraphPanel == null)
            {
                return;
            }

            Graph g = CurrentGraphPanel.Graph;
            GraphAlgorithms.AllPairsShortestPath(g);
        }

        private void onMaxFlow(object sender, EventArgs e)
        {
            if (CurrentGraphPanel == null)
            {
                return;
            }

            //Make sure one vertex is selected
            List<ISelectable> selection = CurrentGraphPanel.GetSelection();
            GUIVertex source, sink;
            if (selection.Count != 2)
            {
                Output.WriteLine("Please select both the source and the sink, in that order");
                return;
            }
            else if (selection[0] as GUIVertex == null || selection[1] as GUIVertex == null)
            {
                Output.WriteLine("Please select both the source and the sink, in that order");
                return;
            }
            else
            {
                source = selection[0] as GUIVertex;
                sink = selection[1] as GUIVertex;
            }

            List<GUIVertex> verts = CurrentGraphPanel.Vertices;
            FlowNetwork fn = CurrentGraphPanel.Graph as FlowNetwork;
            if (fn != null)
            {
                float max = GraphAlgorithms.MaximumFlow(fn, fn.GetVertices().IndexOf(source.Vertex), fn.GetVertices().IndexOf(sink.Vertex));
                Output.WriteLine("[Max Flow Output]");
                Output.WriteLine("Max flow is " + max);
                Output.WriteLine("[End Max Flow Output]");
            }

        }

        private void onMinDomSetClick(object sender, EventArgs e)
        {
            if (CurrentGraphPanel == null)
            {
                return;
            }

            Graph g = CurrentGraphPanel.Graph;
            NumberInputForm inputForm = new NumberInputForm();
            inputForm.ShowDialog();
            if (inputForm.DialogResult == DialogResult.OK)
            {
                GraphAlgorithms.MinimumDominatingSet(g, inputForm.NumValue);
            }
        }

        private void onPrintMatrix(object sender, EventArgs e)
        {
            if (CurrentGraphPanel == null)
            {
                return;
            }

            Graph g = CurrentGraphPanel.Graph;
            g.UpdateMatrix();
            GraphAlgorithms.PrintMatrix(g.GetRawMatrix(), g.GetVertices().Count);
        }

        private void onGraphClassify(object sender, EventArgs e)
        {
            if (CurrentGraphPanel == null)
            {
                return;
            }

            Graph g = CurrentGraphPanel.Graph;

            Output.WriteLine("[Vertex Classification Output]");
            foreach (Vertex v in g.GetVertices())
            {
                VertexClassification vc = GraphAlgorithms.ClassifyVertex(v);
                Output.WriteLine("Vertex " + v.ToString() + " is " + vc.ToString());
            }

            Output.WriteLine("[End Vertex Classification Output]");
        }
    }
}
