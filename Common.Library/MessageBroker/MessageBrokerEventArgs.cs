using System;

namespace Common.Classes
{
  /// <summary>
  /// Permet de passer des données quand un événement est émis
  /// depuis le MessageBroker
  /// </summary>
  public class MessageBrokerEventArgs : EventArgs
  {
    public MessageBrokerEventArgs() : base()
    {
    }

    public MessageBrokerEventArgs(string messageName, object payload) : base()
    {
      MessageName = messageName;
      MessagePayload = payload;
    }

    public string MessageName { get; set; }

    public object MessagePayload { get; set; }

  }
}
