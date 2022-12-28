namespace MagmaTestServer.Classes
{
    public class Files
    {
        public Files() { }
        public string? filename { get; set; }
        public Errors[]? errors { get; set; }  
    }
    public class Errors
    {
        public Errors() { }
        public string? error { get; set; }
    }
}
