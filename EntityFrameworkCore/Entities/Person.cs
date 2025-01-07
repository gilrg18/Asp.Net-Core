using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities
{
    /// <summary>
    /// Person domain model class
    /// </summary>
    public class Person
    {
        [Key] //Primary Key
        public Guid PersonID { get; set; }

        [StringLength(40)] //nvarchar(40) - wherever you use string type always set the length
        public string? PersonName { get; set; }

        [StringLength(40)]
        public string? Email { get; set; }

        public DateTime? DateOfBirth { get; set; }

        [StringLength(10)]
        public string? Gender { get; set; }

        //uniqueidentifier
        public Guid? CountryID { get; set; }

        [StringLength(200)]
        public string? Address { get; set; }

        //bit for bool types in sql
        public bool ReceiveNewsLetters { get; set; } 

        public string? TIN { get; set; }

        //Navigation Property
        [ForeignKey("CountryID")]
        public Country? Country { get; set; }
    }
}
 