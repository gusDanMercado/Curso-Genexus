using System;
using System.Collections;
using GeneXus.Utils;
using GeneXus.Resources;
using GeneXus.Application;
using GeneXus.Metadata;
using GeneXus.Cryptography;
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
   public class aempleado_dataprovider : GXProcedure
   {
      public static int Main( string[] args )
      {
         return new aempleado_dataprovider().MainImpl(args); ;
      }

      public int executeCmdLine( string[] args )
      {
         return ExecuteCmdLine(args); ;
      }

      protected override int ExecuteCmdLine( string[] args )
      {
         GXBCCollection<SdtEmpleado> aP0_Gxm1rootcol = new GXBCCollection<SdtEmpleado>()  ;
         execute(out aP0_Gxm1rootcol);
         return GX.GXRuntime.ExitCode ;
      }

      public aempleado_dataprovider( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         IsMain = true;
         context.SetDefaultTheme("parques", true);
      }

      public aempleado_dataprovider( IGxContext context )
      {
         this.context = context;
         IsMain = false;
      }

      public void execute( out GXBCCollection<SdtEmpleado> aP0_Gxm1rootcol )
      {
         this.Gxm1rootcol = new GXBCCollection<SdtEmpleado>( context, "Empleado", "parques") ;
         initialize();
         ExecuteImpl();
         aP0_Gxm1rootcol=this.Gxm1rootcol;
      }

      public GXBCCollection<SdtEmpleado> executeUdp( )
      {
         execute(out aP0_Gxm1rootcol);
         return Gxm1rootcol ;
      }

      public void executeSubmit( out GXBCCollection<SdtEmpleado> aP0_Gxm1rootcol )
      {
         this.Gxm1rootcol = new GXBCCollection<SdtEmpleado>( context, "Empleado", "parques") ;
         SubmitImpl();
         aP0_Gxm1rootcol=this.Gxm1rootcol;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
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
         /* GeneXus formulas. */
      }

      private GXBCCollection<SdtEmpleado> Gxm1rootcol ;
      private GXBCCollection<SdtEmpleado> aP0_Gxm1rootcol ;
   }

}
