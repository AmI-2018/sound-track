#!/bin/bash

arecord -D hw:0,0 -f S16_LE -c2|nc -l 3333 &;nc -l 3334|aplay
