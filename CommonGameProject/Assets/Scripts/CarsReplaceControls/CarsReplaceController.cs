using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Cars.ActionsOnVehicle
{
    public class CarsReplaceController : MonoBehaviour
    {
        public static CarsReplaceController i;
        [SerializeField] Camera camera;

        public delegate void CarReplaced(Car newCar);
        public static event CarReplaced OnCarReplaced;
        public static void ReplaceCar(Car newCar)
        {
            if (newCar == null)
                return;

            OnCarReplaced?.Invoke(newCar);
            Debug.Log("Car replaced. New car name " + newCar.CarName);
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
                    var car = hit.transform.GetComponent<Car>();
                    if (car != null)
                    {
                        ReplaceCar(car);
                    }
                }
            
            }
        }
    }
}
