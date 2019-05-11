using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EvolutionModelTests.AssertExtensions {
  [TestClass]
  public class AssertTriggersEventTests {
    [TestMethod]
    public void AssertionFailsIfEventDoesNotTrigger() {
      var thing = new EventMocker();

      Assert.ThrowsException<AssertFailedException>(() =>
        AssertExtension.TriggersEvent(x => thing.SomeEvent += x, () => thing.SomethingUnrelated()));
    }

    [TestMethod]
    public void AssertionFailsIfAnExceptionIsThrown() {
      var thing = new EventMocker();
      Assert.ThrowsException<InvalidOperationException>(() =>
        AssertExtension.TriggersEvent(x => thing.SomeEvent += x, () => thing.ThrowException()));
    }

    [TestMethod]
    public void AssertionSucceedsIfEventIsTriggered() {
      var thing = new EventMocker();

      AssertExtension.TriggersEvent(x => thing.SomeEvent += x, () => thing.TriggerEvent());
    }

    [TestMethod]
    public void AssertionFailsIfCustomEventDoesNotTrigger() {
      var thing = new EventMocker();

      Assert.ThrowsException<AssertFailedException>(() =>
        AssertExtension.TriggersEvent<EventMocker.CustomEventArgs>(x => thing.SomeTypedEvent += x, () => thing.SomethingUnrelated()));
    }

    [TestMethod]
    public void AssertionFailsIfAnExceptionIsThrownCustom() {
      var thing = new EventMocker();
      Assert.ThrowsException<InvalidOperationException>(() =>
        AssertExtension.TriggersEvent<EventMocker.CustomEventArgs>(x => thing.SomeTypedEvent += x, () => thing.ThrowException()));
    }

    [TestMethod]
    public void AssertionSucceedsIfCustomEventIsTriggered() {
      var thing = new EventMocker();

      AssertExtension.TriggersEvent<EventMocker.CustomEventArgs>(x => thing.SomeTypedEvent += x, () => thing.TriggerTypedEvent());
    }
  }

  [TestClass]
  public class AssertDoesNotTriggerEventTests {
    [TestMethod]
    public void AssertionSucceeedsIfEventDoesNotTrigger() {
      var thing = new EventMocker();


      AssertExtension.DoesNotTriggerEvent(x => thing.SomeEvent += x, () => thing.SomethingUnrelated());
    }

    [TestMethod]
    public void AssertionFailsIfAnExceptionIsThrown() {
      var thing = new EventMocker();
      Assert.ThrowsException<InvalidOperationException>(() =>
        AssertExtension.DoesNotTriggerEvent(x => thing.SomeEvent += x, () => thing.ThrowException()));
    }

    [TestMethod]
    public void AssertionFailsIfEventIsTriggered() {
      var thing = new EventMocker();

      Assert.ThrowsException<AssertFailedException>(() =>
        AssertExtension.DoesNotTriggerEvent(x => thing.SomeEvent += x, () => thing.TriggerEvent()));
    }

    [TestMethod]
    public void AssertionSucceedsIfCustomEventDoesNotTrigger() {
      var thing = new EventMocker();


      AssertExtension.DoesNotTriggerEvent<EventMocker.CustomEventArgs>(x => thing.SomeTypedEvent += x, () => thing.SomethingUnrelated());
    }

    [TestMethod]
    public void AssertionFailsIfAnExceptionIsThrownCustom() {
      var thing = new EventMocker();
      Assert.ThrowsException<InvalidOperationException>(() =>
        AssertExtension.DoesNotTriggerEvent<EventMocker.CustomEventArgs>(x => thing.SomeTypedEvent += x, () => thing.ThrowException()));
    }

    [TestMethod]
    public void AssertionFailsIfCustomEventIsTriggered() {
      var thing = new EventMocker();

      Assert.ThrowsException<AssertFailedException>(() =>
        AssertExtension.DoesNotTriggerEvent<EventMocker.CustomEventArgs>(x => thing.SomeTypedEvent += x, () => thing.TriggerTypedEvent()));
    }
  }

  internal class EventMocker {
    public event EventHandler SomeEvent;
    public event EventHandler<CustomEventArgs> SomeTypedEvent;

    public void TriggerEvent() => SomeEvent.Invoke(this, new EventArgs());
    public void TriggerTypedEvent() => SomeTypedEvent.Invoke(this, new CustomEventArgs());

    public void ThrowException() => throw new InvalidOperationException();
    public int SomethingUnrelated() => 1 + 1;

    public class CustomEventArgs : EventArgs {
    }
  }
}
