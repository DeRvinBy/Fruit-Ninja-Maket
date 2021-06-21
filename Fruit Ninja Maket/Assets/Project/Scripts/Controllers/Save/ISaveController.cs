namespace Project.Scripts.Controllers.Save
{
    public interface ISaveController
    {
        PlayerStats PlayerSave { get; }
        
        void SavePlayerStats();
    }
}