// Задайте прямоугольный двумерный массив. Напишите программу, которая будет находить строку с наименьшей суммой элементов.

int[,] Create2DArray(int rows, int columns, int min, int max)
{
    int[,] array = new int[rows, columns];
    for (int i = 0; i < rows; i++)
    {
        for (int j = 0; j < columns; j++) 
        {
            array[i,j] = new Random().Next(min, max + 1); 
        }
    }

    return array;
}

void Print2DArray(int[,] array)
{
    for (int i = 0; i < array.GetLength(0); i++)
    {
        for (int j = 0; j < array.GetLength(1); j++)
        {
            System.Console.Write(array[i,j] + " ");
        }
        System.Console.WriteLine();
    }
}

int[] SumElementsRows(int[,] array)
{
    int[] sumArray = new int[array.GetLength(0)];
    for (int i = 0; i < array.GetLength(0); i++)
    {
        int sum = 0;
        for (int j = 0; j < array.GetLength(1); j++)
        {
            sum = sum + array[i, j];
            sumArray[i] = sum;
        }
    }
    return sumArray;
}

void PrintSumArray(int[] array)
{
    for (int i = 0; i < array.Length; i++)
    {
        Console.WriteLine($"Сумма элементов строки с индексом {i} = {array[i]}");
    }
    Console.WriteLine();
}

// int IndexMinElements(int[] array) // // Если строк с наименьшей суммой элементов больше 1, то данный метод находит индекс последней строки из строк с равнозначной минимальной суммой
// {
//     int iMin = 0;
//     int min = array[iMin];
//     for (int i = 1; i < array.Length - 1; i++)
//     {
//         if (array[i] < min)
//         {
//             min = array[i];
//             iMin = i;
//         }
//     }
//     return iMin;
// }

int SumFirstRowMatrix(int[,] matrix) // Если строк с наименьшей суммой элементов больше 1, то данный метод находит индекс первой строки из строк с равнозначной минимальной суммой
{
    int columns = matrix.GetLength(1);
    int minsum = 0;
    for (int i = 0; i < 1; i++)
    {
        for (int j = 0; j < columns; j++)
        {
            minsum += matrix[i, j];
        }
    }
    return minsum;
}

int MinElemRowMatrix(int[,] matrix)
{
    int rows = matrix.GetLength(0);
    int columns = matrix.GetLength(1);
    int minsum = SumFirstRowMatrix(matrix);
    int minElemRow = 0;
    for (int i = 0; i < rows; i++)
    {
        int sum = 0;
        for (int j = 0; j < columns; j++)
        {
            sum += matrix[i, j];
        }
        if (sum < minsum)
        {
            minsum = sum;
            minElemRow = i;
        }
    }
    return minElemRow;
}

// int[,] newArray = new int[,] // // проверка с помощью внесения значений элементов массива вручную (хард-код)
// {
//     {1, 2, 3},
//     {3, 2, 1},
//     {4, 5, 6},
//     {7, 6, 5},
// };

Console.Write("Введите количество строк: ");
int Qrows = Convert.ToInt32(Console.ReadLine());
Console.Write("Введите количество столбцов: ");
int Qcolumns = Convert.ToInt32(Console.ReadLine());
Console.Write("Введите минимальное значение элемента: ");
int minValue = Convert.ToInt32(Console.ReadLine());
Console.Write("Введите максимальное значение элемента: ");
int maxValue = Convert.ToInt32(Console.ReadLine());
int[,] newArray = Create2DArray(Qrows, Qcolumns, minValue, maxValue);
Print2DArray(newArray);
Console.WriteLine();
int[] sumArray = SumElementsRows(newArray);
PrintSumArray(sumArray);
int numberOfRow = MinElemRowMatrix(newArray);
Console.WriteLine($"Номер строки с наименьшей суммой элементов - {numberOfRow}.");