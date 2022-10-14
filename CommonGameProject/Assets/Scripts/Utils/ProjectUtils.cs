using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    public static class ProjectUtils
    {
        public static bool IsMobilePlatform()
        {
#if UNITY_EDITOR
            return false;
#endif
#if UNITY_ANDROID && !UNITY_EDITOR
            return true;
#endif
        }
    }
}
