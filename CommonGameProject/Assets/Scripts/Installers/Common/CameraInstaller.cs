using Game.CameraSystem;
using UnityEngine;
using Zenject;

namespace Game.Installers
{
    public class CameraInstaller : MonoInstaller
    {
        [SerializeField] CameraControl cameraControl;
        public override void InstallBindings()
        {
            BindCameraSystem();
        }

        private void BindCameraSystem()
        {
            Container
                .Bind<CameraControl>()
                .FromInstance(cameraControl)
                .AsSingle();
        }
    }
}