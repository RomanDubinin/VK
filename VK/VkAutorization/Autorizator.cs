
using System.Windows.Forms;

namespace VkAutorization
{
	public static class Autorizator
	{
		public static string GetAccessToken(int appId, int scope)
		{
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);

			var oauth = new Oauth(appId, scope);
			Application.Run(oauth);

			return oauth.Token;
		}
	}
}