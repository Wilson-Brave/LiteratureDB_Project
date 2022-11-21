using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Models
{
    public class User
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int? User_index { get; set; }

#nullable enable
        public string? User_id { get; set; }
        public string? Username { get; set; }
        public string? Pwd_hash { get; set; }
        public string? Email { get; set; }
        public string? Avatar { get; set; }
        public string? Type { get; set; }

    }
}