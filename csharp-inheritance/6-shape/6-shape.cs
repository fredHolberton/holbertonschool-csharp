using System;

/// <summary>This is a public class Shape.</summary>
public class Shape
{
    /// <summary>Function Area not implemented.</summary>
    public virtual int Area()
    {
        throw new NotImplementedException ("Area() is not implemented");
    }
}

/// <summary>This is a public class Rectangle that inherits from Shape.</summary>
public class Rectangle : Shape
{
    private int width;
    private int height;

    /// <summary>Gets or sets the width of the Rectangle.</summary>
    public int Width 
    { 
        get
        {
            return width;
        } 
        set
        {
            if (value < 0)
            {
                throw new ArgumentException("Width must be greater than or equal to 0");
            }
            else
            {
                width = value;
            }               
        }
    } 

    /// <summary>Gets or sets the height of the Rectangle.</summary>
    public int Height 
    { 
        get
        {
            return height;
        } 
        set
        {
            if (value < 0)
            {
                throw new ArgumentException("Weight must be greater than or equal to 0");
            }
            else
            {
                height = value;
            }                
        }
    }
}
