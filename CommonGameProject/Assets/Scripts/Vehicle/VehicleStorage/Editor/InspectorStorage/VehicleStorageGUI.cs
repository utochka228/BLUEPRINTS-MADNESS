using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEditor.UIElements;
using UnityEngine.UIElements;
using Vehicle.Storage;
using System;
using System.Linq;
using Vehicle.Storage.CellsEditorCreator;

[CustomEditor(typeof(VehicleStorageInstance))]
public class VehicleStorageGUI : Editor
{
    VisualElement myInspector;
    VehicleStorageInstance instance;

    VisualTreeAsset _rowElement;
    VisualTreeAsset _cellButton;

    bool previewEnabled;
    ObjectField targetVehicle;
    static GameObject lastSelectedVehicle;
    bool skipFirstCallbackTrigger;
    public override VisualElement CreateInspectorGUI()
    {
        myInspector = new VisualElement();
        instance = target as VehicleStorageInstance;

        InspectorElement.FillDefaultInspector(myInspector, serializedObject, this);

        var visualTreeAsset = AssetDatabase.LoadAssetAtPath<VisualTreeAsset>("Assets/UI Toolkit Projects/VehicleStorageGUI.uxml");
        var vehicle_storage_gui = visualTreeAsset.CloneTree();

        myInspector.Add(vehicle_storage_gui);

        ProcessWire();
        CreateWireToolbox();

        return myInspector;
    }

    public void CreateWireToolbox()
    {
        var wireToolbox = myInspector.Q<VisualElement>("wire_toolbox");
        wireToolbox.style.marginTop = 5;
        wireToolbox.style.marginBottom = 10;
        wireToolbox.style.flexDirection = FlexDirection.Row;

        var enableAll_button = new Button();
        enableAll_button.text = "Enable All";
        enableAll_button.clicked += EnableAllCells;

        var disableAll_button = new Button();
        disableAll_button.text = "Disable All";
        disableAll_button.clicked += DisableAllCells;

        var preview_sceneView = new Button();
        preview_sceneView.text = "Preview in 3D";
        preview_sceneView.clicked += PreviewIn3d;

        targetVehicle = new ObjectField();
        if (lastSelectedVehicle != null)
            targetVehicle.value = lastSelectedVehicle;
        targetVehicle.RegisterValueChangedCallback<UnityEngine.Object>((x) => {
            lastSelectedVehicle = x.newValue as GameObject;
        });
        targetVehicle.objectType = typeof(GameObject);

        wireToolbox.Add(enableAll_button);
        wireToolbox.Add(disableAll_button);
        wireToolbox.Add(preview_sceneView);
        wireToolbox.Add(targetVehicle);
    }

    private void PreviewIn3d()
    {
        previewEnabled = !previewEnabled;
        if(targetVehicle.value == null)
        {
            Debug.Log("<color=orange>Set target vehicle in object field!</color>");
            return;
        }

        if (previewEnabled)
        {
            SceneViewWire.SetupWire(new WireSettings()
            {
                TargetVehicle = (targetVehicle.value as GameObject).transform,
                cells = instance.cellsStruct.cells,
                instance = instance
            });
            SceneViewWire.drawWire = true;
            Selection.activeTransform = SceneViewWire.sceneViewWireMono.transform;
        }
        else
        {

            SceneViewWire.drawWire = false;
        }
    }

    private void DisableAllCells()
    {
        var wire_holder = myInspector.Q<VisualElement>("wire_holder");
        for (int x = 0; x < instance.cellsStruct.cells.GetLength(0); x++)
        {
            var row = wire_holder.ElementAt(x).Q<GroupBox>();
            for (int y = 0; y < instance.cellsStruct.cells.GetLength(1); y++)
            {
                instance.cellsStruct.cells[x, y].exist = false;
                var cell_button = row.ElementAt(y).Q<Button>();
                cell_button.style.backgroundColor = Color.grey;
            }
        }
    }

    private void EnableAllCells()
    {
        var wire_holder = myInspector.Q<VisualElement>("wire_holder");
        for (int x = 0; x < instance.cellsStruct.cells.GetLength(0); x++)
        {
            var row = wire_holder.ElementAt(x).Q<GroupBox>();
            for (int y = 0; y < instance.cellsStruct.cells.GetLength(1); y++)
            {
                instance.cellsStruct.cells[x, y].exist = true;
                var cell_button = row.ElementAt(y).Q<Button>();
                cell_button.style.backgroundColor = Color.green;
            }
        }
    }

    public void ProcessWire()
    {
        skipFirstCallbackTrigger = true;

        var wire_size = myInspector.Q<Vector2IntField>("wire_size");
        wire_size.Bind(serializedObject);
        wire_size.bindingPath = "m_wireSize";   

        var zero_offset = myInspector.Q<Vector3Field>("zero_offset");
        zero_offset.Bind(serializedObject);
        zero_offset.bindingPath = "m_localOffsetFromZero";   

        _rowElement = AssetDatabase.LoadAssetAtPath<VisualTreeAsset>("Assets/UI Toolkit Projects/wire_row_element.uxml");
        _cellButton = AssetDatabase.LoadAssetAtPath<VisualTreeAsset>("Assets/UI Toolkit Projects/cell_button.uxml");
        wire_size.RegisterCallback<ChangeEvent<Vector2Int>>((newValue) =>
        {
            DrawWire(true);
        });
        DrawWire();
    }

    private void DrawWire(bool repaint = false)
    {
        int rows = instance.m_wireSize.x;
        int columns = instance.m_wireSize.y;

        var wire_holder = myInspector.Q<VisualElement>("wire_holder");

        if(repaint || instance.cellsStruct.cells == null)
        {
            if (skipFirstCallbackTrigger)
            {
                skipFirstCallbackTrigger = false;
                return;
            }
            ClearWire(wire_holder);
            instance.cellsStruct.cells = new Cell[rows, columns];
        }

        for (int x = 0; x < rows; x++)
        {
            var row_element = _rowElement.Instantiate();
            row_element.style.minHeight = 30;
            for (int y = 0; y < columns; y++)
            {
                var cell_button = _cellButton.CloneTree();
                var button = cell_button.Q<Button>();
                int x_index = x;
                int y_index = y;

                button.clicked += ()=> CellButtonClicked(x_index, y_index, button);
                cell_button.style.minWidth = 30;
                cell_button.style.minHeight = 30;

                if(instance.cellsStruct.cells[x_index, y_index].exist)
                    button.style.backgroundColor = Color.green;
                else
                    button.style.backgroundColor = Color.grey;

                var rowGroupBox = row_element.Q<GroupBox>();
                rowGroupBox.Add(cell_button);
            }
            wire_holder.Add(row_element);
        }
    }

    private void CellButtonClicked(int x, int y, Button button)
    {
        var cell = instance.cellsStruct.cells[x, y];
        instance.cellsStruct.cells[x, y].exist = !cell.exist;

        if (instance.cellsStruct.cells[x, y].exist)
            button.style.backgroundColor = Color.green;
        else
            button.style.backgroundColor = Color.grey;

    }

    private static void ClearWire(VisualElement wire_holder)
    {
        wire_holder.Clear();
    }
}
