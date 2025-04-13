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
   public class parqueatraccion : GXDataArea
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
         gxfirstwebparm = GetNextPar( );
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
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_6") == 0 )
         {
            A18PaisId = (short)(Math.Round(NumberUtil.Val( GetPar( "PaisId"), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "A18PaisId", StringUtil.LTrimStr( (decimal)(A18PaisId), 4, 0));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_6( A18PaisId) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_7") == 0 )
         {
            A20ShowId = (short)(Math.Round(NumberUtil.Val( GetPar( "ShowId"), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "A20ShowId", StringUtil.LTrimStr( (decimal)(A20ShowId), 4, 0));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_7( A20ShowId) ;
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
            gxfirstwebparm = GetNextPar( );
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxfullajaxEvt") == 0 )
         {
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxfirstwebparm = GetNextPar( );
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
         Form.Meta.addItem("description", "parque Atraccion", 0) ;
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         if ( ! context.isAjaxRequest( ) )
         {
            GX_FocusControl = edtparqueAtraccionId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         wbErr = false;
         context.SetDefaultTheme("parques", true);
         if ( ! context.IsLocalStorageSupported( ) )
         {
            context.PushCurrentUrl();
         }
      }

      public parqueatraccion( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("parques", true);
      }

      public parqueatraccion( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( )
      {
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
         GxWebStd.gx_label_ctrl( context, lblTitle_Internalname, "parque Atraccion", "", "", lblTitle_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "heading-01", 0, "", 1, 1, 0, 0, "HLP_parqueAtraccion.htm");
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
         GxWebStd.gx_button_ctrl( context, bttBtn_first_Internalname, "", "", bttBtn_first_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_first_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EFIRST."+"'", TempTags, "", context.GetButtonType( ), "HLP_parqueAtraccion.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 23,'',false,'',0)\"";
         ClassString = "Button button-auxiliary ico__arrow-prev";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_previous_Internalname, "", "", bttBtn_previous_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_previous_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EPREVIOUS."+"'", TempTags, "", context.GetButtonType( ), "HLP_parqueAtraccion.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 25,'',false,'',0)\"";
         ClassString = "Button button-auxiliary ico__arrow-next";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_next_Internalname, "", "", bttBtn_next_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_next_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ENEXT."+"'", TempTags, "", context.GetButtonType( ), "HLP_parqueAtraccion.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 27,'',false,'',0)\"";
         ClassString = "Button button-auxiliary ico__arrow-last";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_last_Internalname, "", "", bttBtn_last_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_last_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ELAST."+"'", TempTags, "", context.GetButtonType( ), "HLP_parqueAtraccion.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 29,'',false,'',0)\"";
         ClassString = "Button button-secondary";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_select_Internalname, "", "Seleccionar", bttBtn_select_Jsonclick, 4, "Seleccionar", "", StyleString, ClassString, bttBtn_select_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ESELECT."+"'", TempTags, "gx.popup.openPrompt('"+"gx0020.aspx"+"',["+"{Ctrl:gx.dom.el('"+"PARQUEATRACCIONID"+"'), id:'"+"PARQUEATRACCIONID"+"'"+",IOType:'out',isKey:true,isLastKey:true}"+"],"+"null"+","+"'', false"+","+"true"+");"+"return false;", 2, "HLP_parqueAtraccion.htm");
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtparqueAtraccionId_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtparqueAtraccionId_Internalname, "Atraccion Id", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 34,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtparqueAtraccionId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A13parqueAtraccionId), 4, 0, ",", "")), StringUtil.LTrim( ((edtparqueAtraccionId_Enabled!=0) ? context.localUtil.Format( (decimal)(A13parqueAtraccionId), "ZZZ9") : context.localUtil.Format( (decimal)(A13parqueAtraccionId), "ZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,34);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtparqueAtraccionId_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtparqueAtraccionId_Enabled, 0, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_parqueAtraccion.htm");
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
         GxWebStd.gx_label_element( context, edtparqueAtraccionNombre_Internalname, "Atraccion Nombre", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 39,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtparqueAtraccionNombre_Internalname, A14parqueAtraccionNombre, StringUtil.RTrim( context.localUtil.Format( A14parqueAtraccionNombre, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,39);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtparqueAtraccionNombre_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtparqueAtraccionNombre_Enabled, 0, "text", "", 20, "chr", 1, "row", 20, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_parqueAtraccion.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtparqueAtraccionSitioWeb_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtparqueAtraccionSitioWeb_Internalname, "Sitio Web", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 44,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtparqueAtraccionSitioWeb_Internalname, A15parqueAtraccionSitioWeb, StringUtil.RTrim( context.localUtil.Format( A15parqueAtraccionSitioWeb, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,44);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtparqueAtraccionSitioWeb_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtparqueAtraccionSitioWeb_Enabled, 0, "text", "", 60, "chr", 1, "row", 60, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_parqueAtraccion.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtparqueAtraccionDireccion_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtparqueAtraccionDireccion_Internalname, "Atraccion Direccion", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Multiple line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 49,'',false,'',0)\"";
         ClassString = "Attribute";
         StyleString = "";
         ClassString = "Attribute";
         StyleString = "";
         GxWebStd.gx_html_textarea( context, edtparqueAtraccionDireccion_Internalname, A16parqueAtraccionDireccion, "http://maps.google.com/maps?q="+GXUtil.UrlEncode( A16parqueAtraccionDireccion), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,49);\"", 0, 1, edtparqueAtraccionDireccion_Enabled, 0, 80, "chr", 10, "row", 0, StyleString, ClassString, "", "", "1024", -1, 0, "_blank", "", 0, true, "GeneXus\\Address", "'"+""+"'"+",false,"+"'"+""+"'", 0, "", "HLP_parqueAtraccion.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+imgparqueAtraccionFoto_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, "", "Atraccion Foto", "col-sm-3 ImageAttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Static Bitmap Variable */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 54,'',false,'',0)\"";
         ClassString = "ImageAttribute";
         StyleString = "";
         A17parqueAtraccionFoto_IsBlob = (bool)((String.IsNullOrEmpty(StringUtil.RTrim( A17parqueAtraccionFoto))&&String.IsNullOrEmpty(StringUtil.RTrim( A40000parqueAtraccionFoto_GXI)))||!String.IsNullOrEmpty(StringUtil.RTrim( A17parqueAtraccionFoto)));
         sImgUrl = (String.IsNullOrEmpty(StringUtil.RTrim( A17parqueAtraccionFoto)) ? A40000parqueAtraccionFoto_GXI : context.PathToRelativeUrl( A17parqueAtraccionFoto));
         GxWebStd.gx_bitmap( context, imgparqueAtraccionFoto_Internalname, sImgUrl, "", "", "", context.GetTheme( ), 1, imgparqueAtraccionFoto_Enabled, "", "", 0, -1, 0, "", 0, "", 0, 0, 0, "", "", StyleString, ClassString, "", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,54);\"", "", "", "", 0, A17parqueAtraccionFoto_IsBlob, true, context.GetImageSrcSet( sImgUrl), "HLP_parqueAtraccion.htm");
         AssignProp("", false, imgparqueAtraccionFoto_Internalname, "URL", (String.IsNullOrEmpty(StringUtil.RTrim( A17parqueAtraccionFoto)) ? A40000parqueAtraccionFoto_GXI : context.PathToRelativeUrl( A17parqueAtraccionFoto)), true);
         AssignProp("", false, imgparqueAtraccionFoto_Internalname, "IsBlob", StringUtil.BoolToStr( A17parqueAtraccionFoto_IsBlob), true);
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtPaisId_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtPaisId_Internalname, "Pais Id", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 59,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtPaisId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A18PaisId), 4, 0, ",", "")), StringUtil.LTrim( ((edtPaisId_Enabled!=0) ? context.localUtil.Format( (decimal)(A18PaisId), "ZZZ9") : context.localUtil.Format( (decimal)(A18PaisId), "ZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,59);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtPaisId_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtPaisId_Enabled, 0, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_parqueAtraccion.htm");
         /* Static images/pictures */
         ClassString = "gx-prompt Image" + " " + ((StringUtil.StrCmp(imgprompt_18_gximage, "")==0) ? "" : "GX_Image_"+imgprompt_18_gximage+"_Class");
         StyleString = "";
         sImgUrl = (string)(context.GetImagePath( "prompt.gif", "", context.GetTheme( )));
         GxWebStd.gx_bitmap( context, imgprompt_18_Internalname, sImgUrl, imgprompt_18_Link, "", "", context.GetTheme( ), imgprompt_18_Visible, 1, "", "", 0, 0, 0, "", 0, "", 0, 0, 0, "", "", StyleString, ClassString, "", "", "", "", "", "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_parqueAtraccion.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtPaisNombre_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtPaisNombre_Internalname, "Pais Nombre", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 64,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtPaisNombre_Internalname, A19PaisNombre, StringUtil.RTrim( context.localUtil.Format( A19PaisNombre, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,64);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtPaisNombre_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtPaisNombre_Enabled, 0, "text", "", 50, "chr", 1, "row", 50, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_parqueAtraccion.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtShowId_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtShowId_Internalname, "Show Id", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 69,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtShowId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A20ShowId), 4, 0, ",", "")), StringUtil.LTrim( ((edtShowId_Enabled!=0) ? context.localUtil.Format( (decimal)(A20ShowId), "ZZZ9") : context.localUtil.Format( (decimal)(A20ShowId), "ZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,69);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtShowId_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtShowId_Enabled, 0, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_parqueAtraccion.htm");
         /* Static images/pictures */
         ClassString = "gx-prompt Image" + " " + ((StringUtil.StrCmp(imgprompt_20_gximage, "")==0) ? "" : "GX_Image_"+imgprompt_20_gximage+"_Class");
         StyleString = "";
         sImgUrl = (string)(context.GetImagePath( "prompt.gif", "", context.GetTheme( )));
         GxWebStd.gx_bitmap( context, imgprompt_20_Internalname, sImgUrl, imgprompt_20_Link, "", "", context.GetTheme( ), imgprompt_20_Visible, 1, "", "", 0, 0, 0, "", 0, "", 0, 0, 0, "", "", StyleString, ClassString, "", "", "", "", "", "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_parqueAtraccion.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtShowNombre_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtShowNombre_Internalname, "Show Nombre", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 74,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtShowNombre_Internalname, A21ShowNombre, StringUtil.RTrim( context.localUtil.Format( A21ShowNombre, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,74);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtShowNombre_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtShowNombre_Enabled, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_parqueAtraccion.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtparqueAtraccionShowFechaHora_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtparqueAtraccionShowFechaHora_Internalname, "Fecha Hora", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 79,'',false,'',0)\"";
         context.WriteHtmlText( "<div id=\""+edtparqueAtraccionShowFechaHora_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
         GxWebStd.gx_single_line_edit( context, edtparqueAtraccionShowFechaHora_Internalname, context.localUtil.TToC( A23parqueAtraccionShowFechaHora, 10, 8, 0, 3, "/", ":", " "), context.localUtil.Format( A23parqueAtraccionShowFechaHora, "99/99/99 99:99"), TempTags+" onchange=\""+"gx.date.valid_date(this, 8,'DMY',5,24,'spa',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 8,'DMY',5,24,'spa',false,0);"+";gx.evt.onblur(this,79);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtparqueAtraccionShowFechaHora_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtparqueAtraccionShowFechaHora_Enabled, 0, "text", "", 14, "chr", 1, "row", 14, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_parqueAtraccion.htm");
         GxWebStd.gx_bitmap( context, edtparqueAtraccionShowFechaHora_Internalname+"_dp_trigger", context.GetImagePath( "", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtparqueAtraccionShowFechaHora_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_parqueAtraccion.htm");
         context.WriteHtmlTextNl( "</div>") ;
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
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 84,'',false,'',0)\"";
         ClassString = "Button button-primary";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_enter_Internalname, "", "Confirmar", bttBtn_enter_Jsonclick, 5, "Confirmar", "", StyleString, ClassString, bttBtn_enter_Visible, bttBtn_enter_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_parqueAtraccion.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 86,'',false,'',0)\"";
         ClassString = "Button button-tertiary";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_cancel_Internalname, "", "Cancelar", bttBtn_cancel_Jsonclick, 1, "Cancelar", "", StyleString, ClassString, bttBtn_cancel_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_parqueAtraccion.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 88,'',false,'',0)\"";
         ClassString = "Button button-tertiary";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_delete_Internalname, "", "Eliminar", bttBtn_delete_Jsonclick, 5, "Eliminar", "", StyleString, ClassString, bttBtn_delete_Visible, bttBtn_delete_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EDELETE."+"'", TempTags, "", context.GetButtonType( ), "HLP_parqueAtraccion.htm");
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
         context.wbGlbDoneStart = 1;
         assign_properties_default( ) ;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
            /* Read saved SDTs. */
            /* Read saved values. */
            Z13parqueAtraccionId = (short)(Math.Round(context.localUtil.CToN( cgiGet( "Z13parqueAtraccionId"), ",", "."), 18, MidpointRounding.ToEven));
            Z14parqueAtraccionNombre = cgiGet( "Z14parqueAtraccionNombre");
            Z15parqueAtraccionSitioWeb = cgiGet( "Z15parqueAtraccionSitioWeb");
            Z16parqueAtraccionDireccion = cgiGet( "Z16parqueAtraccionDireccion");
            Z23parqueAtraccionShowFechaHora = context.localUtil.CToT( cgiGet( "Z23parqueAtraccionShowFechaHora"), 0);
            Z18PaisId = (short)(Math.Round(context.localUtil.CToN( cgiGet( "Z18PaisId"), ",", "."), 18, MidpointRounding.ToEven));
            Z20ShowId = (short)(Math.Round(context.localUtil.CToN( cgiGet( "Z20ShowId"), ",", "."), 18, MidpointRounding.ToEven));
            IsConfirmed = (short)(Math.Round(context.localUtil.CToN( cgiGet( "IsConfirmed"), ",", "."), 18, MidpointRounding.ToEven));
            IsModified = (short)(Math.Round(context.localUtil.CToN( cgiGet( "IsModified"), ",", "."), 18, MidpointRounding.ToEven));
            Gx_mode = cgiGet( "Mode");
            Gx_BScreen = (short)(Math.Round(context.localUtil.CToN( cgiGet( "vGXBSCREEN"), ",", "."), 18, MidpointRounding.ToEven));
            A40000parqueAtraccionFoto_GXI = cgiGet( "PARQUEATRACCIONFOTO_GXI");
            /* Read variables values. */
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
            A15parqueAtraccionSitioWeb = cgiGet( edtparqueAtraccionSitioWeb_Internalname);
            AssignAttri("", false, "A15parqueAtraccionSitioWeb", A15parqueAtraccionSitioWeb);
            A16parqueAtraccionDireccion = cgiGet( edtparqueAtraccionDireccion_Internalname);
            AssignAttri("", false, "A16parqueAtraccionDireccion", A16parqueAtraccionDireccion);
            A17parqueAtraccionFoto = cgiGet( imgparqueAtraccionFoto_Internalname);
            AssignAttri("", false, "A17parqueAtraccionFoto", A17parqueAtraccionFoto);
            if ( ( ( context.localUtil.CToN( cgiGet( edtPaisId_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtPaisId_Internalname), ",", ".") > Convert.ToDecimal( 9999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "PAISID");
               AnyError = 1;
               GX_FocusControl = edtPaisId_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A18PaisId = 0;
               AssignAttri("", false, "A18PaisId", StringUtil.LTrimStr( (decimal)(A18PaisId), 4, 0));
            }
            else
            {
               A18PaisId = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtPaisId_Internalname), ",", "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "A18PaisId", StringUtil.LTrimStr( (decimal)(A18PaisId), 4, 0));
            }
            A19PaisNombre = cgiGet( edtPaisNombre_Internalname);
            AssignAttri("", false, "A19PaisNombre", A19PaisNombre);
            if ( ( ( context.localUtil.CToN( cgiGet( edtShowId_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtShowId_Internalname), ",", ".") > Convert.ToDecimal( 9999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "SHOWID");
               AnyError = 1;
               GX_FocusControl = edtShowId_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A20ShowId = 0;
               AssignAttri("", false, "A20ShowId", StringUtil.LTrimStr( (decimal)(A20ShowId), 4, 0));
            }
            else
            {
               A20ShowId = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtShowId_Internalname), ",", "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "A20ShowId", StringUtil.LTrimStr( (decimal)(A20ShowId), 4, 0));
            }
            A21ShowNombre = cgiGet( edtShowNombre_Internalname);
            AssignAttri("", false, "A21ShowNombre", A21ShowNombre);
            if ( context.localUtil.VCDateTime( cgiGet( edtparqueAtraccionShowFechaHora_Internalname), 2, 0) == 0 )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_baddatetime", new   object[]  {"parque Atraccion Show Fecha Hora"}), 1, "PARQUEATRACCIONSHOWFECHAHORA");
               AnyError = 1;
               GX_FocusControl = edtparqueAtraccionShowFechaHora_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A23parqueAtraccionShowFechaHora = (DateTime)(DateTime.MinValue);
               AssignAttri("", false, "A23parqueAtraccionShowFechaHora", context.localUtil.TToC( A23parqueAtraccionShowFechaHora, 8, 5, 0, 3, "/", ":", " "));
            }
            else
            {
               A23parqueAtraccionShowFechaHora = context.localUtil.CToT( cgiGet( edtparqueAtraccionShowFechaHora_Internalname));
               AssignAttri("", false, "A23parqueAtraccionShowFechaHora", context.localUtil.TToC( A23parqueAtraccionShowFechaHora, 8, 5, 0, 3, "/", ":", " "));
            }
            /* Read subfile selected row values. */
            /* Read hidden variables. */
            getMultimediaValue(imgparqueAtraccionFoto_Internalname, ref  A17parqueAtraccionFoto, ref  A40000parqueAtraccionFoto_GXI);
            GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
            standaloneNotModal( ) ;
         }
         else
         {
            standaloneNotModal( ) ;
            if ( StringUtil.StrCmp(gxfirstwebparm, "viewer") == 0 )
            {
               Gx_mode = "DSP";
               AssignAttri("", false, "Gx_mode", Gx_mode);
               A13parqueAtraccionId = (short)(Math.Round(NumberUtil.Val( GetPar( "parqueAtraccionId"), "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "A13parqueAtraccionId", StringUtil.LTrimStr( (decimal)(A13parqueAtraccionId), 4, 0));
               getEqualNoModal( ) ;
               if ( IsIns( )  && (0==A13parqueAtraccionId) && ( Gx_BScreen == 0 ) )
               {
                  A13parqueAtraccionId = 1;
                  AssignAttri("", false, "A13parqueAtraccionId", StringUtil.LTrimStr( (decimal)(A13parqueAtraccionId), 4, 0));
               }
               Gx_mode = "DSP";
               AssignAttri("", false, "Gx_mode", Gx_mode);
               disable_std_buttons_dsp( ) ;
               standaloneModal( ) ;
            }
            else
            {
               getEqualNoModal( ) ;
               standaloneModal( ) ;
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
                        if ( StringUtil.StrCmp(sEvt, "ENTER") == 0 )
                        {
                           context.wbHandled = 1;
                           btn_enter( ) ;
                           /* No code required for Cancel button. It is implemented as the Reset button. */
                        }
                        else if ( StringUtil.StrCmp(sEvt, "FIRST") == 0 )
                        {
                           context.wbHandled = 1;
                           btn_first( ) ;
                        }
                        else if ( StringUtil.StrCmp(sEvt, "PREVIOUS") == 0 )
                        {
                           context.wbHandled = 1;
                           btn_previous( ) ;
                        }
                        else if ( StringUtil.StrCmp(sEvt, "NEXT") == 0 )
                        {
                           context.wbHandled = 1;
                           btn_next( ) ;
                        }
                        else if ( StringUtil.StrCmp(sEvt, "LAST") == 0 )
                        {
                           context.wbHandled = 1;
                           btn_last( ) ;
                        }
                        else if ( StringUtil.StrCmp(sEvt, "SELECT") == 0 )
                        {
                           context.wbHandled = 1;
                           btn_select( ) ;
                        }
                        else if ( StringUtil.StrCmp(sEvt, "DELETE") == 0 )
                        {
                           context.wbHandled = 1;
                           btn_delete( ) ;
                        }
                        else if ( StringUtil.StrCmp(sEvt, "LSCR") == 0 )
                        {
                           context.wbHandled = 1;
                           AfterKeyLoadScreen( ) ;
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
            trnEnded = 0;
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            if ( IsIns( )  )
            {
               /* Clear variables for new insertion. */
               InitAll022( ) ;
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
         if ( IsIns( ) )
         {
            bttBtn_delete_Enabled = 0;
            AssignProp("", false, bttBtn_delete_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_delete_Enabled), 5, 0), true);
         }
      }

      protected void disable_std_buttons_dsp( )
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
         bttBtn_delete_Visible = 0;
         AssignProp("", false, bttBtn_delete_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtn_delete_Visible), 5, 0), true);
         if ( IsDsp( ) )
         {
            bttBtn_enter_Visible = 0;
            AssignProp("", false, bttBtn_enter_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtn_enter_Visible), 5, 0), true);
         }
         DisableAttributes022( ) ;
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

      protected void ResetCaption020( )
      {
      }

      protected void ZM022( short GX_JID )
      {
         if ( ( GX_JID == 5 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z14parqueAtraccionNombre = T00023_A14parqueAtraccionNombre[0];
               Z15parqueAtraccionSitioWeb = T00023_A15parqueAtraccionSitioWeb[0];
               Z16parqueAtraccionDireccion = T00023_A16parqueAtraccionDireccion[0];
               Z23parqueAtraccionShowFechaHora = T00023_A23parqueAtraccionShowFechaHora[0];
               Z18PaisId = T00023_A18PaisId[0];
               Z20ShowId = T00023_A20ShowId[0];
            }
            else
            {
               Z14parqueAtraccionNombre = A14parqueAtraccionNombre;
               Z15parqueAtraccionSitioWeb = A15parqueAtraccionSitioWeb;
               Z16parqueAtraccionDireccion = A16parqueAtraccionDireccion;
               Z23parqueAtraccionShowFechaHora = A23parqueAtraccionShowFechaHora;
               Z18PaisId = A18PaisId;
               Z20ShowId = A20ShowId;
            }
         }
         if ( GX_JID == -5 )
         {
            Z13parqueAtraccionId = A13parqueAtraccionId;
            Z14parqueAtraccionNombre = A14parqueAtraccionNombre;
            Z15parqueAtraccionSitioWeb = A15parqueAtraccionSitioWeb;
            Z16parqueAtraccionDireccion = A16parqueAtraccionDireccion;
            Z17parqueAtraccionFoto = A17parqueAtraccionFoto;
            Z40000parqueAtraccionFoto_GXI = A40000parqueAtraccionFoto_GXI;
            Z23parqueAtraccionShowFechaHora = A23parqueAtraccionShowFechaHora;
            Z18PaisId = A18PaisId;
            Z20ShowId = A20ShowId;
            Z19PaisNombre = A19PaisNombre;
            Z21ShowNombre = A21ShowNombre;
         }
      }

      protected void standaloneNotModal( )
      {
         Gx_BScreen = 0;
         AssignAttri("", false, "Gx_BScreen", StringUtil.Str( (decimal)(Gx_BScreen), 1, 0));
         imgprompt_18_Link = ((StringUtil.StrCmp(Gx_mode, "DSP")==0) ? "" : "javascript:"+"gx.popup.openPrompt('"+"gx0030.aspx"+"',["+"{Ctrl:gx.dom.el('"+"PAISID"+"'), id:'"+"PAISID"+"'"+",IOType:'out'}"+"],"+"null"+","+"'', false"+","+"false"+");");
         imgprompt_20_Link = ((StringUtil.StrCmp(Gx_mode, "DSP")==0) ? "" : "javascript:"+"gx.popup.openPrompt('"+"gx0040.aspx"+"',["+"{Ctrl:gx.dom.el('"+"SHOWID"+"'), id:'"+"SHOWID"+"'"+",IOType:'out'}"+"],"+"null"+","+"'', false"+","+"false"+");");
      }

      protected void standaloneModal( )
      {
         if ( IsIns( )  && (0==A20ShowId) && ( Gx_BScreen == 0 ) )
         {
            A20ShowId = 1;
            AssignAttri("", false, "A20ShowId", StringUtil.LTrimStr( (decimal)(A20ShowId), 4, 0));
         }
         if ( IsIns( )  && (0==A18PaisId) && ( Gx_BScreen == 0 ) )
         {
            A18PaisId = 1;
            AssignAttri("", false, "A18PaisId", StringUtil.LTrimStr( (decimal)(A18PaisId), 4, 0));
         }
         if ( IsIns( )  && (0==A13parqueAtraccionId) && ( Gx_BScreen == 0 ) )
         {
            A13parqueAtraccionId = 1;
            AssignAttri("", false, "A13parqueAtraccionId", StringUtil.LTrimStr( (decimal)(A13parqueAtraccionId), 4, 0));
         }
         if ( StringUtil.StrCmp(Gx_mode, "INS") == 0 )
         {
            bttBtn_delete_Enabled = 0;
            AssignProp("", false, bttBtn_delete_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_delete_Enabled), 5, 0), true);
         }
         else
         {
            bttBtn_delete_Enabled = 1;
            AssignProp("", false, bttBtn_delete_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_delete_Enabled), 5, 0), true);
         }
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
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ( Gx_BScreen == 0 ) )
         {
            /* Using cursor T00025 */
            pr_default.execute(3, new Object[] {A20ShowId});
            A21ShowNombre = T00025_A21ShowNombre[0];
            AssignAttri("", false, "A21ShowNombre", A21ShowNombre);
            pr_default.close(3);
            /* Using cursor T00024 */
            pr_default.execute(2, new Object[] {A18PaisId});
            A19PaisNombre = T00024_A19PaisNombre[0];
            AssignAttri("", false, "A19PaisNombre", A19PaisNombre);
            pr_default.close(2);
         }
      }

      protected void Load022( )
      {
         /* Using cursor T00026 */
         pr_default.execute(4, new Object[] {A13parqueAtraccionId});
         if ( (pr_default.getStatus(4) != 101) )
         {
            RcdFound2 = 1;
            A14parqueAtraccionNombre = T00026_A14parqueAtraccionNombre[0];
            AssignAttri("", false, "A14parqueAtraccionNombre", A14parqueAtraccionNombre);
            A15parqueAtraccionSitioWeb = T00026_A15parqueAtraccionSitioWeb[0];
            AssignAttri("", false, "A15parqueAtraccionSitioWeb", A15parqueAtraccionSitioWeb);
            A16parqueAtraccionDireccion = T00026_A16parqueAtraccionDireccion[0];
            AssignAttri("", false, "A16parqueAtraccionDireccion", A16parqueAtraccionDireccion);
            A40000parqueAtraccionFoto_GXI = T00026_A40000parqueAtraccionFoto_GXI[0];
            AssignProp("", false, imgparqueAtraccionFoto_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A17parqueAtraccionFoto)) ? A40000parqueAtraccionFoto_GXI : context.convertURL( context.PathToRelativeUrl( A17parqueAtraccionFoto))), true);
            AssignProp("", false, imgparqueAtraccionFoto_Internalname, "SrcSet", context.GetImageSrcSet( A17parqueAtraccionFoto), true);
            A19PaisNombre = T00026_A19PaisNombre[0];
            AssignAttri("", false, "A19PaisNombre", A19PaisNombre);
            A21ShowNombre = T00026_A21ShowNombre[0];
            AssignAttri("", false, "A21ShowNombre", A21ShowNombre);
            A23parqueAtraccionShowFechaHora = T00026_A23parqueAtraccionShowFechaHora[0];
            AssignAttri("", false, "A23parqueAtraccionShowFechaHora", context.localUtil.TToC( A23parqueAtraccionShowFechaHora, 8, 5, 0, 3, "/", ":", " "));
            A18PaisId = T00026_A18PaisId[0];
            AssignAttri("", false, "A18PaisId", StringUtil.LTrimStr( (decimal)(A18PaisId), 4, 0));
            A20ShowId = T00026_A20ShowId[0];
            AssignAttri("", false, "A20ShowId", StringUtil.LTrimStr( (decimal)(A20ShowId), 4, 0));
            A17parqueAtraccionFoto = T00026_A17parqueAtraccionFoto[0];
            AssignAttri("", false, "A17parqueAtraccionFoto", A17parqueAtraccionFoto);
            AssignProp("", false, imgparqueAtraccionFoto_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A17parqueAtraccionFoto)) ? A40000parqueAtraccionFoto_GXI : context.convertURL( context.PathToRelativeUrl( A17parqueAtraccionFoto))), true);
            AssignProp("", false, imgparqueAtraccionFoto_Internalname, "SrcSet", context.GetImageSrcSet( A17parqueAtraccionFoto), true);
            ZM022( -5) ;
         }
         pr_default.close(4);
         OnLoadActions022( ) ;
      }

      protected void OnLoadActions022( )
      {
      }

      protected void CheckExtendedTable022( )
      {
         Gx_BScreen = 1;
         AssignAttri("", false, "Gx_BScreen", StringUtil.Str( (decimal)(Gx_BScreen), 1, 0));
         standaloneModal( ) ;
         /* Using cursor T00024 */
         pr_default.execute(2, new Object[] {A18PaisId});
         if ( (pr_default.getStatus(2) == 101) )
         {
            GX_msglist.addItem("No existe 'Pais'.", "ForeignKeyNotFound", 1, "PAISID");
            AnyError = 1;
            GX_FocusControl = edtPaisId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A19PaisNombre = T00024_A19PaisNombre[0];
         AssignAttri("", false, "A19PaisNombre", A19PaisNombre);
         pr_default.close(2);
         /* Using cursor T00025 */
         pr_default.execute(3, new Object[] {A20ShowId});
         if ( (pr_default.getStatus(3) == 101) )
         {
            GX_msglist.addItem("No existe 'Show'.", "ForeignKeyNotFound", 1, "SHOWID");
            AnyError = 1;
            GX_FocusControl = edtShowId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A21ShowNombre = T00025_A21ShowNombre[0];
         AssignAttri("", false, "A21ShowNombre", A21ShowNombre);
         pr_default.close(3);
         if ( ! ( (DateTime.MinValue==A23parqueAtraccionShowFechaHora) || ( A23parqueAtraccionShowFechaHora >= context.localUtil.YMDHMSToT( 1753, 1, 1, 0, 0, 0) ) ) )
         {
            GX_msglist.addItem("Campo parque Atraccion Show Fecha Hora fuera de rango", "OutOfRange", 1, "PARQUEATRACCIONSHOWFECHAHORA");
            AnyError = 1;
            GX_FocusControl = edtparqueAtraccionShowFechaHora_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
      }

      protected void CloseExtendedTableCursors022( )
      {
         pr_default.close(2);
         pr_default.close(3);
      }

      protected void enableDisable( )
      {
      }

      protected void gxLoad_6( short A18PaisId )
      {
         /* Using cursor T00027 */
         pr_default.execute(5, new Object[] {A18PaisId});
         if ( (pr_default.getStatus(5) == 101) )
         {
            GX_msglist.addItem("No existe 'Pais'.", "ForeignKeyNotFound", 1, "PAISID");
            AnyError = 1;
            GX_FocusControl = edtPaisId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A19PaisNombre = T00027_A19PaisNombre[0];
         AssignAttri("", false, "A19PaisNombre", A19PaisNombre);
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( A19PaisNombre)+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(5) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(5);
      }

      protected void gxLoad_7( short A20ShowId )
      {
         /* Using cursor T00028 */
         pr_default.execute(6, new Object[] {A20ShowId});
         if ( (pr_default.getStatus(6) == 101) )
         {
            GX_msglist.addItem("No existe 'Show'.", "ForeignKeyNotFound", 1, "SHOWID");
            AnyError = 1;
            GX_FocusControl = edtShowId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A21ShowNombre = T00028_A21ShowNombre[0];
         AssignAttri("", false, "A21ShowNombre", A21ShowNombre);
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( A21ShowNombre)+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(6) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(6);
      }

      protected void GetKey022( )
      {
         /* Using cursor T00029 */
         pr_default.execute(7, new Object[] {A13parqueAtraccionId});
         if ( (pr_default.getStatus(7) != 101) )
         {
            RcdFound2 = 1;
         }
         else
         {
            RcdFound2 = 0;
         }
         pr_default.close(7);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor T00023 */
         pr_default.execute(1, new Object[] {A13parqueAtraccionId});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM022( 5) ;
            RcdFound2 = 1;
            A13parqueAtraccionId = T00023_A13parqueAtraccionId[0];
            AssignAttri("", false, "A13parqueAtraccionId", StringUtil.LTrimStr( (decimal)(A13parqueAtraccionId), 4, 0));
            A14parqueAtraccionNombre = T00023_A14parqueAtraccionNombre[0];
            AssignAttri("", false, "A14parqueAtraccionNombre", A14parqueAtraccionNombre);
            A15parqueAtraccionSitioWeb = T00023_A15parqueAtraccionSitioWeb[0];
            AssignAttri("", false, "A15parqueAtraccionSitioWeb", A15parqueAtraccionSitioWeb);
            A16parqueAtraccionDireccion = T00023_A16parqueAtraccionDireccion[0];
            AssignAttri("", false, "A16parqueAtraccionDireccion", A16parqueAtraccionDireccion);
            A40000parqueAtraccionFoto_GXI = T00023_A40000parqueAtraccionFoto_GXI[0];
            AssignProp("", false, imgparqueAtraccionFoto_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A17parqueAtraccionFoto)) ? A40000parqueAtraccionFoto_GXI : context.convertURL( context.PathToRelativeUrl( A17parqueAtraccionFoto))), true);
            AssignProp("", false, imgparqueAtraccionFoto_Internalname, "SrcSet", context.GetImageSrcSet( A17parqueAtraccionFoto), true);
            A23parqueAtraccionShowFechaHora = T00023_A23parqueAtraccionShowFechaHora[0];
            AssignAttri("", false, "A23parqueAtraccionShowFechaHora", context.localUtil.TToC( A23parqueAtraccionShowFechaHora, 8, 5, 0, 3, "/", ":", " "));
            A18PaisId = T00023_A18PaisId[0];
            AssignAttri("", false, "A18PaisId", StringUtil.LTrimStr( (decimal)(A18PaisId), 4, 0));
            A20ShowId = T00023_A20ShowId[0];
            AssignAttri("", false, "A20ShowId", StringUtil.LTrimStr( (decimal)(A20ShowId), 4, 0));
            A17parqueAtraccionFoto = T00023_A17parqueAtraccionFoto[0];
            AssignAttri("", false, "A17parqueAtraccionFoto", A17parqueAtraccionFoto);
            AssignProp("", false, imgparqueAtraccionFoto_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A17parqueAtraccionFoto)) ? A40000parqueAtraccionFoto_GXI : context.convertURL( context.PathToRelativeUrl( A17parqueAtraccionFoto))), true);
            AssignProp("", false, imgparqueAtraccionFoto_Internalname, "SrcSet", context.GetImageSrcSet( A17parqueAtraccionFoto), true);
            Z13parqueAtraccionId = A13parqueAtraccionId;
            sMode2 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Load022( ) ;
            if ( AnyError == 1 )
            {
               RcdFound2 = 0;
               InitializeNonKey022( ) ;
            }
            Gx_mode = sMode2;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound2 = 0;
            InitializeNonKey022( ) ;
            sMode2 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Gx_mode = sMode2;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey022( ) ;
         if ( RcdFound2 == 0 )
         {
            Gx_mode = "INS";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         getByPrimaryKey( ) ;
      }

      protected void move_next( )
      {
         RcdFound2 = 0;
         /* Using cursor T000210 */
         pr_default.execute(8, new Object[] {A13parqueAtraccionId});
         if ( (pr_default.getStatus(8) != 101) )
         {
            while ( (pr_default.getStatus(8) != 101) && ( ( T000210_A13parqueAtraccionId[0] < A13parqueAtraccionId ) ) )
            {
               pr_default.readNext(8);
            }
            if ( (pr_default.getStatus(8) != 101) && ( ( T000210_A13parqueAtraccionId[0] > A13parqueAtraccionId ) ) )
            {
               A13parqueAtraccionId = T000210_A13parqueAtraccionId[0];
               AssignAttri("", false, "A13parqueAtraccionId", StringUtil.LTrimStr( (decimal)(A13parqueAtraccionId), 4, 0));
               RcdFound2 = 1;
            }
         }
         pr_default.close(8);
      }

      protected void move_previous( )
      {
         RcdFound2 = 0;
         /* Using cursor T000211 */
         pr_default.execute(9, new Object[] {A13parqueAtraccionId});
         if ( (pr_default.getStatus(9) != 101) )
         {
            while ( (pr_default.getStatus(9) != 101) && ( ( T000211_A13parqueAtraccionId[0] > A13parqueAtraccionId ) ) )
            {
               pr_default.readNext(9);
            }
            if ( (pr_default.getStatus(9) != 101) && ( ( T000211_A13parqueAtraccionId[0] < A13parqueAtraccionId ) ) )
            {
               A13parqueAtraccionId = T000211_A13parqueAtraccionId[0];
               AssignAttri("", false, "A13parqueAtraccionId", StringUtil.LTrimStr( (decimal)(A13parqueAtraccionId), 4, 0));
               RcdFound2 = 1;
            }
         }
         pr_default.close(9);
      }

      protected void btn_enter( )
      {
         nKeyPressed = 1;
         GetKey022( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            GX_FocusControl = edtparqueAtraccionId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            Insert022( ) ;
            if ( AnyError == 1 )
            {
               GX_FocusControl = "";
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         else
         {
            if ( RcdFound2 == 1 )
            {
               if ( A13parqueAtraccionId != Z13parqueAtraccionId )
               {
                  A13parqueAtraccionId = Z13parqueAtraccionId;
                  AssignAttri("", false, "A13parqueAtraccionId", StringUtil.LTrimStr( (decimal)(A13parqueAtraccionId), 4, 0));
                  GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "CandidateKeyNotFound", 1, "PARQUEATRACCIONID");
                  AnyError = 1;
                  GX_FocusControl = edtparqueAtraccionId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else if ( IsDlt( ) )
               {
                  delete( ) ;
                  AfterTrn( ) ;
                  GX_FocusControl = edtparqueAtraccionId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else
               {
                  Gx_mode = "UPD";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  /* Update record */
                  Update022( ) ;
                  GX_FocusControl = edtparqueAtraccionId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
            }
            else
            {
               if ( A13parqueAtraccionId != Z13parqueAtraccionId )
               {
                  Gx_mode = "INS";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  /* Insert record */
                  GX_FocusControl = edtparqueAtraccionId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  Insert022( ) ;
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
                     GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "PARQUEATRACCIONID");
                     AnyError = 1;
                     GX_FocusControl = edtparqueAtraccionId_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
                  else
                  {
                     Gx_mode = "INS";
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                     /* Insert record */
                     GX_FocusControl = edtparqueAtraccionId_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     Insert022( ) ;
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
      }

      protected void btn_delete( )
      {
         if ( A13parqueAtraccionId != Z13parqueAtraccionId )
         {
            A13parqueAtraccionId = Z13parqueAtraccionId;
            AssignAttri("", false, "A13parqueAtraccionId", StringUtil.LTrimStr( (decimal)(A13parqueAtraccionId), 4, 0));
            GX_msglist.addItem(context.GetMessage( "GXM_getbeforedlt", ""), 1, "PARQUEATRACCIONID");
            AnyError = 1;
            GX_FocusControl = edtparqueAtraccionId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         else
         {
            delete( ) ;
            AfterTrn( ) ;
            GX_FocusControl = edtparqueAtraccionId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( AnyError != 0 )
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            getByPrimaryKey( ) ;
         }
         CloseCursors();
      }

      protected void btn_get( )
      {
         nKeyPressed = 2;
         IsConfirmed = 0;
         AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         getEqualNoModal( ) ;
         if ( RcdFound2 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "PARQUEATRACCIONID");
            AnyError = 1;
            GX_FocusControl = edtparqueAtraccionId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         GX_FocusControl = edtparqueAtraccionNombre_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_first( )
      {
         nKeyPressed = 2;
         IsConfirmed = 0;
         AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         ScanStart022( ) ;
         if ( RcdFound2 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtparqueAtraccionNombre_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         ScanEnd022( ) ;
         getByPrimaryKey( ) ;
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_previous( )
      {
         nKeyPressed = 2;
         IsConfirmed = 0;
         AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         move_previous( ) ;
         if ( RcdFound2 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtparqueAtraccionNombre_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         getByPrimaryKey( ) ;
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_next( )
      {
         nKeyPressed = 2;
         IsConfirmed = 0;
         AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         move_next( ) ;
         if ( RcdFound2 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtparqueAtraccionNombre_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         getByPrimaryKey( ) ;
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_last( )
      {
         nKeyPressed = 2;
         IsConfirmed = 0;
         AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         ScanStart022( ) ;
         if ( RcdFound2 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            while ( RcdFound2 != 0 )
            {
               ScanNext022( ) ;
            }
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtparqueAtraccionNombre_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         ScanEnd022( ) ;
         getByPrimaryKey( ) ;
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_select( )
      {
         getEqualNoModal( ) ;
      }

      protected void CheckOptimisticConcurrency022( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T00022 */
            pr_default.execute(0, new Object[] {A13parqueAtraccionId});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"parqueAtraccion"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            Gx_longc = false;
            if ( (pr_default.getStatus(0) == 101) || ( StringUtil.StrCmp(Z14parqueAtraccionNombre, T00022_A14parqueAtraccionNombre[0]) != 0 ) || ( StringUtil.StrCmp(Z15parqueAtraccionSitioWeb, T00022_A15parqueAtraccionSitioWeb[0]) != 0 ) || ( StringUtil.StrCmp(Z16parqueAtraccionDireccion, T00022_A16parqueAtraccionDireccion[0]) != 0 ) || ( Z23parqueAtraccionShowFechaHora != T00022_A23parqueAtraccionShowFechaHora[0] ) || ( Z18PaisId != T00022_A18PaisId[0] ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( Z20ShowId != T00022_A20ShowId[0] ) )
            {
               if ( StringUtil.StrCmp(Z14parqueAtraccionNombre, T00022_A14parqueAtraccionNombre[0]) != 0 )
               {
                  GXUtil.WriteLog("parqueatraccion:[seudo value changed for attri]"+"parqueAtraccionNombre");
                  GXUtil.WriteLogRaw("Old: ",Z14parqueAtraccionNombre);
                  GXUtil.WriteLogRaw("Current: ",T00022_A14parqueAtraccionNombre[0]);
               }
               if ( StringUtil.StrCmp(Z15parqueAtraccionSitioWeb, T00022_A15parqueAtraccionSitioWeb[0]) != 0 )
               {
                  GXUtil.WriteLog("parqueatraccion:[seudo value changed for attri]"+"parqueAtraccionSitioWeb");
                  GXUtil.WriteLogRaw("Old: ",Z15parqueAtraccionSitioWeb);
                  GXUtil.WriteLogRaw("Current: ",T00022_A15parqueAtraccionSitioWeb[0]);
               }
               if ( StringUtil.StrCmp(Z16parqueAtraccionDireccion, T00022_A16parqueAtraccionDireccion[0]) != 0 )
               {
                  GXUtil.WriteLog("parqueatraccion:[seudo value changed for attri]"+"parqueAtraccionDireccion");
                  GXUtil.WriteLogRaw("Old: ",Z16parqueAtraccionDireccion);
                  GXUtil.WriteLogRaw("Current: ",T00022_A16parqueAtraccionDireccion[0]);
               }
               if ( Z23parqueAtraccionShowFechaHora != T00022_A23parqueAtraccionShowFechaHora[0] )
               {
                  GXUtil.WriteLog("parqueatraccion:[seudo value changed for attri]"+"parqueAtraccionShowFechaHora");
                  GXUtil.WriteLogRaw("Old: ",Z23parqueAtraccionShowFechaHora);
                  GXUtil.WriteLogRaw("Current: ",T00022_A23parqueAtraccionShowFechaHora[0]);
               }
               if ( Z18PaisId != T00022_A18PaisId[0] )
               {
                  GXUtil.WriteLog("parqueatraccion:[seudo value changed for attri]"+"PaisId");
                  GXUtil.WriteLogRaw("Old: ",Z18PaisId);
                  GXUtil.WriteLogRaw("Current: ",T00022_A18PaisId[0]);
               }
               if ( Z20ShowId != T00022_A20ShowId[0] )
               {
                  GXUtil.WriteLog("parqueatraccion:[seudo value changed for attri]"+"ShowId");
                  GXUtil.WriteLogRaw("Old: ",Z20ShowId);
                  GXUtil.WriteLogRaw("Current: ",T00022_A20ShowId[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"parqueAtraccion"}), "RecordWasChanged", 1, "");
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
                     /* Using cursor T000212 */
                     pr_default.execute(10, new Object[] {A14parqueAtraccionNombre, A15parqueAtraccionSitioWeb, A16parqueAtraccionDireccion, A17parqueAtraccionFoto, A40000parqueAtraccionFoto_GXI, A23parqueAtraccionShowFechaHora, A18PaisId, A20ShowId});
                     A13parqueAtraccionId = T000212_A13parqueAtraccionId[0];
                     AssignAttri("", false, "A13parqueAtraccionId", StringUtil.LTrimStr( (decimal)(A13parqueAtraccionId), 4, 0));
                     pr_default.close(10);
                     pr_default.SmartCacheProvider.SetUpdated("parqueAtraccion");
                     if ( AnyError == 0 )
                     {
                        /* Start of After( Insert) rules */
                        /* End of After( Insert) rules */
                        if ( AnyError == 0 )
                        {
                           /* Save values for previous() function. */
                           endTrnMsgTxt = context.GetMessage( "GXM_sucadded", "");
                           endTrnMsgCod = "SuccessfullyAdded";
                           ResetCaption020( ) ;
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
                     /* Using cursor T000213 */
                     pr_default.execute(11, new Object[] {A14parqueAtraccionNombre, A15parqueAtraccionSitioWeb, A16parqueAtraccionDireccion, A23parqueAtraccionShowFechaHora, A18PaisId, A20ShowId, A13parqueAtraccionId});
                     pr_default.close(11);
                     pr_default.SmartCacheProvider.SetUpdated("parqueAtraccion");
                     if ( (pr_default.getStatus(11) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"parqueAtraccion"}), "RecordIsLocked", 1, "");
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
                           ResetCaption020( ) ;
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
         if ( AnyError == 0 )
         {
            /* Using cursor T000214 */
            pr_default.execute(12, new Object[] {A17parqueAtraccionFoto, A40000parqueAtraccionFoto_GXI, A13parqueAtraccionId});
            pr_default.close(12);
            pr_default.SmartCacheProvider.SetUpdated("parqueAtraccion");
         }
      }

      protected void delete( )
      {
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
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
                  /* Using cursor T000215 */
                  pr_default.execute(13, new Object[] {A13parqueAtraccionId});
                  pr_default.close(13);
                  pr_default.SmartCacheProvider.SetUpdated("parqueAtraccion");
                  if ( AnyError == 0 )
                  {
                     /* Start of After( delete) rules */
                     /* End of After( delete) rules */
                     if ( AnyError == 0 )
                     {
                        move_next( ) ;
                        if ( RcdFound2 == 0 )
                        {
                           InitAll022( ) ;
                           Gx_mode = "INS";
                           AssignAttri("", false, "Gx_mode", Gx_mode);
                        }
                        else
                        {
                           getByPrimaryKey( ) ;
                           Gx_mode = "UPD";
                           AssignAttri("", false, "Gx_mode", Gx_mode);
                        }
                        endTrnMsgTxt = context.GetMessage( "GXM_sucdeleted", "");
                        endTrnMsgCod = "SuccessfullyDeleted";
                        ResetCaption020( ) ;
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
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel022( ) ;
         Gx_mode = sMode2;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls022( )
      {
         standaloneModal( ) ;
         if ( AnyError == 0 )
         {
            /* Delete mode formulas */
            /* Using cursor T000216 */
            pr_default.execute(14, new Object[] {A18PaisId});
            A19PaisNombre = T000216_A19PaisNombre[0];
            AssignAttri("", false, "A19PaisNombre", A19PaisNombre);
            pr_default.close(14);
            /* Using cursor T000217 */
            pr_default.execute(15, new Object[] {A20ShowId});
            A21ShowNombre = T000217_A21ShowNombre[0];
            AssignAttri("", false, "A21ShowNombre", A21ShowNombre);
            pr_default.close(15);
         }
         if ( AnyError == 0 )
         {
            /* Using cursor T000218 */
            pr_default.execute(16, new Object[] {A13parqueAtraccionId});
            if ( (pr_default.getStatus(16) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Juego"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(16);
            /* Using cursor T000219 */
            pr_default.execute(17, new Object[] {A13parqueAtraccionId});
            if ( (pr_default.getStatus(17) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Empleado"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(17);
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
            pr_default.close(1);
            pr_default.close(14);
            pr_default.close(15);
            context.CommitDataStores("parqueatraccion",pr_default);
            if ( AnyError == 0 )
            {
               ConfirmValues020( ) ;
            }
            /* After transaction rules */
            /* Execute 'After Trn' event if defined. */
            trnEnded = 1;
         }
         else
         {
            pr_default.close(1);
            pr_default.close(14);
            pr_default.close(15);
            context.RollbackDataStores("parqueatraccion",pr_default);
         }
         IsModified = 0;
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanStart022( )
      {
         /* Using cursor T000220 */
         pr_default.execute(18);
         RcdFound2 = 0;
         if ( (pr_default.getStatus(18) != 101) )
         {
            RcdFound2 = 1;
            A13parqueAtraccionId = T000220_A13parqueAtraccionId[0];
            AssignAttri("", false, "A13parqueAtraccionId", StringUtil.LTrimStr( (decimal)(A13parqueAtraccionId), 4, 0));
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext022( )
      {
         /* Scan next routine */
         pr_default.readNext(18);
         RcdFound2 = 0;
         if ( (pr_default.getStatus(18) != 101) )
         {
            RcdFound2 = 1;
            A13parqueAtraccionId = T000220_A13parqueAtraccionId[0];
            AssignAttri("", false, "A13parqueAtraccionId", StringUtil.LTrimStr( (decimal)(A13parqueAtraccionId), 4, 0));
         }
      }

      protected void ScanEnd022( )
      {
         pr_default.close(18);
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
         edtparqueAtraccionId_Enabled = 0;
         AssignProp("", false, edtparqueAtraccionId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtparqueAtraccionId_Enabled), 5, 0), true);
         edtparqueAtraccionNombre_Enabled = 0;
         AssignProp("", false, edtparqueAtraccionNombre_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtparqueAtraccionNombre_Enabled), 5, 0), true);
         edtparqueAtraccionSitioWeb_Enabled = 0;
         AssignProp("", false, edtparqueAtraccionSitioWeb_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtparqueAtraccionSitioWeb_Enabled), 5, 0), true);
         edtparqueAtraccionDireccion_Enabled = 0;
         AssignProp("", false, edtparqueAtraccionDireccion_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtparqueAtraccionDireccion_Enabled), 5, 0), true);
         imgparqueAtraccionFoto_Enabled = 0;
         AssignProp("", false, imgparqueAtraccionFoto_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(imgparqueAtraccionFoto_Enabled), 5, 0), true);
         edtPaisId_Enabled = 0;
         AssignProp("", false, edtPaisId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtPaisId_Enabled), 5, 0), true);
         edtPaisNombre_Enabled = 0;
         AssignProp("", false, edtPaisNombre_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtPaisNombre_Enabled), 5, 0), true);
         edtShowId_Enabled = 0;
         AssignProp("", false, edtShowId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtShowId_Enabled), 5, 0), true);
         edtShowNombre_Enabled = 0;
         AssignProp("", false, edtShowNombre_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtShowNombre_Enabled), 5, 0), true);
         edtparqueAtraccionShowFechaHora_Enabled = 0;
         AssignProp("", false, edtparqueAtraccionShowFechaHora_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtparqueAtraccionShowFechaHora_Enabled), 5, 0), true);
      }

      protected void send_integrity_lvl_hashes022( )
      {
      }

      protected void assign_properties_default( )
      {
      }

      protected void ConfirmValues020( )
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("parqueatraccion.aspx") +"\">") ;
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
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "Z13parqueAtraccionId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z13parqueAtraccionId), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "Z14parqueAtraccionNombre", Z14parqueAtraccionNombre);
         GxWebStd.gx_hidden_field( context, "Z15parqueAtraccionSitioWeb", Z15parqueAtraccionSitioWeb);
         GxWebStd.gx_hidden_field( context, "Z16parqueAtraccionDireccion", Z16parqueAtraccionDireccion);
         GxWebStd.gx_hidden_field( context, "Z23parqueAtraccionShowFechaHora", context.localUtil.TToC( Z23parqueAtraccionShowFechaHora, 10, 8, 0, 0, "/", ":", " "));
         GxWebStd.gx_hidden_field( context, "Z18PaisId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z18PaisId), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "Z20ShowId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z20ShowId), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "IsConfirmed", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsConfirmed), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "IsModified", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsModified), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "Mode", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "vGXBSCREEN", StringUtil.LTrim( StringUtil.NToC( (decimal)(Gx_BScreen), 1, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "PARQUEATRACCIONFOTO_GXI", A40000parqueAtraccionFoto_GXI);
         GXCCtlgxBlob = "PARQUEATRACCIONFOTO" + "_gxBlob";
         GxWebStd.gx_hidden_field( context, GXCCtlgxBlob, A17parqueAtraccionFoto);
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
         return formatLink("parqueatraccion.aspx")  ;
      }

      public override string GetPgmname( )
      {
         return "parqueAtraccion" ;
      }

      public override string GetPgmdesc( )
      {
         return "parque Atraccion" ;
      }

      protected void InitializeNonKey022( )
      {
         A14parqueAtraccionNombre = "";
         AssignAttri("", false, "A14parqueAtraccionNombre", A14parqueAtraccionNombre);
         A15parqueAtraccionSitioWeb = "";
         AssignAttri("", false, "A15parqueAtraccionSitioWeb", A15parqueAtraccionSitioWeb);
         A16parqueAtraccionDireccion = "";
         AssignAttri("", false, "A16parqueAtraccionDireccion", A16parqueAtraccionDireccion);
         A17parqueAtraccionFoto = "";
         AssignAttri("", false, "A17parqueAtraccionFoto", A17parqueAtraccionFoto);
         AssignProp("", false, imgparqueAtraccionFoto_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A17parqueAtraccionFoto)) ? A40000parqueAtraccionFoto_GXI : context.convertURL( context.PathToRelativeUrl( A17parqueAtraccionFoto))), true);
         AssignProp("", false, imgparqueAtraccionFoto_Internalname, "SrcSet", context.GetImageSrcSet( A17parqueAtraccionFoto), true);
         A40000parqueAtraccionFoto_GXI = "";
         AssignProp("", false, imgparqueAtraccionFoto_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A17parqueAtraccionFoto)) ? A40000parqueAtraccionFoto_GXI : context.convertURL( context.PathToRelativeUrl( A17parqueAtraccionFoto))), true);
         AssignProp("", false, imgparqueAtraccionFoto_Internalname, "SrcSet", context.GetImageSrcSet( A17parqueAtraccionFoto), true);
         A19PaisNombre = "";
         AssignAttri("", false, "A19PaisNombre", A19PaisNombre);
         A21ShowNombre = "";
         AssignAttri("", false, "A21ShowNombre", A21ShowNombre);
         A23parqueAtraccionShowFechaHora = (DateTime)(DateTime.MinValue);
         AssignAttri("", false, "A23parqueAtraccionShowFechaHora", context.localUtil.TToC( A23parqueAtraccionShowFechaHora, 8, 5, 0, 3, "/", ":", " "));
         A18PaisId = 1;
         AssignAttri("", false, "A18PaisId", StringUtil.LTrimStr( (decimal)(A18PaisId), 4, 0));
         A20ShowId = 1;
         AssignAttri("", false, "A20ShowId", StringUtil.LTrimStr( (decimal)(A20ShowId), 4, 0));
         Z14parqueAtraccionNombre = "";
         Z15parqueAtraccionSitioWeb = "";
         Z16parqueAtraccionDireccion = "";
         Z23parqueAtraccionShowFechaHora = (DateTime)(DateTime.MinValue);
         Z18PaisId = 0;
         Z20ShowId = 0;
      }

      protected void InitAll022( )
      {
         A13parqueAtraccionId = 1;
         AssignAttri("", false, "A13parqueAtraccionId", StringUtil.LTrimStr( (decimal)(A13parqueAtraccionId), 4, 0));
         InitializeNonKey022( ) ;
      }

      protected void StandaloneModalInsert( )
      {
         A20ShowId = i20ShowId;
         AssignAttri("", false, "A20ShowId", StringUtil.LTrimStr( (decimal)(A20ShowId), 4, 0));
         A18PaisId = i18PaisId;
         AssignAttri("", false, "A18PaisId", StringUtil.LTrimStr( (decimal)(A18PaisId), 4, 0));
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?20254122151351", true, true);
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
         context.AddJavascriptSource("parqueatraccion.js", "?20254122151351", false, true);
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
         edtparqueAtraccionId_Internalname = "PARQUEATRACCIONID";
         edtparqueAtraccionNombre_Internalname = "PARQUEATRACCIONNOMBRE";
         edtparqueAtraccionSitioWeb_Internalname = "PARQUEATRACCIONSITIOWEB";
         edtparqueAtraccionDireccion_Internalname = "PARQUEATRACCIONDIRECCION";
         imgparqueAtraccionFoto_Internalname = "PARQUEATRACCIONFOTO";
         edtPaisId_Internalname = "PAISID";
         edtPaisNombre_Internalname = "PAISNOMBRE";
         edtShowId_Internalname = "SHOWID";
         edtShowNombre_Internalname = "SHOWNOMBRE";
         edtparqueAtraccionShowFechaHora_Internalname = "PARQUEATRACCIONSHOWFECHAHORA";
         divFormcontainer_Internalname = "FORMCONTAINER";
         bttBtn_enter_Internalname = "BTN_ENTER";
         bttBtn_cancel_Internalname = "BTN_CANCEL";
         bttBtn_delete_Internalname = "BTN_DELETE";
         divMaintable_Internalname = "MAINTABLE";
         Form.Internalname = "FORM";
         imgprompt_18_Internalname = "PROMPT_18";
         imgprompt_20_Internalname = "PROMPT_20";
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
         Form.Caption = "parque Atraccion";
         bttBtn_delete_Enabled = 1;
         bttBtn_delete_Visible = 1;
         bttBtn_cancel_Visible = 1;
         bttBtn_enter_Enabled = 1;
         bttBtn_enter_Visible = 1;
         edtparqueAtraccionShowFechaHora_Jsonclick = "";
         edtparqueAtraccionShowFechaHora_Enabled = 1;
         edtShowNombre_Jsonclick = "";
         edtShowNombre_Enabled = 0;
         imgprompt_20_Visible = 1;
         imgprompt_20_Link = "";
         edtShowId_Jsonclick = "";
         edtShowId_Enabled = 1;
         edtPaisNombre_Jsonclick = "";
         edtPaisNombre_Enabled = 0;
         imgprompt_18_Visible = 1;
         imgprompt_18_Link = "";
         edtPaisId_Jsonclick = "";
         edtPaisId_Enabled = 1;
         imgparqueAtraccionFoto_Enabled = 1;
         edtparqueAtraccionDireccion_Enabled = 1;
         edtparqueAtraccionSitioWeb_Jsonclick = "";
         edtparqueAtraccionSitioWeb_Enabled = 1;
         edtparqueAtraccionNombre_Jsonclick = "";
         edtparqueAtraccionNombre_Enabled = 1;
         edtparqueAtraccionId_Jsonclick = "";
         edtparqueAtraccionId_Enabled = 1;
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

      protected void AfterKeyLoadScreen( )
      {
         IsConfirmed = 0;
         AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         getEqualNoModal( ) ;
         GX_FocusControl = edtparqueAtraccionNombre_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         standaloneNotModal( ) ;
         standaloneModal( ) ;
         /* End function AfterKeyLoadScreen */
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
         context.wbHandled = 1;
         AfterKeyLoadScreen( ) ;
         Draw( ) ;
         send_integrity_footer_hashes( ) ;
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "A14parqueAtraccionNombre", A14parqueAtraccionNombre);
         AssignAttri("", false, "A15parqueAtraccionSitioWeb", A15parqueAtraccionSitioWeb);
         AssignAttri("", false, "A16parqueAtraccionDireccion", A16parqueAtraccionDireccion);
         AssignAttri("", false, "A17parqueAtraccionFoto", context.PathToRelativeUrl( A17parqueAtraccionFoto));
         GXCCtlgxBlob = "PARQUEATRACCIONFOTO" + "_gxBlob";
         AssignAttri("", false, "GXCCtlgxBlob", GXCCtlgxBlob);
         GxWebStd.gx_hidden_field( context, GXCCtlgxBlob, context.PathToRelativeUrl( A17parqueAtraccionFoto));
         AssignAttri("", false, "A40000parqueAtraccionFoto_GXI", A40000parqueAtraccionFoto_GXI);
         AssignAttri("", false, "A18PaisId", StringUtil.LTrim( StringUtil.NToC( (decimal)(A18PaisId), 4, 0, ".", "")));
         AssignAttri("", false, "A20ShowId", StringUtil.LTrim( StringUtil.NToC( (decimal)(A20ShowId), 4, 0, ".", "")));
         AssignAttri("", false, "A23parqueAtraccionShowFechaHora", context.localUtil.TToC( A23parqueAtraccionShowFechaHora, 10, 8, 0, 3, "/", ":", " "));
         AssignAttri("", false, "A19PaisNombre", A19PaisNombre);
         AssignAttri("", false, "A21ShowNombre", A21ShowNombre);
         AssignAttri("", false, "Gx_mode", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "Z13parqueAtraccionId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z13parqueAtraccionId), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z14parqueAtraccionNombre", Z14parqueAtraccionNombre);
         GxWebStd.gx_hidden_field( context, "Z15parqueAtraccionSitioWeb", Z15parqueAtraccionSitioWeb);
         GxWebStd.gx_hidden_field( context, "Z16parqueAtraccionDireccion", Z16parqueAtraccionDireccion);
         GxWebStd.gx_hidden_field( context, "Z17parqueAtraccionFoto", context.PathToRelativeUrl( Z17parqueAtraccionFoto));
         GxWebStd.gx_hidden_field( context, "Z40000parqueAtraccionFoto_GXI", Z40000parqueAtraccionFoto_GXI);
         GxWebStd.gx_hidden_field( context, "Z18PaisId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z18PaisId), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z20ShowId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z20ShowId), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z23parqueAtraccionShowFechaHora", context.localUtil.TToC( Z23parqueAtraccionShowFechaHora, 10, 8, 0, 3, "/", ":", " "));
         GxWebStd.gx_hidden_field( context, "Z19PaisNombre", Z19PaisNombre);
         GxWebStd.gx_hidden_field( context, "Z21ShowNombre", Z21ShowNombre);
         AssignProp("", false, bttBtn_delete_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_delete_Enabled), 5, 0), true);
         AssignProp("", false, bttBtn_enter_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_enter_Enabled), 5, 0), true);
         SendCloseFormHiddens( ) ;
      }

      public void Valid_Paisid( )
      {
         /* Using cursor T000216 */
         pr_default.execute(14, new Object[] {A18PaisId});
         if ( (pr_default.getStatus(14) == 101) )
         {
            GX_msglist.addItem("No existe 'Pais'.", "ForeignKeyNotFound", 1, "PAISID");
            AnyError = 1;
            GX_FocusControl = edtPaisId_Internalname;
         }
         A19PaisNombre = T000216_A19PaisNombre[0];
         pr_default.close(14);
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "A19PaisNombre", A19PaisNombre);
      }

      public void Valid_Showid( )
      {
         /* Using cursor T000217 */
         pr_default.execute(15, new Object[] {A20ShowId});
         if ( (pr_default.getStatus(15) == 101) )
         {
            GX_msglist.addItem("No existe 'Show'.", "ForeignKeyNotFound", 1, "SHOWID");
            AnyError = 1;
            GX_FocusControl = edtShowId_Internalname;
         }
         A21ShowNombre = T000217_A21ShowNombre[0];
         pr_default.close(15);
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "A21ShowNombre", A21ShowNombre);
      }

      public override bool SupportAjaxEvent( )
      {
         return true ;
      }

      public override void InitializeDynEvents( )
      {
         setEventMetadata("ENTER","""{"handler":"UserMainFullajax","iparms":[{"postForm":true}]}""");
         setEventMetadata("REFRESH","""{"handler":"Refresh","iparms":[]}""");
         setEventMetadata("VALID_PARQUEATRACCIONID","""{"handler":"Valid_Parqueatraccionid","iparms":[{"av":"A13parqueAtraccionId","fld":"PARQUEATRACCIONID","pic":"ZZZ9"},{"av":"Gx_BScreen","fld":"vGXBSCREEN","pic":"9"},{"av":"Gx_mode","fld":"vMODE","pic":"@!"},{"av":"A20ShowId","fld":"SHOWID","pic":"ZZZ9"},{"av":"A18PaisId","fld":"PAISID","pic":"ZZZ9"}]""");
         setEventMetadata("VALID_PARQUEATRACCIONID",""","oparms":[{"av":"A14parqueAtraccionNombre","fld":"PARQUEATRACCIONNOMBRE"},{"av":"A15parqueAtraccionSitioWeb","fld":"PARQUEATRACCIONSITIOWEB"},{"av":"A16parqueAtraccionDireccion","fld":"PARQUEATRACCIONDIRECCION"},{"av":"A17parqueAtraccionFoto","fld":"PARQUEATRACCIONFOTO"},{"av":"A40000parqueAtraccionFoto_GXI","fld":"PARQUEATRACCIONFOTO_GXI"},{"av":"A18PaisId","fld":"PAISID","pic":"ZZZ9"},{"av":"A20ShowId","fld":"SHOWID","pic":"ZZZ9"},{"av":"A23parqueAtraccionShowFechaHora","fld":"PARQUEATRACCIONSHOWFECHAHORA","pic":"99/99/99 99:99"},{"av":"A19PaisNombre","fld":"PAISNOMBRE"},{"av":"A21ShowNombre","fld":"SHOWNOMBRE"},{"av":"Gx_mode","fld":"vMODE","pic":"@!"},{"av":"Z13parqueAtraccionId"},{"av":"Z14parqueAtraccionNombre"},{"av":"Z15parqueAtraccionSitioWeb"},{"av":"Z16parqueAtraccionDireccion"},{"av":"Z17parqueAtraccionFoto"},{"av":"Z40000parqueAtraccionFoto_GXI"},{"av":"Z18PaisId"},{"av":"Z20ShowId"},{"av":"Z23parqueAtraccionShowFechaHora"},{"av":"Z19PaisNombre"},{"av":"Z21ShowNombre"},{"ctrl":"BTN_DELETE","prop":"Enabled"},{"ctrl":"BTN_ENTER","prop":"Enabled"}]}""");
         setEventMetadata("VALID_PAISID","""{"handler":"Valid_Paisid","iparms":[{"av":"A18PaisId","fld":"PAISID","pic":"ZZZ9"},{"av":"A19PaisNombre","fld":"PAISNOMBRE"}]""");
         setEventMetadata("VALID_PAISID",""","oparms":[{"av":"A19PaisNombre","fld":"PAISNOMBRE"}]}""");
         setEventMetadata("VALID_SHOWID","""{"handler":"Valid_Showid","iparms":[{"av":"A20ShowId","fld":"SHOWID","pic":"ZZZ9"},{"av":"A21ShowNombre","fld":"SHOWNOMBRE"}]""");
         setEventMetadata("VALID_SHOWID",""","oparms":[{"av":"A21ShowNombre","fld":"SHOWNOMBRE"}]}""");
         setEventMetadata("VALID_PARQUEATRACCIONSHOWFECHAHORA","""{"handler":"Valid_Parqueatraccionshowfechahora","iparms":[]}""");
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
         pr_default.close(14);
         pr_default.close(15);
      }

      public override void initialize( )
      {
         sPrefix = "";
         Z14parqueAtraccionNombre = "";
         Z15parqueAtraccionSitioWeb = "";
         Z16parqueAtraccionDireccion = "";
         Z23parqueAtraccionShowFechaHora = (DateTime)(DateTime.MinValue);
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
         A14parqueAtraccionNombre = "";
         A15parqueAtraccionSitioWeb = "";
         A16parqueAtraccionDireccion = "";
         A17parqueAtraccionFoto = "";
         A40000parqueAtraccionFoto_GXI = "";
         sImgUrl = "";
         imgprompt_18_gximage = "";
         A19PaisNombre = "";
         imgprompt_20_gximage = "";
         A21ShowNombre = "";
         A23parqueAtraccionShowFechaHora = (DateTime)(DateTime.MinValue);
         bttBtn_enter_Jsonclick = "";
         bttBtn_cancel_Jsonclick = "";
         bttBtn_delete_Jsonclick = "";
         Gx_mode = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         endTrnMsgTxt = "";
         endTrnMsgCod = "";
         Z17parqueAtraccionFoto = "";
         Z40000parqueAtraccionFoto_GXI = "";
         Z19PaisNombre = "";
         Z21ShowNombre = "";
         T00025_A21ShowNombre = new string[] {""} ;
         T00024_A19PaisNombre = new string[] {""} ;
         T00026_A13parqueAtraccionId = new short[1] ;
         T00026_A14parqueAtraccionNombre = new string[] {""} ;
         T00026_A15parqueAtraccionSitioWeb = new string[] {""} ;
         T00026_A16parqueAtraccionDireccion = new string[] {""} ;
         T00026_A40000parqueAtraccionFoto_GXI = new string[] {""} ;
         T00026_A19PaisNombre = new string[] {""} ;
         T00026_A21ShowNombre = new string[] {""} ;
         T00026_A23parqueAtraccionShowFechaHora = new DateTime[] {DateTime.MinValue} ;
         T00026_A18PaisId = new short[1] ;
         T00026_A20ShowId = new short[1] ;
         T00026_A17parqueAtraccionFoto = new string[] {""} ;
         T00027_A19PaisNombre = new string[] {""} ;
         T00028_A21ShowNombre = new string[] {""} ;
         T00029_A13parqueAtraccionId = new short[1] ;
         T00023_A13parqueAtraccionId = new short[1] ;
         T00023_A14parqueAtraccionNombre = new string[] {""} ;
         T00023_A15parqueAtraccionSitioWeb = new string[] {""} ;
         T00023_A16parqueAtraccionDireccion = new string[] {""} ;
         T00023_A40000parqueAtraccionFoto_GXI = new string[] {""} ;
         T00023_A23parqueAtraccionShowFechaHora = new DateTime[] {DateTime.MinValue} ;
         T00023_A18PaisId = new short[1] ;
         T00023_A20ShowId = new short[1] ;
         T00023_A17parqueAtraccionFoto = new string[] {""} ;
         sMode2 = "";
         T000210_A13parqueAtraccionId = new short[1] ;
         T000211_A13parqueAtraccionId = new short[1] ;
         T00022_A13parqueAtraccionId = new short[1] ;
         T00022_A14parqueAtraccionNombre = new string[] {""} ;
         T00022_A15parqueAtraccionSitioWeb = new string[] {""} ;
         T00022_A16parqueAtraccionDireccion = new string[] {""} ;
         T00022_A40000parqueAtraccionFoto_GXI = new string[] {""} ;
         T00022_A23parqueAtraccionShowFechaHora = new DateTime[] {DateTime.MinValue} ;
         T00022_A18PaisId = new short[1] ;
         T00022_A20ShowId = new short[1] ;
         T00022_A17parqueAtraccionFoto = new string[] {""} ;
         T000212_A13parqueAtraccionId = new short[1] ;
         T000216_A19PaisNombre = new string[] {""} ;
         T000217_A21ShowNombre = new string[] {""} ;
         T000218_A24JuegoId = new short[1] ;
         T000219_A1EmpleadoId = new short[1] ;
         T000220_A13parqueAtraccionId = new short[1] ;
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXCCtlgxBlob = "";
         ZZ14parqueAtraccionNombre = "";
         ZZ15parqueAtraccionSitioWeb = "";
         ZZ16parqueAtraccionDireccion = "";
         ZZ17parqueAtraccionFoto = "";
         ZZ40000parqueAtraccionFoto_GXI = "";
         ZZ23parqueAtraccionShowFechaHora = (DateTime)(DateTime.MinValue);
         ZZ19PaisNombre = "";
         ZZ21ShowNombre = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.parqueatraccion__default(),
            new Object[][] {
                new Object[] {
               T00022_A13parqueAtraccionId, T00022_A14parqueAtraccionNombre, T00022_A15parqueAtraccionSitioWeb, T00022_A16parqueAtraccionDireccion, T00022_A40000parqueAtraccionFoto_GXI, T00022_A23parqueAtraccionShowFechaHora, T00022_A18PaisId, T00022_A20ShowId, T00022_A17parqueAtraccionFoto
               }
               , new Object[] {
               T00023_A13parqueAtraccionId, T00023_A14parqueAtraccionNombre, T00023_A15parqueAtraccionSitioWeb, T00023_A16parqueAtraccionDireccion, T00023_A40000parqueAtraccionFoto_GXI, T00023_A23parqueAtraccionShowFechaHora, T00023_A18PaisId, T00023_A20ShowId, T00023_A17parqueAtraccionFoto
               }
               , new Object[] {
               T00024_A19PaisNombre
               }
               , new Object[] {
               T00025_A21ShowNombre
               }
               , new Object[] {
               T00026_A13parqueAtraccionId, T00026_A14parqueAtraccionNombre, T00026_A15parqueAtraccionSitioWeb, T00026_A16parqueAtraccionDireccion, T00026_A40000parqueAtraccionFoto_GXI, T00026_A19PaisNombre, T00026_A21ShowNombre, T00026_A23parqueAtraccionShowFechaHora, T00026_A18PaisId, T00026_A20ShowId,
               T00026_A17parqueAtraccionFoto
               }
               , new Object[] {
               T00027_A19PaisNombre
               }
               , new Object[] {
               T00028_A21ShowNombre
               }
               , new Object[] {
               T00029_A13parqueAtraccionId
               }
               , new Object[] {
               T000210_A13parqueAtraccionId
               }
               , new Object[] {
               T000211_A13parqueAtraccionId
               }
               , new Object[] {
               T000212_A13parqueAtraccionId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T000216_A19PaisNombre
               }
               , new Object[] {
               T000217_A21ShowNombre
               }
               , new Object[] {
               T000218_A24JuegoId
               }
               , new Object[] {
               T000219_A1EmpleadoId
               }
               , new Object[] {
               T000220_A13parqueAtraccionId
               }
            }
         );
         Z20ShowId = 1;
         i20ShowId = 1;
         A20ShowId = 1;
         Z18PaisId = 1;
         i18PaisId = 1;
         A18PaisId = 1;
         Z13parqueAtraccionId = 1;
         A13parqueAtraccionId = 1;
      }

      private short Z13parqueAtraccionId ;
      private short Z18PaisId ;
      private short Z20ShowId ;
      private short GxWebError ;
      private short A18PaisId ;
      private short A20ShowId ;
      private short gxcookieaux ;
      private short AnyError ;
      private short IsModified ;
      private short IsConfirmed ;
      private short nKeyPressed ;
      private short A13parqueAtraccionId ;
      private short Gx_BScreen ;
      private short RcdFound2 ;
      private short gxajaxcallmode ;
      private short i20ShowId ;
      private short i18PaisId ;
      private short ZZ13parqueAtraccionId ;
      private short ZZ18PaisId ;
      private short ZZ20ShowId ;
      private int trnEnded ;
      private int bttBtn_first_Visible ;
      private int bttBtn_previous_Visible ;
      private int bttBtn_next_Visible ;
      private int bttBtn_last_Visible ;
      private int bttBtn_select_Visible ;
      private int edtparqueAtraccionId_Enabled ;
      private int edtparqueAtraccionNombre_Enabled ;
      private int edtparqueAtraccionSitioWeb_Enabled ;
      private int edtparqueAtraccionDireccion_Enabled ;
      private int imgparqueAtraccionFoto_Enabled ;
      private int edtPaisId_Enabled ;
      private int imgprompt_18_Visible ;
      private int edtPaisNombre_Enabled ;
      private int edtShowId_Enabled ;
      private int imgprompt_20_Visible ;
      private int edtShowNombre_Enabled ;
      private int edtparqueAtraccionShowFechaHora_Enabled ;
      private int bttBtn_enter_Visible ;
      private int bttBtn_enter_Enabled ;
      private int bttBtn_cancel_Visible ;
      private int bttBtn_delete_Visible ;
      private int bttBtn_delete_Enabled ;
      private int idxLst ;
      private string sPrefix ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string GXKey ;
      private string PreviousTooltip ;
      private string PreviousCaption ;
      private string GX_FocusControl ;
      private string edtparqueAtraccionId_Internalname ;
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
      private string edtparqueAtraccionId_Jsonclick ;
      private string edtparqueAtraccionNombre_Internalname ;
      private string edtparqueAtraccionNombre_Jsonclick ;
      private string edtparqueAtraccionSitioWeb_Internalname ;
      private string edtparqueAtraccionSitioWeb_Jsonclick ;
      private string edtparqueAtraccionDireccion_Internalname ;
      private string imgparqueAtraccionFoto_Internalname ;
      private string sImgUrl ;
      private string edtPaisId_Internalname ;
      private string edtPaisId_Jsonclick ;
      private string imgprompt_18_gximage ;
      private string imgprompt_18_Internalname ;
      private string imgprompt_18_Link ;
      private string edtPaisNombre_Internalname ;
      private string edtPaisNombre_Jsonclick ;
      private string edtShowId_Internalname ;
      private string edtShowId_Jsonclick ;
      private string imgprompt_20_gximage ;
      private string imgprompt_20_Internalname ;
      private string imgprompt_20_Link ;
      private string edtShowNombre_Internalname ;
      private string edtShowNombre_Jsonclick ;
      private string edtparqueAtraccionShowFechaHora_Internalname ;
      private string edtparqueAtraccionShowFechaHora_Jsonclick ;
      private string bttBtn_enter_Internalname ;
      private string bttBtn_enter_Jsonclick ;
      private string bttBtn_cancel_Internalname ;
      private string bttBtn_cancel_Jsonclick ;
      private string bttBtn_delete_Internalname ;
      private string bttBtn_delete_Jsonclick ;
      private string Gx_mode ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string endTrnMsgTxt ;
      private string endTrnMsgCod ;
      private string sMode2 ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string GXCCtlgxBlob ;
      private DateTime Z23parqueAtraccionShowFechaHora ;
      private DateTime A23parqueAtraccionShowFechaHora ;
      private DateTime ZZ23parqueAtraccionShowFechaHora ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool wbErr ;
      private bool A17parqueAtraccionFoto_IsBlob ;
      private bool Gx_longc ;
      private string Z14parqueAtraccionNombre ;
      private string Z15parqueAtraccionSitioWeb ;
      private string Z16parqueAtraccionDireccion ;
      private string A14parqueAtraccionNombre ;
      private string A15parqueAtraccionSitioWeb ;
      private string A16parqueAtraccionDireccion ;
      private string A40000parqueAtraccionFoto_GXI ;
      private string A19PaisNombre ;
      private string A21ShowNombre ;
      private string Z40000parqueAtraccionFoto_GXI ;
      private string Z19PaisNombre ;
      private string Z21ShowNombre ;
      private string ZZ14parqueAtraccionNombre ;
      private string ZZ15parqueAtraccionSitioWeb ;
      private string ZZ16parqueAtraccionDireccion ;
      private string ZZ40000parqueAtraccionFoto_GXI ;
      private string ZZ19PaisNombre ;
      private string ZZ21ShowNombre ;
      private string A17parqueAtraccionFoto ;
      private string Z17parqueAtraccionFoto ;
      private string ZZ17parqueAtraccionFoto ;
      private GXWebForm Form ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private string[] T00025_A21ShowNombre ;
      private string[] T00024_A19PaisNombre ;
      private short[] T00026_A13parqueAtraccionId ;
      private string[] T00026_A14parqueAtraccionNombre ;
      private string[] T00026_A15parqueAtraccionSitioWeb ;
      private string[] T00026_A16parqueAtraccionDireccion ;
      private string[] T00026_A40000parqueAtraccionFoto_GXI ;
      private string[] T00026_A19PaisNombre ;
      private string[] T00026_A21ShowNombre ;
      private DateTime[] T00026_A23parqueAtraccionShowFechaHora ;
      private short[] T00026_A18PaisId ;
      private short[] T00026_A20ShowId ;
      private string[] T00026_A17parqueAtraccionFoto ;
      private string[] T00027_A19PaisNombre ;
      private string[] T00028_A21ShowNombre ;
      private short[] T00029_A13parqueAtraccionId ;
      private short[] T00023_A13parqueAtraccionId ;
      private string[] T00023_A14parqueAtraccionNombre ;
      private string[] T00023_A15parqueAtraccionSitioWeb ;
      private string[] T00023_A16parqueAtraccionDireccion ;
      private string[] T00023_A40000parqueAtraccionFoto_GXI ;
      private DateTime[] T00023_A23parqueAtraccionShowFechaHora ;
      private short[] T00023_A18PaisId ;
      private short[] T00023_A20ShowId ;
      private string[] T00023_A17parqueAtraccionFoto ;
      private short[] T000210_A13parqueAtraccionId ;
      private short[] T000211_A13parqueAtraccionId ;
      private short[] T00022_A13parqueAtraccionId ;
      private string[] T00022_A14parqueAtraccionNombre ;
      private string[] T00022_A15parqueAtraccionSitioWeb ;
      private string[] T00022_A16parqueAtraccionDireccion ;
      private string[] T00022_A40000parqueAtraccionFoto_GXI ;
      private DateTime[] T00022_A23parqueAtraccionShowFechaHora ;
      private short[] T00022_A18PaisId ;
      private short[] T00022_A20ShowId ;
      private string[] T00022_A17parqueAtraccionFoto ;
      private short[] T000212_A13parqueAtraccionId ;
      private string[] T000216_A19PaisNombre ;
      private string[] T000217_A21ShowNombre ;
      private short[] T000218_A24JuegoId ;
      private short[] T000219_A1EmpleadoId ;
      private short[] T000220_A13parqueAtraccionId ;
   }

   public class parqueatraccion__default : DataStoreHelperBase, IDataStoreHelper
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
         ,new ForEachCursor(def[9])
         ,new ForEachCursor(def[10])
         ,new UpdateCursor(def[11])
         ,new UpdateCursor(def[12])
         ,new UpdateCursor(def[13])
         ,new ForEachCursor(def[14])
         ,new ForEachCursor(def[15])
         ,new ForEachCursor(def[16])
         ,new ForEachCursor(def[17])
         ,new ForEachCursor(def[18])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmT00022;
          prmT00022 = new Object[] {
          new ParDef("@parqueAtraccionId",GXType.Int16,4,0)
          };
          Object[] prmT00023;
          prmT00023 = new Object[] {
          new ParDef("@parqueAtraccionId",GXType.Int16,4,0)
          };
          Object[] prmT00024;
          prmT00024 = new Object[] {
          new ParDef("@PaisId",GXType.Int16,4,0)
          };
          Object[] prmT00025;
          prmT00025 = new Object[] {
          new ParDef("@ShowId",GXType.Int16,4,0)
          };
          Object[] prmT00026;
          prmT00026 = new Object[] {
          new ParDef("@parqueAtraccionId",GXType.Int16,4,0)
          };
          Object[] prmT00027;
          prmT00027 = new Object[] {
          new ParDef("@PaisId",GXType.Int16,4,0)
          };
          Object[] prmT00028;
          prmT00028 = new Object[] {
          new ParDef("@ShowId",GXType.Int16,4,0)
          };
          Object[] prmT00029;
          prmT00029 = new Object[] {
          new ParDef("@parqueAtraccionId",GXType.Int16,4,0)
          };
          Object[] prmT000210;
          prmT000210 = new Object[] {
          new ParDef("@parqueAtraccionId",GXType.Int16,4,0)
          };
          Object[] prmT000211;
          prmT000211 = new Object[] {
          new ParDef("@parqueAtraccionId",GXType.Int16,4,0)
          };
          Object[] prmT000212;
          prmT000212 = new Object[] {
          new ParDef("@parqueAtraccionNombre",GXType.NVarChar,20,0) ,
          new ParDef("@parqueAtraccionSitioWeb",GXType.NVarChar,60,0) ,
          new ParDef("@parqueAtraccionDireccion",GXType.NVarChar,1024,0) ,
          new ParDef("@parqueAtraccionFoto",GXType.Blob,1024,0){InDB=false} ,
          new ParDef("@parqueAtraccionFoto_GXI",GXType.VarChar,2048,0){AddAtt=true, ImgIdx=3, Tbl="parqueAtraccion", Fld="parqueAtraccionFoto"} ,
          new ParDef("@parqueAtraccionShowFechaHora",GXType.DateTime,8,5) ,
          new ParDef("@PaisId",GXType.Int16,4,0) ,
          new ParDef("@ShowId",GXType.Int16,4,0)
          };
          Object[] prmT000213;
          prmT000213 = new Object[] {
          new ParDef("@parqueAtraccionNombre",GXType.NVarChar,20,0) ,
          new ParDef("@parqueAtraccionSitioWeb",GXType.NVarChar,60,0) ,
          new ParDef("@parqueAtraccionDireccion",GXType.NVarChar,1024,0) ,
          new ParDef("@parqueAtraccionShowFechaHora",GXType.DateTime,8,5) ,
          new ParDef("@PaisId",GXType.Int16,4,0) ,
          new ParDef("@ShowId",GXType.Int16,4,0) ,
          new ParDef("@parqueAtraccionId",GXType.Int16,4,0)
          };
          Object[] prmT000214;
          prmT000214 = new Object[] {
          new ParDef("@parqueAtraccionFoto",GXType.Blob,1024,0){InDB=false} ,
          new ParDef("@parqueAtraccionFoto_GXI",GXType.VarChar,2048,0){AddAtt=true, ImgIdx=0, Tbl="parqueAtraccion", Fld="parqueAtraccionFoto"} ,
          new ParDef("@parqueAtraccionId",GXType.Int16,4,0)
          };
          Object[] prmT000215;
          prmT000215 = new Object[] {
          new ParDef("@parqueAtraccionId",GXType.Int16,4,0)
          };
          Object[] prmT000216;
          prmT000216 = new Object[] {
          new ParDef("@PaisId",GXType.Int16,4,0)
          };
          Object[] prmT000217;
          prmT000217 = new Object[] {
          new ParDef("@ShowId",GXType.Int16,4,0)
          };
          Object[] prmT000218;
          prmT000218 = new Object[] {
          new ParDef("@parqueAtraccionId",GXType.Int16,4,0)
          };
          Object[] prmT000219;
          prmT000219 = new Object[] {
          new ParDef("@parqueAtraccionId",GXType.Int16,4,0)
          };
          Object[] prmT000220;
          prmT000220 = new Object[] {
          };
          def= new CursorDef[] {
              new CursorDef("T00022", "SELECT [parqueAtraccionId], [parqueAtraccionNombre], [parqueAtraccionSitioWeb], [parqueAtraccionDireccion], [parqueAtraccionFoto_GXI], [parqueAtraccionShowFechaHora], [PaisId], [ShowId], [parqueAtraccionFoto] FROM [parqueAtraccion] WITH (UPDLOCK) WHERE [parqueAtraccionId] = @parqueAtraccionId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00022,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00023", "SELECT [parqueAtraccionId], [parqueAtraccionNombre], [parqueAtraccionSitioWeb], [parqueAtraccionDireccion], [parqueAtraccionFoto_GXI], [parqueAtraccionShowFechaHora], [PaisId], [ShowId], [parqueAtraccionFoto] FROM [parqueAtraccion] WHERE [parqueAtraccionId] = @parqueAtraccionId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00023,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00024", "SELECT [PaisNombre] FROM [Pais] WHERE [PaisId] = @PaisId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00024,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00025", "SELECT [ShowNombre] FROM [Show] WHERE [ShowId] = @ShowId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00025,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00026", "SELECT TM1.[parqueAtraccionId], TM1.[parqueAtraccionNombre], TM1.[parqueAtraccionSitioWeb], TM1.[parqueAtraccionDireccion], TM1.[parqueAtraccionFoto_GXI], T2.[PaisNombre], T3.[ShowNombre], TM1.[parqueAtraccionShowFechaHora], TM1.[PaisId], TM1.[ShowId], TM1.[parqueAtraccionFoto] FROM (([parqueAtraccion] TM1 INNER JOIN [Pais] T2 ON T2.[PaisId] = TM1.[PaisId]) INNER JOIN [Show] T3 ON T3.[ShowId] = TM1.[ShowId]) WHERE TM1.[parqueAtraccionId] = @parqueAtraccionId ORDER BY TM1.[parqueAtraccionId]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT00026,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00027", "SELECT [PaisNombre] FROM [Pais] WHERE [PaisId] = @PaisId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00027,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00028", "SELECT [ShowNombre] FROM [Show] WHERE [ShowId] = @ShowId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00028,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00029", "SELECT [parqueAtraccionId] FROM [parqueAtraccion] WHERE [parqueAtraccionId] = @parqueAtraccionId  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT00029,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000210", "SELECT TOP 1 [parqueAtraccionId] FROM [parqueAtraccion] WHERE ( [parqueAtraccionId] > @parqueAtraccionId) ORDER BY [parqueAtraccionId]  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT000210,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T000211", "SELECT TOP 1 [parqueAtraccionId] FROM [parqueAtraccion] WHERE ( [parqueAtraccionId] < @parqueAtraccionId) ORDER BY [parqueAtraccionId] DESC  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT000211,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T000212", "INSERT INTO [parqueAtraccion]([parqueAtraccionNombre], [parqueAtraccionSitioWeb], [parqueAtraccionDireccion], [parqueAtraccionFoto], [parqueAtraccionFoto_GXI], [parqueAtraccionShowFechaHora], [PaisId], [ShowId]) VALUES(@parqueAtraccionNombre, @parqueAtraccionSitioWeb, @parqueAtraccionDireccion, @parqueAtraccionFoto, @parqueAtraccionFoto_GXI, @parqueAtraccionShowFechaHora, @PaisId, @ShowId); SELECT SCOPE_IDENTITY()",true, GxErrorMask.GX_NOMASK, false, this,prmT000212,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T000213", "UPDATE [parqueAtraccion] SET [parqueAtraccionNombre]=@parqueAtraccionNombre, [parqueAtraccionSitioWeb]=@parqueAtraccionSitioWeb, [parqueAtraccionDireccion]=@parqueAtraccionDireccion, [parqueAtraccionShowFechaHora]=@parqueAtraccionShowFechaHora, [PaisId]=@PaisId, [ShowId]=@ShowId  WHERE [parqueAtraccionId] = @parqueAtraccionId", GxErrorMask.GX_NOMASK,prmT000213)
             ,new CursorDef("T000214", "UPDATE [parqueAtraccion] SET [parqueAtraccionFoto]=@parqueAtraccionFoto, [parqueAtraccionFoto_GXI]=@parqueAtraccionFoto_GXI  WHERE [parqueAtraccionId] = @parqueAtraccionId", GxErrorMask.GX_NOMASK,prmT000214)
             ,new CursorDef("T000215", "DELETE FROM [parqueAtraccion]  WHERE [parqueAtraccionId] = @parqueAtraccionId", GxErrorMask.GX_NOMASK,prmT000215)
             ,new CursorDef("T000216", "SELECT [PaisNombre] FROM [Pais] WHERE [PaisId] = @PaisId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000216,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000217", "SELECT [ShowNombre] FROM [Show] WHERE [ShowId] = @ShowId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000217,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000218", "SELECT TOP 1 [JuegoId] FROM [Juego] WHERE [parqueAtraccionId] = @parqueAtraccionId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000218,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T000219", "SELECT TOP 1 [EmpleadoId] FROM [Empleado] WHERE [parqueAtraccionId] = @parqueAtraccionId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000219,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T000220", "SELECT [parqueAtraccionId] FROM [parqueAtraccion] ORDER BY [parqueAtraccionId]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT000220,100, GxCacheFrequency.OFF ,true,false )
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
                ((string[]) buf[4])[0] = rslt.getMultimediaUri(5);
                ((DateTime[]) buf[5])[0] = rslt.getGXDateTime(6);
                ((short[]) buf[6])[0] = rslt.getShort(7);
                ((short[]) buf[7])[0] = rslt.getShort(8);
                ((string[]) buf[8])[0] = rslt.getMultimediaFile(9, rslt.getVarchar(5));
                return;
             case 1 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((string[]) buf[2])[0] = rslt.getVarchar(3);
                ((string[]) buf[3])[0] = rslt.getVarchar(4);
                ((string[]) buf[4])[0] = rslt.getMultimediaUri(5);
                ((DateTime[]) buf[5])[0] = rslt.getGXDateTime(6);
                ((short[]) buf[6])[0] = rslt.getShort(7);
                ((short[]) buf[7])[0] = rslt.getShort(8);
                ((string[]) buf[8])[0] = rslt.getMultimediaFile(9, rslt.getVarchar(5));
                return;
             case 2 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                return;
             case 3 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                return;
             case 4 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((string[]) buf[2])[0] = rslt.getVarchar(3);
                ((string[]) buf[3])[0] = rslt.getVarchar(4);
                ((string[]) buf[4])[0] = rslt.getMultimediaUri(5);
                ((string[]) buf[5])[0] = rslt.getVarchar(6);
                ((string[]) buf[6])[0] = rslt.getVarchar(7);
                ((DateTime[]) buf[7])[0] = rslt.getGXDateTime(8);
                ((short[]) buf[8])[0] = rslt.getShort(9);
                ((short[]) buf[9])[0] = rslt.getShort(10);
                ((string[]) buf[10])[0] = rslt.getMultimediaFile(11, rslt.getVarchar(5));
                return;
             case 5 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                return;
             case 6 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                return;
             case 7 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                return;
             case 8 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                return;
             case 9 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                return;
             case 10 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                return;
             case 14 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                return;
             case 15 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                return;
             case 16 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                return;
             case 17 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                return;
             case 18 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                return;
       }
    }

 }

}
