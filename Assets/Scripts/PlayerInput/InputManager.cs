using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
[DefaultExecutionOrder(-1)]
public class InputManager : Singleton<InputManager>
{

    public delegate void StartTouch(Vector2 startpos, float time);
    public event StartTouch OnStartTouchEvent;
    
    public delegate void EndTouch(Vector2 startpos, float time);
    public event StartTouch OnEndTouchEvent;

    private PayerInputControl plaeyrcontorl;
    private Camera camrea;
    private void Awake()
    {
        plaeyrcontorl = new PayerInputControl();
        camrea = Camera.main;
    }
    private void OnEnable()
    {
        plaeyrcontorl.Enable();
    }
    private void OnDisable()
    {
        plaeyrcontorl.Disable();
    }
    void Start()
    {
        plaeyrcontorl.Touch.PrimaryContact.started += ct => startPrimaryTouch(ct);
        plaeyrcontorl.Touch.PrimaryContact.canceled += ct => EndTouchPrimary(ct);
       
    }

    private void EndTouchPrimary(InputAction.CallbackContext ct)
    {
    if(OnEndTouchEvent != null)
        {
            OnEndTouchEvent.Invoke(Utils.Screentoworld(camrea, plaeyrcontorl.Touch.PrimaryPositition.ReadValue<Vector2>()), (float)ct.time);
        }
    }


    public void startPrimaryTouch(InputAction.CallbackContext ct)
    {
        if(OnStartTouchEvent != null)
        {
            OnStartTouchEvent.Invoke(Utils.Screentoworld(camrea,plaeyrcontorl.Touch.PrimaryPositition.ReadValue<Vector2>()),(float)ct.startTime);
        }
    }
    //public Vector2 PrimaryPositon()
    //{
    //    return
    //}
 
}
