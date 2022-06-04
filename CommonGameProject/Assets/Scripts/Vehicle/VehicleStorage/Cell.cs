using UnityEngine;
using Utils.Convertor;
using Vehicle.Storage.Data;

namespace Vehicle.Storage
{
    public struct Cell
    {
        public Vector3 localPosition;
        public bool exist;
    }

    public struct CellsWireStruct : IConvertable<CellsWire>
    {
        public Cell[,] cells;
        public CellsWire ConvertTo()
        {
            var xLength = cells.GetLength(0);
            var yLength = cells.GetLength(1);

            CellsWire cellsWire = new CellsWire(xLength, yLength);
            for (int x = 0; x < xLength; x++)
            {
                for (int y = 0; y < yLength; y++)
                {
                    cellsWire[x, y] = cells[x, y];
                }
            }
            return cellsWire;
        }
    }
}
