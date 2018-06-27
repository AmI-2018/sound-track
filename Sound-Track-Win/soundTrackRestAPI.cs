using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web.Script.Serialization;

namespace Sound_Track_Win

{
    class SoundTrackRestAP
    {
        
        public class UserResource
        {
            public int user_id { get; set; }
            public string user_name { get; set; }
            public string mon_start { get; set; }
            public string mon_end{ get; set; }
            public string tue_start{ get; set; }
            public string tue_end{ get; set; }
            public string wed_start{ get; set; }
            public string wed_end{ get; set; }
            public string thr_start{ get; set; }
            public string thr_end{ get; set; }
            public string fri_start{ get; set; }
            public string fri_end{ get; set; }
            public string sat_start{ get; set; }
            public string sat_end{ get; set; }
            public string sun_start{ get; set; }
            public string sun_end{ get; set; }
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

        public class LocationResource
        {
            public string current_location { get; set; }
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
                    //gets data as a json string
                    time = response.Result.Content.ReadAsAsync<TimeResource>();
                    time.Wait();
                }
                return time.Result;
            }

            //gets current location from server
            public LocationResource GetCurrentLocation ()
            {
                Task<LocationResource> location = null;
                Task<HttpResponseMessage> response = apiRequestClient.GetAsync("current_location");
                response.Wait();
                if (response.Result.IsSuccessStatusCode)
                {
                    //gets data as a json string
                    location = response.Result.Content.ReadAsAsync<LocationResource>();
                    location.Wait();
                }
                return location.Result;
            }

            //gets data on a specific user (given the user's id)
            public UserResource GetUser(string user_id)
            {
                Task<UserResource> user = null;
                Task<HttpResponseMessage> response = apiRequestClient.GetAsync("users/" + user_id);
                response.Wait();
                if (response.Result.IsSuccessStatusCode)
                {
                    //gets data as a json string
                    user = response.Result.Content.ReadAsAsync<UserResource>();
                    user.Wait();
                }
                return user.Result;
            }

            //gets data on all users and their quiet time settings
            public UserResource GetAllUsers()
            {
                //gets data as a json string
                Task<UserResource> users = null;
                Task<HttpResponseMessage> response = apiRequestClient.GetAsync("users");
                response.Wait();
                if (response.Result.IsSuccessStatusCode)
                {
                    users = response.Result.Content.ReadAsAsync<UserResource>();
                    users.Wait();
                }
                return users.Result;
            }

            //gets data on a specific beacon (given the beacon's id)
            public BeaconResource GetBeacon(string beacon_id)
            {
                Task<BeaconResource> beacon = null;
                Task<HttpResponseMessage> response = apiRequestClient.GetAsync("beacons/" + beacon_id);
                response.Wait();
                if (response.Result.IsSuccessStatusCode)
                {
                    //gets data as a json string
                    beacon = response.Result.Content.ReadAsAsync<BeaconResource>();
                    beacon.Wait();
                }
                return beacon.Result;
            }

            //gets data on all beacons
            public BeaconResource GetAllBeacons()
            {
                Task<BeaconResource> beacons = null;
                Task<HttpResponseMessage> response = apiRequestClient.GetAsync("beacons");
                response.Wait();
                if (response.Result.IsSuccessStatusCode)
                {
                    //gets data as a json string
                    beacons = response.Result.Content.ReadAsAsync<BeaconResource>();
                    beacons.Wait();
                }
                return beacons.Result;
            }

            //creates a user profile
            //sends username and quiet times to api as a dictionary
            public void CreateUser(string user_name, Dictionary<string, string> quiet_times)
            {
                quiet_times.Add("user_name", user_name);         //adds username to dictionary to be posted
                var user_data = new FormUrlEncodedContent(quiet_times);
                Task<HttpResponseMessage> response = apiRequestClient.PostAsJsonAsync("users", user_data);
            }

            //creates a beacon profile
            //sends beacon data to api as a dictionary with key/value pairs
            //specifying what the data is and then the data
            //i.e., "location_name", "name of location"
            public void CreateBeacon(Dictionary<string, string> beacon_info)
            {
                var new_beacon = new FormUrlEncodedContent(beacon_info);
                Task<HttpResponseMessage> response = apiRequestClient.PostAsJsonAsync("beacons", new_beacon);
            }

            //updates a specific user's quiet time settings
            public void UpdateUser(string user_id, Dictionary<string, string> new_quiet_times)
            {
                var quiet_time_updates = new FormUrlEncodedContent(new_quiet_times);
                Task<HttpResponseMessage> response = apiRequestClient.PostAsJsonAsync("users/" + user_id, quiet_time_updates);
            }

            //updates beacon info
            public void UpdateBeacon(string beacon_id, Dictionary<string, string> new_beacon_info)
            {
                var beacon_updates = new FormUrlEncodedContent(new_beacon_info);
                Task<HttpResponseMessage> response = apiRequestClient.PostAsJsonAsync("beacons/" + beacon_id, beacon_updates);
            }

            //updates current location
            public void SetCurrentLocation(string new_current_location)
            {
                Task<HttpResponseMessage> response = apiRequestClient.PostAsJsonAsync<string>("current_location", new_current_location);
            }
        }
    }
}