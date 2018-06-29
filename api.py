from flask import Flask, request, jsonify
import db
import time
from datetime import date, datetime

current_location = None

api = Flask(__name__)

#route audio to given location, return whether the request succeeded or failed
@api.route('/current_location', methods = ['POST'])
def set_location():
    if request.headers['Content-Type'] == 'application/json':

        user_id = request.json['user_id']

    try:
        user_settings = db.get_user_details(user_id)[0]
    except:
        user_settings = {}
        
        #get the number of minutes from midnight
        now = datetime.now()
        current_time = ((now - now.replace(hour=0, minute=0, second=0, microsecond=0)).total_seconds()) / 60


        today = date.today().weekday()

	#if the current time is before noon, then bump the comparison back one day
	if current_time < 720:
            if today == 0:
                today = 6
            else:
                today -= 1

        #if today is D, check current time against settings for D_start and D_end
        if  today == 0 and not(user_settings['mon_start'] < current_time < user_settings['mon_end']) and\
            today == 1 and not(user_settings['tue_start'] < current_time < user_settings['tue_end']) and\
            today == 2 and not(user_settings['wed_start'] < current_time < user_settings['wed_end']) and\
            today == 3 and not(user_settings['thr_start'] < current_time < user_settings['thr_end']) and\
            today == 4 and not(user_settings['fri_start'] < current_time < user_settings['fri_end']) and\
            today == 5 and not(user_settings['sat_start'] < current_time < user_settings['sat_end']) and\
            today == 6 and not(user_settings['sun_start'] < current_time < user_settings['sun_end']):
            
                #forgive me
                global current_location  
                current_location = request.json['beacon_id']
        
                response = jsonify({'message': "POST Successful"})

        else:
            current_location = "quiet_hours"
            response = jsonify({'message': "quiet hours in effect, current_location set to placeholder."}) 

    else:
        response = jsonify({'message': "Invalid Request"})

    return response

#the client devices will check to determine whether they should be active
#returns current location
@api.route('/current_location', methods = ['GET'])
def get_current_location():

    try:
        return jsonify({'beacon_id': current_location})

    except:
        return jsonify({'message': "no current_location set"})

#adds location given beacon_id, SpeakerID, and IP Address of client Pi
@api.route('/locations', methods = ['POST'])
def add_location():
    if request.headers['Content-Type'] == 'application/json':

        try:
            db.add_location(request.json['beacon_id'], request.json['speaker_id'], request.json['ip_addr'], request.json['location_name'])

        except:

            response = jsonify({'message': "db.add_location() error"})

        response = jsonify({'message': "POST Successful"})

    else:
        response = jsonify({'message': "Invalid Request"})

    return response

#updates location details
@api.route('/locations', methods = ['PUT'])
def update_location():
    if request.headers['Content-Type'] == 'application/json':

        try:
            db.add_location(request.json['beacon_id'], request.json['speaker_id'], request.json['ip_addr'], request.json['location_name'])

        except:

            response = jsonify({'message': "db.add_location() error"})

        response = jsonify({'message': "PUT Successful"})

    else:
        response = jsonify({'message': "Invalid Request"})

    return response

#returns all locations, SpeakerID, and IPAddress of client Pi
@api.route('/locations', methods = ['GET'])
def get_all_locations():

    locations = db.get_all_locations()

    if not locations:
        return jsonify({'message': "no locations found"})
    
    return jsonify({'locations': locations})

# Returns speaker_id, location_name, and ip_addr of specified beacon (GET Identifier)
@api.route('/beacons/<beacon_id>', methods=['GET'])
def get_beacon_details(beacon_id):
    
    details = db.get_beacon_details()

    if not details:
        return jsonify({'message': "no information found"})

    return jsonify({'details': details})


# Updates specified elements of selected beacon (PUT Identifier)


# Returns server's time
@api.route('/time', methods = ['GET'])
def get_server_time():
    return jsonify({'time': time.time()})

# Notifies server that user is still active (PUT Identifier)

# Notifies server that device speaker is still active (PUT Identifier)

# Returns all users and sleep settings (GET Resource)
@api.route('/users', methods = ['GET'])
def get_all_users():
    return jsonify({'users': db.get_all_users()})

# Creates new user entry (POST)
@api.route('/users', methods = ['POST'])
def add_user():
    
    #assume that it will fail, change it if it succeeds
    response = jsonify({'message': "Invalid Request"})

    if request.headers['Content-Type'] == 'application/json':

        try:
            #the userdict should contain at least a key value pair for user_name
            #i.e. "user_name":"USERNAMEHERE"
            #similarly for times:
            #i.e. "mon_start":"TIMEHERE"

            #two python sins in one script, nice
            db.add_user(eval(request.json['userdict']))
             
            response = jsonify({'message': "POST Successful"})

        except:
            response = jsonify({'message': "db.add_user() error"})


    return response

#updates user entry
@api.route('/users', methods = ['PUT'])
def update_user():
    
    #assume that it will fail, change it if it succeeds
    response = jsonify({'message': "Invalid Request"})

    if request.headers['Content-Type'] == 'application/json':

        try:
            #the userdict should contain at least a key value pair for user_name
            #i.e. "user_name":"USERNAMEHERE"
            #similarly for times:
            #i.e. "mon_start":"TIMEHERE"

            #two python sins in one script, nice
            db.add_user(eval(request.json['userdict']))
             
            response = jsonify({'message': "PUT Successful"})

        except:
            response = jsonify({'message': "db.add_user() error"})


    return response

# Returns sleep settings and name for specified user (GET Identifier)
@api.route('/users/<user_id>', methods = ['GET'])
def get_user(user_id):
    user_details = db.get_user_details(user_id)

    if not user_details:
        return jsonify({'message': "no user found"})
    
    return jsonify({'user': user_details})


# Update specified elements of selected user (Put Identifier)

# Delete a location by beacon_id
@api.route('/locations', methods=['DELETE'])
def delete_location():
    if request.headers['Content-Type'] == 'application/json':

        try:
            db.delete_location(request.json['beacon_id'])

        except:
            response = jsonify({'message': "db.delete_location() error"})

        response = jsonify({'message': "DELETE Successful"})

    else:
        response = jsonify({'message': "Invalid Request"})

    return response


if __name__ == '__main__':
    api.run(host='0.0.0.0')

