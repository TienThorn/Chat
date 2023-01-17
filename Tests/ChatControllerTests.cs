using System.Collections.Generic;
using Chat.Server;
using Chat.Server.Controllers;
using Chat.Shared;
using NUnit.Framework;

namespace Tests;

[TestFixture]
public class ChatControllerTests
{
    private MessagesRepository _messagesRepository;
    
    [SetUp]
    public void Setup()
    {
        _messagesRepository = new MessagesRepository(new List<Message>
        {
            new ("Аркадий", "Всем привет"),
            new ("Вася", "Привет"),
            new ("Петя", "И вам привет"),
        });
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
}