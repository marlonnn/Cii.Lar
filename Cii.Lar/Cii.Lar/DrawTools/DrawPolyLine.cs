﻿using Cii.Lar.UI;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cii.Lar.DrawTools
{
    public class DrawPolyLine : DrawPolygon
    {
        public DrawPolyLine()
        {

        }

        public DrawPolyLine(CursorPictureBox pictureBox, int x1, int y1, int x2, int y2) 
            : base(pictureBox, x1, y1, x2, y2)
        {
        }

        public bool CloseToFirstPoint(Point point)
        {
            if (PointCount <= 0) return false;

            Point first = Point.Ceiling(pointArray[0]);

            return CloseToPoint(first, point);
        }

        public void RemovePointAt(int nIndex)
        {
            if (nIndex > 0 && nIndex < pointArray.Count)
            {
                pointArray.RemoveAt(nIndex);
            }

        }
    }
}