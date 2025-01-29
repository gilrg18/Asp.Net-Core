namespace ViewComponentsExample.Models
{
    public class PersonTableModel
    {
        public string TableTitle { get; set; } = string.Empty;

        public List<Person> Persons { get; set; } = new List<Person>();
    }
}
