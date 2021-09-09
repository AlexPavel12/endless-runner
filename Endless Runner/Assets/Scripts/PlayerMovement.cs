using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private CharacterController controller;

    [SerializeField] private Vector3 sideLeft, sideCenter, sideRight;
    private Vector3 direction;

    [SerializeField] private float moveSpeed;
    private float prevX, deltaX;

    [SerializeField] private int currentSide;

    private bool changeSides;

    private void Start()
    {
        currentSide = 1;
        direction = Vector3.forward;
        changeSides = true;
    }

    private void Update()
    {
        controller.Move(moveSpeed * Time.deltaTime * direction);

        if (Input.GetMouseButtonDown(0))
        {
            prevX = Input.mousePosition.x;
        }

        if (Input.GetMouseButton(0) && changeSides)
        {
            deltaX = Input.mousePosition.x - prevX;

            if (deltaX > 0.1f)
            {
                switch (currentSide)
                {
                    case 0:
                        MoveSides(sideRight);
                        currentSide = 1;
                        break;
                    case 1:
                        MoveSides(sideRight);
                        currentSide = 2;
                        break;
                    case 2:
                        return;
                }
                changeSides = false;
            }
            else if (deltaX < -0.1f)
            {
                switch (currentSide)
                {
                    case 0:
                        return;
                    case 1:
                        MoveSides(sideLeft);
                        currentSide = 0;
                        break;
                    case 2:
                        MoveSides(sideLeft);
                        currentSide = 1;
                        break;
                }
                changeSides = false;
            }
        }

        if (Input.GetMouseButtonUp(0))
        {
            changeSides = true;
        }
    }

    private void MoveSides(Vector3 side)
    {
        controller.enabled = false;
        transform.position += side;
        controller.enabled = true;
    }

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (hit.collider.CompareTag("Obstacle"))
        {
            GameManager.instance.Defeat();
        }
    }
}
