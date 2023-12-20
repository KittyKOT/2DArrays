// Задайте двумерный массив из целых чисел. Напишите программу, которая удалит строку и столбец, на пересечении которых расположен наименьший элемент массива. 
// Под удалением понимается создание нового двумерного массива без строки и столбца

int[,] GenerateMatrix(int row, int column, int leftRange, int rightRange)
{   
    int[,] matrix = new int[row, column];
    Random rand = new Random();

    for (int i = 0; i < row; i++)
    {
        for (int j = 0; j < column; j++)
        {
            matrix[i, j] = rand.Next(leftRange, rightRange + 1);
        }
    }
    return matrix;
}

void PrintMatrix(int[,] matrix)
{
    for (int i = 0; i < matrix.GetLength(0); i++)
    {
        for (int j = 0; j < matrix.GetLength(1); j++)
        {
            Console.Write(matrix[i, j] + "\t");  
        }
        Console.WriteLine();
    }
}

int[] FindMinElement(int[,] matrix)
{
    int minElement = matrix[0, 0];
    int[] minRowColElement = new int[3];
    minRowColElement[2] = minElement;
    for (int i = 0; i < matrix.GetLength(0); i++)
    {
        for (int j = 0; j < matrix.GetLength(1); j++)
        {
           if (matrix[i, j] < minElement){
                minElement = matrix[i, j];
                minRowColElement[0] = i;
                minRowColElement[1] = j;
                minRowColElement[2] = minElement;
           }
        }
    }
    return minRowColElement;
}

int[,] CreateMatrixWithoutMinElement(int[,] matrix, int[] array)
{
    int row = matrix.GetLength(0);
    int column = matrix.GetLength(1);
    int[,] newMatrix = new int[row-1, column-1];
    int newRow = 0;
    for (int i = 0; i < row; i++)
    {
        if (i == array[0])
            continue;
        
        int newColumn = 0;
        for (int j = 0; j < column; j++)
        {
           if (j != array[1])
           {
            newMatrix[newRow,newColumn] = matrix[i, j];
            newColumn ++;
           }
        }
        newRow ++;
    }
    return newMatrix;
}

Console.Write($"Введите количество строк двумерного массива: ");
int rows = Convert.ToInt32(Console.ReadLine());
Console.Write($"Введите количество столбцов двумерного массива: ");
int cols = Convert.ToInt32(Console.ReadLine());

if (rows > 1 && cols > 1)
{
    Console.Write($"Введите минимальное значение элемента массива: ");
    int min = Convert.ToInt32(Console.ReadLine());
    Console.Write($"Введите максимальное значение массива: ");
    int max = Convert.ToInt32(Console.ReadLine());

    int[,] array = GenerateMatrix(rows, cols, min, max);
    PrintMatrix(array);

    int[] newArray = FindMinElement(array);
    Console.WriteLine($"\nНайден первый минимальный элемент = {newArray[2]}, будет удалена {newArray[0]} строка и {newArray[1]}"+" столбец исходного массива\n");

    Console.WriteLine("Новый массив:\n");
    int[,] newMatrix = CreateMatrixWithoutMinElement(array, newArray);
    PrintMatrix(newMatrix);
} else {
    Console.WriteLine("Двумерный массив не может иметь менее 2 строк и/или столбцов!");
}
