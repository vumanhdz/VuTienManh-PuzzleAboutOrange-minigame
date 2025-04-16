using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerCtrl : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private Transform Up, Down, Left, Right, Uup, Ddown, Lleft, Rright;
    [SerializeField] private float groundPoin, moveDistance, moveSpeed;
    [SerializeField] private LayerMask groundLayer, OjLayer;
    private Rigidbody2D rb;
    private int originalLayer;
    private Vector2 targetPosition, startTouchPos, endTouchPos;
    private bool isMoving = false, isL, isR, isU, isD, isMoveL, isMoveR, isMoveU, isMoveD, isOD, isOU, isOR, isOL, isWL, isWR, isWU, isWD, isOjD, isOjU, isOjL, isOjR;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        moveDistance = 1.7f;
        moveSpeed = 15f;
        targetPosition = transform.position;
        originalLayer = gameObject.layer;
    }

    private void Update()
    {
        CheckInput();
        if (isOjL && isOjR || isOjU && isOjD)
        {
            gameObject.layer = LayerMask.NameToLayer("Wall");
        }
        else
        {
            gameObject.layer = originalLayer;
        }
    }
    private void FixedUpdate()
    {
        CheckGround();
        PlayerMove();
    }
    public void PlayerMove()
    {
        if (rb.position == targetPosition)
        {
            isMoving = false;
        }

        if (!isMoving)
        {
            if (isMoveL && !isL && !(isOL && isWL))
            {
                StartMove(Vector2.left);
            }
            else if (isMoveR && !isR && !(isOR && isWR))
            {
                StartMove(Vector2.right);
            }
            else if (isMoveU && !isU && !(isOU && isWU))
            {
                StartMove(Vector2.up);
            }
            else if (isMoveD && !isD && !(isOD && isWD))
            {
                StartMove(Vector2.down);
            }
        }

        rb.MovePosition(Vector2.MoveTowards(rb.position, targetPosition, moveSpeed * Time.fixedDeltaTime));
    }
    void StartMove(Vector2 direction)
    {
        targetPosition += direction * moveDistance;
        isMoving = true;
    }
    private void CheckInput()
    {
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            startTouchPos = Input.GetTouch(0).position;
        }
        if(Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Ended)
        {
            endTouchPos = Input.GetTouch(0).position;

            if (endTouchPos.x > startTouchPos.x && (endTouchPos.x - startTouchPos.x) > 400)
            {
                isMoveR = true;
                isMoveL = false;
                isMoveU = false;
                isMoveD = false;
            }
            else if (endTouchPos.x < startTouchPos.x && (-endTouchPos.x + startTouchPos.x) > 400)
            {
                isMoveR = false;
                isMoveL = true;
                isMoveU = false;
                isMoveD = false;
            }
            else if (endTouchPos.y > startTouchPos.y && (endTouchPos.y - startTouchPos.y) > 400)
            {
                isMoveR = false;
                isMoveL = false;
                isMoveU = true;
                isMoveD = false;
            }
            else if (endTouchPos.y < startTouchPos.y && (-endTouchPos.y + startTouchPos.y) > 400)
            {
                isMoveR = false;
                isMoveL = false;
                isMoveU = false;
                isMoveD = true;
            }
        }
        Invoke(nameof(ResetMoveFlags), 0.5f);
    }
    private void ResetMoveFlags()
    {
        isMoveR = isMoveL = isMoveU = isMoveD = false;
    }
    private void CheckGround()
    {
        isD = Physics2D.Raycast(Down.position, transform.up, groundPoin, groundLayer);
        isU = Physics2D.Raycast(Up.position, transform.up, groundPoin, groundLayer);
        isL = Physics2D.Raycast(Left.position, transform.right, groundPoin, groundLayer);
        isR = Physics2D.Raycast(Right.position, transform.right, groundPoin, groundLayer);

        isOjD = Physics2D.Raycast(Down.position, transform.up, groundPoin, OjLayer);
        isOjU = Physics2D.Raycast(Up.position, transform.up, groundPoin, OjLayer);
        isOjL = Physics2D.Raycast(Left.position, transform.right, groundPoin, OjLayer);
        isOjR = Physics2D.Raycast(Right.position, transform.right, groundPoin, OjLayer);

        isOD = Physics2D.Raycast(Ddown.position, transform.up, groundPoin, OjLayer);
        isOU = Physics2D.Raycast(Uup.position, transform.up, groundPoin, OjLayer);
        isOL = Physics2D.Raycast(Lleft.position, transform.right, groundPoin, OjLayer);
        isOR = Physics2D.Raycast(Rright.position, transform.right, groundPoin, OjLayer);

        isWD = Physics2D.Raycast(Ddown.position, transform.up, groundPoin, groundLayer);
        isWU = Physics2D.Raycast(Uup.position, transform.up, groundPoin, groundLayer);
        isWL = Physics2D.Raycast(Lleft.position, transform.right, groundPoin, groundLayer);
        isWR = Physics2D.Raycast(Rright.position, transform.right, groundPoin, groundLayer);
    }
   
    private void OnDrawGizmos()
    {
        Gizmos.DrawLine(Down.position, new Vector3(Down.position.x, Down.position.y + groundPoin, Down.position.z));
        Gizmos.DrawLine(Up.position, new Vector3(Up.position.x, Up.position.y + groundPoin, Up.position.z));
        Gizmos.DrawLine(Left.position, new Vector3(Left.position.x + groundPoin, Left.position.y, Left.position.z));
        Gizmos.DrawLine(Right.position, new Vector3(Right.position.x + groundPoin, Right.position.y, Right.position.z));

        Gizmos.DrawLine(Ddown.position, new Vector3(Ddown.position.x, Ddown.position.y + groundPoin, Ddown.position.z));
        Gizmos.DrawLine(Uup.position, new Vector3(Uup.position.x, Uup.position.y + groundPoin, Uup.position.z));
        Gizmos.DrawLine(Lleft.position, new Vector3(Lleft.position.x + groundPoin, Lleft.position.y, Lleft.position.z));
        Gizmos.DrawLine(Rright.position, new Vector3(Rright.position.x + groundPoin, Rright.position.y, Rright.position.z));
    }

}
