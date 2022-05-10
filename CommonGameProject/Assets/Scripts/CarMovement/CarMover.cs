using PlayerControls;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Cars.Movement
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
    public class CarMover : MonoBehaviour
    {
        [SerializeField] Vector3 centerOfMass;
        [SerializeField] float motorForce = 20f;
        [SerializeField] float turnSensativity = 1f;
        [SerializeField] float maxSteerAngle = 45f;
        [SerializeField] float brakeForce = 20f;
        [SerializeField] List<Wheel> wheels;
        [SerializeField] GameObject trailPrefab;
        Dictionary<WheelCollider, TrailRenderer> currentBrakeTrails = new Dictionary<WheelCollider, TrailRenderer>();

        private float inputX, inputY;
        private Rigidbody rb;

        private void Start()
        {
            rb = GetComponent<Rigidbody>();
            rb.centerOfMass = centerOfMass;
        }

        public void AnimateWheels()
        {
            foreach (var wheel in wheels)
            {
                Quaternion _rot;
                Vector3 _pos;
                wheel.collider.GetWorldPose(out _pos, out _rot);
                wheel.model.transform.position = _pos;
                wheel.model.transform.rotation = _rot;
            }
        }

        public void GetInputs()
        {
            inputX = Input.GetAxis("Horizontal");
            inputY = -Input.GetAxis("Vertical");
            SpawnBrakeTracks();
        }

        public void SpawnBrakeTracks()
        {
            if (Input.GetKey(KeyCode.Space))
            {
                //Spawn
                if (brake == false)
                {
                    foreach (var wheel in wheels)
                    {
                        if (wheel.brakenWheel)
                        {
                            var trail = Instantiate(trailPrefab).GetComponent<TrailRenderer>();
                            currentBrakeTrails.Add(wheel.collider, trail);
                        }
                    }
                }
                // add to dict
                brake = true;
            }
            if (Input.GetKeyUp(KeyCode.Space))
            {
                currentBrakeTrails.Clear();
                brake = false;
            }
        }

        bool brake;
        public void Brake()
        {
            if (brake)
            {
                foreach (var wheel in wheels)
                {
                    wheel.collider.brakeTorque = brakeForce;
                }
            }else
            {
                foreach (var wheel in wheels)
                {
                    wheel.collider.brakeTorque = 0;
                }
            }
        }


        public void SnapTrailsWheelsPos()
        {
            if (brake == false)
                return;

            //Set poses
            foreach (var trail in currentBrakeTrails)
            {
                trail.Key.GetWorldPose(out Vector3 pos, out Quaternion rot);
                trail.Value.transform.position = pos;
            }
        }

        public void Turn()
        {
            foreach (var wheel in wheels)
            {
                if(wheel.axel == Axel.Front)
                {
                    var _steerAngle = inputX * turnSensativity * maxSteerAngle;
                    wheel.collider.steerAngle = Mathf.Lerp(wheel.collider.steerAngle, _steerAngle, 0.5f);
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
