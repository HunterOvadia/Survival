using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public delegate void OnSystemMessageReceivedDelegate(string message);
    public static OnSystemMessageReceivedDelegate OnSystemMessageReceived;

    public static void SendSystemMessage(string message)
    {
        OnSystemMessageReceived?.Invoke(message);
    }
}
