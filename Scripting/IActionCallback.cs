using System;


namespace Scripting 
{
    /// <summary>
    /// Receives action events.
    /// </summary>
    public interface IActionCallback
    {
        /// <summary>
        /// Invoked when an Action needs to signal the game should be stopped.
        /// </summary>
        void OnInfo(string message);
        void OnStop();
        void OnError(string message, Exception exception);
    }
}