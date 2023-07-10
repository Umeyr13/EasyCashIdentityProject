using Microsoft.AspNetCore.Mvc;

namespace EasyCashIdentityProject.PresentationLayer.Controllers
{
    public class ExchangeController : Controller
    {
        public async Task<IActionResult> Index()
        {
            #region Dolar - TL
            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("https://currency-exchange.p.rapidapi.com/exchange?from=USD&to=TRY&q=1.0"),
                Headers =
                {
                    { "X-RapidAPI-Key", "bd98385f85mshdc63868ca96ec64p147738jsn1eb14d2dd72f" },
                    { "X-RapidAPI-Host", "currency-exchange.p.rapidapi.com" },
                },
                        };
            using (var response = await client.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                var body = await response.Content.ReadAsStringAsync();
                ViewBag.UsdToTry = body;
            }
            #endregion

            #region Euro - TL
            var client2 = new HttpClient();
            var request2 = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("https://currency-exchange.p.rapidapi.com/exchange?from=EUR&to=TRY&q=1.0"),
                Headers =
                {
                    { "X-RapidAPI-Key", "bd98385f85mshdc63868ca96ec64p147738jsn1eb14d2dd72f" },
                    { "X-RapidAPI-Host", "currency-exchange.p.rapidapi.com" },
                },
            };
            using (var response2 = await client2.SendAsync(request2))
            {
                response2.EnsureSuccessStatusCode();
                var body2 = await response2.Content.ReadAsStringAsync();
                ViewBag.EuroToTry = body2;
            }
            #endregion

            #region Sterlin - TL
            var client3 = new HttpClient();
            var request3 = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("https://currency-exchange.p.rapidapi.com/exchange?from=GBP&to=TRY&q=1.0"),
                Headers =
                {
                    { "X-RapidAPI-Key", "bd98385f85mshdc63868ca96ec64p147738jsn1eb14d2dd72f" },
                    { "X-RapidAPI-Host", "currency-exchange.p.rapidapi.com" },
                },
            };
            using (var response3 = await client.SendAsync(request3))
            {
                response3.EnsureSuccessStatusCode();
                var body3 = await response3.Content.ReadAsStringAsync();
                ViewBag.SterlinToTry = body3;
            }
            #endregion

            #region Dolar - Euro
            var client4 = new HttpClient();
            var request4 = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("https://currency-exchange.p.rapidapi.com/exchange?from=USD&to=EUR&q=1.0"),
                Headers =
                {
                    { "X-RapidAPI-Key", "bd98385f85mshdc63868ca96ec64p147738jsn1eb14d2dd72f" },
                    { "X-RapidAPI-Host", "currency-exchange.p.rapidapi.com" },
                },
            };
            using (var response4 = await client.SendAsync(request4))
            {
                response4.EnsureSuccessStatusCode();
                var body4 = await response4.Content.ReadAsStringAsync();
                ViewBag.UsdToEur = body4;
            }
            #endregion

            return View();
        }
    }
}
