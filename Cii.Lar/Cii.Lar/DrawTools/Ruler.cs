using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cii.Lar.DrawTools
{
    public class Ruler
    {
        public static Dictionary<char, Point[]> signsTable = new Dictionary<char, Point[]>();

        private const int DigitWidth = 6;

        private static Pen RulerPen = new Pen(Color.Navy);

        private List<System.Drawing.Point> static_DrawScaledNumber_pixelList;

        private List<Point> static_DrawScaledNumber_logicCoordList;

        public int MaskWidth(double aValue)
        {
            // Larghezza di una cifra [pixel] * "numero di cifre nella rappresentazione come stringa"
            return DigitWidth * ValueString(aValue).Length;
        }

        /// <summary>
        /// Ritorna la stringa da stampare per il valore passatogli
        /// </summary>
        private string ValueString(double aValue)
        {
            return aValue.ToString("0.###");
        }

        public Ruler()
        {

        }

        private static void Initialize()
        {
            //  "1"
            Point[] one = {
                    new Point(0, 2),
                    new Point(2, 0),
                    new Point(2, 7)
                };

            //  "2"
            Point[] two = {
                    new Point(0, 1),
                    new Point(1, 0),
                    new Point(3, 0),
                    new Point(4, 1),
                    new Point(4, 3),
                    new Point(0, 7),
                    new Point(4, 7)
                };

            //  "3"
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

            //  "4"
            Point[] four = {
                    new Point(4, 5),
                    new Point(0, 5),
                    new Point(0, 4),
                    new Point(2, 1),
                    new Point(3, 0),
                    new Point(3, 7)
                };

            //  "5"
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

            //  "6"
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

            //  "7"
            Point[] seven = {
                    new Point(0, 0),
                    new Point(4, 0),
                    new Point(1, 7)
                };

            //  "8"
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

            //  "9"
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

            //  "0"
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

            //  "-"
            Point[] minus = {
                    new Point(1, 3),
                    new Point(4, 3)
                };

            //  "."  ","
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

        private void CreateSegmentsList(double Value, ref List<System.Drawing.Point> pointList, bool Horizontal, bool HideSign = false)
        {
            try
            {
                if (signsTable.Count == 0)
                {
                    Initialize();
                }

                pointList.Clear();

                string strValue = ValueString(Value);

                int alignmentOffset = -MaskWidth(Value) / 2;

                Point[] actualSign = null;
                char actualChar = '\0';

                for (int actualIndex = 0; actualIndex <= strValue.Length - 1; actualIndex++)
                {
                    actualChar = strValue.ToCharArray()[actualIndex];

                    if (HideSign && actualChar == '-')
                    {
                        continue;
                    }

                    actualSign = signsTable[actualChar];

                    Point newPoint = default(Point);
                    int xCoord = 0;
                    int yCoord = 0;
                    pointList.Capacity = pointList.Count + actualSign.Length + 1;
                    for (int i = 0; i <= actualSign.Length - 1; i++)
                    {

                        xCoord = (DigitWidth * actualIndex) + actualSign[i].X + alignmentOffset;
                        yCoord = actualSign[i].Y;

                        if (Horizontal)
                        {
                            newPoint = new System.Drawing.Point(xCoord, yCoord);
                        }
                        else
                        {
                            newPoint = new System.Drawing.Point(yCoord, -xCoord);
                        }

                        pointList.Add(newPoint);
                    }

                    pointList.Add(new System.Drawing.Point(int.MaxValue, int.MaxValue));
                }
            }
            catch (Exception ex)
            {
                LogHelper.GetLogger<Ruler>().Error(ex.Message);
                LogHelper.GetLogger<Ruler>().Error(ex.StackTrace);
            }
        }

        public void DrawScaledNumber(Graphics GR, double value, float xCoord, float yCoord, float ScaleFactor, bool Horizontal)
        {
            try
            {
                static_DrawScaledNumber_pixelList = new List<System.Drawing.Point>();
                CreateSegmentsList(value, ref static_DrawScaledNumber_pixelList, Horizontal);

                static_DrawScaledNumber_logicCoordList = new List<Point>();
                static_DrawScaledNumber_logicCoordList.Clear();

                Point tmpLogicPoint = default(Point);
                for (int iIter = 0; iIter <= static_DrawScaledNumber_pixelList.Count - 1; iIter++)
                {
                    if (static_DrawScaledNumber_pixelList[iIter].X != int.MaxValue)
                    {

                        tmpLogicPoint.X = (int)(static_DrawScaledNumber_pixelList[iIter].X / ScaleFactor + xCoord);
                        tmpLogicPoint.Y = (int)(static_DrawScaledNumber_pixelList[iIter].Y / ScaleFactor + yCoord);

                        static_DrawScaledNumber_logicCoordList.Add(tmpLogicPoint);
                    }
                    else
                    {

                        GR.DrawLines(RulerPen, static_DrawScaledNumber_logicCoordList.ToArray());

                        static_DrawScaledNumber_logicCoordList.Clear();
                    }
                }
            }
            catch (Exception ex)
            {
                LogHelper.GetLogger<Ruler>().Error(ex.Message);
                LogHelper.GetLogger<Ruler>().Error(ex.StackTrace);
            }
        }
    }
}
