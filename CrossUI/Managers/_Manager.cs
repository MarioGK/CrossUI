namespace CrossUI.Managers
{
    // ReSharper disable once InconsistentNaming
    public static class _Manager
    {
        public static void InitializeAllManagers()
        {
            FontManager.Initialize();
            ThemeManager.Initialize();
        }
    }
}