using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Vehicle.ActionsOnVehicle
{
    public class VehiclesReplaceController : MonoBehaviour
    {
        public static VehiclesReplaceController i;
        [SerializeField] Camera camera;
        [SerializeField] GameObject replacedVehicleTrail;

        public delegate void CarReplaced(Vehicle newCar);
        public static event CarReplaced OnCarReplaced;
        public static void ReplaceVehicle(Vehicle newVehicle)
        {
            if (newVehicle == null)
                return;

            OnCarReplaced?.Invoke(newVehicle);
            Debug.Log("Car replaced. New car name " + newVehicle.VehicleName);
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
            var ray = camera.ScreenPointToRay(Input.mousePosition);
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
