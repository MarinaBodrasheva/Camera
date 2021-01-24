using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using CameraSearchService.Entities;
using TinyCsvParser;
using TinyCsvParser.Mapping;

namespace CameraSearchService.Repo
{
    public class CameraDataCsvRepository : ICameraDataRepository
    {
        //TODO: Move to configurations
        private const string FILENAME = "cameras-defb.csv";

        public IEnumerable<CameraData> GetData(string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                return GetData();
            }

            var records = GetRecords();
            return records.Where(x => x?.Result?.Camera != null && x.Result.Camera.Contains(name))
                .Select(x => x.Result)
                .ToList();
        }

        public IEnumerable<CameraData> GetData()
        {
            var records = GetRecords();
            return records.Where(x => x?.Result?.Camera != null)
                .Select(x => x.Result)
                .ToList();
        }

        private static ParallelQuery<CsvMappingResult<CameraData>> GetRecords()
        {
            CsvParserOptions csvParserOptions = new CsvParserOptions(true, ';');
            var csvParser = new CsvParser<CameraData>(csvParserOptions, new CsvCameraDataMapping());
            var appDomain = System.AppDomain.CurrentDomain;
            var basePath = appDomain.RelativeSearchPath ?? appDomain.BaseDirectory;

            string path = Path.Combine(basePath, "Data", FILENAME);
            var records = csvParser.ReadFromFile(path, Encoding.UTF8);
            return records;
        }
    }
}