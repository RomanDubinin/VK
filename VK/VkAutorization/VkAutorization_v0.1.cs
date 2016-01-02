using System;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace VkAutorization
{
	public partial class Oauth : Form
	{
		private readonly int AppId;
		private readonly int Scope;
		public string Token = "";

		public Oauth(int appId, int scope)
		{
			AppId = appId;
			Scope = scope;
			InitializeComponent();
		}

		private void Form1_Load(object sender, EventArgs e)
		{
			string url = String.Format("https://oauth.vk.com/authorize?client_id={0}&scope={1}&redirect_uri=https://oauth.vk.com/blank.html&display=popup&v=5.28&response_type=token&revoke=0", AppId, Scope);
			webBrowser.Navigate(url);
		}

		private void webBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
		{
			if (e.Url.ToString().IndexOf("access_token") != -1)
			{
				var myReg = new Regex(@"access_token=([\d\w]*)&", RegexOptions.IgnoreCase | RegexOptions.Singleline);
				var match = myReg.Match(e.Url.ToString());
				
				Token = match.Groups[1].ToString();
				Close();
			}
		}

		private void Oauth_FormClosing(object sender, FormClosingEventArgs e)
		{
			Application.Exit();
		}
	}
}
