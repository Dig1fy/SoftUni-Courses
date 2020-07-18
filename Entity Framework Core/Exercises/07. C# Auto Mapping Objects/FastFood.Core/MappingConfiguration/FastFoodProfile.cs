namespace FastFood.Core.MappingConfiguration
{
    using AutoMapper;
    using FastFood.Core.ViewModels.Categories;
    using FastFood.Core.ViewModels.Employees;
    using FastFood.Core.ViewModels.Items;
    using FastFood.Core.ViewModels.Orders;
    using FastFood.Models;
    using FastFood.Models.Enums;
    using System;
    using System.Globalization;
    using ViewModels.Positions;

    public class FastFoodProfile : Profile
    {
        public FastFoodProfile()
        {
            //Positions
            this.CreateMap<CreatePositionInputModel, Position>()
                .ForMember(x => x.Name, y => y.MapFrom(s => s.PositionName));

            this.CreateMap<Position, PositionsAllViewModel>()
                .ForMember(x => x.Name, y => y.MapFrom(s => s.Name));

            //Categories
            this.CreateMap<CreateCategoryInputModel, Category>()
                .ForMember(x => x.Name, y => y.MapFrom(c => c.CategoryName));

            this.CreateMap<Category, CategoryAllViewModel>();

            //Employees
            //We add position name so in the view will be shown the name that corresponds to the id, not the id itself
            this.CreateMap<Position, RegisterEmployeeViewModel>()
                .ForMember(x => x.PositionId, y => y.MapFrom(x => x.Id))
                .ForMember(x => x.PositionName, y => y.MapFrom(x => x.Name));

            //we do not implement additional logic since the property names are the same and EF Core will handle it automatically.
            this.CreateMap<RegisterEmployeeInputModel, Employee>();

            //We need to manually map these two because Employee has string Position and empVieModel has navigation property Position.
            this.CreateMap<Employee, EmployeesAllViewModel>()
                .ForMember(evmodel => evmodel.Name, em => em.MapFrom(em => em.Position.Name));

            //Items
            this.CreateMap<Category, CreateItemViewModel>()
                .ForMember(cr => cr.CategoryId, c => c.MapFrom(cc => cc.Id))
                .ForMember(x => x.CategoryName, y => y.MapFrom(y => y.Name));

            this.CreateMap<CreateItemInputModel, Item>();

            this.CreateMap<Item, ItemsAllViewModels>()
            .ForMember(iv => iv.Category, i => i.MapFrom(c => c.Category.Name));

            //Orders
            this.CreateMap<Item, CreateItemOrderViewModel>()
                .ForMember(x => x.ItemId, y => y.MapFrom(y => y.Id))
                .ForMember(x => x.ItemName, y => y.MapFrom(y => y.Name));

            this.CreateMap<Employee, CreateOrderEmployeeViewModel>()
                .ForMember(x => x.EmployeeId, y => y.MapFrom(y => y.Id))
                .ForMember(x => x.EmployeeName, y => y.MapFrom(y => y.Name));

            this.CreateMap<CreateOrderInputModel, Order>()
                .ForMember(x => x.DateTime, y => y.MapFrom(y => DateTime.Now))
                .ForMember(x => x.Type, y => y.MapFrom(y => OrderType.ToGo));

            this.CreateMap<CreateOrderInputModel, OrderItem>()
                .ForMember(x => x.ItemId, y => y.MapFrom(y => y.ItemId))
                .ForMember(x => x.Quantity, y => y.MapFrom(y => y.Quantity));

            this.CreateMap<Order, OrderAllViewModel>()
                .ForMember(x => x.Employee, y => y.MapFrom(y => y.Employee.Name))
                .ForMember(x => x.DateTime, y => y.MapFrom(y => y.DateTime.ToString("D", CultureInfo.InvariantCulture)))
                .ForMember(x => x.OrderId, y => y.MapFrom(y => y.Id));

        }
    }
}
