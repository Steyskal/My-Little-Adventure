using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float MovementSpeed = 5.0f;
    public float AllowedDestinationOffset = 0.25f; // radius sphere

    public Inventory PlayerInventory;

    [Header("Read-only")]
    [SerializeField] private Vector2 _destination = Vector2.zero;
    [SerializeField] private bool _shouldMove = false;

    private Animator _animator;
    private Rigidbody2D _rigidbody2D;
    private AudioSource _audioSource;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _audioSource = GetComponent<AudioSource>();
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Mouse0))
        {
            _shouldMove = true;
            _destination = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            _animator.SetBool("IsRunning", _shouldMove);
        }
    }

    private void FixedUpdate()
    {
        if (!_shouldMove)
            return;

        float distance = Vector2.Distance(_rigidbody2D.position, _destination);

        if (distance > AllowedDestinationOffset)
        {
            Vector2 movementDirection = _destination - _rigidbody2D.position;
            movementDirection.Normalize();

            _animator.SetFloat("LookX", movementDirection.x);
            _animator.SetFloat("LookY", movementDirection.y);

            //transform.position += (Vector3)movementDirection * MovementSpeed * Time.deltaTime;
            _rigidbody2D.MovePosition(_rigidbody2D.position + movementDirection * MovementSpeed * Time.fixedDeltaTime); // fixedDeltaTime = 0.02s
        }
        else
        {
            _shouldMove = false;
            _animator.SetBool("IsRunning", _shouldMove);
        }
    }

    private void PlayAudioClip(AudioClip audioClip)
    {
        _audioSource.PlayOneShot(audioClip);
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawLine(transform.position, _destination); // nacratati krug s draw line metodom
        Gizmos.DrawWireSphere(_destination, AllowedDestinationOffset);
    }
}
