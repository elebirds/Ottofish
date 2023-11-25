/**
 * 描述游戏中可能发生的事情的类。
 */
public abstract class Event
{
    public string eventName { get; protected set; }

    protected Event(string eventName){
        this.eventName = eventName;
    }
}
