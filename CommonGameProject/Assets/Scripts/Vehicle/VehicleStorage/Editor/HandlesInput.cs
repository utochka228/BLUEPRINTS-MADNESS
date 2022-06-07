using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace Vehicle.Storage.CellsEditorCreator
{
    public class HandlesInput
    {
        private Vector3 sceneMousePosition;
        public static void ProcessInput(EditorSceneCellsCreator cellsDrawer, Event guiEvent)
        {
            ProcessMousePosition(guiEvent.mousePosition, cellsDrawer.WireHeightInScene);
            if (guiEvent.type == EventType.MouseMove)
            {
                UpdateMouseOverSelection(cellsDrawer);
            }
        }
        private static void ProcessMousePosition(Vector2 mousePosition, float drawPlaneHeight)
        {
            Ray mouseRay = HandleUtility.GUIPointToWorldRay(mousePosition);
            float dstToDrawPlane = (drawPlaneHeight - mouseRay.origin.y) / mouseRay.direction.y;
            sceneMousePosition = mouseRay.GetPoint(dstToDrawPlane);
        }
        private static void UpdateMouseOverSelection(EditorSceneCellsCreator cellsDrawer)
        {
            var rowLenth = cellsDrawer.temporaryCellsWire.RowLength;
            var columnLenth = cellsDrawer.temporaryCellsWire.ColumnLength;
            for (int x = 0; x < rowLenth; x++)
            {
                for (int y = 0; y < columnLenth; y++)
                {
                    var cell = cellsDrawer.temporaryCellsWire[x, y];
                    var square = cell.verts[0] + cell.verts[1] + cell.verts[2] + cell.verts[3];
                    if(sceneMousePosition)
                }
            }
        }
    }
}
