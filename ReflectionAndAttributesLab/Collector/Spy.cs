using System.Reflection;
using System.Runtime.Intrinsics.X86;
using System.Text;

namespace Stealer
{
	public class Spy
	{
		public string CollectGettersAndSetters(string investigatedClass)
		{
			Type classType = Type.GetType(investigatedClass);
			MethodInfo[] classMethods = classType.GetMethods(BindingFlags.Instance 
				| BindingFlags.Public
				| BindingFlags.NonPublic);
			StringBuilder sb = new StringBuilder();

			foreach (MethodInfo method in classMethods.Where(m => m.Name.StartsWith("get")))
			{
				sb.AppendLine($"{method.Name} will return {method.ReturnType}");
			}
			foreach (MethodInfo method in classMethods.Where(m => m.Name.StartsWith("set")))
			{
				sb.AppendLine($"{method.Name} will set field of {method.GetParameters().First().ParameterType}");
			}
			return sb.ToString().Trim();
		}
	}
}