using System.Collections.Generic;
using Mino.Models;

namespace Mino.ViewModels
{
    public class WeeklyTasksViewModel
    {
        public Dictionary<string, IEnumerable<Tasks>> Tasks = new Dictionary<string, IEnumerable<Tasks>>();
    }
}
// lista 2 elementowa