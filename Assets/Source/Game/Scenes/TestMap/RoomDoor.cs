using UnityEngine;
using System.Collections;

public class RoomDoor : Door
{
    new void OnOpen(){}

    new void OnClose()
    {
        Game.GetScene().GoPhase("RoomExit");
        
    }
}
