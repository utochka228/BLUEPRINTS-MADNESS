using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarControl : MonoBehaviour
{
    public static CarControl i;
    public CarMover targetCarMover;

    private void Awake()
    {
        i = this;
    }

    void Update()
    {
        if (targetCarMover == null)
            return;

        targetCarMover.AnimateWheels();
        targetCarMover.GetInputs();
        targetCarMover.SnapTrailsWheelsPos();
    }
    private void FixedUpdate()
    {
        if (targetCarMover == null)
            return;

        targetCarMover.Move();
        targetCarMover.Turn();
        targetCarMover.Brake();
    }
}
