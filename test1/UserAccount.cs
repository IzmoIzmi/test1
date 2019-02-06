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
       
        public UserAccount(UserAccountData data)
        {
            this._AccessToken = data.AccessToken;
            this._AccessTokenSecret = data.AccessTokenSecret;
            this.ScreenName = data.ScreenName;
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

            //tokens.UserId と tokens.ScreenName は Tokens.Create を使った場合、自動で取得されることはないとのこと
            var ures = Tokens.Account.VerifyCredentials();
            this._Tokens.ScreenName = ures.ScreenName;
            this._Tokens.UserId = (long)ures.Id;            

            this._AccessToken = _Tokens.AccessToken;
            this._AccessTokenSecret = _Tokens.AccessTokenSecret;
            this.ScreenName = _Tokens.ScreenName;
        }

        /// <summary>
        /// @*****
        /// </summary>
        public string ScreenName { get; private set; }


        [System.Xml.Serialization.XmlIgnore]
        public string AccessToken => _AccessToken;
        [System.Xml.Serialization.XmlIgnore]
        public string AccessTokenSecret => _AccessTokenSecret;
        private string _AccessToken = "";
        private string _AccessTokenSecret = "";

        public override string ToString() => ScreenName;

        public UserAccountData GetXmlData()=> new UserAccountData(_Tokens);
    }

    public struct UserAccountData
    {
        public string ScreenName;
        public string HashAccessToken;
        public string HashAccessTokenSecret;

        [System.Xml.Serialization.XmlIgnore]
        const string EncryptPass = @"https://github.com/IzmoIzmi";

        [System.Xml.Serialization.XmlIgnore]
        public string AccessToken
        {
            get
            {
                if (string.IsNullOrEmpty(this.HashAccessToken)) return null;
                return Encrypt.DecryptString(this.HashAccessToken, UserAccountData.EncryptPass);
            }
        }
        [System.Xml.Serialization.XmlIgnore]
        public string AccessTokenSecret
        {
            get
            {
                if (string.IsNullOrEmpty(this.HashAccessTokenSecret)) return null;
                return Encrypt.DecryptString(this.HashAccessTokenSecret, UserAccountData.EncryptPass);
            }
        }

        public UserAccountData(Tokens token)
        {
            this.ScreenName = token.ScreenName;
            this.HashAccessToken = Encrypt.EncryptString(token.AccessToken, UserAccountData.EncryptPass);
            this.HashAccessTokenSecret = Encrypt.EncryptString(token.AccessTokenSecret, UserAccountData.EncryptPass);
        }

    }

    

}
