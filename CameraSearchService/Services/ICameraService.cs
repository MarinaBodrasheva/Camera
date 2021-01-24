using System.Collections.Generic;
using CameraSearchService.Entities;

namespace CameraSearchService.Services
{
    public interface ICameraService
    {
        IEnumerable<CameraData> GetData(string name);
        IEnumerable<CameraData> GetData();
    }
}