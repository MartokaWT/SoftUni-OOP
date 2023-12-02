
string input = Console.ReadLine();
string[] cardStrings = input.Split(',');

List<Card> validCards = new List<Card>();
List<string> invalidCards = new List<string>();

foreach (string cardString in cardStrings)
{
	string[] parts = cardString.Trim().Split(' ');

	try
	{
		if (parts.Length != 2)
		{
			throw new ArgumentException("Invalid card!");
		}

		string face = parts[0].ToUpper();
		string suit = parts[1].ToUpper();

		Card card = new Card(face, suit);
		validCards.Add(card);
	}
	catch (ArgumentException)
	{
		invalidCards.Add("Invalid card!");
	}
}

foreach (var invalidCard in invalidCards)
{
	Console.WriteLine(invalidCard);
}

foreach (Card card in validCards)
{
	Console.Write(card + " ");
}

class Card
{
	private string face;
	private string suit;

	public Card(string face, string suit)
	{
		SetFace(face);
		SetSuit(suit);
	}

	public string GetFace()
	{
		return face;
	}

	public string GetSuit()
	{
		return suit;
	}

	private void SetFace(string face)
	{
		string[] validFaces = { "2", "3", "4", "5", "6", "7", "8", "9", "10", "J", "Q", "K", "A" };

		if (Array.IndexOf(validFaces, face) == -1)
		{
			throw new ArgumentException("Invalid card!");
		}

		this.face = face;
	}

	private void SetSuit(string suit)
	{
		string[] validSuits = { "S", "H", "D", "C" };
		string[] suitSymbols = { "\u2660", "\u2665", "\u2666", "\u2663" };

		if (Array.IndexOf(validSuits, suit) == -1)
		{
			throw new ArgumentException("Invalid card!");
		}

		int index = Array.IndexOf(validSuits, suit);
		this.suit = suitSymbols[index];
	}

	public override string ToString()
	{
		return $"[{face}{suit}]";
	}
}