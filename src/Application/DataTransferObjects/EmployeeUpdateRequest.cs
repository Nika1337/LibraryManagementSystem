


namespace Nika1337.Library.Application.DataTransferObjects;

public abstract record EmployeeUpdateRequest(
    string Id,
    string FirstName,
    string LastName,
    string Username);