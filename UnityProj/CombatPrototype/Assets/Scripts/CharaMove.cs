using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharaMove : MonoBehaviour
{

    [SerializeField]
    private float _speed = 15f;

    [SerializeField]
    private Animator _anim;

    [SerializeField]
    private Transform _visuals;

    [SerializeField]
    private CharacterController _charaController;

    [SerializeField]
    private Camera _cam;

    // Functions
    void Awake()
    {
    }

    void Update()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        Move(h, v);
    }

    private void Move(float horizontal, float vertical)
    {
        if (horizontal != 0f || vertical != 0f)
        {
            Vector3 targetDirection = new Vector3(horizontal, 0f, vertical);
            targetDirection = _cam.transform.TransformDirection(targetDirection);
            targetDirection.y = 0.0f;
            _charaController.Move(targetDirection * _speed * Time.deltaTime);
            _visuals.forward = targetDirection;
            _anim.SetFloat("Speed", 1f);
        }
        else
        {
            _anim.SetFloat("Speed", 0);
        }
    }
}
