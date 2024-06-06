using System;

namespace hw17
{
    public delegate void MyEventHandler<T>(object sender, T eventArgs);

    internal class Program
    {
        public delegate string ColorToRGB(string color);
        public delegate int SevenMultiplesNumbers(int[] array);
        public delegate int PositiveNumbers(int[] array);
        public delegate int[] NegativeNumbers(int[] array);
        public delegate bool WordChecker(string text, string word);
        static void Main(string[] args)
        {
            while (true)
            {
                Console.Write("Choose number of task(1-6): ");
                int.TryParse(Console.ReadLine(), out int task);
                if (task == 0) break;

                switch (task)
                {
                    case 1:
                        ColorToRGB rgb = delegate (string color)
                        {
                            switch (color)
                            {
                                case "Red":
                                    return "RGB: (255, 0, 0)";
                                case "Orange":
                                    return "RGB: (255, 165, 0)";
                                case "Yellow":
                                    return "RGB: (255, 255, 0)";
                                case "Green":
                                    return "RGB: (0, 128, 0)";
                                case "Blue":
                                    return "RGB: (0, 0, 255)";
                                case "Indigo":
                                    return "RGB: (75, 0, 130)";
                                case "Violet":
                                    return "RGB: (238, 130, 238)";
                                default:
                                    return $"{color} is not a valid rainbow color";
                            }
                        };
                        Console.WriteLine(rgb("Red"));
                        Console.WriteLine(rgb("Pink"));
                        break;
                    case 2:
                        var myBackpack = new Backpack()
                        {
                            Color = "Blue",
                            BrandAndMaker = "Nike & Nike Inc.",
                            Cloth = "Nylon",
                            Weight = 1.5,
                            Volume = 30.0
                        };
                        myBackpack.myEvent += delegate (object sender, Item item)
                        {
                            Console.WriteLine($"Item added: {item.Name}, Volume: {item.Volume}");
                        };
                        try
                        {
                            myBackpack.AddItem(new Item("Laptop", 15.0));
                            myBackpack.AddItem(new Item("Notebook", 5.0));
                            myBackpack.AddItem(new Item("Water Bottle", 10.0));
                            myBackpack.AddItem(new Item("Extra Shoes", 5.0));
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine($"Exception: {ex.Message}");
                        }

                        myBackpack.DisplayContents();
                        break;
                    case 3:
                        SevenMultiplesNumbers num = (int[] array) =>
                        {
                            int amount = 0;
                            foreach (int value in array)
                            {
                                if (value % 7 == 0)
                                {
                                    amount += 1;
                                }
                            }
                            return amount;
                        };
                        int[] array1 = { 1, 21, -15, 6, -7 };
                        Console.WriteLine($"Multiples of seven value: {num(array1)}");

                        break;
                    case 4:
                        PositiveNumbers num2 = (int[] array) =>
                        {
                            int amount = 0;
                            foreach (int value in array)
                            {
                                if (value > 0)
                                {
                                    amount += 1;
                                }
                            }
                            return amount;
                        };
                        int[] array2 = { 1, 21, -15, 6, -7 };
                        Console.WriteLine($"Positive value: {num2(array2)}");
                        break;
                    case 5:
                        NegativeNumbers num3 = (int[] array) =>
                        {
                            int[] nums = new int[array.Length];
                            foreach (int value in array)
                            {
                                if (value < 0)
                                {
                                    nums.Append(value);
                                }
                            }
                            return nums;
                        };
                        int[] array3 = { 1, 20, -15, 6, -9 };
                        Console.WriteLine($"Negative numbers:");
                        foreach (var value in num3(array3).Distinct())
                        {
                            Console.Write(value + " ");
                        }
                        Console.WriteLine();
                        break;
                    case 6:
                        WordChecker checkWord = (text, word) => text.Contains(word);
                        string sampleText = "To be, or not to be, that is the question:";
                        string wordToCheck1 = "question";
                        string wordToCheck2 = "answer";

                        Console.WriteLine($"Checking if '{wordToCheck1}' is in the text: {checkWord(sampleText, wordToCheck1)}");
                        Console.WriteLine($"Checking if '{wordToCheck2}' is in the text: {checkWord(sampleText, wordToCheck2)}");
                        break;
                }
            }
        }
    }
}
