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
   public class productoconversion : GXProcedure
   {
      public productoconversion( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("miTienda", false);
      }

      public productoconversion( IGxContext context )
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
         cmdBuffer=" SET IDENTITY_INSERT [GXA0007] ON "
         ;
         RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
         RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
         RGZ.ExecuteStmt() ;
         RGZ.Drop();
         /* Using cursor PRODUCTOCO2 */
         pr_default.execute(0);
         while ( (pr_default.getStatus(0) != 101) )
         {
            A1PaisID = PRODUCTOCO2_A1PaisID[0];
            A4CategoriaID = PRODUCTOCO2_A4CategoriaID[0];
            A6VendedorID = PRODUCTOCO2_A6VendedorID[0];
            A22ProductoPrecio = PRODUCTOCO2_A22ProductoPrecio[0];
            A21ProductoDescripcion = PRODUCTOCO2_A21ProductoDescripcion[0];
            A20ProductoNombre = PRODUCTOCO2_A20ProductoNombre[0];
            A19ProductoID = PRODUCTOCO2_A19ProductoID[0];
            A40000ProductoImagen_GXI = PRODUCTOCO2_A40000ProductoImagen_GXI[0];
            A23ProductoImagen = PRODUCTOCO2_A23ProductoImagen[0];
            A1PaisID = PRODUCTOCO2_A1PaisID[0];
            /*
               INSERT RECORD ON TABLE GXA0007

            */
            AV2ProductoID = A19ProductoID;
            AV3ProductoNombre = A20ProductoNombre;
            AV4ProductoDescripcion = A21ProductoDescripcion;
            AV5ProductoPrecio = A22ProductoPrecio;
            AV6ProductoImagen = A23ProductoImagen;
            AV7ProductoImagen_GXI = A40000ProductoImagen_GXI;
            AV7ProductoImagen_GXI = A40000ProductoImagen_GXI;
            AV8VendedorID = A6VendedorID;
            AV9CategoriaID = A4CategoriaID;
            if ( PRODUCTOCO2_n1PaisID[0] )
            {
               AV10ProductoPaisID = 1;
            }
            else
            {
               AV10ProductoPaisID = A1PaisID;
            }
            /* Using cursor PRODUCTOCO3 */
            pr_default.execute(1, new Object[] {AV2ProductoID, AV3ProductoNombre, AV4ProductoDescripcion, AV5ProductoPrecio, AV6ProductoImagen, AV7ProductoImagen_GXI, AV8VendedorID, AV9CategoriaID, AV10ProductoPaisID});
            pr_default.close(1);
            pr_default.SmartCacheProvider.SetUpdated("GXA0007");
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
         cmdBuffer=" SET IDENTITY_INSERT [GXA0007] OFF "
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
         PRODUCTOCO2_A1PaisID = new int[1] ;
         PRODUCTOCO2_A4CategoriaID = new int[1] ;
         PRODUCTOCO2_A6VendedorID = new int[1] ;
         PRODUCTOCO2_A22ProductoPrecio = new decimal[1] ;
         PRODUCTOCO2_A21ProductoDescripcion = new string[] {""} ;
         PRODUCTOCO2_A20ProductoNombre = new string[] {""} ;
         PRODUCTOCO2_A19ProductoID = new int[1] ;
         PRODUCTOCO2_A40000ProductoImagen_GXI = new string[] {""} ;
         PRODUCTOCO2_A23ProductoImagen = new string[] {""} ;
         A21ProductoDescripcion = "";
         A20ProductoNombre = "";
         A40000ProductoImagen_GXI = "";
         A23ProductoImagen = "";
         AV3ProductoNombre = "";
         AV4ProductoDescripcion = "";
         AV6ProductoImagen = "";
         AV7ProductoImagen_GXI = "";
         PRODUCTOCO2_n1PaisID = new bool[] {false} ;
         Gx_emsg = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.productoconversion__default(),
            new Object[][] {
                new Object[] {
               PRODUCTOCO2_A1PaisID, PRODUCTOCO2_A4CategoriaID, PRODUCTOCO2_A6VendedorID, PRODUCTOCO2_A22ProductoPrecio, PRODUCTOCO2_A21ProductoDescripcion, PRODUCTOCO2_A20ProductoNombre, PRODUCTOCO2_A19ProductoID, PRODUCTOCO2_A40000ProductoImagen_GXI, PRODUCTOCO2_A23ProductoImagen
               }
               , new Object[] {
               }
            }
         );
         /* GeneXus formulas. */
      }

      private int A1PaisID ;
      private int A4CategoriaID ;
      private int A6VendedorID ;
      private int A19ProductoID ;
      private int GIGXA0007 ;
      private int AV2ProductoID ;
      private int AV8VendedorID ;
      private int AV9CategoriaID ;
      private int AV10ProductoPaisID ;
      private decimal A22ProductoPrecio ;
      private decimal AV5ProductoPrecio ;
      private string cmdBuffer ;
      private string Gx_emsg ;
      private string A21ProductoDescripcion ;
      private string A20ProductoNombre ;
      private string A40000ProductoImagen_GXI ;
      private string AV3ProductoNombre ;
      private string AV4ProductoDescripcion ;
      private string AV7ProductoImagen_GXI ;
      private string A23ProductoImagen ;
      private string AV6ProductoImagen ;
      private IGxDataStore dsDefault ;
      private GxCommand RGZ ;
      private IDataStoreProvider pr_default ;
      private int[] PRODUCTOCO2_A1PaisID ;
      private int[] PRODUCTOCO2_A4CategoriaID ;
      private int[] PRODUCTOCO2_A6VendedorID ;
      private decimal[] PRODUCTOCO2_A22ProductoPrecio ;
      private string[] PRODUCTOCO2_A21ProductoDescripcion ;
      private string[] PRODUCTOCO2_A20ProductoNombre ;
      private int[] PRODUCTOCO2_A19ProductoID ;
      private string[] PRODUCTOCO2_A40000ProductoImagen_GXI ;
      private string[] PRODUCTOCO2_A23ProductoImagen ;
      private bool[] PRODUCTOCO2_n1PaisID ;
   }

   public class productoconversion__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmPRODUCTOCO2;
          prmPRODUCTOCO2 = new Object[] {
          };
          Object[] prmPRODUCTOCO3;
          prmPRODUCTOCO3 = new Object[] {
          new ParDef("@AV2ProductoID",GXType.Int32,6,0) ,
          new ParDef("@AV3ProductoNombre",GXType.VarChar,80,0) ,
          new ParDef("@AV4ProductoDescripcion",GXType.VarChar,80,0) ,
          new ParDef("@AV5ProductoPrecio",GXType.Decimal,6,2) ,
          new ParDef("@AV6ProductoImagen",GXType.Blob,1024,0){InDB=false} ,
          new ParDef("@AV7ProductoImagen_GXI",GXType.VarChar,2048,0){AddAtt=true, ImgIdx=4, Tbl="GXA0007", Fld="ProductoImagen"} ,
          new ParDef("@AV8VendedorID",GXType.Int32,6,0) ,
          new ParDef("@AV9CategoriaID",GXType.Int32,6,0) ,
          new ParDef("@AV10ProductoPaisID",GXType.Int32,6,0)
          };
          def= new CursorDef[] {
              new CursorDef("PRODUCTOCO2", "SELECT T2.[PaisID], T1.[CategoriaID], T1.[VendedorID], T1.[ProductoPrecio], T1.[ProductoDescripcion], T1.[ProductoNombre], T1.[ProductoID], T1.[ProductoImagen_GXI], T1.[ProductoImagen] FROM ([Producto] T1 INNER JOIN [Vendedor] T2 ON T2.[VendedorID] = T1.[VendedorID]) ORDER BY T1.[ProductoID] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmPRODUCTOCO2,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("PRODUCTOCO3", "INSERT INTO [GXA0007]([ProductoID], [ProductoNombre], [ProductoDescripcion], [ProductoPrecio], [ProductoImagen], [ProductoImagen_GXI], [VendedorID], [CategoriaID], [ProductoPaisID]) VALUES(@AV2ProductoID, @AV3ProductoNombre, @AV4ProductoDescripcion, @AV5ProductoPrecio, @AV6ProductoImagen, @AV7ProductoImagen_GXI, @AV8VendedorID, @AV9CategoriaID, @AV10ProductoPaisID)", GxErrorMask.GX_NOMASK,prmPRODUCTOCO3)
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
                ((int[]) buf[1])[0] = rslt.getInt(2);
                ((int[]) buf[2])[0] = rslt.getInt(3);
                ((decimal[]) buf[3])[0] = rslt.getDecimal(4);
                ((string[]) buf[4])[0] = rslt.getVarchar(5);
                ((string[]) buf[5])[0] = rslt.getVarchar(6);
                ((int[]) buf[6])[0] = rslt.getInt(7);
                ((string[]) buf[7])[0] = rslt.getMultimediaUri(8);
                ((string[]) buf[8])[0] = rslt.getMultimediaFile(9, rslt.getVarchar(8));
                return;
       }
    }

 }

}
