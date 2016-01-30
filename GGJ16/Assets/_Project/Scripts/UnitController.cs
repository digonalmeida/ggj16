using UnityEngine;
using System.Collections;

public class UnitController : MonoBehaviour {

    //attributes
    public float baseMovespeed;
    public float baseAttackRange;
    public float baseAttackRadius;
    public float baseChargingRate;
    public int maximumHP = 1;
    public int currentHP = 1;
    
    private float _modifierMovespeed = 1;
    private float _modifierShootingRange = 1;
    private float _modifierExplosionRadius = 1;
    private float _modifierChargingRate = 1;
    private Vector3 _inputMovementVector = Vector3.zero;
    private Vector3 _inputRotationVector = Vector3.zero;    //a vector to be projected from the unit's position to be looked at
    private CharacterController _characterController;
    private bool _chargingAttack = false;
    private float _currentChargedPercentage;
    

	// Use this for initialization
	void Awake ()
    {
        _characterController = GetComponent<CharacterController>();
	}
	
	// Update is called once per frame
	void FixedUpdate ()
    {
        //apply movement and rotation to the unit
        _characterController.Move(_inputMovementVector * (baseMovespeed * _modifierMovespeed));
        //change the rotation
        //if the input is a zero vector, then we make the unit just look ahead, by looking at the movementspeed
        if (_inputRotationVector != Vector3.zero)   
        {
            transform.LookAt(transform.position + _inputRotationVector);
        }
        else
        {
            transform.LookAt(transform.position + _inputMovementVector);
        }
	}

    public void UpdateMovementVector(Vector3 p_vector)
    {
        _inputMovementVector = p_vector;
    }

    public void UpdateRotationVector(Vector3 p_vector)
    {
        _inputRotationVector = p_vector;
        if(p_vector != Vector3.zero)
        {
            _chargingAttack = true;
        }
    }
}
