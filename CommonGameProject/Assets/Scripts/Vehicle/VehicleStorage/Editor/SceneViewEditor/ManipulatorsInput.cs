using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Vehicle.Storage.CellsEditorCreator
{
    public class ManipulatorsInput : HandlesInput
    {
        public override void HandleMouseMove()
        {
            UpdateMouseOverSpheres();
        }
        private void UpdateMouseOverSpheres()
        {
            var cellsCreator = EditorCellsCreator.instance;

            if (ManipulatorsDrawer.manipulatorsPoses == null)
                return;

            int index = -1;

            for (int i = 0; i < ManipulatorsDrawer.manipulatorsPoses.Length; i++)
            {
                var manipulatorPos = ManipulatorsDrawer.manipulatorsPoses[i];
                if (Vector3.Distance(sceneMousePosition, manipulatorPos) <= cellsCreator.StorageCreator.ManipulatorsDistance)
                {
                    index = i;

                    break;
                }
            }

            if (index != ManipulatorsDrawer.selectionInfo.ManipulatorIndex)
            {
                ManipulatorsDrawer.selectionInfo.ManipulatorIndex = index;
                ManipulatorsDrawer.selectionInfo.isHovered = true;

                cellsCreator.needsRepaint = true;
            }
        }

        public override void HandleLeftMouseClick()
        {
            
        }
    }
}
