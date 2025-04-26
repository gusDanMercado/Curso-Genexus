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
using GeneXus.Procedure;
using GeneXus.XML;
using GeneXus.Search;
using GeneXus.Encryption;
using GeneXus.Http.Client;
using GeneXus.Http.Server;
using System.Threading;
using System.Xml.Serialization;
using System.Runtime.Serialization;
namespace GeneXus.Programs {
   public class areporteempleadoexcel : GXWebProcedure
   {
      public override void webExecute( )
      {
         context.SetDefaultTheme("parques", true);
         initialize();
         if ( String.IsNullOrEmpty(StringUtil.RTrim( context.GetCookie( "GX_SESSION_ID"))) )
         {
            gxcookieaux = context.SetCookie( "GX_SESSION_ID", Encrypt64( Crypto.GetEncryptionKey( ), Crypto.GetServerKey( )), "", (DateTime)(DateTime.MinValue), "", (short)(context.GetHttpSecure( )));
         }
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         if ( nGotPars == 0 )
         {
            entryPointCalled = false;
            gxfirstwebparm = GetNextPar( );
         }
         if ( GxWebError == 0 )
         {
            ExecutePrivate();
         }
         cleanup();
      }

      public areporteempleadoexcel( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("parques", true);
      }

      public areporteempleadoexcel( IGxContext context )
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
         Gx_xmlwrt.Open("ReporteEmpleadoExcel.xml");
         if ( Gx_xmlwrt.ErrCode == 0 )
         {
            Gx_xmlwrt.WriteStartDocument("UTF-8", 0);
            if ( Gx_xmlwrt.ErrCode == 0 )
            {
               Gx_xmlwrt.WriteStartElement("DATA");
               AV8Row = 1;
               Gx_xmlwrt.WriteStartElement("Empleado_Group");
               /* Optimized group. */
               /* Using cursor P000G2 */
               pr_default.execute(0);
               cV8Row = P000G2_AV8Row[0];
               pr_default.close(0);
               AV8Row = (short)(AV8Row+cV8Row*1);
               /* End optimized group. */
               Gx_xmlwrt.WriteEndElement();
               Gx_xmlwrt.WriteEndElement();
               Gx_xmlwrt.WriteProcessingInstruction("xmlend", "");
            }
            Gx_xmlwrt.Close();
         }
         if ( context.WillRedirect( ) )
         {
            context.Redirect( context.wjLoc );
            context.wjLoc = "";
         }
         cleanup();
      }

      public override void cleanup( )
      {
         CloseCursors();
         base.cleanup();
         if ( IsMain )
         {
            context.CloseConnections();
         }
         ExitApp();
      }

      public override void initialize( )
      {
         GXKey = "";
         gxfirstwebparm = "";
         Gx_xmlwrt = new GXXMLWriter(context.GetPhysicalPath());
         P000G2_AV8Row = new short[1] ;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.areporteempleadoexcel__default(),
            new Object[][] {
                new Object[] {
               P000G2_AV8Row
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short gxcookieaux ;
      private short nGotPars ;
      private short GxWebError ;
      private short AV8Row ;
      private short cV8Row ;
      private string GXKey ;
      private string gxfirstwebparm ;
      private bool entryPointCalled ;
      private GXXMLWriter Gx_xmlwrt ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private short[] P000G2_AV8Row ;
   }

   public class areporteempleadoexcel__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmP000G2;
          prmP000G2 = new Object[] {
          };
          def= new CursorDef[] {
              new CursorDef("P000G2", "SELECT COUNT(*) FROM [Empleado] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP000G2,1, GxCacheFrequency.OFF ,true,false )
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
                return;
       }
    }

 }

}
