using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace sdv701_admin_app
{
    public partial class frmPointNShoot : sdv701_admin_app.frmCamera
    {
        #region Singleton
        public static readonly frmPointNShoot Instance = new frmPointNShoot();
        private frmPointNShoot()
        {
            InitializeComponent();
        }
        #endregion

        #region Methods
        public static void Run(clsAllCameras prCamera)
        {
            Instance.SetDetails(prCamera);
        }
        #endregion

        #region Updates
        protected override void PushData()
        {
            base.PushData();
            _Camera.camera_type = "PointNShoot";
            _Camera.zoom_range = txtZoomRange.Text;
        }

        protected override void UpdateForm()
        {
            base.UpdateForm();
            txtZoomRange.Text = _Camera.zoom_range;
        }
        #endregion

    }
}
