namespace Common.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("UserAccounts")]
    public partial class UserAccounts
    {
        public int Id { get; set; }

        [StringLength(100)]
        public string Username { get; set; }

        [StringLength(100)]
        [Required(ErrorMessage = "Password is Required")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [StringLength(100)]
        [Required(ErrorMessage = "Email is Required")]
        [RegularExpression(@"^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$", ErrorMessage ="Email is not valid.")]
        public string Email { get; set; }

        [StringLength(100)]
        public string FirstName { get; set; }

        [StringLength(50)]
        public string LastName { get; set; }
    }
}
