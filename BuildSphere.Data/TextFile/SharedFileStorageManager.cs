using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using BuildSphere.Core.Definitions;
using BuildSphere.Core.Interfaces;

namespace BuildSphere.Data.TextFile
{
    public abstract class SharedFileStorageManager<TObject>
        where TObject : class, IIdentifiable, new()
    {
        public SharedFileStorageManager(string fileName) 
        {
            _data = new();
            _fileFullPath = Path.Combine(_projectPath, "BuildSphere.Data", "TextFile", "DataStorage", fileName);
            LoadFile();
        }

        public virtual IEnumerable<TObject> Get()
        {
            lock (_lock)
            {
                return _data.Select(p => p).ToList();
            }
        }

        public virtual TObject GetById(int id)
        {
            lock (_lock)
            {
                return _data.First(p => p.Id == id);
            }
        }


        public virtual void Add(TObject obj)
        {
            lock (_lock)
            {
                obj.Id = _nextId++;
                _data.Add(obj);
                SaveFile();
            }
        }

        public virtual void Update(int id, TObject obj)
        {
            lock (_lock)
            {
                var index = _data.FindIndex(p => p.Id == id);
                if (index != -1)
                {
                    _data[index] = obj;
                    SaveFile();
                }
                else
                    throw new KeyNotFoundException($"Key not found: {id}");
            }
        }

        public virtual void Delete(int id)
        {
            lock (_lock)
            {
                var removed = _data.RemoveAll(p => p.Id == id);
                if (removed <= 0)
                    throw new KeyNotFoundException($"Key not found: {id}");

                SaveFile();
            }
        }

        private void LoadFile()
        {
            var jsonString = File.ReadAllText(_fileFullPath);
            if (!string.IsNullOrWhiteSpace(jsonString))
            {
                _data = JsonSerializer.Deserialize<List<TObject>>(jsonString);
                _nextId = _data.Max(item => item.Id) + 1;
                return;
            }

            _data = new List<TObject>();
            _nextId = 1;
        }

        private void SaveFile()
        {
            lock (_lock)
            {
                var json = JsonSerializer.Serialize(_data, new JsonSerializerOptions { WriteIndented = true });
                File.WriteAllText(_fileFullPath, json);
            }
        }

        private List<TObject> _data;
        private int _nextId;
        private readonly object _lock = new();
        private static string _projectPath = Directory.GetParent(AppContext.BaseDirectory)!.Parent!.Parent!.Parent!.Parent!.FullName;
        private readonly string _fileFullPath; 
    }
}
