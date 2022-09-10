using UnityEngine;
using Utils;
using Utils.CellVertices;
using Utils.Convertor;
using Transport.Storage.CellsEditorCreator;
using Transport.Storage.Data;

namespace Transport.Storage
{
    public struct Cell
    {
        public bool exist;

        public Color GetColor()
        {
            if (exist)
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
                    cellsWire[x, y] = new WireCell()
                    {
                        isExist = cells[x, y].exist,
                        verts = VerticesUtils.GetVertices(new DrawingCellsParams() {
                            coords = new Vector2(x, y),
                            targetVehicle = CellsStorageCreator.instance.targetVehicle.transform,
                            cells_unit_size = CellsStorageCreator.instance.CELLS_UNIT_SIZE,
                            offsetFromZeroPoint = CellsStorageCreator.instance.targetVehicleStorage.localOffsetFromZero,
                            fillColor = cells[x, y].GetColor()
                    })};
                }
            }
            return cellsWire;
        }
    }
}
