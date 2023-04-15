using Microsoft.AspNetCore.Mvc.Rendering;

namespace AWWW_lab2_gr5.Models.ViewModels
{
    public class PlayerAssignedData
    {
        public Player Player { get; set; }
        public SelectList TeamList { get; set; }
        public MultiSelectList PositionList { get; set; }
    }
}
