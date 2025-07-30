using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using BuildSphere.Core.Definitions;

namespace BuildSphere.Data.TextFile
{
    public abstract class SharedFileStorageManager<TObject>
    {
        public SharedFileStorageManager(string filePath) 
        {
            _filePath = filePath;
        }

        private void Load()
        {
            if (!File.Exists(_filePath)) { }
                return;

            var jsonString = File.ReadAllText(_filePath);
            _data = JsonSerializer.Deserialize<List<TObject>>(jsonString);
        }

        private void Save()
        {
            lock (_lock)
            {
                var json = JsonSerializer.Serialize(_data, new JsonSerializerOptions { WriteIndented = true });
                File.WriteAllText(_filePath, json);
            }
        }

        private List<TObject> _data = new();
        private readonly object _lock = new();
        private readonly string _filePath;
    }
}
