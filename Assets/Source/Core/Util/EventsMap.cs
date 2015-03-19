using UnityEngine;
using System.Collections.Generic;


public class EventsMap {
	private List<Event> events = new List<Event>();
	
	public void ScheduleEvent(int id, int duration)
	{
		for(int i =0; i<events.Count; i++)
		{
			if(events[i].getId() == id)
			{
				events.RemoveAt(i);
			}
		}
		events.Add(new Event(id, duration, true));
	}
	
	public void RestartEvent(int id)
	{
		for(int i=0; i<events.Count; i++)
		{
			Event ev = events[i];
			if(ev.getId() == id)
			{
				ev.restart();
				break;
			}
		}
	}
	public void RestartEvent(int id, int newDuration)
	{
		for(int i =0; i<events.Count; i++)
		{
			Event ev = events[i];
			if(ev.getId() == id)
			{
				ev.Enable(true);
				ev.ChangeDuration(newDuration);
				break;
			}
		}
	}
	
	public void CancelEvent(int id)
	{
		for(int i=0; i<events.Count; i++)
		{
			if(events[i].getId() == id)
			{
				events.RemoveAt(i);
			}
		}
	}
	public void CancelAllEvents()
	{
		events.Clear();
	}
	
	public bool EventActive(int id)
	{
		for(int i=0; i<events.Count; i++)
		{
			Event ev = events[i];
			if(ev.getId() == id)
			{
				return ev.isEnabled();
			}
		}
		return false;
	} 
	public int getEvents()
	{
		for(int i=0; i<events.Count; i++)
		{
			Event ev = events[i];
			if(ev.Over())
			{
				int id = ev.getId();
				ev.Enable(false);
				return id;
			}
		}
		return -1;
	}

	public class Event {
		private int id;
		private int duration;
		private bool enabled;
		private Delay delay;
		
		public Event(int id, int duration, bool enabled)
		{
			this.id = id;
			this.duration = duration;
			this.enabled = enabled;
			delay = new Delay(duration);
			delay.start();
		}
		
		public void ChangeDuration(int newDuration)
		{
			this.duration = newDuration;
			delay = new Delay(duration);
			delay.start();
		}
		public void setId(int id)
		{
			this.id = id;
		}
		public int getId()
		{
			return id;
		}
		public void Enable(bool enabled)
		{
			this.enabled = enabled;
		}
		public bool isEnabled()
		{
			return enabled;
		}
		public void restart()
		{
			enabled = true;
			delay = new Delay(duration);
            delay.start();
        }
        public bool Over()
        {
            if(enabled)
                return delay.over();
            else
                return false;
        }
    }
    
}
