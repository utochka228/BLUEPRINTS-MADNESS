using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Interaction
{
    public class Interactor : MonoBehaviour
    {
        [SerializeField] LayerMask interactionMask;
        [SerializeField] float radiusInteraction = 2f;
        private Collider[] results;
        private int countFound;

        public delegate void InteractDelegate(Collider[] foundInteractables);
        public event InteractDelegate OnInteractablesFound;
        private void Update()
        {
            countFound = Physics.OverlapSphereNonAlloc(transform.position, radiusInteraction, results, interactionMask);
            if (countFound > 0)
                OnInteractablesFound?.Invoke(results);
        }
    }
}
