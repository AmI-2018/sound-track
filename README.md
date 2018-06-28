## server-code
This branch contains the portion of sound-track that acts as a central server that stores user prefrences, beacon locations, and routes audio.

It is intended to be run on a Raspberry Pi running some flavor of linux (this is important for the /etc/rc.local file) that has python3 and mariadb installed.


# Sound Track

This system will allow for whatever a user is listening to (such as music and podcasts) to follow them around their house or flat. Sound Track would be for those who have a variety of audio equipment and want to seamlessly utilize it while going about their activities at home. It would keep track of where the user is and play their audio on the nearest available speaker system. This system would also be able to intelligently handle multiple users moving around and control volume in situations when there are other residents that shouldn?t be disturbed (such as phone calls or sleeping). Sound Track would be compatible with most audio sources and speaker systems and utilize other devices, such as smartphones, when no dedicated system is available. The system would have an interface that provides controls for initial setup, preferences, notifications explaining why an action was automatically performed with the option to override, and active controls such as volume and possibly standard media controls (i.e. previous track, next track, pause/play, etc.).
