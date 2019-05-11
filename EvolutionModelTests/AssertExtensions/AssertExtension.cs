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
      subscriptor(EventTester);
      try {
        action();
      } catch (EventTriggeredException) {
        return;
      }

      Assert.Fail(message);
    }

    /// <summary>
    /// Tests whether the specified event triggers during the action.
    /// </summary>
    /// <typeparam name="TEventArgs">EventArgs type used.</typeparam>
    /// <param name="subscriptor">Method used to subscribe an eventhandler.</param>
    /// <param name="action">Action that triggers the event.</param>
    public static void TriggersEvent<TEventArgs>(Action<EventHandler<TEventArgs>> subscriptor, Action action) where TEventArgs : EventArgs {
      TriggersEvent(subscriptor, action, "Action did not trigger the event");
    }

    /// <summary>
    /// Tests whether the specified event triggers during the action.
    /// </summary>
    /// <typeparam name="TEventArgs">EventArgs type used.</typeparam>
    /// <param name="subscriptor">Method used to subscribe an eventhandler.</param>
    /// <param name="action">Action that triggers the event.</param>
    /// <param name="message">Message to display on failure.</param>
    public static void TriggersEvent<TEventArgs>(Action<EventHandler<TEventArgs>> subscriptor, Action action, string message) where TEventArgs : EventArgs {
      subscriptor(EventTester);
      try {
        action();
      }
      catch (EventTriggeredException) {
        return;
      }

      Assert.Fail(message);
    }

    /// <summary>
    /// Tests whether the specified event does not trigger during the action.
    /// </summary>
    /// <param name="subscriptor">Method used to subscribe an eventhandler.</param>
    /// <param name="action">Action that should not trigger the event.</param>
    public static void DoesNotTriggerEvent(Action<EventHandler> subscriptor, Action action) {
      DoesNotTriggerEvent(subscriptor, action, "Action did trigger event");
    }


    /// <summary>
    /// Tests whether the specified event does not trigger during the action.
    /// </summary>
    /// <param name="subscriptor">Method used to subscribe an eventhandler.</param>
    /// <param name="action">Action that should not trigger the event.</param>
    /// <param name="message">Message to display on failure.</param>
    public static void DoesNotTriggerEvent(Action<EventHandler> subscriptor, Action action, string message) {
      subscriptor(EventTester);

      try {
        action();
      } catch (EventTriggeredException) {
        Assert.Fail(message);
      }
    }


    /// <summary>
    /// Tests whether the specified event does not trigger during the action.
    /// </summary>
    /// <typeparam name="TEventArgs">EventArgs type used.</typeparam>
    /// <param name="subscriptor">Method used to subscribe an eventhandler.</param>
    /// <param name="action">Action that should not trigger the event.</param>
    public static void DoesNotTriggerEvent<TEventArgs>(Action<EventHandler<TEventArgs>> subscriptor, Action action) where TEventArgs : EventArgs {
      DoesNotTriggerEvent(subscriptor, action, "Action did trigger event");
    }


    /// <summary>
    /// Tests whether the specified event does not trigger during the action.
    /// </summary>
    /// <typeparam name="TEventArgs">EventArgs type used.</typeparam>
    /// <param name="subscriptor">Method used to subscribe an eventhandler.</param>
    /// <param name="action">Action that should not trigger the event.</param>
    /// <param name="message">Message to display on failure.</param>
    public static void DoesNotTriggerEvent<TEventArgs>(Action<EventHandler<TEventArgs>> subscriptor, Action action, string message) where TEventArgs : EventArgs {
      subscriptor(EventTester);

      try {
        action();
      } catch (EventTriggeredException) {
        Assert.Fail(message);
      }
    }

    static void EventTester<TEventArgs>(object sender, TEventArgs args) where TEventArgs : EventArgs {
      throw new EventTriggeredException();
    }
  }
}
