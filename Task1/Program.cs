// Напишите программу, которая на вход принимает позиции элемента в двумерном массиве, и возвращает значение этого элемента или же указание, что такого элемента нет.

int[,] Create2DArray(int rows, int columns, int min, int max)
{
    int[,] array = new int[rows, columns]; // выделит в памяти место для двумерного массива
    for (int i = 0; i < rows; i++) // проход по строчкам
    {
        for (int j = 0; j < columns; j++) // проход по столбцам
        {
            array[i,j] = new Random().Next(min, max + 1); // заполнение массива, но не выведение
        }
    }

    return array; // возвращает массив
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

int FindElement(int[,] array, int row, int column)
{   
    while (row >= array.GetLength(0) || column >= array.GetLength(1))
    {
        Console.WriteLine("Такого элемента не существует. Введите другое значение."); 
        Console.Write("Введите номер строки элемента: ");
        row = Convert.ToInt32(Console.ReadLine());
        Console.Write("Введите номер столбца элемента: ");
        column = Convert.ToInt32(Console.ReadLine()); 
    }
    int num = array[row,column];        
    return num;
}

Console.Write("Введите количество строк: ");
int Qrows = Convert.ToInt32(Console.ReadLine());
Console.Write("Введите количество столбцов: ");
int Qcolumns = Convert.ToInt32(Console.ReadLine());
Console.Write("Введите минимальное значение элемента: ");
int minValue = Convert.ToInt32(Console.ReadLine());
Console.Write("Введите максимальное значение элемента: ");
int maxValue = Convert.ToInt32(Console.ReadLine());
int[,] myArray = Create2DArray(Qrows, Qcolumns, minValue, maxValue);
Print2DArray(myArray);
Console.Write("Введите номер строки элемента: ");
int row = Convert.ToInt32(Console.ReadLine());
Console.Write("Введите номер столбца элемента: ");
int column = Convert.ToInt32(Console.ReadLine());
Console.WriteLine($"Значение элемента с указанными индексами строки и столбца: {FindElement(myArray, row, column)}"); 