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
            _messages = await ChatService.GetAllMessages();
            textBox1.Text = String.Join(Environment.NewLine, _messages);
        }
    }
}
