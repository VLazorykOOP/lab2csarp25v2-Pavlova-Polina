namespace Lab2CSharp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Lab 2 CSharp");
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.InputEncoding = System.Text.Encoding.UTF8;

            Console.Write("Task1: ");
            Task1();
            Console.WriteLine();

            Console.Write("Task2: ");
            Task2();
            Console.WriteLine();

            Console.Write("Task3: ");
            Task3();
            Console.WriteLine();

            Console.Write("Task4: ");
            Task4();
            Console.WriteLine();
        }

        static void Task1()
        {
            Console.WriteLine("\n=== Завдання 1: Підрахунок елементів, що не потрапляють у заданий інтервал ===");
            Console.WriteLine("Використання одновимірного масиву:");
            OneDimensionalArraySolution();

            Console.WriteLine("\nВикористання двовимірного масиву:");
            TwoDimensionalArraySolution();
        }

        static void OneDimensionalArraySolution()
        {
            // Введення розміру масиву
            Console.Write("Введіть розмір одновимірного масиву: ");
            int n = int.Parse(Console.ReadLine());

            // Створення одновимірного масиву
            int[] array = new int[n];
            Random rand = new Random();

            // Заповнення масиву випадковими числами (приклад: від -10 до 10)
            Console.WriteLine("Одновимірний масив:");
            for (int i = 0; i < n; i++)
            {
                array[i] = rand.Next(-10, 11);
                Console.Write(array[i] + " ");
            }
            Console.WriteLine();

            // Введення інтервалу [a, b]
            Console.Write("Введіть початок інтервалу (a): ");
            int a = int.Parse(Console.ReadLine());
            Console.Write("Введіть кінець інтервалу (b): ");
            int b = int.Parse(Console.ReadLine());

            // Підрахунок елементів, що не потрапляють у інтервал
            int count = 0;
            for (int i = 0; i < n; i++)
            {
                if (array[i] < a || array[i] > b)
                {
                    count++;
                }
            }

            // Виведення результату
            Console.WriteLine($"Кількість елементів, що не потрапляють у інтервал [{a}, {b}]: {count}");
        }

        static void TwoDimensionalArraySolution()
        {
            // Введення розміру двовимірного масиву (n x n)
            Console.Write("Введіть розмір двовимірного масиву (n x n): ");
            int n = int.Parse(Console.ReadLine());

            // Створення двовимірного масиву
            int[,] array = new int[n, n];
            Random rand = new Random();

            // Заповнення масиву випадковими числами (приклад: від -10 до 10)
            Console.WriteLine("Двовимірний масив:");
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    array[i, j] = rand.Next(-10, 11);
                    Console.Write(array[i, j] + " ");
                }
                Console.WriteLine();
            }

            // Введення інтервалу [a, b]
            Console.Write("Введіть початок інтервалу (a): ");
            int a = int.Parse(Console.ReadLine());
            Console.Write("Введіть кінець інтервалу (b): ");
            int b = int.Parse(Console.ReadLine());

            // Підрахунок елементів, що не потрапляють у інтервал
            int count = 0;
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (array[i, j] < a || array[i, j] > b)
                    {
                        count++;
                    }
                }
            }

            // Виведення результату
            Console.WriteLine($"Кількість елементів, що не потрапляють у інтервал [{a}, {b}]: {count}");
        }

        static void Task2()
        {
            Console.WriteLine("\n=== Завдання 2: Знайти номер останнього мінімального елемента ===");

            // Введення розміру масиву
            Console.Write("Введіть розмір одновимірного масиву: ");
            int n = int.Parse(Console.ReadLine());

            // Створення одновимірного масиву з дійсними числами
            double[] array = new double[n];
            Random rand = new Random();

            // Заповнення масиву випадковими дійсними числами (приклад: від -10.0 до 10.0)
            Console.WriteLine("Масив:");
            for (int i = 0; i < n; i++)
            {
                array[i] = rand.NextDouble() * 20 - 10; // Числа від -10.0 до 10.0
                Console.Write($"{array[i]:F2} "); // Виведення з двома знаками після коми
            }
            Console.WriteLine();

            // Пошук останнього мінімального елемента
            double minValue = array[0];
            int lastMinIndex = 0;

            for (int i = 1; i < n; i++)
            {
                if (array[i] <= minValue) // Використовуємо <=, щоб знайти останній випадок
                {
                    minValue = array[i];
                    lastMinIndex = i;
                }
            }

            // Виведення результату
            Console.WriteLine($"Останній мінімальний елемент: {minValue:F2}");
            Console.WriteLine($"Його номер (індекс): {lastMinIndex}");
        }

        static void Task3()
        {
            Console.WriteLine("\n=== Завдання 3: Обчислити A^n для матриці A ===");

            // Введення розміру матриці (n x n)
            Console.Write("Введіть розмір матриці (n x n): ");
            int n = int.Parse(Console.ReadLine());

            // Введення степеня n
            Console.Write("Введіть натуральний степінь n: ");
            int power = int.Parse(Console.ReadLine());

            if (power < 0)
            {
                Console.WriteLine("Степінь має бути натуральним числом (додатним).");
                return;
            }

            // Створення початкової матриці A
            int[,] matrixA = new int[n, n];
            Random rand = new Random();

            // Заповнення матриці A випадковими цілими числами (приклад: від -5 до 5)
            Console.WriteLine("Матриця A:");
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    matrixA[i, j] = rand.Next(-5, 6); // Цілі числа від -5 до 5
                    Console.Write(matrixA[i, j] + " ");
                }
                Console.WriteLine();
            }

            // Обчислення A^n
            int[,] result = MatrixPower(matrixA, power, n);

            // Виведення результату
            Console.WriteLine($"\nМатриця A^{power}:");
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    Console.Write(result[i, j] + " ");
                }
                Console.WriteLine();
            }
        }

        static int[,] MatrixPower(int[,] matrix, int power, int n)
        {
            // Ініціалізація одиничної матриці для результату
            int[,] result = new int[n, n];
            for (int i = 0; i < n; i++)
                result[i, i] = 1;

            // Збереження копії початкової матриці
            int[,] tempMatrix = new int[n, n];
            Array.Copy(matrix, tempMatrix, matrix.Length);

            // Обчислення степеня через множення матриць
            while (power > 0)
            {
                if (power % 2 == 1)
                {
                    result = MultiplyMatrices(result, tempMatrix, n);
                }
                tempMatrix = MultiplyMatrices(tempMatrix, tempMatrix, n);
                power /= 2;
            }

            return result;
        }

        static int[,] MultiplyMatrices(int[,] a, int[,] b, int n)
        {
            int[,] result = new int[n, n];

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    int sum = 0;
                    for (int k = 0; k < n; k++)
                    {
                        sum += a[i, k] * b[k, j];
                    }
                    result[i, j] = sum;
                }
            }

            return result;
        }

        static void Task4()
        {
            Console.WriteLine("\n=== Завдання 4: Знайти суму елементів у межах k1 і k2 для кожного рядка східчастого масиву ===");

            // Введення кількості рядків
            Console.Write("Введіть кількість рядків (n): ");
            int n = int.Parse(Console.ReadLine());

            // Створення східчастого масиву
            int[][] jaggedArray = new int[n][];
            Random rand = new Random();

            // Введення кількості елементів для кожного рядка
            for (int i = 0; i < n; i++)
            {
                Console.Write($"Введіть кількість елементів для рядка {i + 1}: ");
                int m = int.Parse(Console.ReadLine());
                jaggedArray[i] = new int[m];
            }

            // Заповнення східчастого масиву випадковими числами (приклад: від -10 до 10)
            Console.WriteLine("Східчастий масив:");
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < jaggedArray[i].Length; j++)
                {
                    jaggedArray[i][j] = rand.Next(-10, 11);
                    Console.Write(jaggedArray[i][j] + " ");
                }
                Console.WriteLine();
            }

            // Введення меж індексів k1 і k2
            Console.Write("Введіть початковий індекс k1: ");
            int k1 = int.Parse(Console.ReadLine());
            Console.Write("Введіть кінцевий індекс k2: ");
            int k2 = int.Parse(Console.ReadLine());

            // Перевірка правильності введених індексів
            if (k1 < 0 || k2 >= jaggedArray.Max(x => x.Length) || k1 > k2)
            {
                Console.WriteLine("Неправильні індекси k1 або k2. Переконайтеся, що 0 <= k1 <= k2 < максимальна довжина рядка.");
                return;
            }

            // Обчислення сум для кожного рядка та збереження в новий масив
            double[] resultArray = new double[n];
            for (int i = 0; i < n; i++)
            {
                int sum = 0;
                for (int j = k1; j <= k2 && j < jaggedArray[i].Length; j++)
                {
                    sum += jaggedArray[i][j];
                }
                resultArray[i] = sum;
            }

            // Виведення результату
            Console.WriteLine("Суми елементів у межах k1 і k2 для кожного рядка:");
            for (int i = 0; i < n; i++)
            {
                Console.WriteLine($"Рядок {i + 1}: {resultArray[i]}");
            }
        }
    }
}