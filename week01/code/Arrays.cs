using System.Diagnostics;

public static class Arrays
{
    /// <summary>
    /// This function will produce an array of size 'length' starting with 'number' followed by multiples of 'number'.  For 
    /// example, MultiplesOf(7, 5) will result in: {7, 14, 21, 28, 35}.  Assume that length is a positive
    /// integer greater than 0.
    /// </summary>
    /// <returns>array of doubles that are the multiples of the supplied number</returns>
    public static double[] MultiplesOf(double number, int length)
    {
        //creating the list where the numbers will be stored on.
        List<double> totalNums = new() {};
        
        //looping through the length of numbers given
        for (int i = 1; i <= length; i++)
        {      
            //calculating the multiples of the number given (e.j 3*1, 3*2...etc)
            var multiple = number * i;
            totalNums.Add(multiple);
        }

        //converting the doubles into an array.
        return  totalNums.ToArray();
    }

    /// <summary>
    /// Rotate the 'data' to the right by the 'amount'.  For example, if the data is 
    /// List<int>{1, 2, 3, 4, 5, 6, 7, 8, 9} and an amount is 3 then the list after the function runs should be 
    /// List<int>{7, 8, 9, 1, 2, 3, 4, 5, 6}.  The value of amount will be in the range of 1 to data.Count, inclusive.
    ///
    /// Because a list is dynamic, this function will modify the existing data list rather than returning a new list.
    /// </summary>
    public static void RotateListRight(List<int> data, int amount)
    {
        // 1. Find where the list should be split
        var splitIndex = data.Count - amount;
        
        // 2. Get the last "amount" elements
        var lastpart = data.GetRange(splitIndex, amount);


        // 3. Get the first part of the list
        var firstpart = data.GetRange(0, splitIndex);
        // 4. Rebuild the list in rotated order
        //clearing list
        data.RemoveRange(0, data.Count);

        //add last part
        data.AddRange(lastpart);

        //adding first part
        data.AddRange(firstpart);
    }
}
