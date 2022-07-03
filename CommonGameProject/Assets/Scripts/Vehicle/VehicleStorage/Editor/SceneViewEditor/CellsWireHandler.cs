using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using Utils;

namespace Vehicle.Storage.CellsEditorCreator
{
    public class CellsWireHandler : EditorDrawerBase
    {
        public static SelectionInfo selectionInfo = new SelectionInfo();
        public static void DrawCellsWire()
        {
            if (EditorInstance.temporaryCellsWire == null)
                return;

            for (int x = 0; x < EditorInstance.temporaryCellsWire.RowLength; x++)
            {
                for (int y = 0; y < EditorInstance.temporaryCellsWire.ColumnLength; y++)
                {
                    var wire_cell = EditorInstance.temporaryCellsWire[x, y];

                    var fillColor = wire_cell.isExist ? ColorScheme.Scheme.CellExistFill : ColorScheme.Scheme.CellNotExistFill;
                    DrawCell(new Vector2Int(x, y), fillColor);
                }
            }
        }

        private static void DrawCell(Vector2Int coords, Color fillColor)
        {
            var verts = EditorVerticesUtils.GetVertices(new DrawingCellsParams(EditorInstance, coords));

            Color fillerColor = fillColor;
            if (coords == selectionInfo.Coords)
            {
                if (selectionInfo.isHovered)
                    fillerColor = ColorScheme.Scheme.CellHovered;
                if (selectionInfo.Selected)
                    fillerColor = ColorScheme.Scheme.CellSelected;
            }
            Handles.DrawSolidRectangleWithOutline(verts, fillerColor, ColorScheme.Scheme.CellBorder);
        }
        public static Vector3 GetPosByCoords(Vector2Int coords)
        {
            var point = new Vector3(EditorInstance.CELLS_UNIT_SIZE * (2 * coords.x + 1), 0f, EditorInstance.CELLS_UNIT_SIZE * (2 * coords.y + 1));
            var resultPos = EditorInstance.StorageCreator.targetVehicle.transform.TransformPoint(point);
            return resultPos;
        }
        public class SelectionInfo
        {
            public Vector2Int Coords = new Vector2Int(-1, -1);
            public bool isHovered;
            public bool Selected;
        }
    }
}
