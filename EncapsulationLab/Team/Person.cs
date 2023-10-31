namespace PersonsInfo
{
	public class Person
	{
		private string firstName;
		private string lastName;
		private int age;
		private decimal salary;
		private const string NameException = "{0} name cannot contain fewer than 3 symbols!";
		private const string AgeException = "{0} cannot be zero or negative integer!";
		private const string SalaryException = "{0} cannot be less than 650 leva!";

		public Person(string firstName, string lastName, int age, decimal salary)
		{
			FirstName = firstName;
			LastName = lastName;
			Age = age;
			Salary = salary;
		}

		public string FirstName
		{
			get => firstName;
			private set
			{
				if (value.Length < 3)
				{
					throw new ArgumentException(string.Format(NameException, nameof(FirstName)));
				}

				firstName = value;
			}
		}
		public string LastName
		{
			get => lastName;
			private set
			{
				if (value.Length < 3)
				{
					throw new ArgumentException(string.Format(NameException, nameof(LastName)));
				}

				lastName = value;
			}
		}
		public int Age
		{
			get => age;
			private set
			{
				if (value <= 0)
				{
					throw new ArgumentException(string.Format(AgeException, nameof(Age)));
				}

				age = value;
			}
		}
		public decimal Salary
		{
			get => salary;
			private set
			{
				if (value < 650)
				{
					throw new ArgumentException(string.Format(SalaryException, nameof(Salary)));
				}

				salary = value;
			}
		}
		public void IncreaseSalary(decimal percentage)
		{
			if (Age > 30)
			{
				Salary += Salary * percentage / 100;
			}
			else
			{
				Salary += Salary * percentage / 200;
			}
		}

		public override string ToString()
		{
			return $"{FirstName} {LastName} receives {Salary:f2} leva.";
		}
	}
}