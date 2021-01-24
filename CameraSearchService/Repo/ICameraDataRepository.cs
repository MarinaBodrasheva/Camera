using System.Collections.Generic;
using CameraSearchService.Entities;

namespace CameraSearchService.Repo
{
    public interface ICameraDataRepository
    {
        public IEnumerable<CameraData> GetData(string name);
        public IEnumerable<CameraData> GetData();
    }
}