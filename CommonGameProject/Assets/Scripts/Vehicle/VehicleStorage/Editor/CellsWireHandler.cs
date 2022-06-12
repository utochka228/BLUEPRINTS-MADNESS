using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using Utils;

namespace Vehicle.Storage.CellsEditorCreator
{
    public class CellsWireHandler : EditorDrawerBase
    {
        public static void DrawCellsWire()
        {
            if (EditorInstance.temporaryCellsWire == null)
                return;

            for (int x = 0; x < EditorInstance.temporaryCellsWire.RowLength; x++)
            {
                for (int y = 0; y < EditorInstance.temporaryCellsWire.ColumnLength; y++)
                {
                    var wire_cell = EditorInstance.temporaryCellsWire[x, y];
                    DrawCell(new Vector2Int(x, y), wire_cell.GetColor());
                }
            }
        }

        private static void DrawCell(Vector2Int coords, Color fillColor)
        {
            var verts = EditorVerticesUtils.GetVertices(new DrawingCellsParams(EditorInstance, coords));

            Color fillerColor = fillColor;

            Handles.DrawSolidRectangleWithOutline(verts, fillerColor, Color.black);
        }
        public static Vector3 GetPosByCoords(Vector2Int coords)
        {
            var point = new Vector3(EditorInstance.CELLS_UNIT_SIZE * (2 * coords.x + 1), 0f, EditorInstance.CELLS_UNIT_SIZE * (2 * coords.y + 1));
            var resultPos = EditorInstance.StorageCreator.targetVehicle.transform.TransformPoint(point);
            return resultPos;
        }
    }
}
