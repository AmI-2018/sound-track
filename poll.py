import requests
import time
from config import SERVER

session = requests.Session()

session.headers.update({'Content-type': 'application/json'})

url = SERVER + "/current_location"

while True:
    with open(current_location, 'w') as f:
        f.seek(0)
        f.write(session.get(url))
        f.truncate()

    time.sleep(2) 
