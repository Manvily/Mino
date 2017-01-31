using System;

namespace Mino.Dtos
{
    public class TaskDto
    {
        public int TaskId { get; set; }
        public int? ProjectId { get; set; }
        public int? TagId { get; set; }
        public string Name { get; set; }
        public string Date { get; set; }
        public string Time { get; set; }

        public DateTime? GetDateTime()
        {
            if (Date == null && Time == null)
                return null;
            if (Date == null)
                return DateTime.Parse($"{Time}");
            if (Time == null)
                return DateTime.Parse($"{Date}");

            return DateTime.Parse($"{Date} {Time}");
        }
    }
}