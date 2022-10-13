using System;
using System.Collections.Generic;
using System.Linq;

namespace ega_lab8;

internal static class Program
{
	private static void Main()
	{
		var items = new List<Item>
		{
			new(3, 5), new(2, 1), new(3, 4)
		};
		const int capacity = 9;

		var solution = GreedyMethod.FindSolution(items, capacity).ToList();

		Console.WriteLine($"Решение: [{string.Join(" ", solution)}], ценность: {SolutionValue(solution, items)}");
	}

	private static int SolutionValue(IReadOnlyList<bool> solution, IEnumerable<Item> items)
	{
		return items.Where((_, i) => solution[i]).Sum(t => t.Value);
	}
}
