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

def get_ip(BeaconID):
    
    connection = get_connection()

    sql = "SELECT IPAddr FROM Beacons WHERE BeaconID = %s;"

    try:
        cursor = connection.cursor()
        cursor.execute(sql, BeaconID)
        
        output = cursor.fetchall()

        SpeakerID = ''

        if not output:
            IPAddr = 'NoIPAddrFound'
        
        else:
            IPAddr = output['IPAddr']

    finally:
        connection.close()

    return IPAddr

def add_location(BeaconID, SpeakerID, IPAddr):
    #open the connection to the database
    connection = get_connection()

    sql = "INSERT INTO Beacons (BeaconID, SpeakerID, IPAddr) VALUES (%s, %s, %s);"

    try:
        cursor = connection.cursor()
        cursor.execute(sql, (BeaconID, SpeakerID, IPAddr))
        connection.commit()

    finally:
        connection.close()

def delete_location(BeaconID):
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

def update_speaker(BeaconID, IPAddr):

    sql = "UPDATE Beacons SET IPAddr = %s WHERE BeaconID = %s;"

    connection = get_connection()

    try:
        cursor = connection.cursor()
        cursor.execute(sql, (IPAddr, BeaconID))
        connection.commit()

    finally:
        connection.close()

#list all Beacons and their paired Speakers in database
def get_all_locations():

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
