DROP TABLE IF EXISTS `Beacons`;
CREATE TABLE `Beacons` (
    `beacon_id` VARCHAR(128) NOT NULL,
    `speaker_id` INT,
    `ip_addr` VARCHAR(32) NOT NULL,
    `location_name` VARCHAR(255),
    PRIMARY KEY (`beacon_id`)
);

DROP TABLE IF EXISTS Settings;
CREATE TABLE Settings (
    `user_id` VARCHAR(128),
    `user_name` VARCHAR(255) DEFAULT NULL,
    `mon_start` INT DEFAULT -1,
    `mon_end` INT DEFAULT -1,
    `tue_start` INT DEFAULT -1,
    `tue_end` INT DEFAULT -1,
    `wed_start` INT DEFAULT -1,
    `wed_end` INT DEFAULT -1,
    `thr_start` INT DEFAULT -1,
    `thr_end` INT DEFAULT -1,
    `fri_start` INT DEFAULT -1,
    `fri_end` INT DEFAULT -1,
    `sat_start` INT DEFAULT -1,
    `sat_end` INT DEFAULT -1,
    `sun_start` INT DEFAULT -1,
    `sun_end` INT DEFAULT -1,
    PRIMARY KEY (`user_id`)
);

