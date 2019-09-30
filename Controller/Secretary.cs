using System.Collections.Generic;
using System.IO;
using System.Reflection;
using Newtonsoft.Json;

namespace Controller
{
  public class Secretary
  {
    public void RegisterMember()
    {
      View.UserInterface view = new View.UserInterface();

      view.PresentMemberCreationUI();

      view.PresentMemberNameUI();
      string name = view.CollectData();

      view.PresentMemberPersonalIdUI();
      string ssn = view.CollectData();

      Model.Member member = new Model.Member(name, ssn);
      member.SaveToFile();
    }


  }
}
