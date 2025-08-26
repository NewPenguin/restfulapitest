using Microsoft.AspNetCore.Mvc;
using static aspnettest.Controllers.RoomsController;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace aspnettest.Controllers
{

    public interface IRoomService
    {
        IEnumerable<Room> GetAllRooms();
        Room? GetRoomById(int id);
    }

    [Route("api/[controller]")]
    [ApiController]
    public class RoomsController : IRoomService
    {

        public class Room
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public string Type { get; set; }
            public bool IsAvailable { get; set; }
        }

        public static readonly List<Room> Rooms = new List<Room>
        {
            new Room { Id = 1, Name = "101", Type = "Single", IsAvailable = true },
            new Room { Id = 2, Name = "102", Type = "Double", IsAvailable = true },
            new Room { Id = 3, Name = "103",Type = "Suite", IsAvailable = true },
            new Room { Id = 4, Name = "201", Type = "Single", IsAvailable = true },
            new Room { Id = 5, Name = "202", Type = "Double", IsAvailable = true }
        };

        /// <summary>
        /// When using interfaces for the dependancy thing the normal method is no need
        /// </summary>
        /// <returns></returns>
        //// GET: api/<RoomsController>
        //[HttpGet]
        //public ActionResult<IEnumerable<Room>> GetRooms()
        //{
        //    return Ok(Rooms);
        //}

        //// GET api/<RoomsController>/5
        //[HttpGet("{id}")]
        //public ActionResult<Room> GetRoomById(int id)
        //{
        //    var room = Rooms.Find(r => r.Id == id);
        //    if (room == null)
        //        return NotFound(new { Message = $"Room with Id {id} not found." });

        //    return Ok(room);
        //}

        public IEnumerable<Room> GetAllRooms() => Rooms;

        public Room? GetRoomById(int id) => Rooms.FirstOrDefault(r => r.Id == id);

        //// POST api/<RoomsController>
        //[HttpPost]
        //public void Post([FromBody] string value)
        //{
        //}

        //// PUT api/<RoomsController>/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody] string value)
        //{
        //}

        //// DELETE api/<RoomsController>/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
    }
}
