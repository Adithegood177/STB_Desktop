using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace STB_desktop
{
    public class Asset
    {
        [Key]
        private Guid id;
        [Required]
        [MaxLength(255)]
        public string Name { get; set; } = string.Empty;
        [Required]
        [MaxLength(255)]
        public string? Description { get; set; } = string.Empty;

        

        [Required]
        public int BaseCreditPricePerHour { get; set; } = 0;
        
        public int MonthlyDividendCredits { get; set; } = 0;
        public bool IsActive { get; set; } = true;

        public Guid? RoomId { get; set; }
        [ForeignKey(nameof(RoomId))]
        public virtual Room? Room { get; set; }

        public Guid? OwnerId { get; set; }
        [ForeignKey(nameof(OwnerId))]
        public virtual Users? Owner { get; set; }

        public bool IsDeleted { get; set; } = false;
        public DateTimeOffset? DeletedAt { get; set; }

        public virtual ICollection<Bookings> Bookings { get; set; } = new List<Bookings>();


    }
}
