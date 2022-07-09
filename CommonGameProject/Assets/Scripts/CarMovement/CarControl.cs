using Cars;
using Cars.ActionsOnVehicle;
using Cars.Movement;
using InputPresets;
using InputSystem;
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

        InputAction movementAction;
        private void Awake()
        {
            InitializeInput();
        }
        
        private void InitializeInput()
        {
            GameInput gameInput = new GameInput();
            InputSetup.SetupInput(InputStage.Gameplay);
#if UNITY_EDITOR
            gameInput.InGameEditor.Movement.started += MovementStarted;
            gameInput.InGameEditor.Movement.canceled += MovementCanceled;
            movementAction = gameInput.InGameEditor.Movement;
            gameInput.InGameEditor.Movement.Enable();
            gameInput.InGameEditor.MouseClick.started += OnMouseClicked;
            gameInput.InGameEditor.Brake.performed += BrakeHolding;
#endif
        }

        private void MovementCanceled(InputAction.CallbackContext obj)
        {
        }

        private void MovementStarted(InputAction.CallbackContext obj)
        {
        }

        private void BrakeHolding(InputAction.CallbackContext context)
        {
            targetCar.CarMover.SpawnBrakeTracks();
            targetCar.CarMover.Brake();
        }

        private void OnMouseClicked(InputAction.CallbackContext context)
        {
            var mousePosition = Mouse.current.position;
            bool selectVehicle = false;
#if UNITY_EDITOR
            if(Mouse.current.leftButton.isPressed)
                selectVehicle = true;
#endif
            // Process mobile logic
            //
            //////////
            if (selectVehicle)
            {
                Vector2 mousePos = new(mousePosition.x.ReadValue(), mousePosition.y.ReadValue());
                replaceController.SelectCar(mousePos);
            }
        }

        private void SendInputs()
        {
            var inputVector = movementAction.ReadValue<Vector2>();
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

            SendInputs();
            targetCar.CarMover.AnimateWheels();
            targetCar.CarMover.SnapTrailsWheelsPos();
        }
        private void FixedUpdate()
        {
            if (targetCar == null)
                return;

            targetCar.CarMover.Move();
            targetCar.CarMover.Turn(targetCar.rotatingAxel);
        }
    }
}
