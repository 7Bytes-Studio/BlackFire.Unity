namespace BlackFire.Unity
{
    public interface IDebuggerManager:IManager
    {
        float WindowScale { get; set; }
        DebuggerStyle DebuggerStyle { get; set; }
    }
}