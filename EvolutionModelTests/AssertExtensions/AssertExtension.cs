using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EvolutionModelTests.AssertExtensions {
  static class AssertExtension {
    /// <summary>
    /// Tests whether the specified event triggers during the action.
    /// </summary>
    /// <param name="subscriptor">Method used to subscribe an eventhandler.</param>
    /// <param name="action">Action that triggers the event.</param>
    public static void TriggersEvent(Action<EventHandler> subscriptor, Action action) {
      TriggersEvent(subscriptor, action, "Action did not trigger the event.");
    }

    /// <summary>
    /// Tests whether the specified event triggers during the action.
    /// </summary>
    /// <param name="subscriptor">Method used to subscribe an eventhandler.</param>
    /// <param name="action">Action that triggers the event.</param>
    /// <param name="message">Message to display on failure.</param>
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

    /// <summary>
    /// Tests whether the specified event triggers during the action.
    /// </summary>
    /// <typeparam name="TEventArgs">EventArgs type used.</typeparam>
    /// <param name="subscriptor">Method used to subscribe an eventhandler.</param>
    /// <param name="action">Action that triggers the event.</param>
    public static void TriggersEvent<TEventArgs>(Action<EventHandler<TEventArgs>> subscriptor, Action action) {
      TriggersEvent(subscriptor, action, "Action did not trigger the event");
    }

    /// <summary>
    /// Tests whether the specified event triggers during the action.
    /// </summary>
    /// <typeparam name="TEventArgs">EventArgs type used.</typeparam>
    /// <param name="subscriptor">Method used to subscribe an eventhandler.</param>
    /// <param name="action">Action that triggers the event.</param>
    /// <param name="message">Message to display on failure.</param>
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
