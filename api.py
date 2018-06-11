from Flask import Flask, request, jsonify
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
def get_location():

    return jsonify({'BeaconID': current_location})

#adds location given BeaconID, SpeakerID and IP Address of client Pi
@api.route('/locations', methods = ['POST'])
def add_location():
    if request.headers['Content-Type'] == 'aplication/json':

        try:
            db.add_location(request.json['BeaconID'], request.json['SpeakerID'], request.json['IPAddr'])
        except:

            response = jsonify({'message': "db.add_location() error"}]

        response = jsonify({'message': "POST Successful"}]

    else:
        response = jsonify({'message': "Invalid Request"}]

    return response
