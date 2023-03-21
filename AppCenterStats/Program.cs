using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace AppCenterStats
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var updates = new Dictionary<int, string>
            {
                //{ 16299, "Fall Creators" },
                //{ 17134, "April 2018" },
                //{ 17763, "October 2018" },
                { 18362, "May 2019" },
                { 18363, "November 2019" },
                { 19041, "May 2020" },
                { 19042, "October 2020" },
                { 19043, "May 2021" },
                { 19044, "November 2021" },
                { 22000, "Windows 11" },
                { 22621, "Windows 22H2" },
            };

            var windows = new[]
            {
                //10240,
                //10586,
                //14393,
                //15063,
                //16299,
                //17134,
                //17763,
                18362,
                18363,
                19041,
                19042,
                19043,
                19044,
                22000,
                22621
            };

            var latest = windows.Max();

            var end = DateTime.Today.AddDays(-1).ToString("yyyy-MM-dd");
            var start = DateTime.Today.AddDays(-28).ToString("yyyy-MM-dd");

            var client = new HttpClient();
            var request = new HttpRequestMessage(HttpMethod.Get, $"https://api.appcenter.ms/v0.1/apps/unigram-team/unigram-1/analytics/oses?start={start}&end={end}&%24top=0");
            request.Headers.Accept.ParseAdd("application/json");
            request.Headers.Add("X-API-Token", "baf81250628999e43232b0032051ee952355d56c"); // b28009e96ade44f4e08d1ddd93f124939295146d

            var response = await client.SendAsync(request);
            var content = await response.Content.ReadAsStringAsync();

            var count = JsonConvert.DeserializeObject<OperatingSystemCount>(content);
            var map = new Dictionary<int, long>();
            var old = new Dictionary<int, long>();

            foreach (var item in count.Oses)
            {
                if (Version.TryParse(item.OsName, out Version version))
                {
                    map[version.Build] = item.Count;
                    old[version.Build] = item.PreviousCount ?? 0;
                }
            }

            var prev = new DefaultDictionary<int, long>();
            var next = new DefaultDictionary<int, long>();
            var added = new DefaultDictionary<int, int>();

            var obsoletePrev = 0L;
            var obsoleteNext = 0L;
            var obsoleteCount = 0;

            var insidersPrev = 0L;
            var insidersNext = 0L;
            var insidersCount = 0;

            foreach (var item in map)
            {
                if (windows.Contains(item.Key))
                {
                    prev[item.Key] += old[item.Key];
                    next[item.Key] += item.Value;
                }
                else
                {
                    if (item.Key <= latest && item.Key >= windows[0])
                    {
                        for (int i = 0; i < windows.Length; i++)
                        {
                            if (item.Key > windows[i] && item.Key < windows[i + 1])
                            {
                                prev[windows[i]] += old[item.Key];
                                next[windows[i]] += item.Value;
                                added[windows[i]] += 1;
                                break;
                            }
                        }
                    }
                    else if (item.Key > latest)
                    {
                        insidersPrev += old[item.Key];
                        insidersNext += item.Value;
                        insidersCount++;
                    }
                    else
                    {
                        obsoletePrev += old[item.Key];
                        obsoleteNext += item.Value;
                        obsoleteCount++;
                    }
                }
            }

            Console.WriteLine("┌───┬──────────────────────┬──────────┬─────┐");

            foreach (var item in next)
            {
                PrintVersion(updates[item.Key], count.Total, next[item.Key], prev[item.Key], added[item.Key]);
            }

            Console.WriteLine("├───┼──────────────────────┼──────────┼─────┤");

            PrintVersion("Dev Channel", count.Total, insidersNext, insidersPrev, insidersCount);
            PrintVersion("Unsupported", count.Total, obsoleteNext, obsoletePrev, obsoleteCount);

            Console.WriteLine("└───┴──────────────────────┴──────────┴─────┘");


            while (true)
            {
                var group = Console.ReadLine();
                if (string.IsNullOrEmpty(group))
                {
                    return;
                }

                await GetCrashUsersAsync(group);
            }

            Console.ReadLine();
        }

        private static async Task GetCrashUsersAsync(string group)
        {
            var start = DateTime.Today.AddDays(-30).ToString("yyyy-MM-dd");

            var client = new HttpClient();
            var request = new HttpRequestMessage(HttpMethod.Get, $"https://api.appcenter.ms/v0.1/apps/unigram-team/Unigram-1/errors/errorGroups/{group}/errors?start={start}");
            request.Headers.Accept.ParseAdd("application/json");
            request.Headers.Add("X-API-Token", "baf81250628999e43232b0032051ee952355d56c"); // b28009e96ade44f4e08d1ddd93f124939295146d

            var response = await client.SendAsync(request);
            var content = await response.Content.ReadAsStringAsync();

            var count = JsonConvert.DeserializeObject<ErrorGroup>(content);
            var userIds = new HashSet<string>();

            foreach (var error in count.Errors)
            {
                var userId = error.UserId?.Split('=')[1];
                if (userId == null || userIds.Contains(userId))
                {
                    continue;
                }

                userIds.Add(userId);

                var tgbeta = await GetUsernameAsync("tgbeta", userId);
                if (tgbeta == null)
                {
                    var unigram = await GetUsernameAsync("unigram", userId);
                    if (unigram == null)
                    {
                        var unigraminsiders = await GetUsernameAsync("unigraminsiders", userId);
                        if (unigraminsiders != null)
                        {
                            Console.WriteLine("@" + unigraminsiders);
                            continue;
                        }
                    }
                    else
                    {
                        Console.WriteLine("@" + unigram);
                        continue;
                    }
                }
                else
                {
                    Console.WriteLine("@" + tgbeta);
                    continue;
                }
            }

            Console.WriteLine("End");
        }

        private static async Task<string> GetUsernameAsync(string channel, string userId)
        {
            var client = new HttpClient();
            var request = new HttpRequestMessage(HttpMethod.Get, $"https://api.telegram.org/bot230102167:AAFxrm5K2UkA3pdFSV0tCYOaI6fFSy_7Wkg/getChatMember?chat_id=@{channel}&user_id={userId}");
            request.Headers.Accept.ParseAdd("application/json");
            request.Headers.Add("X-API-Token", "baf81250628999e43232b0032051ee952355d56c"); // b28009e96ade44f4e08d1ddd93f124939295146d

            var response = await client.SendAsync(request);
            var content = await response.Content.ReadAsStringAsync();

            var json = JObject.Parse(content);
            if (json.TryGetValue("result", out JToken resultToken) && resultToken is JObject result)
            {
                if (result.TryGetValue("user", out JToken userToken) && userToken is JObject user)
                {
                    return user["username"].Value<string>();
                }
            }

            return null;
        }

        private static void PrintVersion(string name, float total, long next, long prev, int additional)
        {
            Console.Write("│ ");

            if (prev > next)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("\u2193");
                Console.ResetColor();
            }
            else if (prev < next)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write("\u2191");
                Console.ResetColor();
            }
            else
            {
                Console.Write("-");
            }

            Console.Write(string.Format(" │ {0,-20} │ {1,7:0.000}% │ {2,3} │\n", name, next / total * 100, additional > 0 ? $"+{Math.Min(99, additional)}" : ""));
        }
    }

    public class Error
    {
        [JsonProperty("errorId")]
        public string ErrorId { get; set; }

        [JsonProperty("timestamp")]
        public DateTime Timestamp { get; set; }

        [JsonProperty("deviceName")]
        public string DeviceName { get; set; }

        [JsonProperty("osVersion")]
        public string OsVersion { get; set; }

        [JsonProperty("osType")]
        public string OsType { get; set; }

        [JsonProperty("country")]
        public string Country { get; set; }

        [JsonProperty("language")]
        public string Language { get; set; }

        [JsonProperty("userId")]
        public string UserId { get; set; }

        [JsonProperty("hasBreadcrumbs")]
        public bool HasBreadcrumbs { get; set; }

        [JsonProperty("hasAttachments")]
        public bool HasAttachments { get; set; }
    }

    public class ErrorGroup
    {
        [JsonProperty("nextLink")]
        public string NextLink { get; set; }

        [JsonProperty("errors")]
        public List<Error> Errors { get; set; }
    }

    public partial class OperatingSystemCount
    {
        [JsonProperty("total", Required = Required.Always)]
        public float Total { get; set; }

        [JsonProperty("oses", Required = Required.Always)]
        public List<OperatingSystem> Oses { get; set; }
    }

    public partial class OperatingSystem
    {
        [JsonProperty("os_name", Required = Required.Always)]
        public string OsName { get; set; }

        [JsonProperty("count", Required = Required.Always)]
        public long Count { get; set; }

        [JsonProperty("previous_count", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public long? PreviousCount { get; set; }
    }

    public partial class DevicesCount
    {
        [JsonProperty("total_devices", Required = Required.Always)]
        public long TotalDevices { get; set; }

        [JsonProperty("total_devices_with_event", Required = Required.Always)]
        public long TotalDevicesWithEvent { get; set; }

        [JsonProperty("previous_total_devices_with_event", Required = Required.Always)]
        public long PreviousTotalDevicesWithEvent { get; set; }
    }

    public partial class Temperatures
    {
        [JsonProperty("events", Required = Required.Always)]
        public List<Event> Events { get; set; }

        [JsonProperty("total", Required = Required.Always)]
        public long Total { get; set; }

        [JsonProperty("total_devices", Required = Required.Always)]
        public long TotalDevices { get; set; }
    }

    public partial class Event
    {
        [JsonProperty("id", Required = Required.Always)]
        public string Id { get; set; }

        [JsonProperty("name", Required = Required.Always)]
        public string Name { get; set; }

        [JsonProperty("device_count", Required = Required.Always)]
        public long DeviceCount { get; set; }

        [JsonProperty("previous_device_count", Required = Required.Always)]
        public long PreviousDeviceCount { get; set; }

        [JsonProperty("count", Required = Required.Always)]
        public long Count { get; set; }

        [JsonProperty("previous_count", Required = Required.Always)]
        public long PreviousCount { get; set; }

        [JsonProperty("count_per_device", Required = Required.Always)]
        public double CountPerDevice { get; set; }
    }

    class DefaultDictionary<TKey, TValue> : Dictionary<TKey, TValue>
    {
        public new TValue this[TKey key]
        {
            get
            {
                if (TryGetValue(key, out TValue value))
                {
                    return value;
                }

                value = default;
                base[key] = value;

                return value;
            }
            set
            {
                base[key] = value;
            }
        }
    }
}
