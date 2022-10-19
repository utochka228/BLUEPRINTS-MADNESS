using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Transport.VehicleList
{
    public class Jeep : Vehicle
    {
        protected override void OnInteractedWithSmth(List<Collider> interactedItems)
        {
            
        }

        protected override void SubscribeInput()
        {
            throw new System.NotImplementedException();
        }
    }
}
