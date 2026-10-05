using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace STB_desktop
{
    public class Assets
    {
        [Key]
        private Guid id;
        [Required]
        [MaxLength(255)]
        public string name { get; set; } = string.Empty;
        [Required]
        [MaxLength(255)]
        public string? description { get; set; } = string.Empty;

        

        [Required]
        public int baseCreditPricePerHour = 0;
        
        public int monthlyDividendCredits { get; set; } = 0;
        public bool isActive { get; set; } = true;

        public Guid? roomId { get; set; }
        [ForeignKey(nameof(roomId))]
        public virtual Rooms? Room { get; set; }

        public Guid? ownerId { get; set; }
        [ForeignKey(nameof(ownerId))]
        public virtual Users? Owner { get; set; }

        public bool isDeleted { get; set; } = false;
        public DateTimeOffset? deletedAt { get; set; }

        public virtual ICollection<Bookings> Bookings { get; set; } = new List<Bookings>();


    }
}
