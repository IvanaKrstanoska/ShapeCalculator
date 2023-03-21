using System;
using System.Collections.Generic;

namespace ShapeCalculator
{
    public enum ShapeMood
    {
        Normal = 1,
        Happy = 2,
        SupperHappy = 3,

    }
    public interface IShape
    {
        double CalculateArea();
        int NumberOfCorners();
    }

    public class Triangle : IShape
    {
        public double Base { get; set; }
        public double Height { get; set; }
        public int Mood { get; set; }

        public Triangle(double triangleBase, double height, int mood)
        {
            Base = triangleBase;
            Height = height;
            Mood = mood;
        }

        public double CalculateArea()
        {
            return ((Base * Height) / 2) * Mood;
        }

        public int NumberOfCorners()
        {

            return 3 * Mood;
        }
    }

    public class Square : IShape
    {
        public double Side { get; set; }
        public int Mood { get; set; }

        public Square(double side, int mood)
        {
            Side = side;
            Mood = mood;
        }

        public double CalculateArea()
        {
            return Side * Side * Mood;
        }

        public int NumberOfCorners()
        {
            return 4 * Mood;
        }
    }

    public class Circle : IShape
    {
        public double Radius { get; set; }
        public int Mood { get; set; }
        public Circle(double radius, int mood)
        {
            Radius = radius;
            Mood = mood;
        }

        public double CalculateArea()
        {
            return (3.1415 * (Radius * Radius)) * Mood;
        }

        public int NumberOfCorners()
        {
            if (Mood == (int)ShapeMood.SupperHappy)
            {
                return 10;
            }
            if (Mood == (int)ShapeMood.Happy)
            {
                return 5;
            }
            else
                return 0;
        }
    }


    public class ShapeCalculator
    {
        public double CalculateTotalArea(List<IShape> shapes)
        {
            double totalArea = 0;
            foreach (var shape in shapes)
            {
                totalArea += shape.CalculateArea();
            }
            return totalArea;
        }

        public int CalculateTotalCorners(List<IShape> shapes)
        {
            int totalCorners = 0;
            foreach (var shape in shapes)
            {
                totalCorners += shape.NumberOfCorners();
            }
            return totalCorners;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            List<IShape> shapes = new List<IShape>();
            shapes.Add(new Triangle(3, 4, (int)ShapeMood.Normal));
            shapes.Add(new Square(2, (int)ShapeMood.Normal));
            shapes.Add(new Circle(5.6, (int)ShapeMood.Normal));
            shapes.Add(new Circle(2, (int)ShapeMood.SupperHappy));
            shapes.Add(new Square(5, (int)ShapeMood.Happy));
            ShapeCalculator calculator = new ShapeCalculator();
            double totalArea = calculator.CalculateTotalArea(shapes);
            int totalCorners = calculator.CalculateTotalCorners(shapes);
            Console.WriteLine($"Total area of the shapes is {totalArea}");
            Console.WriteLine($"Total corners of the shapes is {totalCorners}");

        }
    }
}
