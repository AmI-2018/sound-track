from Flask import Flask, request, jsonify
import db
import routing
import cast

api = Flask(__name__)

##give a beacon, return a speaker
#@api.route('/beacons/<BeaconID>/speaker', methods = ['GET'])
#def speaker(BeaconID):
    
#return a list of all connected chromecasts as a JSON object
@api.route('/chromecasts', methods = ['GET'])
def chromecasts():
    return jsonify(cast.discover())

#route audio to given location, return whether the request succeeded or failed
@api.route('/location', methods = ['POST'])
def set_location():
    if request.headers['Content-Type'] == 'application/json':
        cast.set_output(request.json['SpeakerID'])

        response = jsonify({'message': "POST Successful"})

    else:
        response = jsonify({'message': "Invalid Request"})

    return response

