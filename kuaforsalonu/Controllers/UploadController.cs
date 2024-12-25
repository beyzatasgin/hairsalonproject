using kuaforsalonu.Models;
using Microsoft.AspNetCore.Mvc;

public class UploadController : Controller
{
    private readonly OpenAIService _openAIService;

    public UploadController(OpenAIService openAIService)
    {
        _openAIService = openAIService;
    }

    // Fotoğraf yükleme formunu gösteren GET metodu
    [HttpGet]
    public IActionResult Index()
    {
        return View();
    }

    // Fotoğrafı alıp OpenAI'ye gönderme POST metodu
    [HttpPost]
    public async Task<IActionResult> UploadPhoto(IFormFile photo)
    {
        if (photo != null && photo.Length > 0)
        {
            using (var memoryStream = new MemoryStream())
            {
                // Fotoğrafı memoryStream'e kopyalayın
                await photo.CopyToAsync(memoryStream);
                var imageBytes = memoryStream.ToArray();

                // Fotoğrafı Base64 formatına çeviriyoruz
                var base64Image = Convert.ToBase64String(imageBytes);

                // OpenAI'ye fotoğraf verisini gönderiyoruz
                var suggestions = await _openAIService.GetHairCutSuggestions(base64Image);

                // Sonuçları bir modelle view'a gönderiyoruz
                var model = new HairCutSuggestionViewModel
                {
                    Suggestions = suggestions
                };

                return View("Suggestions", model);
            }
        }

        return View("Index");
    }
}
