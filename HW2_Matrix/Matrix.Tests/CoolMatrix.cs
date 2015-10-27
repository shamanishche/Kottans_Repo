﻿using System;
using System.Data;

namespace Matrix.Tests
{
    internal class CoolMatrix
    {
        private int[,] arr;
        public Size Size;
        public bool IsSquare => Size.IsSquare;

        public CoolMatrix(int[,] arr)
        {
            if (ReferenceEquals(null, arr)) throw new ArgumentNullException(nameof(arr));

            this.arr = arr;
            this.Size = new Size(arr.GetLength(1), arr.GetLength(0));
        }

        public static implicit operator CoolMatrix(int[,] arr)  
        {
            return new CoolMatrix(arr);
        }

        public override string ToString()
        {
            var output = System.String.Empty;
            for (int i = 0; i < Size.Height; i++)
            {
                output += "[";
                for (int j = 0; j < Size.Width; j++)
                {
                    var lineEnd = (j == Size.Width-1) ? "]" : ", ";
                    output += $"{arr[i,j]}{lineEnd}";
                }
                var lineEnd1 = (i == Size.Height - 1) ? "" : "\r\n";
                output += lineEnd1;
            }
            return output;
        }

        public int this[int row, int column]
        {
            get
            {
                if ((row < 0) || (column < 0)
                    || (row > Size.Width) || (column > Size.Height))
                        {throw new ArgumentOutOfRangeException();}
                return arr[row, column];
            }
            set
            {
                if ((row < 0) || (column < 0)
                    || (row > Size.Width) || (column > Size.Height))
                        { throw new ArgumentOutOfRangeException(); }
                arr[row, column] = value;
            }
        }
        public override bool Equals(object obj)
        {
            // If parameter is null return false.
            if (obj == null)
            {
                return false;
            }

            //If parameter cannot be cast to CoolMatrix return false.
            CoolMatrix matrix = obj as CoolMatrix;
            if ((System.Object)matrix == null)
            {
                return false;
            }

            // Return true if the fields match:
            if (Size != matrix.Size)
                   { return false; }

            for (int i = 0; i < matrix.Size.Height; i++)
            {
                for (int j = 0; j < matrix.Size.Width; j++)
                {
                    if (this[i,j] != matrix[i, j])
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        public static bool operator == (CoolMatrix left, CoolMatrix right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(CoolMatrix left, CoolMatrix right)
        {
            return !Equals(left, right);
        }

        public static CoolMatrix operator *(CoolMatrix left, int right)
        {
            CoolMatrix result = left.arr;

            for (var i = 0; i < result.Size.Width; i++)
            {
                for (var j = 0; j < result.Size.Height; j++)
                    result.arr[i, j] *= right;
            }

            return result;
        }

        public static CoolMatrix operator +(CoolMatrix left, CoolMatrix right)
        {
            if (left.Size != right.Size)
            {
                throw new ArgumentException();
            }
            CoolMatrix result = left.arr;

            for (var i = 0; i < result.Size.Width; i++)
            {
                for (var j = 0; j < result.Size.Height; j++)
                    result[i, j] += right[i,j];
            }
            return result;
        }

        public CoolMatrix Transpose()
        {
            int[,] transposedArray = new int[Size.Height, Size.Width];

            for (var i = 0; i < Size.Width; i++)
                for (var j = 0; j < Size.Height; j++)
                    transposedArray[j, i] = arr[i, j];

            Size = new Size(transposedArray.GetLength(0), transposedArray.GetLength(1));
            arr = transposedArray;

            return this;
        }
    }
}