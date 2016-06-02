namespace Common.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("EmailSubscription")]
    public partial class EmailSubscription
    {
        public int Id { get; set; }

        [StringLength(50)]
        public string IP { get; set; }

        [Required]
        [StringLength(255)]
        public string Email { get; set; }

    }
}
