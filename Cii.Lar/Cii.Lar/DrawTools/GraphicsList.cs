using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cii.Lar.DrawTools
{
    using System.Drawing;
    using UI;
    using DrawList = List<DrawObject>;

    public class GraphicsList
    {
        private DrawList graphicsList;

        public event EventHandler<ArrayChangedEventArgs<DrawObject>> DrawObjsChanged;

        public GraphicsList()
        {
            graphicsList = new DrawList();
        }

        private void OnDrawObjsChanged(ArrayChangedEventArgs<DrawObject> e)
        {
            DrawObjsChanged?.Invoke(this, e);
        }

        /// <summary>
        /// Count and this [nIndex] allow to read all graphics objects
        /// from GraphicsList in the loop.
        /// </summary>
        public int Count
        {
            get
            {
                return graphicsList.Count;
            }
        }

        public DrawObject this[int index]
        {
            get
            {
                if (index < 0 || index >= graphicsList.Count)
                    return null;

                return graphicsList[index];
            }
        }

        public void Draw(Graphics g, CursorPictureBox pictureBox)
        {
            int n = graphicsList.Count;
            DrawObject o;

            // Enumerate list in reverse order to get first
            // object on the top of Z-order.
            for (int i = n - 1; i >= 0; i--)
            {
                if (pictureBox == null)
                {
                    break;
                }
                o = graphicsList[i];
                o.Draw(g, pictureBox);
                if (o.Selected)
                {
                    o.DrawTracker(g, pictureBox);
                }
            }
        }

        public void Add(DrawObject obj, bool refreshWhenAdded = false)
        {
            graphicsList.Insert(0, obj);

            OnDrawObjsChanged(new ArrayChangedEventArgs<DrawObject>(obj, ArrayChangedType.ItemAdded, refreshWhenAdded));
        }

        public void UnselectAll()
        {
            foreach (DrawObject o in graphicsList)
            {
                o.Selected = false;
            }
        }
    }
}
