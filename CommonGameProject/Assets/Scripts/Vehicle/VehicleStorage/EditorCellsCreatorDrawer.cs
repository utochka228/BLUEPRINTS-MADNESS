using GameDataUtils.DataWireClass;
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
        DataWire<Cell> temporaryCellsWire;
        Vector3 offsetFromZeroPoint;

        bool needsRepaint;

        private void OnEnable()
        {
            StorageCreator = target as CellsStorageCreator;
        }
        private void OnSceneGUI()
        {
            Event guiEvent = Event.current;

            if (StorageCreator == null)
                return;
            if (StorageCreator.targetVehicle == null)
                return;
            if (StorageCreator.targetVehicleStorage == null)
                return;

            if (temporaryCellsWire == null)
                CreateNewCellsWire();

            DrawCellsWire();

            if (needsRepaint)
            {
                HandleUtility.Repaint();
                needsRepaint = false;
            }

            if (guiEvent.type == EventType.Layout)
            {
                HandleUtility.AddDefaultControl(GUIUtility.GetControlID(FocusType.Passive));
            }
        }
        static float CELLS_UNIT_SIZE => CellsStorageCreator.instance.CELLS_UNIT_SIZE;
        private void DrawCellsWire()
        {
            if (temporaryCellsWire == null)
                return;

            for (int x = 0; x < temporaryCellsWire.RowLength; x++)
            {
                for (int y = 0; y < temporaryCellsWire.ColumnLength; y++)
                {
                    var cell = temporaryCellsWire[x, y];
                    if (cell.exist)
                    {
                        DrawCell(cell);
                    }
                }
            }
        }

        private void DrawCell(Cell cell)
        {
            var worldPos = StorageCreator.targetVehicle.transform.TransformPoint(cell.localPosition);
            var verts = new Vector3[]
            {
                new Vector3(worldPos.x - CELLS_UNIT_SIZE, worldPos.y, worldPos.z - CELLS_UNIT_SIZE) + offsetFromZeroPoint,
                new Vector3(worldPos.x - CELLS_UNIT_SIZE, worldPos.y, worldPos.z + CELLS_UNIT_SIZE) + offsetFromZeroPoint,
                new Vector3(worldPos.x + CELLS_UNIT_SIZE, worldPos.y, worldPos.z + CELLS_UNIT_SIZE) + offsetFromZeroPoint,
                new Vector3(worldPos.x + CELLS_UNIT_SIZE, worldPos.y, worldPos.z - CELLS_UNIT_SIZE) + offsetFromZeroPoint
            };
            Handles.DrawSolidRectangleWithOutline(verts, Color.yellow, Color.black);
        }

        private void CreateNewCellsWire()
        {
            if (StorageCreator.targetVehicleStorage.cells == null)
            {
                temporaryCellsWire = new DataWire<Cell>(1, 1);
                temporaryCellsWire[0, 0] = new Cell() { exist = true, localPosition = Vector3.zero };
            }
            //else // Form datawire based on stored cells
             //   temporaryCellsWire = StorageCreator.targetVehicleStorage.cells;
        }
    }
}
