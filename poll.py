import subprocess
import requests
import time
from config import SERVER

session = requests.Session()

session.headers.update({'Content-type': 'application/json'})

url = SERVER + "/current_location"

while True:

    if session.get(url)['BeaconID'] = MY_ID:
        command = "arecord -D hw:0,0 -f S16_LE -c2|nc {0} 3334 &;nc {0} 3333|aplay".format(SERVER)
        process = subprocess.Popen(command.split(), stdout=subprocess.PIPE)
        
        #this is for debugging, there shouldn't be output in normal circumstances
        output, error = process.communicate()

    else:
        command = "pkill -f 'arecord' && pkill -f 'nc' && pkill -f 'aplay'"
        process = subprocess.Popen(command.split(), stdout=subprocess.PIPE)
       
         #this is for debugging, there shouldn't be output in normal circumstances
        output, error = process.communicate()


    time.sleep(2) 
