using Game.CameraSystem;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Transport.Replacing
{
    /// <summary>
    /// Scene script what replace target vehicle by the user selected
    /// </summary>
    public class VehicleReplacer : MonoBehaviour
    {
        public delegate void VehicleReplaced(Vehicle vehicle);
        public event VehicleReplaced OnVehicleReplaced;

        #region ScriptsForReplace

        // Scripts what need to replace the target vehicle
        [SerializeField] CameraControl cameraSystem;

        #endregion

        public void Replace(Vehicle selectedVehicle)
        {
            cameraSystem.SetNewVehicleTarget(selectedVehicle);
        }
    }
}
