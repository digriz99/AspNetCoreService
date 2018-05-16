using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace AspNetCoreService.Repository.Models
{
    public class UserModel 
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Telephone { get; set; }
        public string Address { get; set; }
    }    
}
