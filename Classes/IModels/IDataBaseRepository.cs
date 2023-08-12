
using SystemInventory.Classes.Entities;
using SystemInventory.Classes.Models;
using SystemIventory.Classes.Entities;

namespace SystemInventory.Classes.IModels
{
    public interface IDataBaseRepository
    {

        ResponseQuery SaveInstitution(Institution institution);
        ResponseQuery UpdateStatusList(int list, string statusList);
        ResponseQuery SaveNewWorkAction(int workAction, string description, string typeWorkAction);
        ResponseQuery SaveNewOrderMaterialsWorkAction(int orden, string descripcion);
        ResponseQuery UpdateNewOrderMaterialsWorkAction(string descripcion, int cantidad, int orden);
        ResponseQuery SaveNewOrderMaterialsForTecnicals(string descripcion, int cantidad, int orden, string tecnico);
        ResponseQuery SaveNewProduct(string codigo, string descripcion);
        ResponseQuery ApplyWorkAction(int accion, string estado);
        ResponseQuery SaveInvoice(int numero, string detalle, double valor, string fecha, int orden, string tipo);
        ResponseQuery SaveChangeInDatabase(string placa, string serie, int accion, string estado, int estacion);

        ResponseQuery GetInstitutionCode(string code, string queryType);

        ResponseQuery SaveRegisterReequipamiento(int codeModel, string serial, string placa, string query);
        ResponseQuery GetNextCodeProduct();
        ResponseQuery GetAllTypesDevice();
        ResponseQuery SaveModelDevice(int code, string brand, string model, string queryType);
        ResponseQuery SearchDeviceFromId(string placa_serie, string queryType);
        ResponseQuery GetIdWorkActionFromType(string typeWorkAction);
        ResponseQuery GetIdOrder();
        ResponseQuery SaveInventoryRecord(Equipos_Reequipamiento deviceReequipamiento, string query);
        ResponseQuery GetTotalMaterialsInStockFromDescription(string description);
        ResponseQuery UpdateStatusWorkActionInProduction(int orden, string estado_update);
        ResponseQuery SaveNewDevice(int tipo, string placa, string serie, string cartel);
        ResponseQuery GetDevicesInInstitutionFromCode(string codigo, string tipo, int orden);
        ResponseQuery GetFinalInventoryOrder(int orden);
        ResponseQuery SaveFinalInventoryOrder(InstalledDevice equi, string orden, string encargado, string num_pedido);
        ResponseQuery DeleteDevice(string placa, string serie, int workAction, int NumberEstation);
        ResponseQuery GetListMaterials();
        ResponseQuery GetCodeTechnicals();
        ResponseQuery SaveTechnical(string nameTechnical);
        ResponseQuery SaveUnitCostMaterials(UnitCostMaterial unitCost);
        ResponseQuery GetAllNameDamage();
        ResponseQuery SaveNewDamage(string placa, string serie, string dano, string estado);
        ResponseQuery GetRolSystemFromIdUser(User user);

        ResponseQuery GetDescriptionOutputOrderFromIdOrder(int idOrder);

        ResponseQuery GetDescriptionWorkActionFromId(int idOrder);

        ResponseQuery GetRoles();

        ResponseQuery SaveUserSystem(User user);

        ResponseQuery GetAllInformationInInstitutionFromCode(string code);

        ResponseQuery GetPendingOrder();

        ResponseQuery RegisterNewCartel(string code, string description, string date);

        ResponseQuery GetInformationLocation();

        ResponseQuery GetAllLotes();

        ResponseQuery GetTecnicals();
        ResponseQuery GetInformationTotalLocation();


    }
}
