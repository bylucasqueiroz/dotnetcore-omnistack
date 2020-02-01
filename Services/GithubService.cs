using System.Net.Http;
using System.Net.Http.Headers;
using Newtonsoft.Json;
using System.Threading.Tasks;
using Omnistack.Models.User;

namespace Omnistack.Services
{
    public class Github
    {
        public string avatar_url { get; set; }
        public string url { get; set; }
        public string name { get; set; }
        public string company { get; set; }
        public string location { get; set; }
        public string bio { get; set; }
    }
    public static class GithubService
    {
        public static void InsertGitHubUser(User item)
        {
            var inGithub = GetInfoGitHub(item.UserName);

            item.Name = inGithub.name;
            item.Location = inGithub.location;
            item.Avatar = inGithub.avatar_url;
            item.Bio = inGithub.bio;
            item.Linkedin = inGithub.company;
            item.Url = inGithub.url;
        }

        private static Github GetInfoGitHub(string name)
        {
            return ProcessRepositories(name).Result;
        }

        private static async Task<Github> ProcessRepositories(string name)
        {
            HttpClient client = new HttpClient();
            
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/vnd.github.v3+json"));
            client.DefaultRequestHeaders.Add("User-Agent", "Application Omnistack");

            HttpResponseMessage  response  = await client.GetAsync($"https://api.github.com/users/" + name);
            HttpContent content = response.Content;

            string stringJson = await content.ReadAsStringAsync();
            Github rota = JsonConvert.DeserializeObject<Github>(stringJson);

            return rota;
        }

        
    }
}