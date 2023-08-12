
using MySql.Data.MySqlClient;
using System;

namespace SystemInventory.Classes.IModels
{
    public interface IDataSetModel
    {
        ResponseQuery GetWorkActionReport(int workAction);

        ResponseQuery GetOrderReport(int order, string location);

        ResponseQuery GetOuputMaterialReport(int order);

        ResponseQuery GetGeneralDevicesReport();

        ResponseQuery GetDevicesInWarranty(string status);


    }
}
