namespace ShoppingSpree.Models
{
	public class Product
	{
		private string name;
		private decimal price;

		public Product(string name, decimal price)
		{
			Name = name;
			Price = price;
		}

		public string Name
		{
			get => name;
		    private set
			{
				if (string.IsNullOrEmpty(value))
				{
					throw new ArgumentNullException("Name cannot be empty");
				}

				name = value;
			}
		}

		public decimal Price
		{
			get => price;
			private set
			{
				if (value <= 0)
				{
					throw new ArgumentException("Money cannot be negative");
				}

				price = value;
			}
		}

		public override string ToString()
		{
			return Name;
		}
	}
}