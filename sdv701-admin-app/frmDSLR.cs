using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace sdv701_admin_app
{
    public sealed partial class frmDSLR : sdv701_admin_app.frmCamera
    {

        #region Singleton create
        public static readonly frmDSLR Instance = new frmDSLR();
        public frmDSLR()
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
        }

        protected override void UpdateForm()
        {
            base.UpdateForm();
            txtLensMount.Text = _Camera.lens_mount;
        }
        #endregion
    }
}
