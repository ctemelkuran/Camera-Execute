#region Namespaces
using System;
using System.Collections.Generic;
using System.Diagnostics;
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
            /*
            using (Transaction tx = new Transaction(doc))
            {
                tx.Start("Transaction Name");
                App.Instance.ShowForm(commandData.Application);
                tx.Commit();
            }
            */
     
            Form1 form1 = new Form1(commandData);
            // Modify document within a transaction
            using (Transaction tx = new Transaction(doc))
            {
                tx.Start("Transaction Name");
                    
                    form1.Show();
                tx.Commit();
            }
            
            return Result.Succeeded;
        }
    }
}