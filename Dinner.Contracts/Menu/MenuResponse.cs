using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuberDinner.Contracts.Menu
{
    public record MenuResponse(
        Guid Id,
        string Name,
        string Description,
        double? AverageRating,
        List<MenuSectionResponse> Sections,
        string HostId,
        List<string> DinnerIds,
        List<string> MenuReviewIds,
        DateTime CreatedDateTime,
        DateTime UpdateDateTime);

    public record MenuSectionResponse(
        Guid Id,
        string Name,
        string Description,
        List<MenuItemResponse> Items);

    public record MenuItemResponse(
         Guid Id,
        string Name,
        string Description);


}
