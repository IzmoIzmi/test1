using CoreTweet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace test1
{
    class UserAccountSet
    {
        List<UserAccount> list = new List<UserAccount>();

        public UserAccount GetUserAccount(string ScreenName, string consumerKey, string consumerSecret)
        {
            var account = list.SingleOrDefault(s => string.Compare(s.ScreenName, ScreenName, true) == 0);
            if (account != null) account.SetToken(consumerKey, consumerSecret);

            return account;
        }
        public UserAccount GetUserAccount(string ID, OAuth.OAuthSession oAuth)
        {
            return GetUserAccount(ID, oAuth.ConsumerKey, oAuth.ConsumerSecret);
        }

        public void Add(UserAccount account)
        {
            list.RemoveAll(a => string.Compare(a.ScreenName, account.ScreenName, true) == 0);
            list.Add(account);
        }

        /// <summary>
        /// Serialize Load All
        /// </summary>
        /// <returns></returns>
        public void UnSerializeAccounts()
        {
            var dirPath = Properties.Settings.Default.AccountDirPath;

            if (!System.IO.Directory.Exists(dirPath)) return;

            System.Xml.Serialization.XmlSerializer serializer =
                new System.Xml.Serialization.XmlSerializer(typeof(UserAccount));

            foreach (var path in System.IO.Directory.GetFiles(dirPath))
            {
                var tmp = UnSerializeUserAccount(serializer, path);
                tmp.DecryptInit();
                list.Add(tmp);
            }
        }

        /// <summary>
        /// Serialize Load
        /// </summary>
        private UserAccount UnSerializeUserAccount(System.Xml.Serialization.XmlSerializer serializer, string fileName)
        {
            System.IO.StreamReader sr = new System.IO.StreamReader(
                fileName, new System.Text.UTF8Encoding(false));
            UserAccount account = (UserAccount)serializer.Deserialize(sr);
            sr.Close();

            return account;
        }

        /// <summary>
        /// Serialize Save All
        /// </summary>
        public void SaveAll()
        {
            foreach (var ac in this.list)
            {
                ac.Save();
            }
        }
        
    }
}
