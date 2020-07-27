using Service.Helpers;
using Service.ViewModels;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Service.Interfaces
{
    public interface INotificationService
    {
        Task<PagedList<NotificationViewModel>> GetAllPagingAsync(PagingParams pagingParams, string userId);
        Task DeleteAllAsync(string receiverId);
        Task<NotificationViewModel> GetByIdAsync(string id);
        Task<NotificationViewModel> CreateAsync(NotificationViewModel notificationVM);
        Task<List<NotificationViewModel>> CreateRangeAsync(IList<NotificationViewModel> notificationsVM);
        Task MarkViewedAllAsync(string userId);
        Task<int> GetCountUnViewAsync(string userId);
        Task MarkSeenNotification(NotificationViewModel notificationVM);
        Task<bool> CheckExistsAsync(string id);
    }
}
