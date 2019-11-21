
namespace DiceGame.model
{
  public interface IDie
  {
      int GetFaceValue();
      void RollDie();
      bool ValidateNrOfSides(int value);

  }
}
