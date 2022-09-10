using Game.PlayerControls;
using Game.Transport.Movement;
using Game.Transport.Replacing;
using System;
using UnityEngine;
using Zenject;

namespace Game.Installers
{
    public class VehicleSystemsInstaller : MonoInstaller
    {
        [SerializeField] VehicleReplacer vehicleReplacer;
        [SerializeField] VehicleControl vehicleControl;
        [SerializeField] VehicleMover vehicleMover;
        public override void InstallBindings()
        {
            BindVehicleReplacer();
        }

        private void BindVehicleReplacer()
        {

        }
    }
}