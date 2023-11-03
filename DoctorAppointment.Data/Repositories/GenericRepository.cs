using MyDoctorAppointment.Data.Configuration;
using MyDoctorAppointment.Data.Interfaces;
using MyDoctorAppointment.Domain.Entities;
using System.Xml.Linq;
using System.Xml.Serialization;
using Newtonsoft.Json;
using System.Xml;
using Formatting = Newtonsoft.Json.Formatting;
using System.Xml.XPath;
using Microsoft.VisualBasic;
using System.Text;

namespace MyDoctorAppointment.Data.Repositories
{
    public abstract class GenericRepository<TSource> : IGenericRepository<TSource> where TSource : Auditable
    {
        public abstract string Path { get; set; }

        //public abstract string XMLPath { get; set; }

        public abstract int LastId { get; set; }

        public TSource Create(TSource source)
        {
            source.Id = ++LastId;
            source.CreatedAt = DateTime.Now;

            File.WriteAllText(Path, JsonConvert.SerializeObject(GetAll().Append(source), Formatting.Indented));
            SaveLastId();

            return source;
        }


        public abstract TSource CreateXML(TSource source);

        public bool Delete(int id)
        {
            if (GetById(id) is null)
                return false;

            File.WriteAllText(Path, JsonConvert.SerializeObject(GetAll().Where(x => x.Id != id), Formatting.Indented));

            return true;
        }

        public IEnumerable<TSource> GetAll()
        {
            if (!File.Exists(Path))
            {
                File.WriteAllText(Path, "[]");
            }

            var json = File.ReadAllText(Path);

            if (string.IsNullOrWhiteSpace(json))
            {
                File.WriteAllText(Path, "[]");
                json = "[]";
            }

            return JsonConvert.DeserializeObject<List<TSource>>(json)!;

            
        }

        public TSource? GetById(int id)
        {
            
            return GetAll().FirstOrDefault(x => x.Id == id);
            
        }

        public TSource Update(int id, TSource source)
        {
            source.UpdatedAt = DateTime.Now;
            source.Id = id;

            File.WriteAllText(Path, JsonConvert.SerializeObject(GetAll().Select(x => x.Id == id ? source : x), Formatting.Indented));

            return source;
        }

        public abstract TSource ShowInfo(TSource source);

        protected abstract void SaveLastId();


        protected dynamic ReadFromAppSettings() => JsonConvert.DeserializeObject<dynamic>(File.ReadAllText(Configuration.Constants.AppSettingsPath));
        //protected dynamic ReadFromSettingsXML() => XmlConvert.DecodeName(Constants.SettingsPathXML);

    }
}
