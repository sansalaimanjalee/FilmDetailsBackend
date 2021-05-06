using i_wonder_project.OtherClasses;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using WebApi.Models;

namespace i_wonder_project.Controllers
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [Route("[controller]/[action]")]
    public class FilmsController : ControllerBase
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public FilmsController(IHttpClientFactory clientFactory)
        {
            _httpClientFactory = clientFactory;
        }

        [HttpGet]
        public List<Films> GetFilms()
        {
            PublicAPiConnectors connector = new PublicAPiConnectors();
            List<Films> filmsList = connector.GetFilmDetails(_httpClientFactory);
            return filmsList;
        }
    }
}
