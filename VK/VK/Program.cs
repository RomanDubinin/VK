using System;
using VkAutorization;

namespace VK
{
	class Program
	{

		[STAThread]
		static void Main(string[] args)
		{
			//WebClient
			var appId = 5211114;
			var sope = 4096;
			var version = "5.28";

			var token = Autorizator.GetAccessToken(appId, sope, version);

			Console.WriteLine("------");
			Console.WriteLine(token);
			Console.WriteLine("token eba");

			var api = new VkApi(token);
			var a = api.Get("messages.get", "out=0");
			var messages = api.JsToMessages(a);
			foreach (var message in messages)
			{
				Console.WriteLine(message.Body);
			}

			Console.ReadKey();
		}
	}
}
