
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Nika1337.Library.Presentation.Models;

public abstract class FilterOption
{
    public required string Name { get; init; }
    public abstract string Type { get; }
    public virtual string ToJsonString()
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
    public required RangeFilterOptionType RangeFilterOptionType { get; set; }

    private string GetFormattedRangefilterOptionTypeForJavascript()
    {
        var javascriptType = RangeFilterOptionType switch
        {
            RangeFilterOptionType.Date => "date",
            RangeFilterOptionType.DateTime => "datetime-local",
            RangeFilterOptionType.Number => "number",
            _ => "text"
        };

        return javascriptType;
    }

    public override string ToJsonString()
    {
        var properties = new Dictionary<string, string>();

        properties["Type"] = Type;
        properties["Name"] = Name;
        properties["RangeFilterOptionType"] = GetFormattedRangefilterOptionTypeForJavascript();

        return JsonSerializer.Serialize(properties);
    }
}

public enum RangeFilterOptionType
{
    Date,
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