using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.CameraSystem
{
    public partial class CameraControl
    {
        float verticalMouse;
        float horizontalMouse;
        [SerializeField] float moveSpeed = 5f;
        private void Move()
        {
#if UNITY_EDITOR
                //horizontalMouse = Input.GetAxisRaw("MouseX");
                //verticalMouse = Input.GetAxisRaw("MouseY");

                //Vector3 moveVector = new Vector3(horizontalMouse *);
                //virtualCamera.transform.position += new Vector3(,0f, );
#endif
        }
    }
}
