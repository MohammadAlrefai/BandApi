using System;
using System.ComponentModel.DataAnnotations;

namespace BandWebApi.Models
{
    public class BandDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string FoundedYearAgo { get; set; }
        public string MainGenre { get; set; }
    }
}
