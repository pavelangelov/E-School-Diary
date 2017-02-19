using System;
using System.Collections.Generic;

using NUnit.Framework;

using E_School_Diary.Data.Models;
using E_School_Diary.Factories;
using E_School_Diary.Utils.DTOs.Common;

namespace E_School_Diary.Tests.Factories
{
    [TestFixture]
    public class CreateMessageShould_
    {
        [Test]
        public void NotToThrow_AndCreateNewMessage()
        {
            var messageFactory = new MessageFactory();
            var messageDTOs = this.GetMessagesDTOs();

            foreach (var messageDTO in messageDTOs)
            {
                var message = messageFactory.CreateMessage(messageDTO);

                Assert.AreEqual(messageDTO.Content, message.Content);
                Assert.AreEqual(messageDTO.From, message.SendFrom);
                Assert.AreEqual(messageDTO.SendOn, message.SendOn);
                Assert.AreEqual(typeof(Message), message.GetType());
            }
        }

        public IEnumerable<MessageDTO> GetMessagesDTOs()
        {
            var messages = new List<MessageDTO>()
            {
                new MessageDTO()
                {
                    Content = "Some content",
                    From = "Pesho",
                    SendOn = DateTime.Now
                },
                new MessageDTO()
                {
                    Content = "Some content 2",
                    From = "Gosho",
                    SendOn = DateTime.Now.AddHours(1)
                },
                new MessageDTO()
                {
                    Content = "Some content 3",
                    From = "Kiro",
                    SendOn = DateTime.Now.AddHours(2)
                },
                new MessageDTO()
                {
                    Content = "Some content 4",
                    From = "Mitko",
                    SendOn = DateTime.Now.AddHours(3)
                }
            };

            return messages;
        }
    }
}
