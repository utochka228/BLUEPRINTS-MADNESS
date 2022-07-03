using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace Vehicle.Storage.CellsEditorCreator
{
    public class ColorScheme : ScriptableObject
    {
        static ColorScheme scheme;

        [Header("Cells")]
        public Color CellExistFill;
        public Color CellNotExistFill;
        public Color CellBorder;
        public Color CellHovered;
        public Color CellSelected;

        [Header("Cells")]
        public Color ManipulatorColor;
        public Color ManipulatorHovered;
        public Color ManipulatorSelected;

        static string path = "Assets/Scripts/Vehicle/VehicleStorage/Editor/";
        public static ColorScheme CreateAsset()
        {
            var asset = AssetDatabase.LoadAssetAtPath<ColorScheme>(path + "ColorScheme.asset");
            if (asset != null)
                return asset;

            var instance = ScriptableObject.CreateInstance<ColorScheme>();
            AssetDatabase.CreateAsset(instance, path + "ColorScheme.asset");
            return instance;
        }
        public static ColorScheme Scheme
        {
            get { 
                if(scheme == null)
                    scheme = AssetDatabase.LoadAssetAtPath<ColorScheme>(path + "ColorScheme.asset");
                return scheme;
            }
        }
    }
}
