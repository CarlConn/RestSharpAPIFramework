﻿using System;

namespace RestAPIFramework.Models
{
    public class CreateUserResponse
    {
        public string name { get; set; }
        public string job { get; set; }
        public string id { get; set; }
        public DateTime createdAt { get; set; }
    }

    public class CreateUserRequest
    {
        public string name { get; set; }
            public string job { get; set; }
     
    }
}