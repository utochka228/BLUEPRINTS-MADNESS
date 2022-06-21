using Vehicle;
using Vehicle.Features.LoadingItems;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Resources
{
    [CreateAssetMenu(fileName = "Wood", menuName = "Resources/Wood")]
    public class Wood : Resource, ICanbeLoaded
    {
        public void Interact()
        {
            // Do nothing
        }

        public void LoadInteraction(Vehicle.Vehicle car)
        {
            
        }
    }
}
