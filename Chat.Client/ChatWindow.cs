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
        public ChatWindow()
        {
            InitializeComponent();
        }

        private async void ChatWindow_Load(object sender, EventArgs e)
        {
            await RefreshMessagesList();
        }
      
        private async void button1_Click(object sender, EventArgs e)
        {
            await ChatService.SendMessage("Аркаша", textBox2.Text);           
            await RefreshMessagesList();
        }

        private async Task RefreshMessagesList()
        {
            textBox2.Text = "";
            _messages = await ChatService.GetAllMessages();

            foreach (Message message in _messages)
            {
                textBox1.Text += message.ToString() + Environment.NewLine;
            }
        }
    }
}
