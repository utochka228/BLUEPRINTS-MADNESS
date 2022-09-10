using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Transport.Storage.CellsEditorCreator
{
    [ExecuteInEditMode]
    public class CellsStorageCreator : MonoBehaviour
    {
        public static CellsStorageCreator instance;

        public float CELLS_UNIT_SIZE = 1f;
        public float ManipulatorsDistance = 0.1f;

        [SerializeField] VehicleStorageInstance _targetVehicleStorage;
        public VehicleStorageInstance targetVehicleStorage { get => _targetVehicleStorage; }
        public GameObject targetVehicle;

        private void OnDestroy()
        {
            SetVehicleStorage(null);
        }

        private void OnEnable()
        {
            instance = this;
        }

        public void SetVehicleStorage(VehicleStorageInstance storage_instance)
        {
            _targetVehicleStorage = storage_instance;
        }
    }
}
