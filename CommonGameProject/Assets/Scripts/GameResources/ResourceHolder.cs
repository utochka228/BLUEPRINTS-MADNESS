using Cars.Features;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Resources
{
    public class ResourceHolder : MonoBehaviour, IInteractable
    {
        [SerializeField]
        private Resource holdedResource;

        public void Interact()
        {
            
        }
    }
}
