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

namespace DVLD.Tests
{
    public partial class frmEditTestTypes : Form
    {
        private clsTestType.enTestType _TestTypeID = clsTestType.enTestType.VisionTest;
        private clsTestType _TestType;
        public frmEditTestTypes(clsTestType.enTestType TestTypeID)
        {
            InitializeComponent();
            _TestTypeID = TestTypeID;
        }

        private void frmEditTestTypes_Load(object sender, EventArgs e)
        {
            _TestType = clsTestType.Find(_TestTypeID);
            lblID.Text = _TestTypeID.ToString();

            if (_TestType != null)
            {
                lblID.Text = ((int)_TestTypeID).ToString();
                txtTitle.Text = _TestType.Title;   
                txtDescription.Text = _TestType.Description;   
                txtFees.Text = _TestType.Fees.ToString();   
            }
            else
            {
                MessageBox.Show("Could not find Test Type with id = " + _TestTypeID.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }


        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!this.ValidateChildren())
            {
                MessageBox.Show("Error can't saved Some fields aren't valid, put mouse over red icon to see Error", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }


            _TestType.Title = txtTitle.Text.Trim();
            _TestType.Description = txtDescription.Text.Trim();
            _TestType.Fees = Convert.ToSingle(txtFees.Text.Trim());
           
            if (_TestType.Save())
            {
                MessageBox.Show("Data Saved Successfully", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
                MessageBox.Show("Error:Data isn't Saved Successfully", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);



        }

        private void txtTitle_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtTitle.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtTitle, "Title can't be blank");
            }
            else
            {
                errorProvider1.SetError(txtTitle, null);

            }
        }

        private void txtDescription_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtDescription.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtDescription, "Description can't be blank");
            }
            else
            {
                errorProvider1.SetError(txtDescription, null);

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

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
