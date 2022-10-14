using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Transport.VehicleList
{
    public class Sedan : Vehicle
    {
        protected override void OnInteractedWithSmth(List<Collider> interactedColliders)
        {
            
        }

        protected override void SubscribeEditorInput()
        {
            throw new System.NotImplementedException();
        }

        protected override void SubscribeMobileInput()
        {
            throw new System.NotImplementedException();
        }
    }
}
