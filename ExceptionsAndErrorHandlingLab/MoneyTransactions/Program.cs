Dictionary<int, double> accounts = Console.ReadLine()
			.Split(',')
			.Select(account =>
			{
				var parts = account.Split('-');
				return new { AccountNumber = int.Parse(parts[0]), Balance = double.Parse(parts[1]) };
			})
			.ToDictionary(acc => acc.AccountNumber, acc => acc.Balance);

string command;
while ((command = Console.ReadLine()) != "End")
{
	try
	{
		ExecuteCommand(command, accounts);
		Console.WriteLine("Enter another command");
	}
	catch (InvalidOperationException)
	{
		Console.WriteLine("Invalid command!");
		Console.WriteLine("Enter another command");
	}
	catch (KeyNotFoundException)
	{
		Console.WriteLine("Invalid account!");
		Console.WriteLine("Enter another command");
	}
	catch (ArgumentException e)
	{
		Console.WriteLine(e.Message);
		Console.WriteLine("Enter another command");
	}
}

static void ExecuteCommand(string command, Dictionary<int, double> accounts)
{
	string[] cmdArgs = command.Split();

	if (cmdArgs.Length != 3)
	{
		throw new InvalidOperationException();
	}

	string action = cmdArgs[0];
	int accountNumber = int.Parse(cmdArgs[1]);
	double amount = double.Parse(cmdArgs[2]);

	if (!accounts.ContainsKey(accountNumber))
	{
		throw new KeyNotFoundException();
	}

	switch (action)
	{
		case "Deposit":
			accounts[accountNumber] += amount;
			Console.WriteLine($"Account {accountNumber} has new balance: {accounts[accountNumber]:F2}");
			break;

		case "Withdraw":
			if (amount > accounts[accountNumber])
			{
				throw new ArgumentException("Insufficient balance!");
			}
			accounts[accountNumber] -= amount;
			Console.WriteLine($"Account {accountNumber} has new balance: {accounts[accountNumber]:F2}");
			break;

		default:
			throw new InvalidOperationException();
	}
}