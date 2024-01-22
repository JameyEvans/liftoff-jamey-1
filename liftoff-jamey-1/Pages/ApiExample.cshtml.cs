using liftoff_jamey_1.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Text.Json;

namespace liftoff_jamey_1.Pages
{
    public class ApiExampleModel : PageModel
    {
        [BindProperty]
        public Joke ServerJoke { get; set; }
        private readonly string _apiKey = "lYTJTp1w73+rvbmqdnL7eA==XBk9tavB5cphQTbv";

        public async Task<IActionResult> OnGetAsync()
        {
            try
            {
                ServerJoke = await GetJokeAsync();
            }
            catch (Exception ex)
            {
                ServerJoke = new Models.Joke { JokeText = ex.Message };
            }

            return Page();
        }

        public async Task<Models.Joke> GetJokeAsync()
        {
            using (HttpClient client = new HttpClient())
            {
                client.DefaultRequestHeaders.Add("X-Api-Key", _apiKey);
                HttpResponseMessage response = await client.GetAsync("https://api.api-ninjas.com/v1/jokes?limit=1");
                if (response.IsSuccessStatusCode)
                {
                    string json = await response.Content.ReadAsStringAsync();
                    List<Models.Joke> joke = JsonSerializer.Deserialize<List<Models.Joke>>(json);
                    if (joke == null || joke.Count == 0)
                    {
                        throw new Exception("Failed to retrieve joke");
                    }
                    return joke[0];
                }
                else
                {
                    throw new Exception("Failed to retrieve joke");
                }
            }
        }
    }
}
