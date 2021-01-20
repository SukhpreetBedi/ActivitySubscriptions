using ActivitySubscriptions.Models;
using ActivitySubscriptions.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ActivitySubscriptions.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SubscribersController : ControllerBase
    {
        private readonly ILogger<SubscribersController> _logger;
        private readonly ISubscriberRepository _subscriberRepository;

        public SubscribersController(
            ILogger<SubscribersController> logger,
            ISubscriberRepository subscriberRepository
            )
        {
            _logger = logger;
            _subscriberRepository = subscriberRepository;
        }

        //GET: SubscribersController/GetAllSubscribers
        [HttpGet]
        public async Task<IActionResult> GetAllSubscribers()
        {
            try
            {
                var subscribers = await _subscriberRepository.GetSubscribers();
                if (subscribers == null)
                {
                    return NotFound();
                }

                return Ok(subscribers);
            }
            catch (Exception)
            {
                return BadRequest();
            }

        }

        //GET: SubscribersController/GetAllActivities
        [HttpGet("getAllActivities")]
        public async Task<IActionResult> GetAllActivities()
        {
            try
            {
                var activities = await _subscriberRepository.GetActivities();
                if (activities == null)
                {
                    return NotFound();
                }

                return Ok(activities);
            }
            catch (Exception)
            {
                return BadRequest();
            }

        }

        // POST: SubscribersController/CreateSubscriber
        [HttpPost]
        public async Task<IActionResult> Create(Subscriber subscriber)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var subscriberId = await _subscriberRepository.AddSubscriber(subscriber);
                    if (subscriberId > 0)
                    {
                        return Ok(subscriberId);
                    }
                    else
                    {
                        return NotFound();
                    }
                }
                catch (Exception)
                {

                    return BadRequest();
                }

            }

            return BadRequest();
        }

    }
}
