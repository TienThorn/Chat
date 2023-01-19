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
using Chat.Shared;
using Message = Chat.Shared.Message;

namespace Chat.Client
{
    public partial class ChatWindow : Form
    {
        private List<Message> _messages = new List<Message>();
        private string _currentUser;
        private Auth _auth;
        public ChatWindow(string sender, Auth auth)
        {
            _currentUser = sender;
            _auth = auth;
            InitializeComponent();
        }

        private async void ChatWindow_Load(object sender, EventArgs e)
        {
            await RefreshMessagesList();
        }
      
        private async void button1_Click(object sender, EventArgs e)
        {
            await ChatService.SendMessage(_currentUser, textBox2.Text);
            await RefreshMessagesList();
        }

        private async Task RefreshMessagesList()
        {
            textBox2.Text = "";
            textBox1.Text = "";
            label3.Text = "Вы зашли как: " + _currentUser;
            _messages = await ChatService.GetAllMessages();

            foreach (Message message in _messages)
            {
                textBox1.Text += message.ToString() + Environment.NewLine;
            }
        }

        private async void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            await LoginService.Logout(_currentUser);
            _auth.Show();
        }
    }
}
