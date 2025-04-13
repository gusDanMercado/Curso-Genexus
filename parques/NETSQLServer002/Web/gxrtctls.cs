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
         context.SetDefaultTheme("parques", false);
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
         Console.WriteLine( "Checking that table parqueAtraccion does NOT contain records." );
         AV3NotFound = 0;
         AV4GXLvl5 = 0;
         /* Using cursor LTCTLS2 */
         pr_default.execute(0);
         while ( (pr_default.getStatus(0) != 101) )
         {
            A18PaisId = LTCTLS2_A18PaisId[0];
            A13parqueAtraccionId = LTCTLS2_A13parqueAtraccionId[0];
            AV4GXLvl5 = 1;
            AV5GXLvl8 = 0;
            /* Using cursor LTCTLS3 */
            pr_default.execute(1, new Object[] {A18PaisId});
            while ( (pr_default.getStatus(1) != 101) )
            {
               A28CiudadId = LTCTLS3_A28CiudadId[0];
               AV5GXLvl8 = 1;
               pr_default.readNext(1);
            }
            pr_default.close(1);
            if ( AV5GXLvl8 == 0 )
            {
               AV2Status = 1;
               Console.WriteLine( "Fail: Table parqueAtraccion has records but referenced key value in table PaisCiudad does _not_ exist." );
               Console.WriteLine( "Recovery: See recovery information for reorganization message rgz0029." );
               AV3NotFound = 1;
            }
            if ( AV3NotFound == 1 )
            {
               /* Exit For each command. Update data (if necessary), close cursors & exit. */
               if (true) break;
            }
            pr_default.readNext(0);
         }
         pr_default.close(0);
         if ( AV4GXLvl5 == 0 )
         {
            Console.WriteLine( "Success: Table parqueAtraccion does NOT have records." );
            AV3NotFound = 1;
         }
         if ( AV3NotFound == 0 )
         {
            Console.WriteLine( "Success: Table parqueAtraccionhas records but all referenced key values in table PaisCiudad exist." );
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
         LTCTLS2_A18PaisId = new short[1] ;
         LTCTLS2_A13parqueAtraccionId = new short[1] ;
         LTCTLS3_A18PaisId = new short[1] ;
         LTCTLS3_A28CiudadId = new short[1] ;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.gxrtctls__default(),
            new Object[][] {
                new Object[] {
               LTCTLS2_A18PaisId, LTCTLS2_A13parqueAtraccionId
               }
               , new Object[] {
               LTCTLS3_A18PaisId, LTCTLS3_A28CiudadId
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short AV2Status ;
      private short AV3NotFound ;
      private short AV4GXLvl5 ;
      private short A18PaisId ;
      private short A13parqueAtraccionId ;
      private short AV5GXLvl8 ;
      private short A28CiudadId ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private short[] LTCTLS2_A18PaisId ;
      private short[] LTCTLS2_A13parqueAtraccionId ;
      private short[] LTCTLS3_A18PaisId ;
      private short[] LTCTLS3_A28CiudadId ;
      private short aP0_Status ;
   }

   public class gxrtctls__default : DataStoreHelperBase, IDataStoreHelper
   {
      public ICursor[] getCursors( )
      {
         cursorDefinitions();
         return new Cursor[] {
          new ForEachCursor(def[0])
         ,new ForEachCursor(def[1])
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
          Object[] prmLTCTLS3;
          prmLTCTLS3 = new Object[] {
          new ParDef("@PaisId",GXType.Int16,4,0)
          };
          def= new CursorDef[] {
              new CursorDef("LTCTLS2", "SELECT DISTINCT [PaisId], [parqueAtraccionId] FROM [parqueAtraccion] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmLTCTLS2,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("LTCTLS3", "SELECT [PaisId], [CiudadId] FROM [PaisCiudad] WHERE ([PaisId] = @PaisId) AND ([CiudadId] = 0) ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmLTCTLS3,100, GxCacheFrequency.OFF ,false,false )
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
                ((short[]) buf[1])[0] = rslt.getShort(2);
                return;
             case 1 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((short[]) buf[1])[0] = rslt.getShort(2);
                return;
       }
    }

 }

}
