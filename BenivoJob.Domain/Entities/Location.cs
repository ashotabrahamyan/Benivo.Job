using System;

namespace BenivoJob.Domain.Entities
{
    public class Location
    {
        public Location()
        {

        }
        public Location(string country,string city, DateTime createDate, DateTime lastUpdate, bool isDeleted)
        {
            
            Country = country;
            City = city;
            CreateDate = createDate;
            LastUpdate = lastUpdate;
            IsDeleted = isDeleted;
        }


        public long Id { get; private set; }
        public string Country { get; private set; }
        public string City { get; private set; }
        public DateTime CreateDate { get; private set; } 
        public DateTime LastUpdate { get; private set; }
        public bool IsDeleted { get; private set; }

        public static Location Load(long id, string country, string city, DateTime createDate, DateTime lastUpdate, bool isDeleted)
        {
            var location = new Location
            {
                Id = id,
                Country = country,
                City = city,
                CreateDate = createDate,
                LastUpdate = lastUpdate,
                IsDeleted = isDeleted
            };
            return location;
        }
    }
}
