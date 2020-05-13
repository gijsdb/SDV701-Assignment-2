using System;
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

        #region Methods

        public void SetDetails(clsAllCameras prCamera)
        {
            _Camera = prCamera;

            if (_Camera.model_name != null)
            {
                txtModelName.Enabled = false;
            }
            else
            {
                txtModelName.Enabled = true;
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

        #endregion

        #region Updates
        protected virtual void PushData()
        {
            _Camera.model_name = txtModelName.Text;
            _Camera.description = txtDescription.Text;
            _Camera.quantity = Convert.ToInt16(numStock.Value);
            _Camera.last_modified = Convert.ToDateTime(lblLastModified.Text);
            _Camera.price = Convert.ToInt16(txtPrice.Text);
        }

        protected virtual void UpdateForm()
        {
            txtModelName.Text = _Camera.model_name;
            txtDescription.Text = _Camera.description;
            numStock.Value = _Camera.quantity;
            lblLastModified.Text = Convert.ToString(_Camera.last_modified);
            txtPrice.Text = Convert.ToString(_Camera.price);
        }
        #endregion
    }
}
