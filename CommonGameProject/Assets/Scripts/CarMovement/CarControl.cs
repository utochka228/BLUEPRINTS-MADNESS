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
        public Car targetCar;

        private void Awake()
        {
            i = this;
        }

        private void OnEnable()
        {
            CarsReplaceController.OnCarReplaced += SetNewCar;
        }

        private void SetNewCar(Car newCar)
        {
            targetCar = newCar;
        }

        private void OnDisable()
        {
            CarsReplaceController.OnCarReplaced -= SetNewCar;
        }

        void Update()
        {
            if (targetCar == null)
                return;

            if (Input.GetKeyDown(KeyCode.E))
                targetCar.Interact();

            targetCar.CarMover.GetInputs();

            targetCar.CarMover.AnimateWheels();
            targetCar.CarMover.SnapTrailsWheelsPos();
        }
        private void FixedUpdate()
        {
            if (targetCar == null)
                return;

            targetCar.CarMover.Move();
            targetCar.CarMover.Turn();
            targetCar.CarMover.Brake();
        }
    }
}
