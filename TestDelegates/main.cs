// Title: Building ASP.NET Server Controls
//
// Chapter: 5 - Event-based Programming
// File: main.cs
// Written by: Dale Michalk and Rob Cameron
//
// Copyright © 2003, Apress L.P.
using System;

namespace ControlsBook.Ch05
{
   delegate void SimpleMulticastDelegate(int i);

   public class DelegateImplementorClass
   {
      public void ClassMethod(int i)
      {
         Console.WriteLine("You passed in " + i.ToString() +" to the class method");
      }

      static public void StaticClassMethod(int j)
      {
         Console.WriteLine("You passed in "+ j.ToString() +" to the static class method");
      }

      public void YetAnotherClassMethod(int k)
      {
         Console.WriteLine("You passed in " + k.ToString() +" to yet another class method");
      }
   }

   class main
   {
      [STAThread]
      static void Main(string[] args)
      {
         DelegateImplementorClass ImpClass = new DelegateImplementorClass();

         SimpleMulticastDelegate d = new SimpleMulticastDelegate(ImpClass.ClassMethod);
         d(5);
         Console.WriteLine("");

         d += new SimpleMulticastDelegate(DelegateImplementorClass.StaticClassMethod);
         d(10);
         Console.WriteLine("");

         d += new SimpleMulticastDelegate(ImpClass.YetAnotherClassMethod);
         d(15);
         Console.Read();
      }
   }
}
