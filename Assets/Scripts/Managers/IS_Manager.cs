using UnityEngine;

public class IS_Manager : SingletonClass<IS_Manager>
{
    public InputSystem_Actions inputs;
    public Vector2 mouseDelta;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        inputs = new InputSystem_Actions();
        inputs.Enable();
    }

    void Update()
    {
        mouseDelta = inputs.Player.Look.ReadValue<Vector2>();
    }
}
