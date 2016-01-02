
using System.Windows.Forms;

namespace VkAutorization
{
	public static class Autorizator
	{
		public static string GetAccessToken(int appId, int scope, string version)
		{
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);

			var oauth = new Oauth(appId, scope, version);
			Application.Run(oauth);

			return oauth.Token;
		}
	}
}