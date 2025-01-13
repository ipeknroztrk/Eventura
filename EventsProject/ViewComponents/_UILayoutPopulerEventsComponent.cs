using DataAccessLayer.Concrete;
using EventsProject.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

public class _UILayoutPopulerEventsComponent : ViewComponent
{
    private readonly Context _context;

    public _UILayoutPopulerEventsComponent(Context context)
    {
        _context = context;
    }

    public IViewComponentResult Invoke()
    {
        // UserFavorite tablosundan en popüler eventleri alıyoruz
        var populerEvents = _context.UserFavorites
            .GroupBy(uf => uf.EventId)
            .Select(group => new
            {
                EventId = group.Key,
                FavoriteCount = group.Count()
            })
            .OrderByDescending(x => x.FavoriteCount)
            .Take(5) // En çok eklenen 5 etkinlik
            .ToList();

        var eventIds = populerEvents.Select(x => x.EventId).ToList();

        // Event bilgilerini çekiyoruz
        var eventsWithPrices = _context.Events
            .Where(e => eventIds.Contains(e.EventId))
            .Select(e => new EventWithPriceViewModel
            {
                EventId = e.EventId,
                EventName = e.Title,
                EventImageUrl = e.ImageUrl,
                CategoryName = e.Category.Name,
                Price = _context.EventsTickets
                                .Where(et => et.EventId == e.EventId)
                                .Select(et => et.Price)
                                .FirstOrDefault() // İlk kaydı alır
            })
            .ToList();

        return View(eventsWithPrices);
    }
}
