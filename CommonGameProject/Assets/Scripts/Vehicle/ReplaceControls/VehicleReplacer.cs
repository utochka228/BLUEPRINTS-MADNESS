using Game.CameraSystem;
using Game.InputSystem;
using UnityEngine;

namespace Game.Transport.Replacing
{
    /// <summary>
    /// Scene script what replace target vehicle by the user selected
    /// </summary>
    public class VehicleReplacer : MonoBehaviour
    {
        #region Events

        public delegate void VehicleNewPrevReplaced(Vehicle vehicle, Vehicle previousVehicle);
        public delegate void VehicleReplaced(Vehicle vehicle);
        public event VehicleReplaced OnVehicleReplaced;
        public event VehicleNewPrevReplaced OnVehicleNewPrevReplaced;

        #endregion

        [SerializeField] InputSetup inputSetup;

        private Vehicle targetVehicle;

        #region ScriptsForReplace

        // Scripts what need to replace the target vehicle
        [SerializeField] CameraControl cameraSystem;

        #endregion

        public void Replace(Vehicle newVehicle)
        {
            targetVehicle = newVehicle;

            SetVehicleInputsActivation();

            OnVehicleNewPrevReplaced?.Invoke(newVehicle, targetVehicle);
            OnVehicleReplaced?.Invoke(newVehicle);
        }

        private void SetVehicleInputsActivation()
        {
            if (targetVehicle == null)
                inputSetup.PlayerControls.VehicleControls.Disable();
            else
                inputSetup.PlayerControls.VehicleControls.Enable();
        }
    }
}
