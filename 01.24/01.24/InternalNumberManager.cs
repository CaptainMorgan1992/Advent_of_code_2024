namespace _01._24;

public class NumberManager
{
    List<int> leftNumbers = new List<int>();
    List<int> rightNumbers = new List<int>();
    List<int> numbersAfterSubtracting = new List<int>();

    public NumberManager()
    { }
    public void TransferNumbersFromFileToLists()
    {
        string filePath = "aoc_input.txt";
        if (!File.Exists(filePath))
        {
            Console.WriteLine($"Error while reading information from file: {filePath}");
            return;
        }

        // The streamreader reads one line at the time.
        using (StreamReader reader = new StreamReader(filePath))
        {
            string line;
            while ((line = reader.ReadLine()) != null)
            {
                string[] numbers = line.Split(new[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);
                if (numbers.Length == 2)
                {
                    if (int.TryParse(numbers[0], out int leftNumber))
                    {
                        leftNumbers.Add(leftNumber);
                    }
                    else
                    {
                        Console.WriteLine("Failed to parse " + numbers[0] + " as an integer. (left side)");
                    }
                    
                    if (int.TryParse(numbers[1], out int rightNumber))
                    {
                        rightNumbers.Add(rightNumber);
                    }
                    else
                    {
                        Console.WriteLine("Failed to parse " + numbers[1] + " as an integer. (right side)");
                    }
                }
            }
        }
    }

    public void SortListItemsInAscendingOrder()
    {
        leftNumbers.Sort();
        rightNumbers.Sort();
    }

    public void SubtractSmallestNumbers()
    {
        numbersAfterSubtracting.Clear();  // Ensure it's empty before starting

        while (leftNumbers.Count > 0 && rightNumbers.Count > 0)
        {
            var leftNumber = leftNumbers[0]; 
            var rightNumber = rightNumbers[0]; 

            var result = Math.Abs(leftNumber - rightNumber);  // Always get positive difference
            numbersAfterSubtracting.Add(result);

            leftNumbers.RemoveAt(0);
            rightNumbers.RemoveAt(0);
        }
    }

    public void AddAllNumbers()
    {
        long numbersAfterAdding = 0;
        foreach (var number in numbersAfterSubtracting)
        {
            numbersAfterAdding += number;
        }
        Console.WriteLine($"Numbers after subtraction: {numbersAfterAdding}");
    }
}