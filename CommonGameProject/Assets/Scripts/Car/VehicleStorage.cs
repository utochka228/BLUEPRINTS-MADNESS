using System.Collections.Generic;
using UnityEngine;

namespace Cars.Storage
{
    /// <summary>
    /// Allow you to announce incapsulated and protected storage for car for resources loading
    /// </summary>
    public class VehicleStorage
    {
        [SerializeField]
        private List<StorageElement> carStorage;
    }
    public struct StorageElement
    {
    }
}