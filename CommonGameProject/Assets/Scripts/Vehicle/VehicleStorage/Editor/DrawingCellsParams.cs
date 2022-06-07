using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Vehicle.Storage.CellsEditorCreator
{
    public struct DrawingCellsParams
    {
        public float cells_unit_size;
        public Vector3 offsetFromZeroPoint;
        public Transform targetVehicle;
        public Vector2 coords;

        public DrawingCellsParams(EditorSceneCellsCreator instance, Vector2 coords)
        {
            cells_unit_size = instance.CELLS_UNIT_SIZE;
            offsetFromZeroPoint = instance.offsetFromZeroPoint;
            targetVehicle = instance.StorageCreator.targetVehicle.transform;
            this.coords = coords;
        }
    }
    public struct DrawingWireParams
    {
        public int RowLength;
        public int ColumnLength;
        public Vector3 targetCenterWorldPos;
        public float cells_unit_size;
        public Vector3 offsetFromZeroPoint;

        public DrawingWireParams(EditorSceneCellsCreator instance)
        {
            cells_unit_size = instance.CELLS_UNIT_SIZE;
            RowLength = instance.temporaryCellsWire.RowLength;
            ColumnLength = instance.temporaryCellsWire.ColumnLength;
            targetCenterWorldPos = instance.StorageCreator.targetVehicle.transform.TransformPoint(Vector3.zero);
            offsetFromZeroPoint = instance.offsetFromZeroPoint;
        }
    }
}
