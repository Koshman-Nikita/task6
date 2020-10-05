using System;
using System.Linq;
using System.Net.Http;

namespace hw4_task6
{
    abstract class Triangle
    {
        protected double a, b;
        protected double angle;

        public abstract double FindSquare();
        public abstract double FindPerimetr();

    }

    class RectTriangle : Triangle
    {
        public RectTriangle(double a, double b, double ang)
        {
            this.a = a;
            this.b = b;
            angle = ang;
        }
        public override double FindSquare()
        {
            return Math.Round(0.5 * a * b, 2);
        }

        public override double FindPerimetr()
        {
            return Math.Round(Math.Sqrt(a * a + b * b) + a + b, 2);
        }

        public string GetName()
        {
            if (a == b) return "прямокутним і рівнобедреним";
            else return "прямокутним";
        }


    }

    class IsoTriangle : Triangle
    {
        public IsoTriangle(double a, double b, double ang)
        {
            this.a = a;
            this.b = b;
            angle = ang;
        }
        public override double FindSquare()
        {
            return Math.Round(0.5 * a * b * Math.Sin(angle * Math.PI / 180), 2);
        }

        public override double FindPerimetr()
        {
            double c = TheoCos.TheoremCos(a, b, angle);
            return Math.Round(a + b + c, 2);
        }

        public string GetName()
        {
            if (angle == 90) return "рівнобедреним і прямокутним";
            else return "рівнобедреним";
        }

    }
    public class TheoCos
    {
        public static double TheoremCos(double a, double b, double ang)
        {
            return Math.Sqrt(a * a + b * b - 2 * a * b * Math.Cos(ang * Math.PI / 180));
        }
    }
    class Program
    {
        private static bool CheckForRect(double a, double b, double ang)
        {
            if (ang == 90) return true;
            else if (ang > 90) return false;
            else
            {
                double c = TheoCos.TheoremCos(a, b, ang);
                double square = 0.5 * a * b * Math.Sin(ang * Math.PI / 180);
                double square1 = 0;
                if (a > b) square1 = 0.5 * b * c;
                else square1 = 0.5 * a * c;
                if (Math.Abs(square - square1) < 0.00001) return true;
            }
            return false;
        }
        


        private static bool CheckForIso(double a, double b, double ang)
        {
            if (a == b) return true;
            else
            {
                double c = TheoCos.TheoremCos(a, b, ang);
                if (a == c || b == c) return true;
            }
            return false;
        }

        public static void Main(string[] args)
        {
                Console.Clear();
               Console.WriteLine("Ведiть дані трикутника ");
            Console.WriteLine("сторна АВ:");
            double a = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("сторна АC:");
            double b = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("кут А:");
            double angle = Convert.ToDouble(Console.ReadLine());
                if (a <= 0 || b <= 0 || angle <= 0 || angle >= 180)
                {
                    Console.WriteLine("Кут або сторони не в межах логічного діапазону");
                }
                else if (CheckForRect(a, b, angle))
                {
                    RectTriangle RT = new RectTriangle(a, b, angle);
                    Console.WriteLine("Даний трикутник є " + RT.GetName());
                    Console.WriteLine("Його площа = " + RT.FindSquare().ToString());
                    Console.WriteLine("Його периметр становить = " + RT.FindPerimetr().ToString());
                
            }
                else if (CheckForIso(a, b, angle))
                {
                    IsoTriangle IT = new IsoTriangle(a, b, angle);
                    Console.WriteLine("Даний трикутник є " + IT.GetName());
                    Console.WriteLine("Його площа = " + IT.FindSquare().ToString());
                    Console.WriteLine("Його периметр становить = " + IT.FindPerimetr().ToString());
                }
                else
                {
                    Console.WriteLine("Кут або сторони не в межах логічного діапазону");
                }
 



        }
        
    }
  }
   


