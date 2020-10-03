using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController : MonoBehaviour
{
    Rigidbody2D _rb2D;
    SpriteRenderer _renderer;

    [SerializeField] PlayerData _playerData;
    [SerializeField] SpriteRenderer _orbSlot;
    [SerializeField] float _speed;
    [SerializeField] LayerMask _orbLayer;

    Vector2 _direction;

    public OrbData CurrentOrb { get => _playerData.currentOrb; set => _playerData.currentOrb = value; }

    // Start is called before the first frame update
    void Start()
    {
        _rb2D = GetComponent<Rigidbody2D>();
        _renderer = GetComponent<SpriteRenderer>();
        UpdateOrbSprite();
    }

    // Update is called once per frame
    void Update()
    {
        UpdateDirection();
        Move();
        Interact();
    }

    void Interact()
    {
        if(Input.GetButtonDown("Button1"))
        {
            Vector2 side;
            if (_renderer.flipX)
                side = Vector2.right;
            else
                side = Vector2.left;

            Vector2 start = _rb2D.position + side * 0.5f;
            Vector2 end = start + side * 0.5f;

            //Debug.DrawLine(start, end, Color.green);

            RaycastHit2D hit = Physics2D.Linecast(start, end, _orbLayer);
            if (hit)
            {
                CurrentOrb = hit.transform.GetComponent<OrbComponent>().SwapOrbs(CurrentOrb);
                UpdateOrbSprite();
            }
        }
    }
    
    void UpdateDirection()
    {
        _direction.x = Input.GetAxis("Horizontal");
        _direction.y = Input.GetAxis("Vertical");

        if (_direction.x > 0)
        {
            _renderer.flipX = true;
        }
        else if(_direction.x < 0)
        {
            _renderer.flipX = false;
        }
    }

    void UpdateOrbSprite()
    {
        _orbSlot.color = CurrentOrb.color;
    }

    void Move()
    {
        Vector2 target = _rb2D.position + _direction;
        _rb2D.MovePosition(Vector2.MoveTowards(_rb2D.position, target, _speed*Time.deltaTime));
    }
}
