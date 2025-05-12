namespace OnlineEdu.WebUI.Helper
{
    public static class HttpClientHelper
    {

        public static HttpClient CreateClient()
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:7260/api/");
            return client;
        }
    }
}
