using Vehicle;
using Vehicle.ActionsOnVehicle;
using Vehicle.Movement;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PlayerControls
{
    public class VehicleControl : MonoBehaviour
    {
        public static VehicleControl i;
        public Vehicle.Vehicle targetVehicle;

        public static Vehicle.Vehicle GetTargetVehicle => i.targetVehicle;

        private void Awake()
        {
            i = this;
        }

        private void OnEnable()
        {
            VehiclesReplaceController.OnVehicleReplaced += SetNewVehicle;
        }

        private void SetNewVehicle(Vehicle.Vehicle newVehicle)
        {
            targetVehicle = newVehicle;
        }

        private void OnDisable()
        {
            VehiclesReplaceController.OnVehicleReplaced -= SetNewVehicle;
        }

        void Update()
        {
            if (targetVehicle == null)
                return;

            if (Input.GetKeyDown(KeyCode.E))
                targetVehicle.Interact();

            targetVehicle.VehicleMover.GetInputs();

            targetVehicle.VehicleMover.AnimateWheels();
            targetVehicle.VehicleMover.SnapTrailsWheelsPos();
        }
        private void FixedUpdate()
        {
            if (targetVehicle == null)
                return;

            targetVehicle.VehicleMover.Move();
            targetVehicle.VehicleMover.Turn();
            targetVehicle.VehicleMover.Brake();
        }
    }
}
