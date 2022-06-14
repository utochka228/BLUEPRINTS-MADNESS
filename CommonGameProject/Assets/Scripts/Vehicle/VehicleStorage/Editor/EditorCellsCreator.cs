using System;
using UnityEditor;
using UnityEngine;
using Utils;
using Utils.Convertor;
using Vehicle.Storage.Data;

namespace Vehicle.Storage.CellsEditorCreator
{
    [CustomEditor(typeof(CellsStorageCreator))]
    public class EditorCellsCreator : Editor
    {
        public static EditorCellsCreator instance;

        public ColorScheme ColorScheme;
        public CellsStorageCreator StorageCreator;
        public CellsWire temporaryCellsWire;
        public Vector3 offsetFromZeroPoint;
        public float WireHeightInScene => (StorageCreator.targetVehicle.transform.TransformPoint(Vector3.zero) + offsetFromZeroPoint).y;

        public bool needsRepaint;
        public float CELLS_UNIT_SIZE => StorageCreator.CELLS_UNIT_SIZE;

        HandlesInput[] inputClasses = new HandlesInput[] { new CellswireInput(), new ManipulatorsInput() };

        private void OnEnable()
        {
            EditorDrawerBase.EditorInstance = this;
            instance = this;

            StorageCreator = target as CellsStorageCreator;

            ColorScheme = ColorScheme.CreateAsset();
        }
        private void OnSceneGUI()
        {
            if (EditorDrawerBase.EditorInstance == null)
                EditorDrawerBase.EditorInstance = this;

            if (instance == null)
                instance = this;

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
                CellsWireHandler.DrawCellsWire();
                ManipulatorsDrawer.DrawHandleSpheres(new DrawingWireParams(this));
                needsRepaint = false;
            }
            else if(guiEvent.type == EventType.Layout)
            {
                HandleUtility.AddDefaultControl(GUIUtility.GetControlID(FocusType.Passive));
            }
            else
            {
                for (int i = 0; i < inputClasses.Length; i++)
                {
                    inputClasses[i].ProcessInput(this, guiEvent);
                }
                if (needsRepaint)
                {
                    HandleUtility.Repaint();
                }
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

        private void CreateNewCellsWire()
        {
            if (StorageCreator.targetVehicleStorage.cellsStruct.cells == null)
            {
                temporaryCellsWire = new CellsWire(5, 10);
                
                offsetFromZeroPoint = Vector3.zero;    
            }
            else // Form datawire based on stored cells
            {
                var cellsStruct = StorageCreator.targetVehicleStorage.cellsStruct;
                temporaryCellsWire = TypesConverter<CellsWireStruct, CellsWire>.Convert(cellsStruct);
                offsetFromZeroPoint = StorageCreator.targetVehicleStorage.localOffsetFromZero;
            }
        }

        private void SaveData()
        {
            StorageCreator.targetVehicleStorage.cellsStruct = temporaryCellsWire.ConvertTo();
        }
    }
}
