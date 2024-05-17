using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coworking.DA.Models.Authorise
{
    public class UserContract
    {
        public string? Id { get; set; }
        public string? UserName { get; set; }
        public string? FullName { get; set; }
        public string? Position { get; set; }
        public string? Phone { get; set; }
        [Required]
        public string? RoleId { get; set; }
        [Required]
        public string? Email { get; set; }
    }
}
