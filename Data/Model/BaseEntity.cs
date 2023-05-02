using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Model
{
    public class BaseEntity
    {
        [Column("id")]
        public int Id { get; set; }
    }
}