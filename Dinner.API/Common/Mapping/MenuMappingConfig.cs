using BuberDinner.Application.Menus.CreateMenu;
using BuberDinner.Contracts.Menu;
using BuberDinner.Domain.Menu;
using Mapster;

namespace DDD_Tutorial.Common.Mapping
{
    using MenuSection = BuberDinner.Domain.Menu.Entities.MenuSection;
    using MenuItem = BuberDinner.Domain.Menu.Entities.MenuItem;
    public class MenuMappingConfig : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig<(CreateMenuRequest Request, string HostId), CreateMenuCommand>()
            .Map(dest => dest.HostId, src => src.HostId)
            .Map(dest => dest, src => src.Request);

            config.NewConfig<Menu, MenuResponse>()
                .Map(dest => dest.Id, src => src.Id.Value)
                .Map(dest => dest.AverageRating, src => src.AverageRating)
                .Map(dest => dest.HostId, src => src.HostId.Value)
                .Map(dest => dest.DinnerIds, src => src.DinnerIds.Select(x => x.Value))
                .Map(dest => dest.MenuReviewIds, src => src.MenuReviewId.Select(x => x.Value));

            config.NewConfig<MenuSection, MenuSectionResponse>()
                .Map(dest => dest.Id, src => src.Id.Value);

            config.NewConfig<MenuItem, MenuItemResponse>()
                .Map(dest => dest.Id, src => src.Id.Value);
        }
    }
}
