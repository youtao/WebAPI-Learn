namespace WebAPI_Learn.WebConsole
{
    using System.Collections.Generic;
    using System.Net.Http;
    using System.Threading.Tasks;

    public class ApiRequest
    {
        public async Task<IEnumerable<Contact>> Get()
        {
            HttpClient client = new HttpClient();
            HttpResponseMessage response = await client.GetAsync("http://localhost");
            IEnumerable<Contact> list = await response.Content.ReadAsAsync<IEnumerable<Contact>>();
            return list;
        }

        public async Task Post()
        {
            Contact entity = new Contact()
            {
                Name = "youtao",
                Phone = "123456",
                Email = "123456@qq.com"
            };
            HttpClient client = new HttpClient();
            HttpResponseMessage response = await client.PostAsJsonAsync("http://localhost", entity);
        }
    }
}