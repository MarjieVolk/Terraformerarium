using System.Threading.Tasks;
using NUnit.Framework;
using Terraformerarium.Controllers;
using Terraformerarium.Models;

namespace Terraformerarium.Tests.Controllers
{
    [TestFixture]
    public class SolutionControllerTests
    {
        [Test]
        public async Task SubmitSolution()
        {
            var sc = new SolutionController();
            await sc.SubmitSolution(new SubmitSolutionModel
            {
                LevelKey = "Level1",
                SolutionData = "Some Json Blob"
            });

        }

        [Test]
        public async Task FetchHistogram()
        {
            var sc = new SolutionController();
            var response = await sc.FetchHistogram("Level1");
            for(int i = 0; i < response.ScoreCounts.Length; ++i)
            {
                System.Console.WriteLine("Score:  {0}, CountOfScore: {1}", i, response.ScoreCounts[i]);
            }
        }

        //private readonly Uri RootUrl = new Uri("http://terraformerarium.azurewebsites.net/");

        //[Test]
        //public async void HttpSubmitSolution()
        //{
        //    var client = new HttpClient(new HttpClientHandler()) {BaseAddress = RootUrl};

        //    //client.PostAsync("api/solution");

        //    JsonConvert


        //}
    }
}
