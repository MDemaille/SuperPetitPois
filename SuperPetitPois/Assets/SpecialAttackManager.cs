using UnityEngine;
using System.Collections;

public class SpecialAttackManager : MonoBehaviour
{
    public int EnergyLevel { get; private set; }

    public float[] SpecialSteps;
    public GameObject[] SpecialAttacks;
    public GameObject[] Shields;

    private EnergyManager _energyManager;
    private GameObject _currentSpecialAttack;
    private GameObject _currentShield;
    private float _currentStep;

    void Start()
    {
        _energyManager = GetComponent<EnergyManager>();
        if (_energyManager.MaxEnergy < SpecialSteps[SpecialSteps.Length - 1])
        {
            Debug.LogError("Unreachable step, not enough Energy");
            _energyManager.MaxEnergy = SpecialSteps[SpecialSteps.Length - 1];
        }

    }

    public void UpdateSpecials()
    {
        if (_energyManager.CurrentEnergy < SpecialSteps[0])
        {
            EnergyLevel = 0;
            return;
        }

        if (_energyManager.CurrentEnergy >= SpecialSteps[SpecialSteps.Length - 1])
        {
            EnergyLevel = SpecialSteps.Length;
            _currentShield = Shields[SpecialSteps.Length - 1];
            _currentSpecialAttack = SpecialAttacks[SpecialSteps.Length - 1];
            _currentStep = SpecialSteps[SpecialSteps.Length - 1];
            return;
        }

        for (int i = 0; i < SpecialSteps.Length - 1; i++)
        {
            if (_energyManager.CurrentEnergy >= SpecialSteps[i] && _energyManager.CurrentEnergy <= SpecialSteps[i + 1])
            {
                EnergyLevel = i+1;
                _currentShield = Shields[i];
                _currentSpecialAttack = SpecialAttacks[i];
                _currentStep = SpecialSteps[i];
            }
        }
    }

    void Update()
    {
        UpdateSpecials();
        if (Input.GetButtonDown("Special") && _currentSpecialAttack != null)
        {
            Instantiate(_currentSpecialAttack, Vector3.zero, Quaternion.identity);
            _currentSpecialAttack = null;
            _energyManager.SpendEnergy(_currentStep);
        }
        else if (Input.GetButtonDown("Shield") && _currentShield != null)
        {
            Instantiate(_currentShield, Vector3.zero, Quaternion.identity);
            _currentShield = null;
            _energyManager.SpendEnergy(_currentStep);
        }
    }


}
