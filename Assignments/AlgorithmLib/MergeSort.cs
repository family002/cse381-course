/* CSE 381 - Merge Sort
*  (c) BYU-Idaho - It is an honor code violation to post this
*  file completed in a public file sharing site. F5.
*
*  Instructions: Refer to W03 Prove: Assignment in Canvas for detailed instructions.
*/

namespace AlgorithmLib;

public static class MergeSort
{
    /* Use Merge Sort to sort a list of values in place
     *
     *  Inputs:
     *     data - list of values
     *  Outputs:
     *     none
     */
    public static void Sort<T>(List<T> data) where T : IComparable<T> 
    {
        // Start the recursive process with the whole list
        if (data == null || data.Count <= 1)
            return;
        _Sort(data, 0, data.Count-1);
    }

    /* Recursively use merge sort to sort a sublist
     * defined by first and last.
     * 
     *  Inputs:
     *     data - list of values
     *     first - the starting index of the sublist
     *     last - the ending index of the sublist
     *  Outputs:
     *     None
     */
    public static void _Sort<T>(List<T> data, int first, int last) where T : IComparable<T>
    {
        if (first >= last) // Base Case
            return;

        int mid = (first + last) / 2; // Determine mid point, then sort the two halves and merge them
        _Sort(data, first, mid);
        _Sort(data, mid + 1, last);
        Merge(data, first, mid, last);
    }

    /* Merge two sorted list which are adjacent to each other back into
     * the same list.
     *
     *  Inputs:
     *     data - list of values
     *     first - the starting index of the first sorted sublist
     *     mid - the ending index of the first sorted sublist (second sublist starts after)
     *     last - the ending index of the second sorted sublist
     *  Outputs:
     *     None
     */
    public static void Merge<T>(List<T> data, int first, int mid, int last) where T : IComparable<T>
    {
        // Create temporary memory for the lists, create pointers, and merge the two lists
        List<T> sa1 = data.GetRange(first, mid - first + 1);
        List<T> sa2 = data.GetRange(mid + 1, last - mid);
        int sa1Index = 0;
        int sa2Index = 0;
        int mIndex = first;

        //If lists have elements, merge
        while (sa1Index < sa1.Count && sa2Index < sa2.Count)
        {
            if (sa1[sa1Index].CompareTo(sa2[sa2Index]) <= 0)
            {
                data[mIndex] = sa1[sa1Index];
                sa1Index++;
            }
            else
            {
                data[mIndex] = sa2[sa2Index];
                sa2Index++;
            }
            mIndex++;
        }

        //If one list has elements, add them
        while (sa1Index < sa1.Count)
        {
            data[mIndex] = sa1[sa1Index];
            sa1Index++;
            mIndex++;
        }
        while (sa2Index < sa2.Count)
        {
            data[mIndex] = sa2[sa2Index];
            sa2Index++;
            mIndex++;
        }
    }
}

