using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plugin.RestClient
{
    /// <summary>
    /// Sample model to test the RestClient object 
    /// with the web service available on:
    /// http://taskmodel.azurewebsites.net/api/TaskModels/
    /// </summary>
    public class TaskModel
    {

        public int Id { get; set; }

        public string Title { get; set; }

        public string Content { get; set; }

        public DateTime CreatedAt { get; set; }
    }
}
