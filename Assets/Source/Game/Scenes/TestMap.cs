using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TestMap : SceneScript {
    bool done = false;
    //Phase: Game
    void OnStart_Game() {}

    //Phase: RoomExit
    void OnStart_RoomExit()
    {
        Place room = FindPlace("Room");
        room.Hidden(true);
        GoPhase("Game");
    }
}
