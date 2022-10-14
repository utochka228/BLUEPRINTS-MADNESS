using System.Collections.Generic;
using UnityEngine;
using Game.Interaction;
using Game.Transport.Movement;

namespace Game.Transport
{
    [RequireComponent(typeof(Interactor))]
    [RequireComponent(typeof(VehicleMover))]
    [RequireComponent(typeof(VehicleVisualsProcessor))]
    public abstract class Vehicle : MonoBehaviour
    {
        // General common parameters
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
        // Interaction with IInteractable logic
        //
        //
        public Interactor vehicleInteractor;

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
    }
}
