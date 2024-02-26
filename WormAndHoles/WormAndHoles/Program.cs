using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
	static void Main()
	{
		List<int> worms = Console.ReadLine().Split().Select(int.Parse).ToList();
		List<int> holes = Console.ReadLine().Split().Select(int.Parse).ToList();

		int matchesCount = 0;

		for (int i = worms.Count - 1; i >= 0; i--)
		{
			if (holes.Count == 0)
				break;

			int worm = worms[i];

			if (worm <= 0)
			{
				worms.RemoveAt(i);
				continue;
			}

			int hole = holes[0];

			if (worm == hole)
			{
				matchesCount++;
				worms.RemoveAt(i);
				holes.RemoveAt(0);
			}
			else
			{
				holes.RemoveAt(0);
				worm -= 3;
				worms[i] = worm;
				i++;
			}
		}

		if (matchesCount > 0)
		{
			Console.WriteLine($"Matches: {matchesCount}");

			if (worms.Count == 0)
			{
				Console.WriteLine("Every worm found a suitable hole!");
			}
			else if (worms.Count > 0)
			{
				Console.WriteLine($"Worms left: {string.Join(", ", worms)}");
			}
			if (holes.Count == 0)
			{
				Console.WriteLine("Holes left: none");
			}
			else
			{
				Console.WriteLine($"Holes left: {holes.Count}");
			}
		}
		else
		{
			Console.WriteLine("There are no matches.");

			if (worms.Count > 0)
			{
				Console.WriteLine($"Worms left: {string.Join(", ", worms)}");
			}
			else
			{
				Console.WriteLine("Worms left: none");
			}

			if (holes.Count == 0)
			{
				Console.WriteLine("Holes left: none");
			}
			else
			{
				Console.WriteLine($"Holes left: {holes.Count}");
			}
		}
	}
}