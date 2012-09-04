using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace GraphApp.src.gui
{
    public class AddVertexTool : AppTool
    {
        private Point currentPos;
        private int radius = GUIVertex.DefaultRadius;
        private int lineWidth = GUIVertex.DefaultLineWidth;

        public void AddVertex(GraphApp app, GraphAppGUI appGUI, Point p)
        {
            Vertex v = app.AddVertex();

            GraphPanel gp = appGUI.CurrentGraphPanel;
            gp.AddVertex(v, p);
        }

        public override void Update(System.Windows.Forms.MouseEventArgs e)
        {
            currentPos = new Point(e.X, e.Y);
        }

        public override void Draw(Graphics g)
        {
            Pen pen = new Pen(GUIVertex.DefaultBrush, lineWidth);
            Rectangle bounds = new Rectangle();
            bounds.X = currentPos.X - radius;
            bounds.Y = currentPos.Y - radius;
            bounds.Width = radius * 2;
            bounds.Height = radius * 2;

            g.DrawEllipse(pen, bounds);
        }
    }
}
