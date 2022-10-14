using Game.Transport;
using Cinemachine;
using UnityEngine;

namespace Game.CameraSystem
{
    public enum CameraStateModes
    {
        TargetFixed, FreeLook
    }
    public partial class CameraControl : MonoBehaviour
    {
        [SerializeField] CinemachineVirtualCamera virtualCamera;

        public CameraStateModes CurrentCameraMode { get; private set; }

        public delegate void CameraStateMode(CameraStateModes oldState, CameraStateModes newState);
        public static event CameraStateMode OnCameraStateModeChanged;

        private Vehicle CurrentVehicleTarget;

        private void OnEnable()
        {
            //VehicleReplacer.OnVehicleReplaced += SetNewCarTarget;
            OnCameraStateModeChanged += SetCameraBehaviour;
        }

        private void OnDisable()
        {
            //VehicleReplacer.OnVehicleReplaced -= SetNewCarTarget;
            OnCameraStateModeChanged -= SetCameraBehaviour;
        }

        private void Start()
        {
            CurrentCameraMode = CameraStateModes.FreeLook;
        }

        private void Update()
        {
            Move();
        }

        private void SetCameraBehaviour(CameraStateModes oldState, CameraStateModes newState)
        {
            
        }

        public void SetNewVehicleTarget(Vehicle newVehicle)
        {
            CurrentVehicleTarget = newVehicle;
            virtualCamera.Follow = newVehicle.transform;
        }

        public void ChangeCameraState(CameraStateModes newState)
        {
            var oldCameraState = CurrentCameraMode;
            CurrentCameraMode = newState;
            OnCameraStateModeChanged?.Invoke(oldCameraState, newState);
        }
    }
}
