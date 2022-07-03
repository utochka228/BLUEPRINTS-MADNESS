using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.UIElements;
using Utils;

namespace Vehicle.Storage.CellsEditorCreator
{
    [CustomEditor(typeof(SceneViewWireMono))]
    public class SceneViewWire : Editor
    {
        public static SceneViewWireMono sceneViewWireMono;
        public static bool drawWire;
        static WireSettings wireSettings;

        private void OnSceneGUI()
        {
            DrawWire();

            var pos = wireSettings.TargetVehicle.TransformPoint(wireSettings.instance.m_localOffsetFromZero);
            var newPos = Handles.PositionHandle(pos, Quaternion.identity);
            wireSettings.instance.m_localOffsetFromZero = wireSettings.TargetVehicle.InverseTransformPoint(newPos);
        }

        public override VisualElement CreateInspectorGUI()
        {
            VisualElement myInspector = new VisualElement();
            InspectorElement.FillDefaultInspector(myInspector, serializedObject, this);

            Button backButton = new Button(() => {
                Selection.activeObject = wireSettings.instance;
            });
            backButton.text = "Back to Storage";
            myInspector.Add(backButton);

            var cellsUnitSize = new FloatField("Cells unit size");
            cellsUnitSize.Bind(new SerializedObject(wireSettings.instance));
            cellsUnitSize.bindingPath = "cell_unit_size";

            myInspector.Add(cellsUnitSize);

            return myInspector;
        }

        public static void SetupWire(WireSettings settings) {
            if (sceneViewWireMono == null)
            {
                var loaded = AssetDatabase.LoadAssetAtPath<GameObject>("Assets/Scripts/Vehicle/VehicleStorage/Editor/InspectorStorage/SceneViewWire.prefab");
                sceneViewWireMono = Instantiate(loaded).GetComponent<SceneViewWireMono>();
            }
            wireSettings = settings;
        }

        public void DrawWire()
        {
            if (drawWire == false)
                return;

            for (int x = 0; x < wireSettings.cells.GetLength(0); x++)
            {
                for (int y = 0; y < wireSettings.cells.GetLength(1); y++)
                {
                    var cell = wireSettings.cells[x, y];
                    Color fillColor = ColorScheme.Scheme.CellNotExistFill;
                    if (cell.exist)
                        fillColor = ColorScheme.Scheme.CellExistFill;
                    DrawCell(new Vector2Int(x, y), fillColor);
                }
            }
        }

        private static void DrawCell(Vector2Int coords, Color fillColor)
        {
            var verts = EditorVerticesUtils.GetVertices(new DrawingCellsParams()
            {
                cells_unit_size = wireSettings.instance.cell_unit_size,
                coords = coords,
                offsetFromZeroPoint = wireSettings.instance.m_localOffsetFromZero,
                targetVehicle = wireSettings.TargetVehicle
            });

            Color fillerColor = fillColor;
        
            Handles.DrawSolidRectangleWithOutline(verts, fillerColor, ColorScheme.Scheme.CellBorder);
        }
    }

    public struct WireSettings
    {
        public Transform TargetVehicle;
        public Cell[,] cells;
        public VehicleStorageInstance instance;
    }
}
