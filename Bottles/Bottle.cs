using System;
using System.Collections.Generic;
using System.Text;

namespace Bottles
{
	public class Bottle
	{
		private int _capacity;
		private int _amount;
		protected int _index;

		protected Bottle(int capacity, int index, int amount)
		{
			_index = index;
			_capacity = capacity;
			_amount = amount;
		}

		public Bottle(int capacity, int index) : this(capacity, index, 0)
		{

		}

		public virtual bool IsBottle => true;

		public virtual bool IsEmpty()
		{
			return _amount == 0;
		}

		public virtual bool IsFull()
		{
			return _capacity == _amount;
		}

		public virtual Step Empty()
		{
			var step = new Step(_index, -1, _amount);
			_amount = 0;

			return step;
		}

		public virtual Step Fill()
		{
			_amount = _capacity;
			return new Step(-1, _index, _amount);
		}

		public Step Fill(Bottle targetBottle)
		{
			if (IsEmpty() || targetBottle.IsFull())
				return null;

			if (!IsBottle && !targetBottle.IsBottle)
				return null;

			var sourceAmount = Amount();
			var targetUllage = targetBottle.Ullage();
			if (sourceAmount <= targetUllage)
			{
				targetBottle.AddWater(sourceAmount);
				Empty();
				return new Step(_index, targetBottle._index, sourceAmount);
			}
			else
			{
				targetBottle.AddWater(targetUllage);
				AddWater(-targetUllage);
				return new Step(_index, targetBottle._index, targetUllage);
			}
		}

		public virtual int Amount()
		{
			return _amount;
		}

		public virtual int Ullage()
		{
			return _capacity - _amount;
		}

		public virtual void AddWater(int litters)
		{
			_amount += litters;
		}

		public virtual Bottle Clone()
		{
			return new Bottle(_capacity, _index, _amount);
		}

		public override string ToString()
		{
			return $"Bottle: {_index + 1}, Capacity: {_capacity}, Amount: {_amount}";
		}

		public override bool Equals(object obj)
		{
			if (obj is Bottle other)
				return other._capacity == _capacity && other._amount == _amount && other._index == _index;

			return false;
		}

		public override int GetHashCode()
		{
			return HashCode.Combine(_capacity, _amount, _index);
		}
	}
}
