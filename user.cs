//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Community2
{
    using System;
    using System.Collections.Generic;
    
    public partial class user
    {
        public user()
        {
            this.requests = new HashSet<request>();
        }
    
        public int Id { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public string cnic { get; set; }
        public string contact { get; set; }
        public string address { get; set; }
    
        public virtual ICollection<request> requests { get; set; }
    }
}
