using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Utils.Convertor;

namespace Vehicle.Storage.Data
{
    public class CellsWire : DataWire<WireCell>, IConvertable<CellsWireStruct>
    {

        public CellsWire(int x_Count, int y_Count) : base(x_Count, y_Count)
        {
            for (int x = 0; x < x_Count; x++)
            {
                for (int y = 0; y < y_Count; y++)
                {
                    data_table[x, y] = new WireCell();
                }
            }
        }

        public CellsWireStruct ConvertTo()
        {
            var cells = new Cell[RowLength, ColumnLength];
            CellsWireStruct cellsWireStruct;
            for (int x = 0; x < RowLength; x++)
            {
                for (int y = 0; y < ColumnLength; y++)
                {
                    cells[x, y] = new Cell() { 
                        exist = this[x, y].isExist
                    };
                }
            }
            cellsWireStruct.cells = cells;
            return cellsWireStruct;
        }
    }

    public struct WireCell
    {
        public bool isExist;
        public Color cellColor;
        public Vector3[] verts;

        public Color GetColor()
        {
            if (isExist)
            {
                Color fillColor = Color.yellow;
                fillColor.a = 0.5f;
                return fillColor;
            }
            else
            {
                Color fillColor = Color.grey;
                fillColor.a = 0.5f;
                return fillColor;
            }
        }
    }
}
