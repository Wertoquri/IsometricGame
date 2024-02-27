using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationControler : MonoBehaviour
{
    public static readonly string[] staticDirection =
        {
        "IdleW","IdleWD","IdleD","IdleDS","IdleS","IdleSA", "IdleA","IdleAW","IdleW"
    };
    public static readonly string[] runDirection =
      {
        "RunW","RunWD","RunD","RunDS","RunS","RunSA", "RunA","RunAW","RunW"
    };
    
    Animator anim;
    
    int lastDirection;
    
    
    void Start() 
    {
        anim = GetComponent<Animator>();
    
    }

    public void SetDirection(Vector2 direction)
    {
        string[] directionArray = null;

        if (direction.magnitude < 0.01) {
            directionArray = staticDirection;

        }
        else
        {
            directionArray = runDirection;
            lastDirection = DirectionToIndex(direction);
        }
        anim.Play(directionArray[lastDirection]);
    }
    private void DirectionToIndex(Vector2 dir)
    {
        Vector2 nordir = DirectionToINdex().normalized;
        float step = 45;
        float offstep = 22.5f;
        float angel = Vector2.SignedAngle(Vector2.up, nordir);
        angel += offstep;
        if(angel < 0)
        {
            angel += 360;
        }
        float stepCount = angel / step;
        return Mathf.FloorToInt(stepCount);
    }

}
