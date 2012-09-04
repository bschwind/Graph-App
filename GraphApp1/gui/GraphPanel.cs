using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

namespace GraphApp.src.gui
{
    public partial class GraphPanel : UserControl
    {
        private List<ISelectable> selectables;
        private List<GUIVertex> verts;
        private List<GUIEdge> edges;
        private List<ISelectable> currentSelection;
        private LinearGradientBrush gb;

        public Graph Graph { get; set; }
        public AppTool CurrentTool { get; set; } //Variable to allow drawing of current app tool

        public GraphPanel()
        {
            InitializeComponent();
            verts = new List<GUIVertex>();
            edges = new List<GUIEdge>();
            selectables = new List<ISelectable>();
            currentSelection = new List<ISelectable>();
            this.DoubleBuffered = true;
            gb = new LinearGradientBrush(new Rectangle(0, 0, this.Width, this.Height), Color.SteelBlue, Color.DarkSlateGray, 90f);
        }

        public List<ISelectable> Selectables
        {
            get
            {
                return selectables;
            }
        }

        public List<GUIVertex> Vertices
        {
            get
            {
                return verts;
            }
        }

        public List<GUIEdge> Edges
        {
            get
            {
                return edges;
            }
        }

        public void Select(ISelectable s)
        {
            currentSelection.Add(s);
        }

        public void Deselect(ISelectable s)
        {
            currentSelection.Remove(s);
        }

        public List<ISelectable> GetSelection()
        {
            return currentSelection;
        }

        public void DeleteSelection(GraphApp app)
        {
            List<GUIEdge> localEdges = new List<GUIEdge>();

            foreach (ISelectable i in currentSelection)
            {
                GUIVertex gv = i as GUIVertex;
                if (gv != null)
                {
                    RemoveVertex(gv, app);
                    foreach (GUIEdge ge in gv.GetEdges())
                    {
                        localEdges.Add(ge);
                    }
                    continue;
                }

                GUIEdge e = i as GUIEdge;
                if (e != null)
                {
                    RemoveEdge(e, app);
                    continue;
                }
            }

            foreach (GUIEdge connected in localEdges)
            {
                RemoveEdge(connected, app);
            }

            Refresh();
        }

        public void Deselect()
        {
            foreach (ISelectable s in currentSelection)
            {
                s.Deselect();
            }

            currentSelection.Clear();
        }

        public void AddVertex(Vertex v, Point pos)
        {
            GUIVertex gv = new GUIVertex(v, pos);
            gv.Brush = GUIVertex.DefaultBrush;
            gv.Radius = GUIVertex.DefaultRadius;
            gv.LineWidth = GUIVertex.DefaultLineWidth;
            verts.Add(gv);
            selectables.Add(gv);

            //Refresh to draw new vertices
            Refresh();
        }

        private void RemoveVertex(GUIVertex gv, GraphApp app)
        {
            app.RemoveVertex(gv.Vertex);
            verts.Remove(gv);
            selectables.Remove(gv);
        }

        public void AddEdge(GUIVertex start, GUIVertex end, Edge e)
        {
            GUIEdge edge = new GUIEdge(start, end, e);
            edge.Brush = GUIEdge.DefaultBrush;
            edge.LineWidth = GUIEdge.DefaultLineWidth;
            edges.Add(edge);
            selectables.Add(edge);

            Refresh();
        }

        public void AddEdge(GUIVertex start, GUIVertex end, FlowEdge fe)
        {
            GUIFlowEdge edge = new GUIFlowEdge(start, end, fe);
            edge.Brush = GUIEdge.DefaultBrush;
            edge.LineWidth = GUIEdge.DefaultLineWidth;
            edges.Add(edge);
            selectables.Add(edge);

            Refresh();
        }

        private void RemoveEdge(GUIEdge e, GraphApp app)
        {
            app.RemoveEdge(e.Edge);
            edges.Remove(e);
            selectables.Remove(e);
        }

        protected override void OnClientSizeChanged(EventArgs e)
        {
            base.OnClientSizeChanged(e);
            gb = new LinearGradientBrush(new Rectangle(0, 0, this.Width, this.Height), Color.SteelBlue, Color.DarkSlateGray, 90f);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            Graphics g = e.Graphics;

            //Enable anti-aliasing for prettier vertices!
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            g.PixelOffsetMode = System.Drawing.Drawing2D.PixelOffsetMode.HighQuality;

            g.FillRectangle(gb, new Rectangle(0, 0, this.Width, this.Height));

            foreach (GUIVertex gv in verts)
            {
                gv.Draw(g);
            }

            foreach (GUIEdge edge in edges)
            {
                edge.Draw(g);
            }

            if (CurrentTool != null)
            {
                CurrentTool.Draw(g);
            }
        }
    }
}
