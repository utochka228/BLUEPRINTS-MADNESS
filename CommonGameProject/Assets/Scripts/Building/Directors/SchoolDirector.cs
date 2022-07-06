using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Building
{
    public class SchoolDirector : BuildDirector
    {
        SchoolBuilder schoolBuilder;
        public override void SetBuilder(ConstructionBuilder builder)
        {
            schoolBuilder = builder as SchoolBuilder;
        }
        protected override void SetBuildingOrder()
        {
            if (buildingOrder == null)
                buildingOrder = new Queue<BuildingOrder>();

        }
    }
}
