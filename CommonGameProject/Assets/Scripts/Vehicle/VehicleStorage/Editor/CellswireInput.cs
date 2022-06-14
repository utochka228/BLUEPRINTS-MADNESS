using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using Utils;
using static Utils.PolygonUtils;

namespace Vehicle.Storage.CellsEditorCreator
{
    public class CellswireInput : HandlesInput
    {
        public override void ProcessInput(EditorCellsCreator cellsDrawer, Event _guiEvent)
        {
            guiEvent = _guiEvent;
            
            if (guiEvent.type == EventType.MouseMove)
            {
                UpdateMouseOverSelection();
            }
        }
        
        private void UpdateMouseOverSelection()
        {
            EditorCellsCreator cellsCreator = EditorCellsCreator.instance;
            var rowLenth = cellsCreator.temporaryCellsWire.RowLength;
            var columnLenth = cellsCreator.temporaryCellsWire.ColumnLength;

            Vector2Int coords = new Vector2Int(-1, -1);
            bool found = false;

            for (int x = 0; x < rowLenth; x++)
            {
                for (int y = 0; y < columnLenth; y++)
                {
                    var cell = cellsCreator.temporaryCellsWire[x, y];
                    var verts = EditorVerticesUtils.GetVertices(new DrawingCellsParams(cellsCreator, new Vector2Int(x, y)));
                    var points = new Point[] {
                        new Point(verts[0].x, verts[0].z),
                        new Point(verts[1].x, verts[1].z),
                        new Point(verts[2].x, verts[2].z),
                        new Point(verts[3].x, verts[3].z)
                    };
                    if (isInside(points, 4, new Point(sceneMousePosition.x, sceneMousePosition.z)))
                    {
                        coords = new Vector2Int(x, y);
                        found = true;
                        break;
                    }
                }
                if (found)
                    break;
            }
            if (coords != CellsWireHandler.selectionInfo.Coords)
            {
                CellsWireHandler.selectionInfo.Coords = coords;
                CellsWireHandler.selectionInfo.isHovered = true;

                cellsCreator.needsRepaint = true;
            }
        }
    }
}
