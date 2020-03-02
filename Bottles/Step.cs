using System;
using System.Collections.Generic;
using System.Text;

namespace Bottles
{
	public class Step
	{
		private int _from;
		private int _to;
		private int _amount;

		public Step(int from, int to, int amount)
		{
			_from = from;
			_to = to;
			_amount = amount;
		}

		public Step Clone()
		{
			return new Step(_from, _to, _amount);
		}

		public override string ToString()
		{
			if(_from == -1)
				return $"Fill up bottle number {_to + 1} from the bathtub.";

			if(_to == -2)
				return $"Empty bottle number {_from + 1}.";

			return $"Add {_amount} litters from bottle number {_from + 1} to bottle number {_to + 1}.";
		}
	}
}
