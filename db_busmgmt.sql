-- phpMyAdmin SQL Dump
-- version 4.0.4
-- http://www.phpmyadmin.net
--
-- Host: localhost
-- Generation Time: Feb 13, 2019 at 01:17 PM
-- Server version: 5.6.12-log
-- PHP Version: 5.4.16

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8 */;

--
-- Database: `db_busmgmt`
--
CREATE DATABASE IF NOT EXISTS `db_busmgmt` DEFAULT CHARACTER SET latin1 COLLATE latin1_swedish_ci;
USE `db_busmgmt`;

-- --------------------------------------------------------

--
-- Table structure for table `tbl_arealist`
--

CREATE TABLE IF NOT EXISTS `tbl_arealist` (
  `area_id` int(10) NOT NULL AUTO_INCREMENT,
  `area_name` varchar(50) NOT NULL,
  PRIMARY KEY (`area_id`)
) ENGINE=InnoDB  DEFAULT CHARSET=latin1 AUTO_INCREMENT=6 ;

--
-- Dumping data for table `tbl_arealist`
--

INSERT INTO `tbl_arealist` (`area_id`, `area_name`) VALUES
(1, 'SAMARTHNAGAR'),
(2, 'SAMARTHNAGAR'),
(3, 'SARASWATI COLONY'),
(4, 'SHAHAGANJ'),
(5, 'FAZALPURA');

-- --------------------------------------------------------

--
-- Table structure for table `tbl_busno`
--

CREATE TABLE IF NOT EXISTS `tbl_busno` (
  `bus_id` int(10) NOT NULL AUTO_INCREMENT,
  `bus_number` varchar(50) DEFAULT NULL,
  `bus_area` varchar(50) NOT NULL,
  PRIMARY KEY (`bus_id`)
) ENGINE=InnoDB  DEFAULT CHARSET=latin1 AUTO_INCREMENT=7 ;

--
-- Dumping data for table `tbl_busno`
--

INSERT INTO `tbl_busno` (`bus_id`, `bus_number`, `bus_area`) VALUES
(4, 'mh 20 15657', 'USmanpura'),
(5, 'MH 20 15678', 'FAZALPURA'),
(6, 'Mh 20 12345', 'SAMARTHNAGAR');

-- --------------------------------------------------------

--
-- Table structure for table `tbl_bus_mst`
--

CREATE TABLE IF NOT EXISTS `tbl_bus_mst` (
  `bus_id` int(10) NOT NULL AUTO_INCREMENT,
  `bus_number` int(50) NOT NULL,
  `bus_drivername` varchar(50) NOT NULL,
  `bus_driverid` int(50) NOT NULL,
  `bus_drivercontact` int(10) NOT NULL,
  PRIMARY KEY (`bus_id`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1 AUTO_INCREMENT=1 ;

-- --------------------------------------------------------

--
-- Table structure for table `tbl_driver_mst`
--

CREATE TABLE IF NOT EXISTS `tbl_driver_mst` (
  `driver_id` int(10) NOT NULL AUTO_INCREMENT,
  `driver_name` varchar(50) NOT NULL,
  `driver_mobile` varchar(50) NOT NULL,
  `driver_allowtedbus` varchar(50) NOT NULL,
  PRIMARY KEY (`driver_id`)
) ENGINE=InnoDB  DEFAULT CHARSET=latin1 AUTO_INCREMENT=11 ;

--
-- Dumping data for table `tbl_driver_mst`
--

INSERT INTO `tbl_driver_mst` (`driver_id`, `driver_name`, `driver_mobile`, `driver_allowtedbus`) VALUES
(8, 'raju', '5454343434', 'mh 20 15656'),
(10, 'sanju', '2323232323', 'MH 20 15678');

-- --------------------------------------------------------

--
-- Table structure for table `tbl_stud_mst`
--

CREATE TABLE IF NOT EXISTS `tbl_stud_mst` (
  `stud_id` int(10) NOT NULL AUTO_INCREMENT COMMENT 'student id ',
  `stud_name` varchar(20) DEFAULT NULL,
  `stud_class` varchar(20) DEFAULT NULL,
  `stud_div` varchar(20) DEFAULT NULL,
  `stud_mobile` double DEFAULT NULL,
  `stud_email` varchar(20) DEFAULT NULL,
  `stud_address` varchar(20) DEFAULT NULL,
  `stud_area` varchar(20) DEFAULT NULL,
  `stud_dob` varchar(10) DEFAULT NULL,
  `stud_gender` varchar(20) DEFAULT NULL,
  `stud_rollno` varchar(50) DEFAULT NULL,
  `RFID` varchar(50) DEFAULT NULL,
  PRIMARY KEY (`stud_id`)
) ENGINE=InnoDB  DEFAULT CHARSET=latin1 AUTO_INCREMENT=3 ;

--
-- Dumping data for table `tbl_stud_mst`
--

INSERT INTO `tbl_stud_mst` (`stud_id`, `stud_name`, `stud_class`, `stud_div`, `stud_mobile`, `stud_email`, `stud_address`, `stud_area`, `stud_dob`, `stud_gender`, `stud_rollno`, `RFID`) VALUES
(2, 'shraddha', '2nd', 'D', 8787878787, 'abc@gmail.com', 'jdfhjksdf', 'SAMARTHNAGAR', '02/13/1997', 'Male', '2', '87876');

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
