using UnityEngine;
using System.Collections;

public static class MoveDirectionExtensions
{
    public static float ToFloat(this MoveDirection moveDirection){
        switch (moveDirection)
        {
            case MoveDirection.North:
                return 270f;
            case MoveDirection.East:
                return 0f;
            case MoveDirection.South:
                return 90f;
            default:
                return 180f;
        }
    }
}

