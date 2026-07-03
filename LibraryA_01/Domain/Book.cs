namespace LibraryA_01.Domain
{
    public class Book
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public string ISBN { get; set; }
        public int Year { get; set; }
        public int NumberOfPages { get; set; }
        public bool Available { get; set; }
    }
}
