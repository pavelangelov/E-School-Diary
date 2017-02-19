using System.Collections.Generic;

using E_School_Diary.Utils.DTOs.Common;

namespace E_School_Diary.WebClient.Models.ViewModels.Parent
{
    public class ParentMessagesViewModel : BaseViewModel
    {
        public IEnumerable<MessageDTO> Messages { get; set; }
    }
}