using System;
using System.Collections;
using GeneXus.Utils;
using GeneXus.Resources;
using GeneXus.Application;
using GeneXus.Metadata;
using GeneXus.Cryptography;
using GeneXus.Reorg;
using System.Threading;
using GeneXus.Programs;
using System.Data;
using GeneXus.Data;
using com.genexus;
using GeneXus.Data.ADO;
using GeneXus.Data.NTier;
using GeneXus.Data.NTier.ADO;
using GeneXus.WebControls;
using GeneXus.Http;
using GeneXus.Procedure;
using GeneXus.XML;
using GeneXus.Search;
using GeneXus.Encryption;
using GeneXus.Http.Client;
using System.Xml.Serialization;
namespace GeneXus.Programs {
   public class showconversion : GXProcedure
   {
      public showconversion( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("parques", false);
      }

      public showconversion( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( )
      {
         initialize();
         ExecuteImpl();
      }

      public void executeSubmit( )
      {
         SubmitImpl();
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         cmdBuffer=" SET IDENTITY_INSERT [GXA0004] ON "
         ;
         RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
         RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
         RGZ.ExecuteStmt() ;
         RGZ.Drop();
         /* Using cursor SHOWCONVER2 */
         pr_default.execute(0);
         while ( (pr_default.getStatus(0) != 101) )
         {
            A21ShowNombre = SHOWCONVER2_A21ShowNombre[0];
            A20ShowId = SHOWCONVER2_A20ShowId[0];
            A40000ShowImagen_GXI = SHOWCONVER2_A40000ShowImagen_GXI[0];
            A22ShowImagen = SHOWCONVER2_A22ShowImagen[0];
            /*
               INSERT RECORD ON TABLE GXA0004

            */
            AV2ShowId = A20ShowId;
            AV3ShowNombre = A21ShowNombre;
            AV4ShowImagen = A22ShowImagen;
            AV5ShowImagen_GXI = A40000ShowImagen_GXI;
            AV5ShowImagen_GXI = A40000ShowImagen_GXI;
            /* Using cursor SHOWCONVER3 */
            pr_default.execute(1, new Object[] {AV2ShowId, AV3ShowNombre, AV4ShowImagen, AV5ShowImagen_GXI});
            pr_default.close(1);
            pr_default.SmartCacheProvider.SetUpdated("GXA0004");
            if ( (pr_default.getStatus(1) == 1) )
            {
               context.Gx_err = 1;
               Gx_emsg = (string)(GXResourceManager.GetMessage("GXM_noupdate"));
            }
            else
            {
               context.Gx_err = 0;
               Gx_emsg = "";
            }
            /* End Insert */
            pr_default.readNext(0);
         }
         pr_default.close(0);
         cmdBuffer=" SET IDENTITY_INSERT [GXA0004] OFF "
         ;
         RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
         RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
         RGZ.ExecuteStmt() ;
         RGZ.Drop();
         cleanup();
      }

      public override void cleanup( )
      {
         CloseCursors();
         if ( IsMain )
         {
            context.CloseConnections();
         }
         ExitApp();
      }

      public override void initialize( )
      {
         cmdBuffer = "";
         SHOWCONVER2_A21ShowNombre = new string[] {""} ;
         SHOWCONVER2_A20ShowId = new short[1] ;
         SHOWCONVER2_A40000ShowImagen_GXI = new string[] {""} ;
         SHOWCONVER2_A22ShowImagen = new string[] {""} ;
         A21ShowNombre = "";
         A40000ShowImagen_GXI = "";
         A22ShowImagen = "";
         AV3ShowNombre = "";
         AV4ShowImagen = "";
         AV5ShowImagen_GXI = "";
         Gx_emsg = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.showconversion__default(),
            new Object[][] {
                new Object[] {
               SHOWCONVER2_A21ShowNombre, SHOWCONVER2_A20ShowId, SHOWCONVER2_A40000ShowImagen_GXI, SHOWCONVER2_A22ShowImagen
               }
               , new Object[] {
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short A20ShowId ;
      private short AV2ShowId ;
      private int GIGXA0004 ;
      private string cmdBuffer ;
      private string Gx_emsg ;
      private string A21ShowNombre ;
      private string A40000ShowImagen_GXI ;
      private string AV3ShowNombre ;
      private string AV5ShowImagen_GXI ;
      private string A22ShowImagen ;
      private string AV4ShowImagen ;
      private IGxDataStore dsDefault ;
      private GxCommand RGZ ;
      private IDataStoreProvider pr_default ;
      private string[] SHOWCONVER2_A21ShowNombre ;
      private short[] SHOWCONVER2_A20ShowId ;
      private string[] SHOWCONVER2_A40000ShowImagen_GXI ;
      private string[] SHOWCONVER2_A22ShowImagen ;
   }

   public class showconversion__default : DataStoreHelperBase, IDataStoreHelper
   {
      public ICursor[] getCursors( )
      {
         cursorDefinitions();
         return new Cursor[] {
          new ForEachCursor(def[0])
         ,new UpdateCursor(def[1])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmSHOWCONVER2;
          prmSHOWCONVER2 = new Object[] {
          };
          Object[] prmSHOWCONVER3;
          prmSHOWCONVER3 = new Object[] {
          new ParDef("@AV2ShowId",GXType.Int16,4,0) ,
          new ParDef("@AV3ShowNombre",GXType.VarChar,40,0) ,
          new ParDef("@AV4ShowImagen",GXType.Blob,1024,0){InDB=false} ,
          new ParDef("@AV5ShowImagen_GXI",GXType.VarChar,2048,0){AddAtt=true, ImgIdx=2, Tbl="GXA0004", Fld="ShowImagen"}
          };
          def= new CursorDef[] {
              new CursorDef("SHOWCONVER2", "SELECT [ShowNombre], [ShowId], [ShowImagen_GXI], [ShowImagen] FROM [Show] ORDER BY [ShowId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmSHOWCONVER2,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("SHOWCONVER3", "INSERT INTO [GXA0004]([ShowId], [ShowNombre], [ShowImagen], [ShowImagen_GXI]) VALUES(@AV2ShowId, @AV3ShowNombre, @AV4ShowImagen, @AV5ShowImagen_GXI)", GxErrorMask.GX_NOMASK,prmSHOWCONVER3)
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
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((short[]) buf[1])[0] = rslt.getShort(2);
                ((string[]) buf[2])[0] = rslt.getMultimediaUri(3);
                ((string[]) buf[3])[0] = rslt.getMultimediaFile(4, rslt.getVarchar(3));
                return;
       }
    }

 }

}
