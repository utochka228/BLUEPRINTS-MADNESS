using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Car : MonoBehaviour
{
    // General common parameters
    [SerializeField]
    protected float enginePower;
    [SerializeField]
    protected float brakePower;
    [SerializeField]
    public CarMover CarMover;
    public string CarName;
}
