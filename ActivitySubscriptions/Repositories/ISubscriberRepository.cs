using ActivitySubscriptions.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ActivitySubscriptions.Repositories
{
    public interface ISubscriberRepository
    {
        Task<List<Subscriber>> GetSubscribers();

        Task<List<Activity>> GetActivities();

        Task<Activity> GetActivity(int activityId);

        Task<int> AddActivity(Activity activity);

        Task<int> DeleteActivity(int activityId);

        Task UpdateActivity(Activity activity);

        Task<Subscriber> GetSubscriber(int subscriberId);

        Task<int> AddSubscriber(Subscriber subscriber);

        Task<int> DeleteSubscriber(int subscriberId);

        Task UpdateSubscriber(Subscriber subscriber);
    }
}
