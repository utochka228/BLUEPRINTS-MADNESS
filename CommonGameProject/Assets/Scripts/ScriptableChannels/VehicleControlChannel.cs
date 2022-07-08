using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace ScriptableChannels
{
    [CreateAssetMenu(fileName = "VehicleControlChannel", menuName = "Scriptable channels/Create vehicle control")]
    public class VehicleControlChannel : ScriptableObject
    {
        public UnityEvent<Collider> OnVehicleInteracted;

        public void RaiseVehicleInteracted(Collider interactedWith) {
            OnVehicleInteracted?.Invoke(interactedWith);
        }
    }
}
