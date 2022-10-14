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
        public override void InstallBindings()
        {
            BindVehicleReplacer();
            BindVehicleControl();
        }

        private void BindVehicleControl()
        {
            Container
                .Bind<VehicleControl>()
                .FromInstance(vehicleControl)
                .AsSingle();
        }

        private void BindVehicleReplacer()
        {
            Container
                .Bind<VehicleReplacer>()
                .FromInstance(vehicleReplacer)
                .AsSingle();
        }
    }
}