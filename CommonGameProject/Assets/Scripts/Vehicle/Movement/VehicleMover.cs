using System;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Transport.Movement
{
    public enum Axel
    {
        Front,
        Rear
    }
    [Serializable]
    public struct Wheel
    {
        public GameObject model;
        public WheelCollider collider;
        public Axel axel;
        public bool brakenWheel;
    }
    public class VehicleMover : MonoBehaviour
    {
        [SerializeField] Vector3 centerOfMass;
        [SerializeField] float motorForce = 20f;
        [SerializeField] float turnSensativity = 1f;
        [SerializeField] float maxSteerAngle = 45f;
        [SerializeField] float brakeForce = 20f;
        [SerializeField] List<Wheel> wheels;
        [SerializeField] GameObject trailPrefab;

        private Vehicle myVehicle;

        private float inputX, inputY;
        private Rigidbody rb;

        private bool brake;
        public bool IsBraking { get => brake; }
        public List<Wheel> Wheels { get => wheels; }

        private void Start()
        {
            myVehicle = GetComponent<Vehicle>();

            rb = GetComponent<Rigidbody>();
            rb.centerOfMass = centerOfMass;
        }
        
        public void GetMovementInputs(Vector2 inputVector)
        {
            inputX = inputVector.x;
            inputY = -inputVector.y;
        }

        #region MovingLogic

        private void Brake()
        {
            foreach (var wheel in wheels)
            {
                wheel.collider.brakeTorque = brakeForce;
            }
        }

        private void Turn(Axel axel)
        {
            foreach (var wheel in wheels)
            {
                if(wheel.axel == axel)
                {
                    var _steerAngle = inputX * maxSteerAngle;
                    wheel.collider.steerAngle = Mathf.Lerp(wheel.collider.steerAngle, _steerAngle, Time.deltaTime * turnSensativity);
                }
            }
        }

        private void Move()
        {
            foreach (var wheel in wheels)
            {
                wheel.collider.motorTorque = inputY * motorForce * 500 * Time.deltaTime;
            }
        }

        #endregion


        private void FixedUpdate()
        {
            if (myVehicle == null)
                return;

            Move();
            Turn(myVehicle.rotatingAxel);
        }
    }
}
