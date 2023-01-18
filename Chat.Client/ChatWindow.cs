using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
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
            await ChatService.AddMessage("Аркаша", textBox2.Text);
            textBox2.Text = "";
            await RefreshMessagesList();
        }

        private async Task RefreshMessagesList()
        {
            _messages = await ChatService.GetAllMessages();
            textBox1.Text = String.Join(Environment.NewLine, _messages);
        }
    }
}
