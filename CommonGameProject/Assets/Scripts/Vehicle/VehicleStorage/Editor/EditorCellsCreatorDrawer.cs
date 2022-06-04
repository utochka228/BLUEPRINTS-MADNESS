using System;
using UnityEditor;
using UnityEngine;
using Utils.Convertor;
using Vehicle.Storage.Data;

namespace Vehicle.Storage.CellsEditorCreator
{
    [CustomEditor(typeof(CellsStorageCreator))]
    public class EditorCellsCreatorDrawer : Editor
    {
        CellsStorageCreator StorageCreator;
        CellsWire temporaryCellsWire;
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
            DrawWireHandles();

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
        const float CubeHandlesSize = 0.5f;
        private void DrawWireHandles()
        {
            DrawHandleCubes();
            DrawPivotOffset();
        }

        private void DrawPivotOffset()
        {
            offsetFromZeroPoint = StorageCreator.targetVehicle.transform.InverseTransformPoint(StorageCreator.transform.position);
        }

        private void DrawHandleCubes()
        {
            var rowLength = temporaryCellsWire.RowLength;
            var columnLength = temporaryCellsWire.ColumnLength;
            var worldPos = StorageCreator.targetVehicle.transform.TransformPoint(Vector3.zero);
            var verts = new Vector3[]
            {
            new Vector3(worldPos.x - CELLS_UNIT_SIZE / 2 - (CELLS_UNIT_SIZE * rowLength) / 2 , worldPos.y, worldPos.z - CELLS_UNIT_SIZE / 2 - (CELLS_UNIT_SIZE * columnLength) / 2) + offsetFromZeroPoint,
            new Vector3(worldPos.x - CELLS_UNIT_SIZE / 2 - (CELLS_UNIT_SIZE * rowLength) / 2, worldPos.y, worldPos.z + CELLS_UNIT_SIZE / 2 + (CELLS_UNIT_SIZE * columnLength) / 2) + offsetFromZeroPoint,
            new Vector3(worldPos.x + CELLS_UNIT_SIZE / 2 + (CELLS_UNIT_SIZE * rowLength) / 2, worldPos.y, worldPos.z + CELLS_UNIT_SIZE / 2 + (CELLS_UNIT_SIZE * columnLength) / 2) + offsetFromZeroPoint,
            new Vector3(worldPos.x + CELLS_UNIT_SIZE / 2 + (CELLS_UNIT_SIZE * rowLength) / 2, worldPos.y, worldPos.z - CELLS_UNIT_SIZE / 2 - (CELLS_UNIT_SIZE * columnLength) / 2) + offsetFromZeroPoint
            };

            float size = CubeHandlesSize * CELLS_UNIT_SIZE;

            Handles.color = Color.red;
            //Handles.CubeHandleCap(
            //    0,
            //    verts[0],
            //    Quaternion.identity,
            //    CubeHandlesSize * CELLS_UNIT_SIZE,
            //    EventType.Repaint
            //);
            //Handles.CubeHandleCap(
            //    0,
            //    verts[1],
            //    Quaternion.identity,
            //    CubeHandlesSize * CELLS_UNIT_SIZE,
            //    EventType.Repaint
            //);
            //Handles.CubeHandleCap(
            //    0,
            //    verts[2],
            //    Quaternion.identity,
            //    CubeHandlesSize * CELLS_UNIT_SIZE,
            //    EventType.Repaint
            //);
            //Handles.CubeHandleCap(
            //    0,
            //    verts[3],
            //    Quaternion.identity,
            //    CubeHandlesSize * CELLS_UNIT_SIZE,
            //    EventType.Repaint
            //);

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

        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();
            if (GUILayout.Button("Save data"))
            {
                SaveData();
            }
        }

        private float CELLS_UNIT_SIZE => StorageCreator.CELLS_UNIT_SIZE;
        private void DrawCellsWire()
        {
            if (temporaryCellsWire == null)
                return;

            for (int x = 0; x < temporaryCellsWire.RowLength; x++)
            {
                for (int y = 0; y < temporaryCellsWire.ColumnLength; y++)
                {
                    var cell = temporaryCellsWire[x, y];
                    Color fillColor;
                    if (cell.exist)
                    {
                        fillColor = Color.grey;
                        fillColor.a = 0.5f;
                    }
                    else
                    {
                        fillColor = Color.grey;
                        fillColor.a = 0.5f;
                    }
                    DrawCell(x, y, fillColor);
                }
            }
        }

        private void DrawCell(int x, int y, Color fillColor)
        {
            var worldPos = StorageCreator.targetVehicle.transform.TransformPoint(Vector3.zero);
            var verts = new Vector3[]
            {
                new Vector3(worldPos.x - CELLS_UNIT_SIZE * x, worldPos.y, worldPos.z - CELLS_UNIT_SIZE * y) + offsetFromZeroPoint,
                new Vector3(worldPos.x - CELLS_UNIT_SIZE * x, worldPos.y, worldPos.z + CELLS_UNIT_SIZE * y) + offsetFromZeroPoint,
                new Vector3(worldPos.x + CELLS_UNIT_SIZE * x, worldPos.y, worldPos.z + CELLS_UNIT_SIZE * y) + offsetFromZeroPoint,
                new Vector3(worldPos.x + CELLS_UNIT_SIZE * x, worldPos.y, worldPos.z - CELLS_UNIT_SIZE * y) + offsetFromZeroPoint
            };
            
            Handles.DrawSolidRectangleWithOutline(verts, fillColor, Color.black);
        }

        private void CreateNewCellsWire()
        {
            if (StorageCreator.targetVehicleStorage.cellsStruct.cells == null)
            {
                temporaryCellsWire = new CellsWire(3, 3);
                for (int x = 0; x < 3; x++)
                {
                    for (int y = 0; y < 3; y++)
                    {
                        temporaryCellsWire[x, y] = new Cell() { exist = true, localPosition = Vector3.zero };
                    }
                }
                offsetFromZeroPoint = Vector3.zero;    
            }
            else // Form datawire based on stored cells
            {
                var cellsStruct = StorageCreator.targetVehicleStorage.cellsStruct;
                temporaryCellsWire = TypesConverter<CellsWireStruct, CellsWire>.Convert(cellsStruct);
                offsetFromZeroPoint = StorageCreator.targetVehicleStorage.localOffsetFromZero;
            }
            StorageCreator.transform.position = StorageCreator.targetVehicle.transform.TransformPoint(offsetFromZeroPoint);
        }

        private void SaveData()
        {
            StorageCreator.targetVehicleStorage.cellsStruct = temporaryCellsWire.ConvertTo();
        }
    }
}
