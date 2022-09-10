using Game.Transport;
using Game.Transport.Replacing;
using System;
using UnityEngine;
using Zenject;

namespace Game.Installers
{
    public class LevelBootInstaller : MonoInstaller
    {
        [SerializeField] Vehicle startVehicle;
        [SerializeField] VehicleReplacer vehicleReplacer;
        public override void InstallBindings()
        {
            BindStartVehicle();
        }

        private void BindStartVehicle()
        {
            
        }
    }
}