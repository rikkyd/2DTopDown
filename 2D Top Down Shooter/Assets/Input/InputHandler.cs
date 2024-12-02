using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;


[CreateAssetMenu(fileName = "InputHandler", menuName = "Input Handler")]
public class InputHandler : ScriptableObject, CustomInput.IGameplayActions
{
    public UnityAction<Vector2> OnSetDirectionAction;

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
        input.Gameplay.Disable();
    }

    public void OnSetDirection(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Performed || context.phase == InputActionPhase.Canceled)
        {
            OnSetDirectionAction?.Invoke(context.ReadValue<Vector2>());
        }
    }
}