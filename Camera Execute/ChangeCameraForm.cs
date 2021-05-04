#region Namespaces
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Autodesk.Revit.ApplicationServices;
using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using Autodesk.Revit.UI.Selection;
using Autodesk.Revit.DB.DirectContext3D;
using Autodesk.Revit.DB.Events;
using Autodesk.Revit.UI.Events;
using System.Diagnostics;
#endregion
namespace Camera_Execute
{
    public partial class ChangeCameraForm : System.Windows.Forms.Form
    {
        private ExternalCommandData commandData;
        private UIApplication uiapp;
        private UIDocument uidoc;
        private Document doc;
        
       
        public void SetText(XYZ eyePosition, XYZ UpDirection, XYZ ForwardDirection)
        {
            tbxEyeX.Text = eyePosition.X.ToString();
            tbxEyeY.Text = eyePosition.Y.ToString();
            tbxEyeZ.Text = eyePosition.Z.ToString();
            tbxUpX.Text = UpDirection.X.ToString();
            tbxUpY.Text = UpDirection.Y.ToString();
            tbxUpZ.Text = UpDirection.Z.ToString();
            tbxFwdX.Text = ForwardDirection.X.ToString();
            tbxFwdY.Text = ForwardDirection.Y.ToString();
            tbxFwdZ.Text = ForwardDirection.Z.ToString();
        }

        public ChangeCameraForm(ExternalCommandData commandData)

        {
        InitializeComponent();

        this.commandData = commandData;
        uiapp = commandData.Application;
        uidoc = uiapp.ActiveUIDocument;
        doc = uidoc.Document;
            
        // active view
        GetViewAndConvert();


        }


        // gets coordinates as string and converts to double
        public static XYZ GetPointData(string X, string Y, string Z)
        {
            double x = double.Parse(X);
            double y = double.Parse(Y);
            double z = double.Parse(Z);
            return new XYZ(x, y, z);
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            uiapp = commandData.Application;
            uidoc = uiapp.ActiveUIDocument;
            doc = uidoc.Document;
            try
            {
                // Get the necessary information and invoke the GetPointData method
                XYZ eyeUser = GetPointData(tbxEyeX.Text, tbxEyeY.Text, tbxEyeZ.Text);
                XYZ upUser = GetPointData(tbxUpX.Text, tbxUpY.Text, tbxUpZ.Text);
                XYZ fwdUser = GetPointData(tbxFwdX.Text, tbxFwdY.Text, tbxFwdZ.Text);


                ViewOrientation3D viewOrientation = new ViewOrientation3D(eyeUser, upUser, fwdUser);

                // get 3d view from doc
                View3D view = Get3dView(doc);

                // get active 3d view
                View3D view3d = doc.ActiveView as View3D;

                // set the orientation with entered data
                view3d.SetOrientation(viewOrientation);

                uidoc.RefreshActiveView();

            }
            catch (Exception ex)
            {
                TaskDialog.Show("Revit", ex.Message);

            }

        }


        #region TextBox Validation

        /*
        /// <summary>
        /// validate the input value
        /// set back to its old value if input is invalid
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void eyeXtextBox_Validating(object sender, CancelEventArgs e)
        {
            int value;
            try
            {
                value = int.Parse(eyeX.Text);
                m_frameData.XNumber = value;
            }
            catch (FormatException formatEx)
            {
                Debug.WriteLine(formatEx.Message);
                TaskDialog.Show("Revit", "Please input a integer.");
                e.Cancel = true;
            }
            catch (ErrorMessageException msgEx)
            {
                xNumberTextBox.Text = m_frameData.XNumber.ToString();
                TaskDialog.Show("Revit", msgEx.Message);
                e.Cancel = true;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                TaskDialog.Show("Revit", "Please input a valid integer.");
                e.Cancel = true;
            }
        }
        */
        #endregion

        static View3D Get3dView(Document doc)
        {
            FilteredElementCollector collector
              = new FilteredElementCollector(doc)
                .OfClass(typeof(View3D));

            foreach (View3D v in collector)
            {
                Debug.Assert(null != v,
                  "never expected a null view to be returned"
                  + " from filtered element collector");

                // Skip view template here because view 
                // templates are invisible in project 
                // browser

                if (!v.IsTemplate)
                {
                    return v;
                }
            }
            return null;
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            GetViewAndConvert();
            
        }
        
        private void GetViewAndConvert()
        {
            View3D view3D = doc.ActiveView as View3D;
            
            // get view orientation 3D data
            ViewOrientation3D getViewOrientation3D = view3D.GetOrientation();

            XYZ eye = getViewOrientation3D.EyePosition; // camera position
            XYZ up = getViewOrientation3D.UpDirection; // up direction of the camera
            XYZ fwd = getViewOrientation3D.ForwardDirection; // the direction the camera is looking at
            
            //initialize the textbox data
            tbxEyeX.Text = eye.X.ToString("0.000");
            tbxEyeY.Text = eye.Y.ToString("0.000");
            tbxEyeZ.Text = eye.Z.ToString("0.000");
            //write up direction to textbox
            tbxUpX.Text = Convert.ToString(up.X);
            tbxUpY.Text = Convert.ToString(up.Y);
            tbxUpZ.Text = Convert.ToString(up.Z);
            //write forward direction to textbox
            tbxFwdX.Text = Convert.ToString(fwd.X);
            tbxFwdY.Text = Convert.ToString(fwd.Y);
            tbxFwdZ.Text = Convert.ToString(fwd.Z);
        }
  
    }
}
