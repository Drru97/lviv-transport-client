using System.Linq;
using System.Threading.Tasks;
using AngleSharp.Parser.Html;
using LvivTransport.Client.Core.Models;
using Newtonsoft.Json;

namespace LvivTransport.Client.Core.Common
{
    internal class StopsHtmlParser
    {
        private readonly HtmlParser _parser;

        public StopsHtmlParser()
        {
            _parser = new HtmlParser();
        }

        public async Task<string> ParseStops(string html)
        {
            var angle = await _parser.ParseAsync(html);

            var stops = (from element in angle.QuerySelectorAll("tbody tr")
                         select element.TextContent
                into textContent
                         select textContent.Trim().Split('\n')
                into data
                         select new Stop
                         {
                             Name = data[0],
                             Longitude = double.Parse(data[1]),
                             Latitude = double.Parse(data[2]),
                             Id = int.Parse(data[4])
                         }).ToList();

            return JsonConvert.SerializeObject(stops);
        }
    }
}
