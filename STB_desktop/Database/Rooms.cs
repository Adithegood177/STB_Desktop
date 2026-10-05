using STB_desktop.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace STB_desktop
{
    public class Rooms
    {
        [Key]
        public Guid id {get; set;}

        [Required]
        [MaxLength(255)]
        public string name {get; set;} = string.Empty;
        [Required]
        public RoomType roomtype { get; set; }
        public string? description {get; set;}
        public int baseCreditPricePerHour {get; set;}
        public int capacity {get; set;}
        public bool isActive {get; set;} = true;
        public bool isDeleted {get; set;} = false;
        public   DateTimeOffset? createdAt {get; set;} = DateTime.UtcNow;


        public virtual ICollection<Bookings> Bookings { get; set; } = new List<Bookings>();
        public virtual ICollection<Assets> Assets { get; set; } = new List<Assets>();
    }
}
