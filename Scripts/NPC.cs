using System;
using UnityEngine;
using TMPro;

public class NPC : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 4f;
    [SerializeField] private float turnSpeed = 90f;
    [SerializeField] private int startingHp = 100;
    [SerializeField] private UnityEngine.UI.Slider hpBarSlider = null;
    [SerializeField] private TextMeshProUGUI playerName = null;
    [SerializeField] private ParticleSystem deathParticlePrefab = null;
    [SerializeField] private int currentHp;

    internal void TakeDamage(int amount)
    {
            GetComponent<IHealth>().TakeDamage(amount);
    }

    //Slease's Code below
    private void UpdateUI()
    {
        var currentHpPct = (float)currentHp / (float)startingHp;

        hpBarSlider.value = currentHpPct;
    }

    //Function to get the thing moving and take damage, don't touch
    private void Update()
    {
        transform.position += transform.forward * moveSpeed * Time.deltaTime;
        transform.Rotate(0f, turnSpeed * Time.deltaTime, 0f);
        hpBarSlider.transform.LookAt(Camera.main.transform);
        playerName.transform.LookAt(Camera.main.transform);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            TakeDamage(startingHp / 10);
        }
    }

}