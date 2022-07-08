using Cars;
using Cars.ActionsOnVehicle;
using Cars.Movement;
using InputPresets;
using Interaction;
using ScriptableChannels;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace PlayerControls
{
    public class CarControl : MonoBehaviour
    {
        [SerializeField] VehicleControlChannel vehicleControlChannel;
        [SerializeField] CarsReplaceController replaceController;
        public Car targetCar;
        private PlayerInput playerInput;

        private void Awake()
        {
            GameInput gameInput = new GameInput();
#if UNITY_EDITOR
            gameInput.InGameEditor.Movement.performed += GetInput;
            gameInput.InGameEditor.Movement.Enable();
            gameInput.InGameEditor.MouseClick.started += OnMouseClicked;
#endif
        }

        private void OnMouseClicked(InputAction.CallbackContext context)
        {
            var mousePosition = Mouse.current.position;
            Vector2 mousePos = new(mousePosition.x.ReadValue(), mousePosition.y.ReadValue());
            replaceController.SelectCar(mousePos);
        }

        private void GetInput(InputAction.CallbackContext context)
        {
            var inputVector = context.ReadValue<Vector2>();
            if (targetCar == null)
            {
                Debug.Log("<color=orange>Can't send inputs - target vehicle is null!</color>");
                return;
            }
            if (targetCar.CarMover == null)
            {
                Debug.Log("<color=orange>Can't send inputs - Vehicle mover is null!</color>");
                return;
            }
            targetCar.CarMover.SendInputs(inputVector);
        }

        private void OnEnable()
        {
            CarsReplaceController.OnCarReplaced += SetNewCar;
            targetCar.vehicleInteractor.OnInteractablesFound += OnInteractableFound;
        }

        private void OnDisable()
        {
            CarsReplaceController.OnCarReplaced -= SetNewCar;
            targetCar.vehicleInteractor.OnInteractablesFound -= OnInteractableFound;
        }

        private void OnInteractableFound(Collider[] foundInteractables)
        {
            
        }

        private void SetNewCar(Car newCar)
        {
            targetCar = newCar;
        }

        void Update()
        {
            if (targetCar == null)
                return;

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
