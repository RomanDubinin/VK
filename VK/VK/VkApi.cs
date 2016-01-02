using System;
using System.Collections.Generic;
using System.IO;
using System.Net;

namespace VK
{
	class VkApi
	{
		private readonly string Token;

		public VkApi(string token)
		{
			Token = token;
		}

		private string GetStr(string source, string key)
		{
			int start = source.IndexOf(key) + key.Length + 2;
			string res = "\"";
			int i = start;
			while (!((source[i] == '"') && (source[i - 1] != '\\')))
				i++;
			return source.Substring(start, i - start);
		}

		private int GetInt(string source, string key)
		{
			int start = source.IndexOf(key) + key.Length + 1;
			string res = "";
			int i = start;
			while (source[i] != ',')
				i++;
			return Convert.ToInt32(source.Substring(start, i - start));
		}

		public string Get(string method, string param = "")
		{
			string url = "https://api.vk.com/method/" + method + "?" + param + String.Format("&v=5.28&access_token={0}", Token);
			var request = WebRequest.Create(url);
			var response = request.GetResponse();
			var stream = response.GetResponseStream();
			var reader = new StreamReader(stream);
			string result = reader.ReadToEnd();
			reader.Close();
			return result;
		}

		public List<VkMessage> JsToMessages(string json)
		{
			int start = json.IndexOf("[");
			int end = json.LastIndexOf("]");
			List<VkMessage> vk = new List<VkMessage>();
			foreach (string i in json.Substring(start, end - start)
				.Split(new string[] { "},{" }, StringSplitOptions.None))
			{
				string body;
				int id;
				bool chat = false;
				if (i.IndexOf("\"chat_id\"") == -1)
					id = GetInt(i, "\"user_id\"");
				else
				{
					chat = true;
					id = GetInt(i, "\"chat_id\"");
				}
				var messageId = GetInt(i, "\"id\"");
				body = GetStr(i, "\"body\"");
				vk.Add(new VkMessage(id, messageId, body, chat));
			}
			return vk;
		}


	}
}