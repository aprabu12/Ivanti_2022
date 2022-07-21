# Ivanti_2022
Source code for Ivanti technology challenge


It is a WebAPI to determine a right-angle triangle by label or coordinates in a square of right-angle triangles in 6 rows and 6 columns. This program assumes that each triangle's adjacent and opposite sides are 10 by 10 pixels long.

The  TriangleFinderController service API has two operations of the "get" type exposed by the "HTTP" protocol. The getTriangleLabel method determines a label of a triangle in a square based on vertices, and vertex can be given in any order. Based on the coordinates, it will provide the label. The operation will throw an error with the appropriate message for invalid coordinates inputs.

The operation getTriangleCoordinates of TriangleFinderController service API  will determine the coordinates of the triangle based on the label. The label name will be the format of  [A-F] followed by [1-12]. The operation will throw an error with an appropriate message for any other value.

There are two folders: TriangleFinder and testingvalidations. 

TriangleFinder : 

The folder containing the source code of all components of WebAPI

testingvalidations: 

The folder contains screenshots of the execution of the service methods with valid and invalid inputs to show the working of the operations.


