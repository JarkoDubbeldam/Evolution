using System;
using System.Runtime.Serialization;

namespace EvolutionModelTests.AssertExtensions {
  [Serializable]
  internal class EventTriggeredException : Exception {
    public EventTriggeredException() {
    }

    public EventTriggeredException(string message) : base(message) {
    }

    public EventTriggeredException(string message, Exception innerException) : base(message, innerException) {
    }

    protected EventTriggeredException(SerializationInfo info, StreamingContext context) : base(info, context) {
    }
  }
}