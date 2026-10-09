using STB_desktop;
using STB_desktop.Enums;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace YourNamespace.Models;

public class CreditLedger
{
    
    [Key]
    public Guid id { get; set; }

    
    [Required]
    public Guid UserId { get; set; }



    [ForeignKey(nameof(UserId))]
    public virtual Users User { get; set; } = null!;

    
    public int Amount { get; set; }

    
    [Required]
    public TransactionType TransactionType { get; set; }

   
    [MaxLength(255)]
    public string? ReferenceId { get; set; }

    
    [MaxLength(255)]
    public string Description { get; set; } = string.Empty;

    
    [Required]
    public DateTimeOffset CreatedAt { get; set; } = DateTimeOffset.UtcNow;
}