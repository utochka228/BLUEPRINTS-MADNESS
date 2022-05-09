using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CarsReplaceController : MonoBehaviour
{
    public static CarsReplaceController i;
    [SerializeField] Camera camera;
    [SerializeField] CinemachineVirtualCamera virtualCamera;
    public Car CurrentControlledCar { get; set; }
    public void ReplaceCar(Car newCar)
    {
        // Change car instance
        if (CurrentControlledCar != newCar)
            CurrentControlledCar = newCar;

        CarControl.i.targetCarMover = newCar.CarMover;
        // Change UI controls
        // Focus camera to new car
        virtualCamera.Follow = newCar.transform;
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
