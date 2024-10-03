using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D _playerRigid;
    private Vector2 _inputVec;
    private float _playerSpeed = 3f;
    private float _stamina = 100;
    public float stamina
    {
        get { return _stamina; }
        set
        {
            _stamina = value;
            if (_stamina > 100)
            {
                _stamina = 100;
                Debug.Log("���¹̳� 100 �̻� �Ұ�");
            }
            else if (_stamina <= 0)
            {
                // ����߸�
            }
        }
    }
    void Start()
    {
        _playerRigid = GetComponent<Rigidbody2D>();
        _inputVec = Vector2.zero;
    }

    void Update()
    {
        
    }

    private void FixedUpdate()
    {

        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        if (horizontal != 0)
        {
            _inputVec.x = horizontal;
            _inputVec.y = 0;  // ���� �̵� �� ���� �̵� ����
        }
        else if (vertical != 0)
        {
            _inputVec.x = 0;  // ���� �̵� �� ���� �̵� ����
            _inputVec.y = vertical;
        }
        else
        {
            _inputVec.x = 0;
            _inputVec.y = 0;
        }

        _playerRigid.velocity = _inputVec.normalized * _playerSpeed;
    }
}