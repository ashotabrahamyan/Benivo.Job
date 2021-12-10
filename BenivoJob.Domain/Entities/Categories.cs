using System;

namespace BenivoJob.Domain.Entities
{
    public class Categories
    {
        public Categories()
        {

        }
        public Categories(string name,DateTime createDate,DateTime lastUpdate,bool isDeleted)
        {
           
            Name = name;
            CreateDate = createDate;
            LastUpdate = lastUpdate;
            IsDeleted = isDeleted; 
        }

        public long Id { get; private set; }
        public string Name { get; private set; }
        public DateTime CreateDate { get; private set; }
        public DateTime LastUpdate { get; private set; }
        public bool IsDeleted { get; private set; }
        public static Categories Load(long id, string name, DateTime createDate, DateTime lastUpdate, bool isDeleted)
        {
            var categories = new Categories
            {
                Id = id,
                Name = name, 
                CreateDate = createDate,
                LastUpdate = lastUpdate,
                IsDeleted = isDeleted
            };
            return categories;
        }
    }
}
