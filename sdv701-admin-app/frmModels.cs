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
    public partial class frmModels : Form
    {

        private static Dictionary<string, frmModels> _ModelList = new Dictionary<string, frmModels>();

        public frmModels()
        {
            InitializeComponent();
        }


        public static void Run(string prModelName)
        {
            frmModels lcModelFrm;
            if (string.IsNullOrEmpty(prModelName) || !_ModelList.TryGetValue(prModelName, out lcModelFrm))
            {
                lcModelFrm = new frmModels();

                if (string.IsNullOrEmpty(prModelName))
                    Console.WriteLine("hello");
                // lcModelFrm.SetDetails(new clsModel());
                else
                {
                    _ModelList.Add(prModelName, lcModelFrm);
                    lcModelFrm.refreshFormFromDB(prModelName);
                }
            }
            else
            {
                lcModelFrm.Show();
                lcModelFrm.Activate();
            }
        }

        private async void refreshFormFromDB(string prArtistName)
        {
            //SetDetails(await ServiceClient.GetArtistAsync(prArtistName));
        }

        /*
        public void SetDetails(clsModel prModel)
        {
            //_Model = prModel;
            // txtName.Enabled = string.IsNullOrEmpty(_Artist.Name);
            //UpdateForm();
            //UpdateDisplay();
            //frmMain.Instance.GalleryNameChanged += new frmMain.Notify(updateTitle);
            //updateTitle(_Artist.ArtistList.GalleryName);
            //Show();

        }*/
    }
}
