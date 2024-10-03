using UnityEngine;

public class PlayerAction : MonoBehaviour
{
    private float _speed = 5;
    private float _horizontal;
    private float _vertical;
    private bool _isHorizonMove;

    private float _raycastDistance = 1.5f;
    private Vector2 _rayDirection;
    public RaycastHit2D hit;
    public Customer hitCustomer;
    
    private Rigidbody2D _rigid;
    private Animator _anim;

    void Awake()
    {
        _rigid = GetComponent<Rigidbody2D>();
        _anim = GetComponent<Animator>();
    }

    void Update()
    {
        RotateRay();
        GenerateRay();

        // 이동 값
        _horizontal = Input.GetAxisRaw("Horizontal");
        _vertical = Input.GetAxisRaw("Vertical");

        // 위아래 체크
        bool hDown = Input.GetButtonDown("Horizontal");
        bool vDown = Input.GetButtonDown("Vertical");
        bool hUp = Input.GetButtonUp("Horizontal");
        bool vUp = Input.GetButtonUp("Vertical");

        // 좌우 체크
        if (hDown)
            _isHorizonMove = true;
        else if (vDown)
            _isHorizonMove = false;
        else if (hUp || vUp)
            _isHorizonMove = _horizontal != 0;

        // 애니메이션
        if (_anim.GetInteger("hAxisRaw") != _horizontal)
        {
            _anim.SetBool("isChange", true);
            _anim.SetInteger("hAxisRaw", (int)_horizontal);
        }
        else if (_anim.GetInteger("vAxisRaw") != _vertical)
        {
            _anim.SetBool("isChange", true);
            _anim.SetInteger("vAxisRaw", (int)_vertical);
        }
        else
            _anim.SetBool("isChange", false);
    }

    private void FixedUpdate()
    {
        // 이동
        Vector2 moveVec = _isHorizonMove ? new Vector2(_horizontal, 0) : new Vector2(0, _vertical);
        _rigid.velocity = moveVec * _speed;
    }

    // Ray 쏘기
    public void GenerateRay()
    {
        // Ray를 현재 방향으로 쏨
        hit = Physics2D.Raycast(transform.position,
                                _rayDirection,
                                _raycastDistance,
                                LayerMask.GetMask("Customer"));

        Debug.DrawLine(transform.position,
                       (Vector2)transform.position + _rayDirection * _raycastDistance,
                       Color.green);
    }

    // Ray 방향 회전
    public void RotateRay()
    {

        Vector2 velocity = GetComponent<Rigidbody2D>().velocity;

        if (_horizontal > 0f)
        {
            _rayDirection = Vector2.right;
        }
        else if (_horizontal < 0f)
        {
            _rayDirection = Vector2.left;
        }
        else if (_vertical > 0f)
        {
            _rayDirection = Vector2.up;
        }
        else if (_vertical < 0f)
        {
            _rayDirection = Vector2.down;
        }
    }
}
