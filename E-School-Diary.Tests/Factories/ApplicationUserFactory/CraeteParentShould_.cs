using System;
using System.Collections.Generic;

using NUnit.Framework;

using E_School_Diary.Factories;
using E_School_Diary.Data.Enums;
using E_School_Diary.Utils.DTOs.RegisterDTOs;

namespace E_School_Diary.Tests.Factories
{
    [TestFixture]
    public class CraeteParentShould_
    {
        [Test]
        public void NotToThrow_AndReturnNewApplicationUser()
        {
            var parents = this.GetParents();
            var userFactory = new ApplicationUserFactory();

            foreach (var parent in parents)
            {
                var user = userFactory.CreateParent(parent);

                Assert.AreEqual(parent.Age, user.Age);
                Assert.AreEqual(parent.LastName, user.LastName);
                Assert.AreEqual(parent.FirstName, user.FirstName);
                Assert.IsTrue(user.UserType == UserTypes.Parent);
            }
        }

        public IEnumerable<RegisterParentDTO> GetParents()
        {
            var parents = new List<RegisterParentDTO>()
            {
                new RegisterParentDTO
                {
                    Age=30,
                    Email="pesho@mail.bg",
                    ChildId =Guid.NewGuid().ToString(),
                    FirstName ="Pesho",
                    LastName ="Kirov"
                },
                new RegisterParentDTO
                {
                    Age=40,
                    Email="gosho@mail.bg",
                    ChildId =Guid.NewGuid().ToString(),
                    FirstName ="Gosho",
                    LastName ="Kirov",
                },
                new RegisterParentDTO
                {
                    Age=30,
                    Email="mitko@mail.bg",
                    ChildId =Guid.NewGuid().ToString(),
                    FirstName ="Mitko",
                    LastName ="Kirov"
                },
                new RegisterParentDTO
                {
                    Age=30,
                    Email="kiro@mail.bg",
                    ChildId =Guid.NewGuid().ToString(),
                    FirstName ="Kiro",
                    LastName ="Kirov"
                }
            };

            return parents;
        }
    }
}
