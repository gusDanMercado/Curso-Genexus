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
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_16") == 0 )
         {
            A18PaisId = (short)(Math.Round(NumberUtil.Val( GetPar( "PaisId"), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "A18PaisId", StringUtil.LTrimStr( (decimal)(A18PaisId), 4, 0));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_16( A18PaisId) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_17") == 0 )
         {
            A18PaisId = (short)(Math.Round(NumberUtil.Val( GetPar( "PaisId"), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "A18PaisId", StringUtil.LTrimStr( (decimal)(A18PaisId), 4, 0));
            A28CiudadId = (short)(Math.Round(NumberUtil.Val( GetPar( "CiudadId"), "."), 18, MidpointRounding.ToEven));
            n28CiudadId = false;
            AssignAttri("", false, "A28CiudadId", StringUtil.LTrimStr( (decimal)(A28CiudadId), 4, 0));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_17( A18PaisId, A28CiudadId) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_18") == 0 )
         {
            A20ShowId = (short)(Math.Round(NumberUtil.Val( GetPar( "ShowId"), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "A20ShowId", StringUtil.LTrimStr( (decimal)(A20ShowId), 4, 0));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_18( A20ShowId) ;
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
               AV7parqueAtraccionId = (short)(Math.Round(NumberUtil.Val( GetPar( "parqueAtraccionId"), "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV7parqueAtraccionId", StringUtil.LTrimStr( (decimal)(AV7parqueAtraccionId), 4, 0));
               GxWebStd.gx_hidden_field( context, "gxhash_vPARQUEATRACCIONID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV7parqueAtraccionId), "ZZZ9"), context));
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
         Form.Meta.addItem("description", "parque Atraccion", 0) ;
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         if ( ! context.isAjaxRequest( ) )
         {
            GX_FocusControl = edtparqueAtraccionNombre_Internalname;
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

      public void execute( string aP0_Gx_mode ,
                           short aP1_parqueAtraccionId )
      {
         this.Gx_mode = aP0_Gx_mode;
         this.AV7parqueAtraccionId = aP1_parqueAtraccionId;
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
         GxWebStd.gx_button_ctrl( context, bttBtn_first_Internalname, "", "", bttBtn_first_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_first_Visible, 0, "standard", "'"+""+"'"+",false,"+"'"+"EFIRST."+"'", TempTags, "", context.GetButtonType( ), "HLP_parqueAtraccion.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 23,'',false,'',0)\"";
         ClassString = "Button button-auxiliary ico__arrow-prev";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_previous_Internalname, "", "", bttBtn_previous_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_previous_Visible, 0, "standard", "'"+""+"'"+",false,"+"'"+"EPREVIOUS."+"'", TempTags, "", context.GetButtonType( ), "HLP_parqueAtraccion.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 25,'',false,'',0)\"";
         ClassString = "Button button-auxiliary ico__arrow-next";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_next_Internalname, "", "", bttBtn_next_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_next_Visible, 0, "standard", "'"+""+"'"+",false,"+"'"+"ENEXT."+"'", TempTags, "", context.GetButtonType( ), "HLP_parqueAtraccion.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 27,'',false,'',0)\"";
         ClassString = "Button button-auxiliary ico__arrow-last";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_last_Internalname, "", "", bttBtn_last_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_last_Visible, 0, "standard", "'"+""+"'"+",false,"+"'"+"ELAST."+"'", TempTags, "", context.GetButtonType( ), "HLP_parqueAtraccion.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 29,'',false,'',0)\"";
         ClassString = "Button button-secondary";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_select_Internalname, "", "Seleccionar", bttBtn_select_Jsonclick, 5, "Seleccionar", "", StyleString, ClassString, bttBtn_select_Visible, 0, "standard", "'"+""+"'"+",false,"+"'"+"ESELECT."+"'", TempTags, "", 2, "HLP_parqueAtraccion.htm");
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
         GxWebStd.gx_single_line_edit( context, edtPaisId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A18PaisId), 4, 0, ",", "")), StringUtil.LTrim( context.localUtil.Format( (decimal)(A18PaisId), "ZZZ9")), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,59);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtPaisId_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtPaisId_Enabled, 1, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_parqueAtraccion.htm");
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtCiudadId_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtCiudadId_Internalname, "Ciudad Id", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 69,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtCiudadId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A28CiudadId), 4, 0, ",", "")), StringUtil.LTrim( context.localUtil.Format( (decimal)(A28CiudadId), "ZZZ9")), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,69);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCiudadId_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtCiudadId_Enabled, 1, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_parqueAtraccion.htm");
         /* Static images/pictures */
         ClassString = "gx-prompt Image" + " " + ((StringUtil.StrCmp(imgprompt_28_gximage, "")==0) ? "" : "GX_Image_"+imgprompt_28_gximage+"_Class");
         StyleString = "";
         sImgUrl = (string)(context.GetImagePath( "prompt.gif", "", context.GetTheme( )));
         GxWebStd.gx_bitmap( context, imgprompt_28_Internalname, sImgUrl, imgprompt_28_Link, "", "", context.GetTheme( ), imgprompt_28_Visible, 1, "", "", 0, 0, 0, "", 0, "", 0, 0, 0, "", "", StyleString, ClassString, "", "", "", "", "", "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_parqueAtraccion.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtCiudadNombre_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtCiudadNombre_Internalname, "Ciudad Nombre", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 74,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtCiudadNombre_Internalname, A29CiudadNombre, StringUtil.RTrim( context.localUtil.Format( A29CiudadNombre, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,74);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCiudadNombre_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtCiudadNombre_Enabled, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_parqueAtraccion.htm");
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
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 79,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtShowId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A20ShowId), 4, 0, ",", "")), StringUtil.LTrim( context.localUtil.Format( (decimal)(A20ShowId), "ZZZ9")), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,79);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtShowId_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtShowId_Enabled, 1, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_parqueAtraccion.htm");
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
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 84,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtShowNombre_Internalname, A21ShowNombre, StringUtil.RTrim( context.localUtil.Format( A21ShowNombre, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,84);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtShowNombre_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtShowNombre_Enabled, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_parqueAtraccion.htm");
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
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 89,'',false,'',0)\"";
         context.WriteHtmlText( "<div id=\""+edtparqueAtraccionShowFechaHora_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
         GxWebStd.gx_single_line_edit( context, edtparqueAtraccionShowFechaHora_Internalname, context.localUtil.TToC( A23parqueAtraccionShowFechaHora, 10, 8, 0, 3, "/", ":", " "), context.localUtil.Format( A23parqueAtraccionShowFechaHora, "99/99/99 99:99"), TempTags+" onchange=\""+"gx.date.valid_date(this, 8,'DMY',5,24,'spa',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 8,'DMY',5,24,'spa',false,0);"+";gx.evt.onblur(this,89);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtparqueAtraccionShowFechaHora_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtparqueAtraccionShowFechaHora_Enabled, 0, "text", "", 14, "chr", 1, "row", 14, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_parqueAtraccion.htm");
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
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 94,'',false,'',0)\"";
         ClassString = "Button button-primary";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_enter_Internalname, "", bttBtn_enter_Caption, bttBtn_enter_Jsonclick, 5, bttBtn_enter_Tooltiptext, "", StyleString, ClassString, bttBtn_enter_Visible, bttBtn_enter_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_parqueAtraccion.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 96,'',false,'',0)\"";
         ClassString = "Button button-tertiary";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_cancel_Internalname, "", "Cancelar", bttBtn_cancel_Jsonclick, 1, "Cancelar", "", StyleString, ClassString, bttBtn_cancel_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_parqueAtraccion.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 98,'',false,'',0)\"";
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
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E11022 ();
         context.wbGlbDoneStart = 1;
         assign_properties_default( ) ;
         if ( AnyError == 0 )
         {
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
               Z28CiudadId = (short)(Math.Round(context.localUtil.CToN( cgiGet( "Z28CiudadId"), ",", "."), 18, MidpointRounding.ToEven));
               n28CiudadId = ((0==A28CiudadId) ? true : false);
               Z20ShowId = (short)(Math.Round(context.localUtil.CToN( cgiGet( "Z20ShowId"), ",", "."), 18, MidpointRounding.ToEven));
               IsConfirmed = (short)(Math.Round(context.localUtil.CToN( cgiGet( "IsConfirmed"), ",", "."), 18, MidpointRounding.ToEven));
               IsModified = (short)(Math.Round(context.localUtil.CToN( cgiGet( "IsModified"), ",", "."), 18, MidpointRounding.ToEven));
               Gx_mode = cgiGet( "Mode");
               N18PaisId = (short)(Math.Round(context.localUtil.CToN( cgiGet( "N18PaisId"), ",", "."), 18, MidpointRounding.ToEven));
               N28CiudadId = (short)(Math.Round(context.localUtil.CToN( cgiGet( "N28CiudadId"), ",", "."), 18, MidpointRounding.ToEven));
               n28CiudadId = ((0==A28CiudadId) ? true : false);
               N20ShowId = (short)(Math.Round(context.localUtil.CToN( cgiGet( "N20ShowId"), ",", "."), 18, MidpointRounding.ToEven));
               AV7parqueAtraccionId = (short)(Math.Round(context.localUtil.CToN( cgiGet( "vPARQUEATRACCIONID"), ",", "."), 18, MidpointRounding.ToEven));
               Gx_BScreen = (short)(Math.Round(context.localUtil.CToN( cgiGet( "vGXBSCREEN"), ",", "."), 18, MidpointRounding.ToEven));
               AV11Insert_PaisId = (short)(Math.Round(context.localUtil.CToN( cgiGet( "vINSERT_PAISID"), ",", "."), 18, MidpointRounding.ToEven));
               AV12Insert_CiudadId = (short)(Math.Round(context.localUtil.CToN( cgiGet( "vINSERT_CIUDADID"), ",", "."), 18, MidpointRounding.ToEven));
               AV13Insert_ShowId = (short)(Math.Round(context.localUtil.CToN( cgiGet( "vINSERT_SHOWID"), ",", "."), 18, MidpointRounding.ToEven));
               A40000parqueAtraccionFoto_GXI = cgiGet( "PARQUEATRACCIONFOTO_GXI");
               AV15Pgmname = cgiGet( "vPGMNAME");
               /* Read variables values. */
               A13parqueAtraccionId = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtparqueAtraccionId_Internalname), ",", "."), 18, MidpointRounding.ToEven));
               n13parqueAtraccionId = false;
               AssignAttri("", false, "A13parqueAtraccionId", StringUtil.LTrimStr( (decimal)(A13parqueAtraccionId), 4, 0));
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
               if ( ( ( context.localUtil.CToN( cgiGet( edtCiudadId_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtCiudadId_Internalname), ",", ".") > Convert.ToDecimal( 9999 )) ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "CIUDADID");
                  AnyError = 1;
                  GX_FocusControl = edtCiudadId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A28CiudadId = 0;
                  n28CiudadId = false;
                  AssignAttri("", false, "A28CiudadId", StringUtil.LTrimStr( (decimal)(A28CiudadId), 4, 0));
               }
               else
               {
                  A28CiudadId = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtCiudadId_Internalname), ",", "."), 18, MidpointRounding.ToEven));
                  n28CiudadId = false;
                  AssignAttri("", false, "A28CiudadId", StringUtil.LTrimStr( (decimal)(A28CiudadId), 4, 0));
               }
               n28CiudadId = ((0==A28CiudadId) ? true : false);
               A29CiudadNombre = cgiGet( edtCiudadNombre_Internalname);
               AssignAttri("", false, "A29CiudadNombre", A29CiudadNombre);
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
               forbiddenHiddens = new GXProperties();
               forbiddenHiddens.Add("hshsalt", "hsh"+"parqueAtraccion");
               A13parqueAtraccionId = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtparqueAtraccionId_Internalname), ",", "."), 18, MidpointRounding.ToEven));
               n13parqueAtraccionId = false;
               AssignAttri("", false, "A13parqueAtraccionId", StringUtil.LTrimStr( (decimal)(A13parqueAtraccionId), 4, 0));
               forbiddenHiddens.Add("parqueAtraccionId", context.localUtil.Format( (decimal)(A13parqueAtraccionId), "ZZZ9"));
               forbiddenHiddens.Add("Gx_mode", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")));
               hsh = cgiGet( "hsh");
               if ( ( ! ( ( A13parqueAtraccionId != Z13parqueAtraccionId ) ) || ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) ) && ! GXUtil.CheckEncryptedHash( forbiddenHiddens.ToString(), hsh, GXKey) )
               {
                  GXUtil.WriteLogError("parqueatraccion:[ SecurityCheckFailed (403 Forbidden) value for]"+forbiddenHiddens.ToJSonString());
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
                  A13parqueAtraccionId = (short)(Math.Round(NumberUtil.Val( GetPar( "parqueAtraccionId"), "."), 18, MidpointRounding.ToEven));
                  n13parqueAtraccionId = false;
                  AssignAttri("", false, "A13parqueAtraccionId", StringUtil.LTrimStr( (decimal)(A13parqueAtraccionId), 4, 0));
                  getEqualNoModal( ) ;
                  if ( ! (0==AV7parqueAtraccionId) )
                  {
                     A13parqueAtraccionId = AV7parqueAtraccionId;
                     n13parqueAtraccionId = false;
                     AssignAttri("", false, "A13parqueAtraccionId", StringUtil.LTrimStr( (decimal)(A13parqueAtraccionId), 4, 0));
                  }
                  else
                  {
                     if ( IsIns( )  && (0==A13parqueAtraccionId) && ( Gx_BScreen == 0 ) )
                     {
                        A13parqueAtraccionId = 1;
                        n13parqueAtraccionId = false;
                        AssignAttri("", false, "A13parqueAtraccionId", StringUtil.LTrimStr( (decimal)(A13parqueAtraccionId), 4, 0));
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
                     sMode2 = Gx_mode;
                     Gx_mode = "UPD";
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                     if ( ! (0==AV7parqueAtraccionId) )
                     {
                        A13parqueAtraccionId = AV7parqueAtraccionId;
                        n13parqueAtraccionId = false;
                        AssignAttri("", false, "A13parqueAtraccionId", StringUtil.LTrimStr( (decimal)(A13parqueAtraccionId), 4, 0));
                     }
                     else
                     {
                        if ( IsIns( )  && (0==A13parqueAtraccionId) && ( Gx_BScreen == 0 ) )
                        {
                           A13parqueAtraccionId = 1;
                           n13parqueAtraccionId = false;
                           AssignAttri("", false, "A13parqueAtraccionId", StringUtil.LTrimStr( (decimal)(A13parqueAtraccionId), 4, 0));
                        }
                     }
                     Gx_mode = sMode2;
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                  }
                  standaloneModal( ) ;
                  if ( ! IsIns( ) )
                  {
                     getByPrimaryKey( ) ;
                     if ( RcdFound2 == 1 )
                     {
                        if ( IsDlt( ) )
                        {
                           /* Confirm record */
                           CONFIRM_020( ) ;
                           if ( AnyError == 0 )
                           {
                              GX_FocusControl = bttBtn_enter_Internalname;
                              AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                           }
                        }
                     }
                     else
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_noinsert", ""), 1, "PARQUEATRACCIONID");
                        AnyError = 1;
                        GX_FocusControl = edtparqueAtraccionId_Internalname;
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
                           E11022 ();
                        }
                        else if ( StringUtil.StrCmp(sEvt, "AFTER TRN") == 0 )
                        {
                           context.wbHandled = 1;
                           dynload_actions( ) ;
                           /* Execute user event: After Trn */
                           E12022 ();
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
            E12022 ();
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
            DisableAttributes022( ) ;
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
               CloseExtendedTableCursors022( ) ;
            }
         }
         if ( AnyError == 0 )
         {
            IsConfirmed = 1;
            AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         }
      }

      protected void ResetCaption020( )
      {
      }

      protected void E11022( )
      {
         /* Start Routine */
         returnInSub = false;
         if ( ! new GeneXus.Programs.general.security.isauthorized(context).executeUdp(  AV15Pgmname) )
         {
            CallWebObject(formatLink("general.security.notauthorized.aspx", new object[] {UrlEncode(StringUtil.RTrim(AV15Pgmname))}, new string[] {"GxObject"}) );
            context.wjLocDisableFrm = 1;
         }
         AV9TrnContext.FromXml(AV10WebSession.Get("TrnContext"), null, "", "");
         AV11Insert_PaisId = 0;
         AssignAttri("", false, "AV11Insert_PaisId", StringUtil.LTrimStr( (decimal)(AV11Insert_PaisId), 4, 0));
         AV12Insert_CiudadId = 0;
         AssignAttri("", false, "AV12Insert_CiudadId", StringUtil.LTrimStr( (decimal)(AV12Insert_CiudadId), 4, 0));
         AV13Insert_ShowId = 0;
         AssignAttri("", false, "AV13Insert_ShowId", StringUtil.LTrimStr( (decimal)(AV13Insert_ShowId), 4, 0));
         if ( ( StringUtil.StrCmp(AV9TrnContext.gxTpr_Transactionname, AV15Pgmname) == 0 ) && ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) )
         {
            AV16GXV1 = 1;
            AssignAttri("", false, "AV16GXV1", StringUtil.LTrimStr( (decimal)(AV16GXV1), 8, 0));
            while ( AV16GXV1 <= AV9TrnContext.gxTpr_Attributes.Count )
            {
               AV14TrnContextAtt = ((GeneXus.Programs.general.ui.SdtTransactionContext_Attribute)AV9TrnContext.gxTpr_Attributes.Item(AV16GXV1));
               if ( StringUtil.StrCmp(AV14TrnContextAtt.gxTpr_Attributename, "PaisId") == 0 )
               {
                  AV11Insert_PaisId = (short)(Math.Round(NumberUtil.Val( AV14TrnContextAtt.gxTpr_Attributevalue, "."), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, "AV11Insert_PaisId", StringUtil.LTrimStr( (decimal)(AV11Insert_PaisId), 4, 0));
               }
               else if ( StringUtil.StrCmp(AV14TrnContextAtt.gxTpr_Attributename, "CiudadId") == 0 )
               {
                  AV12Insert_CiudadId = (short)(Math.Round(NumberUtil.Val( AV14TrnContextAtt.gxTpr_Attributevalue, "."), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, "AV12Insert_CiudadId", StringUtil.LTrimStr( (decimal)(AV12Insert_CiudadId), 4, 0));
               }
               else if ( StringUtil.StrCmp(AV14TrnContextAtt.gxTpr_Attributename, "ShowId") == 0 )
               {
                  AV13Insert_ShowId = (short)(Math.Round(NumberUtil.Val( AV14TrnContextAtt.gxTpr_Attributevalue, "."), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, "AV13Insert_ShowId", StringUtil.LTrimStr( (decimal)(AV13Insert_ShowId), 4, 0));
               }
               AV16GXV1 = (int)(AV16GXV1+1);
               AssignAttri("", false, "AV16GXV1", StringUtil.LTrimStr( (decimal)(AV16GXV1), 8, 0));
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

      protected void E12022( )
      {
         /* After Trn Routine */
         returnInSub = false;
         if ( ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 ) && ! AV9TrnContext.gxTpr_Callerondelete )
         {
            CallWebObject(formatLink("wwparqueatraccion.aspx") );
            context.wjLocDisableFrm = 1;
         }
         context.setWebReturnParms(new Object[] {});
         context.setWebReturnParmsMetadata(new Object[] {});
         context.wjLocDisableFrm = 1;
         context.nUserReturn = 1;
         pr_default.close(1);
         pr_default.close(2);
         pr_default.close(3);
         pr_default.close(4);
         returnInSub = true;
         if (true) return;
      }

      protected void ZM022( short GX_JID )
      {
         if ( ( GX_JID == 15 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z14parqueAtraccionNombre = T00023_A14parqueAtraccionNombre[0];
               Z15parqueAtraccionSitioWeb = T00023_A15parqueAtraccionSitioWeb[0];
               Z16parqueAtraccionDireccion = T00023_A16parqueAtraccionDireccion[0];
               Z23parqueAtraccionShowFechaHora = T00023_A23parqueAtraccionShowFechaHora[0];
               Z18PaisId = T00023_A18PaisId[0];
               Z28CiudadId = T00023_A28CiudadId[0];
               Z20ShowId = T00023_A20ShowId[0];
            }
            else
            {
               Z14parqueAtraccionNombre = A14parqueAtraccionNombre;
               Z15parqueAtraccionSitioWeb = A15parqueAtraccionSitioWeb;
               Z16parqueAtraccionDireccion = A16parqueAtraccionDireccion;
               Z23parqueAtraccionShowFechaHora = A23parqueAtraccionShowFechaHora;
               Z18PaisId = A18PaisId;
               Z28CiudadId = A28CiudadId;
               Z20ShowId = A20ShowId;
            }
         }
         if ( GX_JID == -15 )
         {
            Z13parqueAtraccionId = A13parqueAtraccionId;
            Z14parqueAtraccionNombre = A14parqueAtraccionNombre;
            Z15parqueAtraccionSitioWeb = A15parqueAtraccionSitioWeb;
            Z16parqueAtraccionDireccion = A16parqueAtraccionDireccion;
            Z17parqueAtraccionFoto = A17parqueAtraccionFoto;
            Z40000parqueAtraccionFoto_GXI = A40000parqueAtraccionFoto_GXI;
            Z23parqueAtraccionShowFechaHora = A23parqueAtraccionShowFechaHora;
            Z18PaisId = A18PaisId;
            Z28CiudadId = A28CiudadId;
            Z20ShowId = A20ShowId;
            Z19PaisNombre = A19PaisNombre;
            Z29CiudadNombre = A29CiudadNombre;
            Z21ShowNombre = A21ShowNombre;
         }
      }

      protected void standaloneNotModal( )
      {
         edtparqueAtraccionId_Enabled = 0;
         AssignProp("", false, edtparqueAtraccionId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtparqueAtraccionId_Enabled), 5, 0), true);
         Gx_BScreen = 0;
         AssignAttri("", false, "Gx_BScreen", StringUtil.Str( (decimal)(Gx_BScreen), 1, 0));
         imgprompt_18_Link = ((StringUtil.StrCmp(Gx_mode, "DSP")==0) ? "" : "javascript:"+"gx.popup.openPrompt('"+"gx0030.aspx"+"',["+"{Ctrl:gx.dom.el('"+"PAISID"+"'), id:'"+"PAISID"+"'"+",IOType:'out'}"+"],"+"null"+","+"'', false"+","+"false"+");");
         imgprompt_28_Link = ((StringUtil.StrCmp(Gx_mode, "DSP")==0) ? "" : "javascript:"+"gx.popup.openPrompt('"+"gx0071.aspx"+"',["+"{Ctrl:gx.dom.el('"+"PAISID"+"'), id:'"+"PAISID"+"'"+",IOType:'in'}"+","+"{Ctrl:gx.dom.el('"+"CIUDADID"+"'), id:'"+"CIUDADID"+"'"+",IOType:'out'}"+"],"+"null"+","+"'', false"+","+"false"+");");
         imgprompt_20_Link = ((StringUtil.StrCmp(Gx_mode, "DSP")==0) ? "" : "javascript:"+"gx.popup.openPrompt('"+"gx0040.aspx"+"',["+"{Ctrl:gx.dom.el('"+"SHOWID"+"'), id:'"+"SHOWID"+"'"+",IOType:'out'}"+"],"+"null"+","+"'', false"+","+"false"+");");
         edtparqueAtraccionId_Enabled = 0;
         AssignProp("", false, edtparqueAtraccionId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtparqueAtraccionId_Enabled), 5, 0), true);
         bttBtn_delete_Enabled = 0;
         AssignProp("", false, bttBtn_delete_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_delete_Enabled), 5, 0), true);
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! (0==AV11Insert_PaisId) )
         {
            edtPaisId_Enabled = 0;
            AssignProp("", false, edtPaisId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtPaisId_Enabled), 5, 0), true);
         }
         else
         {
            edtPaisId_Enabled = 1;
            AssignProp("", false, edtPaisId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtPaisId_Enabled), 5, 0), true);
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! (0==AV12Insert_CiudadId) )
         {
            edtCiudadId_Enabled = 0;
            AssignProp("", false, edtCiudadId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCiudadId_Enabled), 5, 0), true);
         }
         else
         {
            edtCiudadId_Enabled = 1;
            AssignProp("", false, edtCiudadId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCiudadId_Enabled), 5, 0), true);
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! (0==AV13Insert_ShowId) )
         {
            edtShowId_Enabled = 0;
            AssignProp("", false, edtShowId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtShowId_Enabled), 5, 0), true);
         }
         else
         {
            edtShowId_Enabled = 1;
            AssignProp("", false, edtShowId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtShowId_Enabled), 5, 0), true);
         }
      }

      protected void standaloneModal( )
      {
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! (0==AV12Insert_CiudadId) )
         {
            A28CiudadId = AV12Insert_CiudadId;
            n28CiudadId = false;
            AssignAttri("", false, "A28CiudadId", StringUtil.LTrimStr( (decimal)(A28CiudadId), 4, 0));
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
         if ( ! (0==AV7parqueAtraccionId) )
         {
            A13parqueAtraccionId = AV7parqueAtraccionId;
            n13parqueAtraccionId = false;
            AssignAttri("", false, "A13parqueAtraccionId", StringUtil.LTrimStr( (decimal)(A13parqueAtraccionId), 4, 0));
         }
         else
         {
            if ( IsIns( )  && (0==A13parqueAtraccionId) && ( Gx_BScreen == 0 ) )
            {
               A13parqueAtraccionId = 1;
               n13parqueAtraccionId = false;
               AssignAttri("", false, "A13parqueAtraccionId", StringUtil.LTrimStr( (decimal)(A13parqueAtraccionId), 4, 0));
            }
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! (0==AV11Insert_PaisId) )
         {
            A18PaisId = AV11Insert_PaisId;
            AssignAttri("", false, "A18PaisId", StringUtil.LTrimStr( (decimal)(A18PaisId), 4, 0));
         }
         else
         {
            if ( IsIns( )  && (0==A18PaisId) && ( Gx_BScreen == 0 ) )
            {
               A18PaisId = 1;
               AssignAttri("", false, "A18PaisId", StringUtil.LTrimStr( (decimal)(A18PaisId), 4, 0));
            }
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! (0==AV13Insert_ShowId) )
         {
            A20ShowId = AV13Insert_ShowId;
            AssignAttri("", false, "A20ShowId", StringUtil.LTrimStr( (decimal)(A20ShowId), 4, 0));
         }
         else
         {
            if ( IsIns( )  && (0==A20ShowId) && ( Gx_BScreen == 0 ) )
            {
               A20ShowId = 1;
               AssignAttri("", false, "A20ShowId", StringUtil.LTrimStr( (decimal)(A20ShowId), 4, 0));
            }
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ( Gx_BScreen == 0 ) )
         {
            AV15Pgmname = "parqueAtraccion";
            AssignAttri("", false, "AV15Pgmname", AV15Pgmname);
            /* Using cursor T00024 */
            pr_default.execute(2, new Object[] {A18PaisId});
            A19PaisNombre = T00024_A19PaisNombre[0];
            AssignAttri("", false, "A19PaisNombre", A19PaisNombre);
            pr_default.close(2);
            /* Using cursor T00025 */
            pr_default.execute(3, new Object[] {A18PaisId, n28CiudadId, A28CiudadId});
            A29CiudadNombre = T00025_A29CiudadNombre[0];
            AssignAttri("", false, "A29CiudadNombre", A29CiudadNombre);
            pr_default.close(3);
            /* Using cursor T00026 */
            pr_default.execute(4, new Object[] {A20ShowId});
            A21ShowNombre = T00026_A21ShowNombre[0];
            AssignAttri("", false, "A21ShowNombre", A21ShowNombre);
            pr_default.close(4);
         }
      }

      protected void Load022( )
      {
         /* Using cursor T00027 */
         pr_default.execute(5, new Object[] {n13parqueAtraccionId, A13parqueAtraccionId});
         if ( (pr_default.getStatus(5) != 101) )
         {
            RcdFound2 = 1;
            A14parqueAtraccionNombre = T00027_A14parqueAtraccionNombre[0];
            AssignAttri("", false, "A14parqueAtraccionNombre", A14parqueAtraccionNombre);
            A15parqueAtraccionSitioWeb = T00027_A15parqueAtraccionSitioWeb[0];
            AssignAttri("", false, "A15parqueAtraccionSitioWeb", A15parqueAtraccionSitioWeb);
            A16parqueAtraccionDireccion = T00027_A16parqueAtraccionDireccion[0];
            AssignAttri("", false, "A16parqueAtraccionDireccion", A16parqueAtraccionDireccion);
            A40000parqueAtraccionFoto_GXI = T00027_A40000parqueAtraccionFoto_GXI[0];
            AssignProp("", false, imgparqueAtraccionFoto_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A17parqueAtraccionFoto)) ? A40000parqueAtraccionFoto_GXI : context.convertURL( context.PathToRelativeUrl( A17parqueAtraccionFoto))), true);
            AssignProp("", false, imgparqueAtraccionFoto_Internalname, "SrcSet", context.GetImageSrcSet( A17parqueAtraccionFoto), true);
            A19PaisNombre = T00027_A19PaisNombre[0];
            AssignAttri("", false, "A19PaisNombre", A19PaisNombre);
            A29CiudadNombre = T00027_A29CiudadNombre[0];
            AssignAttri("", false, "A29CiudadNombre", A29CiudadNombre);
            A21ShowNombre = T00027_A21ShowNombre[0];
            AssignAttri("", false, "A21ShowNombre", A21ShowNombre);
            A23parqueAtraccionShowFechaHora = T00027_A23parqueAtraccionShowFechaHora[0];
            AssignAttri("", false, "A23parqueAtraccionShowFechaHora", context.localUtil.TToC( A23parqueAtraccionShowFechaHora, 8, 5, 0, 3, "/", ":", " "));
            A18PaisId = T00027_A18PaisId[0];
            AssignAttri("", false, "A18PaisId", StringUtil.LTrimStr( (decimal)(A18PaisId), 4, 0));
            A28CiudadId = T00027_A28CiudadId[0];
            n28CiudadId = T00027_n28CiudadId[0];
            AssignAttri("", false, "A28CiudadId", StringUtil.LTrimStr( (decimal)(A28CiudadId), 4, 0));
            A20ShowId = T00027_A20ShowId[0];
            AssignAttri("", false, "A20ShowId", StringUtil.LTrimStr( (decimal)(A20ShowId), 4, 0));
            A17parqueAtraccionFoto = T00027_A17parqueAtraccionFoto[0];
            AssignAttri("", false, "A17parqueAtraccionFoto", A17parqueAtraccionFoto);
            AssignProp("", false, imgparqueAtraccionFoto_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A17parqueAtraccionFoto)) ? A40000parqueAtraccionFoto_GXI : context.convertURL( context.PathToRelativeUrl( A17parqueAtraccionFoto))), true);
            AssignProp("", false, imgparqueAtraccionFoto_Internalname, "SrcSet", context.GetImageSrcSet( A17parqueAtraccionFoto), true);
            ZM022( -15) ;
         }
         pr_default.close(5);
         OnLoadActions022( ) ;
      }

      protected void OnLoadActions022( )
      {
         AV15Pgmname = "parqueAtraccion";
         AssignAttri("", false, "AV15Pgmname", AV15Pgmname);
      }

      protected void CheckExtendedTable022( )
      {
         Gx_BScreen = 1;
         AssignAttri("", false, "Gx_BScreen", StringUtil.Str( (decimal)(Gx_BScreen), 1, 0));
         standaloneModal( ) ;
         AV15Pgmname = "parqueAtraccion";
         AssignAttri("", false, "AV15Pgmname", AV15Pgmname);
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
         pr_default.execute(3, new Object[] {A18PaisId, n28CiudadId, A28CiudadId});
         if ( (pr_default.getStatus(3) == 101) )
         {
            if ( ! ( (0==A18PaisId) || (0==A28CiudadId) ) )
            {
               GX_msglist.addItem("No existe 'Ciudad'.", "ForeignKeyNotFound", 1, "CIUDADID");
               AnyError = 1;
               GX_FocusControl = edtPaisId_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         A29CiudadNombre = T00025_A29CiudadNombre[0];
         AssignAttri("", false, "A29CiudadNombre", A29CiudadNombre);
         pr_default.close(3);
         /* Using cursor T00026 */
         pr_default.execute(4, new Object[] {A20ShowId});
         if ( (pr_default.getStatus(4) == 101) )
         {
            GX_msglist.addItem("No existe 'Show'.", "ForeignKeyNotFound", 1, "SHOWID");
            AnyError = 1;
            GX_FocusControl = edtShowId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A21ShowNombre = T00026_A21ShowNombre[0];
         AssignAttri("", false, "A21ShowNombre", A21ShowNombre);
         pr_default.close(4);
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
         pr_default.close(4);
      }

      protected void enableDisable( )
      {
      }

      protected void gxLoad_16( short A18PaisId )
      {
         /* Using cursor T00028 */
         pr_default.execute(6, new Object[] {A18PaisId});
         if ( (pr_default.getStatus(6) == 101) )
         {
            GX_msglist.addItem("No existe 'Pais'.", "ForeignKeyNotFound", 1, "PAISID");
            AnyError = 1;
            GX_FocusControl = edtPaisId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A19PaisNombre = T00028_A19PaisNombre[0];
         AssignAttri("", false, "A19PaisNombre", A19PaisNombre);
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( A19PaisNombre)+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(6) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(6);
      }

      protected void gxLoad_17( short A18PaisId ,
                                short A28CiudadId )
      {
         /* Using cursor T00029 */
         pr_default.execute(7, new Object[] {A18PaisId, n28CiudadId, A28CiudadId});
         if ( (pr_default.getStatus(7) == 101) )
         {
            if ( ! ( (0==A18PaisId) || (0==A28CiudadId) ) )
            {
               GX_msglist.addItem("No existe 'Ciudad'.", "ForeignKeyNotFound", 1, "CIUDADID");
               AnyError = 1;
               GX_FocusControl = edtPaisId_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         A29CiudadNombre = T00029_A29CiudadNombre[0];
         AssignAttri("", false, "A29CiudadNombre", A29CiudadNombre);
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( A29CiudadNombre)+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(7) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(7);
      }

      protected void gxLoad_18( short A20ShowId )
      {
         /* Using cursor T000210 */
         pr_default.execute(8, new Object[] {A20ShowId});
         if ( (pr_default.getStatus(8) == 101) )
         {
            GX_msglist.addItem("No existe 'Show'.", "ForeignKeyNotFound", 1, "SHOWID");
            AnyError = 1;
            GX_FocusControl = edtShowId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A21ShowNombre = T000210_A21ShowNombre[0];
         AssignAttri("", false, "A21ShowNombre", A21ShowNombre);
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( A21ShowNombre)+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(8) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(8);
      }

      protected void GetKey022( )
      {
         /* Using cursor T000211 */
         pr_default.execute(9, new Object[] {n13parqueAtraccionId, A13parqueAtraccionId});
         if ( (pr_default.getStatus(9) != 101) )
         {
            RcdFound2 = 1;
         }
         else
         {
            RcdFound2 = 0;
         }
         pr_default.close(9);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor T00023 */
         pr_default.execute(1, new Object[] {n13parqueAtraccionId, A13parqueAtraccionId});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM022( 15) ;
            RcdFound2 = 1;
            A13parqueAtraccionId = T00023_A13parqueAtraccionId[0];
            n13parqueAtraccionId = T00023_n13parqueAtraccionId[0];
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
            A28CiudadId = T00023_A28CiudadId[0];
            n28CiudadId = T00023_n28CiudadId[0];
            AssignAttri("", false, "A28CiudadId", StringUtil.LTrimStr( (decimal)(A28CiudadId), 4, 0));
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
         }
         else
         {
         }
         getByPrimaryKey( ) ;
      }

      protected void move_next( )
      {
         RcdFound2 = 0;
         /* Using cursor T000212 */
         pr_default.execute(10, new Object[] {n13parqueAtraccionId, A13parqueAtraccionId});
         if ( (pr_default.getStatus(10) != 101) )
         {
            while ( (pr_default.getStatus(10) != 101) && ( ( T000212_A13parqueAtraccionId[0] < A13parqueAtraccionId ) ) )
            {
               pr_default.readNext(10);
            }
            if ( (pr_default.getStatus(10) != 101) && ( ( T000212_A13parqueAtraccionId[0] > A13parqueAtraccionId ) ) )
            {
               A13parqueAtraccionId = T000212_A13parqueAtraccionId[0];
               n13parqueAtraccionId = T000212_n13parqueAtraccionId[0];
               AssignAttri("", false, "A13parqueAtraccionId", StringUtil.LTrimStr( (decimal)(A13parqueAtraccionId), 4, 0));
               RcdFound2 = 1;
            }
         }
         pr_default.close(10);
      }

      protected void move_previous( )
      {
         RcdFound2 = 0;
         /* Using cursor T000213 */
         pr_default.execute(11, new Object[] {n13parqueAtraccionId, A13parqueAtraccionId});
         if ( (pr_default.getStatus(11) != 101) )
         {
            while ( (pr_default.getStatus(11) != 101) && ( ( T000213_A13parqueAtraccionId[0] > A13parqueAtraccionId ) ) )
            {
               pr_default.readNext(11);
            }
            if ( (pr_default.getStatus(11) != 101) && ( ( T000213_A13parqueAtraccionId[0] < A13parqueAtraccionId ) ) )
            {
               A13parqueAtraccionId = T000213_A13parqueAtraccionId[0];
               n13parqueAtraccionId = T000213_n13parqueAtraccionId[0];
               AssignAttri("", false, "A13parqueAtraccionId", StringUtil.LTrimStr( (decimal)(A13parqueAtraccionId), 4, 0));
               RcdFound2 = 1;
            }
         }
         pr_default.close(11);
      }

      protected void btn_enter( )
      {
         nKeyPressed = 1;
         GetKey022( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            GX_FocusControl = edtparqueAtraccionNombre_Internalname;
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
                  n13parqueAtraccionId = false;
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
                  GX_FocusControl = edtparqueAtraccionNombre_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else
               {
                  /* Update record */
                  Update022( ) ;
                  GX_FocusControl = edtparqueAtraccionNombre_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
            }
            else
            {
               if ( A13parqueAtraccionId != Z13parqueAtraccionId )
               {
                  /* Insert record */
                  GX_FocusControl = edtparqueAtraccionNombre_Internalname;
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
                     /* Insert record */
                     GX_FocusControl = edtparqueAtraccionNombre_Internalname;
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
         if ( A13parqueAtraccionId != Z13parqueAtraccionId )
         {
            A13parqueAtraccionId = Z13parqueAtraccionId;
            n13parqueAtraccionId = false;
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
            GX_FocusControl = edtparqueAtraccionNombre_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( AnyError != 0 )
         {
         }
      }

      protected void CheckOptimisticConcurrency022( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T00022 */
            pr_default.execute(0, new Object[] {n13parqueAtraccionId, A13parqueAtraccionId});
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
            if ( Gx_longc || ( Z28CiudadId != T00022_A28CiudadId[0] ) || ( Z20ShowId != T00022_A20ShowId[0] ) )
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
               if ( Z28CiudadId != T00022_A28CiudadId[0] )
               {
                  GXUtil.WriteLog("parqueatraccion:[seudo value changed for attri]"+"CiudadId");
                  GXUtil.WriteLogRaw("Old: ",Z28CiudadId);
                  GXUtil.WriteLogRaw("Current: ",T00022_A28CiudadId[0]);
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
                     /* Using cursor T000214 */
                     pr_default.execute(12, new Object[] {A14parqueAtraccionNombre, A15parqueAtraccionSitioWeb, A16parqueAtraccionDireccion, A17parqueAtraccionFoto, A40000parqueAtraccionFoto_GXI, A23parqueAtraccionShowFechaHora, A18PaisId, n28CiudadId, A28CiudadId, A20ShowId});
                     A13parqueAtraccionId = T000214_A13parqueAtraccionId[0];
                     n13parqueAtraccionId = T000214_n13parqueAtraccionId[0];
                     AssignAttri("", false, "A13parqueAtraccionId", StringUtil.LTrimStr( (decimal)(A13parqueAtraccionId), 4, 0));
                     pr_default.close(12);
                     pr_default.SmartCacheProvider.SetUpdated("parqueAtraccion");
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
                     /* Using cursor T000215 */
                     pr_default.execute(13, new Object[] {A14parqueAtraccionNombre, A15parqueAtraccionSitioWeb, A16parqueAtraccionDireccion, A23parqueAtraccionShowFechaHora, A18PaisId, n28CiudadId, A28CiudadId, A20ShowId, n13parqueAtraccionId, A13parqueAtraccionId});
                     pr_default.close(13);
                     pr_default.SmartCacheProvider.SetUpdated("parqueAtraccion");
                     if ( (pr_default.getStatus(13) == 103) )
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
            EndLevel022( ) ;
         }
         CloseExtendedTableCursors022( ) ;
      }

      protected void DeferredUpdate022( )
      {
         if ( AnyError == 0 )
         {
            /* Using cursor T000216 */
            pr_default.execute(14, new Object[] {A17parqueAtraccionFoto, A40000parqueAtraccionFoto_GXI, n13parqueAtraccionId, A13parqueAtraccionId});
            pr_default.close(14);
            pr_default.SmartCacheProvider.SetUpdated("parqueAtraccion");
         }
      }

      protected void delete( )
      {
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
                  /* Using cursor T000217 */
                  pr_default.execute(15, new Object[] {n13parqueAtraccionId, A13parqueAtraccionId});
                  pr_default.close(15);
                  pr_default.SmartCacheProvider.SetUpdated("parqueAtraccion");
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
            AV15Pgmname = "parqueAtraccion";
            AssignAttri("", false, "AV15Pgmname", AV15Pgmname);
            /* Using cursor T000218 */
            pr_default.execute(16, new Object[] {A18PaisId});
            A19PaisNombre = T000218_A19PaisNombre[0];
            AssignAttri("", false, "A19PaisNombre", A19PaisNombre);
            pr_default.close(16);
            /* Using cursor T000219 */
            pr_default.execute(17, new Object[] {A18PaisId, n28CiudadId, A28CiudadId});
            A29CiudadNombre = T000219_A29CiudadNombre[0];
            AssignAttri("", false, "A29CiudadNombre", A29CiudadNombre);
            pr_default.close(17);
            /* Using cursor T000220 */
            pr_default.execute(18, new Object[] {A20ShowId});
            A21ShowNombre = T000220_A21ShowNombre[0];
            AssignAttri("", false, "A21ShowNombre", A21ShowNombre);
            pr_default.close(18);
         }
         if ( AnyError == 0 )
         {
            /* Using cursor T000221 */
            pr_default.execute(19, new Object[] {n13parqueAtraccionId, A13parqueAtraccionId});
            if ( (pr_default.getStatus(19) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Juego"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(19);
            /* Using cursor T000222 */
            pr_default.execute(20, new Object[] {n13parqueAtraccionId, A13parqueAtraccionId});
            if ( (pr_default.getStatus(20) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Empleado"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(20);
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
            pr_default.close(16);
            pr_default.close(17);
            pr_default.close(18);
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
            pr_default.close(16);
            pr_default.close(17);
            pr_default.close(18);
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
         /* Scan By routine */
         /* Using cursor T000223 */
         pr_default.execute(21);
         RcdFound2 = 0;
         if ( (pr_default.getStatus(21) != 101) )
         {
            RcdFound2 = 1;
            A13parqueAtraccionId = T000223_A13parqueAtraccionId[0];
            n13parqueAtraccionId = T000223_n13parqueAtraccionId[0];
            AssignAttri("", false, "A13parqueAtraccionId", StringUtil.LTrimStr( (decimal)(A13parqueAtraccionId), 4, 0));
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext022( )
      {
         /* Scan next routine */
         pr_default.readNext(21);
         RcdFound2 = 0;
         if ( (pr_default.getStatus(21) != 101) )
         {
            RcdFound2 = 1;
            A13parqueAtraccionId = T000223_A13parqueAtraccionId[0];
            n13parqueAtraccionId = T000223_n13parqueAtraccionId[0];
            AssignAttri("", false, "A13parqueAtraccionId", StringUtil.LTrimStr( (decimal)(A13parqueAtraccionId), 4, 0));
         }
      }

      protected void ScanEnd022( )
      {
         pr_default.close(21);
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
         edtCiudadId_Enabled = 0;
         AssignProp("", false, edtCiudadId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCiudadId_Enabled), 5, 0), true);
         edtCiudadNombre_Enabled = 0;
         AssignProp("", false, edtCiudadNombre_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCiudadNombre_Enabled), 5, 0), true);
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("parqueatraccion.aspx", new object[] {UrlEncode(StringUtil.RTrim(Gx_mode)),UrlEncode(StringUtil.LTrimStr(AV7parqueAtraccionId,4,0))}, new string[] {"Gx_mode","parqueAtraccionId"}) +"\">") ;
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
         forbiddenHiddens.Add("hshsalt", "hsh"+"parqueAtraccion");
         forbiddenHiddens.Add("parqueAtraccionId", context.localUtil.Format( (decimal)(A13parqueAtraccionId), "ZZZ9"));
         forbiddenHiddens.Add("Gx_mode", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")));
         GxWebStd.gx_hidden_field( context, "hsh", GetEncryptedHash( forbiddenHiddens.ToString(), GXKey));
         GXUtil.WriteLogInfo("parqueatraccion:[ SendSecurityCheck value for]"+forbiddenHiddens.ToJSonString());
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
         GxWebStd.gx_hidden_field( context, "Z28CiudadId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z28CiudadId), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "Z20ShowId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z20ShowId), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "IsConfirmed", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsConfirmed), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "IsModified", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsModified), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "Mode", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "gxhash_Mode", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")), context));
         GxWebStd.gx_hidden_field( context, "N18PaisId", StringUtil.LTrim( StringUtil.NToC( (decimal)(A18PaisId), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "N28CiudadId", StringUtil.LTrim( StringUtil.NToC( (decimal)(A28CiudadId), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "N20ShowId", StringUtil.LTrim( StringUtil.NToC( (decimal)(A20ShowId), 4, 0, ",", "")));
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
         GxWebStd.gx_hidden_field( context, "vPARQUEATRACCIONID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV7parqueAtraccionId), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vPARQUEATRACCIONID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV7parqueAtraccionId), "ZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "vGXBSCREEN", StringUtil.LTrim( StringUtil.NToC( (decimal)(Gx_BScreen), 1, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "vINSERT_PAISID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV11Insert_PaisId), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "vINSERT_CIUDADID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV12Insert_CiudadId), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "vINSERT_SHOWID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV13Insert_ShowId), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "PARQUEATRACCIONFOTO_GXI", A40000parqueAtraccionFoto_GXI);
         GxWebStd.gx_hidden_field( context, "vPGMNAME", StringUtil.RTrim( AV15Pgmname));
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
         return formatLink("parqueatraccion.aspx", new object[] {UrlEncode(StringUtil.RTrim(Gx_mode)),UrlEncode(StringUtil.LTrimStr(AV7parqueAtraccionId,4,0))}, new string[] {"Gx_mode","parqueAtraccionId"})  ;
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
         A28CiudadId = 0;
         n28CiudadId = false;
         AssignAttri("", false, "A28CiudadId", StringUtil.LTrimStr( (decimal)(A28CiudadId), 4, 0));
         n28CiudadId = ((0==A28CiudadId) ? true : false);
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
         A29CiudadNombre = "";
         AssignAttri("", false, "A29CiudadNombre", A29CiudadNombre);
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
         Z28CiudadId = 0;
         Z20ShowId = 0;
      }

      protected void InitAll022( )
      {
         A13parqueAtraccionId = 1;
         n13parqueAtraccionId = false;
         AssignAttri("", false, "A13parqueAtraccionId", StringUtil.LTrimStr( (decimal)(A13parqueAtraccionId), 4, 0));
         InitializeNonKey022( ) ;
      }

      protected void StandaloneModalInsert( )
      {
         A18PaisId = i18PaisId;
         AssignAttri("", false, "A18PaisId", StringUtil.LTrimStr( (decimal)(A18PaisId), 4, 0));
         A20ShowId = i20ShowId;
         AssignAttri("", false, "A20ShowId", StringUtil.LTrimStr( (decimal)(A20ShowId), 4, 0));
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?20255112542383", true, true);
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
         context.AddJavascriptSource("parqueatraccion.js", "?20255112542383", false, true);
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
         edtCiudadId_Internalname = "CIUDADID";
         edtCiudadNombre_Internalname = "CIUDADNOMBRE";
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
         imgprompt_28_Internalname = "PROMPT_28";
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
         bttBtn_delete_Enabled = 0;
         bttBtn_delete_Visible = 1;
         bttBtn_cancel_Visible = 1;
         bttBtn_enter_Tooltiptext = "Confirmar";
         bttBtn_enter_Caption = "Confirmar";
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
         edtCiudadNombre_Jsonclick = "";
         edtCiudadNombre_Enabled = 0;
         imgprompt_28_Visible = 1;
         imgprompt_28_Link = "";
         edtCiudadId_Jsonclick = "";
         edtCiudadId_Enabled = 1;
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
         edtparqueAtraccionId_Enabled = 0;
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

      public void Valid_Paisid( )
      {
         /* Using cursor T000218 */
         pr_default.execute(16, new Object[] {A18PaisId});
         if ( (pr_default.getStatus(16) == 101) )
         {
            GX_msglist.addItem("No existe 'Pais'.", "ForeignKeyNotFound", 1, "PAISID");
            AnyError = 1;
            GX_FocusControl = edtPaisId_Internalname;
         }
         A19PaisNombre = T000218_A19PaisNombre[0];
         pr_default.close(16);
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "A19PaisNombre", A19PaisNombre);
      }

      public void Valid_Ciudadid( )
      {
         n28CiudadId = false;
         /* Using cursor T000219 */
         pr_default.execute(17, new Object[] {A18PaisId, n28CiudadId, A28CiudadId});
         if ( (pr_default.getStatus(17) == 101) )
         {
            if ( ! ( (0==A18PaisId) || (0==A28CiudadId) ) )
            {
               GX_msglist.addItem("No existe 'Ciudad'.", "ForeignKeyNotFound", 1, "CIUDADID");
               AnyError = 1;
               GX_FocusControl = edtPaisId_Internalname;
            }
         }
         A29CiudadNombre = T000219_A29CiudadNombre[0];
         pr_default.close(17);
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "A29CiudadNombre", A29CiudadNombre);
      }

      public void Valid_Showid( )
      {
         /* Using cursor T000220 */
         pr_default.execute(18, new Object[] {A20ShowId});
         if ( (pr_default.getStatus(18) == 101) )
         {
            GX_msglist.addItem("No existe 'Show'.", "ForeignKeyNotFound", 1, "SHOWID");
            AnyError = 1;
            GX_FocusControl = edtShowId_Internalname;
         }
         A21ShowNombre = T000220_A21ShowNombre[0];
         pr_default.close(18);
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
         setEventMetadata("ENTER","""{"handler":"UserMainFullajax","iparms":[{"postForm":true},{"av":"Gx_mode","fld":"vMODE","pic":"@!","hsh":true},{"av":"AV7parqueAtraccionId","fld":"vPARQUEATRACCIONID","pic":"ZZZ9","hsh":true}]}""");
         setEventMetadata("REFRESH","""{"handler":"Refresh","iparms":[{"av":"Gx_mode","fld":"vMODE","pic":"@!","hsh":true},{"av":"AV9TrnContext","fld":"vTRNCONTEXT","hsh":true},{"av":"AV7parqueAtraccionId","fld":"vPARQUEATRACCIONID","pic":"ZZZ9","hsh":true},{"av":"A13parqueAtraccionId","fld":"PARQUEATRACCIONID","pic":"ZZZ9"}]}""");
         setEventMetadata("AFTER TRN","""{"handler":"E12022","iparms":[{"av":"Gx_mode","fld":"vMODE","pic":"@!","hsh":true},{"av":"AV9TrnContext","fld":"vTRNCONTEXT","hsh":true}]}""");
         setEventMetadata("VALID_PARQUEATRACCIONID","""{"handler":"Valid_Parqueatraccionid","iparms":[]}""");
         setEventMetadata("VALID_PAISID","""{"handler":"Valid_Paisid","iparms":[{"av":"A18PaisId","fld":"PAISID","pic":"ZZZ9"},{"av":"A19PaisNombre","fld":"PAISNOMBRE"}]""");
         setEventMetadata("VALID_PAISID",""","oparms":[{"av":"A19PaisNombre","fld":"PAISNOMBRE"}]}""");
         setEventMetadata("VALID_CIUDADID","""{"handler":"Valid_Ciudadid","iparms":[{"av":"A18PaisId","fld":"PAISID","pic":"ZZZ9"},{"av":"A28CiudadId","fld":"CIUDADID","pic":"ZZZ9"},{"av":"A29CiudadNombre","fld":"CIUDADNOMBRE"}]""");
         setEventMetadata("VALID_CIUDADID",""","oparms":[{"av":"A29CiudadNombre","fld":"CIUDADNOMBRE"}]}""");
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
         pr_default.close(16);
         pr_default.close(17);
         pr_default.close(18);
      }

      public override void initialize( )
      {
         sPrefix = "";
         wcpOGx_mode = "";
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
         imgprompt_28_gximage = "";
         A29CiudadNombre = "";
         imgprompt_20_gximage = "";
         A21ShowNombre = "";
         A23parqueAtraccionShowFechaHora = (DateTime)(DateTime.MinValue);
         bttBtn_enter_Jsonclick = "";
         bttBtn_cancel_Jsonclick = "";
         bttBtn_delete_Jsonclick = "";
         AV11Insert_PaisId = 1;
         AV13Insert_ShowId = 1;
         AV15Pgmname = "";
         forbiddenHiddens = new GXProperties();
         hsh = "";
         sMode2 = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         endTrnMsgTxt = "";
         endTrnMsgCod = "";
         AV9TrnContext = new GeneXus.Programs.general.ui.SdtTransactionContext(context);
         AV10WebSession = context.GetSession();
         AV14TrnContextAtt = new GeneXus.Programs.general.ui.SdtTransactionContext_Attribute(context);
         Z17parqueAtraccionFoto = "";
         Z40000parqueAtraccionFoto_GXI = "";
         Z19PaisNombre = "";
         Z29CiudadNombre = "";
         Z21ShowNombre = "";
         T00024_A19PaisNombre = new string[] {""} ;
         T00025_A29CiudadNombre = new string[] {""} ;
         T00026_A21ShowNombre = new string[] {""} ;
         T00027_A13parqueAtraccionId = new short[1] ;
         T00027_n13parqueAtraccionId = new bool[] {false} ;
         T00027_A14parqueAtraccionNombre = new string[] {""} ;
         T00027_A15parqueAtraccionSitioWeb = new string[] {""} ;
         T00027_A16parqueAtraccionDireccion = new string[] {""} ;
         T00027_A40000parqueAtraccionFoto_GXI = new string[] {""} ;
         T00027_A19PaisNombre = new string[] {""} ;
         T00027_A29CiudadNombre = new string[] {""} ;
         T00027_A21ShowNombre = new string[] {""} ;
         T00027_A23parqueAtraccionShowFechaHora = new DateTime[] {DateTime.MinValue} ;
         T00027_A18PaisId = new short[1] ;
         T00027_A28CiudadId = new short[1] ;
         T00027_n28CiudadId = new bool[] {false} ;
         T00027_A20ShowId = new short[1] ;
         T00027_A17parqueAtraccionFoto = new string[] {""} ;
         T00028_A19PaisNombre = new string[] {""} ;
         T00029_A29CiudadNombre = new string[] {""} ;
         T000210_A21ShowNombre = new string[] {""} ;
         T000211_A13parqueAtraccionId = new short[1] ;
         T000211_n13parqueAtraccionId = new bool[] {false} ;
         T00023_A13parqueAtraccionId = new short[1] ;
         T00023_n13parqueAtraccionId = new bool[] {false} ;
         T00023_A14parqueAtraccionNombre = new string[] {""} ;
         T00023_A15parqueAtraccionSitioWeb = new string[] {""} ;
         T00023_A16parqueAtraccionDireccion = new string[] {""} ;
         T00023_A40000parqueAtraccionFoto_GXI = new string[] {""} ;
         T00023_A23parqueAtraccionShowFechaHora = new DateTime[] {DateTime.MinValue} ;
         T00023_A18PaisId = new short[1] ;
         T00023_A28CiudadId = new short[1] ;
         T00023_n28CiudadId = new bool[] {false} ;
         T00023_A20ShowId = new short[1] ;
         T00023_A17parqueAtraccionFoto = new string[] {""} ;
         T000212_A13parqueAtraccionId = new short[1] ;
         T000212_n13parqueAtraccionId = new bool[] {false} ;
         T000213_A13parqueAtraccionId = new short[1] ;
         T000213_n13parqueAtraccionId = new bool[] {false} ;
         T00022_A13parqueAtraccionId = new short[1] ;
         T00022_n13parqueAtraccionId = new bool[] {false} ;
         T00022_A14parqueAtraccionNombre = new string[] {""} ;
         T00022_A15parqueAtraccionSitioWeb = new string[] {""} ;
         T00022_A16parqueAtraccionDireccion = new string[] {""} ;
         T00022_A40000parqueAtraccionFoto_GXI = new string[] {""} ;
         T00022_A23parqueAtraccionShowFechaHora = new DateTime[] {DateTime.MinValue} ;
         T00022_A18PaisId = new short[1] ;
         T00022_A28CiudadId = new short[1] ;
         T00022_n28CiudadId = new bool[] {false} ;
         T00022_A20ShowId = new short[1] ;
         T00022_A17parqueAtraccionFoto = new string[] {""} ;
         T000214_A13parqueAtraccionId = new short[1] ;
         T000214_n13parqueAtraccionId = new bool[] {false} ;
         T000218_A19PaisNombre = new string[] {""} ;
         T000219_A29CiudadNombre = new string[] {""} ;
         T000220_A21ShowNombre = new string[] {""} ;
         T000221_A24JuegoId = new short[1] ;
         T000222_A1EmpleadoId = new short[1] ;
         T000223_A13parqueAtraccionId = new short[1] ;
         T000223_n13parqueAtraccionId = new bool[] {false} ;
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXCCtlgxBlob = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.parqueatraccion__default(),
            new Object[][] {
                new Object[] {
               T00022_A13parqueAtraccionId, T00022_A14parqueAtraccionNombre, T00022_A15parqueAtraccionSitioWeb, T00022_A16parqueAtraccionDireccion, T00022_A40000parqueAtraccionFoto_GXI, T00022_A23parqueAtraccionShowFechaHora, T00022_A18PaisId, T00022_A28CiudadId, T00022_n28CiudadId, T00022_A20ShowId,
               T00022_A17parqueAtraccionFoto
               }
               , new Object[] {
               T00023_A13parqueAtraccionId, T00023_A14parqueAtraccionNombre, T00023_A15parqueAtraccionSitioWeb, T00023_A16parqueAtraccionDireccion, T00023_A40000parqueAtraccionFoto_GXI, T00023_A23parqueAtraccionShowFechaHora, T00023_A18PaisId, T00023_A28CiudadId, T00023_n28CiudadId, T00023_A20ShowId,
               T00023_A17parqueAtraccionFoto
               }
               , new Object[] {
               T00024_A19PaisNombre
               }
               , new Object[] {
               T00025_A29CiudadNombre
               }
               , new Object[] {
               T00026_A21ShowNombre
               }
               , new Object[] {
               T00027_A13parqueAtraccionId, T00027_A14parqueAtraccionNombre, T00027_A15parqueAtraccionSitioWeb, T00027_A16parqueAtraccionDireccion, T00027_A40000parqueAtraccionFoto_GXI, T00027_A19PaisNombre, T00027_A29CiudadNombre, T00027_A21ShowNombre, T00027_A23parqueAtraccionShowFechaHora, T00027_A18PaisId,
               T00027_A28CiudadId, T00027_n28CiudadId, T00027_A20ShowId, T00027_A17parqueAtraccionFoto
               }
               , new Object[] {
               T00028_A19PaisNombre
               }
               , new Object[] {
               T00029_A29CiudadNombre
               }
               , new Object[] {
               T000210_A21ShowNombre
               }
               , new Object[] {
               T000211_A13parqueAtraccionId
               }
               , new Object[] {
               T000212_A13parqueAtraccionId
               }
               , new Object[] {
               T000213_A13parqueAtraccionId
               }
               , new Object[] {
               T000214_A13parqueAtraccionId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T000218_A19PaisNombre
               }
               , new Object[] {
               T000219_A29CiudadNombre
               }
               , new Object[] {
               T000220_A21ShowNombre
               }
               , new Object[] {
               T000221_A24JuegoId
               }
               , new Object[] {
               T000222_A1EmpleadoId
               }
               , new Object[] {
               T000223_A13parqueAtraccionId
               }
            }
         );
         Z20ShowId = 1;
         N20ShowId = 1;
         i20ShowId = 1;
         A20ShowId = 1;
         Z18PaisId = 1;
         N18PaisId = 1;
         i18PaisId = 1;
         A18PaisId = 1;
         Z13parqueAtraccionId = 1;
         n13parqueAtraccionId = false;
         A13parqueAtraccionId = 1;
         n13parqueAtraccionId = false;
         AV15Pgmname = "parqueAtraccion";
      }

      private short wcpOAV7parqueAtraccionId ;
      private short Z13parqueAtraccionId ;
      private short Z18PaisId ;
      private short Z28CiudadId ;
      private short Z20ShowId ;
      private short N18PaisId ;
      private short N28CiudadId ;
      private short N20ShowId ;
      private short GxWebError ;
      private short A18PaisId ;
      private short A28CiudadId ;
      private short A20ShowId ;
      private short AV7parqueAtraccionId ;
      private short gxcookieaux ;
      private short AnyError ;
      private short IsModified ;
      private short IsConfirmed ;
      private short nKeyPressed ;
      private short A13parqueAtraccionId ;
      private short Gx_BScreen ;
      private short AV11Insert_PaisId ;
      private short AV12Insert_CiudadId ;
      private short AV13Insert_ShowId ;
      private short RcdFound2 ;
      private short gxajaxcallmode ;
      private short i18PaisId ;
      private short i20ShowId ;
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
      private int edtCiudadId_Enabled ;
      private int imgprompt_28_Visible ;
      private int edtCiudadNombre_Enabled ;
      private int edtShowId_Enabled ;
      private int imgprompt_20_Visible ;
      private int edtShowNombre_Enabled ;
      private int edtparqueAtraccionShowFechaHora_Enabled ;
      private int bttBtn_enter_Visible ;
      private int bttBtn_enter_Enabled ;
      private int bttBtn_cancel_Visible ;
      private int bttBtn_delete_Visible ;
      private int bttBtn_delete_Enabled ;
      private int AV16GXV1 ;
      private int idxLst ;
      private string sPrefix ;
      private string wcpOGx_mode ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string Gx_mode ;
      private string GXKey ;
      private string PreviousTooltip ;
      private string PreviousCaption ;
      private string GX_FocusControl ;
      private string edtparqueAtraccionNombre_Internalname ;
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
      private string edtparqueAtraccionId_Internalname ;
      private string edtparqueAtraccionId_Jsonclick ;
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
      private string edtCiudadId_Internalname ;
      private string edtCiudadId_Jsonclick ;
      private string imgprompt_28_gximage ;
      private string imgprompt_28_Internalname ;
      private string imgprompt_28_Link ;
      private string edtCiudadNombre_Internalname ;
      private string edtCiudadNombre_Jsonclick ;
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
      private string bttBtn_enter_Caption ;
      private string bttBtn_enter_Jsonclick ;
      private string bttBtn_enter_Tooltiptext ;
      private string bttBtn_cancel_Internalname ;
      private string bttBtn_cancel_Jsonclick ;
      private string bttBtn_delete_Internalname ;
      private string bttBtn_delete_Jsonclick ;
      private string AV15Pgmname ;
      private string hsh ;
      private string sMode2 ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string endTrnMsgTxt ;
      private string endTrnMsgCod ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string GXCCtlgxBlob ;
      private DateTime Z23parqueAtraccionShowFechaHora ;
      private DateTime A23parqueAtraccionShowFechaHora ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool n28CiudadId ;
      private bool wbErr ;
      private bool A17parqueAtraccionFoto_IsBlob ;
      private bool n13parqueAtraccionId ;
      private bool returnInSub ;
      private bool Gx_longc ;
      private string Z14parqueAtraccionNombre ;
      private string Z15parqueAtraccionSitioWeb ;
      private string Z16parqueAtraccionDireccion ;
      private string A14parqueAtraccionNombre ;
      private string A15parqueAtraccionSitioWeb ;
      private string A16parqueAtraccionDireccion ;
      private string A40000parqueAtraccionFoto_GXI ;
      private string A19PaisNombre ;
      private string A29CiudadNombre ;
      private string A21ShowNombre ;
      private string Z40000parqueAtraccionFoto_GXI ;
      private string Z19PaisNombre ;
      private string Z29CiudadNombre ;
      private string Z21ShowNombre ;
      private string A17parqueAtraccionFoto ;
      private string Z17parqueAtraccionFoto ;
      private IGxSession AV10WebSession ;
      private GXProperties forbiddenHiddens ;
      private GXWebForm Form ;
      private IGxDataStore dsDefault ;
      private GeneXus.Programs.general.ui.SdtTransactionContext AV9TrnContext ;
      private GeneXus.Programs.general.ui.SdtTransactionContext_Attribute AV14TrnContextAtt ;
      private IDataStoreProvider pr_default ;
      private string[] T00024_A19PaisNombre ;
      private string[] T00025_A29CiudadNombre ;
      private string[] T00026_A21ShowNombre ;
      private short[] T00027_A13parqueAtraccionId ;
      private bool[] T00027_n13parqueAtraccionId ;
      private string[] T00027_A14parqueAtraccionNombre ;
      private string[] T00027_A15parqueAtraccionSitioWeb ;
      private string[] T00027_A16parqueAtraccionDireccion ;
      private string[] T00027_A40000parqueAtraccionFoto_GXI ;
      private string[] T00027_A19PaisNombre ;
      private string[] T00027_A29CiudadNombre ;
      private string[] T00027_A21ShowNombre ;
      private DateTime[] T00027_A23parqueAtraccionShowFechaHora ;
      private short[] T00027_A18PaisId ;
      private short[] T00027_A28CiudadId ;
      private bool[] T00027_n28CiudadId ;
      private short[] T00027_A20ShowId ;
      private string[] T00027_A17parqueAtraccionFoto ;
      private string[] T00028_A19PaisNombre ;
      private string[] T00029_A29CiudadNombre ;
      private string[] T000210_A21ShowNombre ;
      private short[] T000211_A13parqueAtraccionId ;
      private bool[] T000211_n13parqueAtraccionId ;
      private short[] T00023_A13parqueAtraccionId ;
      private bool[] T00023_n13parqueAtraccionId ;
      private string[] T00023_A14parqueAtraccionNombre ;
      private string[] T00023_A15parqueAtraccionSitioWeb ;
      private string[] T00023_A16parqueAtraccionDireccion ;
      private string[] T00023_A40000parqueAtraccionFoto_GXI ;
      private DateTime[] T00023_A23parqueAtraccionShowFechaHora ;
      private short[] T00023_A18PaisId ;
      private short[] T00023_A28CiudadId ;
      private bool[] T00023_n28CiudadId ;
      private short[] T00023_A20ShowId ;
      private string[] T00023_A17parqueAtraccionFoto ;
      private short[] T000212_A13parqueAtraccionId ;
      private bool[] T000212_n13parqueAtraccionId ;
      private short[] T000213_A13parqueAtraccionId ;
      private bool[] T000213_n13parqueAtraccionId ;
      private short[] T00022_A13parqueAtraccionId ;
      private bool[] T00022_n13parqueAtraccionId ;
      private string[] T00022_A14parqueAtraccionNombre ;
      private string[] T00022_A15parqueAtraccionSitioWeb ;
      private string[] T00022_A16parqueAtraccionDireccion ;
      private string[] T00022_A40000parqueAtraccionFoto_GXI ;
      private DateTime[] T00022_A23parqueAtraccionShowFechaHora ;
      private short[] T00022_A18PaisId ;
      private short[] T00022_A28CiudadId ;
      private bool[] T00022_n28CiudadId ;
      private short[] T00022_A20ShowId ;
      private string[] T00022_A17parqueAtraccionFoto ;
      private short[] T000214_A13parqueAtraccionId ;
      private bool[] T000214_n13parqueAtraccionId ;
      private string[] T000218_A19PaisNombre ;
      private string[] T000219_A29CiudadNombre ;
      private string[] T000220_A21ShowNombre ;
      private short[] T000221_A24JuegoId ;
      private short[] T000222_A1EmpleadoId ;
      private short[] T000223_A13parqueAtraccionId ;
      private bool[] T000223_n13parqueAtraccionId ;
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
         ,new ForEachCursor(def[11])
         ,new ForEachCursor(def[12])
         ,new UpdateCursor(def[13])
         ,new UpdateCursor(def[14])
         ,new UpdateCursor(def[15])
         ,new ForEachCursor(def[16])
         ,new ForEachCursor(def[17])
         ,new ForEachCursor(def[18])
         ,new ForEachCursor(def[19])
         ,new ForEachCursor(def[20])
         ,new ForEachCursor(def[21])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmT00022;
          prmT00022 = new Object[] {
          new ParDef("@parqueAtraccionId",GXType.Int16,4,0){Nullable=true}
          };
          Object[] prmT00023;
          prmT00023 = new Object[] {
          new ParDef("@parqueAtraccionId",GXType.Int16,4,0){Nullable=true}
          };
          Object[] prmT00024;
          prmT00024 = new Object[] {
          new ParDef("@PaisId",GXType.Int16,4,0)
          };
          Object[] prmT00025;
          prmT00025 = new Object[] {
          new ParDef("@PaisId",GXType.Int16,4,0) ,
          new ParDef("@CiudadId",GXType.Int16,4,0){Nullable=true}
          };
          Object[] prmT00026;
          prmT00026 = new Object[] {
          new ParDef("@ShowId",GXType.Int16,4,0)
          };
          Object[] prmT00027;
          prmT00027 = new Object[] {
          new ParDef("@parqueAtraccionId",GXType.Int16,4,0){Nullable=true}
          };
          Object[] prmT00028;
          prmT00028 = new Object[] {
          new ParDef("@PaisId",GXType.Int16,4,0)
          };
          Object[] prmT00029;
          prmT00029 = new Object[] {
          new ParDef("@PaisId",GXType.Int16,4,0) ,
          new ParDef("@CiudadId",GXType.Int16,4,0){Nullable=true}
          };
          Object[] prmT000210;
          prmT000210 = new Object[] {
          new ParDef("@ShowId",GXType.Int16,4,0)
          };
          Object[] prmT000211;
          prmT000211 = new Object[] {
          new ParDef("@parqueAtraccionId",GXType.Int16,4,0){Nullable=true}
          };
          Object[] prmT000212;
          prmT000212 = new Object[] {
          new ParDef("@parqueAtraccionId",GXType.Int16,4,0){Nullable=true}
          };
          Object[] prmT000213;
          prmT000213 = new Object[] {
          new ParDef("@parqueAtraccionId",GXType.Int16,4,0){Nullable=true}
          };
          Object[] prmT000214;
          prmT000214 = new Object[] {
          new ParDef("@parqueAtraccionNombre",GXType.NVarChar,20,0) ,
          new ParDef("@parqueAtraccionSitioWeb",GXType.NVarChar,60,0) ,
          new ParDef("@parqueAtraccionDireccion",GXType.NVarChar,1024,0) ,
          new ParDef("@parqueAtraccionFoto",GXType.Blob,1024,0){InDB=false} ,
          new ParDef("@parqueAtraccionFoto_GXI",GXType.VarChar,2048,0){AddAtt=true, ImgIdx=3, Tbl="parqueAtraccion", Fld="parqueAtraccionFoto"} ,
          new ParDef("@parqueAtraccionShowFechaHora",GXType.DateTime,8,5) ,
          new ParDef("@PaisId",GXType.Int16,4,0) ,
          new ParDef("@CiudadId",GXType.Int16,4,0){Nullable=true} ,
          new ParDef("@ShowId",GXType.Int16,4,0)
          };
          Object[] prmT000215;
          prmT000215 = new Object[] {
          new ParDef("@parqueAtraccionNombre",GXType.NVarChar,20,0) ,
          new ParDef("@parqueAtraccionSitioWeb",GXType.NVarChar,60,0) ,
          new ParDef("@parqueAtraccionDireccion",GXType.NVarChar,1024,0) ,
          new ParDef("@parqueAtraccionShowFechaHora",GXType.DateTime,8,5) ,
          new ParDef("@PaisId",GXType.Int16,4,0) ,
          new ParDef("@CiudadId",GXType.Int16,4,0){Nullable=true} ,
          new ParDef("@ShowId",GXType.Int16,4,0) ,
          new ParDef("@parqueAtraccionId",GXType.Int16,4,0){Nullable=true}
          };
          Object[] prmT000216;
          prmT000216 = new Object[] {
          new ParDef("@parqueAtraccionFoto",GXType.Blob,1024,0){InDB=false} ,
          new ParDef("@parqueAtraccionFoto_GXI",GXType.VarChar,2048,0){AddAtt=true, ImgIdx=0, Tbl="parqueAtraccion", Fld="parqueAtraccionFoto"} ,
          new ParDef("@parqueAtraccionId",GXType.Int16,4,0){Nullable=true}
          };
          Object[] prmT000217;
          prmT000217 = new Object[] {
          new ParDef("@parqueAtraccionId",GXType.Int16,4,0){Nullable=true}
          };
          Object[] prmT000218;
          prmT000218 = new Object[] {
          new ParDef("@PaisId",GXType.Int16,4,0)
          };
          Object[] prmT000219;
          prmT000219 = new Object[] {
          new ParDef("@PaisId",GXType.Int16,4,0) ,
          new ParDef("@CiudadId",GXType.Int16,4,0){Nullable=true}
          };
          Object[] prmT000220;
          prmT000220 = new Object[] {
          new ParDef("@ShowId",GXType.Int16,4,0)
          };
          Object[] prmT000221;
          prmT000221 = new Object[] {
          new ParDef("@parqueAtraccionId",GXType.Int16,4,0){Nullable=true}
          };
          Object[] prmT000222;
          prmT000222 = new Object[] {
          new ParDef("@parqueAtraccionId",GXType.Int16,4,0){Nullable=true}
          };
          Object[] prmT000223;
          prmT000223 = new Object[] {
          };
          def= new CursorDef[] {
              new CursorDef("T00022", "SELECT [parqueAtraccionId], [parqueAtraccionNombre], [parqueAtraccionSitioWeb], [parqueAtraccionDireccion], [parqueAtraccionFoto_GXI], [parqueAtraccionShowFechaHora], [PaisId], [CiudadId], [ShowId], [parqueAtraccionFoto] FROM [parqueAtraccion] WITH (UPDLOCK) WHERE [parqueAtraccionId] = @parqueAtraccionId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00022,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00023", "SELECT [parqueAtraccionId], [parqueAtraccionNombre], [parqueAtraccionSitioWeb], [parqueAtraccionDireccion], [parqueAtraccionFoto_GXI], [parqueAtraccionShowFechaHora], [PaisId], [CiudadId], [ShowId], [parqueAtraccionFoto] FROM [parqueAtraccion] WHERE [parqueAtraccionId] = @parqueAtraccionId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00023,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00024", "SELECT [PaisNombre] FROM [Pais] WHERE [PaisId] = @PaisId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00024,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00025", "SELECT [CiudadNombre] FROM [PaisCiudad] WHERE [PaisId] = @PaisId AND [CiudadId] = @CiudadId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00025,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00026", "SELECT [ShowNombre] FROM [Show] WHERE [ShowId] = @ShowId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00026,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00027", "SELECT TM1.[parqueAtraccionId], TM1.[parqueAtraccionNombre], TM1.[parqueAtraccionSitioWeb], TM1.[parqueAtraccionDireccion], TM1.[parqueAtraccionFoto_GXI], T2.[PaisNombre], T3.[CiudadNombre], T4.[ShowNombre], TM1.[parqueAtraccionShowFechaHora], TM1.[PaisId], TM1.[CiudadId], TM1.[ShowId], TM1.[parqueAtraccionFoto] FROM ((([parqueAtraccion] TM1 INNER JOIN [Pais] T2 ON T2.[PaisId] = TM1.[PaisId]) LEFT JOIN [PaisCiudad] T3 ON T3.[PaisId] = TM1.[PaisId] AND T3.[CiudadId] = TM1.[CiudadId]) INNER JOIN [Show] T4 ON T4.[ShowId] = TM1.[ShowId]) WHERE TM1.[parqueAtraccionId] = @parqueAtraccionId ORDER BY TM1.[parqueAtraccionId]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT00027,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00028", "SELECT [PaisNombre] FROM [Pais] WHERE [PaisId] = @PaisId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00028,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00029", "SELECT [CiudadNombre] FROM [PaisCiudad] WHERE [PaisId] = @PaisId AND [CiudadId] = @CiudadId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00029,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000210", "SELECT [ShowNombre] FROM [Show] WHERE [ShowId] = @ShowId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000210,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000211", "SELECT [parqueAtraccionId] FROM [parqueAtraccion] WHERE [parqueAtraccionId] = @parqueAtraccionId  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT000211,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000212", "SELECT TOP 1 [parqueAtraccionId] FROM [parqueAtraccion] WHERE ( [parqueAtraccionId] > @parqueAtraccionId) ORDER BY [parqueAtraccionId]  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT000212,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T000213", "SELECT TOP 1 [parqueAtraccionId] FROM [parqueAtraccion] WHERE ( [parqueAtraccionId] < @parqueAtraccionId) ORDER BY [parqueAtraccionId] DESC  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT000213,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T000214", "INSERT INTO [parqueAtraccion]([parqueAtraccionNombre], [parqueAtraccionSitioWeb], [parqueAtraccionDireccion], [parqueAtraccionFoto], [parqueAtraccionFoto_GXI], [parqueAtraccionShowFechaHora], [PaisId], [CiudadId], [ShowId]) VALUES(@parqueAtraccionNombre, @parqueAtraccionSitioWeb, @parqueAtraccionDireccion, @parqueAtraccionFoto, @parqueAtraccionFoto_GXI, @parqueAtraccionShowFechaHora, @PaisId, @CiudadId, @ShowId); SELECT SCOPE_IDENTITY()",true, GxErrorMask.GX_NOMASK, false, this,prmT000214,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T000215", "UPDATE [parqueAtraccion] SET [parqueAtraccionNombre]=@parqueAtraccionNombre, [parqueAtraccionSitioWeb]=@parqueAtraccionSitioWeb, [parqueAtraccionDireccion]=@parqueAtraccionDireccion, [parqueAtraccionShowFechaHora]=@parqueAtraccionShowFechaHora, [PaisId]=@PaisId, [CiudadId]=@CiudadId, [ShowId]=@ShowId  WHERE [parqueAtraccionId] = @parqueAtraccionId", GxErrorMask.GX_NOMASK,prmT000215)
             ,new CursorDef("T000216", "UPDATE [parqueAtraccion] SET [parqueAtraccionFoto]=@parqueAtraccionFoto, [parqueAtraccionFoto_GXI]=@parqueAtraccionFoto_GXI  WHERE [parqueAtraccionId] = @parqueAtraccionId", GxErrorMask.GX_NOMASK,prmT000216)
             ,new CursorDef("T000217", "DELETE FROM [parqueAtraccion]  WHERE [parqueAtraccionId] = @parqueAtraccionId", GxErrorMask.GX_NOMASK,prmT000217)
             ,new CursorDef("T000218", "SELECT [PaisNombre] FROM [Pais] WHERE [PaisId] = @PaisId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000218,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000219", "SELECT [CiudadNombre] FROM [PaisCiudad] WHERE [PaisId] = @PaisId AND [CiudadId] = @CiudadId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000219,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000220", "SELECT [ShowNombre] FROM [Show] WHERE [ShowId] = @ShowId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000220,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000221", "SELECT TOP 1 [JuegoId] FROM [Juego] WHERE [parqueAtraccionId] = @parqueAtraccionId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000221,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T000222", "SELECT TOP 1 [EmpleadoId] FROM [Empleado] WHERE [parqueAtraccionId] = @parqueAtraccionId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000222,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T000223", "SELECT [parqueAtraccionId] FROM [parqueAtraccion] ORDER BY [parqueAtraccionId]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT000223,100, GxCacheFrequency.OFF ,true,false )
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
                ((bool[]) buf[8])[0] = rslt.wasNull(8);
                ((short[]) buf[9])[0] = rslt.getShort(9);
                ((string[]) buf[10])[0] = rslt.getMultimediaFile(10, rslt.getVarchar(5));
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
                ((bool[]) buf[8])[0] = rslt.wasNull(8);
                ((short[]) buf[9])[0] = rslt.getShort(9);
                ((string[]) buf[10])[0] = rslt.getMultimediaFile(10, rslt.getVarchar(5));
                return;
             case 2 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                return;
             case 3 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                return;
             case 4 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                return;
             case 5 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((string[]) buf[2])[0] = rslt.getVarchar(3);
                ((string[]) buf[3])[0] = rslt.getVarchar(4);
                ((string[]) buf[4])[0] = rslt.getMultimediaUri(5);
                ((string[]) buf[5])[0] = rslt.getVarchar(6);
                ((string[]) buf[6])[0] = rslt.getVarchar(7);
                ((string[]) buf[7])[0] = rslt.getVarchar(8);
                ((DateTime[]) buf[8])[0] = rslt.getGXDateTime(9);
                ((short[]) buf[9])[0] = rslt.getShort(10);
                ((short[]) buf[10])[0] = rslt.getShort(11);
                ((bool[]) buf[11])[0] = rslt.wasNull(11);
                ((short[]) buf[12])[0] = rslt.getShort(12);
                ((string[]) buf[13])[0] = rslt.getMultimediaFile(13, rslt.getVarchar(5));
                return;
             case 6 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                return;
             case 7 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                return;
             case 8 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                return;
             case 9 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                return;
             case 10 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                return;
             case 11 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                return;
             case 12 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                return;
             case 16 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                return;
             case 17 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                return;
             case 18 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                return;
             case 19 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                return;
             case 20 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                return;
             case 21 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                return;
       }
    }

 }

}
