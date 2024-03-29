﻿using System;

namespace Day13
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = @"                           /-------------------------------------------------------------------------------------------------\                        
 /-------------------------+--\/---------------------------------------------------------------------------------------------+----------\             
 |                       /-+--++---------------------------------------------------------------------------------------------+------\   |             
 |                /------+-+--++-------------------------------------------------------------------------<-\                 |      |   |             
 |           /----+------+-+--++----------------\                                                          |                 |      |   |             
 |           |    |      | |  ||                |                   /----------------\                     |                 |      |   |             
 |           |    |      | | /++---------\      |                   |                |                     |        /--------+------+---+-----------\ 
 |           |   /+------+-+-+++---------+------+-------------------+-------\   /----+---------------------+--------+--------+------+--\|           | 
 |           |   ||      | | |||         |      |  /----------------+-------+---+----+---------------------+\       |        |      |  ||           | 
 | /---------+\  ||      | | |||         |      |  |       /--------+-------+---+----+---------------------++-------+--------+------+--++--------\  | 
 | |         ||  ||      | | |||         |      |  |       | /------+-\     |   |    |                     ||       |   /----+------+--++------\ |  | 
 | |         ||  ||      | | ||| /-------+---\  |  |       | |      | |     |   |    |                     ||       |   |    |      |  ||      | |  | 
 | |         ||  ||   /--+-+-+++-+--\    |   |  |  |       | |      | |     |   |    |          /----------++-------+---+----+------+--++------+-+-\| 
 | |         ||  ||   |  | | ||| |  |    |   |  |  |       | |      | |     |  /+----+----------+----------++-------+---+----+------+--++------+-+\|| 
 | |         \+--++---+--+-+-+++-+--+----+---+--/  |       | |      | |     |  ||    |          |          ||       |   |    |      |  ||      | |||| 
 | |          |  ||   |  | | ||| |  |    |   |     |       | |      | |     |  ||    |          |          ||      /+---+----+------+--++-----\| |||| 
 | |          |  ||   |  | | ||| |/-+----+---+-----+-------+-+------+-+-----+--++----+----------+----------++------++---+----+---\  |  ||     || |||| 
/+-+----------+--++---+--+-+-+++-++-+----+---+-----+-------+-+------+-+-----+--++----+---------\|          ||      ||   |    | /-+--+--++---\ || |||| 
|| |          |  ||   |  | | ||| || |/---+---+-----+-------+-+------+-+-----+--++----+---------++----------++------++-\ |    | | |  |  ||   | || |||| 
|| |         /+--++---+--+-+-+++-++-++---+---+-----+\      | |      | |     |  ||    |         ||          ||      || | |    | | |  |  ||   | || |||| 
|| |         || /++---+--+-+-+++-++-++---+---+-----++------+-+------+-+-----+--++----+--\      ||          ||      || | |    | | |  |  ||   | || |||| 
|| |  /------++-+++---+--+\| \++-++-++---/   |     ||      | |   /--+-+-----+--++----+--+------++---------\||      || | \----+-+-+--+--++---+-+/ |||| 
|| |  |      || |||   |  ||\--++-++-++-------+-----++------+-+---+--+-+-----+--++----+--+------++-------->+++------++-+------/ | |  |  ||   | |  |||| 
|| |  |      || |||   |  ||   || || ||       |     ||      | |   |  | |     |  || /--+--+------++---------+++------++-+--------+-+--+--++\  | |  |||| 
|| |  |      || |||   |  \+---++-++-++-------+-----++------+-+---+--+-+-----+--++-+--+--+------++---------+++------++-+--------+-+--/  |||  | |  |||| 
|| |  |      || |||   | /-+---++-++-++-------+-----++------+-+---+--+-+-----+--++-+--+--+------++---------+++------++-+\       |/+-----+++--+-+--++++\
|| \--+------+/ |||   | | |   || || ||       |     ||      | |   |  | |     |  || |  |  |      ||         |||      || ||       |||     |||  | |  |||||
||    |      |  ||| /-+-+-+---++-++-++-------+-----++------+-+---+--+-+-----+--++-+--+\ |      ||         |||      ||/++-------+++-----+++--+-+-\|||||
||    |      |  ||| | | | |   || || ||       | /---++------+-+---+--+-+-----+--++-+\ || |      ||   /-----+++------+++++---\   |||     |||  | | ||||||
||    |    /-+--+++-+-+-+-+---++-++-++-------+-+---++------+-+---+--+-+-----+--++-++-++-+------++---+----\|||      |||||   |   |||     |||  | | ||||||
||/---+----+-+--+++-+-+-+-+---++-++-++-------+-+---++---\  | |   |  \-+-----+--++-++-/| |      ||   |    ||||      |||||   |   |||     |||  | | ||||||
|||   |    | |  ||| | | | |   || || ||       | |   ||   |  | |   |    |     |  || ||  | |      ||   |    ||||      |||||   |   |||     |||  | | ||||||
|||   |    | |  ||| | | | |/--++-++-++-------+-+---++---+--+-+---+----+-----+--++-++--+-+------++---+----++++\     |||||   |   |||     |||  | | ||||||
|||   |    | |  ||| | | | ||  || || ||       | |/--++---+--+-+---+----+-----+--++-++--+-+------++---+----+++++-----+++++-\ |   |||     |||  | | ||||||
|||   |    | |  ||| |/+-+-++--++-++-++-------+-++--++---+--+-+---+----+-----+--++-++--+-+------++---+----+++++-----+++++-+\|   |||     |||  | | ||||||
|||   |    | |  ||| ||| | ||  || || ||       | ||  ||   |  |/+---+----+--\  |  || ||  | |      ||   |    |||||    /+++++-+++-\ |||     |||  | | ||||||
|||   |    | |  ||| ||| | ||  || \+-++-------/ ||  ||   |  |||   |    |  |  |  \+-++--+-+------++---+----+++++----++++++-+++-+-+++-----+++--+-+-++/|||
|||   |   /+-+--+++-+++-+-++--++--+-++---------++--++---+--+++--\|    |  |  |   | ||  | |      ||   | /--+++++----++++++-+++-+-+++--\  |||  | | || |||
|||   |   || |  ||| ||| | ||  || /+-++---------++--++---+--+++--++----+--+--+---+-++--+-+------++---+-+--+++++-\  |||||| ||| | |||  |  |||  | | || |||
|||   |   || |  ||| ||| \-++--++-++-++---------++--++---+--+++--++----+--+--+---+-++--+-+------++---+-+--+++++-+--+++++/ ||| | |||  |  |||  | | || |||
|||   |   || |  ||| |||   ||  || || ||  /------++--++---+--+++--++----+--+--+---+-++--+-+-<----++---+-+--+++++\|  |||||  ||| | |||  |  |||  | | || |||
|||   |   || |  ||| |||   ||  || || ||  |/-----++--++---+--+++--++----+--+--+---+-++--+-+\     ||   | |  |||||||  |||||  ||| | |||  |  |||  | | || |||
|||   |   || |  ||| |||   |^  || || ||  ||     |\--++---+--+++--++----+--+--+---+-++--+-++-----++---+-+--+++++++--+++++--/|| | |||  |  |||  | | || |||
|||   |   || |  ||| |||/--++--++-++-++--++-----+---++---+--+++--++----+--+--+---+\||  | ||     ||   | |  |||||||  |||||   || | |\+--+--+++--+-+-++-++/
|||   |   || |  ||| ||||/-++--++-++-++--++-----+---++---+--+++--++----+--+--+-\ ||||  | ||     ||   \-+--+++++++--+++++---+/ | | |  |  |||  | | || || 
|||   |   ||/+--+++-+++++-++--++-++-++--++----\|   ||   |  |||  ||    |  |  | | ||||  | ||     ||   /-+--+++++++--+++++---+--+-+-+--+--+++\ | | || || 
||\---+---++++--+++-+++++-++--++-++-++--++----++---++---/  |||  ||    |  |  | | ||||  | ||     ||   | |  |||||||  |||\+---+--+-+-+<-+--++++-+-+-/| || 
||    |   ||||  ||| ||||| ||  || ||/++--++----++---++------+++--++----+--+--+-+-++++--+-++-----++---+-+-\|||||||  ||| |   |  | | |  |  |||| | |  | || 
||    |   ||||  ||| ||||| ||  || |||||  ||    ||   ||      |||  ||    |  |  | | ||\+--+-++-----++---+-+-++++++++--+++-+---+--+-+-+--+--++/| | |  | || 
||   /+---++++--+++-+++++-++--++\|||||  || /--++---++------+++--++----+--+--+-+-++-+--+-++-----++---+-+-++++++++--+++-+---+--+-+-+--+--++-+-+-+--+-++\
||   ||   ||||  ||| ||||| ||  |||||||| /++-+--++---++------+++--++----+--+--+-+-++-+--+-++-----++---+-+-++++++++--+++-+---+--+-+-+--+-\|| | | |  | |||
||   ||   ||||  ||| \++++-++--++++++++-+++-+--++---++------+++--++----+--+--+-+-++-+--/ ||     |\---+-+-++++++++--+++-+---+--+-+-+--+-+++-+-+-+--+-/||
||   ||   ||||  |||/-++++-++--++++++++-+++-+--++---++------+++--++----+--+--+-+-++-+----++-\   |    | | ||||||||  ||| |   |  | | |  | ||| | | |  |  ||
||   ||   ||||  |||| \+++-++--++++++++-+++-+--++---++------+++--++----+--+--+-+-++-+----++-+---+----+-+-++++++++--+++-+---/  | | |  | ||| | | |  |  ||
||   ||   ||||  ||||  ||| ||  |||||||| |||/+--++---++------+++--++----+--+\ | | || |    || |   |    | | ||||||||  ||| |      | | |  | ||| | | |  |  ||
||   ||   ||||  ||||  ||| ||  |||||||| |||||  ||  /++------+++--++----+--++-+-+-++-+\   || |   |    | | ||||||||  ||| |      | | |  |/+++-+-+-+-\|  ||
||   || /-++++--++++--+++-++--++++++++-+++++--++--+++------+++--++----+--++-+-+-++-++---++-+---+----+-+-++++++++-\||| |      | | |  ||||| | | | ||  ||
|| /-++-+-++++--++++--+++-++--++++++++-+++++--++--+++------+++--++----+-\|| | | || ||   || |   |    | | |||||||| |||| |      | | |  ||||| | | | ||  ||
|| | || | ||||  ||||  ||| ||  |||||||| |||||  ||  |||      |||  ||    | ||| | | || ||   || |   |    | | |||||||| |||| |      | | |  ||||| | | | ||  ||
|| | || | ||||  ||||  ||| ||  |||||||| |||||  || /+++------+++--++----+-+++-+-+-++-++---++-+---+----+-+-++++++++\|||| |      | | |  ||||| | | | ||  ||
|| | || | |||\--++++--+++-++--++++++++-+++++--++-+++/      |||/-++----+-+++-+-+-++-++---++-+---+----+-+\||||||||||||| |      | | |  ||||| | | | ||  ||
|| | || | |||   |||| /+++-++--++++++++-+++++--++\|||       |||| ||    | ||| | | || ||   || |   |    | ||||||||||||||| |      | | |  ||||| | | | ||  ||
||/+-++-+-+++---++++-++++-++--++++++++-+++++--++++++-------++++-++----+-+++\| | || ||   || |   |    | ||||||||||||||| |      | \-+--+++++-+-/ | ||  ||
|||| || | |||   |||| |||| ||  |||||||| |||||  ||||||       |||| ||/---+-+++++-+-++-++---++-+---+-\  | ||||||||||||||| |      |   |  ||||| |   | ||  ||
|||| || | |||   |||| |||| ||  |||||||| |||||  ||||||       ||\+-+++---/ ||||| | || ||   || |   | |  | ||||||||||||||| |      |   |  ||||| |   | ||  ||
|||| || | |||   |||| |||| ||  |||||||| |||||  ||||||       || | |||     ||||| | || ||   || |   | |  | ||||||||||||||| |      |   |  ||||| |   | ||  ||
|||| || | ||\---++++-++++-++--++++++++-+++++--/|||||       || | |||  /--+++++-+-++-++---++-+---+-+--+-+++++++++++++++-+------+--\|  ||||| |   | ||  ||
|||| || \-++----++++-++++-++--++++++++-+++++---+++++-------++-+-+++--+--+++++-+-++>++---++-+---+-+>-+-+++++++++++/||| |      |  ||  ||||| |   | ||  ||
||||/++---++---\||\+-++++-++--++++++++-+++++---+++++-------++-+-+++--+--+++++-+-++-++---++-+---+-+--+-+++++/||||| ||| |      |  ||  ||||| |   | ||  ||
|||||||   ||   ||| | |||\-++--++++++++-+++++---+++++-------++-+-+++--+--+++++-/ || ||   ||/+---+-+-\| ||||| ||||| ||| |   /--+--++--+++++-+---+-++-\||
|||||||  /++---+++-+-+++-\||  |||||||| |||||   |||||       || | |||  |  |||||   || ||   ||||   | | || ||||| ||||| ||| |   |  |  ||  ||||| |   | || |||
|||||||  |||   ||| | ||| |||  |||||||| |||||   |||||       || | ||v  |  |||||   || ||   ||||   | | || ||||| ||||| ||| |   |  |  ||  ||||| |   | || |||
|||||||  |||   ||| | ||| |||  |||||||| |||||   |||||     /-++-+-+++--+--+++++---++-++---++++---+-+-++-+++++-+++++-+++-+-\ |  |  ||  ||||| |   | || |||
|||||||  |||   ||| | ||| |||  |||||||| ||\++---+++++-----+-++-+-+++--+--+++++---++-++---+/||   | | || ||||| ||||| ||| | | |  |  ||  ||||| |   | || |||
|||||||  ||| /-+++-+-+++-+++--++++++++-++-++---+++++-\   | || | |\+--+--+++++---++-++---+-++---+-+-++-++++/ ||||| ||| | | |  |  ||  ||||| |   | || |||
|||||||  ||| | ||| | ||| ||| /++++++++-++-++---+++++-+---+-++-+\| |  |  |||||   || ||   | ||   | | || ||||  ||||| ||| | | |  |  || /+++++-+--\| || |||
|||||||  ||| | ||| | ||| ||| ||||||||| || ||   ||||| |/--+-++-+++-+--+--+++++---++-++-\ | ||   | | || ||||  ||||| ||| | | |  |  || |||||| |  || || |||
|||||||  ||| | ||| | ||| ||| ||||||||| || ||   ||||| ||  | || ||| |  |  |||||   || || | | ||   | | || ||||  ||||| ||| | | |  |  || |||||| |  || || |||
|||||||  ||| | ||| | ||| ||| ||||||||| || ||   ||||| ||  | || ||| |  |  |||||   || || | | \+---+-+-/| ||||  ||||| ||| | | |  |  || |||||| |  || || |||
|||||||  ||| | ||| | ||| ||| |||||\+++-++-++---+++++-++--+-++-+++-+--+--+++++---++-++-+-+--+---+-+--+-++++--+++++-+++-+-+-+--+--+/ |||||| |  || || |||
|||||||  ||| | ||| | ||| |||/+++++-+++-++-++---+++++-++--+-++-+++-+--+--+++++---++-++-+-+--+---+-+--+-++++--+++++-+++-+-+-+--+-\|  |||||| |  || || |||
|||||||  ||| | ||| | ||| ||||||||| |||/++-++---+++++-++--+-++-+++-+--+--+++++---++-++-+-+--+--\| |  | ||||  ||||| ||| | | |  | ||  |||||| |  || || |||
|||||||  ||| | ||| | ||| ||||||||| |||||| ||   ||||| ||  | || ||| |  |  |||||   || || | |  |  || |  | ||||  ||||| ||| | | |  | ||  |||||| |  || || |||
|||||||  ||| | ||| | ||| ||||||||| |||||| ||   ||||| ||  | || ||| |  |  |||||   || || | |  |  || |  | ||||  ||||| ||\-+-+-+--+-++--++++++-+--++-++-+/|
|||||||  ||| | ||| | ||| ||||||||| |||||| ||   ||||| ||  | || ||| |/-+--+++++---++-++-+-+--+--++-+--+-++++--+++++-++--+-+-+--+-++--++++++-+\ || || | |
|||||||  ||| | ||| | |\+-+++++++++-+/|||| ||   ||||| ||  | || ||| || |  |||||   || || | |  |  || |  | ||||  ||||| ||  | | |  | ||  \+++++-++-/| || | |
|||||||  ||| | ||| | | | ||||||||| | |||| ||   ||||| |\--+-++-+++-++-+--+++++---++-++-/ |  |  || |  | ||||  ||||| |\--+-+-+--+-++---+++++-++--/ || | |
|||||||  ||| | ||| | | | ||||||||| | ||\+-++---+++++-+---+-++-+++-++-+--+++++---++-++---+--+--++-+--+-++++--+++++-+---+-+-+--+-++---++/|| ||    || | |
|\+++++--+++-+-+++-+-+-+-+++++/||| | || | ||   ||||| |   | || ||| || |/-+++++---++-++---+--+--++\|  | ||||  ||||| |   | | |  | ||   || || ||    || | |
| |||||  ||| | ||| | | | ||||| ||| | || | ||   ||||| |   | || ||| || || |||||   || ||   |  |  ||||  | ||||  ||||| |   | | |  | ||   || || ||    || | |
| ||\++--+++-+-/|| | | | ||||| ||| | || | ||/--+++++-+---+-++-+++-++-++\|||||   || ||   |  |  ||||  | ||||  ||||| |   | | |  | ||   || || ||    || | |
| || ||  ||| |  || | | | ||||| ||| | || | |||  ||||\-+---+-++-+++-++-++++++++---++-++---+--+--++++--+-++++--/|||| |   | | |  | ||   || || ||    || | |
| || ||  ||| |  || | | | ||||| ||| |/++-+-+++--++++--+---+-++-+++-++-++++++++---++-++---+--+--++++-\| ||||   |||| |   | | |  | ||   || |v ||    || | |
| || ||  |||/+--++-+-+-+-+++++-+++-++++-+-+++--++++--+---+-++-+++-++-++++++++---++-++---+--+--++++\|| ||||   |||| |   | | |  | ||   || || ||    || | |
| || ||  |||||  || | | | ||||| ||| ||\+-+-+++--++++--+---+-++-+++-++-++++++++---++-++---+--+--+++++++-++++---++++-+---/ | |  | ||   v| || ||    || | |
| ||/++--+++++--++-+-+-+-+++++-+++-++-+-+-+++--++++--+---+-++-+++-++-++++++++---++-++--\|  |  ||||||| ||||   |||| |     | |  | ||   || || ||    || | |
| |||||  |||||  |\-+-+-+-+++++-+++-++-+-+-+++--++++--+---+-++-+++-++-+++++++/   || ||  ||  |  ||||||| ||||   |||| |     | |  | ||   || || ||    || | |
| |||||  |||||  |  | | | ||||| ||| || | | |||  ||||  |   | || ||| || |||||||  /-++-++--++--+-\||||||| ||||   |||| |     | |  | ||   || || ||    || | |
| |||||  |||||  |/-+-+-+-+++++-+++-++-+-+\|||  ||||  |   | || \++-++-+++++++--+-++-++--++--+-++++++++-+/||   |||| \-----+-+--/ ||   || || ||    || | |
| |||||  |||||  || | | | |v||| ||| || | |||||  ||||/-+---+-++--++-++-+++++++--+-++-++--++--+-++++++++-+-++---++++-------+-+----++---++-++-++----++-+\|
| |||||  |||||  || | | | ||||| ||| || | |||||  ||||| |   | ||  || || |||||||  | || ||  ||  | |^||||||/+-++---++++------\| |    ||   || || ||    || |||
| |||||  |||||  || | | | ||||\-+++-++-+-+++++--+++++-+---+-++--/| || |||||||  | || ||  ||  | |||||||||| ||   ||||      || |    ||   || || ||    || |||
| |||||  |||||  || | | | ||||  \++-++-+-+++++--+++++-+---+-++---+-++-+++++++--+-++-++--++--+-++++++++++-++---++++------++-+----++---++-+/ ||    || |||
| |||||  |||||  || | | | ||||   || || | |||||  ||||| |   | ||   | |\-+++++++--+-++-++--++--+-++++++++++-++---++++------++-+----++---++-+--+/    || |||
| |||||  |||||/-++-+-+-+-++++---++-++-+-+++++--+++++-+---+-++---+-+>-+++++++--+-++-++--++--+-++++++++++-++---++++----\ || |    ||   || |  |     || |||
| |||||  |||||| || | | | ||||   || || | |||||  ||||| |   | ||   | |  |||||||  | |^ ||  ||  | |||||||||| ||   ||||    | || |   /++-<-++-+--+---\ || |||
| |||||  |||||| || | | | ||||   || || \-+++++--+++++-+---+-++---+-+--+++++++--+-++-++--++--+-+/|||||||| ||   ||||    | || |   |||   || |  |   | || |||
| |||||  |||||| || | | | ||\+---++-++---+++++--+++++-+---+-++---+-+--+++++++--+-++-++--++--+-+-++++++++-++---/|||    | || |   |||   || |  |   | || |||
| ||||\--++++++-++-+-+-+-+/ |   || ||   |||||  ||||| |   | ||   | |  |||||||  | || ||  ||  | | |||||||| ||    |||    | || |   |||   || |  |   | || |||
| ||||   |||||| || | | \-+--+---++-++---+++++--+++++-+---+-++---+-+--+++++++--+-+/ ||  ||  | | |||||||| ||    |||    | || \---+++---++-+--+---+-++-/||
| ||||   |||||| || | |   |  |   || ||   \++++--+++++-+---+-++---+-+--+++++++--+-+--++--++--+-+-++++++++-++----/||    | ||     |||   || |  |   | ||  ||
| ||||   |||||| |\-+-+---+--+---++-++----/||\--+++++-+---+-++---+-+--++/||||  | |  ||  ||  | | |||||||| ||     ||/---+-++-\   |||   || |  |   | ||  ||
| ||||   |||||| |  | |   |  |   || ||     ||   ||||| |   | \+---+-+--++-++++--+-+--++--++--+-+-++++++++-++-----+++---+-++-+---+++---++-+--+---+-+/  ||
| ||\+---++++++-+--+-+---+--+---++-++-----++---+++++-+---+--+---+-+--++-++++--+-+--++--/|  | | |||||||| ||     |||   | || |   |||   || |  |   | |   ||
| || |   |||||| |  | |   |  |   || ||     ||   ||||| |   |  |   | |  || ||||  | \--++---+--+-+-++++++++-++-----+++---+-++-+---+++---++-/  |   | |   ||
| || |   |||||| |  | |   |  |   || ||     ||   ||||| |   |  |   | |  || ||||  |    ||   |  | | |||||||| ||     |||   | || |   |||   ||/---+---+-+-\ ||
| || |   \+++++-+--+-+---/  |   || ||     ||   ||||\-+---+--+---+-+--++-++++--+----++---+--+-+-++++++++-++-----+++---+-++-+---+++---+++---+---+-+-+-/|
| \+-+----+++++-+--+-+------+---++-++-----++---++++--+---+--+---+-+--++-+++/  |    ||/--+--+-+-++++++++-++-----+++---+-++-+\  |||   |||   |   | | |  |
|  | |    ||||| |  | |      |   || ||     ||   ||||  |   |  |   | |  || |||   |    |||  |  | | |||||||| ||     |||   | || ||  ||| /-+++---+\  | | |  |
|  | |    ||||| |  | |  /---+---++-++-----++---++++\ |   |  |   | |  || |||   |    |||  |  | | |||||||| ||     |||   | || ||  ||| | |||   ||  | | |  |
|  | |    ||||| |  | |  |   |   || ||     ||   \++++-+---+--+---+-+--++-+++---+----/||  |  | | |||||||| ||     |||   | || ||  ||| | |||   ||  | | |  |
\--+-+----+++++-+--+-+--+---+---++-++-----++----++++-+---+--+---+-+--++-+++---+-----++--+--+-+-/||||\++-++-----+++---+-++-++--+++-+-+++---/|  | | |  |
   | |    ||\++-+--+-+--+---+---++-++-----++----++++-+---+--+---+-+--++-+++---+-----++--+--+-+--++/| || ||     |||   | || ||  ||| | |||    |  | | |  |
   | |    |\-++-+--+-+--+---+---++-++-----++----++++-+---+--+---+-+--++-+++---+-----++--+--+-+--++-+-++-+/     |||   | || ||  ||| | |||    |  | | |  |
   | |    |  || |  | |  |   |   |\-++-----++----++++-+---+--+---+-+--++-+++---+-----++--+--+-+--++-+-++-+------/||   | || ||  ||| | |||    |  | | |  |
   | |    |  || |  | |  |   |   |  ||     ||    |||| |   |  |   | |/-++-+++---+-----++--+--+-+--++-+-++>+-------++---+-++-++--+++-+\|||    |  | | |  |
   | |    |  || \--+-+--+---+---+--++-----++----++++-+---+--+---+-++-++-+++---+-----++--/  | |  || | || |       ||   |/++-++--+++-+++++----+--+-+\|  |
   | |    |  ||    | |  |   |   |  ||     ||    |\++-+---+--+---+-++-++-+++---+-----++-----+-+--++-+-++-+-------/|   |||| ||  ||| |||||    |  | |||  |
   \-+----+--++----+-+--+---+---+--++-----++----+-++-+---+--+---+-++-++-/||   |     ||     | |  || | || |        |   |||| ||  ||| |||||    |  | |||  |
     |    |  ||    | |  |   |   |  ||     ||    | || |   |  |   | \+-++--++---+-----++-----+-+--+/ | || |        |   |||| ||  ||| |||||    |  | |||  |
     |    |  ||    | |  |   |   |  \+-----++----+-++-+---+--+---+--+-++--++---+-----++-----+-+--+--+-++-//-------+---++++\||  ||| |||||    |  | |||  |
     |    |  ||  /-+-+--+---+---+---+\    ||    | || |   |  |   |  | |\--++---+-----++-----+-+--/  | ||  |       |   |||||||  ||| |||||    |  | |||  |
     |    \--++--+-+-+--+---+---+---++----++----+-++-+---+--+---/  | |   ||   |     ||     | |     | ||  |       |   |||||||  ||| |||\+----+--+-/||  |
     |       ||  | | |  |   |   |   ||    |\----+-++-+---+--+------+-+---++---+-----++-----+-+-----+-++--+-------+---+++++++--+++-+++-+----+--+--++--/
     |       ||  | | |  \---+---+---++----+-----+-+/ |   |  |      | |   ||   |     ||     | |     | ||  |       |   |||||||  ||| ||| |    |  |  ||   
     |       ||  | | |      |   |   ||    |     | |  |   |  |      | |   ||   |     |\-----+-+-----+-++--+-------+---++++++/  ||| ||| |    |  |  ||   
     |       ||  | | \------+---+---++----+-----/ |  |   |  |      \-+---++---+-----+------+-+-----+-++--+-------+---++++++---+++-+/| |    |  |  ||   
     |       ||  | |        |   |   ||    |       |  |   |  |        |   ||   \-----+------+-/     | |\--+-------+---++++++---+++-+-/ |    |  |  ||   
     |       \+--+-+--------+---+---++----+-------+--/   |  |        |   ||         |      |       | \---+-------+---++/|||   ||| |   |    |  |  ||   
     |        |  | \--------+---+---++----+-------+------+--+--------+---++---------+------/       |     |       |   || |||   ||| |   |    |  |  ||   
     |        |  |          |   |   ||    |       |      |  \--------+---/| /-------+--------------+-----+-------+\  |\-+++-<-+++-+---+----+--+--/|   
     |        |  |          |   |   ||    |       |      \-----------+----+-+-------+--------------+-----+-------++--+--/||   ||| |   |    |  |   |   
     |        |  |          |   |   \+----+-------+------------------+----+-+-------+--------------/     |       ||  |   ||   ||| |   |    |  |   |   
     |        |  |          |   |    |    |       |                  \----+-+-------+--------------------+-------++--+---++---++/ |   |    |  |   |   
     |        |  \----------+---+----/    |       \-----------------------+-+-------/                    |       \+--+---+/   \+--+---+----+--/   |   
     \--------+-------------+---/         |                               | |                            \--------+--+---/     |  \---+----/      |   
              |             \-------------+-------------------------------+-+-------------------------------------+--+---------/      |           |   
              \---------------------------+-------------------------------+-+-------------------------------------+--/                |           |   
                                          |                               | |                                     |                   \-----------/   
                                          \-------------------------------/ \-------------------------------------/                                   ";
        }
    }
}
