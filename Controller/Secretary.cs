using System;
using System.Collections.Generic;
using Model;
using View;

namespace Controller
{
  /// <summary>
  /// Representing the Secretary controller.
  /// </summary>
  public class Secretary
  {
    /// <summary>
    /// Registers a member and saves it to a member file.
    /// </summary>
    public void RegisterMember()
    {
      UserInterface view = new UserInterface();

      view.PresentMemberCreationUI();

      view.PresentMemberNameUI();
      string name = view.CollectData();

      view.PresentMemberPersonalIdUI();
      string ssn = view.CollectData();

      Member member = new Member(name, ssn);
      Model.FileHandler.Save(member);
    }

    /// <summary>
    /// Deletes a member from the member file.
    /// </summary>
    public void DeleteMember()
    {
      UserInterface view = new UserInterface();

      view.PresentDeleteMemberUI();
      string memberId = view.CollectData();

      Model.FileHandler.Delete(memberId);
    }

    /// <summary>
    /// Reads all the members from the member file and presents them to the view.
    /// </summary>
    public void ShowMemberList()
    {
      UserInterface view = new UserInterface();

      try
      {
        List<Member> members = Model.FileHandler.Show();

        view.PresentMemberListUI();
        string format = view.CollectData();

        foreach (var member in members)
        {
          view.PresentMemberString(member, format);
        }
      }
      catch (Exception ex)
      {
        view.PresentErrorMessage(ex.Message);
      }
    }
  }
}
