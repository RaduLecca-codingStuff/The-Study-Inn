using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class UserMetricData : MonoBehaviour
{
    public int avgnroflogins;
    public float avgtimespentInApp;
    public float avgButtonPressTime;
    DateTime[] timebetweenbuttonspressed;
    int nrofLogins;
    int timeSpent;
    int averageBP;
    DateTime lastLogin;

    // Start is called before the first frame update
    void Awake()
    {
        string path = "Assets/Resources/test.txt";
        StreamReader reader = new StreamReader(path);
        string[] line = reader.ReadToEnd().Split(',');
        nrofLogins = int.Parse(line[0]) + 1;
        timeSpent = int.Parse(line[1]);
        averageBP = int.Parse(line[2]);
        if (line.Length > 3)
            lastLogin = DateTime.Parse(line[3]);
        else
            lastLogin = DateTime.Now;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnApplicationQuit()
    {
        float avg = 0;
        for (int i = 0; i < timebetweenbuttonspressed.Length; i++)
        {
            avg += (timebetweenbuttonspressed[i].Minute * 60) + timebetweenbuttonspressed[i].Second;
        }
        avg = avg / timebetweenbuttonspressed.Length;
        if (avgButtonPressTime > 0)
            avgButtonPressTime = (avgButtonPressTime + avg) / 2;

    }
}
