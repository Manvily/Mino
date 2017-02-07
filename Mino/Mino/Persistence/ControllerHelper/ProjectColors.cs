using System.Collections.Generic;
using System.Web.Mvc;

namespace Mino.Persistence.ControllerHelper
{
    public class ProjectColors
    {
        public IEnumerable<SelectListItem> Colors { get; }

        public ProjectColors()
        {
            Colors = new List<SelectListItem>
            {
                new SelectListItem {Text = "BLUE", Value = "BLUE"},
                new SelectListItem {Text = "AQUA", Value = "AQUA"},
                new SelectListItem {Text = "TEAL", Value = "TEAL"},
                new SelectListItem {Text = "OLIVE", Value = "OLIVE"},
                new SelectListItem {Text = "GREEN", Value = "GREEN"},
                new SelectListItem {Text = "LIME", Value = "LIME"},
                new SelectListItem {Text = "YELLOW", Value = "YELLOW"},
                new SelectListItem {Text = "ORANGE", Value = "ORANGE"},
                new SelectListItem {Text = "RED", Value = "RED"},
                new SelectListItem {Text = "MAROON", Value = "MAROON"},
                new SelectListItem {Text = "FUCHSIA", Value = "FUCHSIA"},
                new SelectListItem {Text = "PURPLE", Value = "PURPLE"},
                new SelectListItem {Text = "BLACK", Value = "BLACK"},
                new SelectListItem {Text = "GRAY", Value = "GRAY"},
                new SelectListItem {Text = "SILVER", Value = "SILVER"}
            };
        }
    }
}