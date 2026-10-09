
using STB_desktop.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace STB_desktop
{
    public class Bookings
    {
        [Key]
        public Guid Id {get; set;}
        //userId
        [Required]
        public int UserId { get; set; }
        [ForeignKey(nameof(UserId))]
        public virtual Users User { get; set; } = null!;
        //AssetId   
        public Guid? AssetId { get; set; }
        [ForeignKey(nameof(AssetId))]
        public virtual Asset Asset { get; set; }
        //RoomId
        public virtual Guid? RoomId { get; set; }
        [ForeignKey(nameof(RoomId))]
        public virtual Room Room { get; set; }

        //BookingUsage
        public RoomType? BookingUsage { get; set; }
        [Required]
        public BookingStatus Status { get; set; } = BookingStatus.PENDING;

        //Dátumok és időpontok
        [Required]
        public DateTimeOffset StartTime { get; set; }
        [Required]
        public DateTimeOffset EndTime { get; set; }


        [Required]
        public DateTimeOffset CreatedAt { get; set; } = DateTimeOffset.UtcNow;
        [Required]
        public DateTimeOffset UpdatedAt { get; set; } = DateTimeOffset.UtcNow;

        private int FinalCreditCost { get; set; } = 0;

        public bool IsDeleted { get; set; } = false;
        public DateTimeOffset? DeletedAt { get; set; }


    }
}
