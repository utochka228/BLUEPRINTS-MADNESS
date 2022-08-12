using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutoutObject : MonoBehaviour
{
    [SerializeField] Transform targetObject;

    [SerializeField] LayerMask obstacleMask;

    private Camera mainCamera;

    private void Awake()
    {
        mainCamera = transform.GetComponent<Camera>();
    }

    void Update()
    {
        CutoutTargetObject();
    }

    private void CutoutTargetObject()
    {
        Vector2 cutoutPos = mainCamera.WorldToViewportPoint(targetObject.position);
        cutoutPos.y /= (Screen.width / Screen.height);

        Vector3 offset = targetObject.position - transform.position;
        RaycastHit[] hitObjects = Physics.RaycastAll(transform.position, offset, offset.magnitude, obstacleMask);

        for (int i = 0; i < hitObjects.Length; ++i)
        {
            Material[] materials = hitObjects[i].transform.GetComponent<Renderer>().materials;

            for (int m = 0; m < materials.Length; ++m)
            {
                materials[m].SetVector("_Cutout_Pos", cutoutPos);
                materials[m].SetFloat("_Cutout_Size", 0.18f);
                materials[m].SetFloat("_Falloff_Size", 0.18f);
            }
        }
    }
}
