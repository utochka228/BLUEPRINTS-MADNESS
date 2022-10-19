using Game.Transport.Movement;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Transport
{
    public class VehicleVisualsProcessor : MonoBehaviour
    {
        [SerializeField] VehicleMover vehicleMover;

        private readonly Dictionary<WheelCollider, TrailRenderer> currentBrakeTrails = new();

        private void Update()
        {
            AnimateWheels();
            SnapTrailsWheelsPos();
        }

        public void AnimateWheels()
        {
            foreach (var wheel in vehicleMover.Wheels)
            {
                Quaternion _rot;
                Vector3 _pos;
                wheel.collider.GetWorldPose(out _pos, out _rot);
                wheel.model.transform.position = _pos;
                wheel.model.transform.rotation = _rot;
            }
        }
        public void SnapTrailsWheelsPos()
        {
            if (vehicleMover.IsBraking == false)
                return;

            //Set poses
            foreach (var trail in currentBrakeTrails)
            {
                trail.Key.GetWorldPose(out Vector3 pos, out Quaternion rot);
                trail.Value.transform.position = pos;
            }
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
    }
}
