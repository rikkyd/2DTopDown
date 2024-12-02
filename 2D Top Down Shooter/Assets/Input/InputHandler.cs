using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


[CreateAssetMenu(fileName = "Input Handler", menuName = "Input Handler")]
public class InputHandler : ScriptableObject, CustomInput.IGameplayActions
{
    private CustomInput input;

    private void OnEnable()
    {
        if (input == null)
        {
            input = new CustomInput();
        }

        input.Gameplay.SetCallbacks(this);
        input.Gameplay.Enable();
    }

    private void OnDisable()
    {
        // Cleanup code to be executed when the component is disabled
    }

    public void OnSetDirection(InputAction.CallbackContext context)
    {
        // Implement the desired behavior for handling the "Set Direction" input action
        Debug.Log("set direction");
    }
}