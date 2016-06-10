using System;

namespace CustomerData.Model
{
    public class Data
    {

        public Guid Guid { get; set; }
        public Uri Picture { get; set; }
        public string Name { get; set; }
        public string Gender { get; set; }
        public string Company { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public string About { get; set; }
        public DateTime Registered { get; set; }
        public string[] Tags { get; set; }

    }
}
