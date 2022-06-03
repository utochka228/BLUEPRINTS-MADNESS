using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameDataUtils.DataWireClass
{
    public class DataWire<T> where T : struct
    {
        List<List<T>> data_table;
        private int rowLength;
        private int columnLength;
        public T this[int X, int Y]
        {
            get {
                return data_table[X][Y];
            }
            set {
                data_table[X][Y] = value;
            }
        }
        public DataWire(int x_Count, int y_Count)
        {
            data_table = new List<List<T>>(x_Count);

            List<T> yElement = new List<T>(y_Count);

            foreach (var xElement in data_table)
            {
                data_table.Add(yElement);
            }

            rowLength = x_Count;
            columnLength = y_Count;
        }

        public int RowLength { get => rowLength; }
        public int ColumnLength { get => columnLength; }
    }
}
