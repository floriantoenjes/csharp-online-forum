using System;

namespace OnlineForum.Models
{
    public interface IHasCreatedAt
    {
        DateTime CreatedAt { get; set; }
    }
}