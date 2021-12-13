# Toy Robot

Toy Robot is a console application built in C#. It simulates a robot moving around a 6x6 grid.

## Download

Use the [release](https://github.com/thomasogg/ToyRobot/releases) to find the latest release.

## Instructions

The following commands can be used to move the robot around the 6x6 grid:

1. First place the robot inside the grid using the command PLACE X,Y,DIRECTION.
   * PLACE X,Y,DIRECTION e.g. PLACE 2,3,WEST.
     - X = Row Integer 0-5.
     - Y = Column Integer 0-5.
     - DIRECTION = Direction you want the robot to face e.g. SOUTH.

2. Use the below commands to move the robot after it has been placed:
   * MOVE - Moves the robot one space in the direction it's facing.
   * LEFT - Turn the robot 90 degrees to the LEFT.
   * RIGHT - Turn the robot 90 degrees to the RIGHT.
   * REPORT - Shows the current location and direction the robot is facing.
