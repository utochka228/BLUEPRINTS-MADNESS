using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Vehicle.Storage
{
    [CreateAssetMenu]
    public class VehicleStorageInstance : ScriptableObject
    {
        public Cell[,] cells;

    }

    public struct Cell
    {
        public Vector3 localPosition;
        public bool exist;
    }
}
