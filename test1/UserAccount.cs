using CoreTweet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace test1
{
    public class UserAccount
    {
        public Tokens Tokens => _Tokens;

        private Tokens _Tokens=null;
        const string EncryptPass = @"https://github.com/IzmoIzmi";

        private UserAccount() { }
       
        /// <summary>
        /// After Decrypt
        /// </summary>
        public void DecryptInit()
        {
            //復号化
            if (!string.IsNullOrEmpty(this.HashAccessToken))
                this._AccessToken = Encrypt.DecryptString(this.HashAccessToken, EncryptPass);
            if (!string.IsNullOrEmpty(this.HashAccessTokenSecret))
                this._AccessTokenSecret = Encrypt.DecryptString(this.HashAccessTokenSecret, EncryptPass);
        }

        public UserAccount(Tokens tokens)
        {
            SetToken(tokens);
        }

        public void SetToken(string consumerKey, string consumerSecret)
        {
            SetToken(Tokens.Create(consumerKey, consumerSecret, this.AccessToken, this.AccessTokenSecret));
        }
        private void SetToken(Tokens token)
        {
            this._Tokens = token;
            this.ScreenName = _Tokens.ScreenName;
            this._AccessToken = _Tokens.AccessToken;
            this._AccessTokenSecret = _Tokens.AccessTokenSecret;

            //暗号化
            this.HashAccessToken = Encrypt.EncryptString(this._AccessToken, EncryptPass);
            this.HashAccessTokenSecret = Encrypt.EncryptString(this._AccessTokenSecret, EncryptPass);

        }

        /// <summary>
        /// @*****
        /// </summary>
        public string ScreenName { get; set; }


        [System.Xml.Serialization.XmlIgnore]
        public string AccessToken => _AccessToken;
        [System.Xml.Serialization.XmlIgnore]
        public string AccessTokenSecret => _AccessTokenSecret;
        private string _AccessToken = "";
        private string _AccessTokenSecret = "";

        public string HashAccessToken;
        public string HashAccessTokenSecret;

        public override string ToString() => ScreenName;

        public void Save()
        {
            UserAccountSerializer.SerializeAccount(this);
        }

    }

    class UserAccountSerializer
    {
        /// <summary>
        /// Serialize Save
        /// </summary>
        static public void SerializeAccount(UserAccount account)
        {
            var dirPath = Properties.Settings.Default.AccountDirPath;

            string fileName = System.IO.Path.Combine(dirPath, account.ScreenName);

            System.IO.Directory.CreateDirectory(dirPath);

            System.Xml.Serialization.XmlSerializer serializer =
                new System.Xml.Serialization.XmlSerializer(typeof(UserAccount));
            System.IO.StreamWriter sw = new System.IO.StreamWriter(
                fileName, false, new System.Text.UTF8Encoding(false));
            serializer.Serialize(sw, account);
            sw.Close();
        }

    }

}
