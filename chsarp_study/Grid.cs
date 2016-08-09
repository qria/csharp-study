using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace chsarp_study
{
    public class Grid<T> {
        private T[,] data;
        public int Width { get; set; }
        public int Height { get; set; }

        public Grid(int width, int height) {
            Width = width;
            Height = height;
            data = new T[width, height];
        }

        public Grid(int width, int height, T value) : this(width, height) {
            for (int i = 0; i < Width; i++) {
                for (int j = 0; j < Height; j++) {
                    data[i, j] = value;
                }
            }
        }

        public T GetValue(int x, int y) {
            if (x >= 0 && x < Width && y >= 0 && y < Height)
                return data[x, y];
            else {
                Console.WriteLine("Error in GetValue: index out of bounds");
                return default(T);
            }
        }

        public void SetValue(int x, int y, T value) {
            if (x >= 0 && x < Width && y >= 0 && y < Height)
                data[x, y] = value;
            else
                Console.WriteLine("Error in SetValue: index out of bounds");
        }

        public void SetRect(int x1, int y1, int x2, int y2, T value) {
            for(int j = y1; j < y2; j++) {
                for(int i = x1; i < x2; i++) {
                    data[i, j] = value;
                }
            }
        }

        public void Print() {
            for (int j = 0; j < Height; j++) {
                for (int i = 0; i < Width; i++) {
                    Console.Write(data[i, j]);
                    Console.Write(" ");
                }
                Console.WriteLine();
            }
        }
    }
}
