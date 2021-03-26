using System;

namespace task_2803021
{
	/// <summary>
	/// Дана вещественная матрица А размерности n х m. Определить k — количество
	/// "особых" элементов массива А, считая его элемент особым, если он больше суммы
	/// остальных элементов его столбца.
	/// </summary>
	/// <remarks>
	/// https://www.cyberforum.ru/csharp-beginners/thread2803021.html
	/// </remarks>
	internal class Program
	{
		private static void Main(string[] args)
		{
			var n = 5;
			var m = 9;
			var A = new int[n, m];

			FillMatrix(A);

			var columnsSum = CalculateColumnsSum(A);

			// необязательный метод вывода значений матрицы, сумм и уникальных чисел
			PrintMatrixWithSums(A, columnsSum);

			var k = CalculateUniqueValues(A, columnsSum);

			Console.WriteLine($"Количество \"особых\" элементов массива А равно: {k}");
			Console.ReadKey(false);
		}

		/// <summary>
		/// Определение количества "особых" элементов массива
		/// </summary>
		/// <param name="matrix"> матрица / массив </param>
		/// <param name="sums"> суммы по столбцам </param>
		/// <returns> </returns>
		private static int CalculateUniqueValues(int[,] matrix, int[] sums)
		{
			var k = 0;
			var longLength0 = matrix.GetLongLength(0);
			var sumsLength = sums.Length;

			for (var j = 0; j < sumsLength; j++)
			{
				for (var i = 0; i < longLength0; i++)
				{
					if (matrix[i, j] > sums[j])
					{
						k++;
					}
				}
			}

			return k;
		}

		/// <summary>
		/// Определение сумм по столбцам
		/// </summary>
		/// <param name="matrix"> матрица / массив </param>
		/// <returns> </returns>
		private static int[] CalculateColumnsSum(int[,] matrix)
		{
			var longLength0 = matrix.GetLongLength(0);
			var longLength1 = matrix.GetLongLength(1);

			var columnsSum = new int[longLength1];

			// здесь i - проход по строке
			// j - по колонке
			for (var j = 0; j < longLength1; j++)
			{
				for (var i = 0; i < longLength0; i++)
				{
					// проходим по столбцу j
					columnsSum[j] += matrix[i, j];
				}
			}

			return columnsSum;
		}

		/// <summary>
		/// Заполнение массива
		/// </summary>
		/// <param name="matrix"> матрица / массив </param>
		private static void FillMatrix(int[,] matrix)
		{
			var random = new Random();

			for (var i = 0; i < matrix.GetLongLength(0); i++)
			{
				for (var j = 0; j < matrix.GetLongLength(1); j++)
				{
					matrix[i, j] = random.Next(-100, 100);
				}
			}
		}

		/// <summary>
		/// Вывод значений массива в консоль c суммами и количеству уникальных чисел по
		/// колонкам
		/// </summary>
		/// <param name="matrix"> матрица / массив </param>
		/// <param name="sums"> суммы по столбцам </param>
		private static void PrintMatrixWithSums(int[,] matrix, int[] sums)
		{
			var longLength0 = matrix.GetLongLength(0);
			var longLength1 = matrix.GetLongLength(1);
			var sumsLength = sums.Length;

			for (var i = 0; i < longLength0; i++)
			{
				for (var j = 0; j < longLength1; j++)
				{
					Console.Write(matrix[i, j]);

					if (j + 1 != longLength1)
					{
						Console.Write("\t");
					}
				}

				Console.WriteLine();
			}

			Console.WriteLine("Суммы:");

			for (var i = 0; i < sumsLength; i++)
			{
				Console.Write(sums[i]);

				if (i + 1 != sumsLength)
				{
					Console.Write("\t");
				}
			}

			Console.WriteLine();
			Console.WriteLine("Количество уникальных чисел в столбце:");

			for (var j = 0; j < sumsLength; j++)
			{
				var k = 0;

				for (var i = 0; i < longLength0; i++)
				{
					if (matrix[i, j] > sums[j])
					{
						k++;
					}
				}

				Console.Write(k);

				if (j + 1 != sumsLength)
				{
					Console.Write("\t");
				}
			}

			Console.WriteLine();
		}
	}
}