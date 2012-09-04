using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GraphApp.src
{
    public class AdjacencyMatrix
    {
        private float[,] array;
        private int count, capacity;
        private float defaultValue;

        public AdjacencyMatrix(float defaultVal)
        {
            count = 0;
            capacity = 1;
            array = new float[capacity,capacity];

            defaultValue = defaultVal;
        }

        public void Clear()
        {
            count = 0;
        }

        //Sets every entry to value
        public void Fill(float value)
        {
            for (int row = 0; row < count; row++)
            {
                for (int col = 0; col < count; col++)
                {
                    array[row,col] = value;
                }
            }
        }

        //Sets a value at a specific position in the matrix
        public void SetValueAt(int row, int col, float value)
        {
            CheckBounds(row, col);
            array[row,col] = value;
        }

        public float GetValueAt(int row, int col)
        {
            CheckBounds(row, col);
            return array[row, col];
        }

        //Adds a vertex to the matrix, which internally adds a new row and column
        //Fills the row and column associated with the vertex to the default float value
        public void AddVertex()
        {
            if (count >= capacity)
            {
                capacity *= 2;
                float[,] newArray = new float[capacity,capacity];

                for (int i = 0; i <= array.GetUpperBound(0); i++)
                {
                    for (int j = 0; j <= array.GetUpperBound(1); j++)
                    {
                        newArray[i, j] = array[i, j];
                    }
                }

                array = newArray;
            }

            count++;

            for (int i = 0; i < count; i++)
            {
                array[i, count - 1] = defaultValue;
                array[count - 1, i] = defaultValue;
            }
        }

        //Remove the row and column associated with this vertex
        public void RemoveVertex(int index)
        {
            //Make sure the vertex we're removing is within the bounds of the graph
            CheckBounds(index, index);
            count--;
            //Remove column
            for (int i = index; i < count; i++)
            {
                for (int j = 0; j < count + 1; j++)
                {
                    array[j, i] = array[j, i + 1];
                }
            }

            //Remove row
            for (int i = index; i < count; i++)
            {
                for (int j = 0; j < count; j++)
                {
                    array[i, j] = array[i + 1, j];
                }
            }
        }

        private void CheckBounds(int row, int col)
        {
            if (row >= count || col >= count || row < 0 || col < 0)
            {
                throw new Exception("Index is out of bounds");
            }
        }

        public int GetCount()
        {
            return count;
        }

        public float[,] GetRawMatrix()
        {
            return array;
        }

        public override string ToString()
        {
            string s = "";
            for (int i = 0; i < count; i++)
            {
                for (int j = 0; j < count; j++)
                {
                    s += array[i, j] + " ";
                    if (j == count - 1)
                    {
                        s += "\n";
                    }
                }
            }

            return s;
        }
    }
}
