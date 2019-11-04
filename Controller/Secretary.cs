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
    private FileHandler fileHandler;

    public Secretary()
    {
      fileHandler = new FileHandler();
    }

    /// <summary>
    /// Change the information of a boat.
    /// </summary>
    public void ChangeBoatInfo()
    {
      UserInterface view = new UserInterface();
      try
      {
        // TODO : Refactor - duplicate code.
        view.PresentBoatUI();
        string boatId = view.CollectData();

        view.PresentBoatTypeUI();
        string type = view.CollectData().ToLower();

        view.PresentBoatLengthUI();
        string length = view.CollectData();

        Member member = fileHandler.UpdateBoat(boatId, type, length);
        fileHandler.Delete(member.ID);
        fileHandler.Save(member);
      }
      catch (Exception ex)
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
        List<Member> members = fileHandler.GetMembers();

        view.PresentMemberInfoUI();
        view.PresentMemberPersonalIdUI();
        string memberId = view.CollectData();
        Member member = members.SingleOrDefault(m => m.ID == memberId);

        view.PresentMemberNameUI();
        string name = view.CollectData();

        view.PresentMemberPersonalIdUI();
        string ssn = view.CollectData();

        fileHandler.Delete(memberId);
        member.Name = name;
        member.SSN = ssn;
        fileHandler.Save(member);
      }
      catch (Exception ex)
      {
        view.PresentErrorMessage(ex.Message);
      }
    }

    /// <summary>
    /// Delete a boat.
    /// </summary>
    public void DeleteBoat()
    {
      UserInterface view = new UserInterface();

      try
      {
        view.PresentBoatUI();
        string boatId = view.CollectData();
        fileHandler.DeleteBoat(boatId);
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
        view.PresentMemberUI();
        string memberId = view.CollectData();

        fileHandler.Delete(memberId);
      }
      catch (Exception ex)
      {
        view.PresentErrorMessage(ex.Message);
      }

    }

    /// <summary>
    /// Registers a boat to a member.
    /// </summary>
    public void RegisterBoat()
    {
      UserInterface view = new UserInterface();

      try
      {
        view.PresentBoatCreationUI();

        view.PresentMemberUI();
        string memberId = view.CollectData();

        view.PresentBoatTypeUI();
        string type = view.CollectData().ToLower();

        view.PresentBoatLengthUI();
        string length = view.CollectData();

        Member member = fileHandler.RegisterBoat(memberId, type, length);
        fileHandler.Delete(member.ID);
        fileHandler.Save(member);
      }
      catch (Exception ex)
      {
        view.PresentErrorMessage(ex.Message);
      }
    }

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
        fileHandler.Save(member);
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
        List<Member> members = fileHandler.GetMembers();

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
        List<Member> members = fileHandler.GetMembers();

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
