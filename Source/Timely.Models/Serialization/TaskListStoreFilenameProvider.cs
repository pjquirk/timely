using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Timely.Models.Serialization
{
    public class TaskListStoreFilenameProvider : ITaskListStoreFilenameProvider
    {
        public string GetFileName()
        {
            return Path.Combine(
                Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),
                "tasklist.xml");
        }
    }
}
