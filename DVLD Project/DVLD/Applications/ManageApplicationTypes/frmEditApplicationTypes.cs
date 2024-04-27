﻿using DVLD.Classes;
using DVLD_Buisness;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace DVLD.Applications.ManageApplicationTypes
{
    public partial class frmEditApplicationTypes : Form
    {
        private int _ApplicationTypeID = -1;
        private clsApplicationType _ApplicationType;
        public frmEditApplicationTypes(int ApplicationTypeID)
        {
            InitializeComponent();
            _ApplicationTypeID = ApplicationTypeID; 
        }

       

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmEditApplicationTypes_Load(object sender, EventArgs e)
        {
            lblID.Text =_ApplicationTypeID.ToString();
            _ApplicationType = clsApplicationType.Find(_ApplicationTypeID);

            if ( _ApplicationType != null )
            {
                txtTitle.Text = _ApplicationType.Title;
                txtFees.Text = _ApplicationType.Fees.ToString();  
               
            }
        
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!this.ValidateChildren())
            {
                MessageBox.Show("Some fields are not valid!, put the mouse over the red icon(s) to see the error" ,"Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            _ApplicationType.Title = txtTitle.Text.Trim();
            _ApplicationType.Fees = Convert.ToSingle(txtFees.Text.Trim());

            if (_ApplicationType.Save())
            {
                MessageBox.Show("Data Saved Successfully" , "Saved" , MessageBoxButtons.OK , MessageBoxIcon.Information);
             
            }
            else
                MessageBox.Show("Error Data isn't saved", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);


        }

        private void txtTitle_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtTitle.Text.Trim())) 
            {
                e.Cancel = true;
                errorProvider1.SetError(txtTitle, "Field Title is Empty fill it");
            }
            else
            {
                errorProvider1.SetError(txtTitle, null);

            }
        }

        private void txtFees_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtFees.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtFees, "Fees can't be Empty");
                return;
            }
            else
            {
                errorProvider1.SetError(txtFees, null);

            }

            if (!clsValidation.IsNumber(txtFees.Text))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtFees, "Fees Must be Number");
            }
            else
                errorProvider1.SetError(txtFees, null);

        }
    }
}
