using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {

            Vector3D vector1 = new Vector3D(1, 2, 3);
            Vector3D vector2 = new Vector3D(4, 5, 6);
            Console.WriteLine($"Вектор 1: {vector1.ToString()}");
            Console.WriteLine($"Вектор 2: {vector2.ToString()}");
            Console.WriteLine($"Длина вектора 1: {vector1.Length()}");
            Console.WriteLine($"Длина вектора 2: {vector2.Length()}");
            Console.WriteLine($"Скалярное произведение: {vector1.ScalarProduct(vector2)}");
            Vector3D vectorProduct = vector1.VectorProduct(vector2);
            Console.WriteLine($"Векторное произведение: ({vectorProduct.X}, {vectorProduct.Y}, {vectorProduct.Z})");
            Console.WriteLine($"Косинус: {vector1.Cosine(vector2)}");
            Vector3D sum = vector1.Sum(vector2);
            Console.WriteLine($"Сумма: ({sum.X}, {sum.Y}, {sum.Z})");
            Vector3D difference = vector1.Difference(vector2);
            Console.WriteLine($"Разница: ({difference.X}, {difference.Y}, {difference.Z})");
            Console.Write("Введите целое число n: ");
            var x = Console.ReadLine();
            Vector3D[] randomVectors = Vector3D.RandomVectors(Convert.ToInt32(x));
            for (int i = 0; i < randomVectors.Length; i++)
            {
                Console.WriteLine($"Случайный вектор {i + 1}: ({randomVectors[i].X}, {randomVectors[i].Y}, {randomVectors[i].Z})");
            }
            Console.ReadKey();
        }
    }
    public class Vector3D
    {
        public double X { get; set; }
        public double Y { get; set; }
        public double Z { get; set; }
        public Vector3D(double x, double y, double z)
        {
            X = x; Y = y; Z = z;
        }
        public override string ToString()
        {
            return $"({X}, {Y}, {Z})";
        }
        public double Length()
        {
            return Math.Sqrt(X * X + Y * Y + Z * Z);
}
        public double ScalarProduct(Vector3D other)
        {
            return X * other.X + Y * other.Y + Z * other.Z;
        }
        public Vector3D VectorProduct(Vector3D other)
        {
            return new Vector3D(Y * other.Z - Z * other.Y, Z * other.X - X * other.Z, X * other.Y - Y * other.X);
        }
        public double Cosine(Vector3D other)
        {
            return ScalarProduct(other) / (Length() * other.Length());
        }
        public Vector3D Sum(Vector3D other)
        {
            return new Vector3D(X + other.X, Y + other.Y, Z + other.Z);
        }
        public Vector3D Difference(Vector3D other)
        {
            return new Vector3D(X - other.X, Y - other.Y, Z - other.Z);
        }
        public static Vector3D[] RandomVectors(int n)
        {
            var random = new Random();
            var vectors = new Vector3D[n];
            for (int i = 0; i < n; i++)
            {
                vectors[i] = new Vector3D(random.NextDouble(), random.NextDouble(), random.NextDouble());
            }
            return vectors;
        }
    }
}
