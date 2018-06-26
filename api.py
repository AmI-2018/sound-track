from flask import Flask, request, jsonify
import db
import time

current_location = None

api = Flask(__name__)

#route audio to given location, return whether the request succeeded or failed
@api.route('/current_location', methods = ['POST'])
def set_location():
    if request.headers['Content-Type'] == 'application/json':
      
        #forgive me
        global current_location  
        current_location= request.json['beacon_id']
        
        response = jsonify({'message': "POST Successful"})

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
            db.add_location(request.json['beacon_id'], request.json['speaker_id'], request.json['ip_addr'])

        except:

            response = jsonify({'message': "db.add_location() error"})

        response = jsonify({'message': "POST Successful"})

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
    if request.headers['Content-Type'] == 'application/json':

        #only specify a string user_name and a dictionary of sleep settings (day:time), a user_id is generated in db.py
        try:
 
            db.add_user(request.json['user_name'], request.json['sleep_settings'])

        except:
            response = jsonify({'message': "db.add_user() error"})

        response = jsonify({'message': "POST Successful"})

    else:
        response = jsonify({'message': "Invalid Request"})

    return response
   

# Returns sleep settings and name for specified user (GET Identifier)
@api.route('/users/<user_id>', methods = ['GET'])
def get_user():
    user_details = db.get_user_details()

    if not user_details:
        return jsonify({'message': "no user found"})
    
    return jsonify({'user': user_details})


# Update specified elements of selected user (Put Identifier)



if __name__ == '__main__':
    api.run()

