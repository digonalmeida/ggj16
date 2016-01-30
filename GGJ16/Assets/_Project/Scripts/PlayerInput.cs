using UnityEngine;
using System.Collections;

[RequireComponent (typeof(UnitController))]
public class PlayerInput : MonoBehaviour {

    public Camera mainCamera;

    private UnitController _unitController;
    private float _horizontalSpeed = 0;
    private float _verticalSpeed = 0;

	// Use this for initialization
	void Start ()
    {
        _unitController = GetComponent<UnitController>();
	}
	
	// Update is called once per frame
	void FixedUpdate ()
    {
        _horizontalSpeed = Input.GetAxis("Horizontal");
        _verticalSpeed = Input.GetAxis("Vertical");
        _unitController.UpdateMovementVector(new Vector3(_horizontalSpeed, 0, _verticalSpeed));

        
        if (Input.GetMouseButton(0))
        {            
            Ray __ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit __hit;
            Physics.Raycast(__ray, out __hit);
            Vector3 __tempVector = new Vector3(__hit.point.x, 0, __hit.point.z);
            Vector3 __tempPosition = new Vector3(transform.position.x, 0, transform.position.z);
            _unitController.UpdateRotationVector((__tempVector - __tempPosition));            
        }
        else
        {
            _unitController.UpdateRotationVector(Vector3.zero);
        }
    }
}
