﻿using System;
using EventBus.Messages.Events;
using MassTransit;

namespace Ordering.API.EventBusConsumer
{
	public class BasketCheckoutConsumer : IConsumer<BasketCheckoutEvent>
	{
		public BasketCheckoutConsumer()
		{
		}

        public Task Consume(ConsumeContext<BasketCheckoutEvent> context)
        {
            throw new NotImplementedException();
        }
    }
}
