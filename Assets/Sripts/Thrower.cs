using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Thrower : MonoBehaviour
{

    public float DistanceToTake = 3f;
    public float ThrowForce = 10f;

    public LayerMask LayerMask;

    private Camera _playerCamera;
    private bool _isSmthInHands = false;
    private Transform _transform;
    private Rigidbody _rigidbody;

    private void Start()
    {
        _playerCamera = FindObjectOfType<MouseLook>().GetComponent<Camera>();
    }

    void LateUpdate()
    {

        Ray ray = _playerCamera.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Input.GetMouseButtonDown(0) && Physics.Raycast(ray, DistanceToTake, LayerMask) && !_isSmthInHands)
        {
            Physics.Raycast(ray, out hit);
            _transform = hit.collider.gameObject.transform;
            _rigidbody = hit.collider.gameObject.GetComponent<Rigidbody>();
            _rigidbody.isKinematic = true;
            _isSmthInHands = true;
            _rigidbody.MovePosition(transform.position);

            _transform.transform.position = transform.position;
            _transform.transform.rotation = transform.rotation;
            _transform.transform.SetParent(transform);
        } 

        if (Input.GetMouseButtonDown(1) && _isSmthInHands)
        {
            _transform.transform.SetParent(null);
            _rigidbody.isKinematic = false;
            _rigidbody.AddRelativeForce(Vector3.forward * ThrowForce, ForceMode.Impulse);

            _transform.gameObject.GetComponent<IsThrowed>().IsObjectThrowed = true;
            _isSmthInHands = false;
        }
    }
}
