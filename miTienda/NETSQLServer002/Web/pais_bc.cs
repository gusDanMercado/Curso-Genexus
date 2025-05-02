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
   public class pais_bc : GxSilentTrn, IGxSilentTrn
   {
      public pais_bc( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("miTienda", true);
      }

      public pais_bc( IGxContext context )
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
               Z1PaisID = A1PaisID;
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
         if ( ( GX_JID == 3 ) || ( GX_JID == 0 ) )
         {
            Z2PaisNombre = A2PaisNombre;
         }
         if ( GX_JID == -3 )
         {
            Z1PaisID = A1PaisID;
            Z2PaisNombre = A2PaisNombre;
            Z3PaisBandera = A3PaisBandera;
            Z40000PaisBandera_GXI = A40000PaisBandera_GXI;
         }
      }

      protected void standaloneNotModal( )
      {
         Gx_BScreen = 0;
      }

      protected void standaloneModal( )
      {
         if ( IsIns( )  && (0==A1PaisID) && ( Gx_BScreen == 0 ) )
         {
            A1PaisID = 1;
         }
      }

      protected void Load011( )
      {
         /* Using cursor BC00014 */
         pr_default.execute(2, new Object[] {A1PaisID});
         if ( (pr_default.getStatus(2) != 101) )
         {
            RcdFound1 = 1;
            A2PaisNombre = BC00014_A2PaisNombre[0];
            A40000PaisBandera_GXI = BC00014_A40000PaisBandera_GXI[0];
            A3PaisBandera = BC00014_A3PaisBandera[0];
            ZM011( -3) ;
         }
         pr_default.close(2);
         OnLoadActions011( ) ;
      }

      protected void OnLoadActions011( )
      {
      }

      protected void CheckExtendedTable011( )
      {
         standaloneModal( ) ;
         /* Using cursor BC00015 */
         pr_default.execute(3, new Object[] {A2PaisNombre, A1PaisID});
         if ( (pr_default.getStatus(3) != 101) )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_1004", new   object[]  {"Pais Nombre"}), 1, "");
            AnyError = 1;
         }
         pr_default.close(3);
         if ( String.IsNullOrEmpty(StringUtil.RTrim( A2PaisNombre)) )
         {
            GX_msglist.addItem("Error, El nombre del Pais es obligatorio!!!", 1, "");
            AnyError = 1;
         }
      }

      protected void CloseExtendedTableCursors011( )
      {
      }

      protected void enableDisable( )
      {
      }

      protected void GetKey011( )
      {
         /* Using cursor BC00016 */
         pr_default.execute(4, new Object[] {A1PaisID});
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
         pr_default.execute(1, new Object[] {A1PaisID});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM011( 3) ;
            RcdFound1 = 1;
            A1PaisID = BC00013_A1PaisID[0];
            A2PaisNombre = BC00013_A2PaisNombre[0];
            A40000PaisBandera_GXI = BC00013_A40000PaisBandera_GXI[0];
            A3PaisBandera = BC00013_A3PaisBandera[0];
            Z1PaisID = A1PaisID;
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
            pr_default.execute(0, new Object[] {A1PaisID});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Pais"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(0) == 101) || ( StringUtil.StrCmp(Z2PaisNombre, BC00012_A2PaisNombre[0]) != 0 ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"Pais"}), "RecordWasChanged", 1, "");
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
                     pr_default.execute(5, new Object[] {A2PaisNombre, A3PaisBandera, A40000PaisBandera_GXI});
                     A1PaisID = BC00017_A1PaisID[0];
                     pr_default.close(5);
                     pr_default.SmartCacheProvider.SetUpdated("Pais");
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
                     pr_default.execute(6, new Object[] {A2PaisNombre, A1PaisID});
                     pr_default.close(6);
                     pr_default.SmartCacheProvider.SetUpdated("Pais");
                     if ( (pr_default.getStatus(6) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Pais"}), "RecordIsLocked", 1, "");
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
         if ( AnyError == 0 )
         {
            /* Using cursor BC00019 */
            pr_default.execute(7, new Object[] {A3PaisBandera, A40000PaisBandera_GXI, A1PaisID});
            pr_default.close(7);
            pr_default.SmartCacheProvider.SetUpdated("Pais");
         }
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
                  /* Using cursor BC000110 */
                  pr_default.execute(8, new Object[] {A1PaisID});
                  pr_default.close(8);
                  pr_default.SmartCacheProvider.SetUpdated("Pais");
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
         /* No delete mode formulas found. */
         if ( AnyError == 0 )
         {
            /* Using cursor BC000111 */
            pr_default.execute(9, new Object[] {A1PaisID});
            if ( (pr_default.getStatus(9) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Producto"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(9);
            /* Using cursor BC000112 */
            pr_default.execute(10, new Object[] {A1PaisID});
            if ( (pr_default.getStatus(10) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Cliente"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(10);
            /* Using cursor BC000113 */
            pr_default.execute(11, new Object[] {A1PaisID});
            if ( (pr_default.getStatus(11) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Vendedor"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(11);
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
         /* Using cursor BC000114 */
         pr_default.execute(12, new Object[] {A1PaisID});
         RcdFound1 = 0;
         if ( (pr_default.getStatus(12) != 101) )
         {
            RcdFound1 = 1;
            A1PaisID = BC000114_A1PaisID[0];
            A2PaisNombre = BC000114_A2PaisNombre[0];
            A40000PaisBandera_GXI = BC000114_A40000PaisBandera_GXI[0];
            A3PaisBandera = BC000114_A3PaisBandera[0];
         }
         /* Load Subordinate Levels */
      }

      protected void ScanKeyNext011( )
      {
         /* Scan next routine */
         pr_default.readNext(12);
         RcdFound1 = 0;
         ScanKeyLoad011( ) ;
      }

      protected void ScanKeyLoad011( )
      {
         sMode1 = Gx_mode;
         Gx_mode = "DSP";
         if ( (pr_default.getStatus(12) != 101) )
         {
            RcdFound1 = 1;
            A1PaisID = BC000114_A1PaisID[0];
            A2PaisNombre = BC000114_A2PaisNombre[0];
            A40000PaisBandera_GXI = BC000114_A40000PaisBandera_GXI[0];
            A3PaisBandera = BC000114_A3PaisBandera[0];
         }
         Gx_mode = sMode1;
      }

      protected void ScanKeyEnd011( )
      {
         pr_default.close(12);
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
         VarsToRow1( bcPais) ;
      }

      protected void ReadRow011( )
      {
         RowToVars1( bcPais, 1) ;
      }

      protected void InitializeNonKey011( )
      {
         A2PaisNombre = "";
         A3PaisBandera = "";
         A40000PaisBandera_GXI = "";
         Z2PaisNombre = "";
      }

      protected void InitAll011( )
      {
         A1PaisID = 1;
         InitializeNonKey011( ) ;
      }

      protected void StandaloneModalInsert( )
      {
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

      public void VarsToRow1( SdtPais obj1 )
      {
         obj1.gxTpr_Mode = Gx_mode;
         obj1.gxTpr_Paisnombre = A2PaisNombre;
         obj1.gxTpr_Paisbandera = A3PaisBandera;
         obj1.gxTpr_Paisbandera_gxi = A40000PaisBandera_GXI;
         obj1.gxTpr_Paisid = A1PaisID;
         obj1.gxTpr_Paisid_Z = Z1PaisID;
         obj1.gxTpr_Paisnombre_Z = Z2PaisNombre;
         obj1.gxTpr_Paisbandera_gxi_Z = Z40000PaisBandera_GXI;
         obj1.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void KeyVarsToRow1( SdtPais obj1 )
      {
         obj1.gxTpr_Paisid = A1PaisID;
         return  ;
      }

      public void RowToVars1( SdtPais obj1 ,
                              int forceLoad )
      {
         Gx_mode = obj1.gxTpr_Mode;
         A2PaisNombre = obj1.gxTpr_Paisnombre;
         A3PaisBandera = obj1.gxTpr_Paisbandera;
         A40000PaisBandera_GXI = obj1.gxTpr_Paisbandera_gxi;
         A1PaisID = obj1.gxTpr_Paisid;
         Z1PaisID = obj1.gxTpr_Paisid_Z;
         Z2PaisNombre = obj1.gxTpr_Paisnombre_Z;
         Z40000PaisBandera_GXI = obj1.gxTpr_Paisbandera_gxi_Z;
         Gx_mode = obj1.gxTpr_Mode;
         return  ;
      }

      public void LoadKey( Object[] obj )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         A1PaisID = (int)getParm(obj,0);
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
            Z1PaisID = A1PaisID;
         }
         ZM011( -3) ;
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
         RowToVars1( bcPais, 0) ;
         ScanKeyStart011( ) ;
         if ( RcdFound1 == 0 )
         {
            Gx_mode = "INS";
         }
         else
         {
            Gx_mode = "UPD";
            Z1PaisID = A1PaisID;
         }
         ZM011( -3) ;
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
               if ( A1PaisID != Z1PaisID )
               {
                  A1PaisID = Z1PaisID;
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
                  if ( A1PaisID != Z1PaisID )
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
         RowToVars1( bcPais, 1) ;
         SaveImpl( ) ;
         VarsToRow1( bcPais) ;
         context.GX_msglist = BackMsgLst;
         return  ;
      }

      public bool Insert( )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         RowToVars1( bcPais, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert011( ) ;
         AfterTrn( ) ;
         VarsToRow1( bcPais) ;
         context.GX_msglist = BackMsgLst;
         return (AnyError==0) ;
      }

      protected void UpdateImpl( )
      {
         if ( IsUpd( ) )
         {
            SaveImpl( ) ;
            VarsToRow1( bcPais) ;
         }
         else
         {
            SdtPais auxBC = new SdtPais(context);
            IGxSilentTrn auxTrn = auxBC.getTransaction();
            auxBC.Load(A1PaisID);
            if ( auxTrn.Errors() == 0 )
            {
               auxBC.UpdateDirties(bcPais);
               auxBC.Save();
               bcPais.Copy((GxSilentTrnSdt)(auxBC));
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
         RowToVars1( bcPais, 1) ;
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
         RowToVars1( bcPais, 1) ;
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
               VarsToRow1( bcPais) ;
            }
         }
         else
         {
            AfterTrn( ) ;
            VarsToRow1( bcPais) ;
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
         RowToVars1( bcPais, 0) ;
         GetKey011( ) ;
         if ( RcdFound1 == 1 )
         {
            if ( IsIns( ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_noupdate", ""), "DuplicatePrimaryKey", 1, "");
               AnyError = 1;
            }
            else if ( A1PaisID != Z1PaisID )
            {
               A1PaisID = Z1PaisID;
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
            if ( A1PaisID != Z1PaisID )
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
         context.RollbackDataStores("pais_bc",pr_default);
         VarsToRow1( bcPais) ;
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
         Gx_mode = bcPais.gxTpr_Mode;
         return Gx_mode ;
      }

      public void SetMode( string lMode )
      {
         Gx_mode = lMode;
         bcPais.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void SetSDT( GxSilentTrnSdt sdt ,
                          short sdtToBc )
      {
         if ( sdt != bcPais )
         {
            bcPais = (SdtPais)(sdt);
            if ( StringUtil.StrCmp(bcPais.gxTpr_Mode, "") == 0 )
            {
               bcPais.gxTpr_Mode = "INS";
            }
            if ( sdtToBc == 1 )
            {
               VarsToRow1( bcPais) ;
            }
            else
            {
               RowToVars1( bcPais, 1) ;
            }
         }
         else
         {
            if ( StringUtil.StrCmp(bcPais.gxTpr_Mode, "") == 0 )
            {
               bcPais.gxTpr_Mode = "INS";
            }
         }
         return  ;
      }

      public void ReloadFromSDT( )
      {
         RowToVars1( bcPais, 1) ;
         return  ;
      }

      public void ForceCommitOnExit( )
      {
         return  ;
      }

      public SdtPais Pais_BC
      {
         get {
            return bcPais ;
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
      }

      public override void initialize( )
      {
         Gx_mode = "";
         endTrnMsgTxt = "";
         endTrnMsgCod = "";
         Z2PaisNombre = "";
         A2PaisNombre = "";
         Z3PaisBandera = "";
         A3PaisBandera = "";
         Z40000PaisBandera_GXI = "";
         A40000PaisBandera_GXI = "";
         BC00014_A1PaisID = new int[1] ;
         BC00014_A2PaisNombre = new string[] {""} ;
         BC00014_A40000PaisBandera_GXI = new string[] {""} ;
         BC00014_A3PaisBandera = new string[] {""} ;
         BC00015_A2PaisNombre = new string[] {""} ;
         BC00016_A1PaisID = new int[1] ;
         BC00013_A1PaisID = new int[1] ;
         BC00013_A2PaisNombre = new string[] {""} ;
         BC00013_A40000PaisBandera_GXI = new string[] {""} ;
         BC00013_A3PaisBandera = new string[] {""} ;
         sMode1 = "";
         BC00012_A1PaisID = new int[1] ;
         BC00012_A2PaisNombre = new string[] {""} ;
         BC00012_A40000PaisBandera_GXI = new string[] {""} ;
         BC00012_A3PaisBandera = new string[] {""} ;
         BC00017_A1PaisID = new int[1] ;
         BC000111_A19ProductoID = new int[1] ;
         BC000112_A9ClienteID = new int[1] ;
         BC000113_A6VendedorID = new int[1] ;
         BC000114_A1PaisID = new int[1] ;
         BC000114_A2PaisNombre = new string[] {""} ;
         BC000114_A40000PaisBandera_GXI = new string[] {""} ;
         BC000114_A3PaisBandera = new string[] {""} ;
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.pais_bc__default(),
            new Object[][] {
                new Object[] {
               BC00012_A1PaisID, BC00012_A2PaisNombre, BC00012_A40000PaisBandera_GXI, BC00012_A3PaisBandera
               }
               , new Object[] {
               BC00013_A1PaisID, BC00013_A2PaisNombre, BC00013_A40000PaisBandera_GXI, BC00013_A3PaisBandera
               }
               , new Object[] {
               BC00014_A1PaisID, BC00014_A2PaisNombre, BC00014_A40000PaisBandera_GXI, BC00014_A3PaisBandera
               }
               , new Object[] {
               BC00015_A2PaisNombre
               }
               , new Object[] {
               BC00016_A1PaisID
               }
               , new Object[] {
               BC00017_A1PaisID
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               BC000111_A19ProductoID
               }
               , new Object[] {
               BC000112_A9ClienteID
               }
               , new Object[] {
               BC000113_A6VendedorID
               }
               , new Object[] {
               BC000114_A1PaisID, BC000114_A2PaisNombre, BC000114_A40000PaisBandera_GXI, BC000114_A3PaisBandera
               }
            }
         );
         Z1PaisID = 1;
         A1PaisID = 1;
         INITTRN();
         /* Execute Start event if defined. */
         /* Execute user event: Start */
         E12012 ();
         standaloneNotModal( ) ;
      }

      private short AnyError ;
      private short Gx_BScreen ;
      private short RcdFound1 ;
      private int trnEnded ;
      private int Z1PaisID ;
      private int A1PaisID ;
      private string Gx_mode ;
      private string endTrnMsgTxt ;
      private string endTrnMsgCod ;
      private string sMode1 ;
      private bool returnInSub ;
      private string Z2PaisNombre ;
      private string A2PaisNombre ;
      private string Z40000PaisBandera_GXI ;
      private string A40000PaisBandera_GXI ;
      private string Z3PaisBandera ;
      private string A3PaisBandera ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private int[] BC00014_A1PaisID ;
      private string[] BC00014_A2PaisNombre ;
      private string[] BC00014_A40000PaisBandera_GXI ;
      private string[] BC00014_A3PaisBandera ;
      private string[] BC00015_A2PaisNombre ;
      private int[] BC00016_A1PaisID ;
      private int[] BC00013_A1PaisID ;
      private string[] BC00013_A2PaisNombre ;
      private string[] BC00013_A40000PaisBandera_GXI ;
      private string[] BC00013_A3PaisBandera ;
      private int[] BC00012_A1PaisID ;
      private string[] BC00012_A2PaisNombre ;
      private string[] BC00012_A40000PaisBandera_GXI ;
      private string[] BC00012_A3PaisBandera ;
      private int[] BC00017_A1PaisID ;
      private int[] BC000111_A19ProductoID ;
      private int[] BC000112_A9ClienteID ;
      private int[] BC000113_A6VendedorID ;
      private int[] BC000114_A1PaisID ;
      private string[] BC000114_A2PaisNombre ;
      private string[] BC000114_A40000PaisBandera_GXI ;
      private string[] BC000114_A3PaisBandera ;
      private SdtPais bcPais ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
   }

   public class pais_bc__default : DataStoreHelperBase, IDataStoreHelper
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
         ,new UpdateCursor(def[8])
         ,new ForEachCursor(def[9])
         ,new ForEachCursor(def[10])
         ,new ForEachCursor(def[11])
         ,new ForEachCursor(def[12])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmBC00012;
          prmBC00012 = new Object[] {
          new ParDef("@PaisID",GXType.Int32,6,0)
          };
          Object[] prmBC00013;
          prmBC00013 = new Object[] {
          new ParDef("@PaisID",GXType.Int32,6,0)
          };
          Object[] prmBC00014;
          prmBC00014 = new Object[] {
          new ParDef("@PaisID",GXType.Int32,6,0)
          };
          Object[] prmBC00015;
          prmBC00015 = new Object[] {
          new ParDef("@PaisNombre",GXType.NVarChar,80,0) ,
          new ParDef("@PaisID",GXType.Int32,6,0)
          };
          Object[] prmBC00016;
          prmBC00016 = new Object[] {
          new ParDef("@PaisID",GXType.Int32,6,0)
          };
          Object[] prmBC00017;
          prmBC00017 = new Object[] {
          new ParDef("@PaisNombre",GXType.NVarChar,80,0) ,
          new ParDef("@PaisBandera",GXType.Blob,1024,0){InDB=false} ,
          new ParDef("@PaisBandera_GXI",GXType.VarChar,2048,0){AddAtt=true, ImgIdx=1, Tbl="Pais", Fld="PaisBandera"}
          };
          Object[] prmBC00018;
          prmBC00018 = new Object[] {
          new ParDef("@PaisNombre",GXType.NVarChar,80,0) ,
          new ParDef("@PaisID",GXType.Int32,6,0)
          };
          Object[] prmBC00019;
          prmBC00019 = new Object[] {
          new ParDef("@PaisBandera",GXType.Blob,1024,0){InDB=false} ,
          new ParDef("@PaisBandera_GXI",GXType.VarChar,2048,0){AddAtt=true, ImgIdx=0, Tbl="Pais", Fld="PaisBandera"} ,
          new ParDef("@PaisID",GXType.Int32,6,0)
          };
          Object[] prmBC000110;
          prmBC000110 = new Object[] {
          new ParDef("@PaisID",GXType.Int32,6,0)
          };
          Object[] prmBC000111;
          prmBC000111 = new Object[] {
          new ParDef("@PaisID",GXType.Int32,6,0)
          };
          Object[] prmBC000112;
          prmBC000112 = new Object[] {
          new ParDef("@PaisID",GXType.Int32,6,0)
          };
          Object[] prmBC000113;
          prmBC000113 = new Object[] {
          new ParDef("@PaisID",GXType.Int32,6,0)
          };
          Object[] prmBC000114;
          prmBC000114 = new Object[] {
          new ParDef("@PaisID",GXType.Int32,6,0)
          };
          def= new CursorDef[] {
              new CursorDef("BC00012", "SELECT [PaisID], [PaisNombre], [PaisBandera_GXI], [PaisBandera] FROM [Pais] WITH (UPDLOCK) WHERE [PaisID] = @PaisID ",true, GxErrorMask.GX_NOMASK, false, this,prmBC00012,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC00013", "SELECT [PaisID], [PaisNombre], [PaisBandera_GXI], [PaisBandera] FROM [Pais] WHERE [PaisID] = @PaisID ",true, GxErrorMask.GX_NOMASK, false, this,prmBC00013,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC00014", "SELECT TM1.[PaisID], TM1.[PaisNombre], TM1.[PaisBandera_GXI], TM1.[PaisBandera] FROM [Pais] TM1 WHERE TM1.[PaisID] = @PaisID ORDER BY TM1.[PaisID]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmBC00014,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC00015", "SELECT [PaisNombre] FROM [Pais] WHERE ([PaisNombre] = @PaisNombre) AND (Not ( [PaisID] = @PaisID)) ",true, GxErrorMask.GX_NOMASK, false, this,prmBC00015,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC00016", "SELECT [PaisID] FROM [Pais] WHERE [PaisID] = @PaisID  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmBC00016,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC00017", "INSERT INTO [Pais]([PaisNombre], [PaisBandera], [PaisBandera_GXI]) VALUES(@PaisNombre, @PaisBandera, @PaisBandera_GXI); SELECT SCOPE_IDENTITY()",true, GxErrorMask.GX_NOMASK, false, this,prmBC00017,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("BC00018", "UPDATE [Pais] SET [PaisNombre]=@PaisNombre  WHERE [PaisID] = @PaisID", GxErrorMask.GX_NOMASK,prmBC00018)
             ,new CursorDef("BC00019", "UPDATE [Pais] SET [PaisBandera]=@PaisBandera, [PaisBandera_GXI]=@PaisBandera_GXI  WHERE [PaisID] = @PaisID", GxErrorMask.GX_NOMASK,prmBC00019)
             ,new CursorDef("BC000110", "DELETE FROM [Pais]  WHERE [PaisID] = @PaisID", GxErrorMask.GX_NOMASK,prmBC000110)
             ,new CursorDef("BC000111", "SELECT TOP 1 [ProductoID] FROM [Producto] WHERE [ProductoPaisID] = @PaisID ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000111,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("BC000112", "SELECT TOP 1 [ClienteID] FROM [Cliente] WHERE [PaisID] = @PaisID ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000112,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("BC000113", "SELECT TOP 1 [VendedorID] FROM [Vendedor] WHERE [PaisID] = @PaisID ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000113,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("BC000114", "SELECT TM1.[PaisID], TM1.[PaisNombre], TM1.[PaisBandera_GXI], TM1.[PaisBandera] FROM [Pais] TM1 WHERE TM1.[PaisID] = @PaisID ORDER BY TM1.[PaisID]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmBC000114,100, GxCacheFrequency.OFF ,true,false )
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
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((string[]) buf[2])[0] = rslt.getMultimediaUri(3);
                ((string[]) buf[3])[0] = rslt.getMultimediaFile(4, rslt.getVarchar(3));
                return;
             case 1 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((string[]) buf[2])[0] = rslt.getMultimediaUri(3);
                ((string[]) buf[3])[0] = rslt.getMultimediaFile(4, rslt.getVarchar(3));
                return;
             case 2 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((string[]) buf[2])[0] = rslt.getMultimediaUri(3);
                ((string[]) buf[3])[0] = rslt.getMultimediaFile(4, rslt.getVarchar(3));
                return;
             case 3 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                return;
             case 4 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
             case 5 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
             case 9 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
             case 10 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
             case 11 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
             case 12 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((string[]) buf[2])[0] = rslt.getMultimediaUri(3);
                ((string[]) buf[3])[0] = rslt.getMultimediaFile(4, rslt.getVarchar(3));
                return;
       }
    }

 }

}
