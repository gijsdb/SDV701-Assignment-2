using sdv701_admin_app.Properties;
using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

/*
    Author: Gijs de Blauw
    Description: 
        - Parent form for DSLR and PointNShoot 
        - Has base methods for updating and pushing data
        - Checks input before pushing data 
        - Adds new items and updates existing through API
*/

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

        private clsAllCameras camera;
        protected string lcBrand;

        protected clsAllCameras Camera { get => camera; set => camera = value; }

        #region Methods

        public void SetDetails(clsAllCameras prCamera)
        {
            Camera = prCamera;

            if (Camera.model_name != null)
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
                    MessageBox.Show(await ServiceClient.InsertCameraAsync(Camera));
                    frmBrands.Instance.UpdateDisplay();
                    txtModelName.Enabled = false;
                }
                else
                    MessageBox.Show(await ServiceClient.UpdateCameraAsync(Camera));
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
                Camera.camera_brand = lcBrand;
                Camera.model_name = txtModelName.Text;
                Camera.release_year = dtpReleaseYear.Value;
                Camera.description = txtDescription.Text;
                Camera.quantity = Convert.ToInt16(numStock.Value);
                Camera.last_modified = DateTime.Today;
                Camera.price = Convert.ToDecimal(txtPrice.Text);
                Camera.image = ConvertImageToBinary(imgCamera.Image);
                return true;
            } catch(System.FormatException)
            {
                return false;
            }
        }

        protected virtual void UpdateForm()
        {
            txtModelName.Text = Camera.model_name;   
            dtpReleaseYear.Value = Camera.release_year.Date;
            txtDescription.Text = Camera.description;
            numStock.Value = Camera.quantity;
            lblLastModified.Text = Convert.ToString(Camera.last_modified);
            txtPrice.Text = Convert.ToString(Camera.price);
            if (imgCamera.Image == null)
            {
                imgCamera.Image = Resources.emptypic;
            }
            else
            {
                imgCamera.Image = ConvertBinaryToImage(Camera.image);
            }
        }
        #endregion

        #region Image
        private void btnImage_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog fileDialog = new OpenFileDialog() { Filter = "JPG|*.jpg", ValidateNames = true, Multiselect = false })
            {
                if (fileDialog.ShowDialog() == DialogResult.OK)
                {
                    imgCamera.Image = Image.FromFile(fileDialog.FileName);
                }
            }
        }

        private byte[] ConvertImageToBinary(Image prImg)
        {
            MemoryStream lcMemoryStream = new MemoryStream();
            prImg.Save(lcMemoryStream, System.Drawing.Imaging.ImageFormat.Jpeg);
            return lcMemoryStream.ToArray();
        }

        private Image ConvertBinaryToImage(byte[] prImgBinary)
        {
            if(prImgBinary == null)
            {
                return imgCamera.Image = Resources.emptypic;
            } else
            {
                MemoryStream lcMemoryStream = new MemoryStream(prImgBinary);
                return Image.FromStream(lcMemoryStream);
            }
        }
        #endregion

    }
}
