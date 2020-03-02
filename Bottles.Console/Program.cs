using System;
using System.Collections.Generic;

namespace Bottles
{
	public class Program
	{
		static void Main(string[] args)
		{
			var bottles = new List<int>();

			while (true)
			{
				Console.WriteLine("Hello!");
				Console.WriteLine("Enter the number of bottles!");

				var line = Console.ReadLine();
				if (int.TryParse(line, out int count) && count > 0)
				{
					Console.WriteLine($"Please now enter {count} integer numbers, corrospond to the bottle capacities.");

					var capacities = new int[count];
					for (int i = 0; i < count; i++)
					{
						line = Console.ReadLine();
						if (int.TryParse(line, out int capacity) && capacity > 0)
						{
							capacities[i] = capacity;
						}
						else
						{
							Console.WriteLine($"Could not convert {line} to a positive integer. Please try again!");
							i--;
						}
					}

					Console.WriteLine($"Please enter the desired amount of water that should be mesured.");
					line = Console.ReadLine();
					if (int.TryParse(line, out int target) && target > 0)
					{
						Console.WriteLine($"====================================================");
						Console.WriteLine($"Thank you! now the program trys to find a solution.");
						Console.WriteLine($"====================================================");
						Console.WriteLine();

						var question = new Question(capacities, target);
						var result = question.Solve();

						if (result == null)
						{
							Console.WriteLine($"There is no solution for the specified configuration.");
						}
						else
						{
							Console.WriteLine($"We found a solution:");
							Console.WriteLine();

							Console.WriteLine($"Here are the amounts in bottles after taking the steps:");
							foreach (var b in result.Bottles)
							{
								if (b.IsBottle)
									Console.WriteLine(b);
							}

							Console.WriteLine();
							Console.WriteLine(result.DescribeSteps());
						}

						Console.WriteLine();
					}
					else
					{
						Console.WriteLine($"Could not convert {line} to a positive integer. Please try again!");
						Console.ReadKey();
						break;
					}

				}
				else
				{
					Console.WriteLine($"Could not convert {line} to a positive integer. Please try again!");
					Console.ReadKey();
					break;
				}
			}

		}
	}
}
