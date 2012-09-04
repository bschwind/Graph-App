using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using GraphApp.src.helpers;

namespace GraphApp.src.gui
{
    public class GUIEdge : ISelectable
    {
        //Refactor this into options
        public static Brush DefaultBrush = Brushes.Black;
        public static Brush SelectBrush = Brushes.Aqua;
        public static int DefaultLineWidth = 2;

        public Brush Brush { get; set; }
        public Point StartPos { get; set; }
        public Point EndPos { get; set; }
        public int LineWidth { get; set; }

        public Edge Edge
        {
            get
            {
                return e;
            }
        }

        public GUIVertex StartVertex
        {
            get
            {
                return start;
            }
        }

        public GUIVertex EndVertex
        {
            get
            {
                return end;
            }
        }

        protected bool selected;
        protected GUIVertex start, end;
        protected Edge e;
        protected Font font;

        public GUIEdge(GUIVertex start, GUIVertex end, Edge e)
        {
            this.e = e;
            this.start = start;
            this.end = end;
            start.AddEdge(this);
            end.AddEdge(this);

            font = new Font(new FontFamily("Arial"), 12f, FontStyle.Regular);
        }

        public bool Intersects(Rectangle rect)
        {
            Circle c = new Circle();
            c.Center = new Point((StartPos.X + EndPos.X) / 2, (StartPos.Y + EndPos.Y)/2);
            c.Radius = 5;

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

        public virtual object GetItem()
        {
            return e;
        }

        public virtual void Draw(Graphics g)
        {
            Pen pen = new Pen(selected ? GUIEdge.SelectBrush : GUIEdge.DefaultBrush, LineWidth);

            StartPos = StartVertex.Pos;
            EndPos = EndVertex.Pos;

            Vector2 start = new Vector2(StartPos);
            Vector2 end = new Vector2(EndPos);

            Vector2 dir = Vector2.Normalize(end - start);

            Vector2 drawStart = start + (dir * StartVertex.Radius);
            Vector2 drawEnd = end - (dir * EndVertex.Radius);

            g.DrawLine(pen, drawStart.ToPoint(), drawEnd.ToPoint());

            Vector2 perpDir = Vector2.Normalize(dir.PerProduct());

            //Draw label
            Vector2 center = (end+start) / 2;
            Vector2 labelPos = center + (perpDir * 20);

            if (e.ShowLabel)
            {
                g.DrawString(e.Weight.ToString(), font, Brushes.Black, labelPos.ToPointF());
            }

            //Draw arrow if directed
            if (!e.Directed)
            {
                return;
            }
            Vector2 arrowBase = drawEnd - (dir * 15);

            Point[] pArray = new Point[3];
            pArray[0] = drawEnd.ToPoint();
            pArray[1] = (arrowBase + perpDir * 5).ToPoint();
            pArray[2] = (arrowBase - perpDir * 5).ToPoint();

            g.FillPolygon(selected ? GUIEdge.SelectBrush : GUIEdge.DefaultBrush, pArray);
        }

        public override string ToString()
        {
            return this.Edge.ToString();
        }
    }
}
