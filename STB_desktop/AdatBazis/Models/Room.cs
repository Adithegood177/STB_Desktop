using STB_desktop.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace STB_desktop
{
    public class Room
    {
        [Key]
        public Guid Id {get; set;}

        [Required]
        [MaxLength(255)]
        public string Name {get; set;} = string.Empty;
        [Required]
        public RoomType Roomtype { get; set; }
        public string? Description {get; set;}
        public int BaseCreditPricePerHour {get; set;}
        public int Capacity {get; set;}
        public bool IsActive {get; set;} = true;
        public bool IsDeleted {get; set;} = false;
        public   DateTimeOffset? CreatedAt {get; set;} = DateTime.UtcNow;


        public virtual ICollection<Bookings> Bookings { get; set; } = new List<Bookings>();
        public virtual ICollection<Asset> Assets { get; set; } = new List<Asset>();
    }
}
