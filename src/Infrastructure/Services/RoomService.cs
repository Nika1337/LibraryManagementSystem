using AutoMapper;
using Nika1337.Library.Application.Abstractions;
using Nika1337.Library.Application.DataTransferObjects.Library;
using Nika1337.Library.Application.DataTransferObjects.Library.Rooms;
using Nika1337.Library.Domain.Abstractions;
using Nika1337.Library.Domain.Entities;
using Nika1337.Library.Domain.Exceptions;
using Nika1337.Library.Domain.RequestFeatures;
using Nika1337.Library.Domain.Specifications;
using Nika1337.Library.Domain.Specifications.Rooms;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Nika1337.Library.Infrastructure.Services;

internal class RoomService : BaseModelService<Room>, IRoomService
{
    private readonly IMapper _mapper;

    public RoomService(
        IRepository<Room> repository,
        IMapper mapper) : base(repository)
    {
        _mapper = mapper;
    }

    public async Task<IEnumerable<RoomPrimitiveResponse>> GetActiveBooksAsync()
    {
        var specification = new NonDeletedSpecification<Room>();

        var rooms = await _repository.ListAsync(specification);

        var response = _mapper.Map<IEnumerable<RoomPrimitiveResponse>>(rooms);

        return response;
    }
    public async Task<PagedList<RoomPreviewResponse>> GetPagedRoomsAsync(BaseModelPagedRequest<Room> request)
    {
        var specificationParameters = _mapper.Map<BaseModelSpecificationParameters<Room>>(request);

        var specification = new RoomsSpecification(specificationParameters);

        var rooms = await _repository.PagedListAsync(specification, request.PageNumber, request.PageSize);

        var response = _mapper.Map<PagedList<RoomPreviewResponse>>(rooms);

        return response;
    }

    public async Task<RoomDetailedResponse> GetRoomAsync(int id)
    {
        var room = await GetDetailedRoomAsync(id);
        
        var response = _mapper.Map<RoomDetailedResponse>(room);

        return response;
    }

    public async Task CreateRoomAsync(RoomCreateRequest request)
    {
        var room = _mapper.Map<Room>(request);

        await _repository.AddAsync(room);
    }

    public async Task UpdateRoomAsync(RoomUpdateRequest request)
    {
        var room = await GetEntityAsync(request.Id);

        _mapper.Map(request, room);

        await _repository.UpdateAsync(room);
    }

    private async Task<Room> GetDetailedRoomAsync(int id)
    {
        var specification = new RoomByIdSpecification(id);

        var room = await _repository.SingleOrDefaultAsync(specification) ?? throw new NotFoundException<Room>(id);

        return room;
    }
}
