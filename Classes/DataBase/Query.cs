namespace SystemIventory.Classes
{
    public static class Query
    {

        public static string Insert
        {
            get
            {
                return "INSERT";
            }
            
        }
        public static string Update
        {
            get
            {
                return "UPDATE";
            }
        }

        public static string MysqlProcedureGetWorkActionFromId
        {
            get
            {
                return "p_buscar_equipos_acciones";
            }
        }
        public static string MysqlProcedureSaveInstitution
        {
            get
            {
                return "p_insertar_institucion";
            }
        }
        public static string MysqlGetNameInstitution
        {
            get
            {
                return "select Centro_educativo from instituciones where Codigo = @code;";
            }
        }
        public static string MysqlSaveRecordReequipamiento
        {
            get
            {
                return "INSERT INTO equipos VALUES(@codeModel,@devicePlaca,@deviceSerial)";
            }
        }
        public static string MysqlGetDataReequipamiento
        {
            get
            {
                return "SELECT * FROM view_inventario_equipos";
            }
        }
        public static string MysqlUpdateStatusList
        {
            get
            {
                return "UPDATE lista_inventarios SET Estado_Listado = @val_lista WHERE Listado = @val_estadoLista;";
            }
        }
        public static string MysqlGetInformationLocation
        {
            get
            {
                return "SELECT Codigo,Nombre FROM ubicacion;";
            }
        }
        public static string MysqlGetAllLotes
        {
            get
            {
                return "SELECT id_cartel FROM carteles;";
            }
        }
        public static string MysqlGetNextCodeProduct
        {
            get
            {
                return "SELECT codigo_modelo FROM view_siguiente_codigo;";
            }
        }

        public static string MysqlGetAllTypesDevice
        {
            get
            {
                return "SELECT * FROM acs_sistema.tipos_equipos;";
            }
            
            
        }

        public static string MysqlProcedureSaveModelDevice
        {
            get
            {
                return "ingreso_modelo_equipos";

            }
        }

        public static string MysqlProcedureSearchDeviceFromId
        {
            get
            {
                return "p_buscar_equipos";          

            }

        }

        public static string MysqlGetIdWorkActionFromType
        {
            get
            {
                return "SELECT * FROM nueva_orden;";

            }
        }
        public static string MysqlGetIdWorkActionMaterialsFromType
        {
            get
            {
                return "SELECT * FROM nueva_orden_materiales;";

            }
        }

        public static string MysqlGetIdOrder
        {
            get
            {
                return "SELECT Codigo FROM nuevo_registro_pedido;";

            }
     
        }

        public static string MysqlProcedureSaveInventoryRecord
        {
            get
            {
                return "p_insertar_equipos_inventarios";

            }
        }

        public static string MysqlGetWorkActionReport
        {
            get
            {
                return "SELECT * FROM lista_inventarios WHERE lista_inventarios.Accion = @workAction;";

            }
                
        }

        public static string MysqlProcedureGetOrderReport
        {
            get
            {
                return "buscar_pedidos";

            }
                    
        }

        public static string MysqlProcedureGetOuputMaterialReport
        {
            get
            {
                return "b_salida_materiales";

            }
                    
        }

        public static string MysqlGetAllWorkAction
        {
            get
            {
                return "SELECT * FROM lista_inventarios WHERE Accion = @workAction;";

            }
                
        }

        public static string MysqlProcedureSaveNewWorkAction
        {
            get
            {
                return "p_insertar_acciones";

            }
            


        }

        public static string MysqlProcedureSaveNewOrderMaterialsWorkAction
        {
            get
            {
                return "p_insertar_orden_materiales";    

            }

        }

        public static string MysqlProcedureUpdateNewOrderMaterialsWorkAction
        {
            get
            {
                return  "actualizar_inventarios_materiales";

            }

        }

        public static string MysqlGetTotalMaterialsInStockFromDescription
        {
            get
            {
                return "SELECT cantidad FROM cantidad_stock_materiales WHERE descripcion = @description;";

            }
            
                
        }

        public static string MysqlProcedureSaveNewOrderMaterialsForTecnicals
        {
            get
            {
                return "registro_inventarios_materiales_tecnicos";

            }
                    
        }

        public static string MysqlProcedureSaveNewProduct
        {
            get
            {
                return "registrar_producto";

            }
                    
        }

        public static string MysqlGetGeneralDevicesReport
        {
            get
            {
                return "SELECT * FROM reporte_general;";

            }
                
        }

        public static string MysqlGetStatusWokActionFromId
        {
            get
            {
                return "SELECT * FROM view_estado_accion where Tipo_Orden = @tipo ORDER BY accion DESC;";

            }


        }
        public static string MysqlGetStatusWokActionByTypeOrder
        {
            get
            {
                return "SELECT * FROM view_estado_accion WHERE accion = @accion AND Tipo_Orden = @tipo ORDER BY accion DESC;";

            }
                
        }

        public static string MysqlGetChangesWorkAction
        {
            get
            {
                return "SELECT * FROM cambios where orden = @orden AND estado = @tipo;";

            }

        }

        public static string MysqlGetWorkActionMaterials
        {
            get
            {
                return "SELECT * FROM ordenes_materiales;";

            }

            
        }

        public static string MysqlGetStatusWorkActionInProduction
        {
            get
            {
                return "SELECT * FROM obtener_ordenes_enproceso;";

            }
            
           
        }
        public static string MysqlGetStatusWorkActionPending
        {
            get
            {
                return "SELECT * FROM obtener_ordenes_pendientes;";

            }

           
        }

        public static string MysqlUpdateStatusWorkActionInProduction
        {
            get
            {
                return "UPDATE estado_orden_produccion SET estado = @estado_update WHERE id_estado_orden = @orden;";

            }
                
        }

        public static string MysqlProcedureApplyWorkAction
        {
            get
            {
                return "p_Aplicar_Estado_Accion";

            }
                
            
        }

        public static string MysqlProcedureSaveInvoice
        {
            get
            {
                return "insertar_factura";

            }
                
        }

        public static string MysqlGetDataListInstitutionFromWorkAction
        {
            get
            {
                return "p_buscar_lista_inventarios";       

            }

        }

        public static string MysqlProcedureSaveNewDevice
        {
            get
            {
                return "ingreso_equipos";

            }
        }

        public static string MysqlGetAllTypeDevice
        {
            get
            {
                return "SELECT * FROM views_tipos_equipos;";

            }
            
        }

        public static string MysqlGetAllTypeMaterials
        {
            get
            {
                return "SELECT * FROM acs_sistema.view_lista_materiales;";

            }
            
        }

        /*public InstalledDevice GetDevicesInInstitutionFromCode
        {
            
            try
            {
                string consulta = string.Empty;

                if (tipo.Equals("ADMINISTRATIVO"))
                {
                    consulta = "SELECT * FROM equipos_instalacion_instituciones_final WHERE Codigo_Institucion= '" + codigo + "' AND id_orden = '" + _order + "'";

                }
                else
                {
                    consulta = "SELECT * FROM equipos_instalacion_instituciones WHERE Codigo_Institucion= '" + codigo + "'";
                }

                
        }*/

        public static string MysqlGetTotalRecordOrders
        {
            get
            {
                return "SELECT * FROM buscar_pedido_equipos;";

            }
            

        }

        public static string MysqlGetFinalInventoryOrder
        {
            get
            {
                return "SELECT * FROM equipos_instalacion_instituciones_final WHERE id_orden=@orden;";

            }

           
        }

        public static string MysqlProcedureSaveFinalInventoryOrder
        {
            get
            {
                return "insertar_orden_preparacion_equipos";

            }
                    

        }

        public static string MysqlProcedureSaveChangeInDatabase
        {
            get
            {
                return "insertar_cambios";

            }
                    
        }

        public static string MysqlDeleteDevice
        {
            get
            {
                return @"DELETE FROM lista_inventarios WHERE Placa = @placa AND Accion = @workAction;";

            }
               
        }

        public static string MysqlGetListMaterials
        {
            get
            {
                return "SELECT descripcion FROM seleccionar_materiales;";

            }
            
        }

        public static string MysqlGetTecnicals
        {
            get
            {
                return "SELECT nombre FROM obtener_tecnicos;";

            }
            
        }

        public static string MysqlGetCodeTechnicals
        {
            get
            {
                return "SELECT codigo_tecnico FROM view_get_codigotecnico;";

            }
            
        }

        public static string MysqlSaveTechnical
        {
            get
            {
                return "INSERT INTO tecnicos VALUES(@codigo,@nameTechnical);";

            }
                    
        }

        public static string MysqlGetInvoiceMaterials
        {
            get
            {
                return "SELECT * FROM factura_materiales;"; 

            }
        }
        public static string MysqlGetInvoice
        {
            get
            {
                return "SELECT * FROM factura_ordenes;";

            }
            
        }

        public static string MysqlGetAllInventoryMaterials
        {
            get
            {
                return "SELECT * FROM materiales_en_inventario;";

            }

        }

        public static string MysqlProcedureSaveUnitCostMaterials
        {
            get
            {
                return "insertar_factura_costo_unidad";

            }

        }

        public static string MysqlGetAllNameDamage
        {
            get
            {
                return "SELECT dano FROM danos;";

            }
            
        }

        public static string MysqlGetAllDeviceDamage
        {
            get
            {
                return "SELECT * FROM view_equipos_reparacion;";

            }

            
        }

        public static string MysqlSaveNewDamage
        {
            get
            {
                return "insertar_equipos_reparacion";

            }
        }

        public static string MysqlGetRolSystemFromIdUser
        {
            get
            {
                return "SELECT rol_user FROM usuarios WHERE nom_user = @user AND pass_user= @password;";

            }
                    
        }

        public static string MysqlGetDevicesInWarranty
        {
            get
            {
                return "SELECT * FROM view_equipos_reparacion;";

            }

        }
        public static string MysqlGetDevicesInWarrantyFromStatus
        {
            get
            {
                return "SELECT * FROM view_equipos_reparacion WHERE ESTADO = @status;";

            }
        }

        public static string MysqlGetDescriptionOutputOrderFromIdOrder
        {
            get
            {
                return "SELECT descripcion FROM ordenes_materiales WHERE codigo = @idOrder;";

            }
        }

        public static string MysqlGetDescriptionWorkActionFromId
        {
            get
            {
                return "SELECT Descripcion FROM acciones WHERE Codigo = @idOrder;";

            }
        }

        public static string MysqlGetRoles
        {
            get
            {
                return "SELECT id_rol from roles;";

            }
                    
        }

        public static string MysqlSaveUserSystem
        {
            get
            {
                
                return "INSERT INTO usuarios VALUES (@user,@password,@rol);";

            }
        }

        public static string MysqlGetAllInformationInInstitutionFromCode
        {
            get
            {
                return "SELECT codigo_institucion,cantidad_instalada,descripcion,fecha_registro,documento FROM acs_sistema.instalaciones_cableado WHERE codigo_institucion= @code;";

            }
            
        }

        public static string MysqlGetPendingOrder
        {
            get
            {
                return "SELECT * FROM cantidad_pendientes;";

            }
            
        }

        public static string MysqlRegisterNewCartel
        {
            get
            {
                return "INSERT INTO carteles VALUES (@code,@description,@date);";

            }
                    
        }


    }
}
