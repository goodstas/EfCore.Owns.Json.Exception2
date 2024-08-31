using WebApplication1.Interfaces;

namespace WebApplication1.Models
{
    public class SubDetail : IShouldBeDetachedOnDelete
    {
        public int IntSubDetail { get; set; }
        public string StrSubDetail { get; set; }

        public double DoubleSubDetail { get; set; }
    }
}
