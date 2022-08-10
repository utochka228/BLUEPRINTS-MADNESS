using Game.ProjectSettings;
using UnityEngine;

namespace Game.Initialization
{
    public static class Bootstrapper
    {
        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
        public static void Execute()
        {
            var loadedSystems = UnityEngine.Resources.Load(Pathes.SystemsResourcesPath);

            if (loadedSystems == null)
                throw new System.NullReferenceException("Systems to spawn wasn't found! Can't load it.");

            var systems = Object.Instantiate(loadedSystems);
            Object.DontDestroyOnLoad(systems);

            Debug.Log("Systems were loaded!");
        }
    }
}
