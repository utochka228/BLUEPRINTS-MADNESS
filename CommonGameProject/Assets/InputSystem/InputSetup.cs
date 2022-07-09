using InputPresets;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace InputSystem
{
    public enum InputStage
    {
        Gameplay, Menu
    }
    public class InputSetup : MonoBehaviour
    {

#if UNITY_EDITOR
        [SerializeField] InputEditorChannel inputEditorChannel;
        public InputEditorChannel InputEditorChannel { get => inputEditorChannel; }
#endif
        [SerializeField] InputMobileChannel inputMobileChannel;
        public InputMobileChannel InputMobileChannel { get => inputMobileChannel; }

        private void Awake()
        {
            SetupDefaultInputs();
        }

        private void SetupDefaultInputs()
        {

        }

        public static void SetupInput(InputStage inputStage)
        {
            var gameInput = new GameInput();
#if UNITY_EDITOR
            gameInput.InGameEditor.Enable();
#else
            gameInput.InGameMobile.Enable();
#endif
            switch (inputStage)
            {
                case InputStage.Gameplay:
                    // Do some actions
                    break;
                case InputStage.Menu:
                    // Do some actions
                    break;
                
            }
        }
    }
}
