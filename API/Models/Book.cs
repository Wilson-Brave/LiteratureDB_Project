using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Models
{
    public class Book
    {

        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int? Book_index {get; set; }

#nullable enable
        public string? ISBN {get; set; }
        public string? Book_name {get; set; }
        public string? Title {get; set; }
        public string? Edition {get; set; }
        public string? Genre {get; set; }
        public string? Publisher_name {get; set; }
        public string? Publisher_id {get; set; }
        public DateTime? Year_published {get; set; }
        public string? Language {get; set; }
        public string? Image_ref {get; set; }
        public string? Synopsis {get; set; }
        public int? Page_count {get; set; }
        public DateTime? Time_added { get; set; }

    }
}