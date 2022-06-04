using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Utils.Convertor;

namespace Vehicle.Storage.Data
{
    public class CellsWire : DataWire<Cell>, IConvertable<CellsWireStruct>
    {
        public CellsWire(int x_Count, int y_Count) : base(x_Count, y_Count)
        {

        }

        public CellsWireStruct ConvertTo()
        {
            var cells = new Cell[RowLength, ColumnLength];
            CellsWireStruct cellsWireStruct;
            for (int x = 0; x < RowLength; x++)
            {
                for (int y = 0; y < ColumnLength; y++)
                {
                    cells[x, y] = this[x, y];
                }
            }
            cellsWireStruct.cells = cells;
            return cellsWireStruct;
        }
    }
}
