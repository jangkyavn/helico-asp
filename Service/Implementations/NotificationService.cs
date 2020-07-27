using AutoMapper;
using Data;
using Data.Entities;
using Microsoft.EntityFrameworkCore;
using Service.Helpers;
using Service.Interfaces;
using Service.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Service.Implementations
{
    public class NotificationService : INotificationService
    {
        private readonly DataContext _dataContext;
        private readonly IMapper _mapper;

        public NotificationService(DataContext dataContext, IMapper mapper)
        {
            _dataContext = dataContext;
            _mapper = mapper;
        }

        public Task<bool> CheckExistsAsync(string id)
        {
            throw new NotImplementedException();
        }

        public async Task<NotificationViewModel> CreateAsync(NotificationViewModel notificationVM)
        {
            Notification notification = _mapper.Map<Notification>(notificationVM);
            await _dataContext.Notifications.AddAsync(notification);
            await _dataContext.SaveChangesAsync();
            NotificationViewModel result = _mapper.Map<NotificationViewModel>(notification);
            return result;
        }

        public async Task<List<NotificationViewModel>> CreateRangeAsync(IList<NotificationViewModel> notificationsVM)
        {
            List<Notification> notifications = _mapper.Map<List<Notification>>(notificationsVM);
            await _dataContext.Notifications.AddRangeAsync(notifications);
            await _dataContext.SaveChangesAsync();
            List<NotificationViewModel> result = _mapper.Map<List<NotificationViewModel>>(notifications);
            return result;
        }

        public async Task DeleteAllAsync(string receiverId)
        {
            var listToDelete = _dataContext.Notifications.Where(x => x.ReceiverId == receiverId);
            _dataContext.Notifications.RemoveRange(listToDelete);
            await _dataContext.SaveChangesAsync();
        }

        public async Task<PagedList<NotificationViewModel>> GetAllPagingAsync(PagingParams pagingParams, string userId)
        {
            IQueryable<NotificationViewModel> query = from n in _dataContext.Notifications
                                                      join u in _dataContext.Users on n.SenderId equals u.Id
                                                      where n.ReceiverId == userId
                                                      orderby n.CreatedDate descending
                                                      select new NotificationViewModel
                                                      {
                                                          Id = n.Id,
                                                          SenderId = n.SenderId,
                                                          SenderName = u.FullName,
                                                          ReceiverId = n.ReceiverId,
                                                          ObjectId = n.ObjectId,
                                                          CreatedBy = n.CreatedBy,
                                                          CreatedDate = n.CreatedDate,
                                                          Content = n.Content,
                                                          Read = n.Read,
                                                          View = n.View,
                                                          Type = n.Type,
                                                          Status = n.Status
                                                      };

            return await PagedList<NotificationViewModel>
                .CreateAsync(query, pagingParams.PageNumber, pagingParams.PageSize);
        }

        public async Task<NotificationViewModel> GetByIdAsync(string id)
        {
            Notification notification = await _dataContext.Notifications
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Id == id);

            NotificationViewModel result = _mapper.Map<NotificationViewModel>(notification);
            return result;
        }

        public async Task<int> GetCountUnViewAsync(string userId)
        {
            int count = await _dataContext.Notifications
                .Where(x => x.View == false && x.ReceiverId == userId)
                .CountAsync();

            return count;
        }

        public async Task MarkSeenNotification(NotificationViewModel notificationVM)
        {
            notificationVM.Read = true;
            notificationVM.View = true;
            Notification notification = await _dataContext.Notifications.FirstOrDefaultAsync(x => x.Id == notificationVM.Id);
            _dataContext.Entry(notification).CurrentValues.SetValues(notificationVM);
            await _dataContext.SaveChangesAsync();
        }

        public async Task MarkViewedAllAsync(string userId)
        {
            List<Notification> list = await _dataContext.Notifications
                .Where(x => x.ReceiverId == userId && x.View == false)
                .ToListAsync();

            foreach (Notification item in list)
            {
                item.View = true;
            }

            await _dataContext.SaveChangesAsync();
        }
    }
}
