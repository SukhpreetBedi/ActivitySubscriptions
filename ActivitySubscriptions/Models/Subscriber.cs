using System;
using System.Collections.Generic;

#nullable disable

namespace ActivitySubscriptions.Models
{
    public partial class Subscriber
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmailAddress { get; set; }
        public int? ActivityId { get; set; }
        public string Comments { get; set; }

        public virtual Activity Activity { get; set; }
    }
}
