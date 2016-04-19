namespace GitJobsService.Core.Service
{
    public class QueryParam
    {
        // A search term, such as "ruby" or "java". This parameter is aliased to search.
        public string description { get; set; }
        // — A city name, zip code, or other location search term.
        public string location { get; set; }
        // — A specific latitude. If used, you must also send long and must not send location.
        public long lat { get; set; } = 0;
        // — A specific longitude. If used, you must also send lat and must not send location.
        public long longitude { get; set; } = 0;
        //— If you want to limit results to full time positions set this parameter to 'true'.
        public bool full_time { get; set; } = true;
    }
}
