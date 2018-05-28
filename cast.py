import routing
import pychromecast


#finds connected chromecasts, returns a list of device details
def discover():

    devices = []

    chromecasts = pychromecast.get_chromecasts()

    for cc in chromecasts:
        cc.wait()
        devices.append(cc.device)

    return devices


#given a ChromecastID/SpeakerID, play media on that output
def set_output(SpeakerID):
    chromecasts = pychromecast.get_chromecasts()

    cast = next(cc for cc in chromecasts if cc.uuid == SpeakerID)

    mc = cast.media_controller

    #the media we want to play will go here
    #this will likely take the form of a USB soundcard having its ouput piped
    #to a ffmpeg server t
    mc.play_media('thisiswhereourmediawillgo', 'audio/mp3')
    mc.block_until_active()


    
