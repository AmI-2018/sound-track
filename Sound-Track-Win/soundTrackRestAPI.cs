using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net.Http.Headers;
using Newtonsoft.Json;

namespace Sound_Track_Win

{
    namespace RestAPI
    {
        
        public class UserResource
        {
            public string user_id { get; set; }
            public string user_name { get; set; }
            public int mon_start { get; set; } = -1;
            public int mon_end{ get; set; } = -1;
            public int tue_start{ get; set; } = -1;
            public int tue_end{ get; set; } = -1;
            public int wed_start{ get; set; } = -1;
            public int wed_end{ get; set; } = -1;
            public int thr_start{ get; set; } = -1;
            public int thr_end{ get; set; } = -1;
            public int fri_start{ get; set; } = -1;
            public int fri_end{ get; set; } = -1;
            public int sat_start{ get; set; } = -1;
            public int sat_end{ get; set; } = -1;
            public int sun_start{ get; set; } = -1;
            public int sun_end{ get; set; } = -1;
        }

        public class UserListResource
        {
            public List<UserResource> users { get; set; }
        }

        public class BeaconResource
        {
            public string beacon_id{ get; set; }
            public string location_name{ get; set; }
            public int speaker_id{ get; set; }
            public string ip_addr{ get; set; }
        }

        public class BeaconListResource
        {
            public List<BeaconResource> BeaconList { get; set; }
        }

        public class TimeResource
        {
            public double time { get; set; }
        }

        public class LocationResource
        {
            public string current_location { get; set; }
        }

        public class MessageResource
        {
            public string message { get; set; }
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

            //gets time from server
            public TimeResource GetServerTime()
            {
                Task<TimeResource> time = null;
                Task<HttpResponseMessage> response = apiRequestClient.GetAsync("time");
                response.Wait();
                if (response.Result.IsSuccessStatusCode)
                {
                    //gets data as a json string and converts it to TimeResource class
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
                    //gets data as a json string and converts it to LocationResource class
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
                    //gets data as a json string and converts it to UserResource class
                    user = response.Result.Content.ReadAsAsync<UserResource>();
                    user.Wait();
                }
                return user.Result;
            }

            //gets data on all users and their quiet time settings
            public List<UserResource> GetAllUsers()
            {
                Task<UserListResource> users = null;
                Task<HttpResponseMessage> response = apiRequestClient.GetAsync("users");
                response.Wait();
                if (response.Result.IsSuccessStatusCode)
                {
                    //gets data as a json string and converts it to a list of UserResource class
                    users = response.Result.Content.ReadAsAsync<UserListResource>();
                    //Task<string> result = response.Result.Content.ReadAsStringAsync();
                    //result.Wait();
                    //users = JsonConvert.DeserializeObject<List<UserResource>>(result.Result);
                    users.Wait();
                    return users.Result.users;
                }
                else { return new List<UserResource>();  }
                
            }

            //gets data on a specific beacon (given the beacon's id)
            public BeaconResource GetBeacon(string beacon_id)
            {
                Task<BeaconResource> beacon = null;
                Task<HttpResponseMessage> response = apiRequestClient.GetAsync("beacons/" + beacon_id);
                response.Wait();
                if (response.Result.IsSuccessStatusCode)
                {
                    //gets data as a json string and converts it to BeaconResource class
                    beacon = response.Result.Content.ReadAsAsync<BeaconResource>();
                    beacon.Wait();
                    return beacon.Result;
                }
                else { return null; }
            }

            //gets data on all beacons
            public List<BeaconResource> GetAllBeacons()
            {
                Task<List<BeaconResource>> beacons = null;
                Task<HttpResponseMessage> response = apiRequestClient.GetAsync("beacons");
                response.Wait();
                if (response.Result.IsSuccessStatusCode)
                {
                    //gets data as a json string and converts it to a list of BeaconResource class
                    beacons = response.Result.Content.ReadAsAsync<List<BeaconResource>>();
                    beacons.Wait();
                    return beacons.Result;
                }
                else { return new List<BeaconResource>(); }
            }

            //creates a user profile from UserResource
            public HttpResponseMessage CreateUser(UserResource newUser)
            {
                Task<HttpResponseMessage> response = apiRequestClient.PostAsJsonAsync<UserResource>("users", newUser);
                response.Wait();
                return response.Result;
            }

            //creates a beacon profile from BeaconResource
            public HttpResponseMessage CreateBeacon(BeaconResource newBeacon)
            {
                Task<HttpResponseMessage> response = apiRequestClient.PostAsJsonAsync<BeaconResource>("beacons", newBeacon);
                response.Wait();
                return response.Result;
            }

            //updates a specific user from UserResource, overwriting all values
            public HttpResponseMessage UpdateUserInFull(UserResource userUpdate)
            {
                Task<HttpResponseMessage> response = 
                    apiRequestClient.PutAsJsonAsync<UserResource>("users/" + userUpdate.user_id, userUpdate);
                response.Wait();
                return response.Result;
            }

            //updates a beacon info
            public HttpResponseMessage UpdateBeaconInFull(BeaconResource beaconUpdate)
            {
                Task<HttpResponseMessage> response = 
                    apiRequestClient.PutAsJsonAsync<BeaconResource>("beacons/" + beaconUpdate.beacon_id, beaconUpdate);
                response.Wait();
                return response.Result;
            }

            //updates current location
            public HttpResponseMessage SetCurrentLocation(string new_current_location)
            {
                Task<HttpResponseMessage> response = apiRequestClient.PostAsJsonAsync<string>("current_location", new_current_location);
                response.Wait();
                return response.Result;
            }
        }
    }
}