## Binary World - 3D Viewing Engine
# Overview
Binary World is a 3D viewing engine implemented in a .NET console application. This project visualizes 3D objects using a binary representation, where each pixel is represented by a dot (.) and absence by a space ( ). The engine employs basic plane intersection logic to render objects in a 2D console window.

# Features
Binary Representation: Visualizes 3D objects using only two characters: . and ' ' representing presence and absence of a pixel, respectively.
3D Rendering: Utilizes plane intersection algorithms to project 3D objects onto a 2D plane.
# Why
just for fun 

How It Works
Binary World renders 3D objects by calculating intersections between 3D planes and the viewer's perspective. The objects are then displayed in the console as a grid of characters by maping these intersection points inside a array grid.

Presence of Pixel: Represented by a dot (.).
Absence of Pixel: Represented by a space ( ).
