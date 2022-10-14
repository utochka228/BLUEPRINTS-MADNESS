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

        private float inputX, inputY;
        private Rigidbody rb;

        private bool brake;
        public bool IsBraking { get => brake; }
        public List<Wheel> Wheels { get => wheels; }

        private void Start()
        {
            rb = GetComponent<Rigidbody>();
            rb.centerOfMass = centerOfMass;
        }
        
        public void SendInputs(Vector2 inputVector)
        {
            inputX = inputVector.x;
            inputY = -inputVector.y;
        }

        public void SpawnBrakeTracks()
        {
            ////Spawn
            //if (brake == false)
            //{
            //    foreach (var wheel in wheels)
            //    {
            //        if (wheel.brakenWheel)
            //        {
            //            var trail = Instantiate(trailPrefab).GetComponent<TrailRenderer>();
            //            currentBrakeTrails.Add(wheel.collider, trail);
            //        }
            //    }
            //}
            //// add to dict
            //brake = true;
            //if (Input.GetKeyUp(KeyCode.Space))
            //{
            //    currentBrakeTrails.Clear();
            //    brake = false;
            //}
        }

        public void Brake()
        {
            foreach (var wheel in wheels)
            {
                wheel.collider.brakeTorque = brakeForce;
            }
        }

        public void Turn(Axel axel)
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

        public void Move()
        {
            foreach (var wheel in wheels)
            {
                wheel.collider.motorTorque = inputY * motorForce * 500 * Time.deltaTime;
            }
        }
    }
}
