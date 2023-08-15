namespace Items.Services.Common
{
	using Interfaces;

	public class Helper : IHelper
	{
		public HashSet<int> GetRandNUniqueOfM(int n, int m)
		{
			HashSet<int> rands = new HashSet<int>(n);
			var rnd = new Random(DateTime.UtcNow.Ticks.GetHashCode());
			while (rands.Count < n)
			{
				rands.Add(rnd.Next(m));
			}

			return rands;
		}
	}
}
