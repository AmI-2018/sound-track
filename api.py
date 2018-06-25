from flask import Flask, request, jsonify
from tempfile import TemporaryFile
import db
import time

api = Flask(__name__)


current_location = TemporaryFile()


#route audio to given location, return whether the request succeeded or failed
@api.route('/current_location', methods = ['POST'])
def set_location():
    if request.headers['Content-Type'] == 'application/json':
        
        current_location = request.json['beacon_id']

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
            db.add_location(request.json['beacon_id'], request.json['SpeakerID'], request.json['IPAddr'])

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
    
    return jsonify({'locations': db.get_all_locations()})

# Returns speaker_id, location_name, and ip_addr of specified beacon (GET Identifier)

# Updates specified elements of selected beacon (PUT Identifier)

# Returns server's time
@api.route('/time', methods = ['GET'])
def get_server_time():
    return jsonify({'time': time.time()})

# Notifies server that user is still active (PUT Identifier)

# Notifies server that device speaker is still active (PUT Identifier)

# Returns all users and sleep settings (GET Resource)

# Creates new user entry (POST)

# Returns sleep settings and name for specified user (GET Identifier)

# Update specified elements of selected user (Put Identifier)



if __name__ == '__main__':
    api.run()

