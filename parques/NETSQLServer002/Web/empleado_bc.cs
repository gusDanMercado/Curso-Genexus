using System;
using System.Collections;
using GeneXus.Utils;
using GeneXus.Resources;
using GeneXus.Application;
using GeneXus.Metadata;
using GeneXus.Cryptography;
using System.Data;
using GeneXus.Data;
using com.genexus;
using GeneXus.Data.ADO;
using GeneXus.Data.NTier;
using GeneXus.Data.NTier.ADO;
using GeneXus.WebControls;
using GeneXus.Http;
using GeneXus.XML;
using GeneXus.Search;
using GeneXus.Encryption;
using GeneXus.Http.Client;
using System.Xml.Serialization;
using System.Runtime.Serialization;
namespace GeneXus.Programs {
   public class empleado_bc : GxSilentTrn, IGxSilentTrn
   {
      public empleado_bc( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("parques", true);
      }

      public empleado_bc( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDefault = context.GetDataStore("Default");
      }

      protected void INITTRN( )
      {
      }

      public void GetInsDefault( )
      {
         ReadRow011( ) ;
         standaloneNotModal( ) ;
         InitializeNonKey011( ) ;
         standaloneModal( ) ;
         AddRow011( ) ;
         Gx_mode = "INS";
         return  ;
      }

      protected void AfterTrn( )
      {
         if ( trnEnded == 1 )
         {
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( endTrnMsgTxt)) )
            {
               GX_msglist.addItem(endTrnMsgTxt, endTrnMsgCod, 0, "", true);
            }
            /* Execute user event: After Trn */
            E11012 ();
            trnEnded = 0;
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            if ( IsIns( )  )
            {
               Z1EmpleadoId = A1EmpleadoId;
               SetMode( "UPD") ;
            }
         }
         endTrnMsgTxt = "";
      }

      public override string ToString( )
      {
         return "" ;
      }

      public GxContentInfo GetContentInfo( )
      {
         return (GxContentInfo)(null) ;
      }

      public bool Reindex( )
      {
         return true ;
      }

      protected void CONFIRM_010( )
      {
         BeforeValidate011( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls011( ) ;
            }
            else
            {
               CheckExtendedTable011( ) ;
               if ( AnyError == 0 )
               {
                  ZM011( 9) ;
               }
               CloseExtendedTableCursors011( ) ;
            }
         }
         if ( AnyError == 0 )
         {
         }
      }

      protected void E12012( )
      {
         /* Start Routine */
         returnInSub = false;
      }

      protected void E11012( )
      {
         /* After Trn Routine */
         returnInSub = false;
      }

      protected void ZM011( short GX_JID )
      {
         if ( ( GX_JID == 8 ) || ( GX_JID == 0 ) )
         {
            Z2EmpleadoNombre = A2EmpleadoNombre;
            Z3EmpleadoApellido = A3EmpleadoApellido;
            Z4EmpleadoDireccion = A4EmpleadoDireccion;
            Z5EmpleadoTelefono = A5EmpleadoTelefono;
            Z6EmpleadoEmail = A6EmpleadoEmail;
            Z7EmpleadoFch_Alta = A7EmpleadoFch_Alta;
            Z8EmpleadoFcha_Mod = A8EmpleadoFcha_Mod;
            Z9EmpleadoFch_Cad = A9EmpleadoFch_Cad;
            Z10EmpleadoUsu_Alta = A10EmpleadoUsu_Alta;
            Z11EmpleadoUsu_Mod = A11EmpleadoUsu_Mod;
            Z12EmpleadoUso_Cad = A12EmpleadoUso_Cad;
            Z13parqueAtraccionId = A13parqueAtraccionId;
         }
         if ( ( GX_JID == 9 ) || ( GX_JID == 0 ) )
         {
            Z14parqueAtraccionNombre = A14parqueAtraccionNombre;
         }
         if ( GX_JID == -8 )
         {
            Z1EmpleadoId = A1EmpleadoId;
            Z2EmpleadoNombre = A2EmpleadoNombre;
            Z3EmpleadoApellido = A3EmpleadoApellido;
            Z4EmpleadoDireccion = A4EmpleadoDireccion;
            Z5EmpleadoTelefono = A5EmpleadoTelefono;
            Z6EmpleadoEmail = A6EmpleadoEmail;
            Z7EmpleadoFch_Alta = A7EmpleadoFch_Alta;
            Z8EmpleadoFcha_Mod = A8EmpleadoFcha_Mod;
            Z9EmpleadoFch_Cad = A9EmpleadoFch_Cad;
            Z10EmpleadoUsu_Alta = A10EmpleadoUsu_Alta;
            Z11EmpleadoUsu_Mod = A11EmpleadoUsu_Mod;
            Z12EmpleadoUso_Cad = A12EmpleadoUso_Cad;
            Z13parqueAtraccionId = A13parqueAtraccionId;
            Z14parqueAtraccionNombre = A14parqueAtraccionNombre;
         }
      }

      protected void standaloneNotModal( )
      {
         Gx_BScreen = 0;
         Gx_date = DateTimeUtil.Today( context);
      }

      protected void standaloneModal( )
      {
         if ( IsIns( )  && (0==A13parqueAtraccionId) && ( Gx_BScreen == 0 ) )
         {
            A13parqueAtraccionId = 1;
            n13parqueAtraccionId = false;
         }
         if ( IsIns( )  && (0==A1EmpleadoId) && ( Gx_BScreen == 0 ) )
         {
            A1EmpleadoId = 1;
         }
         if ( IsIns( )  && (DateTime.MinValue==A7EmpleadoFch_Alta) && ( Gx_BScreen == 0 ) )
         {
            A7EmpleadoFch_Alta = DateTimeUtil.ResetTime( Gx_date ) ;
            n7EmpleadoFch_Alta = false;
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ( Gx_BScreen == 0 ) )
         {
            /* Using cursor BC00014 */
            pr_default.execute(2, new Object[] {n13parqueAtraccionId, A13parqueAtraccionId});
            A14parqueAtraccionNombre = BC00014_A14parqueAtraccionNombre[0];
            pr_default.close(2);
         }
      }

      protected void Load011( )
      {
         /* Using cursor BC00015 */
         pr_default.execute(3, new Object[] {A1EmpleadoId});
         if ( (pr_default.getStatus(3) != 101) )
         {
            RcdFound1 = 1;
            A2EmpleadoNombre = BC00015_A2EmpleadoNombre[0];
            A3EmpleadoApellido = BC00015_A3EmpleadoApellido[0];
            A4EmpleadoDireccion = BC00015_A4EmpleadoDireccion[0];
            n4EmpleadoDireccion = BC00015_n4EmpleadoDireccion[0];
            A5EmpleadoTelefono = BC00015_A5EmpleadoTelefono[0];
            n5EmpleadoTelefono = BC00015_n5EmpleadoTelefono[0];
            A6EmpleadoEmail = BC00015_A6EmpleadoEmail[0];
            n6EmpleadoEmail = BC00015_n6EmpleadoEmail[0];
            A7EmpleadoFch_Alta = BC00015_A7EmpleadoFch_Alta[0];
            n7EmpleadoFch_Alta = BC00015_n7EmpleadoFch_Alta[0];
            A8EmpleadoFcha_Mod = BC00015_A8EmpleadoFcha_Mod[0];
            n8EmpleadoFcha_Mod = BC00015_n8EmpleadoFcha_Mod[0];
            A9EmpleadoFch_Cad = BC00015_A9EmpleadoFch_Cad[0];
            n9EmpleadoFch_Cad = BC00015_n9EmpleadoFch_Cad[0];
            A10EmpleadoUsu_Alta = BC00015_A10EmpleadoUsu_Alta[0];
            n10EmpleadoUsu_Alta = BC00015_n10EmpleadoUsu_Alta[0];
            A11EmpleadoUsu_Mod = BC00015_A11EmpleadoUsu_Mod[0];
            n11EmpleadoUsu_Mod = BC00015_n11EmpleadoUsu_Mod[0];
            A12EmpleadoUso_Cad = BC00015_A12EmpleadoUso_Cad[0];
            n12EmpleadoUso_Cad = BC00015_n12EmpleadoUso_Cad[0];
            A14parqueAtraccionNombre = BC00015_A14parqueAtraccionNombre[0];
            A13parqueAtraccionId = BC00015_A13parqueAtraccionId[0];
            n13parqueAtraccionId = BC00015_n13parqueAtraccionId[0];
            ZM011( -8) ;
         }
         pr_default.close(3);
         OnLoadActions011( ) ;
      }

      protected void OnLoadActions011( )
      {
      }

      protected void CheckExtendedTable011( )
      {
         standaloneModal( ) ;
         if ( ! ( GxRegex.IsMatch(A6EmpleadoEmail,"^((\\w+([-+.']\\w+)*@\\w+([-.]\\w+)*\\.\\w+([-.]\\w+)*)|(\\s*))$") || String.IsNullOrEmpty(StringUtil.RTrim( A6EmpleadoEmail)) ) )
         {
            GX_msglist.addItem("El valor de Empleado Email no coincide con el patrón especificado", "OutOfRange", 1, "");
            AnyError = 1;
         }
         if ( ! ( (DateTime.MinValue==A7EmpleadoFch_Alta) || ( A7EmpleadoFch_Alta >= context.localUtil.YMDHMSToT( 1753, 1, 1, 0, 0, 0) ) ) )
         {
            GX_msglist.addItem("Campo Empleado Fch_Alta fuera de rango", "OutOfRange", 1, "");
            AnyError = 1;
         }
         if ( ! ( (DateTime.MinValue==A8EmpleadoFcha_Mod) || ( A8EmpleadoFcha_Mod >= context.localUtil.YMDHMSToT( 1753, 1, 1, 0, 0, 0) ) ) )
         {
            GX_msglist.addItem("Campo Empleado Fcha_Mod fuera de rango", "OutOfRange", 1, "");
            AnyError = 1;
         }
         if ( ! ( (DateTime.MinValue==A9EmpleadoFch_Cad) || ( A9EmpleadoFch_Cad >= context.localUtil.YMDHMSToT( 1753, 1, 1, 0, 0, 0) ) ) )
         {
            GX_msglist.addItem("Campo Empleado Fch_Cad fuera de rango", "OutOfRange", 1, "");
            AnyError = 1;
         }
         /* Using cursor BC00014 */
         pr_default.execute(2, new Object[] {n13parqueAtraccionId, A13parqueAtraccionId});
         if ( (pr_default.getStatus(2) == 101) )
         {
            if ( ! ( (0==A13parqueAtraccionId) ) )
            {
               GX_msglist.addItem("No existe 'parque Atraccion'.", "ForeignKeyNotFound", 1, "PARQUEATRACCIONID");
               AnyError = 1;
            }
         }
         A14parqueAtraccionNombre = BC00014_A14parqueAtraccionNombre[0];
         pr_default.close(2);
      }

      protected void CloseExtendedTableCursors011( )
      {
         pr_default.close(2);
      }

      protected void enableDisable( )
      {
      }

      protected void GetKey011( )
      {
         /* Using cursor BC00016 */
         pr_default.execute(4, new Object[] {A1EmpleadoId});
         if ( (pr_default.getStatus(4) != 101) )
         {
            RcdFound1 = 1;
         }
         else
         {
            RcdFound1 = 0;
         }
         pr_default.close(4);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor BC00013 */
         pr_default.execute(1, new Object[] {A1EmpleadoId});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM011( 8) ;
            RcdFound1 = 1;
            A1EmpleadoId = BC00013_A1EmpleadoId[0];
            A2EmpleadoNombre = BC00013_A2EmpleadoNombre[0];
            A3EmpleadoApellido = BC00013_A3EmpleadoApellido[0];
            A4EmpleadoDireccion = BC00013_A4EmpleadoDireccion[0];
            n4EmpleadoDireccion = BC00013_n4EmpleadoDireccion[0];
            A5EmpleadoTelefono = BC00013_A5EmpleadoTelefono[0];
            n5EmpleadoTelefono = BC00013_n5EmpleadoTelefono[0];
            A6EmpleadoEmail = BC00013_A6EmpleadoEmail[0];
            n6EmpleadoEmail = BC00013_n6EmpleadoEmail[0];
            A7EmpleadoFch_Alta = BC00013_A7EmpleadoFch_Alta[0];
            n7EmpleadoFch_Alta = BC00013_n7EmpleadoFch_Alta[0];
            A8EmpleadoFcha_Mod = BC00013_A8EmpleadoFcha_Mod[0];
            n8EmpleadoFcha_Mod = BC00013_n8EmpleadoFcha_Mod[0];
            A9EmpleadoFch_Cad = BC00013_A9EmpleadoFch_Cad[0];
            n9EmpleadoFch_Cad = BC00013_n9EmpleadoFch_Cad[0];
            A10EmpleadoUsu_Alta = BC00013_A10EmpleadoUsu_Alta[0];
            n10EmpleadoUsu_Alta = BC00013_n10EmpleadoUsu_Alta[0];
            A11EmpleadoUsu_Mod = BC00013_A11EmpleadoUsu_Mod[0];
            n11EmpleadoUsu_Mod = BC00013_n11EmpleadoUsu_Mod[0];
            A12EmpleadoUso_Cad = BC00013_A12EmpleadoUso_Cad[0];
            n12EmpleadoUso_Cad = BC00013_n12EmpleadoUso_Cad[0];
            A13parqueAtraccionId = BC00013_A13parqueAtraccionId[0];
            n13parqueAtraccionId = BC00013_n13parqueAtraccionId[0];
            Z1EmpleadoId = A1EmpleadoId;
            sMode1 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Load011( ) ;
            if ( AnyError == 1 )
            {
               RcdFound1 = 0;
               InitializeNonKey011( ) ;
            }
            Gx_mode = sMode1;
         }
         else
         {
            RcdFound1 = 0;
            InitializeNonKey011( ) ;
            sMode1 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Gx_mode = sMode1;
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey011( ) ;
         if ( RcdFound1 == 0 )
         {
            Gx_mode = "INS";
         }
         else
         {
            Gx_mode = "UPD";
         }
         getByPrimaryKey( ) ;
      }

      protected void insert_Check( )
      {
         CONFIRM_010( ) ;
      }

      protected void update_Check( )
      {
         insert_Check( ) ;
      }

      protected void delete_Check( )
      {
         insert_Check( ) ;
      }

      protected void CheckOptimisticConcurrency011( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor BC00012 */
            pr_default.execute(0, new Object[] {A1EmpleadoId});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Empleado"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            Gx_longc = false;
            if ( (pr_default.getStatus(0) == 101) || ( StringUtil.StrCmp(Z2EmpleadoNombre, BC00012_A2EmpleadoNombre[0]) != 0 ) || ( StringUtil.StrCmp(Z3EmpleadoApellido, BC00012_A3EmpleadoApellido[0]) != 0 ) || ( StringUtil.StrCmp(Z4EmpleadoDireccion, BC00012_A4EmpleadoDireccion[0]) != 0 ) || ( StringUtil.StrCmp(Z5EmpleadoTelefono, BC00012_A5EmpleadoTelefono[0]) != 0 ) || ( StringUtil.StrCmp(Z6EmpleadoEmail, BC00012_A6EmpleadoEmail[0]) != 0 ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( Z7EmpleadoFch_Alta != BC00012_A7EmpleadoFch_Alta[0] ) || ( Z8EmpleadoFcha_Mod != BC00012_A8EmpleadoFcha_Mod[0] ) || ( Z9EmpleadoFch_Cad != BC00012_A9EmpleadoFch_Cad[0] ) || ( StringUtil.StrCmp(Z10EmpleadoUsu_Alta, BC00012_A10EmpleadoUsu_Alta[0]) != 0 ) || ( StringUtil.StrCmp(Z11EmpleadoUsu_Mod, BC00012_A11EmpleadoUsu_Mod[0]) != 0 ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( StringUtil.StrCmp(Z12EmpleadoUso_Cad, BC00012_A12EmpleadoUso_Cad[0]) != 0 ) || ( Z13parqueAtraccionId != BC00012_A13parqueAtraccionId[0] ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"Empleado"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert011( )
      {
         BeforeValidate011( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable011( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM011( 0) ;
            CheckOptimisticConcurrency011( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm011( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert011( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC00017 */
                     pr_default.execute(5, new Object[] {A2EmpleadoNombre, A3EmpleadoApellido, n4EmpleadoDireccion, A4EmpleadoDireccion, n5EmpleadoTelefono, A5EmpleadoTelefono, n6EmpleadoEmail, A6EmpleadoEmail, n7EmpleadoFch_Alta, A7EmpleadoFch_Alta, n8EmpleadoFcha_Mod, A8EmpleadoFcha_Mod, n9EmpleadoFch_Cad, A9EmpleadoFch_Cad, n10EmpleadoUsu_Alta, A10EmpleadoUsu_Alta, n11EmpleadoUsu_Mod, A11EmpleadoUsu_Mod, n12EmpleadoUso_Cad, A12EmpleadoUso_Cad, n13parqueAtraccionId, A13parqueAtraccionId});
                     A1EmpleadoId = BC00017_A1EmpleadoId[0];
                     pr_default.close(5);
                     pr_default.SmartCacheProvider.SetUpdated("Empleado");
                     if ( AnyError == 0 )
                     {
                        /* Start of After( Insert) rules */
                        /* End of After( Insert) rules */
                        if ( AnyError == 0 )
                        {
                           /* Save values for previous() function. */
                           endTrnMsgTxt = context.GetMessage( "GXM_sucadded", "");
                           endTrnMsgCod = "SuccessfullyAdded";
                        }
                     }
                  }
                  else
                  {
                     GX_msglist.addItem(context.GetMessage( "GXM_unexp", ""), 1, "");
                     AnyError = 1;
                  }
               }
            }
            else
            {
               Load011( ) ;
            }
            EndLevel011( ) ;
         }
         CloseExtendedTableCursors011( ) ;
      }

      protected void Update011( )
      {
         BeforeValidate011( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable011( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency011( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm011( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate011( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC00018 */
                     pr_default.execute(6, new Object[] {A2EmpleadoNombre, A3EmpleadoApellido, n4EmpleadoDireccion, A4EmpleadoDireccion, n5EmpleadoTelefono, A5EmpleadoTelefono, n6EmpleadoEmail, A6EmpleadoEmail, n7EmpleadoFch_Alta, A7EmpleadoFch_Alta, n8EmpleadoFcha_Mod, A8EmpleadoFcha_Mod, n9EmpleadoFch_Cad, A9EmpleadoFch_Cad, n10EmpleadoUsu_Alta, A10EmpleadoUsu_Alta, n11EmpleadoUsu_Mod, A11EmpleadoUsu_Mod, n12EmpleadoUso_Cad, A12EmpleadoUso_Cad, n13parqueAtraccionId, A13parqueAtraccionId, A1EmpleadoId});
                     pr_default.close(6);
                     pr_default.SmartCacheProvider.SetUpdated("Empleado");
                     if ( (pr_default.getStatus(6) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Empleado"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate011( ) ;
                     if ( AnyError == 0 )
                     {
                        /* Start of After( update) rules */
                        /* End of After( update) rules */
                        if ( AnyError == 0 )
                        {
                           getByPrimaryKey( ) ;
                           endTrnMsgTxt = context.GetMessage( "GXM_sucupdated", "");
                           endTrnMsgCod = "SuccessfullyUpdated";
                        }
                     }
                     else
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_unexp", ""), 1, "");
                        AnyError = 1;
                     }
                  }
               }
            }
            EndLevel011( ) ;
         }
         CloseExtendedTableCursors011( ) ;
      }

      protected void DeferredUpdate011( )
      {
      }

      protected void delete( )
      {
         Gx_mode = "DLT";
         BeforeValidate011( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency011( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls011( ) ;
            AfterConfirm011( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete011( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor BC00019 */
                  pr_default.execute(7, new Object[] {A1EmpleadoId});
                  pr_default.close(7);
                  pr_default.SmartCacheProvider.SetUpdated("Empleado");
                  if ( AnyError == 0 )
                  {
                     /* Start of After( delete) rules */
                     /* End of After( delete) rules */
                     if ( AnyError == 0 )
                     {
                        endTrnMsgTxt = context.GetMessage( "GXM_sucdeleted", "");
                        endTrnMsgCod = "SuccessfullyDeleted";
                     }
                  }
                  else
                  {
                     GX_msglist.addItem(context.GetMessage( "GXM_unexp", ""), 1, "");
                     AnyError = 1;
                  }
               }
            }
         }
         sMode1 = Gx_mode;
         Gx_mode = "DLT";
         EndLevel011( ) ;
         Gx_mode = sMode1;
      }

      protected void OnDeleteControls011( )
      {
         standaloneModal( ) ;
         if ( AnyError == 0 )
         {
            /* Delete mode formulas */
            /* Using cursor BC000110 */
            pr_default.execute(8, new Object[] {n13parqueAtraccionId, A13parqueAtraccionId});
            A14parqueAtraccionNombre = BC000110_A14parqueAtraccionNombre[0];
            pr_default.close(8);
         }
      }

      protected void EndLevel011( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete011( ) ;
         }
         if ( AnyError == 0 )
         {
            /* After transaction rules */
            /* Execute 'After Trn' event if defined. */
            trnEnded = 1;
         }
         else
         {
         }
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanKeyStart011( )
      {
         /* Scan By routine */
         /* Using cursor BC000111 */
         pr_default.execute(9, new Object[] {A1EmpleadoId});
         RcdFound1 = 0;
         if ( (pr_default.getStatus(9) != 101) )
         {
            RcdFound1 = 1;
            A1EmpleadoId = BC000111_A1EmpleadoId[0];
            A2EmpleadoNombre = BC000111_A2EmpleadoNombre[0];
            A3EmpleadoApellido = BC000111_A3EmpleadoApellido[0];
            A4EmpleadoDireccion = BC000111_A4EmpleadoDireccion[0];
            n4EmpleadoDireccion = BC000111_n4EmpleadoDireccion[0];
            A5EmpleadoTelefono = BC000111_A5EmpleadoTelefono[0];
            n5EmpleadoTelefono = BC000111_n5EmpleadoTelefono[0];
            A6EmpleadoEmail = BC000111_A6EmpleadoEmail[0];
            n6EmpleadoEmail = BC000111_n6EmpleadoEmail[0];
            A7EmpleadoFch_Alta = BC000111_A7EmpleadoFch_Alta[0];
            n7EmpleadoFch_Alta = BC000111_n7EmpleadoFch_Alta[0];
            A8EmpleadoFcha_Mod = BC000111_A8EmpleadoFcha_Mod[0];
            n8EmpleadoFcha_Mod = BC000111_n8EmpleadoFcha_Mod[0];
            A9EmpleadoFch_Cad = BC000111_A9EmpleadoFch_Cad[0];
            n9EmpleadoFch_Cad = BC000111_n9EmpleadoFch_Cad[0];
            A10EmpleadoUsu_Alta = BC000111_A10EmpleadoUsu_Alta[0];
            n10EmpleadoUsu_Alta = BC000111_n10EmpleadoUsu_Alta[0];
            A11EmpleadoUsu_Mod = BC000111_A11EmpleadoUsu_Mod[0];
            n11EmpleadoUsu_Mod = BC000111_n11EmpleadoUsu_Mod[0];
            A12EmpleadoUso_Cad = BC000111_A12EmpleadoUso_Cad[0];
            n12EmpleadoUso_Cad = BC000111_n12EmpleadoUso_Cad[0];
            A14parqueAtraccionNombre = BC000111_A14parqueAtraccionNombre[0];
            A13parqueAtraccionId = BC000111_A13parqueAtraccionId[0];
            n13parqueAtraccionId = BC000111_n13parqueAtraccionId[0];
         }
         /* Load Subordinate Levels */
      }

      protected void ScanKeyNext011( )
      {
         /* Scan next routine */
         pr_default.readNext(9);
         RcdFound1 = 0;
         ScanKeyLoad011( ) ;
      }

      protected void ScanKeyLoad011( )
      {
         sMode1 = Gx_mode;
         Gx_mode = "DSP";
         if ( (pr_default.getStatus(9) != 101) )
         {
            RcdFound1 = 1;
            A1EmpleadoId = BC000111_A1EmpleadoId[0];
            A2EmpleadoNombre = BC000111_A2EmpleadoNombre[0];
            A3EmpleadoApellido = BC000111_A3EmpleadoApellido[0];
            A4EmpleadoDireccion = BC000111_A4EmpleadoDireccion[0];
            n4EmpleadoDireccion = BC000111_n4EmpleadoDireccion[0];
            A5EmpleadoTelefono = BC000111_A5EmpleadoTelefono[0];
            n5EmpleadoTelefono = BC000111_n5EmpleadoTelefono[0];
            A6EmpleadoEmail = BC000111_A6EmpleadoEmail[0];
            n6EmpleadoEmail = BC000111_n6EmpleadoEmail[0];
            A7EmpleadoFch_Alta = BC000111_A7EmpleadoFch_Alta[0];
            n7EmpleadoFch_Alta = BC000111_n7EmpleadoFch_Alta[0];
            A8EmpleadoFcha_Mod = BC000111_A8EmpleadoFcha_Mod[0];
            n8EmpleadoFcha_Mod = BC000111_n8EmpleadoFcha_Mod[0];
            A9EmpleadoFch_Cad = BC000111_A9EmpleadoFch_Cad[0];
            n9EmpleadoFch_Cad = BC000111_n9EmpleadoFch_Cad[0];
            A10EmpleadoUsu_Alta = BC000111_A10EmpleadoUsu_Alta[0];
            n10EmpleadoUsu_Alta = BC000111_n10EmpleadoUsu_Alta[0];
            A11EmpleadoUsu_Mod = BC000111_A11EmpleadoUsu_Mod[0];
            n11EmpleadoUsu_Mod = BC000111_n11EmpleadoUsu_Mod[0];
            A12EmpleadoUso_Cad = BC000111_A12EmpleadoUso_Cad[0];
            n12EmpleadoUso_Cad = BC000111_n12EmpleadoUso_Cad[0];
            A14parqueAtraccionNombre = BC000111_A14parqueAtraccionNombre[0];
            A13parqueAtraccionId = BC000111_A13parqueAtraccionId[0];
            n13parqueAtraccionId = BC000111_n13parqueAtraccionId[0];
         }
         Gx_mode = sMode1;
      }

      protected void ScanKeyEnd011( )
      {
         pr_default.close(9);
      }

      protected void AfterConfirm011( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert011( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate011( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete011( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete011( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate011( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes011( )
      {
      }

      protected void send_integrity_lvl_hashes011( )
      {
      }

      protected void AddRow011( )
      {
         VarsToRow1( bcEmpleado) ;
      }

      protected void ReadRow011( )
      {
         RowToVars1( bcEmpleado, 1) ;
      }

      protected void InitializeNonKey011( )
      {
         A2EmpleadoNombre = "";
         A3EmpleadoApellido = "";
         A4EmpleadoDireccion = "";
         n4EmpleadoDireccion = false;
         A5EmpleadoTelefono = "";
         n5EmpleadoTelefono = false;
         A6EmpleadoEmail = "";
         n6EmpleadoEmail = false;
         A8EmpleadoFcha_Mod = (DateTime)(DateTime.MinValue);
         n8EmpleadoFcha_Mod = false;
         A9EmpleadoFch_Cad = (DateTime)(DateTime.MinValue);
         n9EmpleadoFch_Cad = false;
         A10EmpleadoUsu_Alta = "";
         n10EmpleadoUsu_Alta = false;
         A11EmpleadoUsu_Mod = "";
         n11EmpleadoUsu_Mod = false;
         A12EmpleadoUso_Cad = "";
         n12EmpleadoUso_Cad = false;
         A14parqueAtraccionNombre = "";
         A7EmpleadoFch_Alta = DateTimeUtil.ResetTime( Gx_date ) ;
         n7EmpleadoFch_Alta = false;
         A13parqueAtraccionId = 1;
         n13parqueAtraccionId = false;
         Z2EmpleadoNombre = "";
         Z3EmpleadoApellido = "";
         Z4EmpleadoDireccion = "";
         Z5EmpleadoTelefono = "";
         Z6EmpleadoEmail = "";
         Z7EmpleadoFch_Alta = (DateTime)(DateTime.MinValue);
         Z8EmpleadoFcha_Mod = (DateTime)(DateTime.MinValue);
         Z9EmpleadoFch_Cad = (DateTime)(DateTime.MinValue);
         Z10EmpleadoUsu_Alta = "";
         Z11EmpleadoUsu_Mod = "";
         Z12EmpleadoUso_Cad = "";
         Z13parqueAtraccionId = 0;
      }

      protected void InitAll011( )
      {
         A1EmpleadoId = 1;
         InitializeNonKey011( ) ;
      }

      protected void StandaloneModalInsert( )
      {
         A13parqueAtraccionId = i13parqueAtraccionId;
         n13parqueAtraccionId = false;
         A7EmpleadoFch_Alta = i7EmpleadoFch_Alta;
         n7EmpleadoFch_Alta = false;
      }

      protected bool IsIns( )
      {
         return ((StringUtil.StrCmp(Gx_mode, "INS")==0) ? true : false) ;
      }

      protected bool IsDlt( )
      {
         return ((StringUtil.StrCmp(Gx_mode, "DLT")==0) ? true : false) ;
      }

      protected bool IsUpd( )
      {
         return ((StringUtil.StrCmp(Gx_mode, "UPD")==0) ? true : false) ;
      }

      protected bool IsDsp( )
      {
         return ((StringUtil.StrCmp(Gx_mode, "DSP")==0) ? true : false) ;
      }

      public void VarsToRow1( SdtEmpleado obj1 )
      {
         obj1.gxTpr_Mode = Gx_mode;
         obj1.gxTpr_Empleadonombre = A2EmpleadoNombre;
         obj1.gxTpr_Empleadoapellido = A3EmpleadoApellido;
         obj1.gxTpr_Empleadodireccion = A4EmpleadoDireccion;
         obj1.gxTpr_Empleadotelefono = A5EmpleadoTelefono;
         obj1.gxTpr_Empleadoemail = A6EmpleadoEmail;
         obj1.gxTpr_Empleadofcha_mod = A8EmpleadoFcha_Mod;
         obj1.gxTpr_Empleadofch_cad = A9EmpleadoFch_Cad;
         obj1.gxTpr_Empleadousu_alta = A10EmpleadoUsu_Alta;
         obj1.gxTpr_Empleadousu_mod = A11EmpleadoUsu_Mod;
         obj1.gxTpr_Empleadouso_cad = A12EmpleadoUso_Cad;
         obj1.gxTpr_Parqueatraccionnombre = A14parqueAtraccionNombre;
         obj1.gxTpr_Empleadofch_alta = A7EmpleadoFch_Alta;
         obj1.gxTpr_Parqueatraccionid = A13parqueAtraccionId;
         obj1.gxTpr_Empleadoid = A1EmpleadoId;
         obj1.gxTpr_Empleadoid_Z = Z1EmpleadoId;
         obj1.gxTpr_Empleadonombre_Z = Z2EmpleadoNombre;
         obj1.gxTpr_Empleadoapellido_Z = Z3EmpleadoApellido;
         obj1.gxTpr_Empleadodireccion_Z = Z4EmpleadoDireccion;
         obj1.gxTpr_Empleadotelefono_Z = Z5EmpleadoTelefono;
         obj1.gxTpr_Empleadoemail_Z = Z6EmpleadoEmail;
         obj1.gxTpr_Empleadofch_alta_Z = Z7EmpleadoFch_Alta;
         obj1.gxTpr_Empleadofcha_mod_Z = Z8EmpleadoFcha_Mod;
         obj1.gxTpr_Empleadofch_cad_Z = Z9EmpleadoFch_Cad;
         obj1.gxTpr_Empleadousu_alta_Z = Z10EmpleadoUsu_Alta;
         obj1.gxTpr_Empleadousu_mod_Z = Z11EmpleadoUsu_Mod;
         obj1.gxTpr_Empleadouso_cad_Z = Z12EmpleadoUso_Cad;
         obj1.gxTpr_Parqueatraccionid_Z = Z13parqueAtraccionId;
         obj1.gxTpr_Parqueatraccionnombre_Z = Z14parqueAtraccionNombre;
         obj1.gxTpr_Empleadodireccion_N = (short)(Convert.ToInt16(n4EmpleadoDireccion));
         obj1.gxTpr_Empleadotelefono_N = (short)(Convert.ToInt16(n5EmpleadoTelefono));
         obj1.gxTpr_Empleadoemail_N = (short)(Convert.ToInt16(n6EmpleadoEmail));
         obj1.gxTpr_Empleadofch_alta_N = (short)(Convert.ToInt16(n7EmpleadoFch_Alta));
         obj1.gxTpr_Empleadofcha_mod_N = (short)(Convert.ToInt16(n8EmpleadoFcha_Mod));
         obj1.gxTpr_Empleadofch_cad_N = (short)(Convert.ToInt16(n9EmpleadoFch_Cad));
         obj1.gxTpr_Empleadousu_alta_N = (short)(Convert.ToInt16(n10EmpleadoUsu_Alta));
         obj1.gxTpr_Empleadousu_mod_N = (short)(Convert.ToInt16(n11EmpleadoUsu_Mod));
         obj1.gxTpr_Empleadouso_cad_N = (short)(Convert.ToInt16(n12EmpleadoUso_Cad));
         obj1.gxTpr_Parqueatraccionid_N = (short)(Convert.ToInt16(n13parqueAtraccionId));
         obj1.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void KeyVarsToRow1( SdtEmpleado obj1 )
      {
         obj1.gxTpr_Empleadoid = A1EmpleadoId;
         return  ;
      }

      public void RowToVars1( SdtEmpleado obj1 ,
                              int forceLoad )
      {
         Gx_mode = obj1.gxTpr_Mode;
         A2EmpleadoNombre = obj1.gxTpr_Empleadonombre;
         A3EmpleadoApellido = obj1.gxTpr_Empleadoapellido;
         A4EmpleadoDireccion = obj1.gxTpr_Empleadodireccion;
         n4EmpleadoDireccion = false;
         A5EmpleadoTelefono = obj1.gxTpr_Empleadotelefono;
         n5EmpleadoTelefono = false;
         A6EmpleadoEmail = obj1.gxTpr_Empleadoemail;
         n6EmpleadoEmail = false;
         A8EmpleadoFcha_Mod = obj1.gxTpr_Empleadofcha_mod;
         n8EmpleadoFcha_Mod = false;
         A9EmpleadoFch_Cad = obj1.gxTpr_Empleadofch_cad;
         n9EmpleadoFch_Cad = false;
         A10EmpleadoUsu_Alta = obj1.gxTpr_Empleadousu_alta;
         n10EmpleadoUsu_Alta = false;
         A11EmpleadoUsu_Mod = obj1.gxTpr_Empleadousu_mod;
         n11EmpleadoUsu_Mod = false;
         A12EmpleadoUso_Cad = obj1.gxTpr_Empleadouso_cad;
         n12EmpleadoUso_Cad = false;
         A14parqueAtraccionNombre = obj1.gxTpr_Parqueatraccionnombre;
         A7EmpleadoFch_Alta = obj1.gxTpr_Empleadofch_alta;
         n7EmpleadoFch_Alta = false;
         A13parqueAtraccionId = obj1.gxTpr_Parqueatraccionid;
         n13parqueAtraccionId = false;
         A1EmpleadoId = obj1.gxTpr_Empleadoid;
         Z1EmpleadoId = obj1.gxTpr_Empleadoid_Z;
         Z2EmpleadoNombre = obj1.gxTpr_Empleadonombre_Z;
         Z3EmpleadoApellido = obj1.gxTpr_Empleadoapellido_Z;
         Z4EmpleadoDireccion = obj1.gxTpr_Empleadodireccion_Z;
         Z5EmpleadoTelefono = obj1.gxTpr_Empleadotelefono_Z;
         Z6EmpleadoEmail = obj1.gxTpr_Empleadoemail_Z;
         Z7EmpleadoFch_Alta = obj1.gxTpr_Empleadofch_alta_Z;
         Z8EmpleadoFcha_Mod = obj1.gxTpr_Empleadofcha_mod_Z;
         Z9EmpleadoFch_Cad = obj1.gxTpr_Empleadofch_cad_Z;
         Z10EmpleadoUsu_Alta = obj1.gxTpr_Empleadousu_alta_Z;
         Z11EmpleadoUsu_Mod = obj1.gxTpr_Empleadousu_mod_Z;
         Z12EmpleadoUso_Cad = obj1.gxTpr_Empleadouso_cad_Z;
         Z13parqueAtraccionId = obj1.gxTpr_Parqueatraccionid_Z;
         Z14parqueAtraccionNombre = obj1.gxTpr_Parqueatraccionnombre_Z;
         n4EmpleadoDireccion = (bool)(Convert.ToBoolean(obj1.gxTpr_Empleadodireccion_N));
         n5EmpleadoTelefono = (bool)(Convert.ToBoolean(obj1.gxTpr_Empleadotelefono_N));
         n6EmpleadoEmail = (bool)(Convert.ToBoolean(obj1.gxTpr_Empleadoemail_N));
         n7EmpleadoFch_Alta = (bool)(Convert.ToBoolean(obj1.gxTpr_Empleadofch_alta_N));
         n8EmpleadoFcha_Mod = (bool)(Convert.ToBoolean(obj1.gxTpr_Empleadofcha_mod_N));
         n9EmpleadoFch_Cad = (bool)(Convert.ToBoolean(obj1.gxTpr_Empleadofch_cad_N));
         n10EmpleadoUsu_Alta = (bool)(Convert.ToBoolean(obj1.gxTpr_Empleadousu_alta_N));
         n11EmpleadoUsu_Mod = (bool)(Convert.ToBoolean(obj1.gxTpr_Empleadousu_mod_N));
         n12EmpleadoUso_Cad = (bool)(Convert.ToBoolean(obj1.gxTpr_Empleadouso_cad_N));
         n13parqueAtraccionId = (bool)(Convert.ToBoolean(obj1.gxTpr_Parqueatraccionid_N));
         Gx_mode = obj1.gxTpr_Mode;
         return  ;
      }

      public void LoadKey( Object[] obj )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         A1EmpleadoId = (short)getParm(obj,0);
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         InitializeNonKey011( ) ;
         ScanKeyStart011( ) ;
         if ( RcdFound1 == 0 )
         {
            Gx_mode = "INS";
         }
         else
         {
            Gx_mode = "UPD";
            Z1EmpleadoId = A1EmpleadoId;
         }
         ZM011( -8) ;
         OnLoadActions011( ) ;
         AddRow011( ) ;
         ScanKeyEnd011( ) ;
         if ( RcdFound1 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "");
            AnyError = 1;
         }
         context.GX_msglist = BackMsgLst;
      }

      public void Load( )
      {
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         RowToVars1( bcEmpleado, 0) ;
         ScanKeyStart011( ) ;
         if ( RcdFound1 == 0 )
         {
            Gx_mode = "INS";
         }
         else
         {
            Gx_mode = "UPD";
            Z1EmpleadoId = A1EmpleadoId;
         }
         ZM011( -8) ;
         OnLoadActions011( ) ;
         AddRow011( ) ;
         ScanKeyEnd011( ) ;
         if ( RcdFound1 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "");
            AnyError = 1;
         }
         context.GX_msglist = BackMsgLst;
      }

      protected void SaveImpl( )
      {
         GetKey011( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            Insert011( ) ;
         }
         else
         {
            if ( RcdFound1 == 1 )
            {
               if ( A1EmpleadoId != Z1EmpleadoId )
               {
                  A1EmpleadoId = Z1EmpleadoId;
                  GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "CandidateKeyNotFound", 1, "");
                  AnyError = 1;
               }
               else if ( IsDlt( ) )
               {
                  delete( ) ;
                  AfterTrn( ) ;
               }
               else
               {
                  Gx_mode = "UPD";
                  /* Update record */
                  Update011( ) ;
               }
            }
            else
            {
               if ( IsDlt( ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "CandidateKeyNotFound", 1, "");
                  AnyError = 1;
               }
               else
               {
                  if ( A1EmpleadoId != Z1EmpleadoId )
                  {
                     if ( IsUpd( ) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "DuplicatePrimaryKey", 1, "");
                        AnyError = 1;
                     }
                     else
                     {
                        Gx_mode = "INS";
                        /* Insert record */
                        Insert011( ) ;
                     }
                  }
                  else
                  {
                     if ( StringUtil.StrCmp(Gx_mode, "UPD") == 0 )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "");
                        AnyError = 1;
                     }
                     else
                     {
                        Gx_mode = "INS";
                        /* Insert record */
                        Insert011( ) ;
                     }
                  }
               }
            }
         }
         AfterTrn( ) ;
      }

      public void Save( )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         RowToVars1( bcEmpleado, 1) ;
         SaveImpl( ) ;
         VarsToRow1( bcEmpleado) ;
         context.GX_msglist = BackMsgLst;
         return  ;
      }

      public bool Insert( )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         RowToVars1( bcEmpleado, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert011( ) ;
         AfterTrn( ) ;
         VarsToRow1( bcEmpleado) ;
         context.GX_msglist = BackMsgLst;
         return (AnyError==0) ;
      }

      protected void UpdateImpl( )
      {
         if ( IsUpd( ) )
         {
            SaveImpl( ) ;
            VarsToRow1( bcEmpleado) ;
         }
         else
         {
            SdtEmpleado auxBC = new SdtEmpleado(context);
            IGxSilentTrn auxTrn = auxBC.getTransaction();
            auxBC.Load(A1EmpleadoId);
            if ( auxTrn.Errors() == 0 )
            {
               auxBC.UpdateDirties(bcEmpleado);
               auxBC.Save();
               bcEmpleado.Copy((GxSilentTrnSdt)(auxBC));
            }
            LclMsgLst = (msglist)(auxTrn.GetMessages());
            AnyError = (short)(auxTrn.Errors());
            context.GX_msglist = LclMsgLst;
            if ( auxTrn.Errors() == 0 )
            {
               Gx_mode = auxTrn.GetMode();
               AfterTrn( ) ;
            }
         }
      }

      public bool Update( )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         RowToVars1( bcEmpleado, 1) ;
         UpdateImpl( ) ;
         context.GX_msglist = BackMsgLst;
         return (AnyError==0) ;
      }

      public bool InsertOrUpdate( )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         RowToVars1( bcEmpleado, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert011( ) ;
         if ( AnyError == 1 )
         {
            if ( StringUtil.StrCmp(context.GX_msglist.getItemValue(1), "DuplicatePrimaryKey") == 0 )
            {
               AnyError = 0;
               context.GX_msglist.removeAllItems();
               UpdateImpl( ) ;
            }
            else
            {
               VarsToRow1( bcEmpleado) ;
            }
         }
         else
         {
            AfterTrn( ) ;
            VarsToRow1( bcEmpleado) ;
         }
         context.GX_msglist = BackMsgLst;
         return (AnyError==0) ;
      }

      public void Check( )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         RowToVars1( bcEmpleado, 0) ;
         GetKey011( ) ;
         if ( RcdFound1 == 1 )
         {
            if ( IsIns( ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_noupdate", ""), "DuplicatePrimaryKey", 1, "");
               AnyError = 1;
            }
            else if ( A1EmpleadoId != Z1EmpleadoId )
            {
               A1EmpleadoId = Z1EmpleadoId;
               GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "DuplicatePrimaryKey", 1, "");
               AnyError = 1;
            }
            else if ( IsDlt( ) )
            {
               delete_Check( ) ;
            }
            else
            {
               Gx_mode = "UPD";
               update_Check( ) ;
            }
         }
         else
         {
            if ( A1EmpleadoId != Z1EmpleadoId )
            {
               Gx_mode = "INS";
               insert_Check( ) ;
            }
            else
            {
               if ( IsUpd( ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "");
                  AnyError = 1;
               }
               else
               {
                  Gx_mode = "INS";
                  insert_Check( ) ;
               }
            }
         }
         pr_default.close(1);
         pr_default.close(8);
         context.RollbackDataStores("empleado_bc",pr_default);
         VarsToRow1( bcEmpleado) ;
         context.GX_msglist = BackMsgLst;
         return  ;
      }

      public int Errors( )
      {
         if ( AnyError == 0 )
         {
            return (int)(0) ;
         }
         return (int)(1) ;
      }

      public msglist GetMessages( )
      {
         return LclMsgLst ;
      }

      public string GetMode( )
      {
         Gx_mode = bcEmpleado.gxTpr_Mode;
         return Gx_mode ;
      }

      public void SetMode( string lMode )
      {
         Gx_mode = lMode;
         bcEmpleado.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void SetSDT( GxSilentTrnSdt sdt ,
                          short sdtToBc )
      {
         if ( sdt != bcEmpleado )
         {
            bcEmpleado = (SdtEmpleado)(sdt);
            if ( StringUtil.StrCmp(bcEmpleado.gxTpr_Mode, "") == 0 )
            {
               bcEmpleado.gxTpr_Mode = "INS";
            }
            if ( sdtToBc == 1 )
            {
               VarsToRow1( bcEmpleado) ;
            }
            else
            {
               RowToVars1( bcEmpleado, 1) ;
            }
         }
         else
         {
            if ( StringUtil.StrCmp(bcEmpleado.gxTpr_Mode, "") == 0 )
            {
               bcEmpleado.gxTpr_Mode = "INS";
            }
         }
         return  ;
      }

      public void ReloadFromSDT( )
      {
         RowToVars1( bcEmpleado, 1) ;
         return  ;
      }

      public void ForceCommitOnExit( )
      {
         return  ;
      }

      public SdtEmpleado Empleado_BC
      {
         get {
            return bcEmpleado ;
         }

      }

      public void webExecute( )
      {
         createObjects();
         initialize();
      }

      public bool isMasterPage( )
      {
         return false;
      }

      protected void createObjects( )
      {
      }

      protected void Process( )
      {
      }

      public override void cleanup( )
      {
         CloseCursors();
         if ( IsMain )
         {
            context.CloseConnections();
         }
      }

      protected override void CloseCursors( )
      {
         pr_default.close(1);
         pr_default.close(8);
      }

      public override void initialize( )
      {
         Gx_mode = "";
         endTrnMsgTxt = "";
         endTrnMsgCod = "";
         Z2EmpleadoNombre = "";
         A2EmpleadoNombre = "";
         Z3EmpleadoApellido = "";
         A3EmpleadoApellido = "";
         Z4EmpleadoDireccion = "";
         A4EmpleadoDireccion = "";
         Z5EmpleadoTelefono = "";
         A5EmpleadoTelefono = "";
         Z6EmpleadoEmail = "";
         A6EmpleadoEmail = "";
         Z7EmpleadoFch_Alta = (DateTime)(DateTime.MinValue);
         A7EmpleadoFch_Alta = (DateTime)(DateTime.MinValue);
         Z8EmpleadoFcha_Mod = (DateTime)(DateTime.MinValue);
         A8EmpleadoFcha_Mod = (DateTime)(DateTime.MinValue);
         Z9EmpleadoFch_Cad = (DateTime)(DateTime.MinValue);
         A9EmpleadoFch_Cad = (DateTime)(DateTime.MinValue);
         Z10EmpleadoUsu_Alta = "";
         A10EmpleadoUsu_Alta = "";
         Z11EmpleadoUsu_Mod = "";
         A11EmpleadoUsu_Mod = "";
         Z12EmpleadoUso_Cad = "";
         A12EmpleadoUso_Cad = "";
         Z14parqueAtraccionNombre = "";
         A14parqueAtraccionNombre = "";
         Gx_date = DateTime.MinValue;
         BC00014_A14parqueAtraccionNombre = new string[] {""} ;
         BC00015_A1EmpleadoId = new short[1] ;
         BC00015_A2EmpleadoNombre = new string[] {""} ;
         BC00015_A3EmpleadoApellido = new string[] {""} ;
         BC00015_A4EmpleadoDireccion = new string[] {""} ;
         BC00015_n4EmpleadoDireccion = new bool[] {false} ;
         BC00015_A5EmpleadoTelefono = new string[] {""} ;
         BC00015_n5EmpleadoTelefono = new bool[] {false} ;
         BC00015_A6EmpleadoEmail = new string[] {""} ;
         BC00015_n6EmpleadoEmail = new bool[] {false} ;
         BC00015_A7EmpleadoFch_Alta = new DateTime[] {DateTime.MinValue} ;
         BC00015_n7EmpleadoFch_Alta = new bool[] {false} ;
         BC00015_A8EmpleadoFcha_Mod = new DateTime[] {DateTime.MinValue} ;
         BC00015_n8EmpleadoFcha_Mod = new bool[] {false} ;
         BC00015_A9EmpleadoFch_Cad = new DateTime[] {DateTime.MinValue} ;
         BC00015_n9EmpleadoFch_Cad = new bool[] {false} ;
         BC00015_A10EmpleadoUsu_Alta = new string[] {""} ;
         BC00015_n10EmpleadoUsu_Alta = new bool[] {false} ;
         BC00015_A11EmpleadoUsu_Mod = new string[] {""} ;
         BC00015_n11EmpleadoUsu_Mod = new bool[] {false} ;
         BC00015_A12EmpleadoUso_Cad = new string[] {""} ;
         BC00015_n12EmpleadoUso_Cad = new bool[] {false} ;
         BC00015_A14parqueAtraccionNombre = new string[] {""} ;
         BC00015_A13parqueAtraccionId = new short[1] ;
         BC00015_n13parqueAtraccionId = new bool[] {false} ;
         BC00016_A1EmpleadoId = new short[1] ;
         BC00013_A1EmpleadoId = new short[1] ;
         BC00013_A2EmpleadoNombre = new string[] {""} ;
         BC00013_A3EmpleadoApellido = new string[] {""} ;
         BC00013_A4EmpleadoDireccion = new string[] {""} ;
         BC00013_n4EmpleadoDireccion = new bool[] {false} ;
         BC00013_A5EmpleadoTelefono = new string[] {""} ;
         BC00013_n5EmpleadoTelefono = new bool[] {false} ;
         BC00013_A6EmpleadoEmail = new string[] {""} ;
         BC00013_n6EmpleadoEmail = new bool[] {false} ;
         BC00013_A7EmpleadoFch_Alta = new DateTime[] {DateTime.MinValue} ;
         BC00013_n7EmpleadoFch_Alta = new bool[] {false} ;
         BC00013_A8EmpleadoFcha_Mod = new DateTime[] {DateTime.MinValue} ;
         BC00013_n8EmpleadoFcha_Mod = new bool[] {false} ;
         BC00013_A9EmpleadoFch_Cad = new DateTime[] {DateTime.MinValue} ;
         BC00013_n9EmpleadoFch_Cad = new bool[] {false} ;
         BC00013_A10EmpleadoUsu_Alta = new string[] {""} ;
         BC00013_n10EmpleadoUsu_Alta = new bool[] {false} ;
         BC00013_A11EmpleadoUsu_Mod = new string[] {""} ;
         BC00013_n11EmpleadoUsu_Mod = new bool[] {false} ;
         BC00013_A12EmpleadoUso_Cad = new string[] {""} ;
         BC00013_n12EmpleadoUso_Cad = new bool[] {false} ;
         BC00013_A13parqueAtraccionId = new short[1] ;
         BC00013_n13parqueAtraccionId = new bool[] {false} ;
         sMode1 = "";
         BC00012_A1EmpleadoId = new short[1] ;
         BC00012_A2EmpleadoNombre = new string[] {""} ;
         BC00012_A3EmpleadoApellido = new string[] {""} ;
         BC00012_A4EmpleadoDireccion = new string[] {""} ;
         BC00012_n4EmpleadoDireccion = new bool[] {false} ;
         BC00012_A5EmpleadoTelefono = new string[] {""} ;
         BC00012_n5EmpleadoTelefono = new bool[] {false} ;
         BC00012_A6EmpleadoEmail = new string[] {""} ;
         BC00012_n6EmpleadoEmail = new bool[] {false} ;
         BC00012_A7EmpleadoFch_Alta = new DateTime[] {DateTime.MinValue} ;
         BC00012_n7EmpleadoFch_Alta = new bool[] {false} ;
         BC00012_A8EmpleadoFcha_Mod = new DateTime[] {DateTime.MinValue} ;
         BC00012_n8EmpleadoFcha_Mod = new bool[] {false} ;
         BC00012_A9EmpleadoFch_Cad = new DateTime[] {DateTime.MinValue} ;
         BC00012_n9EmpleadoFch_Cad = new bool[] {false} ;
         BC00012_A10EmpleadoUsu_Alta = new string[] {""} ;
         BC00012_n10EmpleadoUsu_Alta = new bool[] {false} ;
         BC00012_A11EmpleadoUsu_Mod = new string[] {""} ;
         BC00012_n11EmpleadoUsu_Mod = new bool[] {false} ;
         BC00012_A12EmpleadoUso_Cad = new string[] {""} ;
         BC00012_n12EmpleadoUso_Cad = new bool[] {false} ;
         BC00012_A13parqueAtraccionId = new short[1] ;
         BC00012_n13parqueAtraccionId = new bool[] {false} ;
         BC00017_A1EmpleadoId = new short[1] ;
         BC000110_A14parqueAtraccionNombre = new string[] {""} ;
         BC000111_A1EmpleadoId = new short[1] ;
         BC000111_A2EmpleadoNombre = new string[] {""} ;
         BC000111_A3EmpleadoApellido = new string[] {""} ;
         BC000111_A4EmpleadoDireccion = new string[] {""} ;
         BC000111_n4EmpleadoDireccion = new bool[] {false} ;
         BC000111_A5EmpleadoTelefono = new string[] {""} ;
         BC000111_n5EmpleadoTelefono = new bool[] {false} ;
         BC000111_A6EmpleadoEmail = new string[] {""} ;
         BC000111_n6EmpleadoEmail = new bool[] {false} ;
         BC000111_A7EmpleadoFch_Alta = new DateTime[] {DateTime.MinValue} ;
         BC000111_n7EmpleadoFch_Alta = new bool[] {false} ;
         BC000111_A8EmpleadoFcha_Mod = new DateTime[] {DateTime.MinValue} ;
         BC000111_n8EmpleadoFcha_Mod = new bool[] {false} ;
         BC000111_A9EmpleadoFch_Cad = new DateTime[] {DateTime.MinValue} ;
         BC000111_n9EmpleadoFch_Cad = new bool[] {false} ;
         BC000111_A10EmpleadoUsu_Alta = new string[] {""} ;
         BC000111_n10EmpleadoUsu_Alta = new bool[] {false} ;
         BC000111_A11EmpleadoUsu_Mod = new string[] {""} ;
         BC000111_n11EmpleadoUsu_Mod = new bool[] {false} ;
         BC000111_A12EmpleadoUso_Cad = new string[] {""} ;
         BC000111_n12EmpleadoUso_Cad = new bool[] {false} ;
         BC000111_A14parqueAtraccionNombre = new string[] {""} ;
         BC000111_A13parqueAtraccionId = new short[1] ;
         BC000111_n13parqueAtraccionId = new bool[] {false} ;
         i7EmpleadoFch_Alta = (DateTime)(DateTime.MinValue);
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.empleado_bc__default(),
            new Object[][] {
                new Object[] {
               BC00012_A1EmpleadoId, BC00012_A2EmpleadoNombre, BC00012_A3EmpleadoApellido, BC00012_A4EmpleadoDireccion, BC00012_n4EmpleadoDireccion, BC00012_A5EmpleadoTelefono, BC00012_n5EmpleadoTelefono, BC00012_A6EmpleadoEmail, BC00012_n6EmpleadoEmail, BC00012_A7EmpleadoFch_Alta,
               BC00012_n7EmpleadoFch_Alta, BC00012_A8EmpleadoFcha_Mod, BC00012_n8EmpleadoFcha_Mod, BC00012_A9EmpleadoFch_Cad, BC00012_n9EmpleadoFch_Cad, BC00012_A10EmpleadoUsu_Alta, BC00012_n10EmpleadoUsu_Alta, BC00012_A11EmpleadoUsu_Mod, BC00012_n11EmpleadoUsu_Mod, BC00012_A12EmpleadoUso_Cad,
               BC00012_n12EmpleadoUso_Cad, BC00012_A13parqueAtraccionId, BC00012_n13parqueAtraccionId
               }
               , new Object[] {
               BC00013_A1EmpleadoId, BC00013_A2EmpleadoNombre, BC00013_A3EmpleadoApellido, BC00013_A4EmpleadoDireccion, BC00013_n4EmpleadoDireccion, BC00013_A5EmpleadoTelefono, BC00013_n5EmpleadoTelefono, BC00013_A6EmpleadoEmail, BC00013_n6EmpleadoEmail, BC00013_A7EmpleadoFch_Alta,
               BC00013_n7EmpleadoFch_Alta, BC00013_A8EmpleadoFcha_Mod, BC00013_n8EmpleadoFcha_Mod, BC00013_A9EmpleadoFch_Cad, BC00013_n9EmpleadoFch_Cad, BC00013_A10EmpleadoUsu_Alta, BC00013_n10EmpleadoUsu_Alta, BC00013_A11EmpleadoUsu_Mod, BC00013_n11EmpleadoUsu_Mod, BC00013_A12EmpleadoUso_Cad,
               BC00013_n12EmpleadoUso_Cad, BC00013_A13parqueAtraccionId, BC00013_n13parqueAtraccionId
               }
               , new Object[] {
               BC00014_A14parqueAtraccionNombre
               }
               , new Object[] {
               BC00015_A1EmpleadoId, BC00015_A2EmpleadoNombre, BC00015_A3EmpleadoApellido, BC00015_A4EmpleadoDireccion, BC00015_n4EmpleadoDireccion, BC00015_A5EmpleadoTelefono, BC00015_n5EmpleadoTelefono, BC00015_A6EmpleadoEmail, BC00015_n6EmpleadoEmail, BC00015_A7EmpleadoFch_Alta,
               BC00015_n7EmpleadoFch_Alta, BC00015_A8EmpleadoFcha_Mod, BC00015_n8EmpleadoFcha_Mod, BC00015_A9EmpleadoFch_Cad, BC00015_n9EmpleadoFch_Cad, BC00015_A10EmpleadoUsu_Alta, BC00015_n10EmpleadoUsu_Alta, BC00015_A11EmpleadoUsu_Mod, BC00015_n11EmpleadoUsu_Mod, BC00015_A12EmpleadoUso_Cad,
               BC00015_n12EmpleadoUso_Cad, BC00015_A14parqueAtraccionNombre, BC00015_A13parqueAtraccionId, BC00015_n13parqueAtraccionId
               }
               , new Object[] {
               BC00016_A1EmpleadoId
               }
               , new Object[] {
               BC00017_A1EmpleadoId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               BC000110_A14parqueAtraccionNombre
               }
               , new Object[] {
               BC000111_A1EmpleadoId, BC000111_A2EmpleadoNombre, BC000111_A3EmpleadoApellido, BC000111_A4EmpleadoDireccion, BC000111_n4EmpleadoDireccion, BC000111_A5EmpleadoTelefono, BC000111_n5EmpleadoTelefono, BC000111_A6EmpleadoEmail, BC000111_n6EmpleadoEmail, BC000111_A7EmpleadoFch_Alta,
               BC000111_n7EmpleadoFch_Alta, BC000111_A8EmpleadoFcha_Mod, BC000111_n8EmpleadoFcha_Mod, BC000111_A9EmpleadoFch_Cad, BC000111_n9EmpleadoFch_Cad, BC000111_A10EmpleadoUsu_Alta, BC000111_n10EmpleadoUsu_Alta, BC000111_A11EmpleadoUsu_Mod, BC000111_n11EmpleadoUsu_Mod, BC000111_A12EmpleadoUso_Cad,
               BC000111_n12EmpleadoUso_Cad, BC000111_A14parqueAtraccionNombre, BC000111_A13parqueAtraccionId, BC000111_n13parqueAtraccionId
               }
            }
         );
         Z13parqueAtraccionId = 1;
         n13parqueAtraccionId = false;
         A13parqueAtraccionId = 1;
         n13parqueAtraccionId = false;
         i13parqueAtraccionId = 1;
         n13parqueAtraccionId = false;
         Z1EmpleadoId = 1;
         A1EmpleadoId = 1;
         Z7EmpleadoFch_Alta = (DateTime)(DateTime.MinValue);
         n7EmpleadoFch_Alta = false;
         A7EmpleadoFch_Alta = (DateTime)(DateTime.MinValue);
         n7EmpleadoFch_Alta = false;
         i7EmpleadoFch_Alta = (DateTime)(DateTime.MinValue);
         n7EmpleadoFch_Alta = false;
         Gx_date = DateTimeUtil.Today( context);
         INITTRN();
         /* Execute Start event if defined. */
         /* Execute user event: Start */
         E12012 ();
         standaloneNotModal( ) ;
      }

      private short AnyError ;
      private short Z1EmpleadoId ;
      private short A1EmpleadoId ;
      private short Z13parqueAtraccionId ;
      private short A13parqueAtraccionId ;
      private short Gx_BScreen ;
      private short RcdFound1 ;
      private short i13parqueAtraccionId ;
      private int trnEnded ;
      private string Gx_mode ;
      private string endTrnMsgTxt ;
      private string endTrnMsgCod ;
      private string Z5EmpleadoTelefono ;
      private string A5EmpleadoTelefono ;
      private string sMode1 ;
      private DateTime Z7EmpleadoFch_Alta ;
      private DateTime A7EmpleadoFch_Alta ;
      private DateTime Z8EmpleadoFcha_Mod ;
      private DateTime A8EmpleadoFcha_Mod ;
      private DateTime Z9EmpleadoFch_Cad ;
      private DateTime A9EmpleadoFch_Cad ;
      private DateTime i7EmpleadoFch_Alta ;
      private DateTime Gx_date ;
      private bool returnInSub ;
      private bool n13parqueAtraccionId ;
      private bool n7EmpleadoFch_Alta ;
      private bool n4EmpleadoDireccion ;
      private bool n5EmpleadoTelefono ;
      private bool n6EmpleadoEmail ;
      private bool n8EmpleadoFcha_Mod ;
      private bool n9EmpleadoFch_Cad ;
      private bool n10EmpleadoUsu_Alta ;
      private bool n11EmpleadoUsu_Mod ;
      private bool n12EmpleadoUso_Cad ;
      private bool Gx_longc ;
      private string Z2EmpleadoNombre ;
      private string A2EmpleadoNombre ;
      private string Z3EmpleadoApellido ;
      private string A3EmpleadoApellido ;
      private string Z4EmpleadoDireccion ;
      private string A4EmpleadoDireccion ;
      private string Z6EmpleadoEmail ;
      private string A6EmpleadoEmail ;
      private string Z10EmpleadoUsu_Alta ;
      private string A10EmpleadoUsu_Alta ;
      private string Z11EmpleadoUsu_Mod ;
      private string A11EmpleadoUsu_Mod ;
      private string Z12EmpleadoUso_Cad ;
      private string A12EmpleadoUso_Cad ;
      private string Z14parqueAtraccionNombre ;
      private string A14parqueAtraccionNombre ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private string[] BC00014_A14parqueAtraccionNombre ;
      private short[] BC00015_A1EmpleadoId ;
      private string[] BC00015_A2EmpleadoNombre ;
      private string[] BC00015_A3EmpleadoApellido ;
      private string[] BC00015_A4EmpleadoDireccion ;
      private bool[] BC00015_n4EmpleadoDireccion ;
      private string[] BC00015_A5EmpleadoTelefono ;
      private bool[] BC00015_n5EmpleadoTelefono ;
      private string[] BC00015_A6EmpleadoEmail ;
      private bool[] BC00015_n6EmpleadoEmail ;
      private DateTime[] BC00015_A7EmpleadoFch_Alta ;
      private bool[] BC00015_n7EmpleadoFch_Alta ;
      private DateTime[] BC00015_A8EmpleadoFcha_Mod ;
      private bool[] BC00015_n8EmpleadoFcha_Mod ;
      private DateTime[] BC00015_A9EmpleadoFch_Cad ;
      private bool[] BC00015_n9EmpleadoFch_Cad ;
      private string[] BC00015_A10EmpleadoUsu_Alta ;
      private bool[] BC00015_n10EmpleadoUsu_Alta ;
      private string[] BC00015_A11EmpleadoUsu_Mod ;
      private bool[] BC00015_n11EmpleadoUsu_Mod ;
      private string[] BC00015_A12EmpleadoUso_Cad ;
      private bool[] BC00015_n12EmpleadoUso_Cad ;
      private string[] BC00015_A14parqueAtraccionNombre ;
      private short[] BC00015_A13parqueAtraccionId ;
      private bool[] BC00015_n13parqueAtraccionId ;
      private short[] BC00016_A1EmpleadoId ;
      private short[] BC00013_A1EmpleadoId ;
      private string[] BC00013_A2EmpleadoNombre ;
      private string[] BC00013_A3EmpleadoApellido ;
      private string[] BC00013_A4EmpleadoDireccion ;
      private bool[] BC00013_n4EmpleadoDireccion ;
      private string[] BC00013_A5EmpleadoTelefono ;
      private bool[] BC00013_n5EmpleadoTelefono ;
      private string[] BC00013_A6EmpleadoEmail ;
      private bool[] BC00013_n6EmpleadoEmail ;
      private DateTime[] BC00013_A7EmpleadoFch_Alta ;
      private bool[] BC00013_n7EmpleadoFch_Alta ;
      private DateTime[] BC00013_A8EmpleadoFcha_Mod ;
      private bool[] BC00013_n8EmpleadoFcha_Mod ;
      private DateTime[] BC00013_A9EmpleadoFch_Cad ;
      private bool[] BC00013_n9EmpleadoFch_Cad ;
      private string[] BC00013_A10EmpleadoUsu_Alta ;
      private bool[] BC00013_n10EmpleadoUsu_Alta ;
      private string[] BC00013_A11EmpleadoUsu_Mod ;
      private bool[] BC00013_n11EmpleadoUsu_Mod ;
      private string[] BC00013_A12EmpleadoUso_Cad ;
      private bool[] BC00013_n12EmpleadoUso_Cad ;
      private short[] BC00013_A13parqueAtraccionId ;
      private bool[] BC00013_n13parqueAtraccionId ;
      private short[] BC00012_A1EmpleadoId ;
      private string[] BC00012_A2EmpleadoNombre ;
      private string[] BC00012_A3EmpleadoApellido ;
      private string[] BC00012_A4EmpleadoDireccion ;
      private bool[] BC00012_n4EmpleadoDireccion ;
      private string[] BC00012_A5EmpleadoTelefono ;
      private bool[] BC00012_n5EmpleadoTelefono ;
      private string[] BC00012_A6EmpleadoEmail ;
      private bool[] BC00012_n6EmpleadoEmail ;
      private DateTime[] BC00012_A7EmpleadoFch_Alta ;
      private bool[] BC00012_n7EmpleadoFch_Alta ;
      private DateTime[] BC00012_A8EmpleadoFcha_Mod ;
      private bool[] BC00012_n8EmpleadoFcha_Mod ;
      private DateTime[] BC00012_A9EmpleadoFch_Cad ;
      private bool[] BC00012_n9EmpleadoFch_Cad ;
      private string[] BC00012_A10EmpleadoUsu_Alta ;
      private bool[] BC00012_n10EmpleadoUsu_Alta ;
      private string[] BC00012_A11EmpleadoUsu_Mod ;
      private bool[] BC00012_n11EmpleadoUsu_Mod ;
      private string[] BC00012_A12EmpleadoUso_Cad ;
      private bool[] BC00012_n12EmpleadoUso_Cad ;
      private short[] BC00012_A13parqueAtraccionId ;
      private bool[] BC00012_n13parqueAtraccionId ;
      private short[] BC00017_A1EmpleadoId ;
      private string[] BC000110_A14parqueAtraccionNombre ;
      private short[] BC000111_A1EmpleadoId ;
      private string[] BC000111_A2EmpleadoNombre ;
      private string[] BC000111_A3EmpleadoApellido ;
      private string[] BC000111_A4EmpleadoDireccion ;
      private bool[] BC000111_n4EmpleadoDireccion ;
      private string[] BC000111_A5EmpleadoTelefono ;
      private bool[] BC000111_n5EmpleadoTelefono ;
      private string[] BC000111_A6EmpleadoEmail ;
      private bool[] BC000111_n6EmpleadoEmail ;
      private DateTime[] BC000111_A7EmpleadoFch_Alta ;
      private bool[] BC000111_n7EmpleadoFch_Alta ;
      private DateTime[] BC000111_A8EmpleadoFcha_Mod ;
      private bool[] BC000111_n8EmpleadoFcha_Mod ;
      private DateTime[] BC000111_A9EmpleadoFch_Cad ;
      private bool[] BC000111_n9EmpleadoFch_Cad ;
      private string[] BC000111_A10EmpleadoUsu_Alta ;
      private bool[] BC000111_n10EmpleadoUsu_Alta ;
      private string[] BC000111_A11EmpleadoUsu_Mod ;
      private bool[] BC000111_n11EmpleadoUsu_Mod ;
      private string[] BC000111_A12EmpleadoUso_Cad ;
      private bool[] BC000111_n12EmpleadoUso_Cad ;
      private string[] BC000111_A14parqueAtraccionNombre ;
      private short[] BC000111_A13parqueAtraccionId ;
      private bool[] BC000111_n13parqueAtraccionId ;
      private SdtEmpleado bcEmpleado ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
   }

   public class empleado_bc__default : DataStoreHelperBase, IDataStoreHelper
   {
      public ICursor[] getCursors( )
      {
         cursorDefinitions();
         return new Cursor[] {
          new ForEachCursor(def[0])
         ,new ForEachCursor(def[1])
         ,new ForEachCursor(def[2])
         ,new ForEachCursor(def[3])
         ,new ForEachCursor(def[4])
         ,new ForEachCursor(def[5])
         ,new UpdateCursor(def[6])
         ,new UpdateCursor(def[7])
         ,new ForEachCursor(def[8])
         ,new ForEachCursor(def[9])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmBC00012;
          prmBC00012 = new Object[] {
          new ParDef("@EmpleadoId",GXType.Int16,4,0)
          };
          Object[] prmBC00013;
          prmBC00013 = new Object[] {
          new ParDef("@EmpleadoId",GXType.Int16,4,0)
          };
          Object[] prmBC00014;
          prmBC00014 = new Object[] {
          new ParDef("@parqueAtraccionId",GXType.Int16,4,0){Nullable=true}
          };
          Object[] prmBC00015;
          prmBC00015 = new Object[] {
          new ParDef("@EmpleadoId",GXType.Int16,4,0)
          };
          Object[] prmBC00016;
          prmBC00016 = new Object[] {
          new ParDef("@EmpleadoId",GXType.Int16,4,0)
          };
          Object[] prmBC00017;
          prmBC00017 = new Object[] {
          new ParDef("@EmpleadoNombre",GXType.NVarChar,1024,0) ,
          new ParDef("@EmpleadoApellido",GXType.NVarChar,1024,0) ,
          new ParDef("@EmpleadoDireccion",GXType.NVarChar,1024,0){Nullable=true} ,
          new ParDef("@EmpleadoTelefono",GXType.NChar,20,0){Nullable=true} ,
          new ParDef("@EmpleadoEmail",GXType.NVarChar,100,0){Nullable=true} ,
          new ParDef("@EmpleadoFch_Alta",GXType.DateTime,8,5){Nullable=true} ,
          new ParDef("@EmpleadoFcha_Mod",GXType.DateTime,8,5){Nullable=true} ,
          new ParDef("@EmpleadoFch_Cad",GXType.DateTime,8,5){Nullable=true} ,
          new ParDef("@EmpleadoUsu_Alta",GXType.NVarChar,40,0){Nullable=true} ,
          new ParDef("@EmpleadoUsu_Mod",GXType.NVarChar,40,0){Nullable=true} ,
          new ParDef("@EmpleadoUso_Cad",GXType.NVarChar,40,0){Nullable=true} ,
          new ParDef("@parqueAtraccionId",GXType.Int16,4,0){Nullable=true}
          };
          Object[] prmBC00018;
          prmBC00018 = new Object[] {
          new ParDef("@EmpleadoNombre",GXType.NVarChar,1024,0) ,
          new ParDef("@EmpleadoApellido",GXType.NVarChar,1024,0) ,
          new ParDef("@EmpleadoDireccion",GXType.NVarChar,1024,0){Nullable=true} ,
          new ParDef("@EmpleadoTelefono",GXType.NChar,20,0){Nullable=true} ,
          new ParDef("@EmpleadoEmail",GXType.NVarChar,100,0){Nullable=true} ,
          new ParDef("@EmpleadoFch_Alta",GXType.DateTime,8,5){Nullable=true} ,
          new ParDef("@EmpleadoFcha_Mod",GXType.DateTime,8,5){Nullable=true} ,
          new ParDef("@EmpleadoFch_Cad",GXType.DateTime,8,5){Nullable=true} ,
          new ParDef("@EmpleadoUsu_Alta",GXType.NVarChar,40,0){Nullable=true} ,
          new ParDef("@EmpleadoUsu_Mod",GXType.NVarChar,40,0){Nullable=true} ,
          new ParDef("@EmpleadoUso_Cad",GXType.NVarChar,40,0){Nullable=true} ,
          new ParDef("@parqueAtraccionId",GXType.Int16,4,0){Nullable=true} ,
          new ParDef("@EmpleadoId",GXType.Int16,4,0)
          };
          Object[] prmBC00019;
          prmBC00019 = new Object[] {
          new ParDef("@EmpleadoId",GXType.Int16,4,0)
          };
          Object[] prmBC000110;
          prmBC000110 = new Object[] {
          new ParDef("@parqueAtraccionId",GXType.Int16,4,0){Nullable=true}
          };
          Object[] prmBC000111;
          prmBC000111 = new Object[] {
          new ParDef("@EmpleadoId",GXType.Int16,4,0)
          };
          def= new CursorDef[] {
              new CursorDef("BC00012", "SELECT [EmpleadoId], [EmpleadoNombre], [EmpleadoApellido], [EmpleadoDireccion], [EmpleadoTelefono], [EmpleadoEmail], [EmpleadoFch_Alta], [EmpleadoFcha_Mod], [EmpleadoFch_Cad], [EmpleadoUsu_Alta], [EmpleadoUsu_Mod], [EmpleadoUso_Cad], [parqueAtraccionId] FROM [Empleado] WITH (UPDLOCK) WHERE [EmpleadoId] = @EmpleadoId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC00012,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC00013", "SELECT [EmpleadoId], [EmpleadoNombre], [EmpleadoApellido], [EmpleadoDireccion], [EmpleadoTelefono], [EmpleadoEmail], [EmpleadoFch_Alta], [EmpleadoFcha_Mod], [EmpleadoFch_Cad], [EmpleadoUsu_Alta], [EmpleadoUsu_Mod], [EmpleadoUso_Cad], [parqueAtraccionId] FROM [Empleado] WHERE [EmpleadoId] = @EmpleadoId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC00013,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC00014", "SELECT [parqueAtraccionNombre] FROM [parqueAtraccion] WHERE [parqueAtraccionId] = @parqueAtraccionId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC00014,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC00015", "SELECT TM1.[EmpleadoId], TM1.[EmpleadoNombre], TM1.[EmpleadoApellido], TM1.[EmpleadoDireccion], TM1.[EmpleadoTelefono], TM1.[EmpleadoEmail], TM1.[EmpleadoFch_Alta], TM1.[EmpleadoFcha_Mod], TM1.[EmpleadoFch_Cad], TM1.[EmpleadoUsu_Alta], TM1.[EmpleadoUsu_Mod], TM1.[EmpleadoUso_Cad], T2.[parqueAtraccionNombre], TM1.[parqueAtraccionId] FROM ([Empleado] TM1 LEFT JOIN [parqueAtraccion] T2 ON T2.[parqueAtraccionId] = TM1.[parqueAtraccionId]) WHERE TM1.[EmpleadoId] = @EmpleadoId ORDER BY TM1.[EmpleadoId]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmBC00015,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC00016", "SELECT [EmpleadoId] FROM [Empleado] WHERE [EmpleadoId] = @EmpleadoId  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmBC00016,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC00017", "INSERT INTO [Empleado]([EmpleadoNombre], [EmpleadoApellido], [EmpleadoDireccion], [EmpleadoTelefono], [EmpleadoEmail], [EmpleadoFch_Alta], [EmpleadoFcha_Mod], [EmpleadoFch_Cad], [EmpleadoUsu_Alta], [EmpleadoUsu_Mod], [EmpleadoUso_Cad], [parqueAtraccionId]) VALUES(@EmpleadoNombre, @EmpleadoApellido, @EmpleadoDireccion, @EmpleadoTelefono, @EmpleadoEmail, @EmpleadoFch_Alta, @EmpleadoFcha_Mod, @EmpleadoFch_Cad, @EmpleadoUsu_Alta, @EmpleadoUsu_Mod, @EmpleadoUso_Cad, @parqueAtraccionId); SELECT SCOPE_IDENTITY()",true, GxErrorMask.GX_NOMASK, false, this,prmBC00017,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("BC00018", "UPDATE [Empleado] SET [EmpleadoNombre]=@EmpleadoNombre, [EmpleadoApellido]=@EmpleadoApellido, [EmpleadoDireccion]=@EmpleadoDireccion, [EmpleadoTelefono]=@EmpleadoTelefono, [EmpleadoEmail]=@EmpleadoEmail, [EmpleadoFch_Alta]=@EmpleadoFch_Alta, [EmpleadoFcha_Mod]=@EmpleadoFcha_Mod, [EmpleadoFch_Cad]=@EmpleadoFch_Cad, [EmpleadoUsu_Alta]=@EmpleadoUsu_Alta, [EmpleadoUsu_Mod]=@EmpleadoUsu_Mod, [EmpleadoUso_Cad]=@EmpleadoUso_Cad, [parqueAtraccionId]=@parqueAtraccionId  WHERE [EmpleadoId] = @EmpleadoId", GxErrorMask.GX_NOMASK,prmBC00018)
             ,new CursorDef("BC00019", "DELETE FROM [Empleado]  WHERE [EmpleadoId] = @EmpleadoId", GxErrorMask.GX_NOMASK,prmBC00019)
             ,new CursorDef("BC000110", "SELECT [parqueAtraccionNombre] FROM [parqueAtraccion] WHERE [parqueAtraccionId] = @parqueAtraccionId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000110,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC000111", "SELECT TM1.[EmpleadoId], TM1.[EmpleadoNombre], TM1.[EmpleadoApellido], TM1.[EmpleadoDireccion], TM1.[EmpleadoTelefono], TM1.[EmpleadoEmail], TM1.[EmpleadoFch_Alta], TM1.[EmpleadoFcha_Mod], TM1.[EmpleadoFch_Cad], TM1.[EmpleadoUsu_Alta], TM1.[EmpleadoUsu_Mod], TM1.[EmpleadoUso_Cad], T2.[parqueAtraccionNombre], TM1.[parqueAtraccionId] FROM ([Empleado] TM1 LEFT JOIN [parqueAtraccion] T2 ON T2.[parqueAtraccionId] = TM1.[parqueAtraccionId]) WHERE TM1.[EmpleadoId] = @EmpleadoId ORDER BY TM1.[EmpleadoId]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmBC000111,100, GxCacheFrequency.OFF ,true,false )
          };
       }
    }

    public void getResults( int cursor ,
                            IFieldGetter rslt ,
                            Object[] buf )
    {
       switch ( cursor )
       {
             case 0 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((string[]) buf[2])[0] = rslt.getVarchar(3);
                ((string[]) buf[3])[0] = rslt.getVarchar(4);
                ((bool[]) buf[4])[0] = rslt.wasNull(4);
                ((string[]) buf[5])[0] = rslt.getString(5, 20);
                ((bool[]) buf[6])[0] = rslt.wasNull(5);
                ((string[]) buf[7])[0] = rslt.getVarchar(6);
                ((bool[]) buf[8])[0] = rslt.wasNull(6);
                ((DateTime[]) buf[9])[0] = rslt.getGXDateTime(7);
                ((bool[]) buf[10])[0] = rslt.wasNull(7);
                ((DateTime[]) buf[11])[0] = rslt.getGXDateTime(8);
                ((bool[]) buf[12])[0] = rslt.wasNull(8);
                ((DateTime[]) buf[13])[0] = rslt.getGXDateTime(9);
                ((bool[]) buf[14])[0] = rslt.wasNull(9);
                ((string[]) buf[15])[0] = rslt.getVarchar(10);
                ((bool[]) buf[16])[0] = rslt.wasNull(10);
                ((string[]) buf[17])[0] = rslt.getVarchar(11);
                ((bool[]) buf[18])[0] = rslt.wasNull(11);
                ((string[]) buf[19])[0] = rslt.getVarchar(12);
                ((bool[]) buf[20])[0] = rslt.wasNull(12);
                ((short[]) buf[21])[0] = rslt.getShort(13);
                ((bool[]) buf[22])[0] = rslt.wasNull(13);
                return;
             case 1 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((string[]) buf[2])[0] = rslt.getVarchar(3);
                ((string[]) buf[3])[0] = rslt.getVarchar(4);
                ((bool[]) buf[4])[0] = rslt.wasNull(4);
                ((string[]) buf[5])[0] = rslt.getString(5, 20);
                ((bool[]) buf[6])[0] = rslt.wasNull(5);
                ((string[]) buf[7])[0] = rslt.getVarchar(6);
                ((bool[]) buf[8])[0] = rslt.wasNull(6);
                ((DateTime[]) buf[9])[0] = rslt.getGXDateTime(7);
                ((bool[]) buf[10])[0] = rslt.wasNull(7);
                ((DateTime[]) buf[11])[0] = rslt.getGXDateTime(8);
                ((bool[]) buf[12])[0] = rslt.wasNull(8);
                ((DateTime[]) buf[13])[0] = rslt.getGXDateTime(9);
                ((bool[]) buf[14])[0] = rslt.wasNull(9);
                ((string[]) buf[15])[0] = rslt.getVarchar(10);
                ((bool[]) buf[16])[0] = rslt.wasNull(10);
                ((string[]) buf[17])[0] = rslt.getVarchar(11);
                ((bool[]) buf[18])[0] = rslt.wasNull(11);
                ((string[]) buf[19])[0] = rslt.getVarchar(12);
                ((bool[]) buf[20])[0] = rslt.wasNull(12);
                ((short[]) buf[21])[0] = rslt.getShort(13);
                ((bool[]) buf[22])[0] = rslt.wasNull(13);
                return;
             case 2 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                return;
             case 3 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((string[]) buf[2])[0] = rslt.getVarchar(3);
                ((string[]) buf[3])[0] = rslt.getVarchar(4);
                ((bool[]) buf[4])[0] = rslt.wasNull(4);
                ((string[]) buf[5])[0] = rslt.getString(5, 20);
                ((bool[]) buf[6])[0] = rslt.wasNull(5);
                ((string[]) buf[7])[0] = rslt.getVarchar(6);
                ((bool[]) buf[8])[0] = rslt.wasNull(6);
                ((DateTime[]) buf[9])[0] = rslt.getGXDateTime(7);
                ((bool[]) buf[10])[0] = rslt.wasNull(7);
                ((DateTime[]) buf[11])[0] = rslt.getGXDateTime(8);
                ((bool[]) buf[12])[0] = rslt.wasNull(8);
                ((DateTime[]) buf[13])[0] = rslt.getGXDateTime(9);
                ((bool[]) buf[14])[0] = rslt.wasNull(9);
                ((string[]) buf[15])[0] = rslt.getVarchar(10);
                ((bool[]) buf[16])[0] = rslt.wasNull(10);
                ((string[]) buf[17])[0] = rslt.getVarchar(11);
                ((bool[]) buf[18])[0] = rslt.wasNull(11);
                ((string[]) buf[19])[0] = rslt.getVarchar(12);
                ((bool[]) buf[20])[0] = rslt.wasNull(12);
                ((string[]) buf[21])[0] = rslt.getVarchar(13);
                ((short[]) buf[22])[0] = rslt.getShort(14);
                ((bool[]) buf[23])[0] = rslt.wasNull(14);
                return;
             case 4 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                return;
             case 5 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                return;
             case 8 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                return;
             case 9 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((string[]) buf[2])[0] = rslt.getVarchar(3);
                ((string[]) buf[3])[0] = rslt.getVarchar(4);
                ((bool[]) buf[4])[0] = rslt.wasNull(4);
                ((string[]) buf[5])[0] = rslt.getString(5, 20);
                ((bool[]) buf[6])[0] = rslt.wasNull(5);
                ((string[]) buf[7])[0] = rslt.getVarchar(6);
                ((bool[]) buf[8])[0] = rslt.wasNull(6);
                ((DateTime[]) buf[9])[0] = rslt.getGXDateTime(7);
                ((bool[]) buf[10])[0] = rslt.wasNull(7);
                ((DateTime[]) buf[11])[0] = rslt.getGXDateTime(8);
                ((bool[]) buf[12])[0] = rslt.wasNull(8);
                ((DateTime[]) buf[13])[0] = rslt.getGXDateTime(9);
                ((bool[]) buf[14])[0] = rslt.wasNull(9);
                ((string[]) buf[15])[0] = rslt.getVarchar(10);
                ((bool[]) buf[16])[0] = rslt.wasNull(10);
                ((string[]) buf[17])[0] = rslt.getVarchar(11);
                ((bool[]) buf[18])[0] = rslt.wasNull(11);
                ((string[]) buf[19])[0] = rslt.getVarchar(12);
                ((bool[]) buf[20])[0] = rslt.wasNull(12);
                ((string[]) buf[21])[0] = rslt.getVarchar(13);
                ((short[]) buf[22])[0] = rslt.getShort(14);
                ((bool[]) buf[23])[0] = rslt.wasNull(14);
                return;
       }
    }

 }

}
