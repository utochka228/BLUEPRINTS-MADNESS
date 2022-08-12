using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Utils.Convertor;

namespace Vehicle.Storage.Data
{
    public abstract class DataWire<T> where T : struct
    {
        protected T[,] data_table;
        public T this[int X, int Y]
        {
            get {
                return data_table[X, Y];
            }
            set {
                data_table[X, Y] = value;
            }
        }
        public DataWire(int x_Count, int y_Count)
        {
            data_table = new T[x_Count, y_Count];
        }

        public int RowLength { get => data_table.GetLength(0); }
        public int ColumnLength { get => data_table.GetLength(1); }
    }
}
