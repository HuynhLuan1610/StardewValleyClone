using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Rendering.Universal;
using System.Globalization;

public class DayTimeController : MonoBehaviour
{
    const float secondsInDay = 86400f;
    const float phaseLenght = 900f;   //15 minutes chunk of time

    [SerializeField] Color dayLightColor;
    [SerializeField] AnimationCurve nightTimeCurve;
    [SerializeField] Color nightLightColor;

    float time;
    [SerializeField] float timeScale = 60f;
    [SerializeField] float startAtTime = 28800f;

    [SerializeField] Text text;
    [SerializeField] Light2D globalLight;
    private int days;
    
    List<TimeAgent> agents;

    private void Awake()
    {
        agents = new List<TimeAgent>();
    }

    private void Start()
    {
        time = startAtTime;
    }

    public void Subscribe(TimeAgent timeAgent)
    {
        agents.Add(timeAgent);
    }
    public void UnSubscribe(TimeAgent timeAgent)
    {
        agents.Remove(timeAgent);
    }

    float Hours
    {
        get {return time / 3600f; }
    }

    float Minutes
    {
        get {return time % 3600f / 60f; }
    }

    private void Update()
    {
        time += Time.deltaTime * timeScale;

        TimeValueCalculation();

        DayLight();
        if (time > secondsInDay)
        {
            NextDay();
        }

        TimeAgents();
    }


    int oldPhase = 0;
    private void TimeAgents()
    {
        int currentPhase = (int)(time / phaseLenght);
        
        if (oldPhase != currentPhase)
        {
            oldPhase = currentPhase;
            for (int i = 0; i < agents.Count; i++)
            {
                agents[i].Invoke();
            }
        }
    }

    private void DayLight()
    {
        float v = nightTimeCurve.Evaluate(Hours);
        Color c = Color.Lerp(nightLightColor, dayLightColor, v);
        globalLight.color = c;
    }

    private void TimeValueCalculation()
    {
        int hh = (int)Hours;
        int mm = (int)Minutes;
        text.text = hh.ToString("00") + ":" + mm.ToString("00");
    }

    private void NextDay()
    {
        time = 0;
        days += 1;

    }
}
