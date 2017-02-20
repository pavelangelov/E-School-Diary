using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

using E_School_Diary.Data;
using E_School_Diary.Utils.DTOs.Common;
using E_School_Diary.Services.Contracts;
using E_School_Diary.Data.Models;

namespace E_School_Diary.Services
{
    public class ParentService : IParentService
    {
        private IDatabaseContext dbContext;

        public ParentService(IDatabaseContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public IEnumerable<User> FindParents(string studentId)
        {
            var student = this.dbContext.Users.Include(u => u.Parents)
                                                        .FirstOrDefault(u => u.Id == studentId);
            var parents = student.Parents;

            return parents;
        }

        public string GetChildId(string parentId)
        {
            var parent = this.dbContext.Users.FirstOrDefault(u => u.Id == parentId);

            return parent.ChildId;
        }

        public IEnumerable<IGrouping<string, MarkDTO>> GetChildMarks(string parentId)
        {
            var childId = this.dbContext.Users
                                        .FirstOrDefault(u => u.Id == parentId)
                                        .ChildId;

            var student = this.dbContext.Users.Include(u => u.Lectures)
                                                    .FirstOrDefault(u => u.Id == childId);

            IEnumerable<IGrouping<string, MarkDTO>> marks = null;
            if (student != null)
            {
                marks = student.Marks.Select(m => new MarkDTO()
                                            {
                                                Subject = m.Subject.ToString(),
                                                Value = m.Value
                                            })
                                            .GroupBy(m => m.Subject);
            }

            return marks;
        }

        public IEnumerable<MessageDTO> GetParentMessages(string parentId)
        {
            var user = this.dbContext.Users.Include(u => u.Messages)
                                           .FirstOrDefault(u => u.Id == parentId);

            IEnumerable<MessageDTO> messages = null;
            if (user != null)
            {
                messages = user.Messages.Select(m => new MessageDTO()
                {
                    From = m.SendFrom,
                    Content = m.Content,
                    SendOn = m.SendOn
                });
            }

            return messages;
        }

        public int Save()
        {
            return this.dbContext.Save();
        }
    }
}
