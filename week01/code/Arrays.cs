public static class Arrays
{
    public static void Run()
    {
        // PART 1: MultiplesOf examples
        double[] example1 = MultiplesOf(3, 5);
        Console.Write("MultiplesOf(3, 5) = ");
        foreach (var num in example1)
        {
            Console.Write(num + " ");
        }
        Console.WriteLine();

        double[] example2 = MultiplesOf(4, 6);
        Console.Write("MultiplesOf(4, 6) = ");
        foreach (var num in example2)
        {
            Console.Write(num + " ");
        }
        Console.WriteLine();

        // PART 2: RotateListRight examples
        var listA = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
        Console.WriteLine("Before rotate by 5: " + string.Join(" ", listA));
        RotateListRight(listA, 5);
        Console.WriteLine("After rotate by 5: " + string.Join(" ", listA));

        var listB = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
        Console.WriteLine("Before rotate by 3: " + string.Join(" ", listB));
        RotateListRight(listB, 3);
        Console.WriteLine("After rotate by 3: " + string.Join(" ", listB));
    }

    /*
     PLAN for MultiplesOf:
     1. Validate the count (if <= 0, return empty array).
     2. Create an array with the size equal to count.
     3. Loop through from 0 to count-1.
     4. For each index, calculate start * (i + 1).
     5. Return the filled array.
    */
    public static double[] MultiplesOf(double start, int count)
    {
        if (count <= 0) return Array.Empty<double>();

        var result = new double[count];
        for (int i = 0; i < count; i++)
        {
            result[i] = start * (i + 1);
        }
        return result;
    }

    /*
     PLAN for RotateListRight:
     1. Validate input (null or empty list -> return).
     2. Use modulo to normalize amount so it’s less than list size.
     3. Create a temp array with the same size.
     4. Loop through list:
        - Calculate new index = (i + amount) % size.
        - Place element in that new index.
     5. Copy values back from temp into original list.
    */
    public static void RotateListRight(List<int> data, int amount)
    {
        if (data == null || data.Count == 0) return;

        int n = data.Count;
        amount = amount % n;
        if (amount == 0) return;

        var temp = new int[n];
        for (int i = 0; i < n; i++)
        {
            int newIndex = (i + amount) % n;
            temp[newIndex] = data[i];
        }

        for (int i = 0; i < n; i++)
        {
            data[i] = temp[i];
        }
    }
}
