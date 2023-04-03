/*/
// Задача 54: Задайте двумерный массив. Напишите программу, которая упорядочит по убыванию элементы каждой строки двумерного массива.
// Например, задан массив:
// 1 4 7 2
// 5 9 2 3
// 8 4 2 4
// В итоге получается вот такой массив:
// 7 4 2 1
// 9 5 3 2
// 8 4 4 2

Console.Write("Введите количество строк: ");
int rows = int.Parse(Console.ReadLine()!);

Console.Write("Введите количество столбцов: ");
int columns = int.Parse(Console.ReadLine()!);

int[,] array = GetArray(rows, columns, 0, 10);
PrintArray(array);
PrintSortArray(array);

// ---Заполнение массива---
int[,] GetArray(int m, int n, int min, int max)
{
    int[,] res = new int[m,n];

    for (int i = 0; i < m; i++) {
        for(int j = 0; j < n; j++) {
            res[i, j] = new Random().Next(min, max);
        }
    }
    return res;
}

// ---Вывод массива---
void PrintArray(int[,] array)
{
    Console.WriteLine("Текущий массив:");

    for(int i = 0; i < array.GetLength(0); i++) {
        for(int j = 0; j < array.GetLength(1); j++) {
            Console.Write($"{array[i,j]} ");
        }
        Console.WriteLine();
    }
}

// ---Вывод отсортированного массива---
void PrintSortArray(int[,] array)
{
    int[] workArray = new int[array.GetLength(1)];

    Console.WriteLine("Отсортированный массив:");

    for(int m = 0; m < array.GetLength(0); m++) {
        for(int n = 0; n < array.GetLength(1); n++) {
            workArray[n] = array[m,n];
        }
        Console.WriteLine($"{String.Join(" ", SortArrayFromMaxToMin(workArray))}");
    }
}

int[] SortArrayFromMaxToMin(int[] array)
{
    int aLength = array.Length;
    int max = 0;
    int temp = 0;

    for(int i = 0; i < aLength - 1; i++) {
        max = i;
        for(int j = i + 1; j < aLength; j++) {
            if(array[j] > array[max]) max = j;
            }
        temp = array[i];
        array[i] = array[max];
        array[max] = temp;
        }
    return array;
}
//*/

/*/
// Задача 57: Составить частотный словарь элементов двумерного массива. 
// Частотный словарь содержит информацию о том, сколько раз встречается элемент входных данных.

// 1, 2, 3
// 4, 6, 1
// 2, 1, 6

// 1 встречается 3 раза
// 2 встречается 2 раз
// 3 встречается 1 раз
// 4 встречается 1 раз
// 6 встречается 2 раза

Console.Write("Введите количество строк: ");
int rows = int.Parse(Console.ReadLine()!);

Console.Write("Введите количество столбцов: ");
int columns = int.Parse(Console.ReadLine()!);

Console.Write("Введите минимальное число: ");
int minNumber = int.Parse(Console.ReadLine()!);

Console.Write("Введите максимальное число: ");
int maxNumber = int.Parse(Console.ReadLine()!);

int[,] array = GetArray(rows, columns, minNumber, maxNumber);
int[] arrayCount = CountingNumbers(array, minNumber, maxNumber);
PrintArray(array);
PrintCounts(arrayCount, minNumber, maxNumber);

// ---Заполнение массива---
int[,] GetArray(int m, int n, int min, int max)
{
    int[,] res = new int[m,n];

    for (int i = 0; i < m; i++) {
        for(int j = 0; j < n; j++) {
            res[i, j] = new Random().Next(min, max);
        }
    }
    return res;
}

// ---Вывод массива---
void PrintArray(int[,] array)
{
    for(int i = 0; i < array.GetLength(0); i++) {
        for(int j = 0; j < array.GetLength(1); j++) {
            Console.Write($"{array[i,j]} ");
        }
        Console.WriteLine();
    }
}

int[] CountingNumbers(int[,] array, int minNumber, int maxNumber)
{
    int maxIndex = maxNumber - minNumber;
    int minIndex = 0;
    int[] count = new int[maxIndex + 1];

    for (int i = 0; i < array.GetLength(0); i++) {
        for(int j = 0; j < array.GetLength(1); j++) {
            for(int k = minIndex; k < maxIndex; k++) {
                if(array[i,j] == k + minNumber) count[k]++;
            }
        }
    }
    return count;
}

void PrintCounts(int[] count, int minNumber, int maxNumber)
{
    int maxIndex = maxNumber - minNumber;
    int minIndex = 0;

    for(int i = minIndex; i < maxIndex; i++) {
        if(count[i] > 0) Console.WriteLine($"{i + minNumber} встречается {count[i]} раз(-а)");
    }
}
//*/

/*/
// Задача 58: Задайте две матрицы. Напишите программу, которая будет находить произведение двух матриц.
// Например, даны 2 матрицы:
// 2 4 | 3 4
// 3 2 | 3 3
// Результирующая матрица будет:
// 18 20
// 15 18

Console.Write("Введите количество строк: ");
int rows = int.Parse(Console.ReadLine()!);

Console.Write("Введите количество столбцов: ");
int columns = int.Parse(Console.ReadLine()!);

Console.Write("Введите минимальное число: ");
int minNumber = int.Parse(Console.ReadLine()!);

Console.Write("Введите максимальное число: ");
int maxNumber = int.Parse(Console.ReadLine()!);

int[,] arrayA = GetArray(rows, columns, minNumber, maxNumber);
int[,] arrayB = GetArray(rows, columns, minNumber, maxNumber);
Console.WriteLine();
Console.WriteLine("Матрица 1: ");
PrintArray(arrayA);
Console.WriteLine();
Console.WriteLine("Матрица 2: ");
PrintArray(arrayB);
Console.WriteLine();
Console.WriteLine("Результат перемножения матриц: ");
if(arrayA.GetLength(0) == arrayB.GetLength(1)) PrintArray(MultiMatrix(arrayA,arrayB));
else Console.WriteLine("Скалярное произведение матриц не определено!\nШирина первой матрицы и высота второй матрицы должны совпадать...");

// ---Заполнение массива---
int[,] GetArray(int m, int n, int min, int max)
{
    int[,] res = new int[m,n];

    for (int i = 0; i < m; i++) {
        for(int j = 0; j < n; j++) {
            res[i, j] = new Random().Next(min, max);
        }
    }
    return res;
}

// ---Вывод массива---
void PrintArray(int[,] array)
{
    for(int i = 0; i < array.GetLength(0); i++) {
        for(int j = 0; j < array.GetLength(1); j++) {
            Console.Write($"{array[i,j]} ");
        }
        Console.WriteLine();
    }
}

int[,] MultiMatrix(int[,] arrayA, int[,] arrayB)
{
    int[,] arrayC = new int[arrayA.GetLength(0), arrayA.GetLength(1)];
    int MatrixCell = 0;

    for (int i = 0; i < arrayC.GetLength(0); i++) {
        for(int j = 0; j < arrayC.GetLength(1); j++) {
            for(int k = 0; k < arrayA.GetLength(0); k++) {
                MatrixCell += arrayA[i,k] * arrayB[k,j];
            }
            arrayC[i,j] = MatrixCell;
            MatrixCell = 0;
        }
    }
    return arrayC;
}
//*/

/*/
// Задача 60. ...Сформируйте трёхмерный массив из неповторяющихся двузначных чисел. Напишите программу, которая будет построчно выводить массив, добавляя индексы каждого элемента.
// Массив размером 2 x 2 x 2
// 66(0,0,0) 25(0,1,0)
// 34(1,0,0) 41(1,1,0)
// 27(0,0,1) 90(0,1,1)
// 26(1,0,1) 55(1,1,1)

Console.Write("Введите количество строк: ");
int rows = int.Parse(Console.ReadLine()!);

Console.Write("Введите количество столбцов: ");
int columns = int.Parse(Console.ReadLine()!);

Console.Write("Введите значение глубины массива: ");
int depth = int.Parse(Console.ReadLine()!);

Console.Write("Введите минимальное значение: "); // 10 для двузначного диапазона!!!
int min = int.Parse(Console.ReadLine()!);

Console.Write("Введите максимальное значение: "); // 100 для двузначного диапазона!!!
int max = int.Parse(Console.ReadLine()!);

if((max - min) / (rows * columns * depth) > 0) {
    PrintArray(GetArray(rows, columns, depth, min, max));
    } else {
        Console.WriteLine("Невозможно заполнить трехмерный массив данного размера уникальными двузначными числами!");
        }

// ---Заполнение массива---
int[,,] GetArray(int m, int n, int p, int min, int max)
{
    int uniqueNum = 0;
    int indexUnique = 0;
    int uniqueCount = 0;
    int testLength = m * n * p;
    int[,,] res = new int[m, n, p];
    int[] unique = new int[testLength];
    int stepRandom = (max - min) / testLength;

    while(indexUnique < unique.Length) {
        max = min + stepRandom;
        uniqueNum = new Random().Next(min, max);
        min += stepRandom;
        unique[indexUnique] = uniqueNum;
        indexUnique++;
    }

    for (int i = 0; i < m; i++) {
        for(int j = 0; j < n; j++) {
            for(int k = 0; k < p; k++) {
                res[i, j, k] = unique[uniqueCount];
                uniqueCount++;
            }
        }
    }

    return res;
}

// ---Вывод массива---
void PrintArray(int[,,] array)
{
    for(int i = 0; i < array.GetLength(0); i++) {
        for(int j = 0; j < array.GetLength(1); j++) {
            Console.WriteLine();
            for(int k = 0; k < array.GetLength(2); k++) {
                Console.Write($"{array[i, j, k]}({String.Join(", ", i, j, k)}) ");
            }
            
        }
    }
}
//*/

//*/
// Задача 62. Напишите программу, которая заполнит спирально массив 4 на 4.
// Например, на выходе получается вот такой массив:
// 01 02 03 04
// 12 13 14 05
// 11 16 15 06
// 10 09 08 07

Console.Write("Введите количество строк: ");
int rows = int.Parse(Console.ReadLine()!);

Console.Write("Введите количество столбцов: ");
int columns = int.Parse(Console.ReadLine()!);

PrintArray(GetArray(rows, columns));

// ---Заполнение массива---
int[,] GetArray(int rows, int columns)
{
    int[,] array = new int[rows, columns];
    int spiralLength = rows * columns;
    int runner = 1;
    int horStart = 0;
    int vertStart = 0;
    int changeDirection = 0;
    int currentDirection = 0;
    int iterator = 0;
    int move = 0;

    changeDirection = rows >= columns ? 2 * columns - 1 : 2 * (rows - 1);

    do {
        switch (currentDirection) {
            case 0:
                for(int i = horStart; i < columns - 1; i++) {
                    if(array[vertStart + move, i] == 0) {
                        array[vertStart + move, i] = runner;
                        runner++;
                        }
                }
                iterator++;
                currentDirection = 1;
                break;
            case 1: 
                for(int i = vertStart; i < rows - 1; i++) {
                    if(array[i, columns - move - 1] == 0) {
                        array[i, columns - move - 1] = runner;
                        runner++;
                        }
                }
                iterator++;
                currentDirection = 2;
                break;
            case 2:
                for(int i = columns - 1; i > horStart; i--) {
                    if(array[rows - move - 1, i] == 0) {
                        array[rows - move - 1, i] = runner;
                        runner++;
                        }
                }
                iterator++;
                currentDirection = 3;
                break;
            case 3: 
                for(int i = rows - 1; i > vertStart; i--) {
                    if(array[i, horStart + move] == 0) {
                        array[i, horStart + move] = runner;
                        runner++;
                        }
                }
                iterator++;
                currentDirection = 0;
                move++;
                break;
        }

    }
    while(iterator <= changeDirection);

    return array;
}

void PrintArray(int[,] array)
{
    for(int i = 0; i < array.GetLength(0); i++) {
        Console.WriteLine();
        for(int j = 0; j < array.GetLength(1); j++) {
            if(array[i, j] < 10){
                Console.Write($"0{array[i, j]}");
            } else {
                Console.Write($"{array[i, j]}");
                }
            Console.Write(" ");
        }
    }
}
//*/
