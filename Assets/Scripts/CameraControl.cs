using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    [SerializeField]
    private GameObject _playerObj;

    private float _yOffset;
    private float _rotateSpeed = 90.0f;

    // Start is called before the first frame update
    void Start()
    {
        _yOffset = transform.position.y - _playerObj.transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        RotateCamera();
    }

    private void LateUpdate()
    {
        transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x, _playerObj.transform.rotation.eulerAngles.y, 0);
        transform.position = new Vector3(_playerObj.transform.position.x, _playerObj.transform.position.y + _yOffset, _playerObj.transform.position.z);
    }

    private void RotateCamera()
    {
        float mouseY = Input.GetAxis("Mouse Y");

        Vector3 rotation = new Vector3(-mouseY, 0, 0);
        transform.Rotate(rotation * _rotateSpeed * Time.deltaTime);
    }
}
