using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class HUDPlayerEnergy : MonoBehaviour
{
    public int EnergyLevel;
    private float _min;
    private float _max;

    private Image _image;
    private EnergyManager _energyManager ;

	void Start ()
	{
        _image = GetComponent<Image>();
	    _energyManager = LevelManager.Player.GetComponent<EnergyManager>();

        SpecialAttackManager manager = LevelManager.Player.GetComponent<SpecialAttackManager>();

	    if (EnergyLevel == 0)
	    {
	        _min = 0;
	    }
	    else
	    {
	        _min = manager.SpecialSteps[EnergyLevel - 1];
	    }

	    _max = manager.SpecialSteps[EnergyLevel];
    }
	
	void Update ()
	{
	    _image.fillAmount = (_energyManager.CurrentEnergy - _min)/(_max - _min);
	}
}
