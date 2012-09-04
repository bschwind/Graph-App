using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GraphApp.src.gui
{
    public class SelectionFilter
    {
        public Type Type;

        public SelectionFilter(Type type)
        {
            this.Type = type;
        }

        public override bool Equals(object obj)
        {
            if (obj as SelectionFilter == null)
            {
                return false;
            }
            return this.Type.Equals((obj as SelectionFilter).Type);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public bool PassesFilter(object o)
        {
            if (this.Type.Equals(o.GetType()))
            {
                return true;
            }

            return false;
        }
    }
}
