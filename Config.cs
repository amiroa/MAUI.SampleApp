namespace OA.Public.Maui.SampleApp;

public static class Config
{
    public static bool Desktop
    {
        get
        {
#if WINDOWS || MACCATALYST
        return true;
#else
            return false;
#endif
        }
    }
}
