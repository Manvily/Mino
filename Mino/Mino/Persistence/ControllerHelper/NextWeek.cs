using Mino.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Mino.Persistence.ControllerHelper
{
    public class NextWeek
    {
        private Dictionary<string, IEnumerable<Tasks>> Week { get; }
        private readonly IEnumerable<Tasks> _tasks;

        public NextWeek(IEnumerable<Tasks> tasks)
        {
            _tasks = tasks;
            Week = new Dictionary<string, IEnumerable<Tasks>>
            {
                {
                    "Today",
                    GetTasksInDay(0)
                },
                {
                    "Tomorrow",
                    GetTasksInDay(1)
                },
                {
                    GetDayName(2),
                    GetTasksInDay(2)
                },
                {
                    GetDayName(3),
                    GetTasksInDay(3)
                },
                {
                    GetDayName(4),
                    GetTasksInDay(4)
                },
                {
                    GetDayName(5),
                    GetTasksInDay(5)
                },
                {
                    GetDayName(6),
                    GetTasksInDay(6)
                }
            };
        }

        public Dictionary<string, IEnumerable<Tasks>> GetWeekTasks() => Week;

        private static string GetDayName(int days) =>
            DateTime.Today.AddDays(days).DayOfWeek.ToString();

        private IEnumerable<Tasks> GetTasksInDay(int days)
        {
            var startDay = DateTime.Today.AddDays(days);
            var endDay = startDay.AddDays(1);

            return _tasks.Where(a =>
                a.DateTime >= startDay &&
                a.DateTime < endDay)
                .ToList();
        }
    }
}