using UnityEngine;
using System.Collections;

public class UpdateRendererOnEnergyLevel : MonoBehaviour
{
    public Material[] RendererMaterials;
    private SpecialAttackManager _specialAttackManager;
    private Renderer _particleSystemRenderer;

	void Start ()
	{
	    _specialAttackManager = transform.parent.GetComponent<SpecialAttackManager>();
        _particleSystemRenderer = GetComponent<ParticleSystem>().GetComponent<Renderer>();
	}
	
	void Update ()
	{
	    _particleSystemRenderer.material = RendererMaterials[_specialAttackManager.EnergyLevel];
	}
}
