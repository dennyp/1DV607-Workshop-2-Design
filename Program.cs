using System;

namespace Workshop_2___Design
{
  class Program
  {
    static void Main(string[] args)
    {
      Boolean isRunning = true;
      View.UserInterface view = new View.UserInterface();
      Controller.Secretary secretary = new Controller.Secretary();
      
      do
      {
        view.PresentMenu();
        string choice = view.CollectData().ToLower();

        switch (choice)
        {
          case "1":
            secretary.RegisterMember();
            break;
          case "2":
            secretary.DeleteMember();
            break;
          case "q":
            isRunning = false;
            break;
        }
      } while (isRunning);
    }
  }
}
