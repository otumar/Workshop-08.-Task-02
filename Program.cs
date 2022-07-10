// Задайте прямоугольный двумерный массив. 
//Напишите программу, которая будет находить строку с наименьшей суммой элементов.

int Prompt(string message)
{
    Console.Write(message);
    return int.Parse(Console.ReadLine());
}
int[,] GenerateArray(int row, int column, int min, int max)
{
    var array = new int[row, column];
    var rnd = new Random();
    for (int i = 0; i < array.GetLength(0); i++)
    {
        for (int j = 0; j < array.GetLength(1); j++)
        {
            array[i, j] = rnd.Next(min, max + 1);
        }
    }
    return array;
}
void PrintArray(int[,] array)
{
    for (int i = 0; i < array.GetLength(0); i++)
    {
        for (int j = 0; j < array.GetLength(1); j++)
        {
            Console.Write(array[i, j] + "\t");
        }
        Console.WriteLine();
    }
}
int[] CalcSumInEachRow(int[,] array)
{
    int[] sum = new int[array.GetLength(0)];
    for (int i = 0; i < array.GetLength(0); i++)
    {
        int result = 0;
        for (int j = 0; j < array.GetLength(1); j++)
        {
            result = result + array[i, j];
        }
        sum[i] = result;
    }
    return sum;
}
int ShowRowWithSmallestSum(int[] array)
{
    int minimum = array[0];
    int index = 0;
    for (int i = 1; i < array.Length; i++)
    {
        if (minimum > array[i])
        {
            minimum = array[i];
            index = i;
        }
    }
    return index;
}

int row = Prompt("Введите количество строк: ");
int column = Prompt("Введите количество столбцов: ");
int min = 1;
int max = 10;
int[,] array = GenerateArray(row, column, min, max);
PrintArray(array);
System.Console.WriteLine();
int[] SumPerRow = CalcSumInEachRow(array);
int RowWithSmallestSum = ShowRowWithSmallestSum(SumPerRow);
System.Console.WriteLine($"Наименьшая сумма элементов в {RowWithSmallestSum + 1} строке");