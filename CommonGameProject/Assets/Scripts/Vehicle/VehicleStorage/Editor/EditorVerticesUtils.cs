using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Utils
{
    public class VerticesUtils
    {
        public static Vector3[] GetVertices(Vector2 coords, Transform targetVehicle, float CELLS_UNIT_SIZE, Vector3 zeroPointOffset)
        {
            var worldPos = targetVehicle.TransformPoint(Vector3.zero);
            var verts = new Vector3[]
            {
            new Vector3(worldPos.x - CELLS_UNIT_SIZE * coords.x, worldPos.y, worldPos.z - CELLS_UNIT_SIZE * coords.y) + zeroPointOffset,
            new Vector3(worldPos.x - CELLS_UNIT_SIZE * coords.x, worldPos.y, worldPos.z + CELLS_UNIT_SIZE * coords.y) + zeroPointOffset,
            new Vector3(worldPos.x + CELLS_UNIT_SIZE * coords.x, worldPos.y, worldPos.z + CELLS_UNIT_SIZE * coords.y) + zeroPointOffset,
            new Vector3(worldPos.x + CELLS_UNIT_SIZE * coords.x, worldPos.y, worldPos.z - CELLS_UNIT_SIZE * coords.y) + zeroPointOffset
            };
            return verts;
        }
    }
}
