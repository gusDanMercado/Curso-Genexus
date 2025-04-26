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
using System.Threading;
using System.Xml.Serialization;
using System.Runtime.Serialization;
namespace GeneXus.Programs {
   public class empleado_dataprovider : GXProcedure
   {
      public empleado_dataprovider( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
      }

      public empleado_dataprovider( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( out GXBCCollection<SdtEmpleado> aP0_ReturnValue )
      {
         this.AV2ReturnValue = new GXBCCollection<SdtEmpleado>( context, "Empleado", "parques") ;
         initialize();
         ExecuteImpl();
         aP0_ReturnValue=this.AV2ReturnValue;
      }

      public GXBCCollection<SdtEmpleado> executeUdp( )
      {
         execute(out aP0_ReturnValue);
         return AV2ReturnValue ;
      }

      public void executeSubmit( out GXBCCollection<SdtEmpleado> aP0_ReturnValue )
      {
         this.AV2ReturnValue = new GXBCCollection<SdtEmpleado>( context, "Empleado", "parques") ;
         SubmitImpl();
         aP0_ReturnValue=this.AV2ReturnValue;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         args = new Object[] {(GXBCCollection<SdtEmpleado>)AV2ReturnValue} ;
         ClassLoader.Execute("aempleado_dataprovider","GeneXus.Programs","aempleado_dataprovider", new Object[] {context }, "execute", args);
         if ( ( args != null ) && ( args.Length == 1 ) )
         {
            AV2ReturnValue = (GXBCCollection<SdtEmpleado>)(args[0]) ;
         }
         cleanup();
      }

      public override void cleanup( )
      {
         CloseCursors();
         if ( IsMain )
         {
            context.CloseConnections();
         }
      }

      public override void initialize( )
      {
         AV2ReturnValue = new GXBCCollection<SdtEmpleado>( context, "Empleado", "parques");
         /* GeneXus formulas. */
      }

      private IGxDataStore dsDefault ;
      private GXBCCollection<SdtEmpleado> AV2ReturnValue ;
      private Object[] args ;
      private GXBCCollection<SdtEmpleado> aP0_ReturnValue ;
   }

}
