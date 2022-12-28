namespace MagmaTestServer.Classes
{
    public class Querychek
    {
        public Querychek() { }
        public int total { get; set; }
        public int correct { get; set; }
        public int errors { get; set; }
        public string[]? filenames { get; set; }
    }
}
