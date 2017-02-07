using System.Collections.Generic;
using Mino.Core.Models;

namespace Mino.Core.ViewModels
{
    public class WeeklyTasksViewModel
    {
        public Dictionary<string, IEnumerable<Tasks>> Tasks;

        public WeeklyTasksViewModel(Dictionary<string, IEnumerable<Tasks>> tasks)
        {
            Tasks = tasks;
        }
    }
}
