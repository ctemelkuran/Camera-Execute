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
        public void ShowForm(ExternalCommandData commandData)
        {
            // If we do not have a form yet, create and show it

            if (_form == null || _form.IsDisposed)
            {
                // Instantiate Form1 to use 
                // the designer generated form.

                _form = new ChangeCameraForm(commandData);

                _form.Show();

                UIApplication uiapp = commandData.Application;
                uiapp.Idling += IdlingHandler;
            }
        }
        #endregion

        #region HideForm
        /// <summary>
        /// Hide the form.
        /// </summary>
        /// <remarks>
        /// The external command invokes 
        /// this on end-user request.
        /// </remarks>
        public void HideForm(UIApplication uiapp)
        {
            if (CloseForm())
            {
                // If the form was showing, we had subscribed

                uiapp.Idling -= IdlingHandler;
            }
        }

        #endregion
        public Result OnStartup(UIControlledApplication app)
        {
     
            _app = this;
            _form = null;
            AddMenu(app);
          
            return Result.Succeeded;
        }

        public Result OnShutdown(UIControlledApplication a)
        {

            if (CloseForm())
            {
                a.Idling -= IdlingHandler;
            }
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

                


                #region RevitOrthoCamera
                // Save current 3D view
                var view3D = doc.ActiveView as View3D;

                if (view3D == null || view3D.IsPerspective)
                {
                    TaskDialog ts = new TaskDialog("Incorrect View selected")
                    {
                        MainContent = "Please, select 3D Orthographic view."
                    };

                    ts.Show();
                    
                }

                // Get viewOrientation3D
                ViewOrientation3D viewOrientation3D = view3D.GetOrientation();
                ForwardDirection = viewOrientation3D.ForwardDirection;
                UpDirection = viewOrientation3D.UpDirection;
                var rightDirection = ForwardDirection.CrossProduct(UpDirection);
                EyePosition = viewOrientation3D.EyePosition;

                IList<UIView> views = uidoc.GetOpenUIViews();
                UIView currentView = views.FirstOrDefault(t => t.ViewId == view3D.Id);

                //Corners of the active UI view
                if (currentView == null)
                {
                    TaskDialog ts = new TaskDialog("Current View is null")
                    {
                        MainContent = "Current view is null"
                    };
                }

                IList<XYZ> corners = currentView.GetZoomCorners();
                XYZ corner1 = corners[0];
                XYZ corner2 = corners[1];

                //center of the UI view
                double x = (corner1.X + corner2.X) / 2;
                double y = (corner1.Y + corner2.Y) / 2;
                double z = (corner1.Z + corner2.Z) / 2;
                XYZ viewCenter = new XYZ(x, y, z);
                EyePosition = viewCenter;

                // Calculate diagonal vector
                XYZ diagVector = corner1 - corner2;

                double height = 0.5 * Math.Abs(diagVector.DotProduct(UpDirection));
                double width = 0.5 * Math.Abs(diagVector.DotProduct(rightDirection));
                Scale = Math.Min(height, width);
                #endregion

                try
                {
                    string path = @"C:\Users\cgrte\source\repos\Camera Execute\Camera Execute\CoordinateData\Coordinates.txt";
                    //Pass the filepath and filename to the StreamWriter Constructor
                    if (!File.Exists(path))
                    {
                        // Create a file to write to.
                        using (StreamWriter sw = File.CreateText(path))
                        {
                            sw.WriteLine("Data of 3D Orientation View\n");
                        }
                    }

                    using (StreamWriter sw = File.AppendText(path))
                    {
                        
                        sw.WriteLine(string.Format("EyePosition  -->  X: {0,-4} Y: {1}  Z: {2}", EyePosition.X, EyePosition.Y, EyePosition.Z));
                        sw.WriteLine(string.Format("UpDirection  -->  X: {0,-4} Y: {1}  Z: {2}", UpDirection.X, UpDirection.Y, UpDirection.Z));
                        sw.WriteLine(string.Format("FwdDirection -->  X: {0,-4} Y: {1}  Z: {2}\n", ForwardDirection.X, ForwardDirection.Y, ForwardDirection.Z));
                    }

                    //Close the file
                    //sw.Close();
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Exception: " + ex.Message);
                }

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
        public static double Scale { get; private set; }

        public static XYZ EyePosition { get; private set; }

        public static XYZ UpDirection { get; private set; }

        public static XYZ ForwardDirection { get; private set; }
    }
}
