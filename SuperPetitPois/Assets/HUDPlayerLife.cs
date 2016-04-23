using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class HUDPlayerLife : MonoBehaviour
{
    private HealthManager _playerHealthManager;
    private Image _image;

	void Start ()
	{
	    _playerHealthManager = GameObject.FindGameObjectWithTag(Tags.Player).GetComponent<HealthManager>();
	    _image = GetComponent<Image>();
	}
	
	void Update ()
	{
	    _image.fillAmount = _playerHealthManager.CurrentHealth/_playerHealthManager.MaxHealth;
	}
}
