import pymysql.cursors
import hashlib

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

        speaker_id = ''

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

    sql = "REPLACE INTO Beacons (beacon_id, speaker_id, ip_addr, location_name) VALUES (%s, %s, %s, %s);"

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

#add user given a dictionary of sleep settings (day:time) and a user name
def add_user(userdict):

    #a list of times in the order they are found
    ordered_sleep_settings = []

    sql = "REPLACE INTO Settings (user_name, user_id"
    sql_cap = ") VALUES (%s, %s"

    if userdict["mon_start"] is not None:

        sql += ", mon_start, mon_end"
        sql_cap += ", %s, %s"
        ordered_sleep_settings.extend((userdict['mon_start'], userdict['mon_end']))

    if userdict["tue_start"] is not None:

        sql += ", tue_start, tue_end"
        sql_cap += ", %s, %s"
        ordered_sleep_settings.extend((userdict['tue_start'], userdict['tue_end']))

    if userdict["wed_start"] is not None:

        sql += ", wed_start, wed_end"
        sql_cap += ", %s, %s"
        ordered_sleep_settings.extend((userdict['wed_start'], userdict['wed_end']))

    if userdict["thr_start"] is not None:

        sql += ",thr_start, thr_end"
        sql_cap += ", %s, %s"
        ordered_sleep_settings.extend((userdict['thr_start'], userdict['thr_end']))

    if userdict["fri_start"] is not None:

        sql += ", fri_start, fri_end"
        sql_cap += ", %s, %s"
        ordered_sleep_settings.extend((userdict['fri_start'], userdict['fri_end']))

    if userdict["sat_start"] is not None:

        sql += ", sat_start, sat_end"
        sql_cap += ", %s, %s"
        ordered_sleep_settings.extend((userdict['sat_start'], userdict['sat_end']))

    if userdict["sun_start"] is not None:

        sql += ", sun_start, sun_end"
        sql_cap += ", %s, %s"
        ordered_sleep_settings.extend((userdict['sun_start'], userdict['sun_end']))


    sql += sql_cap    
    sql += ");"

    connection = get_connection()

    try:
        cursor = connection.cursor()
        cursor.execute(sql, (userdict['user_name'],userdict['user_id'], *ordered_sleep_settings))
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

