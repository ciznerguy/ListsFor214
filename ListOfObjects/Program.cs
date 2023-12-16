using ListsOfObjects;
using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace ListOfObjects
{
    internal class Program
    {

        public static void FillArrPoints(Point[] points)
        {
            Random random = new Random();

            for (int i = 0; i < points.Length; i++)
            {
                int randomX = random.Next(0, 11);
                int randomY = random.Next(0, 11);

                points[i] = new Point(randomX, randomY);
            }
        }

        public static void PrintArrPoints(Point[] points)
        {
            for (int i = 0; i < points.Length; i++)
            {
                Console.Write($"value of x {points[i].GetX()} ");
                Console.WriteLine($"value of y {points[i].GetY()} ");
            }
        }

        public static Node<Point> ArrToList(Point[] arr)
        {
            Point p1 = new Point(arr[0].GetX(), arr[0].GetY());
            Node<Point> listToReturn = new Node<Point>(p1);
            Node<Point> current = listToReturn;
            for (int i = 1; i < arr.Length; i++)
            {
                Point pointToAdd = new Point(arr[i].GetX(), arr[i].GetY());
                Node<Point> nodeToAdd = new Node<Point>(pointToAdd);
                current.SetNext(nodeToAdd);
                current = current.GetNext();
            }
            return listToReturn;
        }

        public static double DisPoints(Point p1, Point p2)
        {
            double sum_x = Math.Pow((p1.GetX() - p2.GetX()), 2);
            double sum_y = Math.Pow((p1.GetY() - p2.GetY()), 2);
            return Math.Sqrt(sum_x + sum_y);
        }

        public static double SumDis(Node<Point> head)
        {
            double totalDis = 0;
            while(head.HasNext())
            {
                totalDis += DisPoints(head.GetValue(), head.GetNext().GetValue());
                head = head.GetNext();
            }
            return totalDis;
        }

        

        static void Main(string[] args)
        {
            Point[] arrPoints = new Point[2];
            FillArrPoints(arrPoints);
            PrintArrPoints(arrPoints);
            Point p11 = new Point(arrPoints[0].GetX(), arrPoints[0].GetY());
            Node<Point> p1 = new Node<Point>(p11);
            Console.WriteLine(p1.GetValue().GetX());
            Node<Point> list = ArrToList(arrPoints);
            
            
                Console.WriteLine(list);
            double dis = SumDis(list);
            Console.WriteLine("asd"+dis);


        }
    }
}
