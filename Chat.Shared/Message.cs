﻿namespace Chat.Shared
{
    public class Message
    {  
        public int Id { get; }
        
        public string Sender { get; set; }

        public string Text { get; set; }

        public Message(string sender, string text, int id)
        {            
            Sender = sender;
            Text = text;
            Id = id;
        }

        public Message(string sender, string text)
        {
            Sender = sender;
            Text = text;
        }

        public Message()
        {

        }

        public override string ToString()
        {
            return $"[{Id}] {Sender}: {Text}";
        }
    }
}