using Mino.Models;
using System.Collections.Generic;

namespace Mino.ViewModels
{
    public class TasksViewModel
    {
        public IEnumerable<Tasks> Tasks { get; set; }
    }
}