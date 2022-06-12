using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using Utils;
using static Utils.PolygonUtils;

namespace Vehicle.Storage.CellsEditorCreator
{
    public class HandlesInput
    {
        static Vector3 sceneMousePosition;
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
                    var verts = EditorVerticesUtils.GetVertices(new DrawingCellsParams(cellsDrawer, new Vector2Int(x, y)));
                    var points = new Point[] { 
                        new Point(verts[0].x, verts[0].z),
                        new Point(verts[1].x, verts[1].z),
                        new Point(verts[2].x, verts[2].z),
                        new Point(verts[3].x, verts[3].z)
                    };
                    if (isInside(points, 4, new Point(sceneMousePosition.x, sceneMousePosition.z)))
                    {

                    }
                }
            }
        }
    }
}
