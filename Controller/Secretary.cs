using System;
using System.Collections.Generic;
using System.Linq;
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
      try
      {
        view.PresentMemberCreationUI();

        view.PresentMemberNameUI();
        string name = view.CollectData();

        view.PresentMemberPersonalIdUI();
        string ssn = view.CollectData();

        Member member = new Member(name, ssn);
        FileHandler.Save(member);
      }
      catch (Exception)
      {
        view.PresentErrorMessage(ex.Message);

      }
    }

    /// <summary>
    /// Changes the information of a member.
    /// </summary>
    public void ChangeMemberInfo()
    {
      UserInterface view = new UserInterface();
      try
      {
        List<Member> members = FileHandler.Show();

        view.PresentMemberInfoUI();
        view.PresentMemberPersonalIdUI();
        string memberId = view.CollectData();
        Member member = members.SingleOrDefault(m => m.ID == memberId);

        view.PresentMemberNameUI();
        string name = view.CollectData();

        view.PresentMemberPersonalIdUI();
        string ssn = view.CollectData();

        FileHandler.Delete(memberId);
        member.Name = name;
        member.SSN = ssn;
        FileHandler.Save(member);
      }
      catch (Exception ex)
      {
        view.PresentErrorMessage(ex.Message);
      }

    }

    /// <summary>
    /// Deletes a member from the member file.
    /// </summary>
    public void DeleteMember()
    {
      UserInterface view = new UserInterface();

      try
      {
        view.PresentDeleteMemberUI();
        string memberId = view.CollectData();

        FileHandler.Delete(memberId);
      }
      catch (Exception ex)
      {
        view.PresentErrorMessage(ex.Message);
      }

    }

    /// <summary>
    /// Reads all the members from the member file and presents them to the view.
    /// </summary>
    public void ShowMemberList()
    {
      UserInterface view = new UserInterface();

      try
      {
        List<Member> members = FileHandler.Show();

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

    /// <summary>
    /// Finds a specific member and presents his information.
    /// </summary>
    public void SpecificMemberInfo()
    {
      UserInterface view = new UserInterface();

      try
      {
        List<Member> members = FileHandler.Show();

        view.PresentMemberInformation();
        string memberId = view.CollectData();

        Member member = members.SingleOrDefault(m => m.ID == memberId);
        System.Console.WriteLine(member.ToString("v"));
      }
      catch (Exception ex)
      {
        view.PresentErrorMessage(ex.Message);
      }
    }
  }
}
