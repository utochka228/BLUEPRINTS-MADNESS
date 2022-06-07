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
            var worldPos = wireParams.targetCenterWorldPos;
            var CELLS_UNIT_SIZE = wireParams.cells_unit_size;

            var verts = new Vector3[]
            {
                new Vector3(worldPos.x - CELLS_UNIT_SIZE / 2 - (CELLS_UNIT_SIZE * rowLength) / 2 , worldPos.y, worldPos.z - CELLS_UNIT_SIZE / 2 - (CELLS_UNIT_SIZE * columnLength) / 2) + wireParams.offsetFromZeroPoint,
                new Vector3(worldPos.x - CELLS_UNIT_SIZE / 2 - (CELLS_UNIT_SIZE * rowLength) / 2, worldPos.y, worldPos.z + CELLS_UNIT_SIZE / 2 + (CELLS_UNIT_SIZE * columnLength) / 2) + wireParams.offsetFromZeroPoint,
                new Vector3(worldPos.x + CELLS_UNIT_SIZE / 2 + (CELLS_UNIT_SIZE * rowLength) / 2, worldPos.y, worldPos.z + CELLS_UNIT_SIZE / 2 + (CELLS_UNIT_SIZE * columnLength) / 2) + wireParams.offsetFromZeroPoint,
                new Vector3(worldPos.x + CELLS_UNIT_SIZE / 2 + (CELLS_UNIT_SIZE * rowLength) / 2, worldPos.y, worldPos.z - CELLS_UNIT_SIZE / 2 - (CELLS_UNIT_SIZE * columnLength) / 2) + wireParams.offsetFromZeroPoint
            };

            float size = SphereHandlesSize * CELLS_UNIT_SIZE;

            Handles.color = Color.red;
            Vector3 snap = Vector3.one * CELLS_UNIT_SIZE;

            EditorGUI.BeginChangeCheck();
            Vector3 hPos0 = Handles.FreeMoveHandle(verts[0], Quaternion.identity, size, snap, Handles.SphereHandleCap);
            if (EditorGUI.EndChangeCheck())
            {
                float offset = (hPos0.x - verts[0].x) / 2f;
            }

            EditorGUI.BeginChangeCheck();
            Vector3 hPos1 = Handles.FreeMoveHandle(verts[1], Quaternion.identity, size, snap, Handles.SphereHandleCap);
            if (EditorGUI.EndChangeCheck())
            {
                float offset = (hPos1.x - verts[1].x) / 2f;

            }
            EditorGUI.BeginChangeCheck();
            Vector3 hPos2 = Handles.FreeMoveHandle(verts[2], Quaternion.identity, size, snap, Handles.SphereHandleCap);
            if (EditorGUI.EndChangeCheck())
            {
                float offset = (hPos2.y - verts[2].y) / 2f;
            }
            EditorGUI.BeginChangeCheck();
            Vector3 hPos3 = Handles.FreeMoveHandle(verts[3], Quaternion.identity, size, snap, Handles.SphereHandleCap);
            if (EditorGUI.EndChangeCheck())
            {
                float offset = (hPos3.y - verts[3].y) / 2f;
            }
        }
    }
}
