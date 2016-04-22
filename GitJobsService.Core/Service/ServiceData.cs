namespace GitJobsService.Core.Service
{
    public class ServiceData
    {
        private const string URL_BASE = "https://jobs.github.com/positions.json?";
        private QueryParam queryParam;
        private ResponseListener listener;
        private string url;

        public ServiceData(ResponseListener listener)
        {
            queryParam = new QueryParam();
            this.listener = listener;
        }

        public ServiceData Description(string value)
        {
            queryParam.description = value;
            return this;
        }

        public ServiceData Location(string value)
        {
            queryParam.location = value;
            return this;
        }

        public ServiceData Latitude(long value)
        {
            queryParam.lat = value;
            return this;
        }

        public ServiceData Longitude(long value)
        {
            queryParam.longitude = value;
            return this;
        }

        public ServiceData FullTime(bool value)
        {
            queryParam.full_time = value;
            return this;
        }

        public void Execute()
        {
            url = URL_BASE;
            string e = "";

            if (!string.IsNullOrEmpty(queryParam.description))
            {
                url += "description=" + queryParam.description;
                e = "&";
            }

            if (!string.IsNullOrEmpty(queryParam.location))
            {
                url += e + "location=" + queryParam.location;
                e = "&";
            }

            if (queryParam.full_time)
            {
                url += e + "full_time=true";
            }

            RequestThread request = new RequestThread(listener, url);
            request.Run();
        }
    }
}
//montando as urls de busca para o gitjobs