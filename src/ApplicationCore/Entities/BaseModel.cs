using System;

namespace Nika1337.Library.ApplicationCore.Entities;

public abstract class BaseModel : IEquatable<BaseModel>
{
    public int Id { get; set; }
    public DateTime CreationDate { get; set; }
    public DateTime LastUpdatedDate { get; set; } 
    public DateTime? DeletedDate { get; set; }

    public static bool operator ==(BaseModel left, BaseModel right)
    {
        return (left is null && right is null) || (left is not null && left.Equals(right));
    }

    public static bool operator !=(BaseModel left, BaseModel right)
    {
        return !(left == right);
    }

    public bool Equals(BaseModel? other)
    {
        if (other is null)
        {
            return false;
        }

        if (other.GetType() != GetType()) {
            return false;
        }
        return Id == other.Id;
    }
    public override bool Equals(object? obj)
    {
        if (obj is null)
        {
            return false;
        }

        if (obj is not BaseModel model)
        {
            return false;
        }

        return this.Equals(model);
    }
    public override int GetHashCode()
    {
        return Id.GetHashCode() * 41;
    }
}
