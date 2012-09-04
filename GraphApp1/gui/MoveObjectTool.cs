using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace GraphApp.src.gui
{
    public class MoveObjectTool : AppTool
    {
        private List<ISelectable> selection;
        private Point start, delta;
        private bool hasBegun = false;

        public void Begin(Point p, List<ISelectable> selection)
        {
            start = p;
            this.selection = selection;
            hasBegun = true;
        }

        public override void Update(System.Windows.Forms.MouseEventArgs e)
        {
            delta = new Point(e.Location.X - start.X, e.Location.Y - start.Y);
        }

        public void End(Point p)
        {
            delta = new Point(p.X - start.X, p.Y - start.Y);

            if (selection != null)
            {
                foreach (ISelectable i in selection)
                {
                    GUIVertex gv = i as GUIVertex;
                    if (gv == null)
                    {
                        continue;
                    }
                    gv.Pos = new Point(gv.Pos.X + delta.X, gv.Pos.Y + delta.Y);
                }
            }

            hasBegun = false;
            selection = null;
        }

        public override void Draw(Graphics g)
        {
            if (!hasBegun)
            {
                return;
            }
            if (selection != null)
            {
                foreach (ISelectable i in selection)
                {
                    GUIVertex gv = i as GUIVertex;
                    if (gv == null)
                    {
                        continue;
                    }
                    gv.Draw(g, delta);
                }
            }
        }
    }
}
