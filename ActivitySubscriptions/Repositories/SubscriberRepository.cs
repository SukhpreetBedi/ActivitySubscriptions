using ActivitySubscriptions.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ActivitySubscriptions.Repositories
{
    public class SubscriberRepository : ISubscriberRepository
    {
        private ActivitySubscriptionsContext _activitySubscriptionsContext;
        private readonly ILogger<SubscriberRepository> _logger;

        public SubscriberRepository(
            ActivitySubscriptionsContext activitySubscriptionsContext,
            ILogger<SubscriberRepository> logger
            )
        {
            _activitySubscriptionsContext = activitySubscriptionsContext;
            _logger = logger;
        }
        public async Task<int> AddActivity(Activity activity)
        {
            if (_activitySubscriptionsContext != null)
            {
                await _activitySubscriptionsContext.Activities.AddAsync(activity);
                await _activitySubscriptionsContext.SaveChangesAsync();
                _logger.LogInformation("New activity added: {0}", activity.ActivityType);

                return activity.Id;
            }

            return 0;
        }

        public async Task<int> AddSubscriber(Subscriber subscriber)
        {
            if (_activitySubscriptionsContext != null)
            {
                await _activitySubscriptionsContext.Subscribers.AddAsync(subscriber);
                await _activitySubscriptionsContext.SaveChangesAsync();
                _logger.LogInformation("New Subscriber added: {0}", subscriber.FirstName);

                return subscriber.Id;
            }

            return 0;
        }

        public async Task<int> DeleteActivity(int activityId)
        {
            int result = 0;

            if (_activitySubscriptionsContext != null)
            {
                //Find the activity for specific activity id
                var activity = await _activitySubscriptionsContext.Activities.FirstOrDefaultAsync(x => x.Id == activityId);

                if (activity != null)
                {
                    //Delete that subscriber
                    _activitySubscriptionsContext.Activities.Remove(activity);

                    //Commit the transaction
                    result = await _activitySubscriptionsContext.SaveChangesAsync();
                    _logger.LogInformation("Deleted Activity: {0}", activity.ActivityType);
                }
                return result;
            }

            return result;
        }

        public async Task<int> DeleteSubscriber(int subscriberId)
        {
            int result = 0;

            if (_activitySubscriptionsContext != null)
            {
                //Find the subscriber for specific id
                var subscriber = await _activitySubscriptionsContext.Subscribers.FirstOrDefaultAsync(x => x.Id == subscriberId);

                if (subscriber != null)
                {
                    //Delete that subscriber
                    _activitySubscriptionsContext.Subscribers.Remove(subscriber);

                    //Commit the transaction
                    result = await _activitySubscriptionsContext.SaveChangesAsync();
                    _logger.LogInformation("Deleted Subscriber: {0}", subscriber.FirstName);
                }
                return result;
            }

            return result;
        }

        public async Task<List<Activity>> GetActivities()
        {
            if (_activitySubscriptionsContext != null)
            {
                return await _activitySubscriptionsContext.Activities.ToListAsync();
            }

            return null;
        }

        public async Task<Activity> GetActivity(int activityId)
        {
            if (_activitySubscriptionsContext != null)
            {
                return await (from a in _activitySubscriptionsContext.Activities
                              where a.Id == activityId
                              select new Activity
                              {
                                  Id = a.Id,
                                  ActivityType = a.ActivityType
                              }).FirstOrDefaultAsync();
            }
            return null;
        }

        public async Task<Subscriber> GetSubscriber(int subscriberId)
        {
            if (_activitySubscriptionsContext != null)
            {
                return await (from s in _activitySubscriptionsContext.Subscribers
                              where s.Id == subscriberId
                              select new Subscriber
                              {
                                  Id = s.Id,
                                  FirstName = s.FirstName,
                                  LastName = s.LastName,
                                  EmailAddress = s.EmailAddress,
                                  ActivityId = s.ActivityId,
                                  Comments = s.Comments
                              }).FirstOrDefaultAsync();
            }
            return null;
        }

        public async Task<List<Subscriber>> GetSubscribers()
        {
            if (_activitySubscriptionsContext != null)
            {
                return await _activitySubscriptionsContext.Subscribers
                    .Include(subscriber => subscriber.Activity)
                    .ToListAsync();
            }

            return null;
        }

        public async Task UpdateActivity(Activity activity)
        {
            if (_activitySubscriptionsContext != null)
            {
                //Delete that subscriber
                _activitySubscriptionsContext.Activities.Update(activity);

                //Commit the transaction
                await _activitySubscriptionsContext.SaveChangesAsync();
                _logger.LogInformation("Updated Activity: {0}", activity.ActivityType);
            }
        }

        public async Task UpdateSubscriber(Subscriber subscriber)
        {
            if (_activitySubscriptionsContext != null)
            {
                //Delete that subscriber
                _activitySubscriptionsContext.Subscribers.Update(subscriber);

                //Commit the transaction
                await _activitySubscriptionsContext.SaveChangesAsync();
                _logger.LogInformation("Dsleted Subscriber: {0}", subscriber.FirstName);
            }
        }
    }
}
