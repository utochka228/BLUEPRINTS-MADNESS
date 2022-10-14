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
        public delegate void VehicleNewPrevReplaced(Vehicle vehicle, Vehicle previousVehicle);
        public delegate void VehicleReplaced(Vehicle vehicle);
        public event VehicleReplaced OnVehicleReplaced;
        public event VehicleNewPrevReplaced OnVehicleNewPrevReplaced;

        private Vehicle targetVehicle;

        #region ScriptsForReplace

        // Scripts what need to replace the target vehicle
        [SerializeField] CameraControl cameraSystem;

        #endregion

        public void Replace(Vehicle newVehicle)
        {
            OnVehicleNewPrevReplaced?.Invoke(newVehicle, targetVehicle);
            OnVehicleReplaced?.Invoke(newVehicle);
        }
    }
}
