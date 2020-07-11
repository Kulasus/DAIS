using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PollsDesktop.Forms
{
    public partial class AnswerDetails : Form
    {
        public AnswerDetails()
        {
            InitializeComponent();
        }

        private void AnswerDetails_Load(object sender, EventArgs e)
        {
            TbAnswerDetailsCreatinDate.Text = Session.SelectedAnswer.CreationDate.ToString();
            TbAnswerDetailsLogin.Text = Session.SelectedAnswer.UserLogin;
            TbAnswerDetailsText.Text = Session.SelectedAnswer.Text;
        }

        private void BtnAnswerDetailsBack_Click(object sender, EventArgs e)
        {

        }
    }
}
