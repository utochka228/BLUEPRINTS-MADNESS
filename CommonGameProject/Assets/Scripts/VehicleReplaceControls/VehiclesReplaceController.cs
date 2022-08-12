using PlayerControls;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Vehicle.ActionsOnVehicle
{
    public class VehiclesReplaceController : MonoBehaviour
    {
        public static VehiclesReplaceController i;
        [SerializeField] Camera orthoCamera;

        public delegate void CarReplaced(Vehicle newCar);
        public static event CarReplaced OnVehicleReplaced;
        public static void ReplaceVehicle(Vehicle newVehicle)
        {
            if (newVehicle == null || newVehicle == VehicleControl.GetTargetVehicle)
                return;

            CreateTrail(newVehicle);

            OnVehicleReplaced?.Invoke(newVehicle);
            Debug.Log("Car replaced. New car name " + newVehicle.VehicleName);
        }

        private static void CreateTrail(Vehicle newVehicle)
        {
            if (VehicleControl.GetTargetVehicle != null)
            {
                var from = VehicleControl.GetTargetVehicle.transform;
                var to = newVehicle.transform;
                new VehicleRepTrail(from, to, 0.5f);
            }
        }

        private void Awake()
        {
            i = this;
        }

        private void Update()
        {
            SelectCar();
        }

        private void SelectCar()
        {
            var ray = orthoCamera.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, 100000f))
            {
                if (Input.GetMouseButtonDown(0))
                {
                    var car = hit.transform.GetComponent<Vehicle>();
                    if (car != null)
                    {
                        ReplaceVehicle(car);
                    }
                }
            
            }
        }
    }
}
