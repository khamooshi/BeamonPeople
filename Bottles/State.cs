using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Bottles
{
	public class State
	{
		public List<Bottle> Bottles { get; }
		public List<Step> Steps { get; }

		public State(List<Bottle> bottles, List<Step> steps)
		{
			Bottles = bottles;
			Steps = steps;
		}

		public State Clone()
		{
			return new State(
				Bottles.Select(b => b.Clone()).ToList(), 
				Steps.Select(s => s.Clone()).ToList());
		}

		public string DescribeSteps()
		{
			var result = new StringBuilder();
			result.AppendLine($"{Steps.Count} steps are needed in total, here are the Steps: ");

			for (int i = 0; i < Steps.Count; ++i)
				result.AppendLine($"Step {i + 1}: {Steps[i]}");

			return result.ToString();
		}

		/// <summary>
		/// Equality is defined based on the status of bottles and not the steps that has been taken to reach this status
		/// </summary>
		/// <param name="obj">the other state</param>
		/// <returns></returns>
		public override bool Equals(object obj)
		{
			if (obj is State otherState && otherState.Bottles != null && Bottles != null && otherState.Bottles.Count == Bottles.Count)
			{
				for (int i = 0; i < Bottles.Count; ++i)
					if (!Bottles[i].Equals(otherState.Bottles[i]))
						return false;

				return true;
			}

			return false;
		}

		public override int GetHashCode()
		{
			return HashCode.Combine(Bottles);
		}
	}
}
