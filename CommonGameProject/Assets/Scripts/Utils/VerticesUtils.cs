using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Utils.CellVertices
{
    public class VerticesUtils
    {
        public static Vector3[] GetVertices(DrawingCellsParams cellsParams)
        {
            var worldPos = cellsParams.targetVehicle.TransformPoint(Vector3.zero);
            var verts = new Vector3[]
            {
            new Vector3(worldPos.x - cellsParams.cells_unit_size * cellsParams.coords.x, worldPos.y, worldPos.z - cellsParams.cells_unit_size * cellsParams.coords.y) + cellsParams.offsetFromZeroPoint,
            new Vector3(worldPos.x - cellsParams.cells_unit_size * cellsParams.coords.x, worldPos.y, worldPos.z + cellsParams.cells_unit_size * cellsParams.coords.y) + cellsParams.offsetFromZeroPoint,
            new Vector3(worldPos.x + cellsParams.cells_unit_size * cellsParams.coords.x, worldPos.y, worldPos.z + cellsParams.cells_unit_size * cellsParams.coords.y) + cellsParams.offsetFromZeroPoint,
            new Vector3(worldPos.x + cellsParams.cells_unit_size * cellsParams.coords.x, worldPos.y, worldPos.z - cellsParams.cells_unit_size * cellsParams.coords.y) + cellsParams.offsetFromZeroPoint
            };
            return verts;
        }

    }
    public struct DrawingCellsParams
    {
        public float cells_unit_size;
        public Vector3 offsetFromZeroPoint;
        public Transform targetVehicle;
        public Vector2 coords;
        public Color fillColor;
    }
}
