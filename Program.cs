using System;
using Controller;
using View;

namespace Workshop_2___Design
{
  class Program
  {
    static void Main(string[] args)
    {
      Secretary secretary = new Secretary();

      while (secretary.Run()) ;
    }
  }
}
