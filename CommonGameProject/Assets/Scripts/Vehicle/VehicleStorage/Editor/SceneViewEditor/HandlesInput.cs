using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using Utils;

namespace Vehicle.Storage.CellsEditorCreator
{
    public class HandlesInput
    {
        protected static Vector3 sceneMousePosition;
        protected Event guiEvent;
        protected EditorCellsCreator cellsCreator;
        
        public virtual void ProcessInput(EditorCellsCreator cellsDrawer, Event _guiEvent)
        {
            guiEvent = _guiEvent;
            cellsCreator = cellsDrawer;
            ProcessMousePosition(guiEvent.mousePosition, cellsDrawer.WireHeightInScene);

            if(guiEvent.type == EventType.MouseMove && guiEvent.modifiers == EventModifiers.None)
            {
                HandleMouseMove();
            }
            if(guiEvent.type == EventType.MouseDown && guiEvent.button == 0 && guiEvent.modifiers == EventModifiers.None)
            {
                HandleLeftMouseClick();
            }
            if(guiEvent.type == EventType.MouseDrag && guiEvent.button == 0 && guiEvent.modifiers == EventModifiers.None)
            {
                HandleLeftMouseDrag();
            }
        }

        private void ProcessMousePosition(Vector2 mousePosition, float drawPlaneHeight)
        {
            Ray mouseRay = HandleUtility.GUIPointToWorldRay(mousePosition);
            float dstToDrawPlane = (drawPlaneHeight - mouseRay.origin.y) / mouseRay.direction.y;
            sceneMousePosition = mouseRay.GetPoint(dstToDrawPlane);
        }

        public virtual void HandleMouseMove() { }
        public virtual void HandleLeftMouseClick() { }
        public virtual void HandleLeftMouseDrag() { }
    }
}
