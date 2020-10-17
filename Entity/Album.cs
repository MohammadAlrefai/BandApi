﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace BandWebApi.Entity
{
    public class Album
    {
        [Key]
        public Guid Id { get; set; }
        [Required]
        [MaxLength(200)]
        public string Title { get; set; }
        [Required]
        [MaxLength(400)]
        public string  Description { get; set; }
        [ForeignKey("BandId")]
        public Band Band { get; set; }
        public Guid BandId { get; set; }


    }
}
