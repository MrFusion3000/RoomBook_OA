﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Domain.Entities
{
    public class User
    {
        [Key, Required]
        public int Id { get; set; }

        [Required, MaxLength(128)]
        public string UserName { get; set; }

        [Required, MaxLength(1024)]
        public string PasswordHash { get; set; }

        [Required, MaxLength(128)]
        public string Email { get; set; }

        [MaxLength(32)]
        public string FirstName { get; set; }

        [MaxLength(1)]
        public string MiddleInitial { get; set; }

        [MaxLength(32)]
        public string LastName { get; set; }

        public virtual ICollection<UserRole> UserRoles { get; set; }
    }
}
