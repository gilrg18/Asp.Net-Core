namespace Services
{
    public class CitiesService
    {
        private List<string> _cities = new List<string>();

        public CitiesService()
        {
            //In real world proyects we will invoke the data layer to fetch this data
            //from the database
            _cities = new List<string>
            {
                "London",
                "Paris",
                "Mazatlan",
                "Culiacan",
                "Chiapas"
            };
        }

        public List<string> GetCities()
        {
            return _cities;
        }
    }
}
