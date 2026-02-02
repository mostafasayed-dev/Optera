using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Optera.Shared.Core.Domain
{
    public class BaseModel
    {
        /// <summary>
        /// Id
        /// </summary>
        public long Id { get; set; }

        /// <summary>
        /// CreatedAt
        /// </summary>
        public DateTime CreatedAt { get; set; }

        /// <summary>
        /// UpdatedAt
        /// </summary>
        public DateTime UpdatedAt { get; set; }

        /// <summary>
        /// Creator
        /// </summary>
        public string? Creator { get; set; }

        /// <summary>
        /// Updater
        /// </summary>
        public string? Updater { get; set; }

        /// <summary>
        /// Status
        /// </summary>
        public string Status { get; set; } = "Active";

        /// <summary>
        /// RowVersion
        /// </summary>
        [Timestamp]
        public byte[]? RowVersion { get; set; }

        /// <summary>
        /// RowKey
        /// </summary>
        public Ulid RowKey { get; set; } = Ulid.NewUlid();
    }
}
