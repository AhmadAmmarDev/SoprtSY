using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

namespace SportSY.Data.Repository.SQL.Models
{
	public class ApplicationUser : IdentityUser
	{
        public Guid PersonId { get; set; }
	}
}