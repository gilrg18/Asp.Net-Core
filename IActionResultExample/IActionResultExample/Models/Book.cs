using Microsoft.AspNetCore.Mvc;

namespace IActionResultExample.Models
{
    public class Book
    {
        //[FromQuery]
        public int? BookId { get; set; }

        //This one has no specific attribute, so its value will be picked by
        //the highest hierarchy in model binding
        public string? Author { get; set; }

        public override string ToString()
        {
            return $"Book id: {BookId}, Author: {Author}";
        }
    }
}
