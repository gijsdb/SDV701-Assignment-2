
/*
    Author: Gijs de Blauw
    Description: 
        - Inherits from frmCamera
        - Uses base methods and adds specific detail for PointNShoot
*/

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
        protected override bool PushData()
        {
            base.PushData();
            if (!base.PushData())
            {
                return false;
            }
            else
            {
                Camera.camera_type = "PointNShoot";
                Camera.zoom_range = txtZoomRange.Text;
                return true;
            }           
        }

        protected override void UpdateForm()
        {
            base.UpdateForm();
            txtZoomRange.Text = Camera.zoom_range;
        }
        #endregion

    }
}
