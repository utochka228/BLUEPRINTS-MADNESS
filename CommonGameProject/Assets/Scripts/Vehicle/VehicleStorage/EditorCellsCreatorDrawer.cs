using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace Vehicle.Storage.CellsCreator
{
    [CustomEditor(typeof(CellsStorageCreator))]
    public class EditorCellsCreatorDrawer : Editor
    {
        CellsStorageCreator StorageCreator;
        Cell[,] temporaryCellsWire;
        Vector3 offsetFromZeroPoint;

        private void OnEnable()
        {
            StorageCreator = target as CellsStorageCreator;
        }
        private void OnSceneGUI()
        {
            if (StorageCreator == null)
                return;
            if (StorageCreator.targetVehicle == null)
                return;
            if (StorageCreator.targetVehicleStorage == null)
                return;

            //if (StorageCreator.targetVehicleStorage.cells == null)
            //    CreateNewCellsWire();
            //else
            //    ProcessExistingCellsWire();

            DrawCellsWire();
        }
        static float CELLS_UNIT_SIZE => CellsStorageCreator.instance.CELLS_UNIT_SIZE;
        private void DrawCellsWire()
        {
            if (temporaryCellsWire == null)
                return;

            for (int x = 0; x < temporaryCellsWire.GetLength(0); x++)
            {
                for (int y = 0; y < temporaryCellsWire.GetLength(1); y++)
                {
                    var cell = temporaryCellsWire[x, y];
                    if (cell.exist)
                    {
                        var verts = new Vector3[]
                        {
                            new Vector3(cell.localPosition.x - CELLS_UNIT_SIZE, cell.localPosition.y, cell.localPosition.z - CELLS_UNIT_SIZE) + offsetFromZeroPoint,
                            new Vector3(cell.localPosition.x - CELLS_UNIT_SIZE, cell.localPosition.y, cell.localPosition.z + CELLS_UNIT_SIZE) + offsetFromZeroPoint,
                            new Vector3(cell.localPosition.x + CELLS_UNIT_SIZE, cell.localPosition.y, cell.localPosition.z + CELLS_UNIT_SIZE) + offsetFromZeroPoint,
                            new Vector3(cell.localPosition.x + CELLS_UNIT_SIZE, cell.localPosition.y, cell.localPosition.z - CELLS_UNIT_SIZE) + offsetFromZeroPoint
                        };
                        Handles.DrawSolidRectangleWithOutline(verts, Color.yellow, Color.black);
                    }
                }
            }
        }

        private void CreateNewCellsWire()
        {

        }

        private void ProcessExistingCellsWire()
        {

        }
    }
}
