using System.Data;

namespace SystemInventory.Classes.IModels
{
    internal interface IReequipamiento
    {
        DataTable GetAllDataReequipamiento();
        bool SaveRegisterReequipamiento(int codeModel, string serial, string placa, string query);
    }
}
