using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TaskModsen.Entities
{
    /// <summary>
    /// class that will be used to create the table user to login
    /// </summary>
    public class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; } 
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}
