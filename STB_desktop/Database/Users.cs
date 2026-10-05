using STB_desktop.Database;
using System;
using System.Collections.Generic;
using System.Text;
using STB_desktop.Database.enums;
namespace STB_desktop
{
    public class Users
    {
        public int Id { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        // phone as string to preserve formatting, plus prefixed zeros
        public string PhoneNumber { get; set; } = string.Empty;
        public decimal CreditBalance { get; set; }
        public PartnerTier Tier { get; set; } = PartnerTier.Bronze;
        public decimal DiscountRate { get; set; }
        public DateOnly CreatedAt { get; set; }
        public DateOnly UpdatedAt { get; set; }
        public bool IsDeleted { get; set; }
        public DateOnly? DeletedAt { get; set; }
    }
}
