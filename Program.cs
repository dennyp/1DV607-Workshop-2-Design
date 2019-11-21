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
          case "3":
            secretary.ShowMemberList();
            break;
          case "4":
            secretary.SpecificMemberInfo();
            break;
          case "5":
            secretary.ChangeMemberInfo();
            break;
          case "6":
            secretary.RegisterBoat();
            break;
          case "7":
            secretary.DeleteBoat();
            break;
          case "8":
            // secretary.ChangeBoatInfo();
            break;
          case "q":
            isRunning = false;
            break;
        }
      } while (isRunning);
    }
  }
}
