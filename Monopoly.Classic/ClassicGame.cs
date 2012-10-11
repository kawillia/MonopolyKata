
namespace Monopoly.Classic
{
    public class ClassicGame : Game
    {
        public ClassicGame()
            : base(new ClassicBoard(), new Dice())
        {
        }
    }
}
