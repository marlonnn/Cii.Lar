﻿using Cii.Lar.UI;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cii.Lar.DrawTools
{
    /// <summary>
    /// Draw horizontal and vertical ruler
    /// Author: Zhong Wen 2017/08/31
    /// </summary>
    public class Rulers
    {
        private bool showRulers;
        public bool ShowRulers
        {
            get
            {
                return showRulers;
            }
            set
            {
                showRulers = value;
            }
        }

        private const int DigitWidth = 6;

        private GraphicsPropertiesManager graphicsPropertiesManager = GraphicsPropertiesManager.GraphicsManagerSingleInstance();
        public GraphicsPropertiesManager GraphicsPropertiesManager
        {
            get
            {
                return graphicsPropertiesManager;
            }
            set
            {
                graphicsPropertiesManager = value;
            }
        }

        private ZWPictureBox pictureBox;

        private float rulerStep = 50;

        public float RulerStep
        {
            get
            {
                return rulerStep * pictureBox.Zoom;
            }
            set
            {
                if (value != rulerStep)
                {
                    rulerStep = value;
                }
            }
        }

        private Dictionary<char, Point[]> signsTable;

        public Rulers()
        {
            InitializeSignsTable();
        }

        public Rulers(ZWPictureBox pictureBox) : this()
        {
            this.pictureBox = pictureBox;
        }

        #region initialize signs table
        private void InitializeSignsTable()
        {
            signsTable = new Dictionary<char, Point[]>();
            //figure "1"
            Point[] one = {
                    new Point(0, 2),
                    new Point(2, 0),
                    new Point(2, 7)
                };
            // figure "2"
            Point[] two = {
                    new Point(0, 1),
                    new Point(1, 0),
                    new Point(3, 0),
                    new Point(4, 1),
                    new Point(4, 3),
                    new Point(0, 7),
                    new Point(4, 7)
                };

            // figure "3"
            Point[] three = {
                    new Point(0, 1),
                    new Point(1, 0),
                    new Point(3, 0),
                    new Point(4, 1),
                    new Point(4, 2),
                    new Point(3, 3),
                    new Point(2, 3),
                    new Point(3, 3),
                    new Point(4, 4),
                    new Point(4, 6),
                    new Point(3, 7),
                    new Point(1, 7),
                    new Point(0, 6)
                };

            // figure "4"
            Point[] four = {
                    new Point(4, 5),
                    new Point(0, 5),
                    new Point(0, 4),
                    new Point(2, 1),
                    new Point(3, 0),
                    new Point(3, 7)
                };

            // figure "5"
            Point[] five = {
                    new Point(4, 0),
                    new Point(1, 0),
                    new Point(1, 1),
                    new Point(0, 2),
                    new Point(0, 3),
                    new Point(3, 3),
                    new Point(4, 4),
                    new Point(4, 6),
                    new Point(3, 7),
                    new Point(1, 7),
                    new Point(0, 6)
                };

            // figure "6"
            Point[] six = {
                    new Point(3, 0),
                    new Point(1, 0),
                    new Point(0, 1),
                    new Point(0, 6),
                    new Point(1, 7),
                    new Point(3, 7),
                    new Point(4, 6),
                    new Point(4, 4),
                    new Point(3, 3),
                    new Point(0, 3)
                };

            // figure "7"
            Point[] seven = {
                    new Point(0, 0),
                    new Point(4, 0),
                    new Point(1, 7)
                };

            // figure "8"
            Point[] eight = {
                    new Point(3, 0),
                    new Point(1, 0),
                    new Point(0, 1),
                    new Point(0, 2),
                    new Point(1, 3),
                    new Point(3, 3),
                    new Point(4, 4),
                    new Point(4, 6),
                    new Point(3, 7),
                    new Point(1, 7),
                    new Point(0, 6),
                    new Point(0, 4),
                    new Point(1, 3),
                    new Point(3, 3),
                    new Point(4, 2),
                    new Point(4, 1),
                    new Point(3, 0)
                };

            // figure "9"
            Point[] nine = {
                    new Point(0, 6),
                    new Point(1, 7),
                    new Point(3, 7),
                    new Point(4, 6),
                    new Point(4, 1),
                    new Point(3, 0),
                    new Point(1, 0),
                    new Point(0, 1),
                    new Point(0, 3),
                    new Point(1, 4),
                    new Point(4, 4)
                };

            // figure "0"
            Point[] zero = {
                    new Point(1, 0),
                    new Point(3, 0),
                    new Point(4, 1),
                    new Point(4, 6),
                    new Point(3, 7),
                    new Point(1, 7),
                    new Point(0, 6),
                    new Point(0, 1),
                    new Point(1, 0)
                };

            // figure "-"
            Point[] minus = {
                    new Point(1, 3),
                    new Point(4, 3)
                };

            // figure "." e figure ","
            Point[] dot = {
                    new Point(2, 6),
                    new Point(3, 6),
                    new Point(2, 7),
                    new Point(3, 7)
                };

            signsTable.Add('1', one);
            signsTable.Add('2', two);
            signsTable.Add('3', three);
            signsTable.Add('4', four);
            signsTable.Add('5', five);
            signsTable.Add('6', six);
            signsTable.Add('7', seven);
            signsTable.Add('8', eight);
            signsTable.Add('9', nine);
            signsTable.Add('0', zero);
            signsTable.Add('-', minus);
            signsTable.Add('.', dot);
            signsTable.Add(',', dot);
        } 
        #endregion

        private int MaskWidth(double aValue)
        {
            return DigitWidth * ValueString(aValue).Length;
        }

        private string ValueString(double aValue)
        {
            return aValue.ToString("0.###");
        }

        public void Draw(Graphics g)
        {
            if (ShowRulers)
            {
                using (Pen pen = new Pen(GraphicsPropertiesManager.GetPropertiesByName("Ruler").Color, 
                    GraphicsPropertiesManager.GetPropertiesByName("Ruler").PenWidth))
                {
                    g.ResetTransform();
                    DrawHorizontalRuler(g, pen);
                    DrawVerticalRuler(g, pen);
                }
            }
        }
        
        /// <summary>
        /// draw hotizontal ruler
        /// </summary>
        /// <param name="g"></param>
        /// <param name="pen"></param>
        public void DrawHorizontalRuler(Graphics g, Pen pen)
        {
            float x1Coord = pictureBox.Width / 2;
            float x2Coord = pictureBox.Width / 2;
            for ( ; x1Coord < pictureBox.Width; x1Coord += RulerStep)
            {
                //1.X > 0
                g.DrawLine(pen, x1Coord, pictureBox.Height / 2 - 10, x1Coord, pictureBox.Height / 2);
                g.DrawLine(pen, x1Coord + RulerStep / 2, pictureBox.Height / 2 - 5, x1Coord + RulerStep / 2, pictureBox.Height / 2);

                //2.X < 0
                g.DrawLine(pen, x2Coord, pictureBox.Height / 2 - 10, x2Coord, pictureBox.Height / 2);
                g.DrawLine(pen, x2Coord + RulerStep / 2, pictureBox.Height / 2 - 5, x2Coord + RulerStep / 2, pictureBox.Height / 2);
                x2Coord -= RulerStep;
            }

            g.DrawLine(pen, 0, pictureBox.Height / 2, pictureBox.Width, pictureBox.Height / 2);
        }

        /// <summary>
        /// draw vertical ruler
        /// </summary>
        /// <param name="g"></param>
        /// <param name="pen"></param>
        public void DrawVerticalRuler(Graphics g, Pen pen)
        {
            float y1Coord = pictureBox.Height / 2;
            float y2Coord = pictureBox.Height / 2;
            for ( ; y1Coord < pictureBox.Height; y1Coord += RulerStep)
            {
                //1.Y > 0
                g.DrawLine(pen, pictureBox.Width / 2 - 10, y1Coord, pictureBox.Width / 2, y1Coord);
                g.DrawLine(pen, pictureBox.Width / 2 - 5, y1Coord + RulerStep / 2, pictureBox.Width / 2, y1Coord + RulerStep / 2);

                g.DrawLine(pen, pictureBox.Width / 2 - 10, y2Coord, pictureBox.Width / 2, y2Coord);
                g.DrawLine(pen, pictureBox.Width / 2 - 5, y2Coord + RulerStep / 2, pictureBox.Width / 2, y2Coord + RulerStep / 2);
                y2Coord -= RulerStep;
            }
            g.DrawLine(pen, pictureBox.Width / 2, 0, pictureBox.Width / 2, pictureBox.Height);
        }
    }
}
