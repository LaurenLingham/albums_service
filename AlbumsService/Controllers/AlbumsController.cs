using Microsoft.AspNetCore.Mvc;

namespace AlbumsService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlbumsController : ControllerBase
    {
        private Dictionary<int, string> _albums = new Dictionary<int, string>();

        public AlbumsController()
        {
            _albums.Add(1, "album 1");
            _albums.Add(2, "album 2");
        }

        [HttpGet]
        public IEnumerable<string> Get()
        {
            return _albums.Values.ToList();
        }

        [HttpGet("{id}")]
        public string Get(int id)
        {
            return _albums[id];
        }

        [HttpPost]
        public void Post([FromBody] string value)
        {
            int id;

            do
            {
                id = new Random().Next(1000);
            }
            while (_albums.ContainsKey(id));

            _albums.Add(id, value);
        }

        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
            _albums[id] = value;
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _albums.Remove(id);
        }
    }
}
