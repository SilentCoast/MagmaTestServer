namespace MagmaTestServer.Classes
{
    public class files
    {
        public files() { }
        public string? filename { get; set; }
        public errors[]? errors { get; set; }  
    }
    public class errors
    {
        public errors() { }
        public string? error { get; set; }
    }
}
