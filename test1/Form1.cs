using CoreTweet;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace test1
{
    public partial class Form1 : Form
    {
        private static NLog.Logger logger = NLog.LogManager.GetCurrentClassLogger();

        OAuth.OAuthSession OASession;
        UserAccountSet UserAccountSet;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            logger.Info("Form_Loading");

            UserAccountSet = new UserAccountSet();
            UserAccountSet.UnSerializeAccounts();

            CreateOAuthSession();
        }

        private void CreateOAuthSession()
        {
            var xmlDoc = new XmlDocument();
            xmlDoc.Load(@"AppSetting.xml");
            var ConsumerKey = xmlDoc.SelectSingleNode("Settings/ConsumerKey/text()").Value.ToString();
            var ConsumerSecret = xmlDoc.SelectSingleNode("Settings/ConsumerSecret/text()").Value.ToString();

            OASession = OAuth.Authorize(ConsumerKey, ConsumerSecret);
        }


        private void button1_ClickAsync(object sender, EventArgs e)
        {
            var url = OASession.AuthorizeUri; // -> user open in browser

            // ブラウザでTwitterアプリ連携認証ページを開く
            Process.Start(url.ToString());
        }

        private void txtPIN_TextChanged(object sender, EventArgs e)
        {
            //get pin
            try
            {
                var tokens = CoreTweet.OAuth.GetTokens(OASession, txtPIN.Text);
                var account = new UserAccount(tokens);
                UserAccountSet.Add(account);
            }
            catch (Exception ex)
            {
                Console.WriteLine( ex.Message);
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            UserAccountSet.SaveAll();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var user = UserAccountSet.GetUserAccount("IzmiIzmo", OASession);
            if (user == null) return;

            user.Tokens.Statuses.Update(status => "login!");
        }
    }
}
