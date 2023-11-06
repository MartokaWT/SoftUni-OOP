using BorderControl.Models.Interface;

namespace BorderControl.Models
{
	public class Citizen : IIdentifiable
	{
		private string id;
		private string name;
		private int age;

		public Citizen(string id, string name, int age)
		{
			Id = id;
			Name = name;
			Age = age;
		}

		public string Id { get; private set; }

		public string Name { get; private set; }

		public int Age { get; private set; }
	}
}