using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using GraphApp.src.helpers;

namespace GraphApp.src.gui
{
    public class GUIFlowEdge : GUIEdge
    {
        private FlowEdge fe;

        public GUIFlowEdge(GUIVertex start, GUIVertex end, FlowEdge fe)
            : base(start, end, fe)
        {
            this.fe = fe;
        }

        public override object GetItem()
        {
            return fe;
        }

        public override void Draw(Graphics g)
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
            Vector2 center = (end + start) / 2;
            Vector2 labelPos = center + (perpDir * 20);

            if (e.ShowLabel)
            {
                g.DrawString(fe.CurrentFlow.ToString() + "/" + fe.Capacity.ToString(), font, Brushes.Black, labelPos.ToPointF());
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
    }
}
