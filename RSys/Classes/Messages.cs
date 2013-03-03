using System;
using System.Collections.Generic;
using System.Text;
using DevExpress.XtraEditors;
using System.Windows.Forms;
namespace RSys
{
    public class Messages
    {
        public static bool Save()
        {
            if (DialogResult.No == XtraMessageBox.Show("Do you want to save changes?", Constants.AppTitle , MessageBoxButtons.YesNo, MessageBoxIcon.Question))
                return false;
            else
                return true;
        }

        public static bool Delete()
        {
            if (DialogResult.No == XtraMessageBox.Show("Do you want to delete this record?", Constants.AppTitle, MessageBoxButtons.YesNo, MessageBoxIcon.Question))
                return false;
            else
                return true;
        }

        public static void Information(string message)
        {
            XtraMessageBox.Show(message, Constants.AppTitle, MessageBoxButtons.OK , MessageBoxIcon.Information);
        }

        public static void Error(string message)
        {
            XtraMessageBox.Show(message, Constants.AppTitle, MessageBoxButtons.OK , MessageBoxIcon.Error);
        }

        public static void Warning(string message)
        {
            XtraMessageBox.Show(message, Constants.AppTitle, MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        public static bool YesNo(string message)
        {
            if (DialogResult.No == XtraMessageBox.Show(message, Constants.AppTitle, MessageBoxButtons.YesNo, MessageBoxIcon.Question))
                return false;
            else
                return true;
        }

    }
}
