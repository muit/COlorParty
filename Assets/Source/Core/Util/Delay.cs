using UnityEngine;
using System.Collections.Generic;

public class Delay 
{
    private int length;
    private float endTime;
    private bool started;
    
    public Delay(int length)
    {
        this.length = length;
        started = false;
    }
    
    public bool over()
    {
        if(!started) 
            return false;
        
        return Time.time*1000 >= endTime;
    }
    public void start()
    {
        started = true;
        endTime = length + Time.time*1000;
    }
    public void reset()
    {
        started = false;
    }
    public bool active()
    {
        return started;
    }
    public void end()
    {
        started = true;
        endTime = 0;
    }
}