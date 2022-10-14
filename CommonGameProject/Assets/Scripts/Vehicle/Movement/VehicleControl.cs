using Game.Transport;
using Game.Transport.Replacing;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Game.PlayerControls
{
    public class VehicleControl : MonoBehaviour
    {
        [SerializeField] VehicleReplacer vehicleReplacer;
        public Vehicle TargetVehicle { get; private set; }  

        [SerializeField] Transform controlsCanvasesParent;

        private readonly Dictionary<Vehicle, Canvas> mobileControlsCanvases = new();

        private void Awake()
        {
            
        }

        private void OnEnable()
        {
            vehicleReplacer.OnVehicleReplaced += SetNewVehicle;
            vehicleReplacer.OnVehicleNewPrevReplaced += SetupVehicleControls;
            TargetVehicle.vehicleInteractor.OnInteractablesFound += OnInteractableFound;
        }

        private void OnDisable()
        {
            vehicleReplacer.OnVehicleReplaced -= SetNewVehicle;
            vehicleReplacer.OnVehicleNewPrevReplaced -= SetupVehicleControls;
            TargetVehicle.vehicleInteractor.OnInteractablesFound -= OnInteractableFound;
        }

        public void SpawnMobileControlsCanvas(Vehicle targetVehicle, Canvas controlsCanvas)
        {
            var spawnedCanvas = Instantiate(controlsCanvas, controlsCanvasesParent);
            spawnedCanvas.gameObject.SetActive(false);
            mobileControlsCanvases.Add(targetVehicle, spawnedCanvas);
        }

        private void SetupVehicleControls(Vehicle vehicle, Vehicle previousVehicle)
        {
            if (ProjectUtils.IsMobilePlatform())
            {
                SetupMobileControls(vehicle, previousVehicle);
            }
            else
            {
                SetupEditorControls();
            }
        }

        private void SetupEditorControls()
        {
            throw new NotImplementedException();
        }

        private void SetupMobileControls(Vehicle vehicle, Vehicle previousVehicle)
        {
            if (previousVehicle != null)
            {
                // Disable previous vehicle controls canvas
                mobileControlsCanvases.TryGetValue(previousVehicle, out Canvas previousControlsCanvas);
                previousControlsCanvas.gameObject.SetActive(false);
            }

            if (vehicle != null)
            {
                // Enable new vehicle controls canvas
                mobileControlsCanvases.TryGetValue(vehicle, out Canvas controlsCanvas);
                controlsCanvas.gameObject.SetActive(true);
            }
        }

        private void OnInteractableFound(Collider[] foundInteractables)
        {

        }

        private void SetNewVehicle(Vehicle newVehicle)
        {
            TargetVehicle = newVehicle;
        }

        void Update()
        {
            if (TargetVehicle == null)
                return;

            SendInputs();
        }

        private void SendInputs()
        {
            
        }

        private void FixedUpdate()
        {
            if (TargetVehicle == null)
                return;

            TargetVehicle.VehicleMover.Move();
            TargetVehicle.VehicleMover.Turn(TargetVehicle.rotatingAxel);
        }
    }
}
