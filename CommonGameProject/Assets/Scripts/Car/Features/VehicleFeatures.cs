using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Cars.Features
{
    namespace LoadingItems
    {
        /// <summary>
        /// Player can interact with it and it marks item can be placed to some vehicle
        /// </summary>
        interface ICanbeLoaded : IInteractable
        {
            void LoadInteraction(Car car);
        }
        /// <summary>Add possibility placing items which marked ICanbeLoaded to vehicle</summary>
        interface ILoaderFeature
        {
            void LoadItem(ICanbeLoaded item);
            void UnloadItem(ICanbeLoaded item);
            void UnloadAllItems();
        }
        interface IResourcesLoaderFeature
        {
            void LoadItem(Resources.Resource resource);
            void UnloadItem(Resources.Resource resource);
            void UnloadAllItems();
        }
    }
    interface IInteractable
    {
        void Interact();
    }
}
