using Microsoft.AspNetCore.Mvc;
using System.Runtime.InteropServices;
using static aspnettest.Controllers.BookingsController;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace aspnettest.Controllers
{

    //public interface IBookingService
    //{
    //    IEnumerable<Booking> GetAllBookings();
    //    Booking? GetBookingById(int id);
    //    Booking CreateBooking(Booking booking);
    //    bool DeleteBooking(int id);
    //}

    [Route("api/[controller]")]
    [ApiController]
    public class BookingsController : ControllerBase
    {
        public class Booking
        {
            public int Id { get; set; }
            public string GuestName { get; set; }
            public int RoomId { get; set; }
            public DateTime CheckInDate { get; set; }
            public DateTime CheckOutDate { get; set; }
        }

        private static readonly List<Booking> Bookings = new List<Booking> { };

        // GET: api/<BookingsController>
        [HttpGet]
        public ActionResult<IEnumerable<Booking>> GetBooking()
        {
            return Ok(Bookings);
        }

        // GET api/<BookingsController>/5
        [HttpGet("{id}")]
        public IActionResult GetBookingById(int id)
        {

            var booking = Bookings.Find(b => b.Id == id);
            if (booking != null)
            {
                return Ok(booking);
            }
            else 
            {
                return NotFound(new { Message = $"Booking with Id {id} not found." });
            }

        }

        // POST api/<BookingsController>
        [HttpPost]
        public IActionResult CreateBooking([FromBody] Booking newBooking)
        {
            newBooking.Id = Bookings.Count + 1;

            var room = RoomsController.Rooms.Find(r => r.Id == newBooking.RoomId);
            if (room == null)
                return BadRequest(new { Message = "Invalid RoomId" });
            else if (room.IsAvailable == false)
                return BadRequest(new { Message = "Room Booked" });
                Bookings.Add(newBooking);

            return CreatedAtAction(nameof(GetBookingById), new { id = newBooking.Id }, newBooking);
        }

        //// PUT api/<BookingsController>/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody] string value)
        //{
        //}

        // DELETE api/<BookingsController>/5
        [HttpDelete("{id}")]
        public IActionResult DeleteBookingById(int id)
        {
            var booking = Bookings.Find(b => b.Id == id);
            Bookings.Remove(booking);
            return Ok(new { Message = $"Booking with Id {id} removed." });
        }
    }
}
