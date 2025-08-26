
# Softinn Junior Back-end C# Developer Test

Creating a backend for a room booking




## Run Locally

Clone the project

```bash
  git clone https://github.com/NewPenguin/restfulapitest.git
```

Go to the project directory

```bash
  cd aspnettest
```

Open *aspnettest.sln* file with *visual studio* and run with *https*

## Documentation

Under RoomsController,I have created 2 Get:
```bash
GET /api/Rooms
```
Grabs the whole list of the rooms available and not available. In most cases for frontend development we would be displaying all status, available or unavailable rooms for the users to check out the all the rooms that the client may have.
```bash
GET /api/Rooms/{id}
```
Grabs specific room by id. In many cases like users would click on an item to view more details about it, we would then give them more information about that specific object.

Under BookingsController,I have created 2 Get, 1 Post and 1 Delete:
```bash
GET /api/Bookings
```
Grabs all booked rooms. In cases where users may book multiple, they could check on the list of rooms that they had made booking.
```bash
GET /api/Bookings/{id}
```
Grabs specific booking by id. For users to enter and view more about the booked room.
```bash
POST /api/Bookings
```
Sends request to/add into table of booked rooms. Updates the table for booked room made by users. Request format as shown:
```bash
{
    "guestName": "John Doe",
    "roomId": 1,
    "checkInDate": "2025-05-01",
    "checkOutDate": "2025-05-03"
}
```
Finally,
```bash
DELETE /api/Bookings/{id}
```
Submits deletion of booking by id. This api could be used after grabbing specific booking by id, where users could then delete the booking records in case they do not want it anymore.

