/* CSE 381 - BetterLinearSerach
*  (c) BYU-Idaho - It is an honor code violation to post this
*  file completed in a public file sharing site. F5.
*
*  Instructions: Refer to W01 Prove: Assignment in Canvas for detailed instructions.
*/

namespace AlgorithmLib;

public static class BetterLinearSearch
{

    /* Search for an item in a list.  Ignore duplicates by exiting
    *  as soon as the first match is found.
    *
    *  Inputs:
    *     data - list to search
    *     target - value to search for
    *  Outputs:
    *     Index where target was found
    *
    *  Note: Return -1 if target not found
    */
    public static int Search<T>(List<T> data, T target) where T : IComparable<T>
    {
        for (int i = 0; i < data.Count; i++) // Iterates through the data provided
        {
            if (data[i].CompareTo(target) == 0) // Checks to see if the data is equal to the target
            {
                return i; // If found, stops the search and returns the index
            }
        }
        return -1; //If not, returns -1
    }
}