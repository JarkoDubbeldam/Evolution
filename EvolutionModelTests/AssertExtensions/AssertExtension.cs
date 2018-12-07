using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EvolutionModelTests.AssertExtensions {
  static class AssertExtension {
    public static void TriggersEvent(Action<EventHandler> subscriptor, Action action) {
      TriggersEvent(subscriptor, action, "Action did not trigger the event.");
    }

    public static void TriggersEvent(Action<EventHandler> subscriptor, Action action, string message) {
      void EventTester(object sender, EventArgs args) {
        throw new EventTriggeredException();
      }

      subscriptor(EventTester);
      try {
        action();
      } catch (EventTriggeredException) {
        return;
      }

      Assert.Fail("Event did not trigger on action.");
    }

    public static void TriggersEvent<TEventArgs>(Action<EventHandler<TEventArgs>> subscriptor, Action action) {
      TriggersEvent(subscriptor, action, "Action did not trigger the event");
    }

    public static void TriggersEvent<TEventArgs>(Action<EventHandler<TEventArgs>> subscriptor, Action action, string message) {
      void EventTester(object sender, TEventArgs args) {
        throw new EventTriggeredException();
      }

      subscriptor(EventTester);
      try {
        action();
      }
      catch (EventTriggeredException) {
        return;
      }

      Assert.Fail("Event did not trigger on action.");
    }
  }
}
