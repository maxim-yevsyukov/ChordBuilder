using System;
using System.Drawing;
using System.Windows.Forms;

namespace ToliyGuitarSchoolHelper
{
    enum BaseDockType
    {
        Fret,
        Finger,
        Muting
    }

    class BaseDock
    {
        private int dockId;
        private Panel parent;
        private BaseDockType dockType;
        private static int idCounter;
        public bool isSelected;
        public int InLocX;
        public int InLocY;
        public int InWidth;
        public int InHeight;
        private int OutLocX;
        private int OutLocY;
        private int OutWidth;
        private int OutHeight;
        private int XPad;
        private int YPad;

        public int DockID
        {
            get
            {
                return this.dockId;
            }
        }

        public BaseDockType Type
        {
            get
            {
                return this.dockType;
            }
        }

        static BaseDock()
        {
            idCounter = 1;
        }

        public BaseDock(Panel parnt, BaseDockType type, Point relLoc, Size size, int xPad, int yPad)
        {
            int num = idCounter;
            idCounter = num + 1;
            dockId = num;
            parent = parnt;
            dockType = type;
            InLocX = relLoc.X;
            InLocY = relLoc.Y;
            InWidth = size.Width;
            InHeight = size.Height;
            XPad = xPad;
            YPad = yPad;
            OutWidth = InWidth + 2 * xPad;
            OutHeight = InHeight + 2 * yPad;
            OutLocX = InLocX - xPad;
            OutLocY = InLocY - yPad;
        }

        public bool IsNear(Point screenPt)
        {
            return (screenPt.X < this.OutLocX || screenPt.X > this.OutLocX + this.OutWidth || screenPt.Y < this.OutLocY ? false : screenPt.Y <= this.OutLocY + this.OutHeight);
        }
    }
}