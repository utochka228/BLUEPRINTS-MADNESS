using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace Game.Interaction
{
    [RequireComponent(typeof(Interactable))]
    public class Interactor : MonoBehaviour
    {
        public static readonly List<IInteractable> interactables = new List<IInteractable>();
        private Interactable myInteractable;
        [SerializeField] LayerMask interactionMask;
        [SerializeField] float radiusInteraction = 2f;
        private Collider[] results;
        private int countFound;

        public delegate void InteractDelegate(Collider[] foundInteractables);
        public event InteractDelegate OnInteractablesFound;

        private void Start()
        {
            myInteractable = GetComponent<Interactable>();
        }

        private void Update()
        {
            FindInteractables();
        }

        private void FindInteractables()
        {
            results = Physics.OverlapSphere(transform.position, radiusInteraction, interactionMask);
        }
        private void OnDrawGizmos()
        {
            if (EditorApplication.isPlaying == false)
                return;

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
