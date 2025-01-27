using ServiceContracts;

namespace Services
{
    public class CitiesService2 : ICitiesService, IDisposable
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
        public CitiesService2()
        {
            _serviceInstanceId = Guid.NewGuid();
            //In real world proyects we will invoke the data layer to fetch this data
            //from the database
            _cities = new List<string>
            {
                "London2",
                "Paris2",
                "Mazatlan2",
                "Culiacan2",
                "Chiapas2"
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
