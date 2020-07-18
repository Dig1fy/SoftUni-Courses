namespace FastFood.Core.ViewModels.Orders
{
    using System.Collections.Generic;

    public class CreateOrderViewModel
    {
        public List<CreateItemOrderViewModel> Items { get; set; }

        public List<CreateOrderEmployeeViewModel> Employees { get; set; }
    }
}
