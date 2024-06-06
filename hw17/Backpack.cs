
namespace hw17
{
    public class Item
    {
        public string Name { get; set; }
        public double Volume { get; set; }
        public Item(string name, double volume)
        {
            Name = name;
            Volume = volume;
        }
    }
    public class Backpack
    {
        public string Color { get; set; }
        public string BrandAndMaker { get; set; }
        public string Cloth { get; set; }
        public double Weight { get; set; }
        public double Volume { get; set; }
        public List<Item> Contents { get; set; }
        public double CurrentVolume;

        public Backpack()
        {
            Contents = new List<Item>();
            CurrentVolume = 0;
        }

        public void AddItem(Item item)
        {
            if (CurrentVolume + item.Volume > Volume)
            {
                throw new InvalidOperationException("Adding this item exceeds the backpack's volume.");
            }

            Contents.Add(item);
            CurrentVolume += item.Volume;
            ItemAddedEvent(item);
        }

        public event MyEventHandler<Item> myEvent;

        public void ItemAddedEvent(Item item)
        {
            myEvent.Invoke(this, item);
        }


        public void DisplayContents()
        {
            Console.WriteLine("Backpack Contents:");
            foreach (var item in Contents)
            {
                Console.WriteLine($"- {item.Name}, Volume: {item.Volume}");
            }
        }
    }
}
