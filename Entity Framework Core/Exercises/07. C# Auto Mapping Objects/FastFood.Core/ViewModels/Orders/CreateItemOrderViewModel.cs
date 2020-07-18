using System.ComponentModel.DataAnnotations;

namespace FastFood.Core.ViewModels.Orders
{
    public class CreateItemOrderViewModel
    {
        public int ItemId { get; set; }

        public string ItemName { get; set; }

    }
}
