using System.Collections.Generic;
using UnityEngine;
using Game.Resources;

namespace Game.Transport.VehicleList
{
    public class Track : Vehicle
    {
        public void LoadItem(Resource resource)
        {
            
        }

        public void UnloadAllItems()
        {
            throw new System.NotImplementedException();
        }

        public void UnloadItem(Resource resource)
        {
            throw new System.NotImplementedException();
        }

        protected override void OnInteractedWithSmth(List<Collider> interactedColliders)
        {
            foreach (var item in interactedColliders)
            {
                
            }
        }

        protected override void SubscribeInput()
        {
            throw new System.NotImplementedException();
        }
    }
}
