using ServiceContracts;

namespace Services
{
    public class CitiesService : ICitiesService, IDisposable
    {
        private List<string> _cities = new List<string>();

        private Guid _serviceInstanceId;
        public Guid ServiceInstanceId
        {
            get
            {
                return _serviceInstanceId;
            }
        }
        public CitiesService()
        {
            _serviceInstanceId = Guid.NewGuid();
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
            //TO DO: Add logic to open the db connection
        }

        public List<string> GetCities()
        {
            return _cities;
        }

        public void Dispose()
        {
            //TO DO: add logic to close db connection
        }
    }
}
