#!/bin/bash

while true
do

	arecord -D plughw:1,0 -f S16_LE -c1 -r 16000|nc -l 3333 2>&1

done

exit 0

