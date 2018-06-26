import subprocess
import requests
import time
from config import SERVER, MY_ID

session = requests.Session()

session.headers.update({'Content-type': 'application/json'})

url = SERVER + "/current_location"

last_location = None

while True:

    new_location = session.get(url)['beacon_id']

    if new_location == MY_ID and last_location != MY_ID:
        command = "arecord -D hw:0,0 -f S16_LE -c2|nc {0} 3334 &;nc {0} 3333|aplay".format(SERVER)
        process = subprocess.Popen(command.split(), stdout=subprocess.PIPE)
        
        #this is for debugging, there shouldn't be output in normal circumstances
        output, error = process.communicate()

        last_location = MY_ID

    elif new_location != MY_ID:
        command = "pkill -f 'arecord' && pkill -f 'nc' && pkill -f 'aplay'"
        process = subprocess.Popen(command.split(), stdout=subprocess.PIPE)
       
         #this is for debugging, there shouldn't be output in normal circumstances
        output, error = process.communicate()
        
        last_location = new_location

    #This clause could be removed but just for verbosity I'll leave it in for now
    else:
        last_location = new_location
    
    time.sleep(2) 
