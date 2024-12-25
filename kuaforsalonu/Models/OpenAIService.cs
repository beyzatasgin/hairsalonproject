using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

public class OpenAIService
{
    private readonly HttpClient _httpClient;
    private readonly string _apiKey;
    private const string _apiUrl = "https://api.openai.com/v1/completions"; // OpenAI API endpointi

    public OpenAIService(HttpClient httpClient, IConfiguration configuration)
    {
        _httpClient = httpClient;
        _apiKey = configuration["OpenAI:ApiKey"]; // appsettings.json'dan alınıyor
    }

    public async Task<string> GetHairCutSuggestions(string imageBase64)
    {
        var requestBody = new
        {
            model = "text-davinci-003", // Kullanılacak model
            prompt = $"Analyze the uploaded image and suggest a suitable haircut style for this person. Image: {imageBase64}",
            max_tokens = 150
        };

        var content = new StringContent(JsonConvert.SerializeObject(requestBody), Encoding.UTF8, "application/json");
        content.Headers.Add("Authorization", "Bearer " + _apiKey);

        var response = await _httpClient.PostAsync(_apiUrl, content);
        response.EnsureSuccessStatusCode();

        var result = await response.Content.ReadAsStringAsync();
        return result; // Yapay zekadan gelen cevabı döndürüyoruz
    }
}
