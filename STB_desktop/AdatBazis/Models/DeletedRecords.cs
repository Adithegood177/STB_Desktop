using STB_desktop.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using System.Text.Json;

namespace STB_desktop
{
   public class DeletedRecords
    {
        [Key]
        private Guid Id;
        [Required]
        private int UserId { get; set; }
        [ForeignKey(nameof(UserId))]
        public virtual Users User { get; set; } = null!;
        [Required]
        [MaxLength(100)]
        private string TableName { get; set; } = string.Empty;
        [Required]
        [MaxLength(255)]
        private string RecordId { get; set; } = string.Empty;

        [Required]
        private Guid DeletedByUserid { get; set; }
        [ForeignKey(nameof(DeletedByUserid))]
        public virtual Users DeletedByUser { get; set; } = null!;

        [Required]
        [Column(TypeName = "jsonb")]
        public JsonDocument DeletedData { get; set; } = null!;

        [Required]
        public DateTimeOffset DeletedAt { get; set; } = DateTimeOffset.UtcNow;



    }
}
