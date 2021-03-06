﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace UwpCommunityBackend.Models
{
    public class UserBase
    {
        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; }

        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        [JsonProperty(PropertyName = "discordId")]
        public string DiscordId { get; set; }

        [JsonProperty(PropertyName = "email")]
        public string Email { get; set; }
    }
}
