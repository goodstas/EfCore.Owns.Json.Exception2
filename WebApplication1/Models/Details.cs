using WebApplication1.Interfaces;

namespace WebApplication1.Models
{
    public class Details : IShouldBeDetachedOnDelete
    {
        public bool BoolDetail { get; set; }

        public string StrDetail { get; set; }

        public List<SubDetail> SubDetails { get; set; }
    }
}
