using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GumballMachine : MonoBehaviour
{
    public bool GumballTime;
    public bool AtMachine;
    public Player player;

    public float GumballTimer;
    public float GumballCooldownTime;
    public bool MachineIsCooldown;

    public TextMeshProUGUI TimerText;




    [Header("Info")]
    private Vector3 _startPos;
    private float _timer;
    private Vector3 _randomPos;

    [Header("Settings")]
    [Range(0f, 2f)]
    public float _time = 0.2f;
    [Range(0f, 2f)]
    public float _distance = 0.1f;
    [Range(0f, 0.1f)]
    public float _delayBetweenShakes = 0f;

    public void Awake()
    {
        _startPos = transform.position;
    }

    public void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            AtMachine = true;
        }
    }

    public void Update()
    {
        if(AtMachine && player.EPressed)
        {
            if(MachineIsCooldown)
            {
                player.EPressed = false;
                return;
            }
            else
            {
                
                MachineIsCooldown = true;
                GumballTimer = GumballCooldownTime;
                
            }
         
            player.EPressed = false;
        }

        if(MachineIsCooldown)
        {
            ApplyMachineCooldown();
            TimerText.gameObject.SetActive(true);
            TimerText.text = GumballTimer.ToString("0");
            GumballTime = true;
           


        }
        else
        {
            GumballTime = false;
            TimerText.gameObject.SetActive(false);
        }


    }

    public void ApplyMachineCooldown()
    {
        GumballTimer -= Time.deltaTime;
        Begin();
        if(GumballTimer < 0.0f)
        {
            MachineIsCooldown = false;
            GumballTime = false;
            StopAllCoroutines();
        }
    }
    private void OnValidate()
    {
        if (_delayBetweenShakes > _time)
            _delayBetweenShakes = _time;
    }

    public void Begin()
    {
        StopAllCoroutines();
        StartCoroutine(Shake());
    }

    private IEnumerator Shake()
    {
        _timer = 0f;

        while (_timer < _time)
        {
            _timer += Time.deltaTime;

            _randomPos = _startPos + (Random.insideUnitSphere * _distance);

            transform.position = _randomPos;

            if (_delayBetweenShakes > 0f)
            {
                yield return new WaitForSeconds(_delayBetweenShakes);
            }
            else
            {
                yield return null;
            }
        }

        transform.position = _startPos;
    }

}
