using System;

using NUnit.Framework;

using E_School_Diary.Data.Models;

namespace E_School_Diary.Tests.Data.CustomModels.Messages
{
    [TestFixture]
    public class _ConstructorShould_
    {
        [Test]
        public void NotToThrow_AndCreateMessage_WithUniqueId()
        {
            var messageId = Guid.Empty.ToString();
            for (int i = 0; i < 5; i++)
            {
                // Arrange & Act
                var message = new Message();

                // Assert
                Assert.AreNotEqual(messageId, message.Id);

                messageId = message.Id;
            }
        }

        [TestCase("")]
        [TestCase("a")]
        public void ThrowArgumentException_WhenPassedContentParameter_IsNotValid(string invalidContent)
        {
            var from = "Pesho";
            var msg = Assert.Throws<ArgumentException>(() => new Message(invalidContent, from)).Message;

            Assert.IsTrue(msg.Contains("Content"));
        }

        [TestCase("")]
        [TestCase("a")]
        [TestCase("aaaaaaaaaaaaaaaaaaaaa")]
        public void ThrowArgumentException_WhenPassedFromParameter_IsNotValid(string invalidFrom)
        {
            var content = "New Message";
            var msg = Assert.Throws<ArgumentException>(() => new Message(content, invalidFrom)).Message;

            Assert.IsTrue(msg.Contains("From"));
        }

        [TestCase("aa", "aa")]
        [TestCase("aa", "Some Teacher")]
        [TestCase("Some content", "aa")]
        public void NotToThrow_AndSetPropertiesCorectly(string content, string from)
        {
            var message = new Message(content, from);

            Assert.AreEqual(message.Content, content);
            Assert.AreEqual(message.SendFrom, from);
        }
    }
}
