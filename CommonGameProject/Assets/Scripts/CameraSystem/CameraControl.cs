using Vehicle;
using Vehicle.ActionsOnVehicle;
using Cinemachine;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CameraSystem
{
    public enum CameraStateModes
    {
        TargetFixed, FreeLook
    }
    public partial class CameraControl : MonoBehaviour
    {
        public static CameraControl i;
        [SerializeField] CinemachineVirtualCamera virtualCamera;

        public CameraStateModes CurrentCameraMode { get; private set; }

        public delegate void CameraStateMode(CameraStateModes oldState, CameraStateModes newState);
        public static event CameraStateMode OnCameraStateModeChanged;

        private Car CurrentCarTarget;
        private void Awake()
        {
            i = this;
        }

        private void OnEnable()
        {
            CarsReplaceController.OnCarReplaced += SetNewCarTarget;
            OnCameraStateModeChanged += SetCameraBehaviour;
        }

        private void OnDisable()
        {
            CarsReplaceController.OnCarReplaced -= SetNewCarTarget;
            OnCameraStateModeChanged -= SetCameraBehaviour;
        }

        private void Start()
        {
            CurrentCameraMode = CameraStateModes.FreeLook;
        }

        private void Update()
        {
            Move();
            Rotate();
        }

        private void SetCameraBehaviour(CameraStateModes oldState, CameraStateModes newState)
        {
            
        }

        private void SetNewCarTarget(Car newCar)
        {
            CurrentCarTarget = newCar;
            virtualCamera.Follow = newCar.transform;
        }

        public static void ChangeCameraState(CameraStateModes newState)
        {
            if(i == null)
            {
                Debug.LogError("Camera singleton is null!");
                return;
            }
            var oldCameraState = i.CurrentCameraMode;
            i.CurrentCameraMode = newState;
            OnCameraStateModeChanged?.Invoke(oldCameraState, newState);
        }
    }
}
