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
    /// Changes the information of a member.
    /// </summary>
    public void ChangeMemberInfo()
    {
      try
      {
        Member member = view.UpdateMemberUI();

        fileHandler.ChangeMemberInformation(member);
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
        Member member = view.GetMemberUI(fileHandler);

        fileHandler.RemoveMemberFromFile(member);
      }
      catch (Exception ex)
      {
        view.PresentErrorMessage(ex.Message);
      }

    }

    /// <summary>
    /// Register a member.
    /// </summary>
    public void RegisterMember()
    {
      try
      {
        Member member = view.RegisterMemberUI();

        fileHandler.SaveMemberToFile(member);
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

        view.ShowMemberListUI(members);
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

        view.ShowMemberUI(members);
      }
      catch (Exception ex)
      {
        view.PresentErrorMessage(ex.Message);
      }
    }

    /// <summary>
    /// Change the information of a boat.
    /// </summary>
    // public void ChangeBoatInfo()
    // {
    //   try
    //   {
    //     // TODO : Refactor - duplicate code.
    //     view.PresentBoatUI();
    //     string boatId = view.CollectData();

    //     view.PresentBoatTypeUI();
    //     string type = view.CollectData().ToLower();

    //     view.PresentBoatLengthUI();
    //     string length = view.CollectData();

    //     fileHandler.UpdateBoat(int.Parse(boatId), type, length);
    //   }
    //   catch (Exception ex)
    //   {
    //     view.PresentErrorMessage(ex.Message);
    //   }
    // }

    /// <summary>
    /// Delete a boat.
    /// </summary>
    public void DeleteBoat()
    {
      try
      {
        Member member = view.GetMemberUI(fileHandler);
        List<Boat> boats = member.Boats;

        Boat boat = view.DeleteBoatUI(boats);

        if (boat != null && member != null)
        {
          fileHandler.DeleteBoat(member, boat);
        }
        else if (boat == null)
        {
          view.PresentErrorMessage("Member has no boat.");
        }
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
        Member member = view.GetMemberUI(fileHandler);
        Boat boat = view.RegisterBoatUI();

        fileHandler.RegisterBoat(member, boat);
      }
      catch (Exception ex)
      {
        view.PresentErrorMessage(ex.Message);
      }
    }
  }
}
