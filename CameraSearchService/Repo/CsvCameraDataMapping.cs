using CameraSearchService.Entities;
using TinyCsvParser.Mapping;

namespace CameraSearchService.Repo
{
    public class CsvCameraDataMapping : CsvMapping<CameraData>
    {
        public CsvCameraDataMapping() : base()
        {
            MapProperty(0, x => x.Camera);
            MapProperty(1, x => x.Latitude);
            MapProperty(2, x => x.Longitude);
        }
    }
}