// Задайте двумерный массив. Напишите программу, которая поменяет местами первую и последнюю строку массива.

int[,] GetArray(int rows, int columns, int minValue, int maxValue) // Метод создает двумерный массив случайных чисел.
{
    int[,] result = new int[rows, columns];
    for (int i = 0; i < rows; i++)
        for (int j = 0; j < columns; j++)
        {
            result[i, j] = new Random().Next(minValue, maxValue);
        }
    return result;
}

void PrintArray(int[,] inArray)
{
    for (int i = 0; i < inArray.GetLength(0); i++)
    {
        for (int j = 0; j < inArray.GetLength(1); j++)
        {
            Console.Write($"{inArray[i, j]}");
        }
        Console.WriteLine();
    }
}

void ChangeRows(int[,] inArray)
{
    int rowCount = inArray.GetLength(0) - 1;
    for (int i = 0; i < inArray.GetLength(1); i++)
    {
        int k = inArray[0, i];
        inArray[0, i] = inArray[rowCount, i];
        inArray[rowCount, i] = k;
    }
}

Console.Clear();
Console.Write("Введите количество строк в массиве: ");
int row = Convert.ToInt32(Console.ReadLine()!);
Console.Write("Введите количество столбцов в массиве: ");
int columns = Convert.ToInt32(Console.ReadLine()!);

int[,] array = GetArray(row, columns, 0, 10);
PrintArray(array);
ChangeRows(array);
Console.WriteLine("");
PrintArray(array);