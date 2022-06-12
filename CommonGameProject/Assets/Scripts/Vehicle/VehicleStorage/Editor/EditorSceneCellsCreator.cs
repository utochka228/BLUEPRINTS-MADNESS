using System;
using UnityEditor;
using UnityEngine;
using Utils;
using Utils.Convertor;
using Vehicle.Storage.Data;

namespace Vehicle.Storage.CellsEditorCreator
{
    [CustomEditor(typeof(CellsStorageCreator))]
    public class EditorSceneCellsCreator : Editor
    {
        public CellsStorageCreator StorageCreator;
        public CellsWire temporaryCellsWire;
        public Vector3 offsetFromZeroPoint;
        public float WireHeightInScene => (StorageCreator.targetVehicle.transform.TransformPoint(Vector3.zero) + offsetFromZeroPoint).y;

        bool needsRepaint;
        public float CELLS_UNIT_SIZE => StorageCreator.CELLS_UNIT_SIZE;

        private void OnEnable()
        {
            StorageCreator = target as CellsStorageCreator;
            EditorDrawerBase.EditorInstance = this;
        }
        private void OnSceneGUI()
        {
            if (EditorDrawerBase.EditorInstance == null)
                EditorDrawerBase.EditorInstance = this;

            Event guiEvent = Event.current;

            if (StorageCreator == null)
                return;
            if (StorageCreator.targetVehicle == null)
                return;
            if (StorageCreator.targetVehicleStorage == null)
                return;

            if (temporaryCellsWire == null)
                CreateNewCellsWire();

            if(guiEvent.type == EventType.Repaint)
            {
                DrawCellsWire();
                DrawWireHandles();
                needsRepaint = false;
            }
            else if(guiEvent.type == EventType.Layout)
            {
                HandleUtility.AddDefaultControl(GUIUtility.GetControlID(FocusType.Passive));
            }
            else
            {
                HandlesInput.ProcessInput(this, guiEvent);
                if (needsRepaint)
                {
                    HandleUtility.Repaint();
                }
            }
        }

        private void DrawWireHandles()
        {
            ManipulatorsDrawer.DrawHandleSpheres(new DrawingWireParams(this));
            ProcessPivotOffset();
        }

        private void ProcessPivotOffset()
        {
            offsetFromZeroPoint = StorageCreator.targetVehicle.transform.InverseTransformPoint(StorageCreator.transform.position);
        }

        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();
            if (GUILayout.Button("Save data"))
            {
                SaveData();
            }
        }

        private void DrawCellsWire()
        {
            if (temporaryCellsWire == null)
                return;

            for (int x = 0; x < temporaryCellsWire.RowLength; x++)
            {
                for (int y = 0; y < temporaryCellsWire.ColumnLength; y++)
                {
                    var wire_cell = temporaryCellsWire[x, y];
                    DrawCell(new Vector2(x, y), wire_cell.GetColor());
                }
            }
        }

        private void DrawCell(Vector2 coords, Color fillColor)
        {
            var verts = EditorVerticesUtils.GetVertices(coords, StorageCreator.targetVehicle.transform, CELLS_UNIT_SIZE, offsetFromZeroPoint);

            Vector3 plane = Vector3.zero;
            for (int i = 0; i < verts.Length; i++)
            {
                Handles.color = Color.black;
                Handles.DrawLine(verts[i], verts[(i + 1) % verts.Length], 2f);
                plane += verts[i];
            }
            //Handles.DotHandleCap(, new Vector3(plane.x, verts[0].y, plane.z), Quaternion.identity, CELLS_UNIT_SIZE, EventType.Repaint);
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
                        temporaryCellsWire[x, y] = new WireCell() { 
                            isExist = false, 
                            verts = EditorVerticesUtils.GetVertices(new Vector2(x, y), 
                            StorageCreator.targetVehicle.transform, CELLS_UNIT_SIZE, offsetFromZeroPoint), 
                            cellColor = Color.grey 
                        };
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
