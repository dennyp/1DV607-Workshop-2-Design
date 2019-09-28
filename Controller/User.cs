namespace Controller
{
  public class User
  {
    public void CreateMember()
    {
      View.UserInterface view = new View.UserInterface();

      view.PresentMemberCreationUI();

      view.PresentMemberNameUI();
      string name = view.CollectData();

      view.PresentMemberPersonalIdUI();
      string ssn = view.CollectData();

      Model.Member member = new Model.Member(name, ssn);
    }
  }
}
