using Game.Transport;
using Game.Transport.Replacing;
using System;
using UnityEngine;

namespace Game.Initializators
{
    public class BootstrapperMechanicsLvl : MonoBehaviour
    {
        [SerializeField] Vehicle startupVehicle;
        [SerializeField] VehicleReplacer vehicleReplacer;

        private void Start()
        {
            SetStartupVehicle();
        }

        private void SetStartupVehicle()
        {
            vehicleReplacer.Replace(startupVehicle);
        }
    }
}
