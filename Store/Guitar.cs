namespace Store
{
    public class Guitar
    {
        public string Name { get; }
        public int Id { get; }

        public Guitar (string name, int id)
        {
            Name = name;
            Id = id;
        }

    }
}