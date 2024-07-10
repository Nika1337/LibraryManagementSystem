
using System.Linq;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Nika1337.Library.Presentation.Models;

public abstract class FilterOption
{
    public required string Name { get; init; }
    public abstract string Type { get; }
    public string ToJsonString()
    {
        var properties = GetType().GetProperties()
            .Where(prop => prop.CanRead && !prop.IsDefined(typeof(JsonIgnoreAttribute), false))
            .ToDictionary(prop => prop.Name, prop => prop.GetValue(this, null));

        properties["Type"] = Type;
        properties["Name"] = Name;

        return JsonSerializer.Serialize(properties);
    }
}

public class RangeFilterOption : FilterOption
{
    public override string Type => "range";
    public required RangeFilterOptionType RangeFilterOptionType { get; init; }
}
public enum RangeFilterOptionType
{
    Date,
    Time,
    DateTime,
    Number
}
public class BoolFilterOption : FilterOption
{
    public override string Type => "bool";
}

public class ListFilterOption : FilterOption
{
    public override string Type => "list";
    public required string[] Choices { get; init; }
}