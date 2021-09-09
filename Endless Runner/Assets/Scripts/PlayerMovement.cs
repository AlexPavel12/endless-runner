using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private CharacterController controller;

    [SerializeField] private Vector3 sideLeft, sideCenter, sideRight;
    private Vector3 direction, desiredPosition;

    [SerializeField] private float forwardSpeed, sideSpeed;
    private float prevX, deltaX;
    private float zUnits;

    [SerializeField] private int currentSide;

    private bool changeSides, sideMove, moveLeft, moveRight;

    private void Start()
    {
        currentSide = 1;
        zUnits = 1;
        direction = Vector3.forward * forwardSpeed;
        changeSides = true;
    }

    private void Update()
    {
        controller.Move(direction * Time.deltaTime);

        if (transform.position.z > zUnits)
        {
            GameManager.instance.Score++;
            zUnits += 1;
        }

        if (Input.GetMouseButtonDown(0))
        {
            prevX = Input.mousePosition.x;
        }

        if (Input.GetMouseButton(0) && changeSides && !moveLeft && !moveRight)
        {
            deltaX = Input.mousePosition.x - prevX;

            if (deltaX > 20f)
            {
                switch (currentSide)
                {
                    case 0:
                        MoveSides(sideCenter);
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
            else if (deltaX < -20f)
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
                        MoveSides(sideCenter);
                        currentSide = 1;
                        break;
                }
                changeSides = false;
            }
        }

        if (sideMove)
        {
            if ((moveRight && transform.position.x > desiredPosition.x) || (moveLeft && transform.position.x < desiredPosition.x))
            {
                direction = Vector3.forward * forwardSpeed;
                controller.enabled = false;
                transform.position = new Vector3(desiredPosition.x, transform.position.y, transform.position.z);
                controller.enabled = true;
                sideMove = false;
                moveLeft = false;
                moveRight = false;
            }
        }

        if (Input.GetMouseButtonUp(0))
        {
            changeSides = true;
        }
    }

    private void MoveSides(Vector3 side)
    {
        sideMove = true;
        desiredPosition = side;
        if (desiredPosition.x < transform.position.x)
        {
            moveLeft = true;
            direction = new Vector3(-1 * sideSpeed, 0, 1 * forwardSpeed);
        }
        else if(desiredPosition.x > transform.position.x)
        {
            moveRight = true;
            direction = new Vector3(1 * sideSpeed, 0, 1 * forwardSpeed);
        }
    }

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (hit.collider.CompareTag("Obstacle"))
        {
            GameManager.instance.Defeat();
        }
    }
}
