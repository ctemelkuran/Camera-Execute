﻿#region Namespaces
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
    public partial class Form1 : System.Windows.Forms.Form
    {
        /// <summary>
        /// Current UI document
        /// </summary>
        
        /// <summary>
        /// Current revit document
        /// </summary>
        
        private ExternalCommandData commandData;
        private UIApplication uiapp;
        private UIDocument uidoc;
        private Document doc;

        

        public Form1(ExternalCommandData commandData)
            
        {
            InitializeComponent();

            this.commandData = commandData;
            uiapp = commandData.Application;
            uidoc = uiapp.ActiveUIDocument;
            doc = uidoc.Document;

            // active view
            View3D view3D = doc.ActiveView as View3D;

            // get view orientation 3D data
            ViewOrientation3D getViewOrientation3D = view3D.GetOrientation();

            XYZ eye = getViewOrientation3D.EyePosition; // camera position
            XYZ up = getViewOrientation3D.UpDirection; // up direction of the camera
            XYZ fwd = getViewOrientation3D.ForwardDirection; // the direction the camera is looking at
                                                         
            //initialize the textbox data
            eyeX.Text = Convert.ToString(eye.X);
            eyeY.Text = Convert.ToString(eye.Y);
            eyeZ.Text = Convert.ToString(eye.Z);
            upX.Text = Convert.ToString(up.X);
            upY.Text = Convert.ToString(up.Y);
            upZ.Text = Convert.ToString(up.Z);
            fwdZ.Text = Convert.ToString(fwd.X);
            fwdY.Text = Convert.ToString(fwd.Y);
            fwdX.Text = Convert.ToString(fwd.Z);
    }

        public Form1()
        {
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
        public static XYZ GetPointData(string X, string Y, string Z)
        {
            double x = double.Parse(X);
            double y = double.Parse(Y);
            double z = double.Parse(Z);
            return new Autodesk.Revit.DB.XYZ(x, y, z);
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            uiapp = commandData.Application;
            uidoc = uiapp.ActiveUIDocument;
            doc = uidoc.Document;
            try
            {
                // Get the necessary information and invoke the GetPointData method
                XYZ eyeUser = GetPointData(eyeX.Text, eyeY.Text, eyeZ.Text);
                XYZ upUser = GetPointData(upX.Text, upY.Text, upZ.Text);
                XYZ fwdUser = GetPointData(fwdX.Text, fwdY.Text, fwdZ.Text);


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
                return;
            }

            // If the creation is successful, close this form
            // this.DialogResult = DialogResult.OK;
            // this.Close();
        }

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

        private void eyeX_TextChanged(object sender, EventArgs e)
        {

        }
    }
}