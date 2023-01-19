using System.Collections.Generic;
using Chat.Server;
using Chat.Server.Controllers;
using Chat.Shared;
using NUnit.Framework;
using System.Linq;
using System;

namespace Tests;

[TestFixture]
public class ChatControllerTests
{
    private MessagesRepository _messagesRepository;
    
    [SetUp]
    public void Setup()
    {
        _messagesRepository = new MessagesRepository(new List<Message>());

        Message message1 = new Message("Иван", "Всем привет!");
        Message message2 = new Message("Аркадий", "Добрый день!");
        Message message3 = new Message("Георгий","Рад всем!");

        _messagesRepository.AddMessage(message1);
        _messagesRepository.AddMessage(message2);
        _messagesRepository.AddMessage(message3);
    }

    [Test]
    public void GetAllMessages_GetMessagesListJson_ReturnsListFromRepository()
    {
        var controller = new ChatController(_messagesRepository);
        
        var actualList = controller.GetAllMessages().Value;
        var expectedList = _messagesRepository.Messages;
        
        Assert.AreEqual(expectedList, actualList);
    }
    
    [Test]
    public void GetAllMessages_GetMessagesListJson_ReturnsEmptyListFromEmptyRepository()
    {
        var emptyRepository = new MessagesRepository();
        var controller = new ChatController(emptyRepository);
        var actualList = controller.GetAllMessages().Value;
        Assert.IsEmpty(actualList!);
    }

    [Test]
    public void AddMessage_PostMessageInRepository_ReturnsListWithNewMessage()
    {
        var controller = new ChatController(_messagesRepository);
        Message newMessage = new Message("Игорь", "Добрый вечер!");    
        controller.AddMessage(newMessage);
        List<Message> currentMessages = controller.GetAllMessages().Value;
        Assert.AreEqual(newMessage, currentMessages[currentMessages.Count - 1]);
    }

    [Test]
    public void DeleteMessage_DeleteMessageInRepository_ReturnsListWithoutMessage()
    {
        Message message = _messagesRepository.Messages[0];
        var controller = new ChatController(_messagesRepository);
        controller.DeleteMessage(message.Id);
        CollectionAssert.DoesNotContain(_messagesRepository.Messages, message);
    }

    [Test]
    public void AddMessage_PostMessageInRepository_ThrowsNullArgumentException()
    {
        var chatController = new ChatController(_messagesRepository);
        //Assert.Throws<ArgumentNullException>(chatController.AddMessage, null, null, null);
        Assert.Throws<ArgumentNullException>(() => chatController.AddMessage(null));
    }
}