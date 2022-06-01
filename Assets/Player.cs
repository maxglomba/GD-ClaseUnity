using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private CharacterController _characterController;
    public float _moveSpeed = 50f;
    public float _jumpForce = 100f;
    public bool _jumping = false;

    // Start is called before the first frame update
    void Start()
    {
        _characterController = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 moveDir = transform.forward * Input.GetAxis("Vertical") + transform.right * Input.GetAxis("Horizontal");

        _characterController.SimpleMove(moveDir * _moveSpeed * Time.deltaTime);

        if(Input.GetKeyDown(KeyCode.LeftShift))
        {
            _moveSpeed *= 3;
        }
        else if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            _moveSpeed /= 3;
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (!_jumping)
            {
                Physics.gravity = new Vector3(0,0,0);
                _jumping = true;
                StartCoroutine(JumpRoutine());
            }
        }
    }

    IEnumerator JumpRoutine()
    {
        _characterController.SimpleMove(new Vector3(_characterController.velocity.x, _characterController.velocity.y * _jumpForce, _characterController.velocity.z ));
        yield return new WaitForSeconds(1f);
        Physics.gravity = new Vector3(0, -1, 0);
        _jumping = false;

    }
}
