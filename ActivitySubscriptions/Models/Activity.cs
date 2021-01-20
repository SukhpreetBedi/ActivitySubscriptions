using System;
using System.Collections.Generic;

#nullable disable

namespace ActivitySubscriptions.Models
{
    public partial class Activity
    {
        public Activity()
        {
            Subscribers = new HashSet<Subscriber>();
        }

        public int Id { get; set; }
        public string ActivityType { get; set; }

        public virtual ICollection<Subscriber> Subscribers { get; set; }
    }
}
