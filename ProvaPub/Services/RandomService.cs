namespace ProvaPub.Services
{
	public class RandomService
	{
		private Random random;
		public RandomService()
		{
			random = new Random(Guid.NewGuid().GetHashCode());
		}
		public int GetRandom()
		{
			return random.Next(100);
		}

	}

	/*
	 O problema de repetição de número ocorria pois sempre era gerado uma instância de random a partir da mesma seed,
	o que fazia com que o valor retornado fosse sempre o mesmo, para corrigir, utilizei apenas uma instância única de random.
	 */
}
