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

        // get the absolute path of this assembly for AddMenu
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
        internal static ChangeCameraForm _form;

        /// <summary>
        /// Dispose and null out form.
        /// Return true if it was previously not disposed.
        /// </summary>
        static bool CloseForm()
        {
            bool rc = _form != null;

            if (rc)
            {
                if (!_form.IsDisposed)
                {
                    _form.Dispose();
                }
                _form = null;
            }
            return rc;
        }

        #region ShowForm
        /// <summary>
        /// Create and show the form, 
        /// unless it already exists.
        /// </summary>
        /// <remarks>
        /// The external command invokes 
        /// this on end-user request.
        /// </remarks>
        public void ShowForm(UIApplication uiapp)
        {
            // If we do not have a form yet, create and show it

            if (_form == null || _form.IsDisposed)
            {
                // Instantiate Form1 to use 
                // the designer generated form.

                _form = new ChangeCameraForm();

                _form.Show();


            }
        }
        #endregion

        public Result OnStartup(UIControlledApplication app)
        {
     
            //_app = this;
            //_form = null;
            AddMenu(app);
            while (app != null)
            {

            }
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

        #region IdlingHandler
        public void IdlingHandler(
          object sender,
          IdlingEventArgs args)
        {
            UIApplication uiapp = sender as UIApplication;
            UIDocument uidoc = uiapp.ActiveUIDocument;

            // UI document is null if the project is closed.

            if (null == uidoc || _form.IsDisposed)
            {
                uiapp.Idling -= IdlingHandler;
            }
            else // form still exists
            {
                Document doc = uidoc.Document;
                View view = doc.ActiveView;

                UIView uiview = GetActiveUiView(uidoc);

                // get the coordinates of Revit Window
                Autodesk.Revit.DB.Rectangle rect = uiview.GetWindowRectangle();

                // create a 2D point "p" for mouse position
                Point p = System.Windows.Forms.Cursor.Position;

                try
                {
                    string path = @"C:\Users\cgrte\source\repos\Coord.Revit.RibbonButton\Coord.Revit.RibbonButton\CoordinateData\Coordinates.txt";
                    //Pass the filepath and filename to the StreamWriter Constructor
                    if (!File.Exists(path))
                    {
                        // Create a file to write to.
                        using (StreamWriter sw = File.CreateText(path))
                        {
                            sw.WriteLine("Coordinates in Windows Screen");
                        }
                    }

                    using (StreamWriter sw = File.AppendText(path))
                    {
                        sw.WriteLine(string.Format("X: {0,-4} Y: {1}", p.X, p.Y));
                    }

                    //Close the file
                    //sw.Close();
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Exception: " + ex.Message);
                }

                // determine relative position of p between two corners
                // to obtain the relative width and height location values dx and dy 

                double dx = (double)(p.X - rect.Left)
                  / (rect.Right - rect.Left);

                double dy = (double)(p.Y - rect.Bottom)
                  / (rect.Top - rect.Bottom);

                // model coordinates of  the viewcorners from UIView
                IList<XYZ> corners = uiview.GetZoomCorners();
                XYZ a = corners[0];
                XYZ b = corners[1];
                XYZ v = b - a;

                // cursor point 'q' in model coordinates from the two relative values
                XYZ q = a
                  + dx * v.X * XYZ.BasisX
                  + dy * v.Y * XYZ.BasisY;

                // If the current view happens to be a 3D view, 
                // we could simply use it right away. In 
                // general we have to find a different one to 
                // run the ReferenceIntersector in.

                View3D view3d = GetView3d(doc); // ray casting requires a 3D view to operate in.

                XYZ viewdir = view.ViewDirection; // view direction

                XYZ origin = q + 1000 * viewdir;  // ray origin

                // Move tooltip to current cursor 
                // location and set tooltip text.
                Point cursor = System.Windows.Forms.Cursor.Position;

                // create the coordinates in a string format, to show at the cursor tip
                string location = string.Format("X: {0,-6} Y: {1}", cursor.X, cursor.Y);

                _form.Location = p + new Size(_form.Offset);
                _form.SetText(location);
            }
        }
        #endregion

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
