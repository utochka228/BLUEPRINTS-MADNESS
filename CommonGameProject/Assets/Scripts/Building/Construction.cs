using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Building
{
    public class Construction : MonoBehaviour
    {
        BuildDirector levelBuildDirector;

        public void SetDirector(BuildDirector director)
        {
            levelBuildDirector = director;
        }
    }
}
