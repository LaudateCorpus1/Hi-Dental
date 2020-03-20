using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using DatabaseLayer.Enums;

namespace DataBaseLayer.Models.Commons
{
  public class CommonsProperty
    {
        public Guid Id { get; set; }
        public DateTime CreateAt { get; set; } = DateTime.Now;
        public DateTime UpdateAt { get; set; } = DateTime.Now;
        public State State { get; set; } = State.Active;
        [NotMapped]
        public string CreatedAtStr => CreateAt.ToShortDateString();
        [NotMapped]
        public string UpdatedAtStr => UpdateAt.ToShortDateString();


    }
}
