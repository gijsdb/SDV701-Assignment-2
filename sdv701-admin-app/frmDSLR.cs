/*
    Author: Gijs de Blauw
    Description: 
        - Inherits from frmCamera
        - Uses base methods and adds specific detail for DSLR
*/

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
        protected override bool PushData()
        {
            base.PushData();
            if(!base.PushData())
            {
                return false;
            }
            else
            {
                _Camera.lens_mount = txtLensMount.Text;
                _Camera.camera_type = "DSLR";
                return true;
            }          
        }

        protected override void UpdateForm()
        {
            base.UpdateForm();
            txtLensMount.Text = _Camera.lens_mount;
        }
        #endregion
    }
}
