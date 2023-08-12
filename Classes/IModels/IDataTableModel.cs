
namespace SystemInventory.Classes.IModels
{
    public interface IDataTableModel
    {
        ResponseQuery GetAllDataReequipamiento();

        ResponseQuery GetWorkActionFromId(string command, string idWorkAction);


        ResponseQuery GetAllWorkAction(int workAction);


        ResponseQuery GetInfromationWokActionFromType(int accion, string tipo);


        ResponseQuery GetChangesWorkAction(int orden, string tipo);


        ResponseQuery GetWorkActionMaterials();


        ResponseQuery GetStatusWorkActionInProduction(string tipo);


        ResponseQuery GetDataListInstitutionFromWorkAction(string comando, string accion);


        ResponseQuery GetAllTypeDevice();


        ResponseQuery GetAllTypeMaterials();


        ResponseQuery GetTotalRecordOrders();


        ResponseQuery GetInvoiceMaterials(string tipo);


        ResponseQuery GetAllInventoryMaterials();

        ResponseQuery GetAllDeviceDamage();



    }
}
