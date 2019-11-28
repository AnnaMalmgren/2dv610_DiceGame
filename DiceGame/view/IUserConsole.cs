
namespace DiceGame.view
{
  public interface IUserConsole
  {
    void WriteLine(string Message);
    
    char ReadKey();
    
    string ReadLine();
  }
}
