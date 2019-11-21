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
    /// Changes the information of a member.
    /// </summary>
    // public void ChangeMemberInfo()
    // {
    //   try
    //   {
    //     view.PresentMemberInfoUI();

    //     view.PresentMemberPersonalIdUI();
    //     string memberId = view.CollectData();

    //     view.PresentMemberNameUI();
    //     string name = view.CollectData();

    //     view.PresentMemberPersonalIdUI();
    //     string ssn = view.CollectData();

    //     Member member = new Member(name, ssn, int.Parse(memberId));
    //     fileHandler.ChangeMemberInformation(member);
    //   }
    //   catch (Exception ex)
    //   {
    //     view.PresentErrorMessage(ex.Message);
    //   }
    // }

    /// <summary>
    /// Delete a boat.
    /// </summary>
    // public void DeleteBoat()
    // {
    //   try
    //   {
    //     view.PresentBoatUI();
    //     string boatId = view.CollectData();

    //     fileHandler.DeleteBoat(int.Parse(boatId));
    //   }
    //   catch (Exception ex)
    //   {
    //     view.PresentErrorMessage(ex.Message);
    //   }
    // }

    /// <summary>
    /// Deletes a member from the member file.
    /// </summary>
    public void DeleteMember()
    {
      try
      {
        int memberId = view.DeleteMemberUI();

        fileHandler.RemoveMemberFromFile(memberId);
      }
      catch (Exception ex)
      {
        view.PresentErrorMessage(ex.Message);
      }

    }

    /// <summary>
    /// Registers a boat to a member.
    /// </summary>
    // public void RegisterBoat()
    // {
    //   try
    //   {
    //     view.PresentBoatCreationUI();

    //     view.PresentMemberUI();
    //     string memberId = view.CollectData();

    //     view.PresentBoatTypeUI();
    //     string type = view.CollectData().ToLower();

    //     view.PresentBoatLengthUI();
    //     string length = view.CollectData();

    //     BoatType boatType = (BoatType)Enum.Parse(typeof(BoatType), type);
    //     Boat boat = new Boat(boatType, double.Parse(length));

    //     fileHandler.RegisterBoat(int.Parse(memberId), boat);
    //   }
    //   catch (Exception ex)
    //   {
    //     view.PresentErrorMessage(ex.Message);
    //   }
    // }

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
  }
}
