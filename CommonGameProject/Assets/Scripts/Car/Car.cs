using Cars.Features;
using Cars.Movement;
using Interaction;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Cars
{
    [RequireComponent(typeof(Interactor))]
    public abstract class Car : MonoBehaviour
    {
        // General common parameters
        [SerializeField]
        protected float enginePower;
        [SerializeField]
        protected float brakePower;
        public CarMover CarMover;
        public Interactor vehicleInteractor;
        public string CarName;

        [SerializeField] float fuelConsumption;
        float currentFuelCount;

        [SerializeField]
        protected float interactableRadius = 5f;
        // Interaction with IInteractable logic
        //
        //

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
