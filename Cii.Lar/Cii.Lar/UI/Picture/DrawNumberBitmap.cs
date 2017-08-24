using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cii.Lar.UI.Picture
{
    /// <summary>
    /// Draw number on ruler
    /// Author: Zhong Wen 2017/08/24
    /// </summary>
    public class DrawNumberBitmap
    {
        private const int DigitWidth = 6;

        private Pen pen;
        public Pen Pen
        {
            get
            {
                return pen;
            }
            set
            {
                pen = value;
            }
        }
        public int MaskWidth(double aValue)
        {
            return DigitWidth * ValueString(aValue).Length;
        }
        private string ValueString(double aValue)
        {
            return aValue.ToString("0.###");
        }

        private List<Point> pixelList;
        private List<Point> logicCoordList;

        #region sign table dictionary
        public Dictionary<char, Point[]> signsTable;
        public void Initialize()
        {
            signsTable = new Dictionary<char, Point[]>();
            //figure "1"
            Point[] one = {
                    new Point(0, 2),
                    new Point(2, 0),
                    new Point(2, 7)
                };

            // "2"
            Point[] two = {
                    new Point(0, 1),
                    new Point(1, 0),
                    new Point(3, 0),
                    new Point(4, 1),
                    new Point(4, 3),
                    new Point(0, 7),
                    new Point(4, 7)
                };

            // "3"
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

            // "4"
            Point[] four = {
                    new Point(4, 5),
                    new Point(0, 5),
                    new Point(0, 4),
                    new Point(2, 1),
                    new Point(3, 0),
                    new Point(3, 7)
                };

            // "5"
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

            // "6"
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

            // "7"
            Point[] seven = {
                    new Point(0, 0),
                    new Point(4, 0),
                    new Point(1, 7)
                };

            // "8"
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

            // "9"
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

            // "0"
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

            // "-"
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
        #endregion

        public DrawNumberBitmap(Pen pen)
        {
            this.pen = pen;
            Initialize();
        }
        private void CreateSegmentsList(double Value, ref List<System.Drawing.Point> pointList, bool Horizontal, bool HideSign = false)
        {
            try
            {

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
                            newPoint = new Point(xCoord, yCoord);
                        }
                        else
                        {
                            newPoint = new Point(yCoord, -xCoord);
                        }

                        pointList.Add(newPoint);
                    }

                    pointList.Add(new System.Drawing.Point(int.MaxValue, int.MaxValue));
                }
            }
            catch (Exception ex)
            {
                LogHelper.GetLogger<DrawNumberBitmap>().Error(ex.Message);
                LogHelper.GetLogger<DrawNumberBitmap>().Error(ex.StackTrace);
            }
        }

        public void DrawScaledNumber(Graphics GR, double value, float xCoord, float yCoord, float ScaleFactor, bool Horizontal)
        {
            try
            {
                // Calcolo le coordinate dei segmenti da tracciare
                pixelList = new List<System.Drawing.Point>();
                CreateSegmentsList(value, ref pixelList, Horizontal);

                // Lista temporanea dei segmenti in coordinate logiche
                logicCoordList = new List<Point>();
                logicCoordList.Clear();

                Point tmpLogicPoint = default(Point);
                for (int iIter = 0; iIter <= pixelList.Count - 1; iIter++)
                {
                    if (pixelList[iIter].X != int.MaxValue)
                    {
                        tmpLogicPoint.X = (int)(pixelList[iIter].X / ScaleFactor + xCoord);
                        tmpLogicPoint.Y = (int)(pixelList[iIter].Y / ScaleFactor + yCoord);
                        logicCoordList.Add(tmpLogicPoint);
                    }
                    else
                    {
                        GR.DrawLines(Pen, logicCoordList.ToArray());
                        logicCoordList.Clear();
                    }
                }
            }
            catch (Exception ex)
            {
                LogHelper.GetLogger<DrawNumberBitmap>().Error(ex.Message);
                LogHelper.GetLogger<DrawNumberBitmap>().Error(ex.StackTrace);
            }
        }
    }
}
