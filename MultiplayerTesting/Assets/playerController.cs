using UnityEngine;

[RequireComponent(typeof(playerMovement))]
public class playerController : MonoBehaviour
{
    [SerializeField]
    private float speed = 5f;
    private float lookSensitivity = 3f;

    private playerMovement pM;

    private void Start()
    {
        pM = GetComponent<playerMovement>();
    }

    private void Update()
    {
        float _xMove = Input.GetAxis("Horizontal");
        float _zMove = Input.GetAxis("Vertical");

        Vector3 _moveHorizontal = transform.right * _xMove;
        Vector3 _moveVertical = transform.forward * _zMove;

        Vector3 _velocity = (_moveHorizontal + _moveVertical) * speed;

        pM.Move(_velocity);

        float _yRot = Input.GetAxis("Mouse X");

        Vector3 _rotation = new Vector3(0, _yRot, 0) * lookSensitivity;

        pM.Rotate(_rotation);

        float _xRot = Input.GetAxis("Mouse Y");

        Vector3 _camRotation = new Vector3(_xRot, 0, 0) * lookSensitivity;

        pM.RotateCamera(_camRotation);
    }
}
