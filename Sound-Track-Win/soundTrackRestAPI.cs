using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;

namespace Sound_Track_Win
{
    class SoundTrackRestAPI
    {
        
        public class UserResource
        {
            public int user_id { get; set; }
            public string user_name { get; set; }
            public int mon_start { get; set; }
            public int mon_end{ get; set; }
            public int tue_start{ get; set; }
            public int tue_end{ get; set; }
            public int wed_start{ get; set; }
            public int wed_end{ get; set; }
            public int thr_start{ get; set; }
            public int thr_end{ get; set; }
            public int fri_start{ get; set; }
            public int fri_end{ get; set; }
            public int sat_start{ get; set; }
            public int sat_end{ get; set; }
            public int sun_start{ get; set; }
            public int sun_end{ get; set; }
        }

        public class BeaconResource
        {
            public string beacon_id{ get; set; }
            public string location_name{ get; set; }
            public int speaker_id{ get; set; }
            public string ip_addr{ get; set; }
        }

        public class TimeResource
        {
            public double time { get; set; }
        }

        public class SoundTrackRestHandler
        {

            static HttpClient apiRequestClient = new HttpClient();

            public string serverLocation { get { return apiRequestClient.BaseAddress.AbsolutePath; } }

            public SoundTrackRestHandler(string IP_Address, string Port = "5000")
            {
                apiRequestClient.BaseAddress = new Uri("http://" + IP_Address + ":" + Port + "/");
                apiRequestClient.DefaultRequestHeaders.Accept.Clear();
                apiRequestClient.DefaultRequestHeaders.Accept.Add(
                    new MediaTypeWithQualityHeaderValue("application/json"));
            }

            /*public UserResource GetUser(string user_id)
            {
                Task<UserResource> taskResult = GetUserAsync(user_id);
                taskResult.RunSynchronously();
                return taskResult.Result;
            }*/

            public TimeResource GetServerTime()
            {
                Task<TimeResource> time = null;
                Task<HttpResponseMessage> response = apiRequestClient.GetAsync("time");
                response.Wait();
                if (response.Result.IsSuccessStatusCode)
                {
                    time = response.Result.Content.ReadAsAsync<TimeResource>();
                    time.Wait();
                }
                return time.Result;
            }

            public UserResource GetUser(string user_id)
            {
                Task<UserResource> user = null;
                Task<HttpResponseMessage> response = apiRequestClient.GetAsync("users/" + user_id);
                response.Wait();
                if (response.Result.IsSuccessStatusCode)
                {
                    user = response.Result.Content.ReadAsAsync<UserResource>();
                    user.Wait();
                }
                return user.Result;
            }
        }
    }
}
