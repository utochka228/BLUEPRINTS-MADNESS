using InputPresets;
using UnityEngine;

namespace Game.InputSystem
{
    public enum InputStage
    {
        Gameplay, Menu, Paused
    }
    public class InputSetup : MonoBehaviour
    {
        public PlayerInputControls PlayerControls { get; private set; }
        private void Awake()
        {
            PlayerControls = new();
        }
    }
}
