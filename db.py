import pymysql.cursors

from config import USER, PASS, SOCK

# gets our connection to the database
def get_connection():
    connection = pymysql.connect(user = USER,
                                 password = PASS,
                                 unix_socket = SOCK,
                                 db='sound-track',
                                 charset='utf8mb4',
                                 cursorclass=pymysql.cursors.DictCursor)

    return connection


#given a string:BeaconID, return a string:SpeakerID
def get_speaker(BeaconID):
    
    connection = get_connection()

    sql = "SELECT SpeakerID FROM Beacons WHERE BeaconID = %s;"

    try:
        cursor = connection.cursor()
        cursor.execute(sql, BeaconID)
        
        output = cursor.fetchall()

        SpeakerID = ''

        if not output:
            SpeakerID = 'NoSpeakerIDFound'
        
        else:
            SpeakerID = output['SpeakerID']

    finally:
        connection.close()

    return SpeakerID


#given a string:BeaconID and a string:SpeakerID, add the Beacon:Speaker pair to the database
def add_beacon(BeaconID, SpeakerID):
    #open the connection to the database
    connection = get_connection()

    sql = "INSERT INTO Beacons (BeaconID, SpeakerID) VALUES (%s, %s);"

    try:
        cursor = connection.cursor()
        cursor.execute(sql, (BeaconID, SpeakerID))
        connection.commit()

    finally:
        connection.close()

#given a string:BeaconID, delete the beacon and all associated speakers from the database
def delete_beacon(BeaconID):
    #open the connection to the database
    connection = get_connection()

    sql = "DELETE FROM Beacons WHERE BeaconID = %s;"

    try:
        cursor = connection.cursor()
        cursor.execute(sql, BeaconID)
        connection.commit()


    #close connection and return True on successful delete
    finally:
        connection.close()

#given a string:BeaconID and string:SpeakerID, change the Speaker paired with specified beacon
def update_beacon(BeaconID, SpeakerID):

    sql = "UPDATE Beacons SET SpeakerID = %s WHERE BeaconID = %s;"

    connection = get_connection()

    try:
        cursor = connection.cursor()
        cursor.execute(sql, (SpeakerID, BeaconID))
        connection.commit()

    finally:
        connection.close()

#list all Beacons and their paired Speakers in database
def get_all_beacons():

    sql = "SELECT * FROM Beacons;"
    
    beacons = []

    connection = get_connection()

    try:
        cursor = connection.cursor()
        cursor.execute(sql)

        beacons = cursor.fetchall()
        
    finally:
        connection.close()
        return beacons
