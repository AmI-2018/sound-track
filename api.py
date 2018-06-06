from Flask import Flask, request, jsonify
import db

api = Flask(__name__)

#route audio to given location, return whether the request succeeded or failed
@api.route('/location', methods = ['POST'])
def set_location():
    if request.headers['Content-Type'] == 'application/json':
        #set_output(request.json['SpeakerID'])

        response = jsonify({'message': "POST Successful"})

    else:
        response = jsonify({'message': "Invalid Request"})

    return response

