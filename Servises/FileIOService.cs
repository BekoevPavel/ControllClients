using ControllClients.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Text;

namespace ControllClients.Servises
{
    class FileIOService
    {
        private readonly string PATH;
        public FileIOService(string path)
        {
            PATH = path;

        }

        public BindingList<ToDoModel> LoadData()
        {
            var fileExists = File.Exists(PATH);
            if(!fileExists)
            {
                File.CreateText(PATH).Dispose();
                return new BindingList<ToDoModel>();
            }


            using(var reader = File.OpenText(PATH))
            {
                var fileText = reader.ReadToEnd();
                return JsonConvert.DeserializeObject<BindingList<ToDoModel>>(fileText);
            }

            return null;
        }

        public void SaveData(BindingList<ToDoModel> todoDataList)
        {
            using(StreamWriter writer = File.CreateText(PATH))
            {
                string output = JsonConvert.SerializeObject(todoDataList);
                writer.Write(output);
            }

        }

    }
}
