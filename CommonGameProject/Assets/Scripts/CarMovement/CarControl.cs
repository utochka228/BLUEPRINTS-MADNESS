using Vehicle;
using Vehicle.ActionsOnVehicle;
using Vehicle.Movement;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PlayerControls
{
    public class CarControl : MonoBehaviour
    {
        public static CarControl i;
        public Vehicle.Vehicle targetCar;

        private void Awake()
        {
            i = this;
        }

        private void OnEnable()
        {
            VehiclesReplaceController.OnCarReplaced += SetNewCar;
        }

        private void SetNewCar(Vehicle.Vehicle newCar)
        {
            targetCar = newCar;
        }

        private void OnDisable()
        {
            VehiclesReplaceController.OnCarReplaced -= SetNewCar;
        }

        void Update()
        {
            if (targetCar == null)
                return;

            if (Input.GetKeyDown(KeyCode.E))
                targetCar.Interact();

            targetCar.VehicleMover.GetInputs();

            targetCar.VehicleMover.AnimateWheels();
            targetCar.VehicleMover.SnapTrailsWheelsPos();
        }
        private void FixedUpdate()
        {
            if (targetCar == null)
                return;

            targetCar.VehicleMover.Move();
            targetCar.VehicleMover.Turn();
            targetCar.VehicleMover.Brake();
        }
    }
}
