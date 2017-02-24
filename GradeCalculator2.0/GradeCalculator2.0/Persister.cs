using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace GradeCalculator2
{
    class Persister<Course>
    {
        private string fileName;

        public List<Course> SavedCourses { get; set; }
        

        public Persister(string courseListName)
        {
            //string path = AppDomain.CurrentDomain.ToString();
            this.fileName = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, courseListName + ".xml"); 
            this.SavedCourses = Activator.CreateInstance<List<Course>>(); ;
        }

        public void Save()
        {
            lock (fileName)
            {
                using (FileStream writer = File.Create(fileName))
                {
                    XmlSerializer serializer = new XmlSerializer(SavedCourses.GetType());
                    serializer.Serialize(writer, SavedCourses);
                }
            }
        }

        public void Load()
        {
            if (File.Exists(fileName))
            {
                lock (fileName)
                {
                    using (FileStream reader = File.Open(fileName,
                             FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
                    {
                        XmlSerializer serializer = new XmlSerializer(typeof(List<Course>));
                        SavedCourses = (List<Course>)serializer.Deserialize(reader);
                    }
                }
            }
            else
            {
                SavedCourses = new List<Course>();
                Save();
            }
        }
    }
}
