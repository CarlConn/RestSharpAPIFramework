using System.Collections.Generic;

namespace RestAPIFramework.Models
{
    public class Users
    {
        public int page { get; set; }
        public int per_page { get; set; }
        public int total { get; set; }
        public int total_pages { get; set; }
        public IList<UserData> data { get; set; }
    }
}