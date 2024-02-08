using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    // Start is called before the first frame update
    Controls playerControls;
    public Vector2 Movement;
    [SerializeField]public bool canJump;
    public static InputManager instance;

    void Start()
    {
        playerControls.Enable();
    }
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(instance);
        }
    }
    private void OnEnable()
    {
        if (playerControls == null) {
            playerControls = new Controls();
            playerControls.Game.Screen.performed += i => Movement = i.ReadValue<Vector2>();
            playerControls.Game.Screen.canceled += i => Movement = Vector2.zero;
            playerControls.Game.Jump.performed += i => canJump = true;
            playerControls.Game.Jump.canceled += i => canJump = false;

        }
        
    }
    // Update is called once per frame
    void Update()
    {
        

    }

}
