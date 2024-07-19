using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Nika1337.Library.Application.Abstractions;
using Nika1337.Library.Application.DataTransferObjects.Library.Rooms;
using Nika1337.Library.Domain.Entities;
using Nika1337.Library.Domain.Exceptions;
using Nika1337.Library.Domain.RequestFeatures;
using Nika1337.Library.Presentation.Models;
using Nika1337.Library.Presentation.Models.Rooms;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Nika1337.Library.Presentation.Controllers;

[Authorize(Roles = "Location Manager")]
[Route("Rooms")]
public class RoomsController : BaseModelController<Room>
{
    private readonly IRoomService _roomService;
    private readonly IMapper _mapper;

    protected override Dictionary<string, SortOption<Room>> SortOptions =>
     new()
     {
            { "roomNum", new("Room Number: Ascending", room => room.RoomNumber) },
            { "roomNumDesc", new( "Room Number: Descending", room => room.RoomNumber, true) },
            { "floor", new("Floor: Ascending", room => room.Floor) },
            { "floorDesc", new("Floor: Descending", room => room.Floor, true) },
            { "maxCap", new("Max Capacity Of People: Ascending", room => room.MaxCapacityOfPeople) },
            { "maxCapDesc", new("Max Capacity Of People: Descending", room => room.MaxCapacityOfPeople, true) },
            { "editionsCount", new("Editions Released Count: Ascending", room => room.BookEditions.Count) },
            { "editionsCountDesc", new("Editions Released Count: Descending", room => room.BookEditions.Count, true) },
     };

    public RoomsController(
        IRoomService service,
        IMapper mapper) : base(service)
    {
        _roomService = service;
        _mapper = mapper;
    }

    [HttpGet(Name = "Rooms")]
    public async Task<IActionResult> Rooms(
        int pageNumber = 1,
        int pageSize = 10,
        string? searchTerm = null,
        string? sortField = null,
        bool doNotIncludeDeleted = false)
    {
        var request = ConstructBaseModelPagedRequest(pageNumber, pageSize, searchTerm, sortField, !doNotIncludeDeleted);

        var rooms = await _roomService.GetPagedRoomsAsync(request);

        var model = _mapper.Map<PagedList<RoomPreviewViewModel>>(rooms);

        return View(model);
    }

    [HttpGet("[action]")]
    public IActionResult AddRoom()
    {
        var model = new RoomCreateViewModel();

        return View(model);
    }

    [HttpPost("[action]")]
    public async Task<IActionResult> AddRoom(RoomCreateViewModel model)
    {
        if (!ModelState.IsValid)
        {
            return View(model);
        }

        var request = _mapper.Map<RoomCreateRequest>(model);

        try
        {
            await _roomService.CreateRoomAsync(request);
        }
        catch (DuplicateException)
        {
            model.ErrorMessage = $"Room With Number '{model.RoomNumber}' already exists";
            return View(model);
        }

        return RedirectToAction("Rooms");
    }

    [HttpGet("{id:int}")]
    public async Task<IActionResult> Rooms(int id)
    {
        var room = await _roomService.GetRoomAsync(id);

        var model = _mapper.Map<RoomDetailedViewModel>(room);

        return View("Room",model);
    }

    [HttpPost("{id:int}")]
    public async Task<IActionResult> Rooms(RoomDetailedViewModel model)
    {
        if (!ModelState.IsValid)
        {
            return View("Room", model);
        }

        var request = _mapper.Map<RoomUpdateRequest>(model);

        try
        {
            await _roomService.UpdateRoomAsync(request);
        }
        catch (DuplicateException)
        {
            model.ErrorMessage = $"Room With Number '{model.RoomNumber}' already exists";
            return View("Room", model);
        }

        return RedirectToRoute("Rooms");
    }


    [HttpGet("[action]")]
    public async Task<IActionResult> GetActiveRooms()
    {
        var rooms = await _roomService.GetActiveRoomsAsync();

        return Ok(rooms);
    }
}
