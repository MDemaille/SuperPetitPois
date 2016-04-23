using UnityEngine;
using System.Collections;

public class EnergyManager : MonoBehaviour
{
    public float MaxEnergy;
    public float CurrentEnergy{ get; private set; }

    public float HPTransferedBySecond;

    private HealthManager _healthManager;

    public virtual void Start()
    {
        CurrentEnergy = 0;
        _healthManager = GetComponent<HealthManager>();
    }

    public virtual void SpendEnergy(float energy)
    {
        CurrentEnergy -= energy;
        if (CurrentEnergy <= 0) CurrentEnergy = 0;
    }

    public virtual void GainEnergy(float life)
    {
        CurrentEnergy += life;
        if (CurrentEnergy > MaxEnergy) CurrentEnergy = MaxEnergy;
    }

    public void Update()
    {
        if (Input.GetButton("Transfer"))
        {
            _healthManager.TakeDamage(HPTransferedBySecond*Time.deltaTime);
            GainEnergy(HPTransferedBySecond * Time.deltaTime);
        }
    }

}
