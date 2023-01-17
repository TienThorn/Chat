namespace Chat.Shared
{
    public class Message
    {
        private static int _idCounter;
        
        public int Id { get; set; }
        
        public string Sender { get; set; }

        public string Text { get; set; }

        public Message(string sender, string text)
        {
            Id = _idCounter++;
            Sender = sender;
            Text = text;
        }
        public override string ToString()
        {
            return $"{Sender}: {Text}";
        }
    }
}