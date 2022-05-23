using System.Collections.Generic;

namespace RestAPIFramework.Models
{
    public class GetListUsers
    {
        public int page { get; set; }
        public int per_page { get; set; }
        public int total { get; set; }
        public int total_pages { get; set; }
        public IList<GetListUserData> data { get; set; }
    }
}