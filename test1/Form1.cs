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

namespace test1
{
    public partial class Form1 : Form
    {
        private static NLog.Logger logger = NLog.LogManager.GetCurrentClassLogger();

        private string ConsumerKey = "s7zFMoPYhnJAcnWW6Cnei2V4D";
        private string ConsumerSecret = "7F73bvXlGv2sD7OZ3DDHvoVJoYIjTcbolevFQbbjj26NAyCEh6";

        OAuth.OAuthSession OASession;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            logger.Info("Form_Loading");

            var tempPath = Environment.GetEnvironmentVariable("IzmoIzm1", System.EnvironmentVariableTarget.User);
            MessageBox.Show($"TEMP={tempPath}");

            OASession = OAuth.Authorize(ConsumerKey, ConsumerSecret);

        }

        private void InitializeVariable()
        {
            ConsumerKey = SettingManager.common.
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
            var tokens = CoreTweet.OAuth.GetTokens(OASession, txtPIN.Text);

            tokens.Statuses.Update(status => "test 1stTweet");
        }
    }
}
