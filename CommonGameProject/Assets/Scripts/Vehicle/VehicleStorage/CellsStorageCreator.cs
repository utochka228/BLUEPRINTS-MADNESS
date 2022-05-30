using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Vehicle.Storage.CellsCreator
{
    [ExecuteInEditMode]
    public class CellsStorageCreator : MonoBehaviour
    {
        public float CELLS_UNIT_SIZE = 1f;
        public static CellsStorageCreator instance;

        [SerializeField] VehicleStorageInstance _targetVehicleStorage;
        public VehicleStorageInstance targetVehicleStorage { get => _targetVehicleStorage; }
        public GameObject targetVehicle;
        private void Awake()
        {
            instance = this;
        }

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
