using UnityEngine;
using System.Collections;

public class AnimationManager : MonoBehaviour
{
    private Animator _animator;

	void Start ()
	{
	    _animator = transform.Find("View").GetComponent<Animator>();
	}

    public void SetBoolParameter(string parameter, bool value)
    {
        _animator.SetBool(parameter,value);
    }
    
}
