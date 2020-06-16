using static sdv701_customer_app.clsDTO;

namespace sdv701_customer_app
{
    interface ICameraControl
    {
        void PushData(clsAllCameras prCamera);
        void UpdateControl(clsAllCameras prCamera);
    }
}
