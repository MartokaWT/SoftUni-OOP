List<int> elements = Console.ReadLine()
	.Split()
	.Select(int.Parse)
	.ToList();
int exceptionsCount = 0;

while (exceptionsCount < 3)
{
	string[] command = Console.ReadLine().Split();
	try
	{
		ExecuteCommand(command, elements);
	}
	catch (IndexOutOfRangeException)
	{
		Console.WriteLine("The index does not exist!");
		exceptionsCount++;
	}
	catch (FormatException)
	{
		Console.WriteLine("The variable is not in the correct format!");
		exceptionsCount++;
	}
}
Console.WriteLine(string.Join(", ", elements));

static void ExecuteCommand(string[] command, List<int> elements)
{
	switch (command[0])
	{
		case "Replace":
			int replaceIndex = int.Parse(command[1]);
			int replaceElement = int.Parse(command[2]);

			if (replaceIndex < 0 || replaceIndex >= elements.Count)
				throw new IndexOutOfRangeException();

			elements[replaceIndex] = replaceElement;
			break;

		case "Print":
			int startIndex = int.Parse(command[1]);
			int endIndex = int.Parse(command[2]);

			if (startIndex < 0 || endIndex >= elements.Count)
				throw new IndexOutOfRangeException();

			List<int> subList = elements.GetRange(startIndex, endIndex - startIndex + 1);
			Console.WriteLine(string.Join(", ", subList));
			break;

		case "Show":
			int showIndex = int.Parse(command[1]);

			if (showIndex < 0 || showIndex >= elements.Count)
				throw new IndexOutOfRangeException();

			Console.WriteLine(elements[showIndex]);
			break;
	}
}