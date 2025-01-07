using System.ComponentModel.DataAnnotations;

namespace Entities
{
    /// <summary>
    /// Domain Model for Country
    /// </summary>
    public class Country
    {
        [Key] //Entities must have primary key
        public Guid CountryID { get; set; }

        //string? for nullable fields, if it doesnt have ? it means its a mandatory field[StringLength(40)]
        [StringLength(40)]
        public string? CountryName { get; set; }

        //this Persons property will load all Persons where CountryID = "x"
        public virtual ICollection<Person>? Persons { get; set;}
    }
}
