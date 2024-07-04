namespace DroughtProject.Services {

    using System.Collections.Generic;
    using System.Net.Http;
    using System.Threading.Tasks;
    using Newtonsoft.Json;
    using DroughtProject.DTO;

    public class SequiaDataService
    {
        private static readonly HttpClient client = new HttpClient();

        public async Task<List<SequiaData>> FetchDataFromApiAsync()
        {
            string url = "https://analisi.transparenciacatalunya.cat/resource/i5n8-43cw.json";

            var response = await client.GetAsync(url);
            response.EnsureSuccessStatusCode();

            var responseBody = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<List<SequiaData>>(responseBody);
        }
    }
}


