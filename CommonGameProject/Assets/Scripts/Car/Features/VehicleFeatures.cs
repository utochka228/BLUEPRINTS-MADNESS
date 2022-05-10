using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Cars.Features
{
    namespace LoadingItems
    {
        interface ICanbeLoaded
        {
            public GameObject MyGameobject { get; set; }
        }
        /// <summary>Add items loading to vehicle feature</summary>
        interface ILoaderFeature
        {
            void LoadItem(ICanbeLoaded item);
            void UnloadItem(ICanbeLoaded item);
            void UnloadAllItems();
        }
        interface IResourcesLoaderFeature : ILoaderFeature
        {

        }
    }

}
