using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Repository.Model
{
    public class BaseEntity
    {
        [Column("id")]
        public int Id { get; set; }
    }
}