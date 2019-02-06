using CoreTweet;
using System.Collections.Generic;
using System.Linq;

namespace test1
{
    class UserAccountSet
    {
        List<UserAccount> list = new List<UserAccount>();

        public UserAccount GetAccount(string ScreenName, string consumerKey, string consumerSecret)
        {
            var account = list.SingleOrDefault(s => string.Compare(s.ScreenName, ScreenName, true) == 0);
            if (account != null && account.Tokens==null) account.SetToken(consumerKey, consumerSecret);

            return account;
        }
        public UserAccount GetAccount(string ScreenName, OAuth.OAuthSession oAuth)
        {
            return GetAccount(ScreenName, oAuth.ConsumerKey, oAuth.ConsumerSecret);
        }

        public void AddAccount(OAuth.OAuthSession oAuth, string PINCode)
        {
            var tokens = CoreTweet.OAuth.GetTokens(oAuth, PINCode);
            var account = new UserAccount(tokens);
            Add(account);
        }
        private void Add(UserAccount account)
        {
            list.RemoveAll(a => string.Compare(a.ScreenName, account.ScreenName, true) == 0);
            list.Add(account);
        }


        /// <summary>
        /// Serialize Load All
        /// </summary>
        /// <returns></returns>
        public void UnSerializeAllAccountData()
        {
            var dirPath = Properties.Settings.Default.AccountDirPath;

            if (!System.IO.Directory.Exists(dirPath)) return;

            System.Xml.Serialization.XmlSerializer serializer =
                new System.Xml.Serialization.XmlSerializer(typeof(UserAccountData));

            list.Clear();
            foreach (var path in System.IO.Directory.GetFiles(dirPath))
            {
                var tmp = UnSerializeAccountData(serializer, path);
                list.Add(new UserAccount(tmp));
            }
        }

        /// <summary>
        /// Serialize Load
        /// </summary>
        private UserAccountData UnSerializeAccountData(System.Xml.Serialization.XmlSerializer serializer, string fileName)
        {
            System.IO.StreamReader sr = new System.IO.StreamReader(
                fileName, new System.Text.UTF8Encoding(false));
            UserAccountData account = (UserAccountData)serializer.Deserialize(sr);
            sr.Close();

            return account;
        }

        /// <summary>
        /// Serialize Save All
        /// </summary>
        public void SerializeAllAccountData()
        {
            foreach (var ac in this.list)
            {
                if(ac.Tokens!=null)
                    SerializeAccountData(ac.GetXmlData());
            }
        }

        /// <summary>
        /// Serialize Save
        /// </summary>
        static public void SerializeAccountData(UserAccountData data)
        {
            var dirPath = Properties.Settings.Default.AccountDirPath;

            string fileName = System.IO.Path.Combine(dirPath, data.ScreenName);

            System.IO.Directory.CreateDirectory(dirPath);

            System.Xml.Serialization.XmlSerializer serializer =
                new System.Xml.Serialization.XmlSerializer(typeof(UserAccountData));
            System.IO.StreamWriter sw = new System.IO.StreamWriter(
                fileName, false, new System.Text.UTF8Encoding(false));
            serializer.Serialize(sw, data);
            sw.Close();
        }

    }
}
