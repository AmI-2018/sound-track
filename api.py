from Flask import Flask, request, jsonify
from tempfile import TemporaryFile
import db

api = Flask(__name__)


current_location = TemporaryFile()


#route audio to given location, return whether the request succeeded or failed
@api.route('/location', methods = ['POST'])
def set_location():
    if request.headers['Content-Type'] == 'application/json':
        
        current_location = request.json['BeaconID']

        response = jsonify({'message': "POST Successful"})

    else:
        response = jsonify({'message': "Invalid Request"})

    return response

#the client devices will check to determine whether they should be active
#returns current location
@api.route('/location', methods = ['GET'])
def get_location():

    return jsonify({'BeaconID': current_location})
