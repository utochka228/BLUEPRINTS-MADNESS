using Cars.Features.LoadingItems;
using Cars.Storage;
using Resources;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Cars.VehicleList
{
    public class Track : Car, IResourcesLoaderFeature
    {
        private CarStorage storage;
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
