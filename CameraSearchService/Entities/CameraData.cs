namespace CameraSearchService.Entities
{
    public class CameraData
    {
        public string Camera { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public int Number => GetNumber();

        private int GetNumber()
        {
            //TODO: Refactor to regex camera number parsing
             string n = Camera.Substring(7, 3);
             return int.Parse(n);
        }
    }
}
