#region Namespaces
using System;
using System.Collections.Generic;
using System.Linq;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Reflection;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using Autodesk.Revit.ApplicationServices;
using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using Autodesk.Revit.UI.Events;

using Size = System.Drawing.Size;
using Autodesk.Revit.DB.Events;
using Camera_Execute;
#endregion

namespace Camera_Execute
{
    class App : IExternalApplication
    {

        // get the absolute path of this assembly
        static string ExecutingAssemblyPath = Assembly
          .GetExecutingAssembly().Location;

        // Singleton external application class instance.
        internal static App _app;

        /// <summary>
        /// Provide access to singleton class instance.
        /// </summary>
        public static App Instance
        {
            get { return _app; }
        }

        /// <summary>
        /// The tooltip form to display.
        /// </summary>
        internal static Form1 _form;

        #region ShowForm
        /// <summary>
        /// Create and show the form, 
        /// unless it already exists.
        /// </summary>
        /// <remarks>
        /// The external command invokes 
        /// this on end-user request.
        /// </remarks>
        //public void ShowForm(UIApplication uiapp)
        //{
        //    // If we do not have a form yet, create and show it

        //    if (_form == null || _form.IsDisposed)
        //    {
        //        // Instantiate Form1 to use 
        //        // the designer generated form.

        //        _form = new Form1();

        //        _form.Show();


        //    }
        //}
        #endregion
       



        public Result OnStartup(UIControlledApplication a)
        {
     
            _app = this;
            _form = null;
            AddMenu(a);
            return Result.Succeeded;
        }

        public Result OnShutdown(UIControlledApplication a)
        {
 
            return Result.Succeeded;
        }

        /// <summary>
        /// Return currently active UIView or null.
        /// </summary>
        static UIView GetActiveUiView(
          UIDocument uidoc)
        {
            Document doc = uidoc.Document;
            View view = doc.ActiveView;
            IList<UIView> uiviews = uidoc.GetOpenUIViews();
            UIView uiview = null;

            foreach (UIView uv in uiviews)
            {
                if (uv.ViewId.Equals(view.Id))
                {
                    uiview = uv;
                    break;
                }
            }
            return uiview;
        }


        #region AddMenu        
        private void AddMenu(UIControlledApplication app)
        {
            // Create constants for tab and panel names
            const string RIBBON_TAB = "Cgr Tools";
            const string RIBBON_PANEL = "Camera";

            // get the ribbon tab
            try
            {
                app.CreateRibbonTab(RIBBON_TAB);
            }
            catch (Exception) { } // tab already exists

            // get or create panel
            RibbonPanel panel = null;
            List<RibbonPanel> panels = app.GetRibbonPanels(RIBBON_TAB);
            foreach (RibbonPanel pnl in panels)
            {
                if (pnl.Name == RIBBON_PANEL)
                {
                    panel = pnl;
                    break;
                }
            }

            // couldnt find the panel
            if (panel == null)
            {
                panel = app.CreateRibbonPanel(RIBBON_TAB, RIBBON_PANEL);
            }


            // get the image for the button
            Image img = Camera_Execute.Properties.Resources.camera_icon;
            ImageSource imgSrc = GetImageSources(img);

            // Create Push Button data
            PushButtonData data = new PushButtonData("TurnOn", "Camera", ExecutingAssemblyPath, "Camera_Execute.Command")
            {
                ToolTip = "Constains camera coordinates",
                LongDescription = "This button shows you camera properties.",
                Image = imgSrc,
                LargeImage = imgSrc
            };

            // call RibbonItem from Revit.UI
            // RibbonItem item = panel.AddItem(data);
            PushButton button = panel.AddItem(data) as PushButton;
            button.Enabled = true;

        }
        #endregion

        #region GetImageSources
        private BitmapSource GetImageSources(Image img)
        {
            BitmapImage bmp = new BitmapImage();

            using (MemoryStream ms = new MemoryStream())
            {
                img.Save(ms, ImageFormat.Png);
                ms.Position = 0;

                bmp.BeginInit();
                bmp.CacheOption = BitmapCacheOption.OnLoad;
                bmp.UriSource = null;
                bmp.StreamSource = ms;

                bmp.EndInit();
            }
            return bmp;
        }
        #endregion

    }
}
