using UnityEditor;
using UnityEngine;

namespace Vehicle.Storage.CellsEditorCreator
{
    public class ManipulatorsDrawer : EditorDrawerBase
    {
        const float SphereHandlesSize = 0.5f;

        public static void DrawHandleSpheres(DrawingWireParams wireParams)
        {
            var rowLength = wireParams.RowLength;
            var columnLength = wireParams.ColumnLength;
            var CELLS_UNIT_SIZE = wireParams.cells_unit_size;

            var pos_0 = CellsWireHandler.GetPosByCoords(new Vector2Int(0, 0));
            pos_0 -= new Vector3(CELLS_UNIT_SIZE, 0f, CELLS_UNIT_SIZE);
            var pos_1 = CellsWireHandler.GetPosByCoords(new Vector2Int(rowLength-1, columnLength-1));
            pos_1 += new Vector3(CELLS_UNIT_SIZE, 0f, CELLS_UNIT_SIZE);
            var pos_2 = CellsWireHandler.GetPosByCoords(new Vector2Int(rowLength-1, 0));
            pos_2 += new Vector3(CELLS_UNIT_SIZE, 0f, -CELLS_UNIT_SIZE);
            var pos_3 = CellsWireHandler.GetPosByCoords(new Vector2Int(0, columnLength-1));
            pos_3 += new Vector3(-CELLS_UNIT_SIZE, 0f, CELLS_UNIT_SIZE);
            var verts = new Vector3[]{pos_0, pos_1, pos_2, pos_3};

            DrawVisualSpheres(CELLS_UNIT_SIZE, verts);
        }

        private static void DrawVisualSpheres(float CELLS_UNIT_SIZE, Vector3[] verts)
        {
            float size = SphereHandlesSize * CELLS_UNIT_SIZE;
            Handles.color = Color.red;
            Vector3 snap = Vector3.one * CELLS_UNIT_SIZE;

            for (int i = 0; i < 4; i++)
            {
                Handles.FreeMoveHandle(verts[i], Quaternion.identity, size, snap, Handles.SphereHandleCap);
            }
        }
    }
}
