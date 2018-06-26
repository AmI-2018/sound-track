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

def add_location(beacon_id, speaker_id, ip_addr, location_name):
    #open the connection to the database
    connection = get_connection()

    sql = "INSERT INTO Beacons (beacon_id, speaker_id, ip_addr, location_name) VALUES (%s, %s, %s, %s);"

    try:
        cursor = connection.cursor()
        cursor.execute(sql, (beacon_id, speaker_id, ip_addr, location_name))
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

#get all attrib for given beacon
def get_beacon_details(beacon_id):

    sql =  "SELECT speaker_id, location_name, ip_addr FROM Beacons WHERE beacon_id = %s"

    connection = get_connection()

    try:
        cursor = connection.cursor()
        cursor.execute(sql, beacon_id)

        beacon_details = cursor.fetchall()

    finally:
        connection.close()
        return beacon_details

#add user given a string user_name and a dictionary of sleep settings (day:time)
def add_user(user_name, **kwargs):

    #a list of times in the order they are found
    ordered_sleep_settings = []

    sql = "INSERT INTO Settings (user_name, user_id"
    sql_cap = ") VALUES (%s, %s"

    if "mon_start" in kwargs:

        sql += ", mon_start, mon_end"
        sql_cap += ", %s, %s"
        ordered_sleep_settings.extend(kwargs['mon_start'], kwargs['mon_end'])

    elif "tue_start" in kwargs:

        sql += ", tue_start, tue_end"
        sql_cap += ", %s, %s"
        ordered_sleep_settings.extend(kwargs['tue_start'], kwargs['tue_end'])

    elif "wed_start" in kwargs:

        sql += ", wed_start, wed_end"
        sql_cap += ", %s, %s"
        ordered_sleep_settings.extend(kwargs['wed_start'], kwargs['wed_end'])

    elif "thr_start" in kwargs:

        sql += ",thr_start, thr_end"
        sql_cap += ", %s, %s"
        ordered_sleep_settings.extend(kwargs['thr_start'], kwargs['thr_end'])

    elif "fri_start" in kwargs:

        sql += ", fri_start, fri_end"
        sql_cap += ", %s, %s"
        ordered_sleep_settings.extend(kwargs['fri_start'], kwargs['fri_end'])

    elif "sat_start" in kwargs:

        sql += ", sat_start, sat_end"
        sql_cap += ", %s, %s"
        ordered_sleep_settings.extend(kwargs['sat_start'], kwargs['sat_end'])


    elif "sun_start" in kwargs:

        sql += ", sun_start, sun_end"
        sql_cap += ", %s, %s"
        ordered_sleep_settings.extend(kwargs['sun_start'], kwargs['sun_end'])


    sql += sql_cap    
    sql += ");"

    connection = get_connection()

    try:
        cursor = connection.cursor()
        cursor.execute(sql, (user_name, hash(user_name), *ordered_sleep_settings))
        connection.commit()

    finally:
        connection.close()

def get_user_details(user_id):
    
    connection = get_connection()

    sql = "SELECT * FROM Settings WHERE user_id = %s;"

    try:
        cursor = connection.cursor()
        cursor.execute(sql, user_id)
        
        user_details = cursor.fetchall()

    finally:
        connection.close()

    return user_details

def get_all_users():

    connection = get_connection()

    sql = "SELECT * FROM Settings;"

    try:
        cursor = connection.cursor()
        cursor.execute(sql)

        users = cursor.fetchall()

    finally:
        connection.close()
        return users
