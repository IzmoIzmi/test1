using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace test1
{
    public partial class TwiPicFrame : Form
    {
        readonly CoreTweet.Status status;
        readonly CoreTweet.Tokens token;

        public TwiPicFrame(CoreTweet.Status status, CoreTweet.Tokens token)
        {
            InitializeComponent();
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;

            this.status = status;
            this.token = token;
        }

        private async void TwiPicFrame_Load(object sender, EventArgs e)
        {
            labFavorite.Text = (status.FavoriteCount ?? 0).ToString();
            labRetweet.Text = (status.RetweetCount ?? 0).ToString();

            var replySearchTask = token.Search.TweetsAsync(q=> "-RT "+"@"+status.User.ScreenName, count=>100, since_id=>status.Id);

            if (status.Entities.Media != null)
            {
                pictureBox1.ImageLocation = status.Entities.Media[0].MediaUrl;
            }

            labReply.Text = (await replySearchTask).Where(w => w.InReplyToStatusId == status.Id)
                                                   .Count().ToString();
        }
    }
}
