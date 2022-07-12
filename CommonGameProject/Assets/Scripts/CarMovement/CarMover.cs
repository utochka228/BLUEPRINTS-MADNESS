using Game.PlayerControls;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Cars.Movement
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

        bool brake;
        public void Brake()
        {
            foreach (var wheel in wheels)
            {
                wheel.collider.brakeTorque = brakeForce;
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
