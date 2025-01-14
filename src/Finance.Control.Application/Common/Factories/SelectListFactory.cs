using EnumsNET;
using Finance.Control.Domain.Enum;
using Finance.Control.Infra.Data.Contexts;
using Microsoft.AspNetCore.Mvc.Rendering;


namespace Finance.Control.Application.Common.Factories
{
    public sealed class SelectListFactory(AppDbContext context)
    {

        public SelectList CreateSelectListStatus()
        {
            var items = new List<SelectListItem>
            {
                new (AccountStatus.Pendente.AsString(EnumFormat.Description), AccountStatus.Pendente.ToString()),
                new (AccountStatus.Pago.AsString(EnumFormat.Description), AccountStatus.Pago.ToString()),
                new (AccountStatus.Vencido.AsString(EnumFormat.Description), AccountStatus.Vencido.ToString()),
            }
            .OrderBy(item => item.Text)
            .ToList();

            return new SelectList(items, nameof(SelectListItem.Value), nameof(SelectListItem.Text));
        }

        public SelectList CreateSelectListCategory()
        {
            var category = context.Category.Where(x => x.Active).ToList();

            var items = category
                .Select(x => new SelectListItem(x.Name, x.Id.ToString()))
                .OrderBy(x => x.Text)
                .ToList();

            return new SelectList(items, nameof(SelectListItem.Value), nameof(SelectListItem.Text));
        }

    }
}
