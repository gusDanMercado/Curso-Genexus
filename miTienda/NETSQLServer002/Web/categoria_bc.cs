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
   public class categoria_bc : GxSilentTrn, IGxSilentTrn
   {
      public categoria_bc( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("miTienda", true);
      }

      public categoria_bc( IGxContext context )
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
         ReadRow022( ) ;
         standaloneNotModal( ) ;
         InitializeNonKey022( ) ;
         standaloneModal( ) ;
         AddRow022( ) ;
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
            E11022 ();
            trnEnded = 0;
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            if ( IsIns( )  )
            {
               Z4CategoriaID = A4CategoriaID;
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

      protected void CONFIRM_020( )
      {
         BeforeValidate022( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls022( ) ;
            }
            else
            {
               CheckExtendedTable022( ) ;
               if ( AnyError == 0 )
               {
               }
               CloseExtendedTableCursors022( ) ;
            }
         }
         if ( AnyError == 0 )
         {
         }
      }

      protected void E12022( )
      {
         /* Start Routine */
         returnInSub = false;
      }

      protected void E11022( )
      {
         /* After Trn Routine */
         returnInSub = false;
      }

      protected void ZM022( short GX_JID )
      {
         if ( ( GX_JID == 3 ) || ( GX_JID == 0 ) )
         {
            Z5CategoriaNombre = A5CategoriaNombre;
         }
         if ( GX_JID == -3 )
         {
            Z4CategoriaID = A4CategoriaID;
            Z5CategoriaNombre = A5CategoriaNombre;
         }
      }

      protected void standaloneNotModal( )
      {
         Gx_BScreen = 0;
      }

      protected void standaloneModal( )
      {
         if ( IsIns( )  && (0==A4CategoriaID) && ( Gx_BScreen == 0 ) )
         {
            A4CategoriaID = 1;
         }
      }

      protected void Load022( )
      {
         /* Using cursor BC00024 */
         pr_default.execute(2, new Object[] {A4CategoriaID});
         if ( (pr_default.getStatus(2) != 101) )
         {
            RcdFound2 = 1;
            A5CategoriaNombre = BC00024_A5CategoriaNombre[0];
            ZM022( -3) ;
         }
         pr_default.close(2);
         OnLoadActions022( ) ;
      }

      protected void OnLoadActions022( )
      {
      }

      protected void CheckExtendedTable022( )
      {
         standaloneModal( ) ;
         /* Using cursor BC00025 */
         pr_default.execute(3, new Object[] {A5CategoriaNombre, A4CategoriaID});
         if ( (pr_default.getStatus(3) != 101) )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_1004", new   object[]  {"Categoria Nombre"}), 1, "");
            AnyError = 1;
         }
         pr_default.close(3);
         if ( String.IsNullOrEmpty(StringUtil.RTrim( A5CategoriaNombre)) )
         {
            GX_msglist.addItem("Error, El nombre de la categoria es obligatoria", 1, "");
            AnyError = 1;
         }
      }

      protected void CloseExtendedTableCursors022( )
      {
      }

      protected void enableDisable( )
      {
      }

      protected void GetKey022( )
      {
         /* Using cursor BC00026 */
         pr_default.execute(4, new Object[] {A4CategoriaID});
         if ( (pr_default.getStatus(4) != 101) )
         {
            RcdFound2 = 1;
         }
         else
         {
            RcdFound2 = 0;
         }
         pr_default.close(4);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor BC00023 */
         pr_default.execute(1, new Object[] {A4CategoriaID});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM022( 3) ;
            RcdFound2 = 1;
            A4CategoriaID = BC00023_A4CategoriaID[0];
            A5CategoriaNombre = BC00023_A5CategoriaNombre[0];
            Z4CategoriaID = A4CategoriaID;
            sMode2 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Load022( ) ;
            if ( AnyError == 1 )
            {
               RcdFound2 = 0;
               InitializeNonKey022( ) ;
            }
            Gx_mode = sMode2;
         }
         else
         {
            RcdFound2 = 0;
            InitializeNonKey022( ) ;
            sMode2 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Gx_mode = sMode2;
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey022( ) ;
         if ( RcdFound2 == 0 )
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
         CONFIRM_020( ) ;
      }

      protected void update_Check( )
      {
         insert_Check( ) ;
      }

      protected void delete_Check( )
      {
         insert_Check( ) ;
      }

      protected void CheckOptimisticConcurrency022( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor BC00022 */
            pr_default.execute(0, new Object[] {A4CategoriaID});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Categoria"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(0) == 101) || ( StringUtil.StrCmp(Z5CategoriaNombre, BC00022_A5CategoriaNombre[0]) != 0 ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"Categoria"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert022( )
      {
         BeforeValidate022( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable022( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM022( 0) ;
            CheckOptimisticConcurrency022( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm022( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert022( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC00027 */
                     pr_default.execute(5, new Object[] {A5CategoriaNombre});
                     A4CategoriaID = BC00027_A4CategoriaID[0];
                     pr_default.close(5);
                     pr_default.SmartCacheProvider.SetUpdated("Categoria");
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
               Load022( ) ;
            }
            EndLevel022( ) ;
         }
         CloseExtendedTableCursors022( ) ;
      }

      protected void Update022( )
      {
         BeforeValidate022( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable022( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency022( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm022( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate022( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC00028 */
                     pr_default.execute(6, new Object[] {A5CategoriaNombre, A4CategoriaID});
                     pr_default.close(6);
                     pr_default.SmartCacheProvider.SetUpdated("Categoria");
                     if ( (pr_default.getStatus(6) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Categoria"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate022( ) ;
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
            EndLevel022( ) ;
         }
         CloseExtendedTableCursors022( ) ;
      }

      protected void DeferredUpdate022( )
      {
      }

      protected void delete( )
      {
         Gx_mode = "DLT";
         BeforeValidate022( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency022( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls022( ) ;
            AfterConfirm022( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete022( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor BC00029 */
                  pr_default.execute(7, new Object[] {A4CategoriaID});
                  pr_default.close(7);
                  pr_default.SmartCacheProvider.SetUpdated("Categoria");
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
         sMode2 = Gx_mode;
         Gx_mode = "DLT";
         EndLevel022( ) ;
         Gx_mode = sMode2;
      }

      protected void OnDeleteControls022( )
      {
         standaloneModal( ) ;
         /* No delete mode formulas found. */
         if ( AnyError == 0 )
         {
            /* Using cursor BC000210 */
            pr_default.execute(8, new Object[] {A4CategoriaID});
            if ( (pr_default.getStatus(8) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Producto"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(8);
         }
      }

      protected void EndLevel022( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete022( ) ;
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

      public void ScanKeyStart022( )
      {
         /* Scan By routine */
         /* Using cursor BC000211 */
         pr_default.execute(9, new Object[] {A4CategoriaID});
         RcdFound2 = 0;
         if ( (pr_default.getStatus(9) != 101) )
         {
            RcdFound2 = 1;
            A4CategoriaID = BC000211_A4CategoriaID[0];
            A5CategoriaNombre = BC000211_A5CategoriaNombre[0];
         }
         /* Load Subordinate Levels */
      }

      protected void ScanKeyNext022( )
      {
         /* Scan next routine */
         pr_default.readNext(9);
         RcdFound2 = 0;
         ScanKeyLoad022( ) ;
      }

      protected void ScanKeyLoad022( )
      {
         sMode2 = Gx_mode;
         Gx_mode = "DSP";
         if ( (pr_default.getStatus(9) != 101) )
         {
            RcdFound2 = 1;
            A4CategoriaID = BC000211_A4CategoriaID[0];
            A5CategoriaNombre = BC000211_A5CategoriaNombre[0];
         }
         Gx_mode = sMode2;
      }

      protected void ScanKeyEnd022( )
      {
         pr_default.close(9);
      }

      protected void AfterConfirm022( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert022( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate022( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete022( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete022( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate022( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes022( )
      {
      }

      protected void send_integrity_lvl_hashes022( )
      {
      }

      protected void AddRow022( )
      {
         VarsToRow2( bcCategoria) ;
      }

      protected void ReadRow022( )
      {
         RowToVars2( bcCategoria, 1) ;
      }

      protected void InitializeNonKey022( )
      {
         A5CategoriaNombre = "";
         Z5CategoriaNombre = "";
      }

      protected void InitAll022( )
      {
         A4CategoriaID = 1;
         InitializeNonKey022( ) ;
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

      public void VarsToRow2( SdtCategoria obj2 )
      {
         obj2.gxTpr_Mode = Gx_mode;
         obj2.gxTpr_Categorianombre = A5CategoriaNombre;
         obj2.gxTpr_Categoriaid = A4CategoriaID;
         obj2.gxTpr_Categoriaid_Z = Z4CategoriaID;
         obj2.gxTpr_Categorianombre_Z = Z5CategoriaNombre;
         obj2.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void KeyVarsToRow2( SdtCategoria obj2 )
      {
         obj2.gxTpr_Categoriaid = A4CategoriaID;
         return  ;
      }

      public void RowToVars2( SdtCategoria obj2 ,
                              int forceLoad )
      {
         Gx_mode = obj2.gxTpr_Mode;
         A5CategoriaNombre = obj2.gxTpr_Categorianombre;
         A4CategoriaID = obj2.gxTpr_Categoriaid;
         Z4CategoriaID = obj2.gxTpr_Categoriaid_Z;
         Z5CategoriaNombre = obj2.gxTpr_Categorianombre_Z;
         Gx_mode = obj2.gxTpr_Mode;
         return  ;
      }

      public void LoadKey( Object[] obj )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         A4CategoriaID = (int)getParm(obj,0);
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         InitializeNonKey022( ) ;
         ScanKeyStart022( ) ;
         if ( RcdFound2 == 0 )
         {
            Gx_mode = "INS";
         }
         else
         {
            Gx_mode = "UPD";
            Z4CategoriaID = A4CategoriaID;
         }
         ZM022( -3) ;
         OnLoadActions022( ) ;
         AddRow022( ) ;
         ScanKeyEnd022( ) ;
         if ( RcdFound2 == 0 )
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
         RowToVars2( bcCategoria, 0) ;
         ScanKeyStart022( ) ;
         if ( RcdFound2 == 0 )
         {
            Gx_mode = "INS";
         }
         else
         {
            Gx_mode = "UPD";
            Z4CategoriaID = A4CategoriaID;
         }
         ZM022( -3) ;
         OnLoadActions022( ) ;
         AddRow022( ) ;
         ScanKeyEnd022( ) ;
         if ( RcdFound2 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "");
            AnyError = 1;
         }
         context.GX_msglist = BackMsgLst;
      }

      protected void SaveImpl( )
      {
         GetKey022( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            Insert022( ) ;
         }
         else
         {
            if ( RcdFound2 == 1 )
            {
               if ( A4CategoriaID != Z4CategoriaID )
               {
                  A4CategoriaID = Z4CategoriaID;
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
                  Update022( ) ;
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
                  if ( A4CategoriaID != Z4CategoriaID )
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
                        Insert022( ) ;
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
                        Insert022( ) ;
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
         RowToVars2( bcCategoria, 1) ;
         SaveImpl( ) ;
         VarsToRow2( bcCategoria) ;
         context.GX_msglist = BackMsgLst;
         return  ;
      }

      public bool Insert( )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         RowToVars2( bcCategoria, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert022( ) ;
         AfterTrn( ) ;
         VarsToRow2( bcCategoria) ;
         context.GX_msglist = BackMsgLst;
         return (AnyError==0) ;
      }

      protected void UpdateImpl( )
      {
         if ( IsUpd( ) )
         {
            SaveImpl( ) ;
            VarsToRow2( bcCategoria) ;
         }
         else
         {
            SdtCategoria auxBC = new SdtCategoria(context);
            IGxSilentTrn auxTrn = auxBC.getTransaction();
            auxBC.Load(A4CategoriaID);
            if ( auxTrn.Errors() == 0 )
            {
               auxBC.UpdateDirties(bcCategoria);
               auxBC.Save();
               bcCategoria.Copy((GxSilentTrnSdt)(auxBC));
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
         RowToVars2( bcCategoria, 1) ;
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
         RowToVars2( bcCategoria, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert022( ) ;
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
               VarsToRow2( bcCategoria) ;
            }
         }
         else
         {
            AfterTrn( ) ;
            VarsToRow2( bcCategoria) ;
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
         RowToVars2( bcCategoria, 0) ;
         GetKey022( ) ;
         if ( RcdFound2 == 1 )
         {
            if ( IsIns( ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_noupdate", ""), "DuplicatePrimaryKey", 1, "");
               AnyError = 1;
            }
            else if ( A4CategoriaID != Z4CategoriaID )
            {
               A4CategoriaID = Z4CategoriaID;
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
            if ( A4CategoriaID != Z4CategoriaID )
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
         context.RollbackDataStores("categoria_bc",pr_default);
         VarsToRow2( bcCategoria) ;
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
         Gx_mode = bcCategoria.gxTpr_Mode;
         return Gx_mode ;
      }

      public void SetMode( string lMode )
      {
         Gx_mode = lMode;
         bcCategoria.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void SetSDT( GxSilentTrnSdt sdt ,
                          short sdtToBc )
      {
         if ( sdt != bcCategoria )
         {
            bcCategoria = (SdtCategoria)(sdt);
            if ( StringUtil.StrCmp(bcCategoria.gxTpr_Mode, "") == 0 )
            {
               bcCategoria.gxTpr_Mode = "INS";
            }
            if ( sdtToBc == 1 )
            {
               VarsToRow2( bcCategoria) ;
            }
            else
            {
               RowToVars2( bcCategoria, 1) ;
            }
         }
         else
         {
            if ( StringUtil.StrCmp(bcCategoria.gxTpr_Mode, "") == 0 )
            {
               bcCategoria.gxTpr_Mode = "INS";
            }
         }
         return  ;
      }

      public void ReloadFromSDT( )
      {
         RowToVars2( bcCategoria, 1) ;
         return  ;
      }

      public void ForceCommitOnExit( )
      {
         return  ;
      }

      public SdtCategoria Categoria_BC
      {
         get {
            return bcCategoria ;
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
         Z5CategoriaNombre = "";
         A5CategoriaNombre = "";
         BC00024_A4CategoriaID = new int[1] ;
         BC00024_A5CategoriaNombre = new string[] {""} ;
         BC00025_A5CategoriaNombre = new string[] {""} ;
         BC00026_A4CategoriaID = new int[1] ;
         BC00023_A4CategoriaID = new int[1] ;
         BC00023_A5CategoriaNombre = new string[] {""} ;
         sMode2 = "";
         BC00022_A4CategoriaID = new int[1] ;
         BC00022_A5CategoriaNombre = new string[] {""} ;
         BC00027_A4CategoriaID = new int[1] ;
         BC000210_A19ProductoID = new int[1] ;
         BC000211_A4CategoriaID = new int[1] ;
         BC000211_A5CategoriaNombre = new string[] {""} ;
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.categoria_bc__default(),
            new Object[][] {
                new Object[] {
               BC00022_A4CategoriaID, BC00022_A5CategoriaNombre
               }
               , new Object[] {
               BC00023_A4CategoriaID, BC00023_A5CategoriaNombre
               }
               , new Object[] {
               BC00024_A4CategoriaID, BC00024_A5CategoriaNombre
               }
               , new Object[] {
               BC00025_A5CategoriaNombre
               }
               , new Object[] {
               BC00026_A4CategoriaID
               }
               , new Object[] {
               BC00027_A4CategoriaID
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               BC000210_A19ProductoID
               }
               , new Object[] {
               BC000211_A4CategoriaID, BC000211_A5CategoriaNombre
               }
            }
         );
         Z4CategoriaID = 1;
         A4CategoriaID = 1;
         INITTRN();
         /* Execute Start event if defined. */
         /* Execute user event: Start */
         E12022 ();
         standaloneNotModal( ) ;
      }

      private short AnyError ;
      private short Gx_BScreen ;
      private short RcdFound2 ;
      private int trnEnded ;
      private int Z4CategoriaID ;
      private int A4CategoriaID ;
      private string Gx_mode ;
      private string endTrnMsgTxt ;
      private string endTrnMsgCod ;
      private string sMode2 ;
      private bool returnInSub ;
      private string Z5CategoriaNombre ;
      private string A5CategoriaNombre ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private int[] BC00024_A4CategoriaID ;
      private string[] BC00024_A5CategoriaNombre ;
      private string[] BC00025_A5CategoriaNombre ;
      private int[] BC00026_A4CategoriaID ;
      private int[] BC00023_A4CategoriaID ;
      private string[] BC00023_A5CategoriaNombre ;
      private int[] BC00022_A4CategoriaID ;
      private string[] BC00022_A5CategoriaNombre ;
      private int[] BC00027_A4CategoriaID ;
      private int[] BC000210_A19ProductoID ;
      private int[] BC000211_A4CategoriaID ;
      private string[] BC000211_A5CategoriaNombre ;
      private SdtCategoria bcCategoria ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
   }

   public class categoria_bc__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmBC00022;
          prmBC00022 = new Object[] {
          new ParDef("@CategoriaID",GXType.Int32,6,0)
          };
          Object[] prmBC00023;
          prmBC00023 = new Object[] {
          new ParDef("@CategoriaID",GXType.Int32,6,0)
          };
          Object[] prmBC00024;
          prmBC00024 = new Object[] {
          new ParDef("@CategoriaID",GXType.Int32,6,0)
          };
          Object[] prmBC00025;
          prmBC00025 = new Object[] {
          new ParDef("@CategoriaNombre",GXType.NVarChar,80,0) ,
          new ParDef("@CategoriaID",GXType.Int32,6,0)
          };
          Object[] prmBC00026;
          prmBC00026 = new Object[] {
          new ParDef("@CategoriaID",GXType.Int32,6,0)
          };
          Object[] prmBC00027;
          prmBC00027 = new Object[] {
          new ParDef("@CategoriaNombre",GXType.NVarChar,80,0)
          };
          Object[] prmBC00028;
          prmBC00028 = new Object[] {
          new ParDef("@CategoriaNombre",GXType.NVarChar,80,0) ,
          new ParDef("@CategoriaID",GXType.Int32,6,0)
          };
          Object[] prmBC00029;
          prmBC00029 = new Object[] {
          new ParDef("@CategoriaID",GXType.Int32,6,0)
          };
          Object[] prmBC000210;
          prmBC000210 = new Object[] {
          new ParDef("@CategoriaID",GXType.Int32,6,0)
          };
          Object[] prmBC000211;
          prmBC000211 = new Object[] {
          new ParDef("@CategoriaID",GXType.Int32,6,0)
          };
          def= new CursorDef[] {
              new CursorDef("BC00022", "SELECT [CategoriaID], [CategoriaNombre] FROM [Categoria] WITH (UPDLOCK) WHERE [CategoriaID] = @CategoriaID ",true, GxErrorMask.GX_NOMASK, false, this,prmBC00022,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC00023", "SELECT [CategoriaID], [CategoriaNombre] FROM [Categoria] WHERE [CategoriaID] = @CategoriaID ",true, GxErrorMask.GX_NOMASK, false, this,prmBC00023,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC00024", "SELECT TM1.[CategoriaID], TM1.[CategoriaNombre] FROM [Categoria] TM1 WHERE TM1.[CategoriaID] = @CategoriaID ORDER BY TM1.[CategoriaID]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmBC00024,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC00025", "SELECT [CategoriaNombre] FROM [Categoria] WHERE ([CategoriaNombre] = @CategoriaNombre) AND (Not ( [CategoriaID] = @CategoriaID)) ",true, GxErrorMask.GX_NOMASK, false, this,prmBC00025,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC00026", "SELECT [CategoriaID] FROM [Categoria] WHERE [CategoriaID] = @CategoriaID  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmBC00026,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC00027", "INSERT INTO [Categoria]([CategoriaNombre]) VALUES(@CategoriaNombre); SELECT SCOPE_IDENTITY()",true, GxErrorMask.GX_NOMASK, false, this,prmBC00027,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("BC00028", "UPDATE [Categoria] SET [CategoriaNombre]=@CategoriaNombre  WHERE [CategoriaID] = @CategoriaID", GxErrorMask.GX_NOMASK,prmBC00028)
             ,new CursorDef("BC00029", "DELETE FROM [Categoria]  WHERE [CategoriaID] = @CategoriaID", GxErrorMask.GX_NOMASK,prmBC00029)
             ,new CursorDef("BC000210", "SELECT TOP 1 [ProductoID] FROM [Producto] WHERE [CategoriaID] = @CategoriaID ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000210,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("BC000211", "SELECT TM1.[CategoriaID], TM1.[CategoriaNombre] FROM [Categoria] TM1 WHERE TM1.[CategoriaID] = @CategoriaID ORDER BY TM1.[CategoriaID]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmBC000211,100, GxCacheFrequency.OFF ,true,false )
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
                return;
             case 1 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                return;
             case 2 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
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
             case 8 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
             case 9 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                return;
       }
    }

 }

}
