using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwipeDetection : MonoBehaviour
{

    [SerializeField]
    private float minimumDistance = 0.2f;
    [SerializeField]
    private float Maximumtime = 1f;

    [SerializeField,Range(0,1f)]
    private float DirecionThreshold=0.9f;

    private InputManager inputManager;

   

    // Start is called before the first frame update

    private Vector2 startposition;
    private float startTime;    

    private Vector2 EndPosition;
    private float endTime;    
    private void Awake()
    {
        inputManager = InputManager.Instance;
    }
    private void OnEnable()
    {
        inputManager.OnStartTouchEvent += Swipestarted;
        inputManager.OnEndTouchEvent += swipeEnded;

    }

  

    private void OnDisable()
    {
        inputManager.OnStartTouchEvent -= Swipestarted;
        inputManager.OnEndTouchEvent -= swipeEnded;

    }

    private void swipeEnded(Vector2 endpos, float endtime)
    {
        EndPosition = endpos;
        endTime = endtime;

        DetectSwipe();
    }

    private void Swipestarted(Vector2 startpos, float time)
    {
        startposition = startpos;
        startTime = time;
    }
    private void DetectSwipe()
    {
        if(Vector3.Distance(startposition, EndPosition) >=minimumDistance&& endTime-startTime<=Maximumtime) 
        {
            Debug.DrawLine(startposition, EndPosition,Color.red,5f);

            Vector3 direciton = EndPosition - startposition;
            Vector2 direction2d=new Vector2(direciton.x,direciton.y).normalized;
            SwipeDireciton(direction2d);
            startposition = Vector3.zero;
            EndPosition = Vector3.zero;
        }

    }

    private void SwipeDireciton(Vector2 direction)
    {

        if(Vector2.Dot(Vector2.up,direction)>DirecionThreshold)
        {


            Player.instacne.PlayerState = Player.InputPhase.UP;
        } 
        else if(Vector2.Dot(Vector2.down,direction)>DirecionThreshold)
        {
            Debug.Log("SWIPE down");
            Player.instacne.PlayerState = Player.InputPhase.DOWN;
        } 
       else if(Vector2.Dot(Vector2.left,direction)>DirecionThreshold)
        {
            Debug.Log("SWIPE LEft");
          Player.instacne.PlayerState = Player.InputPhase.LEFT;
        } 
       else if(Vector2.Dot(Vector2.right,direction)>DirecionThreshold)
        {
            Debug.Log("SWIPE Right");
            Player.instacne.PlayerState = Player.InputPhase.RIGHT;

        }
    }

}
