using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : ArmedCharacter
{
    public Gun PlayerGun;
    public override Vector3 LookPoint { get => WorldManager.WorldLookPoint; }



    private void Start()
    {
        CharacterGun = PlayerGun;
    }
}
