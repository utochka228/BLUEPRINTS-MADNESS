using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Vehicle.Storage.CellsEditorCreator
{
    public class SceneViewWireMono : MonoBehaviour
    {
        public static SceneViewWireMono instance;
        private void Awake()
        {
            if (instance == null)
                instance = this;
            else
            {
                Destroy(instance);
                instance = this;
            }
        }
    }
}
