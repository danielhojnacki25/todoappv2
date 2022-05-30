

namespace ToDo.Data.Models.TicTakToeModel;

public class Game
{

    public List<WinnigCombination> WinnigCombinations = new List<WinnigCombination>
   { 
       new WinnigCombination(1, 2, 3),
       new WinnigCombination(4, 5, 6),
       new WinnigCombination(7, 8, 9),
       new WinnigCombination(1, 4, 7),
       new WinnigCombination(2, 5, 8),
       new WinnigCombination(3, 6, 9),
       new WinnigCombination(1, 5, 9),
       new WinnigCombination(3, 5, 7)

       
   };

    public int OWinner { get; set; }
    public int XWinner { get; set; }
    public List<Square> Squares { get; protected set; }   

    public MarkEnum NextTurn { get; set; }

    public MarkEnum? Winner { get; set; }

    public Game()
    {
        
        ResetGame();
    }

    public void Next()
    {

        foreach (var winnigCombination  in WinnigCombinations )
        {
            if ( Squares[winnigCombination.Square1 - 1].Mark == MarkEnum.O && Squares[winnigCombination.Square2 - 1].Mark == MarkEnum.O && Squares[winnigCombination.Square3 - 1].Mark == MarkEnum.O )
            {
                Winner = MarkEnum.O;
            }
            else if (Squares[winnigCombination.Square1 - 1].Mark == MarkEnum.X && Squares[winnigCombination.Square2 - 1].Mark == MarkEnum.X && Squares[winnigCombination.Square3 - 1].Mark == MarkEnum.X )
            {
                Winner = MarkEnum.X;
            }
        }

        if (Winner.HasValue)
        {
            if (Winner == MarkEnum.O)
            {
                OWinner += 1;
            }
            if (Winner == MarkEnum.X)
            {
                XWinner += 1;
            }
            NextTurn = Winner.Value;
        }
        else
        {
            if (NextTurn == MarkEnum.O)
            {
                NextTurn = MarkEnum.X;
            }
            else
            {
                NextTurn = MarkEnum.O;
            }
        }
     
    }
    public void ResetGame()
    {
        Squares = new List<Square>();
        NextTurn = (Winner.HasValue ? Winner.Value : (NextTurn == MarkEnum.O ? MarkEnum.X : MarkEnum.O));
        Winner = null;
        for (var tt = 1; tt <= 9; tt++)
        {
            Squares.Add(new Square(tt));
        }
    }
}
