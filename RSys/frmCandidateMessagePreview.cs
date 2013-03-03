using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace RSys
{
    public partial class frmCandidateMessagePreview : DevExpress.XtraEditors.XtraForm
    {
        public string txtMessageTrade;
        public string textMessageLocation;

        public frmCandidateMessagePreview(string trade)
        {
            InitializeComponent();

            this.txtTrade.Text = trade;
        }
        
       
        private void btnOk_Click(object sender, EventArgs e)
        {
            if (!Validation())
                return;
            
            //Set the return values
            txtMessageTrade = txtTrade.Text;
            textMessageLocation = txtLocation.Text;
            this.DialogResult = DialogResult.OK;

            Close();

        }

        private bool Validation()
        {
            bool check = true;
            //Err.ClearErrors();       


            if (txtTrade.Text == string.Empty)
            {
                Err.SetError(txtTrade, "Please enter a trade");
                txtTrade.Focus();
                check = false;
            }

            else
            {
                Err.SetError(txtTrade, null);
            }


            if ((txtLocation.Text == string.Empty))
            {
                Err.SetError(txtLocation, "Please enter a location.");
                txtLocation.Focus();
                check = false;
            }

            else
            {
                Err.SetError(txtLocation, null);
            }

            return check;


        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}