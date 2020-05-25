﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace sdv701_admin_app
{
    public partial class frmCamera : Form
    {
        #region Constructer
        public frmCamera()
        {
            InitializeComponent();
        }
        #endregion
        
        protected clsAllCameras _Camera;
        protected string lcBrand;

        #region Methods

        public void SetDetails(clsAllCameras prCamera)
        {
            _Camera = prCamera;

            if (_Camera.model_name != null)
            {
                txtModelName.Enabled = false;
                lcBrand = prCamera.camera_brand;
            }
            else
            {
                txtModelName.Enabled = true;
                lcBrand = prCamera.camera_brand;
            }

            UpdateForm();
            ShowDialog();
        }



        #endregion

        #region Buttons
        private void btnImage_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Coming");
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("You are about to exit without saving, are you sure you want to do this?", "Cancel", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Hide();
            }
        }

        private async void btnSave_Click(object sender, EventArgs e)
        {
            if(!PushData())
            {
                MessageBox.Show("There is an error with your input");
                
            } else
            {
                if (txtModelName.Enabled)
                {
                    MessageBox.Show(await ServiceClient.InsertCameraAsync(_Camera));
                    frmBrands.Instance.UpdateDisplay();
                    txtModelName.Enabled = false;
                }
                else
                    MessageBox.Show(await ServiceClient.UpdateCameraAsync(_Camera));
                Hide();
            }

            // Disabled because it updates the listview twice causing duplicates, this means data does 
            // not update in listview after save.
            // frmModels.Instance.UpdateForm();
        }
        #endregion

        #region Updates
        protected virtual bool PushData()
        {
            try
            {
                _Camera.camera_brand = lcBrand;
                _Camera.model_name = txtModelName.Text;
                _Camera.release_year = dtpReleaseYear.Value;
                _Camera.description = txtDescription.Text;
                _Camera.quantity = Convert.ToInt16(numStock.Value);
                _Camera.last_modified = DateTime.Today;
                _Camera.price = Convert.ToDecimal(txtPrice.Text);
                return true;
            } catch(System.FormatException)
            {
                return false;
            }
        }

        protected virtual void UpdateForm()
        {
            txtModelName.Text = _Camera.model_name;   
            dtpReleaseYear.Value = _Camera.release_year.Date;
            txtDescription.Text = _Camera.description;
            numStock.Value = _Camera.quantity;
            lblLastModified.Text = Convert.ToString(_Camera.last_modified);
            txtPrice.Text = Convert.ToString(_Camera.price);
        }
        #endregion

       
    }
}
