using System;

/// <summary>
/// Class that encapsulates triangle attributes and behaviors. validate methods in the class ensures that
/// constraints of a triangle is met.
/// </summary>
namespace TriangleFinder;

public enum Orientation
{
    RIGHTSIDE_UP = 0,
    UPSIDE_DOWN = 1

}

public class Triangle
{


    string[] triableLebels = { "A1", "A2", "A3", "A4", "A5", "A6", "A7", "A8", "A9", "A10", "A11", "A12",
    "B1", "B2", "B3", "B4", "B5", "B6", "B7", "B8", "B9", "B10", "B11", "B12",
    "C1", "C2", "C3", "C4", "C5", "C6", "C7", "C8", "C9", "C10", "C11", "C12",
    "D1", "D2", "D3", "D4", "D5", "D6", "D7", "D8", "D9", "D10", "D11", "D12",
    "E1", "E2", "E3", "E4", "E5", "E6", "E7", "E8", "E9", "E10", "E11", "E12",
    "F1", "F2", "F3", "F4", "F5", "F6", "F7", "F8", "F9", "F10", "F11", "F12" };

    public String? label { get; set; }

    private int row;
    private int col;
    private Orientation orientation;

    private Dictionary<string, string> mapDictionary = new Dictionary<string, string>();

    public int getRow()
    {
        return row;
    }
    public int getCol()
    {
        return col;
    }


    public Triangle(String label)
    {
        this.label = label;
        validateLabel();

    }
    /// <summary>
    /// constructs triangle based on vertices. values can be between 0 to 60 in multiple of 10
    /// </summary>
    /// <param name="v1x"></param>
    /// <param name="v1y"></param>
    /// <param name="v2x"></param>
    /// <param name="v2y"></param>
    /// <param name="v3x"></param>
    /// <param name="v3y"></param>

    public Triangle(int v1x, int v1y, int v2x, int v2y, int v3x, int v3y)
    {
        this.v1x = v1x;
        this.v1y = v1y;

        this.v2x = v2x;
        this.v2y = v2y;

        this.v3x = v3x;
        this.v3y = v3y;

        validateVertices();

        // if it is good, load coordinates

        loadMapLabel();

    }


    public int v1x { get; set; }
    public int v1y { get; set; }
    public int v2x { get; set; }
    public int v2y { get; set; }
    public int v3x { get; set; }
    public int v3y { get; set; }

    /// <summary>
    /// validates if vertices are valid or not. values can be between 0 to 60 in multiple of 10 
    /// </summary>
    /// <exception cref="ArgumentException"></exception>
    private void validateVertices()
    {
        //check to see if the value is between 0 and 60
        if (v1x < 0 || v1y < 0 || v2x < 0 || v2y < 0 || v3x < 0 || v3y < 0 || v1x > 60 || v1y > 60 || v2x > 60 || v2y > 60 || v3x > 60 || v3y > 60)
        {

            Console.WriteLine(" invalid values entered. it must be between 0 and 60");
            throw new ArgumentException("Invalid values entered. it must be between 0 and 60");

        }
        //check to see if the value is mutiple of 10
        if ((v1x % 10) != 0 || (v1y % 10) != 0 || (v2x % 10) != 0 || (v2y % 10) != 0 || (v3x % 10) != 0 || (v3y % 10) != 0)
        {

            Console.WriteLine(" invalid values entered. it must be between 0 and 60 in addition to it must be mutiple of 10");
            throw new ArgumentException("Invalid values entered. it must be between 0 and 60 in addition to it must be mutiple of 10");



        }
        // find the length of two points is 10
        //use triangle length formula here.
        int xLen1 = (int)Math.Sqrt(Math.Pow((v1x - v2x), 2));
        int xLen2 = (int)Math.Sqrt(Math.Pow((v2x - v3x), 2));
        int xLen3 = (int)Math.Sqrt(Math.Pow((v3x - v1x), 2));
        int yLen1 = (int)Math.Sqrt(Math.Pow((v1y - v2y), 2));
        int yLen2 = (int)Math.Sqrt(Math.Pow((v2y - v3y), 2));
        int yLen3 = (int)Math.Sqrt(Math.Pow((v3y - v1y), 2));

        //check to see if the lenght is 10

        if ((xLen1 != 0 && xLen1 != 10) || (xLen2 != 0 && xLen2 != 10) || (xLen3 != 0
            && xLen3 != 10) || (yLen1 != 0 && yLen1 != 10) || (yLen2 != 0
                && yLen2 != 10 || (yLen3 != 0 && yLen3 != 10)))
        {

            Console.WriteLine(" invalid values entered. it must be between 1 and 60 mutiple of 10 and triangle lines length must be 10");
            throw new ArgumentException("invalid values entered. it must be between 1 and 60 mutiple of 10 and triangle lines length must be 10");



        }
        //reaching here means , coordinates are validd and meets the constraints.




    }
    /// <summary>
    /// validates if triangle label passed in meets the naming constraints.
    /// </summary>
    /// <exception cref="ArgumentException"></exception>

    private void validateLabel()
    {

        if (label == null)
        {

            Console.WriteLine("Label can not be null");
            throw new ArgumentException("Label can not be null");
        }

        if (label.Length <= 1 || label.Length > 3)
        {
            Console.WriteLine("Invalid value. allowed values [A-F][1-12]");
            throw new ArgumentException("Invalid value. allowed values [A-F][1-12]");
        }
        label = label.ToUpper();

        int asciiRow = (int)label[0];

        if (asciiRow < 65 || asciiRow > 70)
        {

            throw new ArgumentException("Invalid value. allowed values [A-F][1-12]");
        }

        //since row increases by 10, mutiple by 10
        this.row = (asciiRow - 64) * 10;

        String numLabel = label.Substring(1);
        Console.WriteLine(numLabel);
        int col = 0;
        if (int.TryParse(numLabel, out col) == false)
        {
            Console.WriteLine("Value is not numberic [A-F][1-12]");
            throw new ArgumentException("Invalid value. Value is not numberic. Allowed values [A-F][1-12]");
        }

        if (col < 1 || col > 12)
        {
            Console.WriteLine("Value is not numberic [A-F][1-12]");
            throw new ArgumentException("Invalid value. Allowed values [A-F][1-12]");
        }




        //check to see if the column is even or odd
        int iColtype = col % 2;

        if (iColtype == 0)
        {
            this.orientation = Orientation.UPSIDE_DOWN; //sets the orientation
            col = (col / 2) * 10; // for calculating columns, figure out columns it falls in
        }
        else
        {
            this.orientation = Orientation.RIGHTSIDE_UP;
            col = (((col + 1) / 2) * 10) - 10;   // for odd columns, add one, subtract 10 after mutiply 10
        }
        this.col = col;


    }
    /// <summary>
    /// returns orientation of a triangle
    /// </summary>
    /// <returns>orientation of the triangle</returns>

    public Orientation getOrientation()
    {
        return this.orientation;
    }
    /// <summary>
    /// overrides string method for displaying the content for logging
    /// </summary>
    /// <returns></returns>

    public override string ToString()
    {
        return "Triangle:\n " + "Label: " + this.label + "\n Orientation: " + orientation + "\n V1(" + v1x + "," + v1y + ")"
            + "\n V2(" + v2x + "," + v2y + ")" + "\n V3(" + v3x + "," + v3y + ")\n";



    }
    /// <summary>
    /// loads label and their coordinates into dictionary for input lookup
    /// </summary>

    private void loadMapLabel()
    {

        foreach (String aLabel in this.triableLebels)
        {
            poplateLabelsTheirCoordinates(aLabel);
        }


    }
    /// <summary>
    /// populates triangle coordinates for each label
    /// </summary>
    /// <param name="val"> label name</param>

    private void poplateLabelsTheirCoordinates(String val)
    {


        int row = val[0];
        int asciiRow = (int)row;
        String colstr = val.Substring(1);
        int col = 0;
        int.TryParse(colstr, out col);



        //figure out columns and row
        //here X is column nad Y is rwo. (0, 0) starts at upper left corner
        //row number correspond to A=1, B=2, C=3, D=4, E=5, F=6
        //ascii('A') = 65 => 65-64 = 1
        int yRow = asciiRow - 64; // take ascii of A and subtract 64 to find the row it will fall
        int xCol = 0;
        yRow = yRow * 10; // every rwo is of width 10 pixels

        int orientationTmp = col % 2;
        if (orientationTmp == 0)
            xCol = ((col / 2) * 10);
        else
            xCol = ((((col + 1) / 2) * 10) - 10);


        String key = "";
        String value = "";
        int v1x = 0;
        int v1y = 0;
        int v2x = 0;
        int v2y = 0;
        int v3x = 0;
        int v3y = 0;

        //check the orientation based on the input
        //odd - triangle is rightside up
        //even - triangle is upside down

        if (orientationTmp == 0)
        {
            v1x = xCol;
            v1y = yRow;

            // now move up from this point, that means substract 10 from this point and keep columnx
            v2x = v1x;
            v2y = v1y - 10;

            // now move x to left meaning substract 10 from v2x and keep the same row
            v3x = v2x - 10;
            v3y = v2y;

        }
        else
        {
            v1x = xCol;
            v1y = yRow;

            // now move to right from this point, that means add 10 to v1x and keep the row same
            v2x = v1x + 10;
            v2y = v1y;

            // now move y up by 10 from v1y meaning substract 10 from v1y and keep the same column v1x
            v3x = v1x;
            v3y = v1y - 10;

        }
        //create key value for each combination
        //it alloes inputs vertices to be in any order
        //each triangle points will have 6 representation

        value = val + "_" + "1";
        key = "" + v1x + "" + v1y + "" + v2x + "" + v2y + "" + v3x + "" + v3y;
        mapDictionary.Add(key, value);

        value = val + "_" + "2";
        key = "" + v1x + "" + v1y + "" + v3x + "" + v3y + "" + v2x + "" + v2y;
        mapDictionary.Add(key, value);

        value = val + "_" + "3";
        key = "" + v2x + "" + v2y + "" + v3x + "" + v3y + "" + v1x + "" + v1y;
        mapDictionary.Add(key, value);

        value = val + "_" + "4";
        key = "" + v2x + "" + v2y + "" + v1x + "" + v1y + "" + v2x + "" + v2y;
        mapDictionary.Add(key, value);

        value = val + "_" + "5";
        key = "" + v3x + "" + v3y + "" + v1x + "" + v1y + "" + v2x + "" + v2y;
        mapDictionary.Add(key, value);

        value = val + "_" + "6";
        key = "" + v3x + "" + v3y + "" + v2x + "" + v2y + "" + "" + v1x + "" + v1y;
        mapDictionary.Add(key, value);


    }
    /// <summary>
    /// determines triangle label based on coordinates
    /// </summary>

    public void matchLabel()
    {
        String key = "" + this.v1x + "" + this.v1y + "" + this.v2x + "" + this.v2y + "" + this.v3x + "" + this.v3y;

        String value = mapDictionary[key];
        //remove _  from the value before setting
        this.label = value.Substring(0, (value.IndexOf("_")));
    }

}


