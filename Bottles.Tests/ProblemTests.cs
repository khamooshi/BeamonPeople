using NUnit.Framework;
using System.Linq;

namespace Bottles.Tests
{
	public class ProblemTests
	{
		[Test]
		public void Its_possible_to_mesure_1_liters_with_a_bottle_with_capacity_of_1()
		{
			// arrange
			var finder = new Question(new int[] { 1 }, 1);

			// act
			var solution = finder.Solve();

			// assert
			Assert.IsNotNull(solution, "Solution is Empty!");
			Assert.AreEqual(1, solution.Steps.Count, "Expected number of steps is 1!");
			Assert.Greater(solution.Bottles.Count(b => b.Amount() == finder.TargetValue), 0, "None of the bottles has the target value!");
		}

		[Test]
		public void Its_possible_to_mesure_1_liters_with_bottles_of_capacities_3_and_5()
		{
			// arrange
			var finder = new Question(new int[] { 3, 5 }, 1);

			// act
			var solution = finder.Solve();

			// assert
			Assert.IsNotNull(solution, "Solution is Empty!");
			Assert.AreEqual(4, solution.Steps.Count, "Expected number of steps is 4!");
			Assert.Greater(solution.Bottles.Count(b => b.Amount() == finder.TargetValue), 0, "None of the bottles has the target value!");
			Assert.IsNotEmpty(solution.DescribeSteps());
		}

		[Test]
		public void Its_possible_to_mesure_4_liters_with_bottles_of_capacities_3_and_5()
		{
			// arrange
			var finder = new Question(new int[] { 3, 5 }, 4);

			// act
			var solution = finder.Solve();

			// assert
			Assert.IsNotNull(solution, "Solution is Empty!");
			Assert.AreEqual(6, solution.Steps.Count, "Expected number of steps is 6!");
			Assert.Greater(solution.Bottles.Count(b => b.Amount() == finder.TargetValue), 0, "None of the bottles has the target value!");
			Assert.IsNotEmpty(solution.DescribeSteps());
		}

		[Test]
		public void Its_possible_to_mesure_7_liters_with_bottles_of_capacities_3_5_and_8()
		{
			// arrange
			var finder = new Question(new int[] { 3, 5, 8 }, 7);

			// act
			var solution = finder.Solve();

			// assert
			Assert.IsNotNull(solution, "Solution is Empty!");
			Assert.AreEqual(5, solution.Steps.Count, "Expected number of steps is 5!");
			Assert.Greater(solution.Bottles.Count(b => b.Amount() == finder.TargetValue), 0, "None of the bottles has the target value!");
			Assert.IsNotEmpty(solution.DescribeSteps());
		}

		[Test]
		public void Its_not_possible_to_mesure_10_liters_with_bottles_of_capacities_3_and_5()
		{
			// arrange
			var finder = new Question(new int[] { 3, 5 }, 10);

			// act
			var solution = finder.Solve();

			// assert
			Assert.IsNull(solution, "Solution is not null!");
		}
	}
}