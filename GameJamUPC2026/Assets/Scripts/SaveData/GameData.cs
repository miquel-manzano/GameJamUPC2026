using UnityEngine;


[System.Serializable]
public class GameData 
{
    public bool level1;
    public bool level2;
    public bool level3;
    public Skills skills;
}

public class Skills
{
    public bool dash;
    public bool shield;
    public bool rangeAttack;
    public bool doubleJump;
}