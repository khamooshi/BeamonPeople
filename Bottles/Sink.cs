using System;
using System.Collections.Generic;
using System.Text;

namespace Bottles
{
	/// <summary>
	/// Sink is a bottle which is always empty with a huge capacity.
	/// </summary>
	public class Sink : Bottle
	{
		public Sink() : base(int.MaxValue, -2, 0)
		{
		}

		public override bool IsBottle => false;

		public override bool IsEmpty() => true;

		public override bool IsFull() => false;

		public override Step Empty() => throw new InvalidOperationException("Sink is always empty!");

		public override Step Fill() => throw new InvalidOperationException("Sink is always empty!");

		public override void AddWater(int litters)
		{
			return;
		}

		public override Bottle Clone() => new Sink();

		public override string ToString() => $"Sink";

		public override bool Equals(object obj) => obj is Sink;

		public override int GetHashCode() => HashCode.Combine(_index);
	}
}
