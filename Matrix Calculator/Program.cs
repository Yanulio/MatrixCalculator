using System;

namespace Matrix_Calculator
{
    /// <summary>
    /// Основной и единственный класс программы.
    /// </summary>
    class Program
    {
        /// <summary>
        /// Точка входа.
        /// </summary>

        static void Main()
        {
            do
            {
                Console.Clear();
                Rules();
                bool check, secondCheck;
                int numLine, numColumn, numLineSecond, numColumnSecond;
                do
                {
                    string operation = Console.ReadLine();
                    check = true;
                    switch (operation)
                    {
                        case "1":
                            SizeOfSquaredMatrix(out numLine);
                            ChoosingGeneration(in numLine, in numLine, out int[,] matrix);
                            Console.WriteLine("След вашей матрицы: " + Trace(in matrix));
                            break;
                        case "2":
                            SizeOfNotSquaredMatrix(out numLine, out numColumn);
                            ChoosingGeneration(in numLine, in numColumn, out matrix);
                            Transposition(in numLine, in numColumn, in matrix);
                            break;
                        case "3":
                            Console.WriteLine("Давайте определим первую матрицу!");
                            SizeOfNotSquaredMatrix(out numLine, out numColumn);
                            ChoosingGeneration(in numLine, in numColumn, out matrix);
                            Console.WriteLine("Пришло время для второй матрицы!");
                            ChoosingGeneration(in numLine, in numColumn, out int[,] secondMatrix);
                            Add(in numLine, in numColumn, in matrix, in secondMatrix);
                            break;
                        case "4":
                            Console.WriteLine("Давайте определим первую матрицу!");
                            SizeOfNotSquaredMatrix(out numLine, out numColumn);
                            ChoosingGeneration(in numLine, in numColumn, out matrix);
                            Console.WriteLine("Пришло время для второй матрицы!");
                            ChoosingGeneration(in numLine, in numColumn, out secondMatrix);
                            Subtract(in numLine, in numColumn, in matrix, in secondMatrix);
                            break;
                        case "5":
                            do
                            {
                                secondCheck = true;
                                Console.WriteLine("Давайте определим первую матрицу!");
                                SizeOfNotSquaredMatrix(out numLine, out numColumn);
                                Console.WriteLine("Пришло время для второй матрицы!");
                                SizeOfNotSquaredMatrix(out numLineSecond, out numColumnSecond);
                                if (numColumn != numLineSecond)
                                {
                                    Console.WriteLine("Количество столбцов первой матрицы не совпадает с количеством строк второй!");
                                    Console.WriteLine("Попробуйте ввести размеры двух матриц заново.");
                                    secondCheck = false;
                                }
                            } while (secondCheck != true);
                            Console.WriteLine("Заполним элементы первой матрицы.");
                            ChoosingGeneration(in numLine, in numColumn, out matrix);
                            Console.WriteLine("Заполним элементы второй матрицы.");
                            ChoosingGeneration(in numLineSecond, in numColumnSecond, out secondMatrix);
                            MatricesMultiplication(in matrix, in secondMatrix);
                            break;
                        case "6":
                            SizeOfNotSquaredMatrix(out numLine, out numColumn);
                            ChoosingGeneration(in numLine, in numColumn, out matrix);
                            Multiplication(in numLine, in numColumn, in matrix);
                            break;
                        case "7":
                            SizeOfSquaredMatrix(out numLine);
                            ChoosingGeneration(in numLine, in numLine, out matrix);
                            Console.WriteLine("Определитель вашей матрицы: " + Determinant(matrix));
                            break;
                        default:
                            Console.WriteLine("Пожалуйста, попробуйте ввести операцию еще раз.");
                            check = false;
                            continue;
                    }
                } while (check != true);
                Console.WriteLine();
                Console.WriteLine("Чтобы выйти, нажмите кнопку escape. Чтобы начать заново, нажмите любую другую клавишу.");
            } while (Console.ReadKey(true).Key != ConsoleKey.Escape);
            Console.WriteLine("Окей, удачной вам контрольной работы по линалу во время сессионной недели :) До связи!");
        }

        /// <summary>
        /// Ввод размеров для квадратной матрицы (т.к некоторые операции требуют именно квадратную матрицу).
        /// Если введенное значение некорректно (т.е. больше 10, или меньше 1, или не является натуральным числом), 
        /// то программа попросит ввести значение еще раз (реализовано с do while).
        /// </summary>
        /// <param name="numLine">Количество строк и столбцов матрицы.</param>

        public static void SizeOfSquaredMatrix(out int numLine)
        {
            bool check;
            numLine = 0;
            Console.WriteLine("Пожалуйста, введите желаемый размер квадратной матрицы (от 1 до 10):");
            do
            {
                string numLineStr = Console.ReadLine();
                check = true;
                if ((!int.TryParse(numLineStr, out numLine)) || numLine > 10 || numLine < 1)
                {
                    Console.WriteLine("Ошибка в вводе размера матрицы, пожалуйста, попробуйте еще раз!");
                    check = false;
                    continue;
                }
            } while (check != true);
        }

        /// <summary>
        /// Ввод размеров матрицы, необязательно квадратной. Работает аналогично предыдущему методу.
        /// </summary>
        /// <param name="numLine">Количество строк матрицы.</param>
        /// <param name="numColumn">Количество столбцов матрицы.</param>

        public static void SizeOfNotSquaredMatrix(out int numLine, out int numColumn)
        {
            bool check;
            numLine = 0; numColumn = 0;
            Console.WriteLine("Пожалуйста, введите желаемое количество строк матрицы (от 1 до 10):");
            do
            {
                string numLineStr = Console.ReadLine();
                check = true;
                if ((!int.TryParse(numLineStr, out numLine)) || numLine > 10 || numLine < 1)
                //Проверка корректности введенного значения.
                {
                    Console.WriteLine("Ошибка в вводе количества строк, попробуйте ещё раз ввести желаемое количество строк!");
                    check = false;
                    continue;
                }
            } while (check != true);
            Console.WriteLine("Количество строк: " + numLine);
            Console.WriteLine("Пожалуйста, введите желаемое количество столбцов матрицы (от 1 до 10):");
            do
            {
                string numColumnStr = Console.ReadLine();
                check = true;
                if ((!int.TryParse(numColumnStr, out numColumn)) || numColumn > 10 || numColumn < 1)
                //Проверка корректности введенного значения.
                {
                    Console.WriteLine("Ошибка в вводе количества столбцов, попробуйте ещё раз ввести желаемое количество столбцов!");
                    Console.WriteLine("Количество строк останентся тем же, которое вы ввели ранее.");
                    check = false;
                    continue;
                }
            } while (check != true);
            Console.WriteLine("Количество столбцов: " + numColumn);
        }

        /// <summary>
        /// Создание матрицы и запись в нее случайных целых значений (от -50 до 50) с помощью цикла for.
        /// </summary>
        /// <param name="numLine">Количество строк матрицы.</param>
        /// <param name="numColumn">Количество столбцов матрицы.</param>
        /// <param name="matrix">Матрица.</param>

        public static void MakingARandomMatrix(in int numLine, in int numColumn, out int[,] matrix)
        {
            matrix = new int[numLine, numColumn];
            Random rnd = new Random();
            for(int i = 0; i < matrix.GetLength(0); i++)
            {
                for(int j = 0; j < matrix.GetLength(1); j++)
                {
                    matrix[i, j] = rnd.Next(-50, 51);
                    //Генерация случайного числа от -50 до 50.
                }
            }
            Console.WriteLine("Ваша матрица:");
            PrintMatrix(matrix);
        }

        /// <summary>
        /// Организует ввод элементов матрицы с консоли (целые числа от -50 до 50).
        /// </summary>
        /// <param name="numLine">Количество строк матрицы.</param>
        /// <param name="numColumn">Количество столбцов матрицы.</param>
        /// <param name="matrix">Матрица.</param>

        public static void MatrixInput(in int numLine, in int numColumn, out int[,] matrix)
        {
            matrix = new int[numLine, numColumn];
            bool check;
            Console.WriteLine("Введите значение первого элемента матрицы (от -50 до 50)");
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    do
                    {
                        check = true;
                        if ((!int.TryParse(Console.ReadLine(), out matrix[i, j])) || (matrix[i, j] < -50) || (matrix[i, j] > 50))
                        {
                            Console.WriteLine("Неправильная запись элемента матрицы, попробуйте снова!");
                            check = false;
                        }
                        else
                        {
                            Console.WriteLine("Введите следующий элемент матрицы.");
                        }
                    } while (check != true);
                }
            }
            Console.WriteLine("Ваша матрица:");
            PrintMatrix(matrix);
        }
  
        /// <summary>
        /// Вывод матрицы на экран циклом.
        /// </summary>
        /// <param name="matrix">Матрица.</param>
        
        public static void PrintMatrix(int[,] matrix)
        {
            for (int i = 0; i < matrix.GetLength(0); i++, Console.WriteLine())
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    Console.Write("{0,6}", matrix[i, j]);
                }
            }
        }

        /// <summary>
        /// Даёт выбрать пользователю способ генерации матрицы: сгенерировать ее случано, или ввести самостоятельно.
        /// </summary>
        /// <param name="numLine">Количество строк.</param>
        /// <param name="numColumn">Количество столбцов.</param>
        /// <param name="matrix">Матрица.</param>

        public static void ChoosingGeneration(in int numLine, in int numColumn, out int[,] matrix)
        {
            Console.WriteLine("Вы хотите задать элементы матрицы вручную, или сгенерировать их случайным образом?");
            Console.WriteLine("Напишите цифру 1 для ручного ввода или цифру 2 для случайной генерации (от -50 до 50).");
            bool check;
            matrix = new int[numLine, numColumn];
            do
            {
                check = true;
                string choice = Console.ReadLine();
                if (choice == "1")
                {
                    MatrixInput(in numLine, in numColumn, out matrix);
                }
                else if (choice == "2")
                {
                    MakingARandomMatrix(in numLine, in numColumn, out matrix);
                }
                else
                {
                    Console.WriteLine("Неверно введена команда, попробуйте еще раз.");
                    check = false;
                }
            } while (check != true);
            Console.WriteLine();
        }

        /// <summary>
        /// Метод, вычисляющий след матрицы.
        /// </summary>
        /// <param name="matrix">Матрица.</param>
        /// <returns></returns>

        public static int Trace(in int[,] matrix)
        {
            int traceSum = 0;
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(0); j++)
                {
                    if (i == j)
                        traceSum += matrix[i, j];
                        //Суммируем диагональные элементы.
                }
            }
            return traceSum;
        }

        /// <summary>
        /// Метод, транспонирующий матрицу и выводящий ее на экран.
        /// </summary>
        /// <param name="matrix">Начальная матрица.</param>
        /// <param name="numLine">Количество строк.</param>
        /// <param name="numColumn">Количество столбцов.</param>

        public static void Transposition(in int numLine, in int numColumn, in int[,] matrix)
        {
            int[,] matrixT = new int[numColumn, numLine];
            for(int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    matrixT[j, i] = matrix[i, j];
                    //Меняем местами строки и столбцы.
                }
            }
            Console.WriteLine("Ваша транспонированная матрица:");
            PrintMatrix(matrixT);
        }

        /// <summary>
        /// Метод, суммирующий элементы двух матриц.
        /// </summary>
        /// <param name="numLine">Количество строк.</param>
        /// <param name="numColumn">Количество столбцов.</param>
        /// <param name="matrix">Первая матрица.</param>
        /// <param name="secondMatrix">Вторая матрица.</param>

        public static void Add(in int numLine, in int numColumn, in int[,] matrix, in int[,] secondMatrix)
        {
            int[,] matrixSum = new int[numLine, numColumn];
            //Новый массив, являющийся суммой двух матриц.
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    matrixSum[i, j] = matrix[i, j] + secondMatrix[i, j];
                    //Присваиваем элементу итоговой матрицы сумму двух элементов исходных матриц.
                }
            }
            Console.WriteLine("Сумма ваших матриц:");
            PrintMatrix(matrixSum);
        }

        /// <summary>
        /// Метод, вычитающий из первой матрицы вторую.
        /// </summary>
        /// <param name="numLine">Количество строк.</param>
        /// <param name="numColumn">Количество столбцов.</param>
        /// <param name="matrix">Первая матрица.</param>
        /// <param name="secondMatrix">Вторая матрица.</param>

        public static void Subtract(in int numLine, in int numColumn, in int[,] matrix, in int[,] secondMatrix)
        {
            int[,] matrixDifference = new int[numLine, numColumn];
            //Новый массив, являющийся разностью двух матриц.
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    matrixDifference[i, j] = matrix[i, j] - secondMatrix[i, j];
                    //Присваиваем элементу итоговой матрицы разность двух элементов исходных матриц.
                }
            }
            Console.WriteLine("Разность ваших матриц:");
            PrintMatrix(matrixDifference);
        }

        /// <summary>
        /// Метод, умножающий каждый элемент матрицы на заданное пользователем число.
        /// </summary>
        /// <param name="numLine">Количество строк.</param>
        /// <param name="numColumn">Количество столбцов.</param>
        /// <param name="matrix">Матрица.</param>

        public static void Multiplication(in int numLine, in int numColumn, in int[,] matrix)
        {
            Console.WriteLine("Пожалуйста, введите число, на которое хотите умножить матрицу (-50 до 50)");
            bool check;
            int[,] matrixMultiplied = new int[numLine, numColumn];
            do
            {
                check = true;
                int number;
                if ((!int.TryParse(Console.ReadLine(), out number)) || (number > 100) || (number < -100))
                //Проверка корректности введенного числа.
                {
                    check = false;
                    Console.WriteLine("Пожалуйста, попробуйте ввести число снова");
                }
                else
                {
                    for (int i = 0; i < matrix.GetLength(0); i++)
                    {
                        for (int j = 0; j < matrix.GetLength(1); j++)
                        {
                            matrixMultiplied[i, j] = matrix[i, j] * number;
                            //Умножение элемента на число.
                        }
                    }
                }
            } while (check != true);
            Console.WriteLine();
            Console.WriteLine("Полученная матрица:");
            PrintMatrix(matrixMultiplied);
        }

        /// <summary>
        /// Метод, перемножающий две матрицы.
        /// </summary>
        /// <param name="matrix">Первая матрица.</param>
        /// <param name="secondMatrix">Вторая матрица.</param>

        public static void MatricesMultiplication(in int[,] matrix, in int[,] secondMatrix)
        {
            int[,] matricesMultiplication = new int[matrix.GetLength(0), secondMatrix.GetLength(1)];
            for(int i = 0; i < matrix.GetLength(0); i++)
            {
                for(int j = 0; j < secondMatrix.GetLength(1); j++)
                {
                    for (int k = 0; k < matrix.GetLength(1); k++)
                    {
                        matricesMultiplication[i, j] += matrix[i, k] * secondMatrix[k, j];
                        //Перемножаем элементы по определению умножения (лекция линала мне в помощь).
                    }
                }
            }
            Console.WriteLine("В результате умножения мы получим:");
            PrintMatrix(matricesMultiplication);
        }

        /// <summary>
        /// Метод получает необходимый минор матрицы.
        /// </summary>
        /// <param name="matrix">Матрица.</param>
        /// <param name="column">То, с какого столбца надо начинать сдвиг.</param>
        /// <returns>Минор.</returns>

        public static int[,] DeleteLineAndColumn(int[,] matrix, int column)
        {
            int[,] matrixRenewed = new int[matrix.GetLength(0) - 1, matrix.GetLength(0) - 1];
            //Массив для создания минора.
            for (int i = 0; i < matrix.GetLength(0) - 1; i++)
            {
                for (int j = 0; j < column; j++)
                    matrixRenewed[i, j] = matrix[i + 1, j];
                //До нужного нам столбца перезаписываем элемент так, чтобы первая строка уничтожилась.
                for (int j = column; j < matrix.GetLength(0) - 1; j++)
                    matrixRenewed[i, j] = matrix[i + 1, j + 1];
                //После нужного нам столбца перезаписываем, уничтожая и первую строку, и этот столбец.
            }
            return matrixRenewed;
        }

        /// <summary>
        /// Рекурсивный метод, вычисляющий определитель по первой строке с помощью миноров.
        /// </summary>
        /// <param name="matrix">Матрица.</param>
        /// <returns>Определитель.</returns>

        public static long Determinant(int[,] matrix)
        {
            if (matrix.GetLength(0) == 1)
                return matrix[0, 0];
            //Подсчет определителя, если остается один элемент.
            if (matrix.GetLength(0) == 2)
                return matrix[0, 0] * matrix[1, 1] - matrix[0, 1] * matrix[1, 0];
            //Подсчет определителя минора 2х2.
            long determinant = 0;
            for (int i = 0; i < matrix.GetLength(1); i++)
            {
                int[,] matrixRenewed = DeleteLineAndColumn(matrix, i);
                determinant += (int)Math.Pow(-1, i) * matrix[0, i] * Determinant(matrixRenewed);
                //Определяем знак (каждый нечетный столбец будет давать -1), умножаем на сам элемент и делаем рекурсию, чтобы дойти до минора 2х2.
            }
            return determinant;
        }

        /// <summary>
        /// Метод, выводящий на экран правила работы с калькулятором для пользователя.
        /// </summary>

        public static void Rules()
        {
            Console.WriteLine("Добро пожаловать в калькулятор матриц!");
            Console.WriteLine("- Зачем он нужен? - спросите вы.");
            Console.WriteLine("- Для домашек по линалу! - отвечу я.");
            Console.WriteLine("Вы можете произвести 7 различных операций:");
            Console.WriteLine("1. trace - вычислить след матрицы (только для квадратных).");
            Console.WriteLine("2. transposition - транспонировать матрицу.");
            Console.WriteLine("3. add - сложить две матрицы.");
            Console.WriteLine("4. subtract - вычесть из первой матрицы вторую.");
            Console.WriteLine("5. multiply matrices - умножить первую матрицу на вторую (количество столбцов первой должно быть равно");
            Console.WriteLine("количеству строк второй матрицы).");
            Console.WriteLine("6. multiply - умножить матрицу на число.");
            Console.WriteLine("7. determinant - посчитать определитель матрицы (только для квадратных).");
            Console.WriteLine("");
            Console.WriteLine("После выбора операции нужно будет ввести размеры матрицы.");
            Console.WriteLine("Далее, вы сможете ввести элементы матрицы самостоятельно, или сгенерировать ее случайным образом.");
            Console.WriteLine("Ввод матрицы проводится поэлементно, заполняя строки, т.е.");
            Console.WriteLine("сначала вводится элемент первой строки первого столбца, потом первой строки второго столбца и т.д.");
            Console.WriteLine("На ввод принимаются только целые значения от -50 до 50. Случайная генерация тоже будет в этом диапазоне.");
            Console.WriteLine("");
            Console.WriteLine("Отлично, можно приступать!");
            Console.WriteLine("Введите номер операции:");
        }

    }
}
