using EntityLayer.Concrete;
using System;
using System.Collections.Generic;

namespace DataAccessLayer;

public partial class City
{
    public int CityId { get; set; }

    public string CityName { get; set; } = null!;
    public virtual ICollection<Event> Events { get; set; }
}
