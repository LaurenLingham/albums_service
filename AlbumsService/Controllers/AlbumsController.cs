using Microsoft.AspNetCore.Mvc;

namespace AlbumsService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlbumsController : ControllerBase
    {
        private static Dictionary<Guid, string> _albums = new Dictionary<Guid, string>();

        [HttpGet]
        public Dictionary<Guid, string> Get()
        {
            return _albums;
        }

        [HttpGet("{id}")]
        public string Get(Guid id)
        {
            return _albums[id];
        }

        [HttpPost]
        public void Post([FromBody] string value)
        {
            _albums.Add(Guid.NewGuid(), value);
        }

        [HttpPut("{id}")]
        public void Put(Guid id, [FromBody] string value)
        {
            _albums[id] = value;
        }

        [HttpDelete("{id}")]
        public void Delete(Guid id)
        {
            _albums.Remove(id);
        }

        [HttpDelete]
        public void DeleteAll()
        {
            _albums.Clear();
        }
    }
}
