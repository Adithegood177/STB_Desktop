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
        private Guid id;
        [Required]
        private int userId { get; set; }
        [ForeignKey(nameof(userId))]
        public virtual Users User { get; set; } = null!;
        [Required]
        [MaxLength(100)]
        private string tableName { get; set; } = string.Empty;
        [Required]
        [MaxLength(255)]
        private string recordId { get; set; } = string.Empty;

        [Required]
        private Guid deletedByUserid { get; set; }
        [ForeignKey(nameof(deletedByUserid))]
        public virtual Users DeletedByUser { get; set; } = null!;

        [Required]
        [Column(TypeName = "jsonb")]
        public JsonDocument DeletedData { get; set; } = null!;

        [Required]
        public DateTimeOffset DeletedAt { get; set; } = DateTimeOffset.UtcNow;



    }
}
