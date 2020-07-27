﻿using Microsoft.Extensions.Logging;

namespace WebAPI.Helpers
{
    public class LoggingEvents
    {
        public static readonly EventId INIT_DATABASE = new EventId(101, "Error whilst creating and seeding database");
    }
}
