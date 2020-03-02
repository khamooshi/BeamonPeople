using System;

namespace Bottles
{
	/// <summary>
	/// Bathtub is a bottle which is always full with a huge amount of water.
	/// </summary>
	public class Bathtub : Bottle
	{
		public Bathtub() : base(int.MaxValue, -1, int.MaxValue)
		{
		}

		public override bool IsBottle => false;

		public override bool IsEmpty() => false;

		public override bool IsFull() => true;

		public override Step Empty() => throw new InvalidOperationException("Bathtub is always full!");

		public override Step Fill() => throw new InvalidOperationException("Bathtub is always full!");

		public override void AddWater(int litters)
		{
			return;
		}

		public override Bottle Clone() => new Bathtub();

		public override string ToString() => $"Bathtub";

		public override bool Equals(object obj) => obj is Bathtub;

		public override int GetHashCode() => HashCode.Combine(_index);
	}
}
