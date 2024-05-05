namespace Vrika.Models
{
    public class Books
    {
        public int Id { get; set; }
        public required string BookName { get; set; }
        public required string BookPrice { get; set; }
        public  required string Author { get; set; }
        public required string Genre{ get; set; }
        public  required string Url { get; set; }
    }
}
