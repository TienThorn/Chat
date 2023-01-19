namespace Chat.Client
{
    public partial class Auth : Form
    {
        ChatWindow _chatWindow;
        public Auth()
        {
            InitializeComponent();
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            string user = textBox1.Text;
            await LoginService.Login(user);

            if (_chatWindow == null)
            {
                new ChatWindow(textBox1.Text, this).Show();
            }
            else
            {
                _chatWindow.Show();
            }
        }
    }
}