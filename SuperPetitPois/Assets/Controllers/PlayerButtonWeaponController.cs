using UnityEngine;
using System.Collections;

public class PlayerButtonWeaponController : MonoBehaviour {

    private Weapon weaponComponent;
    private float _timer;

    private AnimationManager _animManager;

    void Start()
    {
        weaponComponent = GetComponent<Weapon>();
        _animManager = transform.parent.GetComponent<AnimationManager>();
    }

    // Update is called once per frame
    void Update()
    {
        _animManager.SetBoolParameter(CharacterState.Shooting, false);

        _timer += Time.deltaTime;
        if (Input.GetButton("Fire1"))
        {
            _animManager.SetBoolParameter(CharacterState.Shooting, true);
            if (_timer > weaponComponent.FireRate)
            {
                _timer = 0;
                weaponComponent.Fire();
            }
        }
    }

}
