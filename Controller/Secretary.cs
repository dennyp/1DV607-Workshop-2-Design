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
    private UserInterface view;

    public Secretary()
    {
      fileHandler = new FileHandler();
      view = new UserInterface();
    }

    /// <summary>
    /// Change the information of a boat.
    /// </summary>
    public void ChangeBoatInfo()
    {
      try
      {
        // TODO : Refactor - duplicate code.
        view.PresentBoatUI();
        string boatId = view.CollectData();

        view.PresentBoatTypeUI();
        string type = view.CollectData().ToLower();

        view.PresentBoatLengthUI();
        string length = view.CollectData();

        fileHandler.UpdateBoat(boatId, type, length);
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
      try
      {
        view.PresentMemberInfoUI();

        view.PresentMemberPersonalIdUI();
        string memberId = view.CollectData();

        view.PresentMemberNameUI();
        string name = view.CollectData();

        view.PresentMemberPersonalIdUI();
        string ssn = view.CollectData();

        fileHandler.ChangeMemberInformation(memberId, name, ssn);
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
      try
      {
        view.PresentBoatCreationUI();

        view.PresentMemberUI();
        string memberId = view.CollectData();

        view.PresentBoatTypeUI();
        string type = view.CollectData().ToLower();

        view.PresentBoatLengthUI();
        string length = view.CollectData();

        fileHandler.RegisterBoat(memberId, type, length);
      }
      catch (Exception ex)
      {
        view.PresentErrorMessage(ex.Message);
      }
    }

    /// <summary>
    /// Registers a member.
    /// </summary>
    public void RegisterMember()
    {
      try
      {
        view.PresentMemberCreationUI();

        view.PresentMemberNameUI();
        string name = view.CollectData();

        view.PresentMemberPersonalIdUI();
        string ssn = view.CollectData();

        fileHandler.RegisterMember(name, ssn);
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
      try
      {
        List<Member> members = fileHandler.GetMembers();

        view.PresentMemberListUI();
        string format = view.CollectData();

        foreach (var member in members)
        {
          view.PresentMemberString(member);
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
      try
      {
        List<Member> members = fileHandler.GetMembers();

        view.PresentMemberInformation();
        string memberId = view.CollectData();

        Member member = members.SingleOrDefault(m => m.ID == memberId);
        view.PresentVerboseMemberString(member);
      }
      catch (Exception ex)
      {
        view.PresentErrorMessage(ex.Message);
      }
    }
  }
}
