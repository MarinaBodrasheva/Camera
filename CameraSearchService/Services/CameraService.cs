using System.Collections.Generic;
using CameraSearchService.Entities;
using CameraSearchService.Repo;

namespace CameraSearchService.Services
{
    public class CameraService: ICameraService
    {
        private ICameraDataRepository repository { get; set; }

        public CameraService(ICameraDataRepository repository)
        {
            this.repository = repository;
        }

        public IEnumerable<CameraData> GetData(string name)
        {
            return repository.GetData(name);
        }
        public IEnumerable<CameraData> GetData()
        {
            return repository.GetData();
        }
    }
}
