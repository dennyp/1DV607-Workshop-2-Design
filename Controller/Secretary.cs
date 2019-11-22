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
    private FileHandler fileHandler = new FileHandler();
    private MemberView memberView = new MemberView();
    private BoatView boatView = new BoatView();


    public bool Run()
    {
      try
      {
        memberView.PresentMenu();
        MenuChoice choice = memberView.SelectChoice();

        switch (choice)
        {
          case MenuChoice.RegisterMember:
            RegisterMember();
            return true;
          case MenuChoice.DeleteMember:
            DeleteMember();
            return true;
          case MenuChoice.ShowMemberList:
            ShowMemberList();
            return true;
          case MenuChoice.SpecificMemberInfo:
            SpecificMemberInfo();
            return true;
          case MenuChoice.ChangeMemberInfo:
            ChangeMemberInfo();
            return true;
          case MenuChoice.RegisterBoat:
            RegisterBoat();
            return true;
          case MenuChoice.DeleteBoat:
            DeleteBoat();
            return true;
          case MenuChoice.ChangeBoatInfo:
            ChangeBoatInfo();
            return true;
          case MenuChoice.Quit:
          default:
            return false;
        }
      }
      catch (Exception ex)
      {
        memberView.PresentErrorMessage(ex.Message);
        return true;
      }
    }

    /// <summary>
    /// Changes the information of a member.
    /// </summary>
    public void ChangeMemberInfo()
    {
      try
      {
        Member member = memberView.UpdateMemberUI();

        fileHandler.ChangeMemberInformation(member);
      }
      catch (Exception ex)
      {
        memberView.PresentErrorMessage(ex.Message);
      }
    }

    /// <summary>
    /// Deletes a member from the member file.
    /// </summary>
    public void DeleteMember()
    {
      try
      {
        Member member = memberView.SelectMemberUI(fileHandler);

        fileHandler.RemoveMemberFromFile(member);
      }
      catch (Exception ex)
      {
        memberView.PresentErrorMessage(ex.Message);
      }

    }

    /// <summary>
    /// Register a member.
    /// </summary>
    public void RegisterMember()
    {
      try
      {
        Member member = memberView.RegisterMemberUI();

        fileHandler.SaveMemberToFile(member);
      }
      catch (Exception ex)
      {
        memberView.PresentErrorMessage(ex.Message);
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

        memberView.ShowMemberListUI(members);
      }
      catch (Exception ex)
      {
        memberView.PresentErrorMessage(ex.Message);
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

        memberView.ShowMemberUI(members);
      }
      catch (Exception ex)
      {
        memberView.PresentErrorMessage(ex.Message);
      }
    }

    /// <summary>
    /// Change the information of a boat.
    /// </summary>
    public void ChangeBoatInfo()
    {
      try
      {
        Member member = memberView.SelectMemberUI(fileHandler);
        Boat boat = boatView.SelectBoatUI(member.Boats);

        if (boat != null)
        {
          Boat updatedBoat = boatView.EnterBoatUI();

          fileHandler.UpdateBoat(member, boat, updatedBoat);
        }
        else
        {
          memberView.PresentErrorMessage("No boats registered to this member.");
        }
      }
      catch (Exception ex)
      {
        memberView.PresentErrorMessage(ex.Message);
      }
    }

    /// <summary>
    /// Delete a boat.
    /// </summary>
    public void DeleteBoat()
    {
      try
      {
        Member member = memberView.SelectMemberUI(fileHandler);
        List<Boat> boats = member.Boats;

        Boat boat = boatView.SelectBoatUI(boats);

        if (boat != null && member != null)
        {
          fileHandler.DeleteBoat(member, boat);
        }
        else if (boat == null)
        {
          memberView.PresentErrorMessage("No boats registered to this member.");
        }
      }
      catch (Exception ex)
      {
        memberView.PresentErrorMessage(ex.Message);
      }
    }

    /// <summary>
    /// Registers a boat to a member.
    /// </summary>
    public void RegisterBoat()
    {
      try
      {
        Member member = memberView.SelectMemberUI(fileHandler);
        Boat boat = boatView.EnterBoatUI();

        fileHandler.RegisterBoat(member, boat);
      }
      catch (Exception ex)
      {
        memberView.PresentErrorMessage(ex.Message);
      }
    }
  }
}
