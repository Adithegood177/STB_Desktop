using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using STB_desktop.Enums;
using YourNamespace.Models;
namespace STB_desktop
{
    public class Users
    {
        [Key]
        public Guid Id { get; set; }
        [Required]
        [MaxLength(255)]
        public string FirstName { get; set; } = string.Empty;
        [Required]
        [MaxLength(255)]
        public string LastName { get; set; } = string.Empty;
        [Required]
        [MaxLength(255)]
        public string Email { get; set; } = string.Empty;
        [MaxLength(50)]
        public string? PhoneNumber { get; set; } = string.Empty;

        public decimal CreditBalance { get; set; } = 0;
        [Required]
        public  UserRole Role { get; set; } = UserRole.User;
        [Required]
        public PartnerTier Tier { get; set; } = PartnerTier.Default;
        [Required]
        [Column(TypeName = "decimal(3, 2)")]
        public decimal DiscountRate { get; set; } = 1.00m;
        public DateTimeOffset CreatedAt { get; set; } = DateTimeOffset.UtcNow;
        public DateTimeOffset UpdatedAt { get; set; } = DateTimeOffset.UtcNow;
        [Required]
        public bool isDeleted { get; set; } = false;

        public DateTimeOffset? DeletedAt { get; set; }


        public virtual ICollection<Bookings> Bookings { get; set; } = new List<Bookings>();
        public virtual ICollection<Assets> Assets { get; set; } = new List<Assets>();
        public virtual ICollection<CreditLedger> CreditLedgers { get; set; } = new List<CreditLedger>();

        public virtual ICollection<DeletedRecords> DeletedRecords { get; set; } = new List<DeletedRecords>();
    }
}
