using Vehicle.Features.LoadingItems;
using Vehicle.Storage;
using Resources;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Vehicle.VehicleList
{
    public class Track : Car
    {
        private VehicleStorage storage;
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
    }
}
