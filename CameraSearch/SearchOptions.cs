using CommandLine;

namespace CameraSearch
{
    public class SearchOptions
    {
        [Option('n', "Name")]
        public string Name { get; set; }
    }
}