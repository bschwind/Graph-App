using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Windows.Forms;

namespace GraphApp.src.gui
{
    public abstract class AppTool
    {
        public static AddVertexTool AddVertexTool = new AddVertexTool();
        public static SelectTool SelectTool = new SelectTool();
        public static AddEdgeTool AddEdgeTool = new AddEdgeTool();
        public static MoveObjectTool MoveTool = new MoveObjectTool();

        public abstract void Update(MouseEventArgs e);
        public abstract void Draw(Graphics g);
    }
}
