namespace ShoppingSpree.Models
{
	public class Person
	{
		private string name;
		private decimal money;
		private List<Product> bagOfProducts;

		public Person(string name, decimal money)
		{
			Name = name;
			Money = money;
			bagOfProducts = new List<Product>();
		}

		public string Name
		{
			get => name;
			set
			{
				if (string.IsNullOrWhiteSpace(value))
				{
					throw new ArgumentException("Name cannot be empty");
				}

				name = value;
			}
		}

		public decimal Money
		{
			get => money;
			private set
			{
				if (value < 0)
				{
					throw new ArgumentException("Money cannot be negative");
				}

				money = value;
			}
		}

		public string Add(Product product)
		{
			if (Money < product.Price)
			{
				return $"{Name} can't afford {product}";
			}

			bagOfProducts.Add(product);

			Money -= product.Price;

			return $"{Name} bought {product}";
		}

		public override string ToString()
		{
			string productsString = bagOfProducts.Any()
				 ? string.Join(", ", bagOfProducts)
				 : "Nothing bought";

			return $"{Name} - {productsString}";
		}
	}
}