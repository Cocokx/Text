using System;
public delegate void DebugLogHandler(string _input);
internal class InuDebug
{
    static DebugLogHandler m_LogHandler = null;
    static DebugLogHandler m_LogWarningHandler = null;
    static DebugLogHandler m_LogErrorHandler = null;
    static DebugLogHandler m_LogGameResultHandler = null;

    public static DebugLogHandler LogHandler
    {
        set { m_LogHandler = value; }
    }
    public static DebugLogHandler LogWarningHandler
    {
        set { m_LogWarningHandler = value; }
    }
    public static DebugLogHandler LogErrorHandler
    {
        set { m_LogErrorHandler = value; }
    }
    public static DebugLogHandler LogGameResultHandler
    {
        set { m_LogGameResultHandler = value; }
    }

    public static void Log(string msg)
    {
        if (m_LogHandler != null)
        {
            m_LogHandler(msg);
        }
    }
    public static void LogWarning(string msg)
    {
        if (m_LogWarningHandler != null)
        {
            m_LogWarningHandler(msg);
        }
    }
    public static void LogError(string msg)
    {
        if (m_LogErrorHandler != null)
        {
            m_LogErrorHandler(msg);
        }
    }
    public static void LogGameResult(string msg)
    {
        if (m_LogGameResultHandler != null)
        {
            m_LogGameResultHandler(msg);
        }
    }

    public static void Assert(bool condition, string message)
    {
        if (!condition)
        {
            LogError(message);
            throw new Exception(message);
        }
    }
}