using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDo.Data.Models.TicTakToeModel;

public class WinnigCombination
{
    public int Square1 { get; set; }

    public int Square2 { get; set; }

    public int Square3 { get; set; }

    public WinnigCombination(int square1, int square2, int square3)
    {
        Square1 = square1;

        Square2 = square2;

        Square3 = square3;
    }
}
