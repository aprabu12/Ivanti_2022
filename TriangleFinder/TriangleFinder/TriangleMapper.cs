using System;

namespace TriangleFinder;

/// <summary>
/// Class that encpasulates logic for identifying a triangle based on a label or coordinates
/// </summary>


public class TriangleMapper
{
    private Triangle triangle;
    public TriangleMapper(Triangle triangle)
    {
        this.triangle = triangle;
    }

    /// <summary>
    /// method to identify label of a trinagle based on the coordinates of a triangle.
    /// this method assumes that sqaure of triangles is 60*60
    /// </summary>
    /// <returns>triangle object that contains identified label and its coordinates within the square</returns>

    public Triangle mapbyLabel()
    {
        Triangle t = new Triangle(this.triangle.label);


        if (this.triangle.getOrientation() == Orientation.RIGHTSIDE_UP) //odd numbers
        {

            t.v1x = this.triangle.getCol(); //calculated at this initialization of this class
            t.v1y = this.triangle.getRow();  //calculated at this initialization of this class
            // now move to right from this point, that means add 10 to v1x and keep the row same
            t.v2x = t.v1x + 10;
            t.v2y = t.v1y;
            //now move y up by 10 from v1y meaning substract 10 from v1y and keep the same column v1x
            t.v3x = t.v1x;
            t.v3y = t.v1y - 10;

        }
        else //even numbers
        {

            t.v1x = this.triangle.getCol(); //calculated at this initialization of this class
            t.v1y = this.triangle.getRow();  //calculated at this initialization of this class
            //now move up from this point, that means substract 10 from this point and keep columnx
            t.v2x = t.v1x;
            t.v2y = t.v1y - 10;
            //now move x to left meaning substract 10 from v2x and keep the same row
            t.v3x = t.v2x - 10;
            t.v3y = t.v2y;



        }

        Console.WriteLine(t.ToString());

        return t;
    }

    /// <summary>
    /// method that maps coordinates based on the label
    /// 
    /// </summary>
    /// <returns>return triangle with the label and the cordinates</returns>

    public Triangle mapbyCoordinates()
    {
        triangle.matchLabel();
        return triangle;
    }

}


