int n = int.Parse(Console.ReadLine());
char[,] board = new char[n, n];

int playerRow = -1;
int playerCol = -1;
int initialAmount = 100;

for (int i = 0; i < n; i++)
{
	string row = Console.ReadLine();
	for (int j = 0; j < n; j++)
	{
		board[i, j] = row[j];
		if (row[j] == 'G')
		{
			playerRow = i;
			playerCol = j;
		}
	}
}

string command = Console.ReadLine();
while (command != "end")
{
	int newRow = playerRow;
	int newCol = playerCol;

	switch (command)
	{
		case "up":
			newRow--;
			break;
		case "down":
			newRow++;
			break;
		case "left":
			newCol--;
			break;
		case "right":
			newCol++;
			break;
	}

	if (newRow < 0 || newRow >= n || newCol < 0 || newCol >= n)
	{
		Console.WriteLine("Game over! You lost everything!");
		return;
	}

	char newPosition = board[newRow, newCol];

	if (newPosition == '-')
	{
		board[playerRow, playerCol] = '-';
		board[newRow, newCol] = 'G';
		playerRow = newRow;
		playerCol = newCol;
	}
	else if (newPosition == 'W')
	{
		initialAmount += 100;
		board[playerRow, playerCol] = '-';
		board[newRow, newCol] = 'G';
		playerRow = newRow;
		playerCol = newCol;
	}
	else if (newPosition == 'P')
	{
		initialAmount -= 200;
		if (initialAmount <= 0)
		{
			Console.WriteLine("Game over! You lost everything!");
			return;
		}
		board[playerRow, playerCol] = '-';
		board[newRow, newCol] = 'G';
		playerRow = newRow;
		playerCol = newCol;
	}
	else if (newPosition == 'J')
	{
		initialAmount += 100000;
		Console.WriteLine("You win the Jackpot!");
		break;
	}

	command = Console.ReadLine();
}

Console.WriteLine("End of the game. Total amount: " + initialAmount + "$");
board[playerRow, playerCol] = 'G';

for (int i = 0; i < n; i++)
{
	for (int j = 0; j < n; j++)
	{
		Console.Write(board[i, j]);
	}
	Console.WriteLine();
}