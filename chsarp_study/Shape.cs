using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace chsarp_study
{
    public class Shape
    {
        public double X { get; protected set; }
        public double Y { get; protected set; }
        public double Height { get; set; }
        public double Width { get; set; }
        
        public void Draw() {
            String screenBuffer = "";
            for(int j=0; j<Console.WindowHeight; j++) {
                for(int i=0;i < Console.WindowWidth; i++) {
                    screenBuffer += IsInsideShape((double)i / 2, j) ? "*" : " ";
                }
            }
            Console.WriteLine(screenBuffer);
        }

        public virtual bool IsInsideShape(double x, double y) {
            return false;
        }

        public Shape(double X, double Y, double Height, double Width = -1) {
            if (Width < 0) {
                Width = Height;
            }

            this.X = X;
            this.Y = Y;
            this.Height = Height;
            this.Width = Width;

        }
    }

    public class Rectangle : Shape {
        public Rectangle(double X, double Y, double Height, double Width = -1) : base(X, Y, Height, Width) {}
            
        public override bool IsInsideShape(double x, double y) {
            return Math.Abs(X - x) < Width / 2 &&
                   Math.Abs(Y - y) < Height / 2;
        }
    }

    public class Triangle : Shape {
        public double L { get; set; }
        public Triangle(double X, double Y, double Height, double Width, double L) : base(X, Y, Height, Width) {
            this.L = L;
        }

        public override bool IsInsideShape(double x, double y) {
            // Down side check
            if( y > Y + Height / 2) {
                return false;
            }

            double Ax = X - Width / 2;
            double Ay = Y + Height / 2;
            double Bx = X - Width / 2 + L;
            double By = Y - Height / 2;
            double Cx = X + Width / 2 ;
            double Cy = Y + Height / 2;

            // Left side check
            if ((Bx - Ax) * (y - Ay) - (By - Ay) * (x - Ax) < 0) {
                return false;
            }

            // right side check

            if ((Bx - Cx) * (y - Cy) - (By - Cy) * (x - Cx) > 0) {
                return false;
            }

            return true;
        }
    }


    public class Circle : Shape {
        public Circle(double X, double Y, double Height, double Width = -1) : base(X, Y, Height, Width) { }

        public override bool IsInsideShape(double x, double y) {
            return (X - x) * (X - x) / (Width * Width) + (Y - y) * (Y - y) / (Height * Height) < 1;
        }
    }

    //public class MainExecuter {
    //    static void Main(String[] args) {
    //        List<Shape> shapes = new List<Shape>();
    //        shapes.Add(new Rectangle(10, 10, 10, 20));
    //        shapes.Add(new Triangle(10, 10, 10, 10, 4));
    //        shapes.Add(new Circle(15, 15, 10, 7));
            
    //        foreach (Shape s in shapes) {
    //            s.Draw();
    //        }
    //    }
    //}
}
