using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Building
{
    // Realize order of building target builder
    public abstract class BuildDirector
    {
        public abstract void SetBuilder(ConstructionBuilder builder);
        protected Queue<BuildingOrder> buildingOrder = new Queue<BuildingOrder>();
        protected abstract void SetBuildingOrder();
    }
}
