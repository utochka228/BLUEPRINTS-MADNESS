using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Vehicle.Storage.CellsEditorCreator
{
    [ExecuteInEditMode]
    public class CellsStorageCreator : MonoBehaviour
    {
        public float CELLS_UNIT_SIZE = 1f;

        [SerializeField] VehicleStorageInstance _targetVehicleStorage;
        public VehicleStorageInstance targetVehicleStorage { get => _targetVehicleStorage; }
        public GameObject targetVehicle;

        private void OnDestroy()
        {
            SetVehicleStorage(null);
        }


        public void SetVehicleStorage(VehicleStorageInstance storage_instance)
        {
            _targetVehicleStorage = storage_instance;
        }
    }
}
