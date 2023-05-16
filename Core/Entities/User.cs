using Core.Entities;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;

namespace Core.Entities
{
    public class User : IdentityUser
    {
        public virtual ICollection<Booking> Bookings { get; } = new List<Booking>();
    }
}