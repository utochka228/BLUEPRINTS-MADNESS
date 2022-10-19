using System.Collections.Generic;
using UnityEngine;
using Game.Interaction;
using Game.Transport.Movement;
using Zenject;
using Game.PlayerControls;

namespace Game.Transport
{
    [RequireComponent(typeof(Interactor))]
    [RequireComponent(typeof(VehicleMover))]
    [RequireComponent(typeof(VehicleVisualsProcessor))]
    public abstract class Vehicle : MonoBehaviour
    {
        [SerializeField] Canvas mobileControlsCanvasPrefab;
        public Canvas MobileControlsCanvas { get => mobileControlsCanvasPrefab; }

        #region General_Common_Vehicle_Params

        [SerializeField]
        protected float enginePower;
        [SerializeField]
        protected float brakePower;
        [SerializeField]
        public VehicleMover VehicleMover;
        public string VehicleName;

        public Axel rotatingAxel = Axel.Front;

        [SerializeField] float fuelConsumption;
        float currentFuelCount;

        [SerializeField]
        protected float interactableRadius = 5f;

        #endregion

        // Interaction with IInteractable logic
        #region Interaction

        public Interactor vehicleInteractor;

        #endregion

        private VehicleControl vehicleControl;

        [Inject]
        private void Construct(VehicleControl vehicleControl)
        {
            this.vehicleControl = vehicleControl;
        }

        private void Awake()
        {
            SubscribeInput();
        }

        private void Start()
        {
            RegisterMobileControlsCanvas();
        }

        private void RegisterMobileControlsCanvas()
        {
            if (ProjectUtils.IsMobilePlatform())
                vehicleControl.SpawnMobileControlsCanvas(this, mobileControlsCanvasPrefab);
        }

        public void Interact()
        {
            var collidersInSphere = Physics.OverlapSphere(transform.position, interactableRadius);
            List<Collider> filteredByInteractable = new List<Collider>();
            foreach (var item in collidersInSphere)
            {
                var interactable = item.GetComponent<IInteractable>();
                if (interactable != null)
                    filteredByInteractable.Add(item);
            }
            OnInteractedWithSmth(filteredByInteractable);
        }
        protected abstract void OnInteractedWithSmth(List<Collider> interactedColliders);

        /// <summary>
        /// Each vehicle type subscribes at the Awake custom controls input.
        /// </summary>
        protected abstract void SubscribeInput();
    }
}
