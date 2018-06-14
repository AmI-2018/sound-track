from flask import Flask, request, jsonify
from tempfile import TemporaryFile
import db

api = Flask(__name__)


current_location = TemporaryFile()


#route audio to given location, return whether the request succeeded or failed
@api.route('/current_location', methods = ['POST'])
def set_location():
    if request.headers['Content-Type'] == 'application/json':
        
        current_location = request.json['BeaconID']

        response = jsonify({'message': "POST Successful"})

    else:
        response = jsonify({'message': "Invalid Request"})

    return response

#the client devices will check to determine whether they should be active
#returns current location
@api.route('/current_location', methods = ['GET'])
def get_current_location():
    
    try:
        return jsonify({'BeaconID': current_location})

    except:
        return jsonify({'message': "no current_location set"})

#adds location given BeaconID, SpeakerID and IP Address of client Pi
@api.route('/locations', methods = ['POST'])
def add_location():
    if request.headers['Content-Type'] == 'application/json':

        try:
            db.add_location(request.json['BeaconID'], request.json['SpeakerID'], request.json['IPAddr'])

        except:

            response = jsonify({'message': "db.add_location() error"})

        response = jsonify({'message': "POST Successful"})

    else:
        response = jsonify({'message': "Invalid Request"})

    return response



#returns all locations BeaconID, SpeakerID and IPAddress of client Pi
@api.route('/locations', methods = ['GET'])
def get_all_locations():

    locations = db.get_all_locations()

    if not locations:
        return jsonify({'message': "no locations found"})
    
    return jsonify({'locations': db.get_all_locations()})

if __name__ == '__main__':
    api.run()

