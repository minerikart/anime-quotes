using AnimeQuotes.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Linq;
using System.Net.Http.Json;
using System.Text.Json.Serialization;

namespace AnimeQuotes.Services
{
    public class AnimeQuoteService
    {
        HttpClient httpClient;
        public string animeName { get; set; }
        public string animeChar { get; set; }

        public AnimeQuoteService()
        {
            this.httpClient = new HttpClient();
        }

        QuoteModel animeQuotes;
        List<QuoteModel> tenAnimeQuotes;
        List<QuoteModel> tenCharsQuotes;
        List<AnimeModel> AvailableAnimes;
        List<AnimeModel> AvailableCharacters;
        AnimeModel AvailableChars;

        public async Task<QuoteModel> GetQuotes()
        {

            var response = await httpClient.GetAsync("https://animechan.vercel.app/api/random");

            if (response.IsSuccessStatusCode)
            {
                var json = response.Content.ReadAsStringAsync().Result;
                animeQuotes = JsonConvert.DeserializeObject<QuoteModel>(json);
            }

            return animeQuotes;
        }

        public async Task<List<QuoteModel>> GetTenQuotesFromAnAnime()
        {
            if(animeName is null || animeName == "")
            {
                return tenAnimeQuotes;
            }

            string link = "https://animechan.vercel.app/api/quotes/anime?title=";
            var response = await httpClient.GetAsync(link + animeName);

            if (response.IsSuccessStatusCode)
            {
                var json = response.Content.ReadAsStringAsync().Result;
                tenAnimeQuotes = JsonConvert.DeserializeObject<List<QuoteModel>>(json);
            }

            return tenAnimeQuotes;
        }

        public async Task<List<QuoteModel>> GetTenQuotesFromACharacter()
        {
            if (animeChar is null || animeChar == "")
            {
                return tenAnimeQuotes;
            }

            string link = "https://animechan.vercel.app/api/quotes/character?name=";
            var response = await httpClient.GetAsync(link + animeChar);

            if (response.IsSuccessStatusCode)
            {
                var json = response.Content.ReadAsStringAsync().Result;
                tenCharsQuotes = JsonConvert.DeserializeObject<List<QuoteModel>>(json);
            }

            return tenCharsQuotes;
        }

        public async Task<List<AnimeModel>> GetAvailableAnimes()
        {
            var response = await httpClient.GetAsync("https://animechan.vercel.app/api/available/anime");

            if (response.IsSuccessStatusCode)
            {
                
                 var json = response.Content.ReadAsStringAsync().Result;
                 AvailableAnimes = JsonConvert.DeserializeObject<List<AnimeModel>>(json);
                
                
            }

            return AvailableAnimes;
        }

        public async Task<AnimeModel> GetAvailableCharacters()
        {

            var response = await httpClient.GetAsync("https://animechan.vercel.app/api/available/character");

            if (response.IsSuccessStatusCode)
            {
                var json = response.Content.ReadAsStringAsync().Result;
                AvailableChars = JsonConvert.DeserializeObject<AnimeModel>(json);
                
            }

            return AvailableChars;
        }

    }
}
