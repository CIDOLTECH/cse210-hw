using System;

/// <summary>
/// Represents a fraction made up of a top (numerator) and bottom (denominator)
/// number. This class demonstrates encapsulation: the internal data (_top and
/// _bottom) is hidden behind private fields, and all interaction happens
/// through constructors, getters/setters, and purposeful behavior methods
/// (GetFractionString and GetDecimalValue).
/// </summary>
class Fraction
{
    // Private fields: hidden from anything outside this class.
    private int _top;
    private int _bottom;

    /// <summary>
    /// Default constructor. Initializes the fraction to 1/1.
    /// </summary>
    public Fraction()
    {
        _top = 1;
        _bottom = 1;
    }

    /// <summary>
    /// Constructor that takes only the top number.
    /// The bottom number is initialized to 1 (e.g., 5 becomes 5/1).
    /// </summary>
    public Fraction(int top)
    {
        _top = top;
        _bottom = 1;
    }

    /// <summary>
    /// Constructor that takes both the top and bottom numbers.
    /// </summary>
    public Fraction(int top, int bottom)
    {
        _top = top;
        _bottom = bottom;
    }

    /// <summary>
    /// Gets the top (numerator) value.
    /// </summary>
    public int GetTop()
    {
        return _top;
    }

    /// <summary>
    /// Sets the top (numerator) value.
    /// </summary>
    public void SetTop(int top)
    {
        _top = top;
    }

    /// <summary>
    /// Gets the bottom (denominator) value.
    /// </summary>
    public int GetBottom()
    {
        return _bottom;
    }

    /// <summary>
    /// Sets the bottom (denominator) value.
    /// Guards against a zero denominator, since a fraction can never
    /// legally divide by zero.
    /// </summary>
    public void SetBottom(int bottom)
    {
        if (bottom == 0)
        {
            throw new ArgumentException("Bottom of a fraction cannot be zero.");
        }
        _bottom = bottom;
    }

    /// <summary>
    /// Returns the fraction as a string in the form "top/bottom", e.g. "3/4".
    /// </summary>
    public string GetFractionString()
    {
        return $"{_top}/{_bottom}";
    }

    /// <summary>
    /// Returns the decimal value of the fraction (top divided by bottom).
    /// </summary>
    public double GetDecimalValue()
    {
        return (double)_top / _bottom;
    }
}
