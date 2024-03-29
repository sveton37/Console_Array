using System;
using System.Linq;
using System.Text;

public class Program
{
    public static void Main()
    {
        Console.WriteLine("Task : Determining the maximum and minimum element in each row " +
            "\nand finding the arithmetic mean of each row.");
        Console.WriteLine("Enter the size of the array. ");
        int m = GetNumberFromUser("Enter the number of rows: ", "Input error!");       
        int n = GetNumberFromUser("Enter the number of columns: ", "Input error!");
        int range = GetNumberFromUser("Enter a range of element values: from 1 to ", "Input error!");
        int[,] arr = new int[m, n];

        GetArray(arr, range);
        PrintArray(arr);
        FindMax(arr);
        FindMin(arr);
        Console.WriteLine();         
        GetAverage(arr, n);
        Console.WriteLine();
        Console.WriteLine("\nPress any key to exit...");
        Console.ReadKey();
    }

    // Метод запроса числа у пользователя с проверкой на ошибки ввода.
    public static int GetNumberFromUser(string message, string errorMessage)
    {
        while (true)
        {
            Console.Write(message);
            bool isCorrect = int.TryParse(Console.ReadLine(), out int userNumber);

            if (isCorrect)
            {
                return userNumber;
            }

            Console.WriteLine(errorMessage);
        }
    }

    // Метод определения двумерного массива целых чисел.
    public static void GetArray(int[,] arr, int range)
    {
        for (int i = 0; i < arr.GetLength(0); i++)
        {
            for (int j = 0; j < arr.GetLength(1); j++)
            {
                arr[i, j] = new Random().Next(range);
            }
        }
    }

    // Метод вывода массива в консоль.
    public static void PrintArray(int[,] arr)
    {
        for (int i = 0; i < arr.GetLength(0); i++)
        {
            for (int j = 0; j < arr.GetLength(1); j++)
            {
                Console.Write(arr[i, j] + "\t");
            }
            Console.WriteLine();
        }
    }

    // Метод нахождения минимального числа для каждой строки.
    public static void FindMin(int[,] arr)
    {
        if (arr.Length == 0)
        {
            throw new Exception("Array is empty");
        }
        
        for (int i = 0; i < arr.GetLength(0); i++)
        {
            int min = int.MaxValue;
            for (int j = 0; j < arr.GetLength(1); j++)
            {
                if (min > arr[i, j])
                {
                    min = arr[i, j];
                }
            }

            Console.WriteLine("Minimum number is row {0}: {1}", i, min);            
        }        
    }

    // Метод нахождения максимального числа для каждой строки.
    public static void FindMax(int[,] arr)
    {
        if (arr.Length == 0)
        {
            throw new Exception("Array is empty");
        }
        
        for (int i = 0; i < arr.GetLength(0); i++)
        {
            int max = int.MinValue;
            for (int j = 0; j < arr.GetLength(1); j++)
            {
                if (max < arr[i, j])
                {
                    max = arr[i, j];
                }
            }

            Console.WriteLine("Maximum number is row {0}: {1}", i, max);
        }   
    }

    // Метод нахождения среднего арифметического числа для каждой строки.
    public static void GetAverage(int[,] arr, int col)
    {
        if (arr.Length == 0)
        {
            throw new Exception("Array is empty");
        }

        double sum = 0;
        double result = 0;

        Console.Write("The arithmetic mean of each row: ");

        for (int i = 0; i < arr.GetLength(0); i++)
        {
            sum = 0;
            for (int j = 0; j < arr.GetLength(1); j++)
            {
                sum = sum + arr[i, j];
            }
            result = Math.Round((sum / col), 2);

            if (i == col)
            {
                Console.Write($" {result}.");
            }
            else 
            {
                Console.Write($" {result};");
            }            
        }
    }
}