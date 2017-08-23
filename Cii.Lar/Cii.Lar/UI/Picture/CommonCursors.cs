using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cii.Lar.UI.Picture
{
    /// <summary>
    /// Static common cusros helper class
    /// Author: Zhong Wen 2017/08/23
    /// </summary>
    public class CommonCursors
    {
        [DllImport("user32.dll", EntryPoint = "DestroyIcon")]
        private static extern bool DestroyIcon([System.Runtime.InteropServices.InAttribute()] System.IntPtr hIcon);
        private Icon myInternalIcon = null;
        private System.Windows.Forms.Cursor myCustomCursor = null;
        public Cursor CustomCursor
        {
            get { return myCustomCursor; }
        }
        private static CommonCursors s_myEditCursorHelper;
        public enum enCursorType : int
        {
            Zoom = 0,
            Edit = 2
        }
        public CommonCursors(enCursorType CursorType)
        {
            try
            {
                if (CursorType == enCursorType.Zoom)
                {
                    Bitmap bmp = Properties.Resources.Zoom_32;
                    myInternalIcon = Icon.FromHandle(bmp.GetHicon());
                    myCustomCursor = new Cursor(myInternalIcon.Handle);
                }
                else if (CursorType == enCursorType.Edit)
                {
                    Bitmap bmp = Properties.Resources.edit;
                    myInternalIcon = Icon.FromHandle(bmp.GetHicon());
                    myCustomCursor = new Cursor(myInternalIcon.Handle);
                }
            }
            catch (Exception ex)
            {
                LogHelper.GetLogger<CommonCursors>().Error(ex.Message);
                LogHelper.GetLogger<CommonCursors>().Error(ex.StackTrace);
            }
        }

        public static Cursor EditCursor
        {
            get
            {
                try
                {
                    if (s_myEditCursorHelper == null)
                    {
                        s_myEditCursorHelper = new CommonCursors(CommonCursors.enCursorType.Edit);
                    }
                    return s_myEditCursorHelper.CustomCursor;
                }
                catch (Exception ex)
                {
                    //Interaction.MsgBox(ex.Message);
                    LogHelper.GetLogger<CommonCursors>().Error(ex.Message);
                    LogHelper.GetLogger<CommonCursors>().Error(ex.StackTrace);
                    return Cursors.No;
                }
            }
        }
        private static CommonCursors myZoomCursorHelper;
        public static Cursor ZoomCursor
        {
            get
            {
                try
                {
                    if (myZoomCursorHelper == null)
                    {
                        myZoomCursorHelper = new CommonCursors(CommonCursors.enCursorType.Zoom);
                    }
                    return myZoomCursorHelper.CustomCursor;
                }
                catch (Exception ex)
                {
                    LogHelper.GetLogger<CommonCursors>().Error(ex.Message);
                    LogHelper.GetLogger<CommonCursors>().Error(ex.StackTrace);
                    return Cursors.No;
                }
            }
        }
    }
}
