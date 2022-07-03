using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Vehicle.Storage
{
    [CreateAssetMenu]
    public class VehicleStorageInstance : ScriptableObject
    {
        public CellsWireStruct cellsStruct;
        [HideInInspector]
        public Vector3 m_localOffsetFromZero;
        public float cell_unit_size = 1f;

        #region InspectorGUI
        [HideInInspector]
        public Vector2Int m_wireSize;
        #endregion
    }
}
