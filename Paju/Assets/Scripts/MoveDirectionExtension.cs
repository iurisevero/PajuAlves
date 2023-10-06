using UnityEngine;
using System.Collections;
using Unity.VisualScripting;

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

    public static bool InvertDirection(this MoveDirection moveDirection, MoveDirection compareDirection) {
        switch (moveDirection)
        {
            case MoveDirection.North:
                if(compareDirection == MoveDirection.South)
                    return true;
                else
                    return false;
            case MoveDirection.East:
                if(compareDirection == MoveDirection.West)
                    return true;
                else
                    return false;
            case MoveDirection.South:
                if(compareDirection == MoveDirection.North)
                    return true;
                else
                    return false;
            default:
                if(compareDirection == MoveDirection.East)
                    return true;
                else
                    return false;
        }
    }
}

