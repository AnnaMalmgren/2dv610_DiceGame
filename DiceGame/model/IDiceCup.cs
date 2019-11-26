using System.Collections.Generic;

namespace DiceGame.model
{
  public interface IDiceCup
  {
      int GetOneRoundScore(int numDice);
      void SetDice(int numDice);
      void RollDice();
      int GetScore();
      void Reset();
      void AddSubscriber(IRollDieObserver subscriber);
      void NotifySubscribers(int faceValue);

  }
}