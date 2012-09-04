using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using GraphApp.src.helpers;

namespace GraphApp.src.gui
{
    public class AddEdgeTool : AppTool
    {
        GUIVertex startVert, endVert;
        Point currentPos;

        public bool HasBegun { get; set; }

        private bool isFlowNetwork;

        public void Begin(GraphAppGUI appGUI, Point p)
        {
            if (HasBegun)
            {
                return;
            }

            isFlowNetwork = false;

            GraphPanel gp = appGUI.CurrentGraphPanel;
            isFlowNetwork = (gp.Graph as FlowNetwork) != null;
            List<GUIVertex> verts = gp.Vertices;

            foreach (GUIVertex v in verts)
            {
                if (GeometryHelper.Intersects(p, new Circle(v.Pos, v.Radius)))
                {
                    startVert = v;
                    Console.WriteLine("Edge tool selected vertex " + v.Vertex.Label);
                    HasBegun = true;
                    return;
                }
            }

            startVert = null;
            HasBegun = false;
            Console.WriteLine("Edge tool selected null");
        }

        public void End(GraphApp app, GraphAppGUI appGUI, Point p)
        {
            if (!HasBegun)
            {
                return;
            }
            GraphPanel gp = appGUI.CurrentGraphPanel;
            List<GUIVertex> verts = gp.Vertices;
            bool foundVert = false;

            foreach (GUIVertex v in verts)
            {
                if (GeometryHelper.Intersects(p, new Circle(v.Pos, v.Radius)))
                {
                    endVert = v;
                    Console.WriteLine("Edge tool ended on vertex " + v.Vertex.Label);
                    foundVert = true;
                    //Add vertex
                    if (isFlowNetwork)
                    {
                        FlowEdge fe = app.AddFlowEdge(startVert.Vertex, endVert.Vertex);
                        gp.AddEdge(startVert, endVert, fe);
                    }
                    else
                    {

                        //Change to add two edges, for both directions
                        Edge e = app.AddEdge(startVert.Vertex, endVert.Vertex);
                        gp.AddEdge(startVert, endVert, e);
                    }
                    
                    break;
                }
            }

            HasBegun = false;

            if (!foundVert)
            {
                startVert = null;
                endVert = null;
                return;
            }   
        }

        public override void Update(System.Windows.Forms.MouseEventArgs e)
        {
            currentPos = e.Location;
        }

        public override void Draw(Graphics g)
        {
            if (startVert == null || !HasBegun)
            {
                return;
            }

            Point dir = new Point(currentPos.X - startVert.Pos.X, currentPos.Y - startVert.Pos.Y);
            float len = (float)Math.Sqrt(dir.X * dir.X + dir.Y * dir.Y);
            if (len == 0)
            {
                return;
            }
            float recip = 1f / len;
            float xComp = recip * dir.X;
            float yComp = recip * dir.Y;
            xComp *= startVert.Radius;
            yComp *= startVert.Radius;

            Point first = new Point((int)(startVert.Pos.X + xComp), (int)(startVert.Pos.Y + yComp));

            g.DrawLine(Pens.Black, first, currentPos);
        }
    }
}
