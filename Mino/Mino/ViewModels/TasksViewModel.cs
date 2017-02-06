using Mino.Models;
using System.Collections.Generic;

namespace Mino.ViewModels
{
    public class TasksViewModel
    {
        public IEnumerable<Tasks> Tasks { get; set; }
        public string TitleName { get; set; }

        public TasksViewModel(IEnumerable<Tasks> tasks)
        {
            Tasks = tasks;
        }

        public TasksViewModel(IEnumerable<Tasks> tasks, string name)
        {
            Tasks = tasks;
            TitleName = name;
        }
    }
}