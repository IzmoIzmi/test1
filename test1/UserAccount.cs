using CoreTweet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace test1
{
    class UserAccount
    {
        public UserAccount(string consumerKey,string consumerSecret, string accessToken,string accessTokenSecret)
        {
            this._Tokens = Tokens.Create(consumerKey, consumerSecret, accessToken, accessTokenSecret);
           
        }

        public UserAccount(Tokens tokens)
        {
            this._Tokens = tokens;
        }

        private Tokens _Tokens;

        public string ID { get; set; }

        [System.Xml.Serialization.XmlIgnore]
        public string ConsumerKey => _ConsumerKey;
        [System.Xml.Serialization.XmlIgnore]
        public string ConsumerSecret => _ConsumerSecret;
        private string _ConsumerKey = "";
        private string _ConsumerSecret = "";

        public string HashConsumerKey;
        public string HashConsumerSecret;

        public override string ToString() => ID;

    }
}
