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

def get_ip(beacon_id):
    
    connection = get_connection()

    sql = "SELECT ip_addr FROM Beacons WHERE beacon_id = %s;"

    try:
        cursor = connection.cursor()
        cursor.execute(sql, beacon_id)
        
        output = cursor.fetchall()

        speaker__id = ''

        if not output:
            ip_addr = 'NoIPFound'
        
        else:
            ip_addr = output['ip_addr']

    finally:
        connection.close()

    return ip_addr

def add_location(beacon_id, speaker_id, ip_addr):
    #open the connection to the database
    connection = get_connection()

    sql = "INSERT INTO Beacons (beacon_id, speaker_id, ip_addr) VALUES (%s, %s, %s);"

    try:
        cursor = connection.cursor()
        cursor.execute(sql, (beacon_id, speaker_id, ip_addr))
        connection.commit()

    finally:
        connection.close()

def delete_location(beacon_id):
    #open the connection to the database
    connection = get_connection()

    sql = "DELETE FROM Beacons WHERE beacon_id = %s;"

    try:
        cursor = connection.cursor()
        cursor.execute(sql, beacon_id)
        connection.commit()


    #close connection and return True on successful delete
    finally:
        connection.close()

def update_speaker(beacon_id, ip_addr):

    sql = "UPDATE Beacons SET ip_addr = %s WHERE beacon_id = %s;"

    connection = get_connection()

    try:
        cursor = connection.cursor()
        cursor.execute(sql, (ip_addr, beacon_id))
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
