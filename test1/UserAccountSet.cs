using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace test1
{
    class UserAccountSet
    {
        List<UserAccount> list = new List< UserAccount>();

        public UserAccount this[string id] => GetUserAccount(id);

        public UserAccount GetUserAccount(string ID)
        {
            if (list.Any(a=>string.Compare(a.ID,ID,true)==0))
                return list.Single(s => string.Compare(s.ID, ID, true) == 0);
            return null;
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
                list.Add(UnSerializeUserAccount(serializer, path));
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
        public void SerializeAccounts()
        {
            foreach (var ac in this.list)
            {
                SerializeAccount(ac);
            }
        }
        
        /// <summary>
        /// Serialize Save
        /// </summary>
        private void SerializeAccount(UserAccount account)
        {
            var dirPath = Properties.Settings.Default.AccountDirPath;

            string fileName = account.ID;

            System.Xml.Serialization.XmlSerializer serializer =
                new System.Xml.Serialization.XmlSerializer(typeof(UserAccount));
            System.IO.StreamWriter sw = new System.IO.StreamWriter(
                fileName, false, new System.Text.UTF8Encoding(false));
            serializer.Serialize(sw, account);
            sw.Close();
        }
    }
}
