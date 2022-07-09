using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Interaction
{
    public class Interactor : MonoBehaviour
    {
        [SerializeField] LayerMask interactionMask;
        [SerializeField] float radiusInteraction = 2f;
        private Collider[] results = new Collider[5];
        private int countFound;

        public delegate void InteractDelegate(Collider[] foundInteractables);
        public event InteractDelegate OnInteractablesFound;
        private void Update()
        {
            FindInteractables();
        }

        private void FindInteractables()
        {
            countFound = Physics.OverlapSphereNonAlloc(transform.position, radiusInteraction, results, interactionMask);
            if (countFound > 0)
                OnInteractablesFound?.Invoke(results);
        }

        private void OnDrawGizmos()
        {
            Gizmos.color = Color.green;
            Gizmos.DrawWireSphere(transform.position, 1f);

            Gizmos.color = Color.red;
            if (results == null)
                return;
            // Need checking does found object this vehicle
            foreach (var point in results)
            {
                Gizmos.DrawWireSphere(point.transform.position, .3f);
            }
        }
    }
}
