#region Namespaces
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Autodesk.Revit.ApplicationServices;
using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using Autodesk.Revit.UI.Selection;
#endregion

namespace Camera_Execute
{
    [Transaction(TransactionMode.Manual)]
    public class Command : IExternalCommand
    {
        public Result Execute(
          ExternalCommandData commandData,
          ref string message,
          ElementSet elements)
        {
            UIApplication uiapp = commandData.Application;
            UIDocument uidoc = uiapp.ActiveUIDocument;
            Application app = uiapp.Application;
            Document doc = uidoc.Document;
     
            ChangeCameraForm changeCameraForm = new ChangeCameraForm(commandData);

            changeCameraForm.Show();

        


            //bool isOpen = false;
            //foreach (Form form in System.Windows.Forms.Application.OpenForms)
            //{
            //    if (form.Name == "ChangeCameraForm")
            //    {
            //        isOpen = true;
            //    }
            //}

            return Result.Succeeded;
        }
        public static double Scale { get; private set; }

        public static XYZ EyePosition { get; private set; }

        public static XYZ UpDirection { get; private set; }

        public static XYZ ForwardDirection { get; private set; }
    }
}
