using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Transport.Storage
{
    [CreateAssetMenu]
    public class VehicleStorageInstance : ScriptableObject
    {
        public CellsWireStruct cellsStruct;
        public Vector3 localOffsetFromZero;
    }
}
