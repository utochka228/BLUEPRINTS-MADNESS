using Game.InputSystem;
using Game.ScriptableChannels;
using Game.Transport;
using Game.Transport.Replacing;
using InputPresets;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Game.PlayerControls
{
    public class VehicleControl : MonoBehaviour
    {
        [SerializeField] VehicleControlChannel vehicleControlChannel;
        [SerializeField] VehicleReplacer vehicleReplacer;
        public Vehicle targetCar;

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
            targetCar.VehicleMover.SpawnBrakeTracks();
            targetCar.VehicleMover.Brake();
        }

        private void OnMouseClicked(InputAction.CallbackContext context)
        {
            var mousePosition = Mouse.current.position;
            bool selectVehicle = false;
#if UNITY_EDITOR
            if (Mouse.current.leftButton.isPressed)
                selectVehicle = true;
#endif
            // Process mobile logic
            //
            //////////
            if (selectVehicle)
            {
                Vector2 mousePos = new(mousePosition.x.ReadValue(), mousePosition.y.ReadValue());
                //replaceController.SelectCar(mousePos);
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
            if (targetCar.VehicleMover == null)
            {
                Debug.Log("<color=orange>Can't send inputs - Vehicle mover is null!</color>");
                return;
            }
            targetCar.VehicleMover.SendInputs(inputVector);
        }

        private void OnEnable()
        {
            vehicleReplacer.OnVehicleReplaced += SetNewVehicle;
            targetCar.vehicleInteractor.OnInteractablesFound += OnInteractableFound;
        }

        private void OnDisable()
        {
            vehicleReplacer.OnVehicleReplaced -= SetNewVehicle;
            targetCar.vehicleInteractor.OnInteractablesFound -= OnInteractableFound;
        }

        private void OnInteractableFound(Collider[] foundInteractables)
        {

        }

        private void SetNewVehicle(Vehicle newVehicle)
        {
            targetCar = newVehicle;
        }

        void Update()
        {
            if (targetCar == null)
                return;

            SendInputs();
            targetCar.VehicleMover.AnimateWheels();
            targetCar.VehicleMover.SnapTrailsWheelsPos();
        }
        private void FixedUpdate()
        {
            if (targetCar == null)
                return;

            targetCar.VehicleMover.Move();
            targetCar.VehicleMover.Turn(targetCar.rotatingAxel);
        }
    }
}
