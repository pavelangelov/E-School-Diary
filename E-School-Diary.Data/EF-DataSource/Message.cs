//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace E_School_Diary.Data.EF_DataSource
{
    using System;
    using System.Collections.Generic;
    
    public partial class Message
    {
        public string Id { get; set; }
        public string Content { get; set; }
        public string SendFrom { get; set; }
        public System.DateTime SendOn { get; set; }
        public string User_Id { get; set; }
    
        public virtual User User { get; set; }
    }
}
