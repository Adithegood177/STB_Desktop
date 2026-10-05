
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
        public Guid id {get; set;}
        //userId
        [Required]
        public int userId { get; set; }
        [ForeignKey(nameof(userId))]
        public virtual Users User { get; set; } = null!;
        //AssetId   
        public Guid? assetId { get; set; }
        [ForeignKey(nameof(assetId))]
        public virtual Assets Asset { get; set; }
        //RoomId
        public virtual Guid? roomId { get; set; }
        [ForeignKey(nameof(roomId))]
        public virtual Rooms Room { get; set; }

        //BookingUsage
        public RoomType? bookingUsage { get; set; }
        [Required]
        public BookingStatus status { get; set; } = BookingStatus.PENDING;

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
