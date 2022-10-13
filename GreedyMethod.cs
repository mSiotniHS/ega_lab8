using System;
using System.Collections.Generic;
using System.Linq;

namespace ega_lab8;

public static class GreedyMethod
{
	public static IEnumerable<bool> FindSolution(List<Item> items, int capacity)
	{
		var solution = Enumerable.Repeat(false, items.Count).ToArray();
		var solutionWeight = 0;

		var tmpIdx = 0;
		var unusedItems = items.ToDictionary(_ => tmpIdx++);

		while (unusedItems.Count > 0 && solutionWeight < capacity)
		{
			Console.Write($"> Итерация №{items.Count - unusedItems.Count + 1} | ");
			Console.WriteLine($"Текущий набор: [{string.Join(" ", solution)}]");
			Console.WriteLine($"{new string(' ', 14)}| Вес/вместимость: {solutionWeight}/{capacity}");

			var (idx, mostValuable) = FindMostValuableItem(unusedItems);

			Console.WriteLine($"> Наиболее ценный предмет: {mostValuable}, №{idx}");

			if (solutionWeight + mostValuable.Weight <= capacity)
			{
				solution[idx] = true;
				solutionWeight += mostValuable.Weight;
				unusedItems.Remove(idx);
				Console.WriteLine($"> Можем положить в ранец. Тогда {solutionWeight}/{capacity}\n");
			}
			else
			{
				Console.WriteLine("> Не можем положить в ранец\n");
				break;
			}
		}

		return solution;
	}

	private static (int, Item) FindMostValuableItem(Dictionary<int, Item> items)
	{
		var mostValuableIdx = -1;
		var mostValuable = new Item(int.MinValue, int.MaxValue);
		foreach (var (idx, item) in items)
		{
			if (item.SpecificValue > mostValuable.SpecificValue)
			{
				mostValuable = item;
				mostValuableIdx = idx;
			}
		}

		return (mostValuableIdx, mostValuable);
	}
}
