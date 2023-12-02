//try
//{
//	int start = 1;
//	int end = 100;
//	int[] numbers = new int[10];

//	for (int i = 0; i < numbers.Length; i++)
//	{
//		numbers[i] = ReadNumber(start, end);
//		start = numbers[i];
//	}
//	Console.WriteLine(string.Join(", ", numbers));
//}
//catch (ArgumentOutOfRangeException ex)
//{
//	Console.WriteLine($"Your number is not in range 1 - 100!");
//}
//catch (FormatException ex)
//{
//	Console.WriteLine("Invalid Number!");
//}

//static int ReadNumber(int start, int end)
//{
//	int currentNumber = 0;

//	currentNumber = int.Parse(Console.ReadLine());

//	if (currentNumber <= start || currentNumber >= end)
//	{
//		throw new ArgumentOutOfRangeException();
//	}

//	return currentNumber;
//}

static int ReadNumber(int start, int end)
{
	int number;
	bool isValidNumber = int.TryParse(Console.ReadLine(), out number);

	if (!isValidNumber)
	{
		throw new FormatException();
	}

	if (number <= start || number >= end)
	{
		throw new ArgumentOutOfRangeException();
	}

	return number;
}

int[] numbers = new int[10];
int start = 1;
int end = 100;

int count = 0;
while (count < 10)
{
	try
	{
		int num = ReadNumber(start, end);
		if (num <= start || num >= end)
		{
			continue;
		}

		numbers[count] = num;
		start = numbers[count];
		count++;
	}
	catch (FormatException)
	{
		Console.WriteLine("Invalid Number!");
	}
	catch (ArgumentOutOfRangeException)
	{
		Console.WriteLine($"Your number is not in range {start} - {end}!");
	}
}

Console.WriteLine(string.Join(", ", numbers));