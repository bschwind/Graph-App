using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace GraphApp.src.gui
{
    public class SelectTool : AppTool
    {
        private Point startPoint, endPoint;

        private List<SelectionFilter> filters = new List<SelectionFilter>();

        public bool Started { get; set; }

        public void StartSelect(Point p)
        {
            Console.WriteLine("Selection start: " + p.ToString());
            Started = true;
            startPoint = p;
        }

        public void AddFilter(SelectionFilter f)
        {
            filters.Add(f);
        }

        public void RemoveFilter(SelectionFilter f)
        {
            filters.Remove(f);
        }

        public void EndSelect(GraphApp app, GraphAppGUI appGUI, Point p, bool shiftHeld)
        {
            Console.WriteLine("Selection end: " + p.ToString());
            Started = false;

            endPoint = p;
            Rectangle selectionRect = getSelectionRectangle(startPoint, endPoint);

            GraphPanel gp = appGUI.CurrentGraphPanel;
            if (!shiftHeld)
            {
                gp.Deselect();
            }
            List<ISelectable> selectables = gp.Selectables;

            int selectTotal = 0;

            foreach (ISelectable s in selectables)
            {
                if (s.Intersects(selectionRect))
                {
                    bool filterPass = false;
                    foreach (SelectionFilter filter in filters)
                    {
                        if (filter.PassesFilter(s.GetItem()))
                        {
                            filterPass = true;
                        }
                    }

                    if (!filterPass)
                    {
                        continue;
                    }
                    gp.Select(s);
                    s.Select();
                    selectTotal++;
                    Console.WriteLine("Selected " + s.ToString());
                }
            }

            if (selectTotal == 0)
            {
                Console.WriteLine("Selected nothing");
                gp.Deselect();
            }

            gp.Refresh();
        }

        private Rectangle getSelectionRectangle(Point p1, Point p2)
        {
            return new Rectangle(Math.Min(startPoint.X, endPoint.X), Math.Min(startPoint.Y, endPoint.Y), Math.Abs(endPoint.X - startPoint.X), Math.Abs(endPoint.Y - startPoint.Y));
        }

        public override void Update(System.Windows.Forms.MouseEventArgs e)
        {
            endPoint = new Point(e.X, e.Y);
        }

        public override void Draw(Graphics g)
        {
            if (!Started)
            {
                return;
            }
            Rectangle r = getSelectionRectangle(startPoint, endPoint);
            g.DrawRectangle(Pens.Black, r);
        }
    }
}
