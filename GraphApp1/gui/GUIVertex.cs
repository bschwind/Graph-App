using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using GraphApp.src.helpers;

namespace GraphApp.src.gui
{
    public class GUIVertex : ISelectable
    {
        //Refactor this into options
        public static Brush DefaultBrush = Brushes.DarkBlue;
        public static Brush SelectBrush = Brushes.LightGreen;
        public static int DefaultRadius = 15;
        public static int DefaultLineWidth = 2;

        public int Radius { get; set; }
        public Brush Brush { get; set; }
        public Point Pos { get; set; }
        public int LineWidth { get; set; }
        
        public Vertex Vertex
        {
            get
            {
                return v;
            }
        }

        private bool selected;
        private Vertex v;
        private List<GUIEdge> edges;

        public GUIVertex(Vertex v, Point pos)
        {
            this.v = v;
            Pos = pos;
            edges = new List<GUIEdge>();
        }

        public List<GUIEdge> GetEdges()
        {
            return edges;
        }

        public void AddEdge(GUIEdge e)
        {
            edges.Add(e);
        }

        public void RemoveEdge(GUIEdge e)
        {
            edges.Remove(e);
        }

        public bool Intersects(Rectangle rect)
        {
            Circle c = new Circle();
            c.Center = Pos;
            c.Radius = Radius;

            return GeometryHelper.Intersects(rect, c);
        }

        public void Select()
        {
            selected = true;
        }

        public void Deselect()
        {
            selected = false;
        }

        public object GetItem()
        {
            return v;
        }

        public void Draw(Graphics g)
        {
            Pen pen = new Pen(selected? GUIVertex.SelectBrush : GUIVertex.DefaultBrush, LineWidth);
            Rectangle bounds = new Rectangle();
            bounds.X = Pos.X - Radius;
            bounds.Y = Pos.Y - Radius;
            bounds.Width = Radius * 2;
            bounds.Height = Radius * 2;

            g.DrawEllipse(pen, bounds);
            Font font = new Font(new FontFamily("Arial"), 9f);
            SizeF dim = g.MeasureString(v.Label, font);

            g.DrawString(v.Label, font, Brushes.Black, new PointF(Pos.X - (dim.Width / 2), Pos.Y - (dim.Height / 2)));
        }

        public void Draw(Graphics g, Point offset)
        {
            Pen pen = new Pen(selected ? GUIVertex.SelectBrush : GUIVertex.DefaultBrush, LineWidth);
            Rectangle bounds = new Rectangle();
            bounds.X = Pos.X - Radius + offset.X;
            bounds.Y = Pos.Y - Radius + offset.Y;
            bounds.Width = Radius * 2;
            bounds.Height = Radius * 2;

            g.DrawEllipse(pen, bounds);
            Font font = new Font(new FontFamily("Arial"), 9f);
            SizeF dim = g.MeasureString(v.Label, font);

            g.DrawString(v.Label, font, Brushes.Black, new PointF(Pos.X - (dim.Width / 2) + offset.X, Pos.Y - (dim.Height / 2) + offset.Y));
        }

        public override string ToString()
        {
            return v.Label;
        }
    }
}
