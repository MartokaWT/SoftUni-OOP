try
{
	int num = int.Parse(Console.ReadLine());
	if (num < 0)
	{
		throw new ArgumentOutOfRangeException();
	}
	int squared = (int)Math.Sqrt(num);
	Console.WriteLine(squared);
}
catch (FormatException)
{
	Console.WriteLine("Invalid number");
}
catch (ArgumentOutOfRangeException)
{
	Console.WriteLine("Invalid number.");
}
finally
{
	Console.WriteLine("Goodbye.");
}