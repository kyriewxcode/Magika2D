using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UserKeyListener
{

    private static UserKeyListener instance;

    public static bool canMove = true;

    [Header("鼠标事件")]
    public static bool getMouseButtonDown0;
    public static bool getMouseButtonDown1;
    public static bool getMouseButtonDown2;
    public static bool getMouseButtonHold0;
    public static bool getMouseButtonHold1;
    public static bool getMouseButtonHold2;
    public static bool getMouseButtonUp0;
    public static bool getMouseButtonUp1;
    public static bool getMouseButtonUp2;


    [Header("键盘事件")]
    public static float horizontalValue;//水平
    public static float horizontalValueRaw;
    public static float verticalValue;//垂直
    public static float verticalValueRaw;
    public static bool jumpButtonDown;//Space
    public static bool jumpButtonHold;
    public static bool jumpButtonUp;
    public static bool getKeyDownQ;//Q
    public static bool getKeyHoldQ;
    public static bool getKeyUpQ;
    public static bool getKeyDownE;//E
    public static bool getKeyHoldE;
    public static bool getKeyUpE;
    public static bool getKeyDownJ;//J
    public static bool getKeyHoldJ;
    public static bool getKeyUpJ;
    public static bool getKeyDownShift;//Shift
    public static bool getKeyHoldShift;
    public static bool getKeyUpShift;
    public static bool getKeyDownCtrl;//Ctrl
    public static bool getKeyHoldCtrl;
    public static bool getKeyUpCtrl;


    public static UserKeyListener GetInstance()
    {
        if (instance == null)
            instance = new UserKeyListener();
        return instance;
    }
    public void KeyListener()
    {
        RecoverBool();
        //Debug.Log(canMove);
        if (canMove)
        {
            verticalValue = Input.GetAxis("Vertical");
            verticalValueRaw = Input.GetAxisRaw("Vertical");
            horizontalValue = Input.GetAxis("Horizontal");
            horizontalValueRaw = Input.GetAxisRaw("Horizontal");
            if(Input.GetButtonDown("Jump") || Input.GetKeyDown(KeyCode.K))
            {
                jumpButtonDown = true;
            }
            if (Input.GetButton("Jump") || Input.GetKey(KeyCode.K))
            {
                jumpButtonHold = true;
            }
            if (Input.GetButtonUp("Jump") || Input.GetKeyUp(KeyCode.K))
            {
                jumpButtonUp = true;
            }
            if(Input.GetKeyDown(KeyCode.LeftControl))
            {
                getKeyDownCtrl = true;
            }
            if (Input.GetKey(KeyCode.LeftControl))
            {
                getKeyHoldCtrl = true;
            }
            if (Input.GetKeyUp(KeyCode.LeftControl))
            {
                getKeyUpCtrl = true;
            }
            if (Input.GetKeyDown(KeyCode.LeftShift))
            {
                getKeyDownShift = true;
            }
            if (Input.GetKey(KeyCode.LeftShift))
            {
                getKeyHoldShift = true;
            }
            if (Input.GetKeyUp(KeyCode.LeftShift))
            {
                getKeyUpShift = true;
            }
        }

        if (Input.GetMouseButtonDown(0))
        {
            getMouseButtonDown0 = true;
        }
        if (Input.GetMouseButtonDown(1))
        {
            getMouseButtonDown1 = true;
        }
        if (Input.GetMouseButtonDown(2))
        {
            getMouseButtonDown2 = true;
        }
        if (Input.GetMouseButton(0))
        {
            getMouseButtonHold0 = true;
        }
        if (Input.GetMouseButton(1))
        {
            getMouseButtonHold1 = true;
        }
        if (Input.GetMouseButton(2))
        {
            getMouseButtonHold2 = true;
        }
        if (Input.GetMouseButtonUp(0))
        {
            getMouseButtonUp0 = true;
        }
        if (Input.GetMouseButtonUp(1))
        {
            getMouseButtonUp1 = true;
        }
        if (Input.GetMouseButtonUp(2))
        {
            getMouseButtonUp2 = true;
        }
        if(Input.GetKeyDown(KeyCode.Q))
        {
            getKeyDownQ = true;
        }
        if (Input.GetKey(KeyCode.Q))
        {
            getKeyHoldQ = true;
        }
        if (Input.GetKeyUp(KeyCode.Q))
        {
            getKeyUpQ = true;
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            getKeyDownE = true;
        }
        if (Input.GetKey(KeyCode.E))
        {
            getKeyHoldE = true;
        }
        if (Input.GetKeyUp(KeyCode.E))
        {
            getKeyUpE = true;
        }
        if (Input.GetKeyDown(KeyCode.J))
        {
            getKeyDownJ = true;
        }
        if (Input.GetKey(KeyCode.J))
        {
            getKeyHoldJ = true;
        }
        if (Input.GetKeyUp(KeyCode.J))
        {
            getKeyUpJ = true;
        }
    }

    public void RecoverBool()
    {
        getMouseButtonDown0 = false;
        getMouseButtonDown1 = false;
        getMouseButtonDown2 = false;
        getMouseButtonHold0 = false;
        getMouseButtonHold1 = false;
        getMouseButtonHold2 = false;
        getMouseButtonUp0 = false;
        getMouseButtonUp1 = false;
        getMouseButtonUp2 = false;
        jumpButtonDown = false;
        jumpButtonHold = false;
        jumpButtonUp = false;
        getKeyDownQ = false;
        getKeyHoldQ = false;
        getKeyUpQ = false;
        getKeyDownE = false;
        getKeyHoldE = false;
        getKeyUpE = false;
        getKeyDownJ = false;
        getKeyHoldJ = false;
        getKeyUpJ = false;
        getKeyDownShift = false;
        getKeyHoldShift = false;
        getKeyUpShift = false;
        getKeyDownCtrl = false;
        getKeyHoldCtrl = false;
        getKeyUpCtrl = false;
    }
}
