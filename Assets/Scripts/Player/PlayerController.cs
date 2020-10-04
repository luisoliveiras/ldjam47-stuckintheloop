using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController : MonoBehaviour
{
    [Header("Player")]
    [SerializeField] PlayerData _playerData;
    [SerializeField] float _speed;
    [Header("Orb Pickup")]
    [SerializeField] SpriteRenderer _orbSlot;
    [SerializeField] LayerMask _orbLayer;
    [SerializeField] float _orbPickupRadius;
    [Header("Other")]
    [SerializeField] SceneChanger _sceneChanger;

    Rigidbody2D _rb2D;
    SpriteRenderer _renderer;
    Vector2 _direction;

    public OrbData CurrentOrb { get => _playerData.currentOrb; set => _playerData.currentOrb = value; }

    // Start is called before the first frame update
    void Start()
    {
        _rb2D = GetComponent<Rigidbody2D>();
        _renderer = GetComponent<SpriteRenderer>();
        UpdateOrbSprite();
    }

    private void FixedUpdate()
    {
        Move();
    }

    // Update is called once per frame
    void Update()
    {
        UpdateDirection();
        Interact();
        Restart();
    }

    void Restart()
    {
        if (Input.GetButtonDown("Button2"))
        {
            _sceneChanger.MoveToGame();
        }
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
            Collider2D hit = Physics2D.OverlapCircle(_rb2D.position, _orbPickupRadius, _orbLayer);
            if (hit)
            {
                CurrentOrb = hit.transform.GetComponent<TriggerComponent>().SwapOrbs(CurrentOrb);
                Debug.Log(CurrentOrb);
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
        _rb2D.velocity = _direction * _speed;
    }
}
