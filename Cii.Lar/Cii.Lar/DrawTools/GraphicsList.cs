using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cii.Lar.DrawTools
{
    using System.Drawing;
    using UI;
    using UI.Picture;
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

        public IEnumerator<DrawObject> GetEnumerator()
        {
            return graphicsList.GetEnumerator();
        }

        public void Draw(Graphics g, ZoomblePictureBoxControl pictureBox)
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
                o.DrawTest(g, pictureBox);
                //if (o.Selected)
                //{
                //    o.DrawTracker(g, pictureBox);
                //}
            }
        }

        /// <summary>
        /// Returns INumerable object which may be used for enumeration
        /// of selected objects.
        /// 
        /// Note: returning IEnumerable<DrawObject> breaks CLS-compliance
        /// (assembly CLSCompliant = true is removed from AssemblyInfo.cs).
        /// To make this program CLS-compliant, replace 
        /// IEnumerable<DrawObject> with IEnumerable. This requires
        /// casting to object at runtime.
        /// </summary>
        /// <value></value>
        public IEnumerable<DrawObject> Selection
        {
            get
            {
                return graphicsList.Where(o => o.Selected).ToList();
            }
        }

        public void Add(DrawObject obj, bool refreshWhenAdded = false)
        {
            graphicsList.Insert(0, obj);

            obj.ID = Program.ExpManager.GetNextDrawObjectID();
            obj.Name = obj.Prefix + obj.ID.ToString();

            OnDrawObjsChanged(new ArrayChangedEventArgs<DrawObject>(obj, ArrayChangedType.ItemAdded, refreshWhenAdded));
        }

        /// <summary>
        /// delete draw objcet
        /// </summary>
        /// <param name="drawObject"></param>
        public void DeleteDrawObject(DrawObject drawObject)
        {
            graphicsList.Remove(drawObject);
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
