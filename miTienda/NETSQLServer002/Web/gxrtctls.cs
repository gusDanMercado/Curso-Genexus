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
   public class gxrtctls : GXProcedure
   {
      public gxrtctls( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("miTienda", false);
      }

      public gxrtctls( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( out short aP0_Status )
      {
         this.AV2Status = 0 ;
         initialize();
         ExecuteImpl();
         aP0_Status=this.AV2Status;
      }

      public short executeUdp( )
      {
         execute(out aP0_Status);
         return AV2Status ;
      }

      public void executeSubmit( out short aP0_Status )
      {
         this.AV2Status = 0 ;
         SubmitImpl();
         aP0_Status=this.AV2Status;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         AV2Status = 0;
         Console.WriteLine( "=== Starting run time controls" );
         Console.WriteLine( "Searching CarritoDetalleCompra for duplicate values on new unique index on ProductoID" );
         /* Using cursor LTCTLS2 */
         pr_default.execute(0);
         while ( (pr_default.getStatus(0) != 101) )
         {
            BRKR012 = false;
            A19ProductoID = LTCTLS2_A19ProductoID[0];
            A33CarritoID = LTCTLS2_A33CarritoID[0];
            A37CarritoDetalleCompraID = LTCTLS2_A37CarritoDetalleCompraID[0];
            AV3Count = 0;
            while ( (pr_default.getStatus(0) != 101) && ( LTCTLS2_A19ProductoID[0] == A19ProductoID ) )
            {
               BRKR012 = false;
               A33CarritoID = LTCTLS2_A33CarritoID[0];
               A37CarritoDetalleCompraID = LTCTLS2_A37CarritoDetalleCompraID[0];
               if ( AV3Count != 0 )
               {
                  AV2Status = 1;
                  Console.WriteLine( "Fail: Duplicates found. The first non unique value found follows." );
                  Console.WriteLine( "ProductoID: "+StringUtil.Str( (decimal)(A19ProductoID), 10, 0) );
                  Console.WriteLine( "Recovery: See recovery information for reorganization message rgz0020." );
                  /* Exit For each command. Update data (if necessary), close cursors & exit. */
                  if (true) break;
               }
               AV3Count = (int)(AV3Count+1);
               BRKR012 = true;
               pr_default.readNext(0);
            }
            if ( AV2Status != 0 )
            {
               /* Exit For each command. Update data (if necessary), close cursors & exit. */
               if (true) break;
            }
            if ( ! BRKR012 )
            {
               BRKR012 = true;
               pr_default.readNext(0);
            }
         }
         pr_default.close(0);
         if ( AV2Status == 0 )
         {
            Console.WriteLine( "Success: No duplicates found for ProductoID" );
         }
         Console.WriteLine( "====================" );
         Console.WriteLine( "=== End of run time controls" );
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
         LTCTLS2_A19ProductoID = new int[1] ;
         LTCTLS2_A33CarritoID = new int[1] ;
         LTCTLS2_A37CarritoDetalleCompraID = new int[1] ;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.gxrtctls__default(),
            new Object[][] {
                new Object[] {
               LTCTLS2_A19ProductoID, LTCTLS2_A33CarritoID, LTCTLS2_A37CarritoDetalleCompraID
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short AV2Status ;
      private int A19ProductoID ;
      private int A33CarritoID ;
      private int A37CarritoDetalleCompraID ;
      private int AV3Count ;
      private bool BRKR012 ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private int[] LTCTLS2_A19ProductoID ;
      private int[] LTCTLS2_A33CarritoID ;
      private int[] LTCTLS2_A37CarritoDetalleCompraID ;
      private short aP0_Status ;
   }

   public class gxrtctls__default : DataStoreHelperBase, IDataStoreHelper
   {
      public ICursor[] getCursors( )
      {
         cursorDefinitions();
         return new Cursor[] {
          new ForEachCursor(def[0])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmLTCTLS2;
          prmLTCTLS2 = new Object[] {
          };
          def= new CursorDef[] {
              new CursorDef("LTCTLS2", "SELECT [ProductoID], [CarritoID], [CarritoDetalleCompraID] FROM [CarritoDetalleCompra] ORDER BY [ProductoID] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmLTCTLS2,100, GxCacheFrequency.OFF ,true,false )
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
                return;
       }
    }

 }

}
