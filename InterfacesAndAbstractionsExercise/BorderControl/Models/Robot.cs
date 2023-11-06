using BorderControl.Models.Interface;

namespace BorderControl.Models
{
	public class Robot : IIdentifiable
	{
		private string id;
		private string model;

		public Robot(string id, string model)
		{
			Id = id;
			Model = model;
		}

		public string Id { get; private set; }

		public string Model { get; private set; }
	}
}