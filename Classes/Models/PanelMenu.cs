using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SystemInventory.Classes.IModels;
using SystemIventory.Forms.Acciones;
using SystemIventory.Forms.AdministrativesForms;
using SystemIventory.Forms.Consultas.inventarios_materiales;
using SystemIventory.Forms.InventoriesForms.equipos_malos;
using SystemIventory.Forms.InventoriesForms.estado_ordenes;
using SystemIventory.Forms.InventoriesForms;
using SystemIventory.Reports;
using SystemIventory;

namespace SystemInventory.Classes.Models
{
    internal class PanelMenu : IPanel
    {

        public object GetPanel(string panelName, string rol_user)
        {
            Object panel = null;
            switch (panelName)
            {
                case "inven_reeequi":
                    panel = PrincipalForm._getInstance;
                    break;
                case "list_reequi":
                    InventoryListForm.Get_instance.Rol_Usuario = rol_user;
                    panel = InventoryListForm.Get_instance;
                    break;
                case "rpt_acciones":
                    panel = new salida_materiales();
                    break;
                case "verif_equipos":
                    panel = new VerifyDeviceInventoryForm();
                    break;
                case "rpt_equi_accion":
                    panel = new WorkActionGeneralReport();
                    break;
                case "aplicar_accion":
                    panel = new Aplicar_Acciones();
                    break;
                case "nuevo_equipo":
                    panel = new RegisterDeviceForm();
                    break;
                case "revisar_placas":
                    panel = new VerifyIdDeviceForm();
                    break;
                case "t_equipos_instalacion":
                    panel = new InventoryDevicesToSendForm();
                    break;
                case "materiales":
                    panel = new MaterialsForm();
                    break;
                case "orden_ingreso":
                    panel = new EntryOrderForm();
                    break;
                case "orden_salida_materiales":
                    panel = new OrderOutputMaterials();
                    break;
                case "prepa_orden_equipos":
                    panel = new InventoryDevicesSendForm();
                    break;
                case "estado_ordenes":
                    panel = new StatusOrderProductionForm(rol_user);
                    break;
                case "consulta_inventario_materiales":
                    panel = new MaterialsInventoryForm();
                    break;
                case "equipos_danados":
                    panel = new BadDeviceForm();
                    break;
                case "pedidos":
                    panel = new OrdersReport();
                    break;
                case "equi_garantia":
                    panel = new ReportDeviceWarrantyReport();
                    break;
                case "imp_orden_materiales":
                    panel = new WorkActionOutReport("00000");
                    break;
                case "registrar_cartel":
                    panel = new CreateCartelForm();

                    break;
                default:
                    break;
            }
            return panel;
        }
    }
}
