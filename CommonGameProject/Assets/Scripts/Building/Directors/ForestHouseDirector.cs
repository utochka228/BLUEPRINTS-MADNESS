using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Building
{
    public class ForestHouseDirector : BuildDirector
    {
        ForestHouseBuilder ForestHouseBuilder;

        public override void SetBuilder(ConstructionBuilder builder)
        {
            ForestHouseBuilder = builder as ForestHouseBuilder;
        }
        protected override void SetBuildingOrder()
        {
            if (buildingOrder == null)
                buildingOrder = new Queue<BuildingOrder>();

            buildingOrder.Enqueue((args) => ForestHouseBuilder.BuildFoundation());
            buildingOrder.Enqueue((args) => ForestHouseBuilder.BuildWalls());
            buildingOrder.Enqueue((args) => ForestHouseBuilder.BuildWindows());
            buildingOrder.Enqueue((args) => ForestHouseBuilder.BuildDoor());
            buildingOrder.Enqueue((args) => ForestHouseBuilder.BuildRoof());
        }
    }
}
