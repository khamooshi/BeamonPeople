using System;
using System.Collections.Generic;
using System.Linq;

namespace Bottles
{
	public class Question
	{
		private List<State> _visitedStates = new List<State>();
		private Queue<State> _statesToCheck = new Queue<State>();

		private int _containersCount;

		public int TargetValue { get; }

		public Question(int[] bottles, int targetValue)
		{
			if (bottles.Any(b => b <= 0 || b == int.MaxValue))
				throw new FormatException("Capacity should be a positive number!");

			_containersCount = bottles.Length + 2; // bathtub and sink
			
			var containers = bottles.Select((b, i) => new Bottle(b, i)).ToList();
			containers.Insert(0, new Bathtub());
			containers.Add(new Sink());

			TargetValue = targetValue;

			var steps = new List<Step>();
			_statesToCheck.Enqueue(new State(containers, steps));
		}

		/// <summary>
		/// Breadth First Search for finding the solution with minimum steps
		/// </summary>
		/// <returns>return the bottle states and the steps</returns>
		public State Solve()
		{
			while (_statesToCheck.TryDequeue(out State currentState))
			{
				if (_visitedStates.Any(v => v.Equals(currentState)))
					continue;
				else
					_visitedStates.Add(currentState);

				// go through all possible steps
				for (int i = 0; i < _containersCount; ++i)
				{
					for (int j = 0; j < _containersCount; ++j)
					{
						var newState = currentState.Clone();
						var bottles = newState.Bottles;
						var steps = newState.Steps;
						var sourceBottle = bottles[i];
						var targetBottle = bottles[j];

						// source bottle and target bottle are different
						if (i != j)
						{						
							var step = sourceBottle.Fill(targetBottle);

							if (step == null) // no water transmission happened, either source was emty or target was full
								continue;
								
							steps.Add(step);

							if (sourceBottle.Amount() == TargetValue || targetBottle.Amount() == TargetValue)
								return newState;

							_statesToCheck.Enqueue(newState);
						}
					}
				}
			}

			// could not find any solution
			return null;
		}
	}
}
