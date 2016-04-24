using UnityEngine;
using System.Collections;

public class EnergyManager : MonoBehaviour
{
    public float MaxEnergy;
    public float CurrentEnergy{ get; private set; }

    public float HPTransferedBySecond;
    public GameObject TransferParticleSystem;

    private HealthManager _healthManager;
    private AnimationManager _animationManager;
    private SpecialAttackManager _specialManager;

    public virtual void Start()
    {
        CurrentEnergy = 0;
        _healthManager = GetComponent<HealthManager>();
        _animationManager = GetComponent<AnimationManager>();
        _specialManager = GetComponent<SpecialAttackManager>();
    }

    public virtual void SpendEnergy(float energy)
    {
        CurrentEnergy -= energy;
        if (CurrentEnergy <= 0) CurrentEnergy = 0;
        _specialManager.UpdateSpecials();
    }

    public virtual void GainEnergy(float energy)
    {
        CurrentEnergy += energy;
        if (CurrentEnergy > MaxEnergy) CurrentEnergy = MaxEnergy;

        _specialManager.UpdateSpecials();
    }

    public void Update()
    {
        if (Input.GetButton("Transfer"))
        {
            if (_animationManager != null)
                _animationManager.SetBoolParameter(CharacterState.Transfering, true);

            if(TransferParticleSystem != null)
                TransferParticleSystem.SetActive(true);

            _healthManager.TakeDamage(HPTransferedBySecond*Time.deltaTime);
            GainEnergy(HPTransferedBySecond*Time.deltaTime);
        }
        else
        {
            if (_animationManager != null)
                _animationManager.SetBoolParameter(CharacterState.Transfering, false);

            if (TransferParticleSystem != null)
                TransferParticleSystem.SetActive(false);
        }
    }

}
