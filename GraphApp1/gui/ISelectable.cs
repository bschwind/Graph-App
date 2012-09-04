using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace GraphApp.src.gui
{
    public interface ISelectable
    {
        bool Intersects(Rectangle rect);
        void Select();
        void Deselect();
        //This is the object set on the property grid when it is selected
        object GetItem();
    }
}
