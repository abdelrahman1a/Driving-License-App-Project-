﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD.Licenses
{
    public partial class frmShowLicensePersonHistory : Form
    {
        private int _PersonID = -1;

        public frmShowLicensePersonHistory(int PersonID)
        {
            InitializeComponent();
            _PersonID = PersonID;   
        }
        public frmShowLicensePersonHistory()
        {
            InitializeComponent();
         
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmShowLicensePersonHistory_Load(object sender, EventArgs e)
        {
            if (_PersonID != -1) 
            {
                ctrlPersonCardWithFilter1.LoadPersonInfo(_PersonID);
                ctrlPersonCardWithFilter1.FilterEnabled = false;
                ctrlDriverLicenses1.LoadByPersonID(_PersonID);
                
            }
            else
            {
                ctrlPersonCardWithFilter1.Enabled = true;
                ctrlPersonCardWithFilter1.FilterFocus() ;
            }
        }

        private void ctrlPersonCardWithFilter1_OnPersonSelected(int obj)
        {
            _PersonID = obj;

            if (_PersonID == -1)
            {
                ctrlDriverLicenses1.Clear();
            }
            else
            {
                ctrlDriverLicenses1.LoadByPersonID(_PersonID);
            }
        }
    }
}
