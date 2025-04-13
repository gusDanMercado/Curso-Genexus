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
   public class empleado : GXDataArea
   {
      protected void INITENV( )
      {
         if ( GxWebError != 0 )
         {
            return  ;
         }
      }

      protected void INITTRN( )
      {
         initialize_properties( ) ;
         entryPointCalled = false;
         gxfirstwebparm = GetFirstPar( "Mode");
         gxfirstwebparm_bkp = gxfirstwebparm;
         gxfirstwebparm = DecryptAjaxCall( gxfirstwebparm);
         toggleJsOutput = isJsOutputEnabled( );
         if ( context.isSpaRequest( ) )
         {
            disableJsOutput();
         }
         if ( StringUtil.StrCmp(gxfirstwebparm, "dyncall") == 0 )
         {
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            dyncall( GetNextPar( )) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_14") == 0 )
         {
            A13parqueAtraccionId = (short)(Math.Round(NumberUtil.Val( GetPar( "parqueAtraccionId"), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "A13parqueAtraccionId", StringUtil.LTrimStr( (decimal)(A13parqueAtraccionId), 4, 0));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_14( A13parqueAtraccionId) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxEvt") == 0 )
         {
            setAjaxEventMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxfirstwebparm = GetFirstPar( "Mode");
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxfullajaxEvt") == 0 )
         {
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxfirstwebparm = GetFirstPar( "Mode");
         }
         else
         {
            if ( ! IsValidAjaxCall( false) )
            {
               GxWebError = 1;
               return  ;
            }
            gxfirstwebparm = gxfirstwebparm_bkp;
         }
         if ( ! entryPointCalled && ! ( isAjaxCallMode( ) || isFullAjaxMode( ) ) )
         {
            Gx_mode = gxfirstwebparm;
            AssignAttri("", false, "Gx_mode", Gx_mode);
            if ( StringUtil.StrCmp(gxfirstwebparm, "viewer") != 0 )
            {
               AV7EmpleadoId = (short)(Math.Round(NumberUtil.Val( GetPar( "EmpleadoId"), "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV7EmpleadoId", StringUtil.LTrimStr( (decimal)(AV7EmpleadoId), 4, 0));
               GxWebStd.gx_hidden_field( context, "gxhash_vEMPLEADOID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV7EmpleadoId), "ZZZ9"), context));
            }
         }
         if ( toggleJsOutput )
         {
            if ( context.isSpaRequest( ) )
            {
               enableJsOutput();
            }
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( context.GetCookie( "GX_SESSION_ID"))) )
         {
            gxcookieaux = context.SetCookie( "GX_SESSION_ID", Encrypt64( Crypto.GetEncryptionKey( ), Crypto.GetServerKey( )), "", (DateTime)(DateTime.MinValue), "", (short)(context.GetHttpSecure( )));
         }
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         toggleJsOutput = isJsOutputEnabled( );
         if ( context.isSpaRequest( ) )
         {
            disableJsOutput();
         }
         init_web_controls( ) ;
         if ( toggleJsOutput )
         {
            if ( context.isSpaRequest( ) )
            {
               enableJsOutput();
            }
         }
         if ( ! context.isSpaRequest( ) )
         {
            if ( context.ExposeMetadata( ) )
            {
               Form.Meta.addItem("generator", "GeneXus .NET 18_0_10-184260", 0) ;
            }
         }
         Form.Meta.addItem("description", "Empleado", 0) ;
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         if ( ! context.isAjaxRequest( ) )
         {
            GX_FocusControl = edtEmpleadoNombre_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         wbErr = false;
         context.SetDefaultTheme("parques", true);
         if ( ! context.IsLocalStorageSupported( ) )
         {
            context.PushCurrentUrl();
         }
      }

      public empleado( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("parques", true);
      }

      public empleado( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_Gx_mode ,
                           short aP1_EmpleadoId )
      {
         this.Gx_mode = aP0_Gx_mode;
         this.AV7EmpleadoId = aP1_EmpleadoId;
         ExecuteImpl();
      }

      protected override void ExecutePrivate( )
      {
         isStatic = false;
         webExecute();
      }

      protected override void createObjects( )
      {
      }

      public override void webExecute( )
      {
         createObjects();
         initialize();
         INITENV( ) ;
         INITTRN( ) ;
         if ( ( GxWebError == 0 ) && ! isAjaxCallMode( ) )
         {
            MasterPageObj = (GXMasterPage) ClassLoader.GetInstance("general.ui.masterunanimosidebar", "GeneXus.Programs.general.ui.masterunanimosidebar", new Object[] {context});
            MasterPageObj.setDataArea(this,false);
            ValidateSpaRequest();
            MasterPageObj.webExecute();
            if ( ( GxWebError == 0 ) && context.isAjaxRequest( ) )
            {
               enableOutput();
               if ( ! context.isAjaxRequest( ) )
               {
                  context.GX_webresponse.AppendHeader("Cache-Control", "no-store");
               }
               if ( ! context.WillRedirect( ) )
               {
                  AddString( context.getJSONResponse( )) ;
               }
               else
               {
                  if ( context.isAjaxRequest( ) )
                  {
                     disableOutput();
                  }
                  RenderHtmlHeaders( ) ;
                  context.Redirect( context.wjLoc );
                  context.DispatchAjaxCommands();
               }
            }
         }
         cleanup();
      }

      protected void fix_multi_value_controls( )
      {
      }

      protected void Draw( )
      {
         if ( context.isAjaxRequest( ) )
         {
            disableOutput();
         }
         if ( ! GxWebStd.gx_redirect( context) )
         {
            disable_std_buttons( ) ;
            enableDisable( ) ;
            set_caption( ) ;
            /* Form start */
            DrawControls( ) ;
            fix_multi_value_controls( ) ;
         }
         /* Execute Exit event if defined. */
      }

      protected void DrawControls( )
      {
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Section", "start", "top", " "+"data-gx-base-lib=\"none\""+" "+"data-abstract-form"+" ", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divMaintable_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divTitlecontainer_Internalname, 1, 0, "px", 0, "px", "title-container", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTitle_Internalname, "Empleado", "", "", lblTitle_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "heading-01", 0, "", 1, 1, 0, 0, "HLP_Empleado.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
         ClassString = "ErrorViewer";
         StyleString = "";
         GxWebStd.gx_msg_list( context, "", context.GX_msglist.DisplayMode, StyleString, ClassString, "", "false");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divFormcontainer_Internalname, 1, 0, "px", 0, "px", "form-container", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divToolbarcell_Internalname, 1, 0, "px", 0, "px", "col-xs-12 col-sm-9 col-sm-offset-3 form__toolbar-cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-action-group ActionGroup", "start", "top", " "+"data-gx-actiongroup-type=\"toolbar\""+" ", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "btn-group", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 21,'',false,'',0)\"";
         ClassString = "Button button-auxiliary ico__arrow-first";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_first_Internalname, "", "", bttBtn_first_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_first_Visible, 0, "standard", "'"+""+"'"+",false,"+"'"+"EFIRST."+"'", TempTags, "", context.GetButtonType( ), "HLP_Empleado.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 23,'',false,'',0)\"";
         ClassString = "Button button-auxiliary ico__arrow-prev";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_previous_Internalname, "", "", bttBtn_previous_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_previous_Visible, 0, "standard", "'"+""+"'"+",false,"+"'"+"EPREVIOUS."+"'", TempTags, "", context.GetButtonType( ), "HLP_Empleado.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 25,'',false,'',0)\"";
         ClassString = "Button button-auxiliary ico__arrow-next";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_next_Internalname, "", "", bttBtn_next_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_next_Visible, 0, "standard", "'"+""+"'"+",false,"+"'"+"ENEXT."+"'", TempTags, "", context.GetButtonType( ), "HLP_Empleado.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 27,'',false,'',0)\"";
         ClassString = "Button button-auxiliary ico__arrow-last";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_last_Internalname, "", "", bttBtn_last_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_last_Visible, 0, "standard", "'"+""+"'"+",false,"+"'"+"ELAST."+"'", TempTags, "", context.GetButtonType( ), "HLP_Empleado.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 29,'',false,'',0)\"";
         ClassString = "Button button-secondary";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_select_Internalname, "", "Seleccionar", bttBtn_select_Jsonclick, 5, "Seleccionar", "", StyleString, ClassString, bttBtn_select_Visible, 0, "standard", "'"+""+"'"+",false,"+"'"+"ESELECT."+"'", TempTags, "", 2, "HLP_Empleado.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell-advanced", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtEmpleadoId_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtEmpleadoId_Internalname, "Id", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 34,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtEmpleadoId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A1EmpleadoId), 4, 0, ",", "")), StringUtil.LTrim( ((edtEmpleadoId_Enabled!=0) ? context.localUtil.Format( (decimal)(A1EmpleadoId), "ZZZ9") : context.localUtil.Format( (decimal)(A1EmpleadoId), "ZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,34);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtEmpleadoId_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtEmpleadoId_Enabled, 0, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_Empleado.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtEmpleadoNombre_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtEmpleadoNombre_Internalname, "Nombre", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Multiple line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 39,'',false,'',0)\"";
         ClassString = "Attribute";
         StyleString = "";
         ClassString = "Attribute";
         StyleString = "";
         GxWebStd.gx_html_textarea( context, edtEmpleadoNombre_Internalname, A2EmpleadoNombre, "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,39);\"", 0, 1, edtEmpleadoNombre_Enabled, 0, 80, "chr", 10, "row", 0, StyleString, ClassString, "", "", "1024", -1, 0, "", "", -1, true, "", "'"+""+"'"+",false,"+"'"+""+"'", 0, "", "HLP_Empleado.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtEmpleadoApellido_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtEmpleadoApellido_Internalname, "Apellido", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Multiple line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 44,'',false,'',0)\"";
         ClassString = "Attribute";
         StyleString = "";
         ClassString = "Attribute";
         StyleString = "";
         GxWebStd.gx_html_textarea( context, edtEmpleadoApellido_Internalname, A3EmpleadoApellido, "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,44);\"", 0, 1, edtEmpleadoApellido_Enabled, 0, 80, "chr", 10, "row", 0, StyleString, ClassString, "", "", "1024", -1, 0, "", "", -1, true, "", "'"+""+"'"+",false,"+"'"+""+"'", 0, "", "HLP_Empleado.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtEmpleadoDireccion_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtEmpleadoDireccion_Internalname, "Direccion", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Multiple line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 49,'',false,'',0)\"";
         ClassString = "Attribute";
         StyleString = "";
         ClassString = "Attribute";
         StyleString = "";
         GxWebStd.gx_html_textarea( context, edtEmpleadoDireccion_Internalname, A4EmpleadoDireccion, "http://maps.google.com/maps?q="+GXUtil.UrlEncode( A4EmpleadoDireccion), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,49);\"", 0, 1, edtEmpleadoDireccion_Enabled, 0, 80, "chr", 10, "row", 0, StyleString, ClassString, "", "", "1024", -1, 0, "_blank", "", 0, true, "GeneXus\\Address", "'"+""+"'"+",false,"+"'"+""+"'", 0, "", "HLP_Empleado.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtEmpleadoTelefono_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtEmpleadoTelefono_Internalname, "Telefono", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         if ( context.isSmartDevice( ) )
         {
            gxphoneLink = "tel:" + StringUtil.RTrim( A5EmpleadoTelefono);
         }
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 54,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtEmpleadoTelefono_Internalname, StringUtil.RTrim( A5EmpleadoTelefono), StringUtil.RTrim( context.localUtil.Format( A5EmpleadoTelefono, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,54);\"", "'"+""+"'"+",false,"+"'"+""+"'", gxphoneLink, "", "", "", edtEmpleadoTelefono_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtEmpleadoTelefono_Enabled, 0, "tel", "", 20, "chr", 1, "row", 20, 0, 0, 0, 0, -1, 0, true, "GeneXus\\Phone", "start", true, "", "HLP_Empleado.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtEmpleadoEmail_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtEmpleadoEmail_Internalname, "Email", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 59,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtEmpleadoEmail_Internalname, A6EmpleadoEmail, StringUtil.RTrim( context.localUtil.Format( A6EmpleadoEmail, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,59);\"", "'"+""+"'"+",false,"+"'"+""+"'", "mailto:"+A6EmpleadoEmail, "", "", "", edtEmpleadoEmail_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtEmpleadoEmail_Enabled, 0, "email", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, 0, true, "GeneXus\\Email", "start", true, "", "HLP_Empleado.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtEmpleadoFch_Alta_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtEmpleadoFch_Alta_Internalname, "Fch_Alta", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 64,'',false,'',0)\"";
         context.WriteHtmlText( "<div id=\""+edtEmpleadoFch_Alta_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
         GxWebStd.gx_single_line_edit( context, edtEmpleadoFch_Alta_Internalname, context.localUtil.TToC( A7EmpleadoFch_Alta, 10, 8, 0, 3, "/", ":", " "), context.localUtil.Format( A7EmpleadoFch_Alta, "99/99/99 99:99"), TempTags+" onchange=\""+"gx.date.valid_date(this, 8,'DMY',5,24,'spa',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 8,'DMY',5,24,'spa',false,0);"+";gx.evt.onblur(this,64);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtEmpleadoFch_Alta_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtEmpleadoFch_Alta_Enabled, 0, "text", "", 14, "chr", 1, "row", 14, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_Empleado.htm");
         GxWebStd.gx_bitmap( context, edtEmpleadoFch_Alta_Internalname+"_dp_trigger", context.GetImagePath( "", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtEmpleadoFch_Alta_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_Empleado.htm");
         context.WriteHtmlTextNl( "</div>") ;
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtEmpleadoFcha_Mod_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtEmpleadoFcha_Mod_Internalname, "Fcha_Mod", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 69,'',false,'',0)\"";
         context.WriteHtmlText( "<div id=\""+edtEmpleadoFcha_Mod_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
         GxWebStd.gx_single_line_edit( context, edtEmpleadoFcha_Mod_Internalname, context.localUtil.TToC( A8EmpleadoFcha_Mod, 10, 8, 0, 3, "/", ":", " "), context.localUtil.Format( A8EmpleadoFcha_Mod, "99/99/99 99:99"), TempTags+" onchange=\""+"gx.date.valid_date(this, 8,'DMY',5,24,'spa',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 8,'DMY',5,24,'spa',false,0);"+";gx.evt.onblur(this,69);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtEmpleadoFcha_Mod_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtEmpleadoFcha_Mod_Enabled, 0, "text", "", 14, "chr", 1, "row", 14, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_Empleado.htm");
         GxWebStd.gx_bitmap( context, edtEmpleadoFcha_Mod_Internalname+"_dp_trigger", context.GetImagePath( "", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtEmpleadoFcha_Mod_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_Empleado.htm");
         context.WriteHtmlTextNl( "</div>") ;
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtEmpleadoFch_Cad_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtEmpleadoFch_Cad_Internalname, "Fch_Cad", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 74,'',false,'',0)\"";
         context.WriteHtmlText( "<div id=\""+edtEmpleadoFch_Cad_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
         GxWebStd.gx_single_line_edit( context, edtEmpleadoFch_Cad_Internalname, context.localUtil.TToC( A9EmpleadoFch_Cad, 10, 8, 0, 3, "/", ":", " "), context.localUtil.Format( A9EmpleadoFch_Cad, "99/99/99 99:99"), TempTags+" onchange=\""+"gx.date.valid_date(this, 8,'DMY',5,24,'spa',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 8,'DMY',5,24,'spa',false,0);"+";gx.evt.onblur(this,74);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtEmpleadoFch_Cad_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtEmpleadoFch_Cad_Enabled, 0, "text", "", 14, "chr", 1, "row", 14, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_Empleado.htm");
         GxWebStd.gx_bitmap( context, edtEmpleadoFch_Cad_Internalname+"_dp_trigger", context.GetImagePath( "", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtEmpleadoFch_Cad_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_Empleado.htm");
         context.WriteHtmlTextNl( "</div>") ;
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtEmpleadoUsu_Alta_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtEmpleadoUsu_Alta_Internalname, "Usu_Alta", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 79,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtEmpleadoUsu_Alta_Internalname, A10EmpleadoUsu_Alta, StringUtil.RTrim( context.localUtil.Format( A10EmpleadoUsu_Alta, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,79);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtEmpleadoUsu_Alta_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtEmpleadoUsu_Alta_Enabled, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_Empleado.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtEmpleadoUsu_Mod_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtEmpleadoUsu_Mod_Internalname, "Usu_Mod", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 84,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtEmpleadoUsu_Mod_Internalname, A11EmpleadoUsu_Mod, StringUtil.RTrim( context.localUtil.Format( A11EmpleadoUsu_Mod, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,84);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtEmpleadoUsu_Mod_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtEmpleadoUsu_Mod_Enabled, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_Empleado.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtEmpleadoUso_Cad_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtEmpleadoUso_Cad_Internalname, "Uso_Cad", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 89,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtEmpleadoUso_Cad_Internalname, A12EmpleadoUso_Cad, StringUtil.RTrim( context.localUtil.Format( A12EmpleadoUso_Cad, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,89);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtEmpleadoUso_Cad_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtEmpleadoUso_Cad_Enabled, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_Empleado.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtparqueAtraccionId_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtparqueAtraccionId_Internalname, "parque Atraccion Id", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 94,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtparqueAtraccionId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A13parqueAtraccionId), 4, 0, ",", "")), StringUtil.LTrim( context.localUtil.Format( (decimal)(A13parqueAtraccionId), "ZZZ9")), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,94);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtparqueAtraccionId_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtparqueAtraccionId_Enabled, 1, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_Empleado.htm");
         /* Static images/pictures */
         ClassString = "gx-prompt Image" + " " + ((StringUtil.StrCmp(imgprompt_13_gximage, "")==0) ? "" : "GX_Image_"+imgprompt_13_gximage+"_Class");
         StyleString = "";
         sImgUrl = (string)(context.GetImagePath( "prompt.gif", "", context.GetTheme( )));
         GxWebStd.gx_bitmap( context, imgprompt_13_Internalname, sImgUrl, imgprompt_13_Link, "", "", context.GetTheme( ), imgprompt_13_Visible, 1, "", "", 0, 0, 0, "", 0, "", 0, 0, 0, "", "", StyleString, ClassString, "", "", "", "", "", "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_Empleado.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtparqueAtraccionNombre_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtparqueAtraccionNombre_Internalname, "parque Atraccion Nombre", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 99,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtparqueAtraccionNombre_Internalname, A14parqueAtraccionNombre, StringUtil.RTrim( context.localUtil.Format( A14parqueAtraccionNombre, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,99);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtparqueAtraccionNombre_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtparqueAtraccionNombre_Enabled, 0, "text", "", 20, "chr", 1, "row", 20, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_Empleado.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__actions--fixed", "end", "Middle", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-action-group", "start", "top", " "+"data-gx-actiongroup-type=\"toolbar\""+" ", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 104,'',false,'',0)\"";
         ClassString = "Button button-primary";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_enter_Internalname, "", bttBtn_enter_Caption, bttBtn_enter_Jsonclick, 5, bttBtn_enter_Tooltiptext, "", StyleString, ClassString, bttBtn_enter_Visible, bttBtn_enter_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_Empleado.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 106,'',false,'',0)\"";
         ClassString = "Button button-tertiary";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_cancel_Internalname, "", "Cancelar", bttBtn_cancel_Jsonclick, 1, "Cancelar", "", StyleString, ClassString, bttBtn_cancel_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_Empleado.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 108,'',false,'',0)\"";
         ClassString = "Button button-tertiary";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_delete_Internalname, "", "Eliminar", bttBtn_delete_Jsonclick, 5, "Eliminar", "", StyleString, ClassString, bttBtn_delete_Visible, bttBtn_delete_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EDELETE."+"'", TempTags, "", context.GetButtonType( ), "HLP_Empleado.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "end", "Middle", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
      }

      protected void UserMain( )
      {
         standaloneStartup( ) ;
      }

      protected void UserMainFullajax( )
      {
         INITENV( ) ;
         INITTRN( ) ;
         UserMain( ) ;
         Draw( ) ;
         SendCloseFormHiddens( ) ;
      }

      protected void standaloneStartup( )
      {
         standaloneStartupServer( ) ;
         disable_std_buttons( ) ;
         enableDisable( ) ;
         Process( ) ;
      }

      protected void standaloneStartupServer( )
      {
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E11012 ();
         context.wbGlbDoneStart = 1;
         assign_properties_default( ) ;
         if ( AnyError == 0 )
         {
            if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
            {
               /* Read saved SDTs. */
               /* Read saved values. */
               Z1EmpleadoId = (short)(Math.Round(context.localUtil.CToN( cgiGet( "Z1EmpleadoId"), ",", "."), 18, MidpointRounding.ToEven));
               Z2EmpleadoNombre = cgiGet( "Z2EmpleadoNombre");
               Z3EmpleadoApellido = cgiGet( "Z3EmpleadoApellido");
               Z4EmpleadoDireccion = cgiGet( "Z4EmpleadoDireccion");
               n4EmpleadoDireccion = (String.IsNullOrEmpty(StringUtil.RTrim( A4EmpleadoDireccion)) ? true : false);
               Z5EmpleadoTelefono = cgiGet( "Z5EmpleadoTelefono");
               n5EmpleadoTelefono = (String.IsNullOrEmpty(StringUtil.RTrim( A5EmpleadoTelefono)) ? true : false);
               Z6EmpleadoEmail = cgiGet( "Z6EmpleadoEmail");
               n6EmpleadoEmail = (String.IsNullOrEmpty(StringUtil.RTrim( A6EmpleadoEmail)) ? true : false);
               Z7EmpleadoFch_Alta = context.localUtil.CToT( cgiGet( "Z7EmpleadoFch_Alta"), 0);
               n7EmpleadoFch_Alta = ((DateTime.MinValue==A7EmpleadoFch_Alta) ? true : false);
               Z8EmpleadoFcha_Mod = context.localUtil.CToT( cgiGet( "Z8EmpleadoFcha_Mod"), 0);
               n8EmpleadoFcha_Mod = ((DateTime.MinValue==A8EmpleadoFcha_Mod) ? true : false);
               Z9EmpleadoFch_Cad = context.localUtil.CToT( cgiGet( "Z9EmpleadoFch_Cad"), 0);
               n9EmpleadoFch_Cad = ((DateTime.MinValue==A9EmpleadoFch_Cad) ? true : false);
               Z10EmpleadoUsu_Alta = cgiGet( "Z10EmpleadoUsu_Alta");
               n10EmpleadoUsu_Alta = (String.IsNullOrEmpty(StringUtil.RTrim( A10EmpleadoUsu_Alta)) ? true : false);
               Z11EmpleadoUsu_Mod = cgiGet( "Z11EmpleadoUsu_Mod");
               n11EmpleadoUsu_Mod = (String.IsNullOrEmpty(StringUtil.RTrim( A11EmpleadoUsu_Mod)) ? true : false);
               Z12EmpleadoUso_Cad = cgiGet( "Z12EmpleadoUso_Cad");
               n12EmpleadoUso_Cad = (String.IsNullOrEmpty(StringUtil.RTrim( A12EmpleadoUso_Cad)) ? true : false);
               Z13parqueAtraccionId = (short)(Math.Round(context.localUtil.CToN( cgiGet( "Z13parqueAtraccionId"), ",", "."), 18, MidpointRounding.ToEven));
               IsConfirmed = (short)(Math.Round(context.localUtil.CToN( cgiGet( "IsConfirmed"), ",", "."), 18, MidpointRounding.ToEven));
               IsModified = (short)(Math.Round(context.localUtil.CToN( cgiGet( "IsModified"), ",", "."), 18, MidpointRounding.ToEven));
               Gx_mode = cgiGet( "Mode");
               N13parqueAtraccionId = (short)(Math.Round(context.localUtil.CToN( cgiGet( "N13parqueAtraccionId"), ",", "."), 18, MidpointRounding.ToEven));
               AV7EmpleadoId = (short)(Math.Round(context.localUtil.CToN( cgiGet( "vEMPLEADOID"), ",", "."), 18, MidpointRounding.ToEven));
               Gx_BScreen = (short)(Math.Round(context.localUtil.CToN( cgiGet( "vGXBSCREEN"), ",", "."), 18, MidpointRounding.ToEven));
               AV11Insert_parqueAtraccionId = (short)(Math.Round(context.localUtil.CToN( cgiGet( "vINSERT_PARQUEATRACCIONID"), ",", "."), 18, MidpointRounding.ToEven));
               AV13Pgmname = cgiGet( "vPGMNAME");
               /* Read variables values. */
               A1EmpleadoId = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtEmpleadoId_Internalname), ",", "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "A1EmpleadoId", StringUtil.LTrimStr( (decimal)(A1EmpleadoId), 4, 0));
               A2EmpleadoNombre = cgiGet( edtEmpleadoNombre_Internalname);
               AssignAttri("", false, "A2EmpleadoNombre", A2EmpleadoNombre);
               A3EmpleadoApellido = cgiGet( edtEmpleadoApellido_Internalname);
               AssignAttri("", false, "A3EmpleadoApellido", A3EmpleadoApellido);
               A4EmpleadoDireccion = cgiGet( edtEmpleadoDireccion_Internalname);
               n4EmpleadoDireccion = false;
               AssignAttri("", false, "A4EmpleadoDireccion", A4EmpleadoDireccion);
               n4EmpleadoDireccion = (String.IsNullOrEmpty(StringUtil.RTrim( A4EmpleadoDireccion)) ? true : false);
               A5EmpleadoTelefono = cgiGet( edtEmpleadoTelefono_Internalname);
               n5EmpleadoTelefono = false;
               AssignAttri("", false, "A5EmpleadoTelefono", A5EmpleadoTelefono);
               n5EmpleadoTelefono = (String.IsNullOrEmpty(StringUtil.RTrim( A5EmpleadoTelefono)) ? true : false);
               A6EmpleadoEmail = cgiGet( edtEmpleadoEmail_Internalname);
               n6EmpleadoEmail = false;
               AssignAttri("", false, "A6EmpleadoEmail", A6EmpleadoEmail);
               n6EmpleadoEmail = (String.IsNullOrEmpty(StringUtil.RTrim( A6EmpleadoEmail)) ? true : false);
               if ( context.localUtil.VCDateTime( cgiGet( edtEmpleadoFch_Alta_Internalname), 2, 0) == 0 )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_baddatetime", new   object[]  {"Empleado Fch_Alta"}), 1, "EMPLEADOFCH_ALTA");
                  AnyError = 1;
                  GX_FocusControl = edtEmpleadoFch_Alta_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A7EmpleadoFch_Alta = (DateTime)(DateTime.MinValue);
                  n7EmpleadoFch_Alta = false;
                  AssignAttri("", false, "A7EmpleadoFch_Alta", context.localUtil.TToC( A7EmpleadoFch_Alta, 8, 5, 0, 3, "/", ":", " "));
               }
               else
               {
                  A7EmpleadoFch_Alta = context.localUtil.CToT( cgiGet( edtEmpleadoFch_Alta_Internalname));
                  n7EmpleadoFch_Alta = false;
                  AssignAttri("", false, "A7EmpleadoFch_Alta", context.localUtil.TToC( A7EmpleadoFch_Alta, 8, 5, 0, 3, "/", ":", " "));
               }
               n7EmpleadoFch_Alta = ((DateTime.MinValue==A7EmpleadoFch_Alta) ? true : false);
               if ( context.localUtil.VCDateTime( cgiGet( edtEmpleadoFcha_Mod_Internalname), 2, 0) == 0 )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_baddatetime", new   object[]  {"Empleado Fcha_Mod"}), 1, "EMPLEADOFCHA_MOD");
                  AnyError = 1;
                  GX_FocusControl = edtEmpleadoFcha_Mod_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A8EmpleadoFcha_Mod = (DateTime)(DateTime.MinValue);
                  n8EmpleadoFcha_Mod = false;
                  AssignAttri("", false, "A8EmpleadoFcha_Mod", context.localUtil.TToC( A8EmpleadoFcha_Mod, 8, 5, 0, 3, "/", ":", " "));
               }
               else
               {
                  A8EmpleadoFcha_Mod = context.localUtil.CToT( cgiGet( edtEmpleadoFcha_Mod_Internalname));
                  n8EmpleadoFcha_Mod = false;
                  AssignAttri("", false, "A8EmpleadoFcha_Mod", context.localUtil.TToC( A8EmpleadoFcha_Mod, 8, 5, 0, 3, "/", ":", " "));
               }
               n8EmpleadoFcha_Mod = ((DateTime.MinValue==A8EmpleadoFcha_Mod) ? true : false);
               if ( context.localUtil.VCDateTime( cgiGet( edtEmpleadoFch_Cad_Internalname), 2, 0) == 0 )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_baddatetime", new   object[]  {"Empleado Fch_Cad"}), 1, "EMPLEADOFCH_CAD");
                  AnyError = 1;
                  GX_FocusControl = edtEmpleadoFch_Cad_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A9EmpleadoFch_Cad = (DateTime)(DateTime.MinValue);
                  n9EmpleadoFch_Cad = false;
                  AssignAttri("", false, "A9EmpleadoFch_Cad", context.localUtil.TToC( A9EmpleadoFch_Cad, 8, 5, 0, 3, "/", ":", " "));
               }
               else
               {
                  A9EmpleadoFch_Cad = context.localUtil.CToT( cgiGet( edtEmpleadoFch_Cad_Internalname));
                  n9EmpleadoFch_Cad = false;
                  AssignAttri("", false, "A9EmpleadoFch_Cad", context.localUtil.TToC( A9EmpleadoFch_Cad, 8, 5, 0, 3, "/", ":", " "));
               }
               n9EmpleadoFch_Cad = ((DateTime.MinValue==A9EmpleadoFch_Cad) ? true : false);
               A10EmpleadoUsu_Alta = cgiGet( edtEmpleadoUsu_Alta_Internalname);
               n10EmpleadoUsu_Alta = false;
               AssignAttri("", false, "A10EmpleadoUsu_Alta", A10EmpleadoUsu_Alta);
               n10EmpleadoUsu_Alta = (String.IsNullOrEmpty(StringUtil.RTrim( A10EmpleadoUsu_Alta)) ? true : false);
               A11EmpleadoUsu_Mod = cgiGet( edtEmpleadoUsu_Mod_Internalname);
               n11EmpleadoUsu_Mod = false;
               AssignAttri("", false, "A11EmpleadoUsu_Mod", A11EmpleadoUsu_Mod);
               n11EmpleadoUsu_Mod = (String.IsNullOrEmpty(StringUtil.RTrim( A11EmpleadoUsu_Mod)) ? true : false);
               A12EmpleadoUso_Cad = cgiGet( edtEmpleadoUso_Cad_Internalname);
               n12EmpleadoUso_Cad = false;
               AssignAttri("", false, "A12EmpleadoUso_Cad", A12EmpleadoUso_Cad);
               n12EmpleadoUso_Cad = (String.IsNullOrEmpty(StringUtil.RTrim( A12EmpleadoUso_Cad)) ? true : false);
               if ( ( ( context.localUtil.CToN( cgiGet( edtparqueAtraccionId_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtparqueAtraccionId_Internalname), ",", ".") > Convert.ToDecimal( 9999 )) ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "PARQUEATRACCIONID");
                  AnyError = 1;
                  GX_FocusControl = edtparqueAtraccionId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A13parqueAtraccionId = 0;
                  AssignAttri("", false, "A13parqueAtraccionId", StringUtil.LTrimStr( (decimal)(A13parqueAtraccionId), 4, 0));
               }
               else
               {
                  A13parqueAtraccionId = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtparqueAtraccionId_Internalname), ",", "."), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, "A13parqueAtraccionId", StringUtil.LTrimStr( (decimal)(A13parqueAtraccionId), 4, 0));
               }
               A14parqueAtraccionNombre = cgiGet( edtparqueAtraccionNombre_Internalname);
               AssignAttri("", false, "A14parqueAtraccionNombre", A14parqueAtraccionNombre);
               /* Read subfile selected row values. */
               /* Read hidden variables. */
               GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
               forbiddenHiddens = new GXProperties();
               forbiddenHiddens.Add("hshsalt", "hsh"+"Empleado");
               A1EmpleadoId = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtEmpleadoId_Internalname), ",", "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "A1EmpleadoId", StringUtil.LTrimStr( (decimal)(A1EmpleadoId), 4, 0));
               forbiddenHiddens.Add("EmpleadoId", context.localUtil.Format( (decimal)(A1EmpleadoId), "ZZZ9"));
               forbiddenHiddens.Add("Gx_mode", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")));
               hsh = cgiGet( "hsh");
               if ( ( ! ( ( A1EmpleadoId != Z1EmpleadoId ) ) || ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) ) && ! GXUtil.CheckEncryptedHash( forbiddenHiddens.ToString(), hsh, GXKey) )
               {
                  GXUtil.WriteLogError("empleado:[ SecurityCheckFailed (403 Forbidden) value for]"+forbiddenHiddens.ToJSonString());
                  GxWebError = 1;
                  context.HttpContext.Response.StatusCode = 403;
                  context.WriteHtmlText( "<title>403 Forbidden</title>") ;
                  context.WriteHtmlText( "<h1>403 Forbidden</h1>") ;
                  context.WriteHtmlText( "<p /><hr />") ;
                  GXUtil.WriteLog("send_http_error_code " + 403.ToString());
                  AnyError = 1;
                  return  ;
               }
               standaloneNotModal( ) ;
            }
            else
            {
               standaloneNotModal( ) ;
               if ( StringUtil.StrCmp(gxfirstwebparm, "viewer") == 0 )
               {
                  Gx_mode = "DSP";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  A1EmpleadoId = (short)(Math.Round(NumberUtil.Val( GetPar( "EmpleadoId"), "."), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, "A1EmpleadoId", StringUtil.LTrimStr( (decimal)(A1EmpleadoId), 4, 0));
                  getEqualNoModal( ) ;
                  if ( ! (0==AV7EmpleadoId) )
                  {
                     A1EmpleadoId = AV7EmpleadoId;
                     AssignAttri("", false, "A1EmpleadoId", StringUtil.LTrimStr( (decimal)(A1EmpleadoId), 4, 0));
                  }
                  else
                  {
                     if ( IsIns( )  && (0==A1EmpleadoId) && ( Gx_BScreen == 0 ) )
                     {
                        A1EmpleadoId = 1;
                        AssignAttri("", false, "A1EmpleadoId", StringUtil.LTrimStr( (decimal)(A1EmpleadoId), 4, 0));
                     }
                  }
                  Gx_mode = "DSP";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  disable_std_buttons( ) ;
                  standaloneModal( ) ;
               }
               else
               {
                  if ( IsDsp( ) )
                  {
                     sMode1 = Gx_mode;
                     Gx_mode = "UPD";
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                     if ( ! (0==AV7EmpleadoId) )
                     {
                        A1EmpleadoId = AV7EmpleadoId;
                        AssignAttri("", false, "A1EmpleadoId", StringUtil.LTrimStr( (decimal)(A1EmpleadoId), 4, 0));
                     }
                     else
                     {
                        if ( IsIns( )  && (0==A1EmpleadoId) && ( Gx_BScreen == 0 ) )
                        {
                           A1EmpleadoId = 1;
                           AssignAttri("", false, "A1EmpleadoId", StringUtil.LTrimStr( (decimal)(A1EmpleadoId), 4, 0));
                        }
                     }
                     Gx_mode = sMode1;
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                  }
                  standaloneModal( ) ;
                  if ( ! IsIns( ) )
                  {
                     getByPrimaryKey( ) ;
                     if ( RcdFound1 == 1 )
                     {
                        if ( IsDlt( ) )
                        {
                           /* Confirm record */
                           CONFIRM_010( ) ;
                           if ( AnyError == 0 )
                           {
                              GX_FocusControl = bttBtn_enter_Internalname;
                              AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                           }
                        }
                     }
                     else
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_noinsert", ""), 1, "EMPLEADOID");
                        AnyError = 1;
                        GX_FocusControl = edtEmpleadoId_Internalname;
                        AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     }
                  }
               }
            }
         }
      }

      protected void Process( )
      {
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
            /* Read Transaction buttons. */
            sEvt = cgiGet( "_EventName");
            EvtGridId = cgiGet( "_EventGridId");
            EvtRowId = cgiGet( "_EventRowId");
            if ( StringUtil.Len( sEvt) > 0 )
            {
               sEvtType = StringUtil.Left( sEvt, 1);
               sEvt = StringUtil.Right( sEvt, (short)(StringUtil.Len( sEvt)-1));
               if ( StringUtil.StrCmp(sEvtType, "M") != 0 )
               {
                  if ( StringUtil.StrCmp(sEvtType, "E") == 0 )
                  {
                     sEvtType = StringUtil.Right( sEvt, 1);
                     if ( StringUtil.StrCmp(sEvtType, ".") == 0 )
                     {
                        sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-1));
                        if ( StringUtil.StrCmp(sEvt, "START") == 0 )
                        {
                           context.wbHandled = 1;
                           dynload_actions( ) ;
                           /* Execute user event: Start */
                           E11012 ();
                        }
                        else if ( StringUtil.StrCmp(sEvt, "AFTER TRN") == 0 )
                        {
                           context.wbHandled = 1;
                           dynload_actions( ) ;
                           /* Execute user event: After Trn */
                           E12012 ();
                        }
                        else if ( StringUtil.StrCmp(sEvt, "ENTER") == 0 )
                        {
                           context.wbHandled = 1;
                           if ( ! IsDsp( ) )
                           {
                              btn_enter( ) ;
                           }
                           /* No code required for Cancel button. It is implemented as the Reset button. */
                        }
                     }
                     else
                     {
                     }
                  }
                  context.wbHandled = 1;
               }
            }
         }
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
            E12012 ();
            trnEnded = 0;
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            if ( IsIns( )  )
            {
               /* Clear variables for new insertion. */
               InitAll011( ) ;
               standaloneNotModal( ) ;
               standaloneModal( ) ;
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

      protected void disable_std_buttons( )
      {
         bttBtn_delete_Visible = 0;
         AssignProp("", false, bttBtn_delete_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtn_delete_Visible), 5, 0), true);
         bttBtn_first_Visible = 0;
         AssignProp("", false, bttBtn_first_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtn_first_Visible), 5, 0), true);
         bttBtn_previous_Visible = 0;
         AssignProp("", false, bttBtn_previous_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtn_previous_Visible), 5, 0), true);
         bttBtn_next_Visible = 0;
         AssignProp("", false, bttBtn_next_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtn_next_Visible), 5, 0), true);
         bttBtn_last_Visible = 0;
         AssignProp("", false, bttBtn_last_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtn_last_Visible), 5, 0), true);
         bttBtn_select_Visible = 0;
         AssignProp("", false, bttBtn_select_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtn_select_Visible), 5, 0), true);
         if ( IsDsp( ) || IsDlt( ) )
         {
            bttBtn_delete_Visible = 0;
            AssignProp("", false, bttBtn_delete_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtn_delete_Visible), 5, 0), true);
            if ( IsDsp( ) )
            {
               bttBtn_enter_Visible = 0;
               AssignProp("", false, bttBtn_enter_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtn_enter_Visible), 5, 0), true);
            }
            DisableAttributes011( ) ;
         }
      }

      protected void set_caption( )
      {
         if ( ( IsConfirmed == 1 ) && ( AnyError == 0 ) )
         {
            if ( IsDlt( ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_confdelete", ""), 0, "", true);
            }
            else
            {
               GX_msglist.addItem(context.GetMessage( "GXM_mustconfirm", ""), 0, "", true);
            }
         }
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
               CloseExtendedTableCursors011( ) ;
            }
         }
         if ( AnyError == 0 )
         {
            IsConfirmed = 1;
            AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         }
      }

      protected void ResetCaption010( )
      {
      }

      protected void E11012( )
      {
         /* Start Routine */
         returnInSub = false;
         if ( ! new GeneXus.Programs.general.security.isauthorized(context).executeUdp(  AV13Pgmname) )
         {
            CallWebObject(formatLink("general.security.notauthorized.aspx", new object[] {UrlEncode(StringUtil.RTrim(AV13Pgmname))}, new string[] {"GxObject"}) );
            context.wjLocDisableFrm = 1;
         }
         AV9TrnContext.FromXml(AV10WebSession.Get("TrnContext"), null, "", "");
         AV11Insert_parqueAtraccionId = 0;
         AssignAttri("", false, "AV11Insert_parqueAtraccionId", StringUtil.LTrimStr( (decimal)(AV11Insert_parqueAtraccionId), 4, 0));
         if ( ( StringUtil.StrCmp(AV9TrnContext.gxTpr_Transactionname, AV13Pgmname) == 0 ) && ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) )
         {
            AV14GXV1 = 1;
            AssignAttri("", false, "AV14GXV1", StringUtil.LTrimStr( (decimal)(AV14GXV1), 8, 0));
            while ( AV14GXV1 <= AV9TrnContext.gxTpr_Attributes.Count )
            {
               AV12TrnContextAtt = ((GeneXus.Programs.general.ui.SdtTransactionContext_Attribute)AV9TrnContext.gxTpr_Attributes.Item(AV14GXV1));
               if ( StringUtil.StrCmp(AV12TrnContextAtt.gxTpr_Attributename, "parqueAtraccionId") == 0 )
               {
                  AV11Insert_parqueAtraccionId = (short)(Math.Round(NumberUtil.Val( AV12TrnContextAtt.gxTpr_Attributevalue, "."), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, "AV11Insert_parqueAtraccionId", StringUtil.LTrimStr( (decimal)(AV11Insert_parqueAtraccionId), 4, 0));
               }
               AV14GXV1 = (int)(AV14GXV1+1);
               AssignAttri("", false, "AV14GXV1", StringUtil.LTrimStr( (decimal)(AV14GXV1), 8, 0));
            }
         }
         if ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 )
         {
            bttBtn_enter_Caption = "Eliminar";
            AssignProp("", false, bttBtn_enter_Internalname, "Caption", bttBtn_enter_Caption, true);
            bttBtn_enter_Tooltiptext = "Eliminar";
            AssignProp("", false, bttBtn_enter_Internalname, "Tooltiptext", bttBtn_enter_Tooltiptext, true);
         }
      }

      protected void E12012( )
      {
         /* After Trn Routine */
         returnInSub = false;
         if ( ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 ) && ! AV9TrnContext.gxTpr_Callerondelete )
         {
            CallWebObject(formatLink("wwempleado.aspx") );
            context.wjLocDisableFrm = 1;
         }
         context.setWebReturnParms(new Object[] {});
         context.setWebReturnParmsMetadata(new Object[] {});
         context.wjLocDisableFrm = 1;
         context.nUserReturn = 1;
         returnInSub = true;
         if (true) return;
      }

      protected void ZM011( short GX_JID )
      {
         if ( ( GX_JID == 13 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z2EmpleadoNombre = T00013_A2EmpleadoNombre[0];
               Z3EmpleadoApellido = T00013_A3EmpleadoApellido[0];
               Z4EmpleadoDireccion = T00013_A4EmpleadoDireccion[0];
               Z5EmpleadoTelefono = T00013_A5EmpleadoTelefono[0];
               Z6EmpleadoEmail = T00013_A6EmpleadoEmail[0];
               Z7EmpleadoFch_Alta = T00013_A7EmpleadoFch_Alta[0];
               Z8EmpleadoFcha_Mod = T00013_A8EmpleadoFcha_Mod[0];
               Z9EmpleadoFch_Cad = T00013_A9EmpleadoFch_Cad[0];
               Z10EmpleadoUsu_Alta = T00013_A10EmpleadoUsu_Alta[0];
               Z11EmpleadoUsu_Mod = T00013_A11EmpleadoUsu_Mod[0];
               Z12EmpleadoUso_Cad = T00013_A12EmpleadoUso_Cad[0];
               Z13parqueAtraccionId = T00013_A13parqueAtraccionId[0];
            }
            else
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
         }
         if ( GX_JID == -13 )
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
         edtEmpleadoId_Enabled = 0;
         AssignProp("", false, edtEmpleadoId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtEmpleadoId_Enabled), 5, 0), true);
         Gx_BScreen = 0;
         AssignAttri("", false, "Gx_BScreen", StringUtil.Str( (decimal)(Gx_BScreen), 1, 0));
         imgprompt_13_Link = ((StringUtil.StrCmp(Gx_mode, "DSP")==0) ? "" : "javascript:"+"gx.popup.openPrompt('"+"gx0020.aspx"+"',["+"{Ctrl:gx.dom.el('"+"PARQUEATRACCIONID"+"'), id:'"+"PARQUEATRACCIONID"+"'"+",IOType:'out'}"+"],"+"null"+","+"'', false"+","+"false"+");");
         edtEmpleadoId_Enabled = 0;
         AssignProp("", false, edtEmpleadoId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtEmpleadoId_Enabled), 5, 0), true);
         bttBtn_delete_Enabled = 0;
         AssignProp("", false, bttBtn_delete_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_delete_Enabled), 5, 0), true);
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! (0==AV11Insert_parqueAtraccionId) )
         {
            edtparqueAtraccionId_Enabled = 0;
            AssignProp("", false, edtparqueAtraccionId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtparqueAtraccionId_Enabled), 5, 0), true);
         }
         else
         {
            edtparqueAtraccionId_Enabled = 1;
            AssignProp("", false, edtparqueAtraccionId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtparqueAtraccionId_Enabled), 5, 0), true);
         }
      }

      protected void standaloneModal( )
      {
         if ( StringUtil.StrCmp(Gx_mode, "DSP") == 0 )
         {
            bttBtn_enter_Enabled = 0;
            AssignProp("", false, bttBtn_enter_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_enter_Enabled), 5, 0), true);
         }
         else
         {
            bttBtn_enter_Enabled = 1;
            AssignProp("", false, bttBtn_enter_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_enter_Enabled), 5, 0), true);
         }
         if ( ! (0==AV7EmpleadoId) )
         {
            A1EmpleadoId = AV7EmpleadoId;
            AssignAttri("", false, "A1EmpleadoId", StringUtil.LTrimStr( (decimal)(A1EmpleadoId), 4, 0));
         }
         else
         {
            if ( IsIns( )  && (0==A1EmpleadoId) && ( Gx_BScreen == 0 ) )
            {
               A1EmpleadoId = 1;
               AssignAttri("", false, "A1EmpleadoId", StringUtil.LTrimStr( (decimal)(A1EmpleadoId), 4, 0));
            }
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! (0==AV11Insert_parqueAtraccionId) )
         {
            A13parqueAtraccionId = AV11Insert_parqueAtraccionId;
            AssignAttri("", false, "A13parqueAtraccionId", StringUtil.LTrimStr( (decimal)(A13parqueAtraccionId), 4, 0));
         }
         else
         {
            if ( IsIns( )  && (0==A13parqueAtraccionId) && ( Gx_BScreen == 0 ) )
            {
               A13parqueAtraccionId = 1;
               AssignAttri("", false, "A13parqueAtraccionId", StringUtil.LTrimStr( (decimal)(A13parqueAtraccionId), 4, 0));
            }
         }
         if ( IsIns( )  && (DateTime.MinValue==A7EmpleadoFch_Alta) && ( Gx_BScreen == 0 ) )
         {
            A7EmpleadoFch_Alta = DateTimeUtil.ResetTime( DateTimeUtil.Today( context) ) ;
            n7EmpleadoFch_Alta = false;
            AssignAttri("", false, "A7EmpleadoFch_Alta", context.localUtil.TToC( A7EmpleadoFch_Alta, 8, 5, 0, 3, "/", ":", " "));
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ( Gx_BScreen == 0 ) )
         {
            AV13Pgmname = "Empleado";
            AssignAttri("", false, "AV13Pgmname", AV13Pgmname);
            /* Using cursor T00014 */
            pr_default.execute(2, new Object[] {A13parqueAtraccionId});
            A14parqueAtraccionNombre = T00014_A14parqueAtraccionNombre[0];
            AssignAttri("", false, "A14parqueAtraccionNombre", A14parqueAtraccionNombre);
            pr_default.close(2);
         }
      }

      protected void Load011( )
      {
         /* Using cursor T00015 */
         pr_default.execute(3, new Object[] {A1EmpleadoId});
         if ( (pr_default.getStatus(3) != 101) )
         {
            RcdFound1 = 1;
            A2EmpleadoNombre = T00015_A2EmpleadoNombre[0];
            AssignAttri("", false, "A2EmpleadoNombre", A2EmpleadoNombre);
            A3EmpleadoApellido = T00015_A3EmpleadoApellido[0];
            AssignAttri("", false, "A3EmpleadoApellido", A3EmpleadoApellido);
            A4EmpleadoDireccion = T00015_A4EmpleadoDireccion[0];
            n4EmpleadoDireccion = T00015_n4EmpleadoDireccion[0];
            AssignAttri("", false, "A4EmpleadoDireccion", A4EmpleadoDireccion);
            A5EmpleadoTelefono = T00015_A5EmpleadoTelefono[0];
            n5EmpleadoTelefono = T00015_n5EmpleadoTelefono[0];
            AssignAttri("", false, "A5EmpleadoTelefono", A5EmpleadoTelefono);
            A6EmpleadoEmail = T00015_A6EmpleadoEmail[0];
            n6EmpleadoEmail = T00015_n6EmpleadoEmail[0];
            AssignAttri("", false, "A6EmpleadoEmail", A6EmpleadoEmail);
            A7EmpleadoFch_Alta = T00015_A7EmpleadoFch_Alta[0];
            n7EmpleadoFch_Alta = T00015_n7EmpleadoFch_Alta[0];
            AssignAttri("", false, "A7EmpleadoFch_Alta", context.localUtil.TToC( A7EmpleadoFch_Alta, 8, 5, 0, 3, "/", ":", " "));
            A8EmpleadoFcha_Mod = T00015_A8EmpleadoFcha_Mod[0];
            n8EmpleadoFcha_Mod = T00015_n8EmpleadoFcha_Mod[0];
            AssignAttri("", false, "A8EmpleadoFcha_Mod", context.localUtil.TToC( A8EmpleadoFcha_Mod, 8, 5, 0, 3, "/", ":", " "));
            A9EmpleadoFch_Cad = T00015_A9EmpleadoFch_Cad[0];
            n9EmpleadoFch_Cad = T00015_n9EmpleadoFch_Cad[0];
            AssignAttri("", false, "A9EmpleadoFch_Cad", context.localUtil.TToC( A9EmpleadoFch_Cad, 8, 5, 0, 3, "/", ":", " "));
            A10EmpleadoUsu_Alta = T00015_A10EmpleadoUsu_Alta[0];
            n10EmpleadoUsu_Alta = T00015_n10EmpleadoUsu_Alta[0];
            AssignAttri("", false, "A10EmpleadoUsu_Alta", A10EmpleadoUsu_Alta);
            A11EmpleadoUsu_Mod = T00015_A11EmpleadoUsu_Mod[0];
            n11EmpleadoUsu_Mod = T00015_n11EmpleadoUsu_Mod[0];
            AssignAttri("", false, "A11EmpleadoUsu_Mod", A11EmpleadoUsu_Mod);
            A12EmpleadoUso_Cad = T00015_A12EmpleadoUso_Cad[0];
            n12EmpleadoUso_Cad = T00015_n12EmpleadoUso_Cad[0];
            AssignAttri("", false, "A12EmpleadoUso_Cad", A12EmpleadoUso_Cad);
            A14parqueAtraccionNombre = T00015_A14parqueAtraccionNombre[0];
            AssignAttri("", false, "A14parqueAtraccionNombre", A14parqueAtraccionNombre);
            A13parqueAtraccionId = T00015_A13parqueAtraccionId[0];
            AssignAttri("", false, "A13parqueAtraccionId", StringUtil.LTrimStr( (decimal)(A13parqueAtraccionId), 4, 0));
            ZM011( -13) ;
         }
         pr_default.close(3);
         OnLoadActions011( ) ;
      }

      protected void OnLoadActions011( )
      {
         AV13Pgmname = "Empleado";
         AssignAttri("", false, "AV13Pgmname", AV13Pgmname);
      }

      protected void CheckExtendedTable011( )
      {
         Gx_BScreen = 1;
         AssignAttri("", false, "Gx_BScreen", StringUtil.Str( (decimal)(Gx_BScreen), 1, 0));
         standaloneModal( ) ;
         AV13Pgmname = "Empleado";
         AssignAttri("", false, "AV13Pgmname", AV13Pgmname);
         if ( ! ( GxRegex.IsMatch(A6EmpleadoEmail,"^((\\w+([-+.']\\w+)*@\\w+([-.]\\w+)*\\.\\w+([-.]\\w+)*)|(\\s*))$") || String.IsNullOrEmpty(StringUtil.RTrim( A6EmpleadoEmail)) ) )
         {
            GX_msglist.addItem("El valor de Empleado Email no coincide con el patrón especificado", "OutOfRange", 1, "EMPLEADOEMAIL");
            AnyError = 1;
            GX_FocusControl = edtEmpleadoEmail_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( ! ( (DateTime.MinValue==A7EmpleadoFch_Alta) || ( A7EmpleadoFch_Alta >= context.localUtil.YMDHMSToT( 1753, 1, 1, 0, 0, 0) ) ) )
         {
            GX_msglist.addItem("Campo Empleado Fch_Alta fuera de rango", "OutOfRange", 1, "EMPLEADOFCH_ALTA");
            AnyError = 1;
            GX_FocusControl = edtEmpleadoFch_Alta_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( ! ( (DateTime.MinValue==A8EmpleadoFcha_Mod) || ( A8EmpleadoFcha_Mod >= context.localUtil.YMDHMSToT( 1753, 1, 1, 0, 0, 0) ) ) )
         {
            GX_msglist.addItem("Campo Empleado Fcha_Mod fuera de rango", "OutOfRange", 1, "EMPLEADOFCHA_MOD");
            AnyError = 1;
            GX_FocusControl = edtEmpleadoFcha_Mod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( ! ( (DateTime.MinValue==A9EmpleadoFch_Cad) || ( A9EmpleadoFch_Cad >= context.localUtil.YMDHMSToT( 1753, 1, 1, 0, 0, 0) ) ) )
         {
            GX_msglist.addItem("Campo Empleado Fch_Cad fuera de rango", "OutOfRange", 1, "EMPLEADOFCH_CAD");
            AnyError = 1;
            GX_FocusControl = edtEmpleadoFch_Cad_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         /* Using cursor T00014 */
         pr_default.execute(2, new Object[] {A13parqueAtraccionId});
         if ( (pr_default.getStatus(2) == 101) )
         {
            GX_msglist.addItem("No existe 'parque Atraccion'.", "ForeignKeyNotFound", 1, "PARQUEATRACCIONID");
            AnyError = 1;
            GX_FocusControl = edtparqueAtraccionId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A14parqueAtraccionNombre = T00014_A14parqueAtraccionNombre[0];
         AssignAttri("", false, "A14parqueAtraccionNombre", A14parqueAtraccionNombre);
         pr_default.close(2);
      }

      protected void CloseExtendedTableCursors011( )
      {
         pr_default.close(2);
      }

      protected void enableDisable( )
      {
      }

      protected void gxLoad_14( short A13parqueAtraccionId )
      {
         /* Using cursor T00016 */
         pr_default.execute(4, new Object[] {A13parqueAtraccionId});
         if ( (pr_default.getStatus(4) == 101) )
         {
            GX_msglist.addItem("No existe 'parque Atraccion'.", "ForeignKeyNotFound", 1, "PARQUEATRACCIONID");
            AnyError = 1;
            GX_FocusControl = edtparqueAtraccionId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A14parqueAtraccionNombre = T00016_A14parqueAtraccionNombre[0];
         AssignAttri("", false, "A14parqueAtraccionNombre", A14parqueAtraccionNombre);
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( A14parqueAtraccionNombre)+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(4) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(4);
      }

      protected void GetKey011( )
      {
         /* Using cursor T00017 */
         pr_default.execute(5, new Object[] {A1EmpleadoId});
         if ( (pr_default.getStatus(5) != 101) )
         {
            RcdFound1 = 1;
         }
         else
         {
            RcdFound1 = 0;
         }
         pr_default.close(5);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor T00013 */
         pr_default.execute(1, new Object[] {A1EmpleadoId});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM011( 13) ;
            RcdFound1 = 1;
            A1EmpleadoId = T00013_A1EmpleadoId[0];
            AssignAttri("", false, "A1EmpleadoId", StringUtil.LTrimStr( (decimal)(A1EmpleadoId), 4, 0));
            A2EmpleadoNombre = T00013_A2EmpleadoNombre[0];
            AssignAttri("", false, "A2EmpleadoNombre", A2EmpleadoNombre);
            A3EmpleadoApellido = T00013_A3EmpleadoApellido[0];
            AssignAttri("", false, "A3EmpleadoApellido", A3EmpleadoApellido);
            A4EmpleadoDireccion = T00013_A4EmpleadoDireccion[0];
            n4EmpleadoDireccion = T00013_n4EmpleadoDireccion[0];
            AssignAttri("", false, "A4EmpleadoDireccion", A4EmpleadoDireccion);
            A5EmpleadoTelefono = T00013_A5EmpleadoTelefono[0];
            n5EmpleadoTelefono = T00013_n5EmpleadoTelefono[0];
            AssignAttri("", false, "A5EmpleadoTelefono", A5EmpleadoTelefono);
            A6EmpleadoEmail = T00013_A6EmpleadoEmail[0];
            n6EmpleadoEmail = T00013_n6EmpleadoEmail[0];
            AssignAttri("", false, "A6EmpleadoEmail", A6EmpleadoEmail);
            A7EmpleadoFch_Alta = T00013_A7EmpleadoFch_Alta[0];
            n7EmpleadoFch_Alta = T00013_n7EmpleadoFch_Alta[0];
            AssignAttri("", false, "A7EmpleadoFch_Alta", context.localUtil.TToC( A7EmpleadoFch_Alta, 8, 5, 0, 3, "/", ":", " "));
            A8EmpleadoFcha_Mod = T00013_A8EmpleadoFcha_Mod[0];
            n8EmpleadoFcha_Mod = T00013_n8EmpleadoFcha_Mod[0];
            AssignAttri("", false, "A8EmpleadoFcha_Mod", context.localUtil.TToC( A8EmpleadoFcha_Mod, 8, 5, 0, 3, "/", ":", " "));
            A9EmpleadoFch_Cad = T00013_A9EmpleadoFch_Cad[0];
            n9EmpleadoFch_Cad = T00013_n9EmpleadoFch_Cad[0];
            AssignAttri("", false, "A9EmpleadoFch_Cad", context.localUtil.TToC( A9EmpleadoFch_Cad, 8, 5, 0, 3, "/", ":", " "));
            A10EmpleadoUsu_Alta = T00013_A10EmpleadoUsu_Alta[0];
            n10EmpleadoUsu_Alta = T00013_n10EmpleadoUsu_Alta[0];
            AssignAttri("", false, "A10EmpleadoUsu_Alta", A10EmpleadoUsu_Alta);
            A11EmpleadoUsu_Mod = T00013_A11EmpleadoUsu_Mod[0];
            n11EmpleadoUsu_Mod = T00013_n11EmpleadoUsu_Mod[0];
            AssignAttri("", false, "A11EmpleadoUsu_Mod", A11EmpleadoUsu_Mod);
            A12EmpleadoUso_Cad = T00013_A12EmpleadoUso_Cad[0];
            n12EmpleadoUso_Cad = T00013_n12EmpleadoUso_Cad[0];
            AssignAttri("", false, "A12EmpleadoUso_Cad", A12EmpleadoUso_Cad);
            A13parqueAtraccionId = T00013_A13parqueAtraccionId[0];
            AssignAttri("", false, "A13parqueAtraccionId", StringUtil.LTrimStr( (decimal)(A13parqueAtraccionId), 4, 0));
            Z1EmpleadoId = A1EmpleadoId;
            sMode1 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            Load011( ) ;
            if ( AnyError == 1 )
            {
               RcdFound1 = 0;
               InitializeNonKey011( ) ;
            }
            Gx_mode = sMode1;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound1 = 0;
            InitializeNonKey011( ) ;
            sMode1 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Gx_mode = sMode1;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey011( ) ;
         if ( RcdFound1 == 0 )
         {
         }
         else
         {
         }
         getByPrimaryKey( ) ;
      }

      protected void move_next( )
      {
         RcdFound1 = 0;
         /* Using cursor T00018 */
         pr_default.execute(6, new Object[] {A1EmpleadoId});
         if ( (pr_default.getStatus(6) != 101) )
         {
            while ( (pr_default.getStatus(6) != 101) && ( ( T00018_A1EmpleadoId[0] < A1EmpleadoId ) ) )
            {
               pr_default.readNext(6);
            }
            if ( (pr_default.getStatus(6) != 101) && ( ( T00018_A1EmpleadoId[0] > A1EmpleadoId ) ) )
            {
               A1EmpleadoId = T00018_A1EmpleadoId[0];
               AssignAttri("", false, "A1EmpleadoId", StringUtil.LTrimStr( (decimal)(A1EmpleadoId), 4, 0));
               RcdFound1 = 1;
            }
         }
         pr_default.close(6);
      }

      protected void move_previous( )
      {
         RcdFound1 = 0;
         /* Using cursor T00019 */
         pr_default.execute(7, new Object[] {A1EmpleadoId});
         if ( (pr_default.getStatus(7) != 101) )
         {
            while ( (pr_default.getStatus(7) != 101) && ( ( T00019_A1EmpleadoId[0] > A1EmpleadoId ) ) )
            {
               pr_default.readNext(7);
            }
            if ( (pr_default.getStatus(7) != 101) && ( ( T00019_A1EmpleadoId[0] < A1EmpleadoId ) ) )
            {
               A1EmpleadoId = T00019_A1EmpleadoId[0];
               AssignAttri("", false, "A1EmpleadoId", StringUtil.LTrimStr( (decimal)(A1EmpleadoId), 4, 0));
               RcdFound1 = 1;
            }
         }
         pr_default.close(7);
      }

      protected void btn_enter( )
      {
         nKeyPressed = 1;
         GetKey011( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            GX_FocusControl = edtEmpleadoNombre_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            Insert011( ) ;
            if ( AnyError == 1 )
            {
               GX_FocusControl = "";
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         else
         {
            if ( RcdFound1 == 1 )
            {
               if ( A1EmpleadoId != Z1EmpleadoId )
               {
                  A1EmpleadoId = Z1EmpleadoId;
                  AssignAttri("", false, "A1EmpleadoId", StringUtil.LTrimStr( (decimal)(A1EmpleadoId), 4, 0));
                  GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "CandidateKeyNotFound", 1, "EMPLEADOID");
                  AnyError = 1;
                  GX_FocusControl = edtEmpleadoId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else if ( IsDlt( ) )
               {
                  delete( ) ;
                  AfterTrn( ) ;
                  GX_FocusControl = edtEmpleadoNombre_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else
               {
                  /* Update record */
                  Update011( ) ;
                  GX_FocusControl = edtEmpleadoNombre_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
            }
            else
            {
               if ( A1EmpleadoId != Z1EmpleadoId )
               {
                  /* Insert record */
                  GX_FocusControl = edtEmpleadoNombre_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  Insert011( ) ;
                  if ( AnyError == 1 )
                  {
                     GX_FocusControl = "";
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
               }
               else
               {
                  if ( StringUtil.StrCmp(Gx_mode, "UPD") == 0 )
                  {
                     GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "EMPLEADOID");
                     AnyError = 1;
                     GX_FocusControl = edtEmpleadoId_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
                  else
                  {
                     /* Insert record */
                     GX_FocusControl = edtEmpleadoNombre_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     Insert011( ) ;
                     if ( AnyError == 1 )
                     {
                        GX_FocusControl = "";
                        AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     }
                  }
               }
            }
         }
         AfterTrn( ) ;
         if ( IsIns( ) || IsUpd( ) || IsDlt( ) )
         {
            if ( AnyError == 0 )
            {
               context.nUserReturn = 1;
            }
         }
      }

      protected void btn_delete( )
      {
         if ( A1EmpleadoId != Z1EmpleadoId )
         {
            A1EmpleadoId = Z1EmpleadoId;
            AssignAttri("", false, "A1EmpleadoId", StringUtil.LTrimStr( (decimal)(A1EmpleadoId), 4, 0));
            GX_msglist.addItem(context.GetMessage( "GXM_getbeforedlt", ""), 1, "EMPLEADOID");
            AnyError = 1;
            GX_FocusControl = edtEmpleadoId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         else
         {
            delete( ) ;
            AfterTrn( ) ;
            GX_FocusControl = edtEmpleadoNombre_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( AnyError != 0 )
         {
         }
      }

      protected void CheckOptimisticConcurrency011( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T00012 */
            pr_default.execute(0, new Object[] {A1EmpleadoId});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Empleado"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            Gx_longc = false;
            if ( (pr_default.getStatus(0) == 101) || ( StringUtil.StrCmp(Z2EmpleadoNombre, T00012_A2EmpleadoNombre[0]) != 0 ) || ( StringUtil.StrCmp(Z3EmpleadoApellido, T00012_A3EmpleadoApellido[0]) != 0 ) || ( StringUtil.StrCmp(Z4EmpleadoDireccion, T00012_A4EmpleadoDireccion[0]) != 0 ) || ( StringUtil.StrCmp(Z5EmpleadoTelefono, T00012_A5EmpleadoTelefono[0]) != 0 ) || ( StringUtil.StrCmp(Z6EmpleadoEmail, T00012_A6EmpleadoEmail[0]) != 0 ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( Z7EmpleadoFch_Alta != T00012_A7EmpleadoFch_Alta[0] ) || ( Z8EmpleadoFcha_Mod != T00012_A8EmpleadoFcha_Mod[0] ) || ( Z9EmpleadoFch_Cad != T00012_A9EmpleadoFch_Cad[0] ) || ( StringUtil.StrCmp(Z10EmpleadoUsu_Alta, T00012_A10EmpleadoUsu_Alta[0]) != 0 ) || ( StringUtil.StrCmp(Z11EmpleadoUsu_Mod, T00012_A11EmpleadoUsu_Mod[0]) != 0 ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( StringUtil.StrCmp(Z12EmpleadoUso_Cad, T00012_A12EmpleadoUso_Cad[0]) != 0 ) || ( Z13parqueAtraccionId != T00012_A13parqueAtraccionId[0] ) )
            {
               if ( StringUtil.StrCmp(Z2EmpleadoNombre, T00012_A2EmpleadoNombre[0]) != 0 )
               {
                  GXUtil.WriteLog("empleado:[seudo value changed for attri]"+"EmpleadoNombre");
                  GXUtil.WriteLogRaw("Old: ",Z2EmpleadoNombre);
                  GXUtil.WriteLogRaw("Current: ",T00012_A2EmpleadoNombre[0]);
               }
               if ( StringUtil.StrCmp(Z3EmpleadoApellido, T00012_A3EmpleadoApellido[0]) != 0 )
               {
                  GXUtil.WriteLog("empleado:[seudo value changed for attri]"+"EmpleadoApellido");
                  GXUtil.WriteLogRaw("Old: ",Z3EmpleadoApellido);
                  GXUtil.WriteLogRaw("Current: ",T00012_A3EmpleadoApellido[0]);
               }
               if ( StringUtil.StrCmp(Z4EmpleadoDireccion, T00012_A4EmpleadoDireccion[0]) != 0 )
               {
                  GXUtil.WriteLog("empleado:[seudo value changed for attri]"+"EmpleadoDireccion");
                  GXUtil.WriteLogRaw("Old: ",Z4EmpleadoDireccion);
                  GXUtil.WriteLogRaw("Current: ",T00012_A4EmpleadoDireccion[0]);
               }
               if ( StringUtil.StrCmp(Z5EmpleadoTelefono, T00012_A5EmpleadoTelefono[0]) != 0 )
               {
                  GXUtil.WriteLog("empleado:[seudo value changed for attri]"+"EmpleadoTelefono");
                  GXUtil.WriteLogRaw("Old: ",Z5EmpleadoTelefono);
                  GXUtil.WriteLogRaw("Current: ",T00012_A5EmpleadoTelefono[0]);
               }
               if ( StringUtil.StrCmp(Z6EmpleadoEmail, T00012_A6EmpleadoEmail[0]) != 0 )
               {
                  GXUtil.WriteLog("empleado:[seudo value changed for attri]"+"EmpleadoEmail");
                  GXUtil.WriteLogRaw("Old: ",Z6EmpleadoEmail);
                  GXUtil.WriteLogRaw("Current: ",T00012_A6EmpleadoEmail[0]);
               }
               if ( Z7EmpleadoFch_Alta != T00012_A7EmpleadoFch_Alta[0] )
               {
                  GXUtil.WriteLog("empleado:[seudo value changed for attri]"+"EmpleadoFch_Alta");
                  GXUtil.WriteLogRaw("Old: ",Z7EmpleadoFch_Alta);
                  GXUtil.WriteLogRaw("Current: ",T00012_A7EmpleadoFch_Alta[0]);
               }
               if ( Z8EmpleadoFcha_Mod != T00012_A8EmpleadoFcha_Mod[0] )
               {
                  GXUtil.WriteLog("empleado:[seudo value changed for attri]"+"EmpleadoFcha_Mod");
                  GXUtil.WriteLogRaw("Old: ",Z8EmpleadoFcha_Mod);
                  GXUtil.WriteLogRaw("Current: ",T00012_A8EmpleadoFcha_Mod[0]);
               }
               if ( Z9EmpleadoFch_Cad != T00012_A9EmpleadoFch_Cad[0] )
               {
                  GXUtil.WriteLog("empleado:[seudo value changed for attri]"+"EmpleadoFch_Cad");
                  GXUtil.WriteLogRaw("Old: ",Z9EmpleadoFch_Cad);
                  GXUtil.WriteLogRaw("Current: ",T00012_A9EmpleadoFch_Cad[0]);
               }
               if ( StringUtil.StrCmp(Z10EmpleadoUsu_Alta, T00012_A10EmpleadoUsu_Alta[0]) != 0 )
               {
                  GXUtil.WriteLog("empleado:[seudo value changed for attri]"+"EmpleadoUsu_Alta");
                  GXUtil.WriteLogRaw("Old: ",Z10EmpleadoUsu_Alta);
                  GXUtil.WriteLogRaw("Current: ",T00012_A10EmpleadoUsu_Alta[0]);
               }
               if ( StringUtil.StrCmp(Z11EmpleadoUsu_Mod, T00012_A11EmpleadoUsu_Mod[0]) != 0 )
               {
                  GXUtil.WriteLog("empleado:[seudo value changed for attri]"+"EmpleadoUsu_Mod");
                  GXUtil.WriteLogRaw("Old: ",Z11EmpleadoUsu_Mod);
                  GXUtil.WriteLogRaw("Current: ",T00012_A11EmpleadoUsu_Mod[0]);
               }
               if ( StringUtil.StrCmp(Z12EmpleadoUso_Cad, T00012_A12EmpleadoUso_Cad[0]) != 0 )
               {
                  GXUtil.WriteLog("empleado:[seudo value changed for attri]"+"EmpleadoUso_Cad");
                  GXUtil.WriteLogRaw("Old: ",Z12EmpleadoUso_Cad);
                  GXUtil.WriteLogRaw("Current: ",T00012_A12EmpleadoUso_Cad[0]);
               }
               if ( Z13parqueAtraccionId != T00012_A13parqueAtraccionId[0] )
               {
                  GXUtil.WriteLog("empleado:[seudo value changed for attri]"+"parqueAtraccionId");
                  GXUtil.WriteLogRaw("Old: ",Z13parqueAtraccionId);
                  GXUtil.WriteLogRaw("Current: ",T00012_A13parqueAtraccionId[0]);
               }
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
                     /* Using cursor T000110 */
                     pr_default.execute(8, new Object[] {A2EmpleadoNombre, A3EmpleadoApellido, n4EmpleadoDireccion, A4EmpleadoDireccion, n5EmpleadoTelefono, A5EmpleadoTelefono, n6EmpleadoEmail, A6EmpleadoEmail, n7EmpleadoFch_Alta, A7EmpleadoFch_Alta, n8EmpleadoFcha_Mod, A8EmpleadoFcha_Mod, n9EmpleadoFch_Cad, A9EmpleadoFch_Cad, n10EmpleadoUsu_Alta, A10EmpleadoUsu_Alta, n11EmpleadoUsu_Mod, A11EmpleadoUsu_Mod, n12EmpleadoUso_Cad, A12EmpleadoUso_Cad, A13parqueAtraccionId});
                     A1EmpleadoId = T000110_A1EmpleadoId[0];
                     AssignAttri("", false, "A1EmpleadoId", StringUtil.LTrimStr( (decimal)(A1EmpleadoId), 4, 0));
                     pr_default.close(8);
                     pr_default.SmartCacheProvider.SetUpdated("Empleado");
                     if ( AnyError == 0 )
                     {
                        /* Start of After( Insert) rules */
                        /* End of After( Insert) rules */
                        if ( AnyError == 0 )
                        {
                           if ( IsIns( ) || IsUpd( ) || IsDlt( ) )
                           {
                              if ( AnyError == 0 )
                              {
                                 context.nUserReturn = 1;
                              }
                           }
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
                     /* Using cursor T000111 */
                     pr_default.execute(9, new Object[] {A2EmpleadoNombre, A3EmpleadoApellido, n4EmpleadoDireccion, A4EmpleadoDireccion, n5EmpleadoTelefono, A5EmpleadoTelefono, n6EmpleadoEmail, A6EmpleadoEmail, n7EmpleadoFch_Alta, A7EmpleadoFch_Alta, n8EmpleadoFcha_Mod, A8EmpleadoFcha_Mod, n9EmpleadoFch_Cad, A9EmpleadoFch_Cad, n10EmpleadoUsu_Alta, A10EmpleadoUsu_Alta, n11EmpleadoUsu_Mod, A11EmpleadoUsu_Mod, n12EmpleadoUso_Cad, A12EmpleadoUso_Cad, A13parqueAtraccionId, A1EmpleadoId});
                     pr_default.close(9);
                     pr_default.SmartCacheProvider.SetUpdated("Empleado");
                     if ( (pr_default.getStatus(9) == 103) )
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
                           if ( IsIns( ) || IsUpd( ) || IsDlt( ) )
                           {
                              if ( AnyError == 0 )
                              {
                                 context.nUserReturn = 1;
                              }
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
                  /* Using cursor T000112 */
                  pr_default.execute(10, new Object[] {A1EmpleadoId});
                  pr_default.close(10);
                  pr_default.SmartCacheProvider.SetUpdated("Empleado");
                  if ( AnyError == 0 )
                  {
                     /* Start of After( delete) rules */
                     /* End of After( delete) rules */
                     if ( AnyError == 0 )
                     {
                        if ( IsIns( ) || IsUpd( ) || IsDlt( ) )
                        {
                           if ( AnyError == 0 )
                           {
                              context.nUserReturn = 1;
                           }
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
         }
         sMode1 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel011( ) ;
         Gx_mode = sMode1;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls011( )
      {
         standaloneModal( ) ;
         if ( AnyError == 0 )
         {
            /* Delete mode formulas */
            AV13Pgmname = "Empleado";
            AssignAttri("", false, "AV13Pgmname", AV13Pgmname);
            /* Using cursor T000113 */
            pr_default.execute(11, new Object[] {A13parqueAtraccionId});
            A14parqueAtraccionNombre = T000113_A14parqueAtraccionNombre[0];
            AssignAttri("", false, "A14parqueAtraccionNombre", A14parqueAtraccionNombre);
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
            pr_default.close(1);
            pr_default.close(11);
            context.CommitDataStores("empleado",pr_default);
            if ( AnyError == 0 )
            {
               ConfirmValues010( ) ;
            }
            /* After transaction rules */
            /* Execute 'After Trn' event if defined. */
            trnEnded = 1;
         }
         else
         {
            pr_default.close(1);
            pr_default.close(11);
            context.RollbackDataStores("empleado",pr_default);
         }
         IsModified = 0;
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanStart011( )
      {
         /* Scan By routine */
         /* Using cursor T000114 */
         pr_default.execute(12);
         RcdFound1 = 0;
         if ( (pr_default.getStatus(12) != 101) )
         {
            RcdFound1 = 1;
            A1EmpleadoId = T000114_A1EmpleadoId[0];
            AssignAttri("", false, "A1EmpleadoId", StringUtil.LTrimStr( (decimal)(A1EmpleadoId), 4, 0));
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext011( )
      {
         /* Scan next routine */
         pr_default.readNext(12);
         RcdFound1 = 0;
         if ( (pr_default.getStatus(12) != 101) )
         {
            RcdFound1 = 1;
            A1EmpleadoId = T000114_A1EmpleadoId[0];
            AssignAttri("", false, "A1EmpleadoId", StringUtil.LTrimStr( (decimal)(A1EmpleadoId), 4, 0));
         }
      }

      protected void ScanEnd011( )
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
         edtEmpleadoId_Enabled = 0;
         AssignProp("", false, edtEmpleadoId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtEmpleadoId_Enabled), 5, 0), true);
         edtEmpleadoNombre_Enabled = 0;
         AssignProp("", false, edtEmpleadoNombre_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtEmpleadoNombre_Enabled), 5, 0), true);
         edtEmpleadoApellido_Enabled = 0;
         AssignProp("", false, edtEmpleadoApellido_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtEmpleadoApellido_Enabled), 5, 0), true);
         edtEmpleadoDireccion_Enabled = 0;
         AssignProp("", false, edtEmpleadoDireccion_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtEmpleadoDireccion_Enabled), 5, 0), true);
         edtEmpleadoTelefono_Enabled = 0;
         AssignProp("", false, edtEmpleadoTelefono_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtEmpleadoTelefono_Enabled), 5, 0), true);
         edtEmpleadoEmail_Enabled = 0;
         AssignProp("", false, edtEmpleadoEmail_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtEmpleadoEmail_Enabled), 5, 0), true);
         edtEmpleadoFch_Alta_Enabled = 0;
         AssignProp("", false, edtEmpleadoFch_Alta_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtEmpleadoFch_Alta_Enabled), 5, 0), true);
         edtEmpleadoFcha_Mod_Enabled = 0;
         AssignProp("", false, edtEmpleadoFcha_Mod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtEmpleadoFcha_Mod_Enabled), 5, 0), true);
         edtEmpleadoFch_Cad_Enabled = 0;
         AssignProp("", false, edtEmpleadoFch_Cad_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtEmpleadoFch_Cad_Enabled), 5, 0), true);
         edtEmpleadoUsu_Alta_Enabled = 0;
         AssignProp("", false, edtEmpleadoUsu_Alta_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtEmpleadoUsu_Alta_Enabled), 5, 0), true);
         edtEmpleadoUsu_Mod_Enabled = 0;
         AssignProp("", false, edtEmpleadoUsu_Mod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtEmpleadoUsu_Mod_Enabled), 5, 0), true);
         edtEmpleadoUso_Cad_Enabled = 0;
         AssignProp("", false, edtEmpleadoUso_Cad_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtEmpleadoUso_Cad_Enabled), 5, 0), true);
         edtparqueAtraccionId_Enabled = 0;
         AssignProp("", false, edtparqueAtraccionId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtparqueAtraccionId_Enabled), 5, 0), true);
         edtparqueAtraccionNombre_Enabled = 0;
         AssignProp("", false, edtparqueAtraccionNombre_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtparqueAtraccionNombre_Enabled), 5, 0), true);
      }

      protected void send_integrity_lvl_hashes011( )
      {
      }

      protected void assign_properties_default( )
      {
      }

      protected void ConfirmValues010( )
      {
      }

      public override void RenderHtmlHeaders( )
      {
         GxWebStd.gx_html_headers( context, 0, "", "", Form.Meta, Form.Metaequiv, true);
      }

      public override void RenderHtmlOpenForm( )
      {
         if ( context.isSpaRequest( ) )
         {
            enableOutput();
         }
         context.WriteHtmlText( "<title>") ;
         context.SendWebValue( Form.Caption) ;
         context.WriteHtmlTextNl( "</title>") ;
         if ( context.isSpaRequest( ) )
         {
            disableOutput();
         }
         if ( StringUtil.Len( sDynURL) > 0 )
         {
            context.WriteHtmlText( "<BASE href=\""+sDynURL+"\" />") ;
         }
         define_styles( ) ;
         MasterPageObj.master_styles();
         CloseStyles();
         if ( ( ( context.GetBrowserType( ) == 1 ) || ( context.GetBrowserType( ) == 5 ) ) && ( StringUtil.StrCmp(context.GetBrowserVersion( ), "7.0") == 0 ) )
         {
            context.AddJavascriptSource("json2.js", "?"+context.GetBuildNumber( 239440), false, true);
         }
         context.AddJavascriptSource("jquery.js", "?"+context.GetBuildNumber( 239440), false, true);
         context.AddJavascriptSource("gxgral.js", "?"+context.GetBuildNumber( 239440), false, true);
         context.AddJavascriptSource("gxcfg.js", "?"+GetCacheInvalidationToken( ), false, true);
         if ( context.isSpaRequest( ) )
         {
            enableOutput();
         }
         context.AddJavascriptSource("calendar.js", "?"+context.GetBuildNumber( 239440), false, true);
         context.AddJavascriptSource("calendar-setup.js", "?"+context.GetBuildNumber( 239440), false, true);
         context.AddJavascriptSource("calendar-es.js", "?"+context.GetBuildNumber( 239440), false, true);
         context.WriteHtmlText( Form.Headerrawhtml) ;
         context.CloseHtmlHeader();
         if ( context.isSpaRequest( ) )
         {
            disableOutput();
         }
         FormProcess = " data-HasEnter=\"true\" data-Skiponenter=\"false\"";
         context.WriteHtmlText( "<body ") ;
         if ( StringUtil.StrCmp(context.GetLanguageProperty( "rtl"), "true") == 0 )
         {
            context.WriteHtmlText( " dir=\"rtl\" ") ;
         }
         bodyStyle = "" + "background-color:" + context.BuildHTMLColor( Form.Backcolor) + ";color:" + context.BuildHTMLColor( Form.Textcolor) + ";";
         bodyStyle += "-moz-opacity:0;opacity:0;";
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( Form.Background)) ) )
         {
            bodyStyle += " background-image:url(" + context.convertURL( Form.Background) + ")";
         }
         context.WriteHtmlText( " "+"class=\"form-horizontal Form\""+" "+ "style='"+bodyStyle+"'") ;
         context.WriteHtmlText( FormProcess+">") ;
         context.skipLines(1);
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("empleado.aspx", new object[] {UrlEncode(StringUtil.RTrim(Gx_mode)),UrlEncode(StringUtil.LTrimStr(AV7EmpleadoId,4,0))}, new string[] {"Gx_mode","EmpleadoId"}) +"\">") ;
         GxWebStd.gx_hidden_field( context, "_EventName", "");
         GxWebStd.gx_hidden_field( context, "_EventGridId", "");
         GxWebStd.gx_hidden_field( context, "_EventRowId", "");
         context.WriteHtmlText( "<div style=\"height:0;overflow:hidden\"><input type=\"submit\" title=\"submit\"  disabled></div>") ;
         AssignProp("", false, "FORM", "Class", "form-horizontal Form", true);
         toggleJsOutput = isJsOutputEnabled( );
         if ( context.isSpaRequest( ) )
         {
            disableJsOutput();
         }
      }

      protected void send_integrity_footer_hashes( )
      {
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         forbiddenHiddens = new GXProperties();
         forbiddenHiddens.Add("hshsalt", "hsh"+"Empleado");
         forbiddenHiddens.Add("EmpleadoId", context.localUtil.Format( (decimal)(A1EmpleadoId), "ZZZ9"));
         forbiddenHiddens.Add("Gx_mode", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")));
         GxWebStd.gx_hidden_field( context, "hsh", GetEncryptedHash( forbiddenHiddens.ToString(), GXKey));
         GXUtil.WriteLogInfo("empleado:[ SendSecurityCheck value for]"+forbiddenHiddens.ToJSonString());
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "Z1EmpleadoId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z1EmpleadoId), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "Z2EmpleadoNombre", Z2EmpleadoNombre);
         GxWebStd.gx_hidden_field( context, "Z3EmpleadoApellido", Z3EmpleadoApellido);
         GxWebStd.gx_hidden_field( context, "Z4EmpleadoDireccion", Z4EmpleadoDireccion);
         GxWebStd.gx_hidden_field( context, "Z5EmpleadoTelefono", StringUtil.RTrim( Z5EmpleadoTelefono));
         GxWebStd.gx_hidden_field( context, "Z6EmpleadoEmail", Z6EmpleadoEmail);
         GxWebStd.gx_hidden_field( context, "Z7EmpleadoFch_Alta", context.localUtil.TToC( Z7EmpleadoFch_Alta, 10, 8, 0, 0, "/", ":", " "));
         GxWebStd.gx_hidden_field( context, "Z8EmpleadoFcha_Mod", context.localUtil.TToC( Z8EmpleadoFcha_Mod, 10, 8, 0, 0, "/", ":", " "));
         GxWebStd.gx_hidden_field( context, "Z9EmpleadoFch_Cad", context.localUtil.TToC( Z9EmpleadoFch_Cad, 10, 8, 0, 0, "/", ":", " "));
         GxWebStd.gx_hidden_field( context, "Z10EmpleadoUsu_Alta", Z10EmpleadoUsu_Alta);
         GxWebStd.gx_hidden_field( context, "Z11EmpleadoUsu_Mod", Z11EmpleadoUsu_Mod);
         GxWebStd.gx_hidden_field( context, "Z12EmpleadoUso_Cad", Z12EmpleadoUso_Cad);
         GxWebStd.gx_hidden_field( context, "Z13parqueAtraccionId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z13parqueAtraccionId), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "IsConfirmed", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsConfirmed), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "IsModified", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsModified), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "Mode", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "gxhash_Mode", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")), context));
         GxWebStd.gx_hidden_field( context, "N13parqueAtraccionId", StringUtil.LTrim( StringUtil.NToC( (decimal)(A13parqueAtraccionId), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "vMODE", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "gxhash_vMODE", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")), context));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vTRNCONTEXT", AV9TrnContext);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vTRNCONTEXT", AV9TrnContext);
         }
         GxWebStd.gx_hidden_field( context, "gxhash_vTRNCONTEXT", GetSecureSignedToken( "", AV9TrnContext, context));
         GxWebStd.gx_hidden_field( context, "vEMPLEADOID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV7EmpleadoId), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vEMPLEADOID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV7EmpleadoId), "ZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "vGXBSCREEN", StringUtil.LTrim( StringUtil.NToC( (decimal)(Gx_BScreen), 1, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "vINSERT_PARQUEATRACCIONID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV11Insert_parqueAtraccionId), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "vPGMNAME", StringUtil.RTrim( AV13Pgmname));
      }

      public override void RenderHtmlCloseForm( )
      {
         SendCloseFormHiddens( ) ;
         GxWebStd.gx_hidden_field( context, "GX_FocusControl", GX_FocusControl);
         SendAjaxEncryptionKey();
         SendSecurityToken(sPrefix);
         SendComponentObjects();
         SendServerCommands();
         SendState();
         if ( context.isSpaRequest( ) )
         {
            disableOutput();
         }
         context.WriteHtmlTextNl( "</form>") ;
         if ( context.isSpaRequest( ) )
         {
            enableOutput();
         }
         include_jscripts( ) ;
      }

      public override short ExecuteStartEvent( )
      {
         standaloneStartup( ) ;
         gxajaxcallmode = (short)((isAjaxCallMode( ) ? 1 : 0));
         return gxajaxcallmode ;
      }

      public override void RenderHtmlContent( )
      {
         context.WriteHtmlText( "<div") ;
         GxWebStd.ClassAttribute( context, "gx-ct-body"+" "+(String.IsNullOrEmpty(StringUtil.RTrim( Form.Class)) ? "form-horizontal Form" : Form.Class)+"-fx");
         context.WriteHtmlText( ">") ;
         Draw( ) ;
         context.WriteHtmlText( "</div>") ;
      }

      public override void DispatchEvents( )
      {
         Process( ) ;
      }

      public override bool HasEnterEvent( )
      {
         return true ;
      }

      public override GXWebForm GetForm( )
      {
         return Form ;
      }

      public override string GetSelfLink( )
      {
         return formatLink("empleado.aspx", new object[] {UrlEncode(StringUtil.RTrim(Gx_mode)),UrlEncode(StringUtil.LTrimStr(AV7EmpleadoId,4,0))}, new string[] {"Gx_mode","EmpleadoId"})  ;
      }

      public override string GetPgmname( )
      {
         return "Empleado" ;
      }

      public override string GetPgmdesc( )
      {
         return "Empleado" ;
      }

      protected void InitializeNonKey011( )
      {
         A2EmpleadoNombre = "";
         AssignAttri("", false, "A2EmpleadoNombre", A2EmpleadoNombre);
         A3EmpleadoApellido = "";
         AssignAttri("", false, "A3EmpleadoApellido", A3EmpleadoApellido);
         A4EmpleadoDireccion = "";
         n4EmpleadoDireccion = false;
         AssignAttri("", false, "A4EmpleadoDireccion", A4EmpleadoDireccion);
         n4EmpleadoDireccion = (String.IsNullOrEmpty(StringUtil.RTrim( A4EmpleadoDireccion)) ? true : false);
         A5EmpleadoTelefono = "";
         n5EmpleadoTelefono = false;
         AssignAttri("", false, "A5EmpleadoTelefono", A5EmpleadoTelefono);
         n5EmpleadoTelefono = (String.IsNullOrEmpty(StringUtil.RTrim( A5EmpleadoTelefono)) ? true : false);
         A6EmpleadoEmail = "";
         n6EmpleadoEmail = false;
         AssignAttri("", false, "A6EmpleadoEmail", A6EmpleadoEmail);
         n6EmpleadoEmail = (String.IsNullOrEmpty(StringUtil.RTrim( A6EmpleadoEmail)) ? true : false);
         A8EmpleadoFcha_Mod = (DateTime)(DateTime.MinValue);
         n8EmpleadoFcha_Mod = false;
         AssignAttri("", false, "A8EmpleadoFcha_Mod", context.localUtil.TToC( A8EmpleadoFcha_Mod, 8, 5, 0, 3, "/", ":", " "));
         n8EmpleadoFcha_Mod = ((DateTime.MinValue==A8EmpleadoFcha_Mod) ? true : false);
         A9EmpleadoFch_Cad = (DateTime)(DateTime.MinValue);
         n9EmpleadoFch_Cad = false;
         AssignAttri("", false, "A9EmpleadoFch_Cad", context.localUtil.TToC( A9EmpleadoFch_Cad, 8, 5, 0, 3, "/", ":", " "));
         n9EmpleadoFch_Cad = ((DateTime.MinValue==A9EmpleadoFch_Cad) ? true : false);
         A10EmpleadoUsu_Alta = "";
         n10EmpleadoUsu_Alta = false;
         AssignAttri("", false, "A10EmpleadoUsu_Alta", A10EmpleadoUsu_Alta);
         n10EmpleadoUsu_Alta = (String.IsNullOrEmpty(StringUtil.RTrim( A10EmpleadoUsu_Alta)) ? true : false);
         A11EmpleadoUsu_Mod = "";
         n11EmpleadoUsu_Mod = false;
         AssignAttri("", false, "A11EmpleadoUsu_Mod", A11EmpleadoUsu_Mod);
         n11EmpleadoUsu_Mod = (String.IsNullOrEmpty(StringUtil.RTrim( A11EmpleadoUsu_Mod)) ? true : false);
         A12EmpleadoUso_Cad = "";
         n12EmpleadoUso_Cad = false;
         AssignAttri("", false, "A12EmpleadoUso_Cad", A12EmpleadoUso_Cad);
         n12EmpleadoUso_Cad = (String.IsNullOrEmpty(StringUtil.RTrim( A12EmpleadoUso_Cad)) ? true : false);
         A14parqueAtraccionNombre = "";
         AssignAttri("", false, "A14parqueAtraccionNombre", A14parqueAtraccionNombre);
         A13parqueAtraccionId = 1;
         AssignAttri("", false, "A13parqueAtraccionId", StringUtil.LTrimStr( (decimal)(A13parqueAtraccionId), 4, 0));
         A7EmpleadoFch_Alta = DateTimeUtil.ResetTime( DateTimeUtil.Today( context) ) ;
         n7EmpleadoFch_Alta = false;
         AssignAttri("", false, "A7EmpleadoFch_Alta", context.localUtil.TToC( A7EmpleadoFch_Alta, 8, 5, 0, 3, "/", ":", " "));
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
         AssignAttri("", false, "A1EmpleadoId", StringUtil.LTrimStr( (decimal)(A1EmpleadoId), 4, 0));
         InitializeNonKey011( ) ;
      }

      protected void StandaloneModalInsert( )
      {
         A13parqueAtraccionId = i13parqueAtraccionId;
         AssignAttri("", false, "A13parqueAtraccionId", StringUtil.LTrimStr( (decimal)(A13parqueAtraccionId), 4, 0));
         A7EmpleadoFch_Alta = i7EmpleadoFch_Alta;
         n7EmpleadoFch_Alta = false;
         AssignAttri("", false, "A7EmpleadoFch_Alta", context.localUtil.TToC( A7EmpleadoFch_Alta, 8, 5, 0, 3, "/", ":", " "));
      }

      protected void define_styles( )
      {
         AddStyleSheetFile("calendar-system.css", "");
         AddThemeStyleSheetFile("", context.GetTheme( )+".css", "?"+GetCacheInvalidationToken( ));
         bool outputEnabled = isOutputEnabled( );
         if ( context.isSpaRequest( ) )
         {
            enableOutput();
         }
         idxLst = 1;
         while ( idxLst <= Form.Jscriptsrc.Count )
         {
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?202541223451655", true, true);
            idxLst = (int)(idxLst+1);
         }
         if ( ! outputEnabled )
         {
            if ( context.isSpaRequest( ) )
            {
               disableOutput();
            }
         }
         /* End function define_styles */
      }

      protected void include_jscripts( )
      {
         context.AddJavascriptSource("messages.spa.js", "?"+GetCacheInvalidationToken( ), false, true);
         context.AddJavascriptSource("empleado.js", "?202541223451655", false, true);
         /* End function include_jscripts */
      }

      protected void init_default_properties( )
      {
         lblTitle_Internalname = "TITLE";
         divTitlecontainer_Internalname = "TITLECONTAINER";
         bttBtn_first_Internalname = "BTN_FIRST";
         bttBtn_previous_Internalname = "BTN_PREVIOUS";
         bttBtn_next_Internalname = "BTN_NEXT";
         bttBtn_last_Internalname = "BTN_LAST";
         bttBtn_select_Internalname = "BTN_SELECT";
         divToolbarcell_Internalname = "TOOLBARCELL";
         edtEmpleadoId_Internalname = "EMPLEADOID";
         edtEmpleadoNombre_Internalname = "EMPLEADONOMBRE";
         edtEmpleadoApellido_Internalname = "EMPLEADOAPELLIDO";
         edtEmpleadoDireccion_Internalname = "EMPLEADODIRECCION";
         edtEmpleadoTelefono_Internalname = "EMPLEADOTELEFONO";
         edtEmpleadoEmail_Internalname = "EMPLEADOEMAIL";
         edtEmpleadoFch_Alta_Internalname = "EMPLEADOFCH_ALTA";
         edtEmpleadoFcha_Mod_Internalname = "EMPLEADOFCHA_MOD";
         edtEmpleadoFch_Cad_Internalname = "EMPLEADOFCH_CAD";
         edtEmpleadoUsu_Alta_Internalname = "EMPLEADOUSU_ALTA";
         edtEmpleadoUsu_Mod_Internalname = "EMPLEADOUSU_MOD";
         edtEmpleadoUso_Cad_Internalname = "EMPLEADOUSO_CAD";
         edtparqueAtraccionId_Internalname = "PARQUEATRACCIONID";
         edtparqueAtraccionNombre_Internalname = "PARQUEATRACCIONNOMBRE";
         divFormcontainer_Internalname = "FORMCONTAINER";
         bttBtn_enter_Internalname = "BTN_ENTER";
         bttBtn_cancel_Internalname = "BTN_CANCEL";
         bttBtn_delete_Internalname = "BTN_DELETE";
         divMaintable_Internalname = "MAINTABLE";
         Form.Internalname = "FORM";
         imgprompt_13_Internalname = "PROMPT_13";
      }

      public override void initialize_properties( )
      {
         context.SetDefaultTheme("parques", true);
         if ( context.isSpaRequest( ) )
         {
            disableJsOutput();
         }
         init_default_properties( ) ;
         Form.Headerrawhtml = "";
         Form.Background = "";
         Form.Textcolor = 0;
         Form.Backcolor = (int)(0xFFFFFF);
         Form.Caption = "Empleado";
         bttBtn_delete_Enabled = 0;
         bttBtn_delete_Visible = 1;
         bttBtn_cancel_Visible = 1;
         bttBtn_enter_Tooltiptext = "Confirmar";
         bttBtn_enter_Caption = "Confirmar";
         bttBtn_enter_Enabled = 1;
         bttBtn_enter_Visible = 1;
         edtparqueAtraccionNombre_Jsonclick = "";
         edtparqueAtraccionNombre_Enabled = 0;
         imgprompt_13_Visible = 1;
         imgprompt_13_Link = "";
         edtparqueAtraccionId_Jsonclick = "";
         edtparqueAtraccionId_Enabled = 1;
         edtEmpleadoUso_Cad_Jsonclick = "";
         edtEmpleadoUso_Cad_Enabled = 1;
         edtEmpleadoUsu_Mod_Jsonclick = "";
         edtEmpleadoUsu_Mod_Enabled = 1;
         edtEmpleadoUsu_Alta_Jsonclick = "";
         edtEmpleadoUsu_Alta_Enabled = 1;
         edtEmpleadoFch_Cad_Jsonclick = "";
         edtEmpleadoFch_Cad_Enabled = 1;
         edtEmpleadoFcha_Mod_Jsonclick = "";
         edtEmpleadoFcha_Mod_Enabled = 1;
         edtEmpleadoFch_Alta_Jsonclick = "";
         edtEmpleadoFch_Alta_Enabled = 1;
         edtEmpleadoEmail_Jsonclick = "";
         edtEmpleadoEmail_Enabled = 1;
         edtEmpleadoTelefono_Jsonclick = "";
         edtEmpleadoTelefono_Enabled = 1;
         edtEmpleadoDireccion_Enabled = 1;
         edtEmpleadoApellido_Enabled = 1;
         edtEmpleadoNombre_Enabled = 1;
         edtEmpleadoId_Jsonclick = "";
         edtEmpleadoId_Enabled = 0;
         bttBtn_select_Visible = 1;
         bttBtn_last_Visible = 1;
         bttBtn_next_Visible = 1;
         bttBtn_previous_Visible = 1;
         bttBtn_first_Visible = 1;
         context.GX_msglist.DisplayMode = 1;
         if ( context.isSpaRequest( ) )
         {
            enableJsOutput();
         }
      }

      protected void dynload_actions( )
      {
         /* End function dynload_actions */
      }

      protected void init_web_controls( )
      {
         /* End function init_web_controls */
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

      public void Valid_Parqueatraccionid( )
      {
         /* Using cursor T000113 */
         pr_default.execute(11, new Object[] {A13parqueAtraccionId});
         if ( (pr_default.getStatus(11) == 101) )
         {
            GX_msglist.addItem("No existe 'parque Atraccion'.", "ForeignKeyNotFound", 1, "PARQUEATRACCIONID");
            AnyError = 1;
            GX_FocusControl = edtparqueAtraccionId_Internalname;
         }
         A14parqueAtraccionNombre = T000113_A14parqueAtraccionNombre[0];
         pr_default.close(11);
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "A14parqueAtraccionNombre", A14parqueAtraccionNombre);
      }

      public override bool SupportAjaxEvent( )
      {
         return true ;
      }

      public override void InitializeDynEvents( )
      {
         setEventMetadata("ENTER","""{"handler":"UserMainFullajax","iparms":[{"postForm":true},{"av":"Gx_mode","fld":"vMODE","pic":"@!","hsh":true},{"av":"AV7EmpleadoId","fld":"vEMPLEADOID","pic":"ZZZ9","hsh":true}]}""");
         setEventMetadata("REFRESH","""{"handler":"Refresh","iparms":[{"av":"Gx_mode","fld":"vMODE","pic":"@!","hsh":true},{"av":"AV9TrnContext","fld":"vTRNCONTEXT","hsh":true},{"av":"AV7EmpleadoId","fld":"vEMPLEADOID","pic":"ZZZ9","hsh":true},{"av":"A1EmpleadoId","fld":"EMPLEADOID","pic":"ZZZ9"}]}""");
         setEventMetadata("AFTER TRN","""{"handler":"E12012","iparms":[{"av":"Gx_mode","fld":"vMODE","pic":"@!","hsh":true},{"av":"AV9TrnContext","fld":"vTRNCONTEXT","hsh":true}]}""");
         setEventMetadata("VALID_EMPLEADOID","""{"handler":"Valid_Empleadoid","iparms":[]}""");
         setEventMetadata("VALID_EMPLEADOEMAIL","""{"handler":"Valid_Empleadoemail","iparms":[]}""");
         setEventMetadata("VALID_EMPLEADOFCH_ALTA","""{"handler":"Valid_Empleadofch_alta","iparms":[]}""");
         setEventMetadata("VALID_EMPLEADOFCHA_MOD","""{"handler":"Valid_Empleadofcha_mod","iparms":[]}""");
         setEventMetadata("VALID_EMPLEADOFCH_CAD","""{"handler":"Valid_Empleadofch_cad","iparms":[]}""");
         setEventMetadata("VALID_PARQUEATRACCIONID","""{"handler":"Valid_Parqueatraccionid","iparms":[{"av":"A13parqueAtraccionId","fld":"PARQUEATRACCIONID","pic":"ZZZ9"},{"av":"A14parqueAtraccionNombre","fld":"PARQUEATRACCIONNOMBRE"}]""");
         setEventMetadata("VALID_PARQUEATRACCIONID",""","oparms":[{"av":"A14parqueAtraccionNombre","fld":"PARQUEATRACCIONNOMBRE"}]}""");
         return  ;
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
         pr_default.close(11);
      }

      public override void initialize( )
      {
         sPrefix = "";
         wcpOGx_mode = "";
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
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         GXKey = "";
         PreviousTooltip = "";
         PreviousCaption = "";
         Form = new GXWebForm();
         GX_FocusControl = "";
         lblTitle_Jsonclick = "";
         ClassString = "";
         StyleString = "";
         TempTags = "";
         bttBtn_first_Jsonclick = "";
         bttBtn_previous_Jsonclick = "";
         bttBtn_next_Jsonclick = "";
         bttBtn_last_Jsonclick = "";
         bttBtn_select_Jsonclick = "";
         A2EmpleadoNombre = "";
         A3EmpleadoApellido = "";
         A4EmpleadoDireccion = "";
         gxphoneLink = "";
         A5EmpleadoTelefono = "";
         A6EmpleadoEmail = "";
         A7EmpleadoFch_Alta = (DateTime)(DateTime.MinValue);
         A8EmpleadoFcha_Mod = (DateTime)(DateTime.MinValue);
         A9EmpleadoFch_Cad = (DateTime)(DateTime.MinValue);
         A10EmpleadoUsu_Alta = "";
         A11EmpleadoUsu_Mod = "";
         A12EmpleadoUso_Cad = "";
         imgprompt_13_gximage = "";
         sImgUrl = "";
         A14parqueAtraccionNombre = "";
         bttBtn_enter_Jsonclick = "";
         bttBtn_cancel_Jsonclick = "";
         bttBtn_delete_Jsonclick = "";
         AV11Insert_parqueAtraccionId = 1;
         AV13Pgmname = "";
         forbiddenHiddens = new GXProperties();
         hsh = "";
         sMode1 = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         endTrnMsgTxt = "";
         endTrnMsgCod = "";
         AV9TrnContext = new GeneXus.Programs.general.ui.SdtTransactionContext(context);
         AV10WebSession = context.GetSession();
         AV12TrnContextAtt = new GeneXus.Programs.general.ui.SdtTransactionContext_Attribute(context);
         Z14parqueAtraccionNombre = "";
         T00014_A14parqueAtraccionNombre = new string[] {""} ;
         T00015_A1EmpleadoId = new short[1] ;
         T00015_A2EmpleadoNombre = new string[] {""} ;
         T00015_A3EmpleadoApellido = new string[] {""} ;
         T00015_A4EmpleadoDireccion = new string[] {""} ;
         T00015_n4EmpleadoDireccion = new bool[] {false} ;
         T00015_A5EmpleadoTelefono = new string[] {""} ;
         T00015_n5EmpleadoTelefono = new bool[] {false} ;
         T00015_A6EmpleadoEmail = new string[] {""} ;
         T00015_n6EmpleadoEmail = new bool[] {false} ;
         T00015_A7EmpleadoFch_Alta = new DateTime[] {DateTime.MinValue} ;
         T00015_n7EmpleadoFch_Alta = new bool[] {false} ;
         T00015_A8EmpleadoFcha_Mod = new DateTime[] {DateTime.MinValue} ;
         T00015_n8EmpleadoFcha_Mod = new bool[] {false} ;
         T00015_A9EmpleadoFch_Cad = new DateTime[] {DateTime.MinValue} ;
         T00015_n9EmpleadoFch_Cad = new bool[] {false} ;
         T00015_A10EmpleadoUsu_Alta = new string[] {""} ;
         T00015_n10EmpleadoUsu_Alta = new bool[] {false} ;
         T00015_A11EmpleadoUsu_Mod = new string[] {""} ;
         T00015_n11EmpleadoUsu_Mod = new bool[] {false} ;
         T00015_A12EmpleadoUso_Cad = new string[] {""} ;
         T00015_n12EmpleadoUso_Cad = new bool[] {false} ;
         T00015_A14parqueAtraccionNombre = new string[] {""} ;
         T00015_A13parqueAtraccionId = new short[1] ;
         T00016_A14parqueAtraccionNombre = new string[] {""} ;
         T00017_A1EmpleadoId = new short[1] ;
         T00013_A1EmpleadoId = new short[1] ;
         T00013_A2EmpleadoNombre = new string[] {""} ;
         T00013_A3EmpleadoApellido = new string[] {""} ;
         T00013_A4EmpleadoDireccion = new string[] {""} ;
         T00013_n4EmpleadoDireccion = new bool[] {false} ;
         T00013_A5EmpleadoTelefono = new string[] {""} ;
         T00013_n5EmpleadoTelefono = new bool[] {false} ;
         T00013_A6EmpleadoEmail = new string[] {""} ;
         T00013_n6EmpleadoEmail = new bool[] {false} ;
         T00013_A7EmpleadoFch_Alta = new DateTime[] {DateTime.MinValue} ;
         T00013_n7EmpleadoFch_Alta = new bool[] {false} ;
         T00013_A8EmpleadoFcha_Mod = new DateTime[] {DateTime.MinValue} ;
         T00013_n8EmpleadoFcha_Mod = new bool[] {false} ;
         T00013_A9EmpleadoFch_Cad = new DateTime[] {DateTime.MinValue} ;
         T00013_n9EmpleadoFch_Cad = new bool[] {false} ;
         T00013_A10EmpleadoUsu_Alta = new string[] {""} ;
         T00013_n10EmpleadoUsu_Alta = new bool[] {false} ;
         T00013_A11EmpleadoUsu_Mod = new string[] {""} ;
         T00013_n11EmpleadoUsu_Mod = new bool[] {false} ;
         T00013_A12EmpleadoUso_Cad = new string[] {""} ;
         T00013_n12EmpleadoUso_Cad = new bool[] {false} ;
         T00013_A13parqueAtraccionId = new short[1] ;
         T00018_A1EmpleadoId = new short[1] ;
         T00019_A1EmpleadoId = new short[1] ;
         T00012_A1EmpleadoId = new short[1] ;
         T00012_A2EmpleadoNombre = new string[] {""} ;
         T00012_A3EmpleadoApellido = new string[] {""} ;
         T00012_A4EmpleadoDireccion = new string[] {""} ;
         T00012_n4EmpleadoDireccion = new bool[] {false} ;
         T00012_A5EmpleadoTelefono = new string[] {""} ;
         T00012_n5EmpleadoTelefono = new bool[] {false} ;
         T00012_A6EmpleadoEmail = new string[] {""} ;
         T00012_n6EmpleadoEmail = new bool[] {false} ;
         T00012_A7EmpleadoFch_Alta = new DateTime[] {DateTime.MinValue} ;
         T00012_n7EmpleadoFch_Alta = new bool[] {false} ;
         T00012_A8EmpleadoFcha_Mod = new DateTime[] {DateTime.MinValue} ;
         T00012_n8EmpleadoFcha_Mod = new bool[] {false} ;
         T00012_A9EmpleadoFch_Cad = new DateTime[] {DateTime.MinValue} ;
         T00012_n9EmpleadoFch_Cad = new bool[] {false} ;
         T00012_A10EmpleadoUsu_Alta = new string[] {""} ;
         T00012_n10EmpleadoUsu_Alta = new bool[] {false} ;
         T00012_A11EmpleadoUsu_Mod = new string[] {""} ;
         T00012_n11EmpleadoUsu_Mod = new bool[] {false} ;
         T00012_A12EmpleadoUso_Cad = new string[] {""} ;
         T00012_n12EmpleadoUso_Cad = new bool[] {false} ;
         T00012_A13parqueAtraccionId = new short[1] ;
         T000110_A1EmpleadoId = new short[1] ;
         T000113_A14parqueAtraccionNombre = new string[] {""} ;
         T000114_A1EmpleadoId = new short[1] ;
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         i7EmpleadoFch_Alta = (DateTime)(DateTime.MinValue);
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.empleado__default(),
            new Object[][] {
                new Object[] {
               T00012_A1EmpleadoId, T00012_A2EmpleadoNombre, T00012_A3EmpleadoApellido, T00012_A4EmpleadoDireccion, T00012_n4EmpleadoDireccion, T00012_A5EmpleadoTelefono, T00012_n5EmpleadoTelefono, T00012_A6EmpleadoEmail, T00012_n6EmpleadoEmail, T00012_A7EmpleadoFch_Alta,
               T00012_n7EmpleadoFch_Alta, T00012_A8EmpleadoFcha_Mod, T00012_n8EmpleadoFcha_Mod, T00012_A9EmpleadoFch_Cad, T00012_n9EmpleadoFch_Cad, T00012_A10EmpleadoUsu_Alta, T00012_n10EmpleadoUsu_Alta, T00012_A11EmpleadoUsu_Mod, T00012_n11EmpleadoUsu_Mod, T00012_A12EmpleadoUso_Cad,
               T00012_n12EmpleadoUso_Cad, T00012_A13parqueAtraccionId
               }
               , new Object[] {
               T00013_A1EmpleadoId, T00013_A2EmpleadoNombre, T00013_A3EmpleadoApellido, T00013_A4EmpleadoDireccion, T00013_n4EmpleadoDireccion, T00013_A5EmpleadoTelefono, T00013_n5EmpleadoTelefono, T00013_A6EmpleadoEmail, T00013_n6EmpleadoEmail, T00013_A7EmpleadoFch_Alta,
               T00013_n7EmpleadoFch_Alta, T00013_A8EmpleadoFcha_Mod, T00013_n8EmpleadoFcha_Mod, T00013_A9EmpleadoFch_Cad, T00013_n9EmpleadoFch_Cad, T00013_A10EmpleadoUsu_Alta, T00013_n10EmpleadoUsu_Alta, T00013_A11EmpleadoUsu_Mod, T00013_n11EmpleadoUsu_Mod, T00013_A12EmpleadoUso_Cad,
               T00013_n12EmpleadoUso_Cad, T00013_A13parqueAtraccionId
               }
               , new Object[] {
               T00014_A14parqueAtraccionNombre
               }
               , new Object[] {
               T00015_A1EmpleadoId, T00015_A2EmpleadoNombre, T00015_A3EmpleadoApellido, T00015_A4EmpleadoDireccion, T00015_n4EmpleadoDireccion, T00015_A5EmpleadoTelefono, T00015_n5EmpleadoTelefono, T00015_A6EmpleadoEmail, T00015_n6EmpleadoEmail, T00015_A7EmpleadoFch_Alta,
               T00015_n7EmpleadoFch_Alta, T00015_A8EmpleadoFcha_Mod, T00015_n8EmpleadoFcha_Mod, T00015_A9EmpleadoFch_Cad, T00015_n9EmpleadoFch_Cad, T00015_A10EmpleadoUsu_Alta, T00015_n10EmpleadoUsu_Alta, T00015_A11EmpleadoUsu_Mod, T00015_n11EmpleadoUsu_Mod, T00015_A12EmpleadoUso_Cad,
               T00015_n12EmpleadoUso_Cad, T00015_A14parqueAtraccionNombre, T00015_A13parqueAtraccionId
               }
               , new Object[] {
               T00016_A14parqueAtraccionNombre
               }
               , new Object[] {
               T00017_A1EmpleadoId
               }
               , new Object[] {
               T00018_A1EmpleadoId
               }
               , new Object[] {
               T00019_A1EmpleadoId
               }
               , new Object[] {
               T000110_A1EmpleadoId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T000113_A14parqueAtraccionNombre
               }
               , new Object[] {
               T000114_A1EmpleadoId
               }
            }
         );
         Z13parqueAtraccionId = 1;
         N13parqueAtraccionId = 1;
         i13parqueAtraccionId = 1;
         A13parqueAtraccionId = 1;
         Z7EmpleadoFch_Alta = DateTimeUtil.ResetTime( DateTimeUtil.Today( context) ) ;
         n7EmpleadoFch_Alta = false;
         A7EmpleadoFch_Alta = DateTimeUtil.ResetTime( DateTimeUtil.Today( context) ) ;
         n7EmpleadoFch_Alta = false;
         i7EmpleadoFch_Alta = DateTimeUtil.ResetTime( DateTimeUtil.Today( context) ) ;
         n7EmpleadoFch_Alta = false;
         Z1EmpleadoId = 1;
         A1EmpleadoId = 1;
         AV13Pgmname = "Empleado";
      }

      private short wcpOAV7EmpleadoId ;
      private short Z1EmpleadoId ;
      private short Z13parqueAtraccionId ;
      private short N13parqueAtraccionId ;
      private short GxWebError ;
      private short A13parqueAtraccionId ;
      private short AV7EmpleadoId ;
      private short gxcookieaux ;
      private short AnyError ;
      private short IsModified ;
      private short IsConfirmed ;
      private short nKeyPressed ;
      private short A1EmpleadoId ;
      private short Gx_BScreen ;
      private short AV11Insert_parqueAtraccionId ;
      private short RcdFound1 ;
      private short gxajaxcallmode ;
      private short i13parqueAtraccionId ;
      private int trnEnded ;
      private int bttBtn_first_Visible ;
      private int bttBtn_previous_Visible ;
      private int bttBtn_next_Visible ;
      private int bttBtn_last_Visible ;
      private int bttBtn_select_Visible ;
      private int edtEmpleadoId_Enabled ;
      private int edtEmpleadoNombre_Enabled ;
      private int edtEmpleadoApellido_Enabled ;
      private int edtEmpleadoDireccion_Enabled ;
      private int edtEmpleadoTelefono_Enabled ;
      private int edtEmpleadoEmail_Enabled ;
      private int edtEmpleadoFch_Alta_Enabled ;
      private int edtEmpleadoFcha_Mod_Enabled ;
      private int edtEmpleadoFch_Cad_Enabled ;
      private int edtEmpleadoUsu_Alta_Enabled ;
      private int edtEmpleadoUsu_Mod_Enabled ;
      private int edtEmpleadoUso_Cad_Enabled ;
      private int edtparqueAtraccionId_Enabled ;
      private int imgprompt_13_Visible ;
      private int edtparqueAtraccionNombre_Enabled ;
      private int bttBtn_enter_Visible ;
      private int bttBtn_enter_Enabled ;
      private int bttBtn_cancel_Visible ;
      private int bttBtn_delete_Visible ;
      private int bttBtn_delete_Enabled ;
      private int AV14GXV1 ;
      private int idxLst ;
      private string sPrefix ;
      private string wcpOGx_mode ;
      private string Z5EmpleadoTelefono ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string Gx_mode ;
      private string GXKey ;
      private string PreviousTooltip ;
      private string PreviousCaption ;
      private string GX_FocusControl ;
      private string edtEmpleadoNombre_Internalname ;
      private string divMaintable_Internalname ;
      private string divTitlecontainer_Internalname ;
      private string lblTitle_Internalname ;
      private string lblTitle_Jsonclick ;
      private string ClassString ;
      private string StyleString ;
      private string divFormcontainer_Internalname ;
      private string divToolbarcell_Internalname ;
      private string TempTags ;
      private string bttBtn_first_Internalname ;
      private string bttBtn_first_Jsonclick ;
      private string bttBtn_previous_Internalname ;
      private string bttBtn_previous_Jsonclick ;
      private string bttBtn_next_Internalname ;
      private string bttBtn_next_Jsonclick ;
      private string bttBtn_last_Internalname ;
      private string bttBtn_last_Jsonclick ;
      private string bttBtn_select_Internalname ;
      private string bttBtn_select_Jsonclick ;
      private string edtEmpleadoId_Internalname ;
      private string edtEmpleadoId_Jsonclick ;
      private string edtEmpleadoApellido_Internalname ;
      private string edtEmpleadoDireccion_Internalname ;
      private string edtEmpleadoTelefono_Internalname ;
      private string gxphoneLink ;
      private string A5EmpleadoTelefono ;
      private string edtEmpleadoTelefono_Jsonclick ;
      private string edtEmpleadoEmail_Internalname ;
      private string edtEmpleadoEmail_Jsonclick ;
      private string edtEmpleadoFch_Alta_Internalname ;
      private string edtEmpleadoFch_Alta_Jsonclick ;
      private string edtEmpleadoFcha_Mod_Internalname ;
      private string edtEmpleadoFcha_Mod_Jsonclick ;
      private string edtEmpleadoFch_Cad_Internalname ;
      private string edtEmpleadoFch_Cad_Jsonclick ;
      private string edtEmpleadoUsu_Alta_Internalname ;
      private string edtEmpleadoUsu_Alta_Jsonclick ;
      private string edtEmpleadoUsu_Mod_Internalname ;
      private string edtEmpleadoUsu_Mod_Jsonclick ;
      private string edtEmpleadoUso_Cad_Internalname ;
      private string edtEmpleadoUso_Cad_Jsonclick ;
      private string edtparqueAtraccionId_Internalname ;
      private string edtparqueAtraccionId_Jsonclick ;
      private string imgprompt_13_gximage ;
      private string sImgUrl ;
      private string imgprompt_13_Internalname ;
      private string imgprompt_13_Link ;
      private string edtparqueAtraccionNombre_Internalname ;
      private string edtparqueAtraccionNombre_Jsonclick ;
      private string bttBtn_enter_Internalname ;
      private string bttBtn_enter_Caption ;
      private string bttBtn_enter_Jsonclick ;
      private string bttBtn_enter_Tooltiptext ;
      private string bttBtn_cancel_Internalname ;
      private string bttBtn_cancel_Jsonclick ;
      private string bttBtn_delete_Internalname ;
      private string bttBtn_delete_Jsonclick ;
      private string AV13Pgmname ;
      private string hsh ;
      private string sMode1 ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string endTrnMsgTxt ;
      private string endTrnMsgCod ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private DateTime Z7EmpleadoFch_Alta ;
      private DateTime Z8EmpleadoFcha_Mod ;
      private DateTime Z9EmpleadoFch_Cad ;
      private DateTime A7EmpleadoFch_Alta ;
      private DateTime A8EmpleadoFcha_Mod ;
      private DateTime A9EmpleadoFch_Cad ;
      private DateTime i7EmpleadoFch_Alta ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool wbErr ;
      private bool n4EmpleadoDireccion ;
      private bool n5EmpleadoTelefono ;
      private bool n6EmpleadoEmail ;
      private bool n7EmpleadoFch_Alta ;
      private bool n8EmpleadoFcha_Mod ;
      private bool n9EmpleadoFch_Cad ;
      private bool n10EmpleadoUsu_Alta ;
      private bool n11EmpleadoUsu_Mod ;
      private bool n12EmpleadoUso_Cad ;
      private bool returnInSub ;
      private bool Gx_longc ;
      private string Z2EmpleadoNombre ;
      private string Z3EmpleadoApellido ;
      private string Z4EmpleadoDireccion ;
      private string Z6EmpleadoEmail ;
      private string Z10EmpleadoUsu_Alta ;
      private string Z11EmpleadoUsu_Mod ;
      private string Z12EmpleadoUso_Cad ;
      private string A2EmpleadoNombre ;
      private string A3EmpleadoApellido ;
      private string A4EmpleadoDireccion ;
      private string A6EmpleadoEmail ;
      private string A10EmpleadoUsu_Alta ;
      private string A11EmpleadoUsu_Mod ;
      private string A12EmpleadoUso_Cad ;
      private string A14parqueAtraccionNombre ;
      private string Z14parqueAtraccionNombre ;
      private IGxSession AV10WebSession ;
      private GXProperties forbiddenHiddens ;
      private GXWebForm Form ;
      private IGxDataStore dsDefault ;
      private GeneXus.Programs.general.ui.SdtTransactionContext AV9TrnContext ;
      private GeneXus.Programs.general.ui.SdtTransactionContext_Attribute AV12TrnContextAtt ;
      private IDataStoreProvider pr_default ;
      private string[] T00014_A14parqueAtraccionNombre ;
      private short[] T00015_A1EmpleadoId ;
      private string[] T00015_A2EmpleadoNombre ;
      private string[] T00015_A3EmpleadoApellido ;
      private string[] T00015_A4EmpleadoDireccion ;
      private bool[] T00015_n4EmpleadoDireccion ;
      private string[] T00015_A5EmpleadoTelefono ;
      private bool[] T00015_n5EmpleadoTelefono ;
      private string[] T00015_A6EmpleadoEmail ;
      private bool[] T00015_n6EmpleadoEmail ;
      private DateTime[] T00015_A7EmpleadoFch_Alta ;
      private bool[] T00015_n7EmpleadoFch_Alta ;
      private DateTime[] T00015_A8EmpleadoFcha_Mod ;
      private bool[] T00015_n8EmpleadoFcha_Mod ;
      private DateTime[] T00015_A9EmpleadoFch_Cad ;
      private bool[] T00015_n9EmpleadoFch_Cad ;
      private string[] T00015_A10EmpleadoUsu_Alta ;
      private bool[] T00015_n10EmpleadoUsu_Alta ;
      private string[] T00015_A11EmpleadoUsu_Mod ;
      private bool[] T00015_n11EmpleadoUsu_Mod ;
      private string[] T00015_A12EmpleadoUso_Cad ;
      private bool[] T00015_n12EmpleadoUso_Cad ;
      private string[] T00015_A14parqueAtraccionNombre ;
      private short[] T00015_A13parqueAtraccionId ;
      private string[] T00016_A14parqueAtraccionNombre ;
      private short[] T00017_A1EmpleadoId ;
      private short[] T00013_A1EmpleadoId ;
      private string[] T00013_A2EmpleadoNombre ;
      private string[] T00013_A3EmpleadoApellido ;
      private string[] T00013_A4EmpleadoDireccion ;
      private bool[] T00013_n4EmpleadoDireccion ;
      private string[] T00013_A5EmpleadoTelefono ;
      private bool[] T00013_n5EmpleadoTelefono ;
      private string[] T00013_A6EmpleadoEmail ;
      private bool[] T00013_n6EmpleadoEmail ;
      private DateTime[] T00013_A7EmpleadoFch_Alta ;
      private bool[] T00013_n7EmpleadoFch_Alta ;
      private DateTime[] T00013_A8EmpleadoFcha_Mod ;
      private bool[] T00013_n8EmpleadoFcha_Mod ;
      private DateTime[] T00013_A9EmpleadoFch_Cad ;
      private bool[] T00013_n9EmpleadoFch_Cad ;
      private string[] T00013_A10EmpleadoUsu_Alta ;
      private bool[] T00013_n10EmpleadoUsu_Alta ;
      private string[] T00013_A11EmpleadoUsu_Mod ;
      private bool[] T00013_n11EmpleadoUsu_Mod ;
      private string[] T00013_A12EmpleadoUso_Cad ;
      private bool[] T00013_n12EmpleadoUso_Cad ;
      private short[] T00013_A13parqueAtraccionId ;
      private short[] T00018_A1EmpleadoId ;
      private short[] T00019_A1EmpleadoId ;
      private short[] T00012_A1EmpleadoId ;
      private string[] T00012_A2EmpleadoNombre ;
      private string[] T00012_A3EmpleadoApellido ;
      private string[] T00012_A4EmpleadoDireccion ;
      private bool[] T00012_n4EmpleadoDireccion ;
      private string[] T00012_A5EmpleadoTelefono ;
      private bool[] T00012_n5EmpleadoTelefono ;
      private string[] T00012_A6EmpleadoEmail ;
      private bool[] T00012_n6EmpleadoEmail ;
      private DateTime[] T00012_A7EmpleadoFch_Alta ;
      private bool[] T00012_n7EmpleadoFch_Alta ;
      private DateTime[] T00012_A8EmpleadoFcha_Mod ;
      private bool[] T00012_n8EmpleadoFcha_Mod ;
      private DateTime[] T00012_A9EmpleadoFch_Cad ;
      private bool[] T00012_n9EmpleadoFch_Cad ;
      private string[] T00012_A10EmpleadoUsu_Alta ;
      private bool[] T00012_n10EmpleadoUsu_Alta ;
      private string[] T00012_A11EmpleadoUsu_Mod ;
      private bool[] T00012_n11EmpleadoUsu_Mod ;
      private string[] T00012_A12EmpleadoUso_Cad ;
      private bool[] T00012_n12EmpleadoUso_Cad ;
      private short[] T00012_A13parqueAtraccionId ;
      private short[] T000110_A1EmpleadoId ;
      private string[] T000113_A14parqueAtraccionNombre ;
      private short[] T000114_A1EmpleadoId ;
   }

   public class empleado__default : DataStoreHelperBase, IDataStoreHelper
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
         ,new ForEachCursor(def[6])
         ,new ForEachCursor(def[7])
         ,new ForEachCursor(def[8])
         ,new UpdateCursor(def[9])
         ,new UpdateCursor(def[10])
         ,new ForEachCursor(def[11])
         ,new ForEachCursor(def[12])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmT00012;
          prmT00012 = new Object[] {
          new ParDef("@EmpleadoId",GXType.Int16,4,0)
          };
          Object[] prmT00013;
          prmT00013 = new Object[] {
          new ParDef("@EmpleadoId",GXType.Int16,4,0)
          };
          Object[] prmT00014;
          prmT00014 = new Object[] {
          new ParDef("@parqueAtraccionId",GXType.Int16,4,0)
          };
          Object[] prmT00015;
          prmT00015 = new Object[] {
          new ParDef("@EmpleadoId",GXType.Int16,4,0)
          };
          Object[] prmT00016;
          prmT00016 = new Object[] {
          new ParDef("@parqueAtraccionId",GXType.Int16,4,0)
          };
          Object[] prmT00017;
          prmT00017 = new Object[] {
          new ParDef("@EmpleadoId",GXType.Int16,4,0)
          };
          Object[] prmT00018;
          prmT00018 = new Object[] {
          new ParDef("@EmpleadoId",GXType.Int16,4,0)
          };
          Object[] prmT00019;
          prmT00019 = new Object[] {
          new ParDef("@EmpleadoId",GXType.Int16,4,0)
          };
          Object[] prmT000110;
          prmT000110 = new Object[] {
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
          new ParDef("@parqueAtraccionId",GXType.Int16,4,0)
          };
          Object[] prmT000111;
          prmT000111 = new Object[] {
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
          new ParDef("@parqueAtraccionId",GXType.Int16,4,0) ,
          new ParDef("@EmpleadoId",GXType.Int16,4,0)
          };
          Object[] prmT000112;
          prmT000112 = new Object[] {
          new ParDef("@EmpleadoId",GXType.Int16,4,0)
          };
          Object[] prmT000113;
          prmT000113 = new Object[] {
          new ParDef("@parqueAtraccionId",GXType.Int16,4,0)
          };
          Object[] prmT000114;
          prmT000114 = new Object[] {
          };
          def= new CursorDef[] {
              new CursorDef("T00012", "SELECT [EmpleadoId], [EmpleadoNombre], [EmpleadoApellido], [EmpleadoDireccion], [EmpleadoTelefono], [EmpleadoEmail], [EmpleadoFch_Alta], [EmpleadoFcha_Mod], [EmpleadoFch_Cad], [EmpleadoUsu_Alta], [EmpleadoUsu_Mod], [EmpleadoUso_Cad], [parqueAtraccionId] FROM [Empleado] WITH (UPDLOCK) WHERE [EmpleadoId] = @EmpleadoId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00012,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00013", "SELECT [EmpleadoId], [EmpleadoNombre], [EmpleadoApellido], [EmpleadoDireccion], [EmpleadoTelefono], [EmpleadoEmail], [EmpleadoFch_Alta], [EmpleadoFcha_Mod], [EmpleadoFch_Cad], [EmpleadoUsu_Alta], [EmpleadoUsu_Mod], [EmpleadoUso_Cad], [parqueAtraccionId] FROM [Empleado] WHERE [EmpleadoId] = @EmpleadoId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00013,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00014", "SELECT [parqueAtraccionNombre] FROM [parqueAtraccion] WHERE [parqueAtraccionId] = @parqueAtraccionId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00014,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00015", "SELECT TM1.[EmpleadoId], TM1.[EmpleadoNombre], TM1.[EmpleadoApellido], TM1.[EmpleadoDireccion], TM1.[EmpleadoTelefono], TM1.[EmpleadoEmail], TM1.[EmpleadoFch_Alta], TM1.[EmpleadoFcha_Mod], TM1.[EmpleadoFch_Cad], TM1.[EmpleadoUsu_Alta], TM1.[EmpleadoUsu_Mod], TM1.[EmpleadoUso_Cad], T2.[parqueAtraccionNombre], TM1.[parqueAtraccionId] FROM ([Empleado] TM1 INNER JOIN [parqueAtraccion] T2 ON T2.[parqueAtraccionId] = TM1.[parqueAtraccionId]) WHERE TM1.[EmpleadoId] = @EmpleadoId ORDER BY TM1.[EmpleadoId]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT00015,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00016", "SELECT [parqueAtraccionNombre] FROM [parqueAtraccion] WHERE [parqueAtraccionId] = @parqueAtraccionId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00016,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00017", "SELECT [EmpleadoId] FROM [Empleado] WHERE [EmpleadoId] = @EmpleadoId  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT00017,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00018", "SELECT TOP 1 [EmpleadoId] FROM [Empleado] WHERE ( [EmpleadoId] > @EmpleadoId) ORDER BY [EmpleadoId]  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT00018,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T00019", "SELECT TOP 1 [EmpleadoId] FROM [Empleado] WHERE ( [EmpleadoId] < @EmpleadoId) ORDER BY [EmpleadoId] DESC  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT00019,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T000110", "INSERT INTO [Empleado]([EmpleadoNombre], [EmpleadoApellido], [EmpleadoDireccion], [EmpleadoTelefono], [EmpleadoEmail], [EmpleadoFch_Alta], [EmpleadoFcha_Mod], [EmpleadoFch_Cad], [EmpleadoUsu_Alta], [EmpleadoUsu_Mod], [EmpleadoUso_Cad], [parqueAtraccionId]) VALUES(@EmpleadoNombre, @EmpleadoApellido, @EmpleadoDireccion, @EmpleadoTelefono, @EmpleadoEmail, @EmpleadoFch_Alta, @EmpleadoFcha_Mod, @EmpleadoFch_Cad, @EmpleadoUsu_Alta, @EmpleadoUsu_Mod, @EmpleadoUso_Cad, @parqueAtraccionId); SELECT SCOPE_IDENTITY()",true, GxErrorMask.GX_NOMASK, false, this,prmT000110,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T000111", "UPDATE [Empleado] SET [EmpleadoNombre]=@EmpleadoNombre, [EmpleadoApellido]=@EmpleadoApellido, [EmpleadoDireccion]=@EmpleadoDireccion, [EmpleadoTelefono]=@EmpleadoTelefono, [EmpleadoEmail]=@EmpleadoEmail, [EmpleadoFch_Alta]=@EmpleadoFch_Alta, [EmpleadoFcha_Mod]=@EmpleadoFcha_Mod, [EmpleadoFch_Cad]=@EmpleadoFch_Cad, [EmpleadoUsu_Alta]=@EmpleadoUsu_Alta, [EmpleadoUsu_Mod]=@EmpleadoUsu_Mod, [EmpleadoUso_Cad]=@EmpleadoUso_Cad, [parqueAtraccionId]=@parqueAtraccionId  WHERE [EmpleadoId] = @EmpleadoId", GxErrorMask.GX_NOMASK,prmT000111)
             ,new CursorDef("T000112", "DELETE FROM [Empleado]  WHERE [EmpleadoId] = @EmpleadoId", GxErrorMask.GX_NOMASK,prmT000112)
             ,new CursorDef("T000113", "SELECT [parqueAtraccionNombre] FROM [parqueAtraccion] WHERE [parqueAtraccionId] = @parqueAtraccionId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000113,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000114", "SELECT [EmpleadoId] FROM [Empleado] ORDER BY [EmpleadoId]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT000114,100, GxCacheFrequency.OFF ,true,false )
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
                return;
             case 4 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                return;
             case 5 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                return;
             case 6 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                return;
             case 7 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                return;
             case 8 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                return;
             case 11 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                return;
             case 12 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                return;
       }
    }

 }

}
