

namespace ToDo.Data.Models;

public class Square
{
    public int Number { get; }

    public MarkEnum? Mark { get; set; }

    public Square(int number)
    {
        Number = number;
    }
}
