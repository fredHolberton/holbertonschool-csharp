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
                throw new ArgumentException("Height must be greater than or equal to 0");
            }
            else
            {
                height = value;
            }                
        }
    }

    /// <summary>Function Area that overrides the Area() method 
    /// defined in the Shape base class.
    /// </summary>
    public new int Area()
    {
        return Width * Height;
    }

    /// <summary>Overrides Shape method ToString to print the Area of a Rectangle.</summary>
    public override string ToString()
    {
        return "[Rectangle] " + Width + " / " + Height;
    }

}

/// <summary>This is a public class Square that inherits from Rectangle.</summary>
public class Square : Rectangle
{
    private int size;

    /// <summary>Gets or sets the size of the Square.</summary>
    public int Size 
    { 
        get
        {
            return size;
        } 
        set
        {
            if (value < 0)
            {
                throw new ArgumentException("Size must be greater than or equal to 0");
            }
            else
            {
                size = value;
                Width = value;
                Height = value;
            }               
        }
    }

    /// <summary>Overrides Rectangle method ToString to print the Area of a Square.</summary>
    public new string ToString()
    {
        return "[Square] " + Size + " / " + Size;
    }

}

