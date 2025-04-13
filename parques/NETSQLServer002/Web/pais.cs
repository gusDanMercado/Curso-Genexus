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
   public class pais : GXDataArea
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
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxNewRow_"+"Gridpais_ciudad") == 0 )
         {
            gxnrGridpais_ciudad_newrow_invoke( ) ;
            return  ;
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
               AV7PaisId = (short)(Math.Round(NumberUtil.Val( GetPar( "PaisId"), "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV7PaisId", StringUtil.LTrimStr( (decimal)(AV7PaisId), 4, 0));
               GxWebStd.gx_hidden_field( context, "gxhash_vPAISID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV7PaisId), "ZZZ9"), context));
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
         Form.Meta.addItem("description", "Pais", 0) ;
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         if ( ! context.isAjaxRequest( ) )
         {
            GX_FocusControl = edtPaisNombre_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         wbErr = false;
         context.SetDefaultTheme("parques", true);
         if ( ! context.IsLocalStorageSupported( ) )
         {
            context.PushCurrentUrl();
         }
      }

      protected void gxnrGridpais_ciudad_newrow_invoke( )
      {
         nRC_GXsfl_48 = (int)(Math.Round(NumberUtil.Val( GetPar( "nRC_GXsfl_48"), "."), 18, MidpointRounding.ToEven));
         nGXsfl_48_idx = (int)(Math.Round(NumberUtil.Val( GetPar( "nGXsfl_48_idx"), "."), 18, MidpointRounding.ToEven));
         sGXsfl_48_idx = GetPar( "sGXsfl_48_idx");
         Gx_mode = GetPar( "Mode");
         setAjaxCallMode();
         if ( ! IsValidAjaxCall( true) )
         {
            GxWebError = 1;
            return  ;
         }
         gxnrGridpais_ciudad_newrow( ) ;
         /* End function gxnrGridpais_ciudad_newrow_invoke */
      }

      public pais( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("parques", true);
      }

      public pais( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_Gx_mode ,
                           short aP1_PaisId )
      {
         this.Gx_mode = aP0_Gx_mode;
         this.AV7PaisId = aP1_PaisId;
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
         GxWebStd.gx_label_ctrl( context, lblTitle_Internalname, "Pais", "", "", lblTitle_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "heading-01", 0, "", 1, 1, 0, 0, "HLP_Pais.htm");
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
         GxWebStd.gx_button_ctrl( context, bttBtn_first_Internalname, "", "", bttBtn_first_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_first_Visible, 0, "standard", "'"+""+"'"+",false,"+"'"+"EFIRST."+"'", TempTags, "", context.GetButtonType( ), "HLP_Pais.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 23,'',false,'',0)\"";
         ClassString = "Button button-auxiliary ico__arrow-prev";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_previous_Internalname, "", "", bttBtn_previous_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_previous_Visible, 0, "standard", "'"+""+"'"+",false,"+"'"+"EPREVIOUS."+"'", TempTags, "", context.GetButtonType( ), "HLP_Pais.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 25,'',false,'',0)\"";
         ClassString = "Button button-auxiliary ico__arrow-next";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_next_Internalname, "", "", bttBtn_next_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_next_Visible, 0, "standard", "'"+""+"'"+",false,"+"'"+"ENEXT."+"'", TempTags, "", context.GetButtonType( ), "HLP_Pais.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 27,'',false,'',0)\"";
         ClassString = "Button button-auxiliary ico__arrow-last";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_last_Internalname, "", "", bttBtn_last_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_last_Visible, 0, "standard", "'"+""+"'"+",false,"+"'"+"ELAST."+"'", TempTags, "", context.GetButtonType( ), "HLP_Pais.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 29,'',false,'',0)\"";
         ClassString = "Button button-secondary";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_select_Internalname, "", "Seleccionar", bttBtn_select_Jsonclick, 5, "Seleccionar", "", StyleString, ClassString, bttBtn_select_Visible, 0, "standard", "'"+""+"'"+",false,"+"'"+"ESELECT."+"'", TempTags, "", 2, "HLP_Pais.htm");
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtPaisId_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtPaisId_Internalname, "Id", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 34,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtPaisId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A18PaisId), 4, 0, ",", "")), StringUtil.LTrim( ((edtPaisId_Enabled!=0) ? context.localUtil.Format( (decimal)(A18PaisId), "ZZZ9") : context.localUtil.Format( (decimal)(A18PaisId), "ZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,34);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtPaisId_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtPaisId_Enabled, 0, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_Pais.htm");
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
         GxWebStd.gx_label_element( context, edtPaisNombre_Internalname, "Nombre", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 39,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtPaisNombre_Internalname, A19PaisNombre, StringUtil.RTrim( context.localUtil.Format( A19PaisNombre, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,39);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtPaisNombre_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtPaisNombre_Enabled, 0, "text", "", 50, "chr", 1, "row", 50, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_Pais.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divCiudadtable_Internalname, 1, 0, "px", 0, "px", "form__table-level", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTitleciudad_Internalname, "Ciudad", "", "", lblTitleciudad_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "heading-04", 0, "", 1, 1, 0, 0, "HLP_Pais.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
         gxdraw_Gridpais_ciudad( ) ;
         GxWebStd.gx_div_end( context, "start", "top", "div");
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
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 55,'',false,'',0)\"";
         ClassString = "Button button-primary";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_enter_Internalname, "", bttBtn_enter_Caption, bttBtn_enter_Jsonclick, 5, bttBtn_enter_Tooltiptext, "", StyleString, ClassString, bttBtn_enter_Visible, bttBtn_enter_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_Pais.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 57,'',false,'',0)\"";
         ClassString = "Button button-tertiary";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_cancel_Internalname, "", "Cancelar", bttBtn_cancel_Jsonclick, 1, "Cancelar", "", StyleString, ClassString, bttBtn_cancel_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_Pais.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 59,'',false,'',0)\"";
         ClassString = "Button button-tertiary";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_delete_Internalname, "", "Eliminar", bttBtn_delete_Jsonclick, 5, "Eliminar", "", StyleString, ClassString, bttBtn_delete_Visible, bttBtn_delete_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EDELETE."+"'", TempTags, "", context.GetButtonType( ), "HLP_Pais.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "end", "Middle", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
      }

      protected void gxdraw_Gridpais_ciudad( )
      {
         /*  Grid Control  */
         StartGridControl48( ) ;
         nGXsfl_48_idx = 0;
         if ( ( nKeyPressed == 1 ) && ( AnyError == 0 ) )
         {
            /* Enter key processing. */
            nBlankRcdCount7 = 5;
            if ( ! IsIns( ) )
            {
               /* Display confirmed (stored) records */
               nRcdExists_7 = 1;
               ScanStart037( ) ;
               while ( RcdFound7 != 0 )
               {
                  init_level_properties7( ) ;
                  getByPrimaryKey037( ) ;
                  AddRow037( ) ;
                  ScanNext037( ) ;
               }
               ScanEnd037( ) ;
               nBlankRcdCount7 = 5;
            }
         }
         else if ( ( nKeyPressed == 3 ) || ( nKeyPressed == 4 ) || ( ( nKeyPressed == 1 ) && ( AnyError != 0 ) ) )
         {
            /* Button check  or addlines. */
            standaloneNotModal037( ) ;
            standaloneModal037( ) ;
            sMode7 = Gx_mode;
            while ( nGXsfl_48_idx < nRC_GXsfl_48 )
            {
               bGXsfl_48_Refreshing = true;
               ReadRow037( ) ;
               edtCiudadId_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "CIUDADID_"+sGXsfl_48_idx+"Enabled"), ",", "."), 18, MidpointRounding.ToEven));
               AssignProp("", false, edtCiudadId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCiudadId_Enabled), 5, 0), !bGXsfl_48_Refreshing);
               edtCiudadNombre_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "CIUDADNOMBRE_"+sGXsfl_48_idx+"Enabled"), ",", "."), 18, MidpointRounding.ToEven));
               AssignProp("", false, edtCiudadNombre_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCiudadNombre_Enabled), 5, 0), !bGXsfl_48_Refreshing);
               if ( ( nRcdExists_7 == 0 ) && ! IsIns( ) )
               {
                  Gx_mode = "INS";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  standaloneModal037( ) ;
               }
               SendRow037( ) ;
               bGXsfl_48_Refreshing = false;
            }
            Gx_mode = sMode7;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            /* Get or get-alike key processing. */
            nBlankRcdCount7 = 5;
            nRcdExists_7 = 1;
            if ( ! IsIns( ) )
            {
               ScanStart037( ) ;
               while ( RcdFound7 != 0 )
               {
                  sGXsfl_48_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_48_idx+1), 4, 0), 4, "0");
                  SubsflControlProps_487( ) ;
                  init_level_properties7( ) ;
                  standaloneNotModal037( ) ;
                  getByPrimaryKey037( ) ;
                  standaloneModal037( ) ;
                  AddRow037( ) ;
                  ScanNext037( ) ;
               }
               ScanEnd037( ) ;
            }
         }
         /* Initialize fields for 'new' records and send them. */
         if ( ! IsDsp( ) && ! IsDlt( ) )
         {
            sMode7 = Gx_mode;
            Gx_mode = "INS";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            sGXsfl_48_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_48_idx+1), 4, 0), 4, "0");
            SubsflControlProps_487( ) ;
            InitAll037( ) ;
            init_level_properties7( ) ;
            nRcdExists_7 = 0;
            nIsMod_7 = 0;
            nRcdDeleted_7 = 0;
            nBlankRcdCount7 = (short)(nBlankRcdUsr7+nBlankRcdCount7);
            fRowAdded = 0;
            while ( nBlankRcdCount7 > 0 )
            {
               standaloneNotModal037( ) ;
               standaloneModal037( ) ;
               AddRow037( ) ;
               if ( ( nKeyPressed == 4 ) && ( fRowAdded == 0 ) )
               {
                  fRowAdded = 1;
                  GX_FocusControl = edtCiudadId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               nBlankRcdCount7 = (short)(nBlankRcdCount7-1);
            }
            Gx_mode = sMode7;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         sStyleString = "";
         context.WriteHtmlText( "<div id=\""+"Gridpais_ciudadContainer"+"Div\" "+sStyleString+">"+"</div>") ;
         context.httpAjaxContext.ajax_rsp_assign_grid("_"+"Gridpais_ciudad", Gridpais_ciudadContainer, subGridpais_ciudad_Internalname);
         if ( ! context.isAjaxRequest( ) && ! context.isSpaRequest( ) )
         {
            GxWebStd.gx_hidden_field( context, "Gridpais_ciudadContainerData", Gridpais_ciudadContainer.ToJavascriptSource());
         }
         if ( context.isAjaxRequest( ) || context.isSpaRequest( ) )
         {
            GxWebStd.gx_hidden_field( context, "Gridpais_ciudadContainerData"+"V", Gridpais_ciudadContainer.GridValuesHidden());
         }
         else
         {
            context.WriteHtmlText( "<input type=\"hidden\" "+"name=\""+"Gridpais_ciudadContainerData"+"V"+"\" value='"+Gridpais_ciudadContainer.GridValuesHidden()+"'/>") ;
         }
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
         E11032 ();
         context.wbGlbDoneStart = 1;
         assign_properties_default( ) ;
         if ( AnyError == 0 )
         {
            if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
            {
               /* Read saved SDTs. */
               /* Read saved values. */
               Z18PaisId = (short)(Math.Round(context.localUtil.CToN( cgiGet( "Z18PaisId"), ",", "."), 18, MidpointRounding.ToEven));
               Z19PaisNombre = cgiGet( "Z19PaisNombre");
               IsConfirmed = (short)(Math.Round(context.localUtil.CToN( cgiGet( "IsConfirmed"), ",", "."), 18, MidpointRounding.ToEven));
               IsModified = (short)(Math.Round(context.localUtil.CToN( cgiGet( "IsModified"), ",", "."), 18, MidpointRounding.ToEven));
               Gx_mode = cgiGet( "Mode");
               nRC_GXsfl_48 = (int)(Math.Round(context.localUtil.CToN( cgiGet( "nRC_GXsfl_48"), ",", "."), 18, MidpointRounding.ToEven));
               AV7PaisId = (short)(Math.Round(context.localUtil.CToN( cgiGet( "vPAISID"), ",", "."), 18, MidpointRounding.ToEven));
               Gx_BScreen = (short)(Math.Round(context.localUtil.CToN( cgiGet( "vGXBSCREEN"), ",", "."), 18, MidpointRounding.ToEven));
               AV11Pgmname = cgiGet( "vPGMNAME");
               /* Read variables values. */
               A18PaisId = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtPaisId_Internalname), ",", "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "A18PaisId", StringUtil.LTrimStr( (decimal)(A18PaisId), 4, 0));
               A19PaisNombre = cgiGet( edtPaisNombre_Internalname);
               AssignAttri("", false, "A19PaisNombre", A19PaisNombre);
               /* Read subfile selected row values. */
               /* Read hidden variables. */
               GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
               forbiddenHiddens = new GXProperties();
               forbiddenHiddens.Add("hshsalt", "hsh"+"Pais");
               A18PaisId = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtPaisId_Internalname), ",", "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "A18PaisId", StringUtil.LTrimStr( (decimal)(A18PaisId), 4, 0));
               forbiddenHiddens.Add("PaisId", context.localUtil.Format( (decimal)(A18PaisId), "ZZZ9"));
               forbiddenHiddens.Add("Gx_mode", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")));
               hsh = cgiGet( "hsh");
               if ( ( ! ( ( A18PaisId != Z18PaisId ) ) || ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) ) && ! GXUtil.CheckEncryptedHash( forbiddenHiddens.ToString(), hsh, GXKey) )
               {
                  GXUtil.WriteLogError("pais:[ SecurityCheckFailed (403 Forbidden) value for]"+forbiddenHiddens.ToJSonString());
                  GxWebError = 1;
                  context.HttpContext.Response.StatusCode = 403;
                  context.WriteHtmlText( "<title>403 Forbidden</title>") ;
                  context.WriteHtmlText( "<h1>403 Forbidden</h1>") ;
                  context.WriteHtmlText( "<p /><hr />") ;
                  GXUtil.WriteLog("send_http_error_code " + 403.ToString());
                  AnyError = 1;
                  return  ;
               }
               /* Check if conditions changed and reset current page numbers */
               standaloneNotModal( ) ;
            }
            else
            {
               standaloneNotModal( ) ;
               if ( StringUtil.StrCmp(gxfirstwebparm, "viewer") == 0 )
               {
                  Gx_mode = "DSP";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  A18PaisId = (short)(Math.Round(NumberUtil.Val( GetPar( "PaisId"), "."), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, "A18PaisId", StringUtil.LTrimStr( (decimal)(A18PaisId), 4, 0));
                  getEqualNoModal( ) ;
                  if ( ! (0==AV7PaisId) )
                  {
                     A18PaisId = AV7PaisId;
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
                  Gx_mode = "DSP";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  disable_std_buttons( ) ;
                  standaloneModal( ) ;
               }
               else
               {
                  if ( IsDsp( ) )
                  {
                     sMode3 = Gx_mode;
                     Gx_mode = "UPD";
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                     if ( ! (0==AV7PaisId) )
                     {
                        A18PaisId = AV7PaisId;
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
                     Gx_mode = sMode3;
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                  }
                  standaloneModal( ) ;
                  if ( ! IsIns( ) )
                  {
                     getByPrimaryKey( ) ;
                     if ( RcdFound3 == 1 )
                     {
                        if ( IsDlt( ) )
                        {
                           /* Confirm record */
                           CONFIRM_030( ) ;
                           if ( AnyError == 0 )
                           {
                              GX_FocusControl = bttBtn_enter_Internalname;
                              AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                           }
                        }
                     }
                     else
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_noinsert", ""), 1, "PAISID");
                        AnyError = 1;
                        GX_FocusControl = edtPaisId_Internalname;
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
                           E11032 ();
                        }
                        else if ( StringUtil.StrCmp(sEvt, "AFTER TRN") == 0 )
                        {
                           context.wbHandled = 1;
                           dynload_actions( ) ;
                           /* Execute user event: After Trn */
                           E12032 ();
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
                        sEvtType = StringUtil.Right( sEvt, 4);
                        sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-4));
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
            E12032 ();
            trnEnded = 0;
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            if ( IsIns( )  )
            {
               /* Clear variables for new insertion. */
               InitAll033( ) ;
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
            DisableAttributes033( ) ;
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

      protected void CONFIRM_030( )
      {
         BeforeValidate033( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls033( ) ;
            }
            else
            {
               CheckExtendedTable033( ) ;
               CloseExtendedTableCursors033( ) ;
            }
         }
         if ( AnyError == 0 )
         {
            /* Save parent mode. */
            sMode3 = Gx_mode;
            CONFIRM_037( ) ;
            if ( AnyError == 0 )
            {
               /* Restore parent mode. */
               Gx_mode = sMode3;
               AssignAttri("", false, "Gx_mode", Gx_mode);
               IsConfirmed = 1;
               AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
            }
            /* Restore parent mode. */
            Gx_mode = sMode3;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
      }

      protected void CONFIRM_037( )
      {
         nGXsfl_48_idx = 0;
         while ( nGXsfl_48_idx < nRC_GXsfl_48 )
         {
            ReadRow037( ) ;
            if ( ( nRcdExists_7 != 0 ) || ( nIsMod_7 != 0 ) )
            {
               GetKey037( ) ;
               if ( ( nRcdExists_7 == 0 ) && ( nRcdDeleted_7 == 0 ) )
               {
                  if ( RcdFound7 == 0 )
                  {
                     Gx_mode = "INS";
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                     BeforeValidate037( ) ;
                     if ( AnyError == 0 )
                     {
                        CheckExtendedTable037( ) ;
                        CloseExtendedTableCursors037( ) ;
                        if ( AnyError == 0 )
                        {
                           IsConfirmed = 1;
                           AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
                        }
                     }
                  }
                  else
                  {
                     GXCCtl = "CIUDADID_" + sGXsfl_48_idx;
                     GX_msglist.addItem(context.GetMessage( "GXM_noupdate", ""), "DuplicatePrimaryKey", 1, GXCCtl);
                     AnyError = 1;
                     GX_FocusControl = edtCiudadId_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
               }
               else
               {
                  if ( RcdFound7 != 0 )
                  {
                     if ( nRcdDeleted_7 != 0 )
                     {
                        Gx_mode = "DLT";
                        AssignAttri("", false, "Gx_mode", Gx_mode);
                        getByPrimaryKey037( ) ;
                        Load037( ) ;
                        BeforeValidate037( ) ;
                        if ( AnyError == 0 )
                        {
                           OnDeleteControls037( ) ;
                        }
                     }
                     else
                     {
                        if ( nIsMod_7 != 0 )
                        {
                           Gx_mode = "UPD";
                           AssignAttri("", false, "Gx_mode", Gx_mode);
                           BeforeValidate037( ) ;
                           if ( AnyError == 0 )
                           {
                              CheckExtendedTable037( ) ;
                              CloseExtendedTableCursors037( ) ;
                              if ( AnyError == 0 )
                              {
                                 IsConfirmed = 1;
                                 AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
                              }
                           }
                        }
                     }
                  }
                  else
                  {
                     if ( nRcdDeleted_7 == 0 )
                     {
                        GXCCtl = "CIUDADID_" + sGXsfl_48_idx;
                        GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, GXCCtl);
                        AnyError = 1;
                        GX_FocusControl = edtCiudadId_Internalname;
                        AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     }
                  }
               }
            }
            ChangePostValue( edtCiudadId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A28CiudadId), 4, 0, ",", ""))) ;
            ChangePostValue( edtCiudadNombre_Internalname, A29CiudadNombre) ;
            ChangePostValue( "ZT_"+"Z28CiudadId_"+sGXsfl_48_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(Z28CiudadId), 4, 0, ",", ""))) ;
            ChangePostValue( "ZT_"+"Z29CiudadNombre_"+sGXsfl_48_idx, Z29CiudadNombre) ;
            ChangePostValue( "nRcdDeleted_7_"+sGXsfl_48_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdDeleted_7), 4, 0, ",", ""))) ;
            ChangePostValue( "nRcdExists_7_"+sGXsfl_48_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdExists_7), 4, 0, ",", ""))) ;
            ChangePostValue( "nIsMod_7_"+sGXsfl_48_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nIsMod_7), 4, 0, ",", ""))) ;
            if ( nIsMod_7 != 0 )
            {
               ChangePostValue( "CIUDADID_"+sGXsfl_48_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtCiudadId_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "CIUDADNOMBRE_"+sGXsfl_48_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtCiudadNombre_Enabled), 5, 0, ".", ""))) ;
            }
         }
         /* Start of After( level) rules */
         /* End of After( level) rules */
      }

      protected void ResetCaption030( )
      {
      }

      protected void E11032( )
      {
         /* Start Routine */
         returnInSub = false;
         if ( ! new GeneXus.Programs.general.security.isauthorized(context).executeUdp(  AV11Pgmname) )
         {
            CallWebObject(formatLink("general.security.notauthorized.aspx", new object[] {UrlEncode(StringUtil.RTrim(AV11Pgmname))}, new string[] {"GxObject"}) );
            context.wjLocDisableFrm = 1;
         }
         AV9TrnContext.FromXml(AV10WebSession.Get("TrnContext"), null, "", "");
         if ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 )
         {
            bttBtn_enter_Caption = "Eliminar";
            AssignProp("", false, bttBtn_enter_Internalname, "Caption", bttBtn_enter_Caption, true);
            bttBtn_enter_Tooltiptext = "Eliminar";
            AssignProp("", false, bttBtn_enter_Internalname, "Tooltiptext", bttBtn_enter_Tooltiptext, true);
         }
      }

      protected void E12032( )
      {
         /* After Trn Routine */
         returnInSub = false;
         if ( ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 ) && ! AV9TrnContext.gxTpr_Callerondelete )
         {
            CallWebObject(formatLink("wwpais.aspx") );
            context.wjLocDisableFrm = 1;
         }
         context.setWebReturnParms(new Object[] {});
         context.setWebReturnParmsMetadata(new Object[] {});
         context.wjLocDisableFrm = 1;
         context.nUserReturn = 1;
         returnInSub = true;
         if (true) return;
      }

      protected void ZM033( short GX_JID )
      {
         if ( ( GX_JID == 3 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z19PaisNombre = T00035_A19PaisNombre[0];
            }
            else
            {
               Z19PaisNombre = A19PaisNombre;
            }
         }
         if ( GX_JID == -3 )
         {
            Z18PaisId = A18PaisId;
            Z19PaisNombre = A19PaisNombre;
         }
      }

      protected void standaloneNotModal( )
      {
         edtPaisId_Enabled = 0;
         AssignProp("", false, edtPaisId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtPaisId_Enabled), 5, 0), true);
         Gx_BScreen = 0;
         AssignAttri("", false, "Gx_BScreen", StringUtil.Str( (decimal)(Gx_BScreen), 1, 0));
         edtPaisId_Enabled = 0;
         AssignProp("", false, edtPaisId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtPaisId_Enabled), 5, 0), true);
         bttBtn_delete_Enabled = 0;
         AssignProp("", false, bttBtn_delete_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_delete_Enabled), 5, 0), true);
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
         if ( ! (0==AV7PaisId) )
         {
            A18PaisId = AV7PaisId;
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
      }

      protected void Load033( )
      {
         /* Using cursor T00036 */
         pr_default.execute(4, new Object[] {A18PaisId});
         if ( (pr_default.getStatus(4) != 101) )
         {
            RcdFound3 = 1;
            A19PaisNombre = T00036_A19PaisNombre[0];
            AssignAttri("", false, "A19PaisNombre", A19PaisNombre);
            ZM033( -3) ;
         }
         pr_default.close(4);
         OnLoadActions033( ) ;
      }

      protected void OnLoadActions033( )
      {
         AV11Pgmname = "Pais";
         AssignAttri("", false, "AV11Pgmname", AV11Pgmname);
      }

      protected void CheckExtendedTable033( )
      {
         Gx_BScreen = 1;
         AssignAttri("", false, "Gx_BScreen", StringUtil.Str( (decimal)(Gx_BScreen), 1, 0));
         standaloneModal( ) ;
         AV11Pgmname = "Pais";
         AssignAttri("", false, "AV11Pgmname", AV11Pgmname);
      }

      protected void CloseExtendedTableCursors033( )
      {
      }

      protected void enableDisable( )
      {
      }

      protected void GetKey033( )
      {
         /* Using cursor T00037 */
         pr_default.execute(5, new Object[] {A18PaisId});
         if ( (pr_default.getStatus(5) != 101) )
         {
            RcdFound3 = 1;
         }
         else
         {
            RcdFound3 = 0;
         }
         pr_default.close(5);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor T00035 */
         pr_default.execute(3, new Object[] {A18PaisId});
         if ( (pr_default.getStatus(3) != 101) )
         {
            ZM033( 3) ;
            RcdFound3 = 1;
            A18PaisId = T00035_A18PaisId[0];
            AssignAttri("", false, "A18PaisId", StringUtil.LTrimStr( (decimal)(A18PaisId), 4, 0));
            A19PaisNombre = T00035_A19PaisNombre[0];
            AssignAttri("", false, "A19PaisNombre", A19PaisNombre);
            Z18PaisId = A18PaisId;
            sMode3 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            Load033( ) ;
            if ( AnyError == 1 )
            {
               RcdFound3 = 0;
               InitializeNonKey033( ) ;
            }
            Gx_mode = sMode3;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound3 = 0;
            InitializeNonKey033( ) ;
            sMode3 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Gx_mode = sMode3;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         pr_default.close(3);
      }

      protected void getEqualNoModal( )
      {
         GetKey033( ) ;
         if ( RcdFound3 == 0 )
         {
         }
         else
         {
         }
         getByPrimaryKey( ) ;
      }

      protected void move_next( )
      {
         RcdFound3 = 0;
         /* Using cursor T00038 */
         pr_default.execute(6, new Object[] {A18PaisId});
         if ( (pr_default.getStatus(6) != 101) )
         {
            while ( (pr_default.getStatus(6) != 101) && ( ( T00038_A18PaisId[0] < A18PaisId ) ) )
            {
               pr_default.readNext(6);
            }
            if ( (pr_default.getStatus(6) != 101) && ( ( T00038_A18PaisId[0] > A18PaisId ) ) )
            {
               A18PaisId = T00038_A18PaisId[0];
               AssignAttri("", false, "A18PaisId", StringUtil.LTrimStr( (decimal)(A18PaisId), 4, 0));
               RcdFound3 = 1;
            }
         }
         pr_default.close(6);
      }

      protected void move_previous( )
      {
         RcdFound3 = 0;
         /* Using cursor T00039 */
         pr_default.execute(7, new Object[] {A18PaisId});
         if ( (pr_default.getStatus(7) != 101) )
         {
            while ( (pr_default.getStatus(7) != 101) && ( ( T00039_A18PaisId[0] > A18PaisId ) ) )
            {
               pr_default.readNext(7);
            }
            if ( (pr_default.getStatus(7) != 101) && ( ( T00039_A18PaisId[0] < A18PaisId ) ) )
            {
               A18PaisId = T00039_A18PaisId[0];
               AssignAttri("", false, "A18PaisId", StringUtil.LTrimStr( (decimal)(A18PaisId), 4, 0));
               RcdFound3 = 1;
            }
         }
         pr_default.close(7);
      }

      protected void btn_enter( )
      {
         nKeyPressed = 1;
         GetKey033( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            GX_FocusControl = edtPaisNombre_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            Insert033( ) ;
            if ( AnyError == 1 )
            {
               GX_FocusControl = "";
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         else
         {
            if ( RcdFound3 == 1 )
            {
               if ( A18PaisId != Z18PaisId )
               {
                  A18PaisId = Z18PaisId;
                  AssignAttri("", false, "A18PaisId", StringUtil.LTrimStr( (decimal)(A18PaisId), 4, 0));
                  GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "CandidateKeyNotFound", 1, "PAISID");
                  AnyError = 1;
                  GX_FocusControl = edtPaisId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else if ( IsDlt( ) )
               {
                  delete( ) ;
                  AfterTrn( ) ;
                  GX_FocusControl = edtPaisNombre_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else
               {
                  /* Update record */
                  Update033( ) ;
                  GX_FocusControl = edtPaisNombre_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
            }
            else
            {
               if ( A18PaisId != Z18PaisId )
               {
                  /* Insert record */
                  GX_FocusControl = edtPaisNombre_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  Insert033( ) ;
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
                     GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "PAISID");
                     AnyError = 1;
                     GX_FocusControl = edtPaisId_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
                  else
                  {
                     /* Insert record */
                     GX_FocusControl = edtPaisNombre_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     Insert033( ) ;
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
         if ( A18PaisId != Z18PaisId )
         {
            A18PaisId = Z18PaisId;
            AssignAttri("", false, "A18PaisId", StringUtil.LTrimStr( (decimal)(A18PaisId), 4, 0));
            GX_msglist.addItem(context.GetMessage( "GXM_getbeforedlt", ""), 1, "PAISID");
            AnyError = 1;
            GX_FocusControl = edtPaisId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         else
         {
            delete( ) ;
            AfterTrn( ) ;
            GX_FocusControl = edtPaisNombre_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( AnyError != 0 )
         {
         }
      }

      protected void CheckOptimisticConcurrency033( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T00034 */
            pr_default.execute(2, new Object[] {A18PaisId});
            if ( (pr_default.getStatus(2) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Pais"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(2) == 101) || ( StringUtil.StrCmp(Z19PaisNombre, T00034_A19PaisNombre[0]) != 0 ) )
            {
               if ( StringUtil.StrCmp(Z19PaisNombre, T00034_A19PaisNombre[0]) != 0 )
               {
                  GXUtil.WriteLog("pais:[seudo value changed for attri]"+"PaisNombre");
                  GXUtil.WriteLogRaw("Old: ",Z19PaisNombre);
                  GXUtil.WriteLogRaw("Current: ",T00034_A19PaisNombre[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"Pais"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert033( )
      {
         BeforeValidate033( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable033( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM033( 0) ;
            CheckOptimisticConcurrency033( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm033( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert033( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000310 */
                     pr_default.execute(8, new Object[] {A19PaisNombre});
                     A18PaisId = T000310_A18PaisId[0];
                     AssignAttri("", false, "A18PaisId", StringUtil.LTrimStr( (decimal)(A18PaisId), 4, 0));
                     pr_default.close(8);
                     pr_default.SmartCacheProvider.SetUpdated("Pais");
                     if ( AnyError == 0 )
                     {
                        /* Start of After( Insert) rules */
                        /* End of After( Insert) rules */
                        if ( AnyError == 0 )
                        {
                           ProcessLevel033( ) ;
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
               Load033( ) ;
            }
            EndLevel033( ) ;
         }
         CloseExtendedTableCursors033( ) ;
      }

      protected void Update033( )
      {
         BeforeValidate033( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable033( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency033( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm033( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate033( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000311 */
                     pr_default.execute(9, new Object[] {A19PaisNombre, A18PaisId});
                     pr_default.close(9);
                     pr_default.SmartCacheProvider.SetUpdated("Pais");
                     if ( (pr_default.getStatus(9) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Pais"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate033( ) ;
                     if ( AnyError == 0 )
                     {
                        /* Start of After( update) rules */
                        /* End of After( update) rules */
                        if ( AnyError == 0 )
                        {
                           ProcessLevel033( ) ;
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
            }
            EndLevel033( ) ;
         }
         CloseExtendedTableCursors033( ) ;
      }

      protected void DeferredUpdate033( )
      {
      }

      protected void delete( )
      {
         BeforeValidate033( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency033( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls033( ) ;
            AfterConfirm033( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete033( ) ;
               if ( AnyError == 0 )
               {
                  ScanStart037( ) ;
                  while ( RcdFound7 != 0 )
                  {
                     getByPrimaryKey037( ) ;
                     Delete037( ) ;
                     ScanNext037( ) ;
                  }
                  ScanEnd037( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000312 */
                     pr_default.execute(10, new Object[] {A18PaisId});
                     pr_default.close(10);
                     pr_default.SmartCacheProvider.SetUpdated("Pais");
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
         }
         sMode3 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel033( ) ;
         Gx_mode = sMode3;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls033( )
      {
         standaloneModal( ) ;
         if ( AnyError == 0 )
         {
            /* Delete mode formulas */
            AV11Pgmname = "Pais";
            AssignAttri("", false, "AV11Pgmname", AV11Pgmname);
         }
         if ( AnyError == 0 )
         {
            /* Using cursor T000313 */
            pr_default.execute(11, new Object[] {A18PaisId});
            if ( (pr_default.getStatus(11) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"parque Atraccion"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(11);
         }
      }

      protected void ProcessNestedLevel037( )
      {
         nGXsfl_48_idx = 0;
         while ( nGXsfl_48_idx < nRC_GXsfl_48 )
         {
            ReadRow037( ) ;
            if ( ( nRcdExists_7 != 0 ) || ( nIsMod_7 != 0 ) )
            {
               standaloneNotModal037( ) ;
               GetKey037( ) ;
               if ( ( nRcdExists_7 == 0 ) && ( nRcdDeleted_7 == 0 ) )
               {
                  Gx_mode = "INS";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  Insert037( ) ;
               }
               else
               {
                  if ( RcdFound7 != 0 )
                  {
                     if ( ( nRcdDeleted_7 != 0 ) && ( nRcdExists_7 != 0 ) )
                     {
                        Gx_mode = "DLT";
                        AssignAttri("", false, "Gx_mode", Gx_mode);
                        Delete037( ) ;
                     }
                     else
                     {
                        if ( nRcdExists_7 != 0 )
                        {
                           Gx_mode = "UPD";
                           AssignAttri("", false, "Gx_mode", Gx_mode);
                           Update037( ) ;
                        }
                     }
                  }
                  else
                  {
                     if ( nRcdDeleted_7 == 0 )
                     {
                        GXCCtl = "CIUDADID_" + sGXsfl_48_idx;
                        GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, GXCCtl);
                        AnyError = 1;
                        GX_FocusControl = edtCiudadId_Internalname;
                        AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     }
                  }
               }
            }
            ChangePostValue( edtCiudadId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A28CiudadId), 4, 0, ",", ""))) ;
            ChangePostValue( edtCiudadNombre_Internalname, A29CiudadNombre) ;
            ChangePostValue( "ZT_"+"Z28CiudadId_"+sGXsfl_48_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(Z28CiudadId), 4, 0, ",", ""))) ;
            ChangePostValue( "ZT_"+"Z29CiudadNombre_"+sGXsfl_48_idx, Z29CiudadNombre) ;
            ChangePostValue( "nRcdDeleted_7_"+sGXsfl_48_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdDeleted_7), 4, 0, ",", ""))) ;
            ChangePostValue( "nRcdExists_7_"+sGXsfl_48_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdExists_7), 4, 0, ",", ""))) ;
            ChangePostValue( "nIsMod_7_"+sGXsfl_48_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nIsMod_7), 4, 0, ",", ""))) ;
            if ( nIsMod_7 != 0 )
            {
               ChangePostValue( "CIUDADID_"+sGXsfl_48_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtCiudadId_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "CIUDADNOMBRE_"+sGXsfl_48_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtCiudadNombre_Enabled), 5, 0, ".", ""))) ;
            }
         }
         /* Start of After( level) rules */
         /* End of After( level) rules */
         InitAll037( ) ;
         if ( AnyError != 0 )
         {
         }
         nRcdExists_7 = 0;
         nIsMod_7 = 0;
         nRcdDeleted_7 = 0;
      }

      protected void ProcessLevel033( )
      {
         /* Save parent mode. */
         sMode3 = Gx_mode;
         ProcessNestedLevel037( ) ;
         if ( AnyError != 0 )
         {
         }
         /* Restore parent mode. */
         Gx_mode = sMode3;
         AssignAttri("", false, "Gx_mode", Gx_mode);
         /* ' Update level parameters */
      }

      protected void EndLevel033( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(2);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete033( ) ;
         }
         if ( AnyError == 0 )
         {
            pr_default.close(3);
            pr_default.close(1);
            pr_default.close(0);
            context.CommitDataStores("pais",pr_default);
            if ( AnyError == 0 )
            {
               ConfirmValues030( ) ;
            }
            /* After transaction rules */
            /* Execute 'After Trn' event if defined. */
            trnEnded = 1;
         }
         else
         {
            pr_default.close(3);
            pr_default.close(1);
            pr_default.close(0);
            context.RollbackDataStores("pais",pr_default);
         }
         IsModified = 0;
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanStart033( )
      {
         /* Scan By routine */
         /* Using cursor T000314 */
         pr_default.execute(12);
         RcdFound3 = 0;
         if ( (pr_default.getStatus(12) != 101) )
         {
            RcdFound3 = 1;
            A18PaisId = T000314_A18PaisId[0];
            AssignAttri("", false, "A18PaisId", StringUtil.LTrimStr( (decimal)(A18PaisId), 4, 0));
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext033( )
      {
         /* Scan next routine */
         pr_default.readNext(12);
         RcdFound3 = 0;
         if ( (pr_default.getStatus(12) != 101) )
         {
            RcdFound3 = 1;
            A18PaisId = T000314_A18PaisId[0];
            AssignAttri("", false, "A18PaisId", StringUtil.LTrimStr( (decimal)(A18PaisId), 4, 0));
         }
      }

      protected void ScanEnd033( )
      {
         pr_default.close(12);
      }

      protected void AfterConfirm033( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert033( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate033( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete033( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete033( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate033( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes033( )
      {
         edtPaisId_Enabled = 0;
         AssignProp("", false, edtPaisId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtPaisId_Enabled), 5, 0), true);
         edtPaisNombre_Enabled = 0;
         AssignProp("", false, edtPaisNombre_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtPaisNombre_Enabled), 5, 0), true);
      }

      protected void ZM037( short GX_JID )
      {
         if ( ( GX_JID == 4 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z29CiudadNombre = T00033_A29CiudadNombre[0];
            }
            else
            {
               Z29CiudadNombre = A29CiudadNombre;
            }
         }
         if ( GX_JID == -4 )
         {
            Z18PaisId = A18PaisId;
            Z28CiudadId = A28CiudadId;
            Z29CiudadNombre = A29CiudadNombre;
         }
      }

      protected void standaloneNotModal037( )
      {
      }

      protected void standaloneModal037( )
      {
         if ( StringUtil.StrCmp(Gx_mode, "INS") != 0 )
         {
            edtCiudadId_Enabled = 0;
            AssignProp("", false, edtCiudadId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCiudadId_Enabled), 5, 0), !bGXsfl_48_Refreshing);
         }
         else
         {
            edtCiudadId_Enabled = 1;
            AssignProp("", false, edtCiudadId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCiudadId_Enabled), 5, 0), !bGXsfl_48_Refreshing);
         }
      }

      protected void Load037( )
      {
         /* Using cursor T000315 */
         pr_default.execute(13, new Object[] {A18PaisId, n28CiudadId, A28CiudadId});
         if ( (pr_default.getStatus(13) != 101) )
         {
            RcdFound7 = 1;
            A29CiudadNombre = T000315_A29CiudadNombre[0];
            ZM037( -4) ;
         }
         pr_default.close(13);
         OnLoadActions037( ) ;
      }

      protected void OnLoadActions037( )
      {
      }

      protected void CheckExtendedTable037( )
      {
         nIsDirty_7 = 0;
         Gx_BScreen = 1;
         AssignAttri("", false, "Gx_BScreen", StringUtil.Str( (decimal)(Gx_BScreen), 1, 0));
         standaloneModal037( ) ;
      }

      protected void CloseExtendedTableCursors037( )
      {
      }

      protected void enableDisable037( )
      {
      }

      protected void GetKey037( )
      {
         /* Using cursor T000316 */
         pr_default.execute(14, new Object[] {A18PaisId, n28CiudadId, A28CiudadId});
         if ( (pr_default.getStatus(14) != 101) )
         {
            RcdFound7 = 1;
         }
         else
         {
            RcdFound7 = 0;
         }
         pr_default.close(14);
      }

      protected void getByPrimaryKey037( )
      {
         /* Using cursor T00033 */
         pr_default.execute(1, new Object[] {A18PaisId, n28CiudadId, A28CiudadId});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM037( 4) ;
            RcdFound7 = 1;
            InitializeNonKey037( ) ;
            A28CiudadId = T00033_A28CiudadId[0];
            n28CiudadId = T00033_n28CiudadId[0];
            A29CiudadNombre = T00033_A29CiudadNombre[0];
            Z18PaisId = A18PaisId;
            Z28CiudadId = A28CiudadId;
            sMode7 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            Load037( ) ;
            Gx_mode = sMode7;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound7 = 0;
            InitializeNonKey037( ) ;
            sMode7 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal037( ) ;
            Gx_mode = sMode7;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         if ( IsDsp( ) || IsDlt( ) )
         {
            DisableAttributes037( ) ;
         }
         pr_default.close(1);
      }

      protected void CheckOptimisticConcurrency037( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T00032 */
            pr_default.execute(0, new Object[] {A18PaisId, n28CiudadId, A28CiudadId});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"PaisCiudad"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(0) == 101) || ( StringUtil.StrCmp(Z29CiudadNombre, T00032_A29CiudadNombre[0]) != 0 ) )
            {
               if ( StringUtil.StrCmp(Z29CiudadNombre, T00032_A29CiudadNombre[0]) != 0 )
               {
                  GXUtil.WriteLog("pais:[seudo value changed for attri]"+"CiudadNombre");
                  GXUtil.WriteLogRaw("Old: ",Z29CiudadNombre);
                  GXUtil.WriteLogRaw("Current: ",T00032_A29CiudadNombre[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"PaisCiudad"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert037( )
      {
         BeforeValidate037( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable037( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM037( 0) ;
            CheckOptimisticConcurrency037( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm037( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert037( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000317 */
                     pr_default.execute(15, new Object[] {A18PaisId, n28CiudadId, A28CiudadId, A29CiudadNombre});
                     pr_default.close(15);
                     pr_default.SmartCacheProvider.SetUpdated("PaisCiudad");
                     if ( (pr_default.getStatus(15) == 1) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_noupdate", ""), "DuplicatePrimaryKey", 1, "");
                        AnyError = 1;
                     }
                     if ( AnyError == 0 )
                     {
                        /* Start of After( Insert) rules */
                        /* End of After( Insert) rules */
                        if ( AnyError == 0 )
                        {
                           /* Save values for previous() function. */
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
               Load037( ) ;
            }
            EndLevel037( ) ;
         }
         CloseExtendedTableCursors037( ) ;
      }

      protected void Update037( )
      {
         BeforeValidate037( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable037( ) ;
         }
         if ( ( nIsMod_7 != 0 ) || ( nIsDirty_7 != 0 ) )
         {
            if ( AnyError == 0 )
            {
               CheckOptimisticConcurrency037( ) ;
               if ( AnyError == 0 )
               {
                  AfterConfirm037( ) ;
                  if ( AnyError == 0 )
                  {
                     BeforeUpdate037( ) ;
                     if ( AnyError == 0 )
                     {
                        /* Using cursor T000318 */
                        pr_default.execute(16, new Object[] {A29CiudadNombre, A18PaisId, n28CiudadId, A28CiudadId});
                        pr_default.close(16);
                        pr_default.SmartCacheProvider.SetUpdated("PaisCiudad");
                        if ( (pr_default.getStatus(16) == 103) )
                        {
                           GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"PaisCiudad"}), "RecordIsLocked", 1, "");
                           AnyError = 1;
                        }
                        DeferredUpdate037( ) ;
                        if ( AnyError == 0 )
                        {
                           /* Start of After( update) rules */
                           /* End of After( update) rules */
                           if ( AnyError == 0 )
                           {
                              getByPrimaryKey037( ) ;
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
               EndLevel037( ) ;
            }
         }
         CloseExtendedTableCursors037( ) ;
      }

      protected void DeferredUpdate037( )
      {
      }

      protected void Delete037( )
      {
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         BeforeValidate037( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency037( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls037( ) ;
            AfterConfirm037( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete037( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor T000319 */
                  pr_default.execute(17, new Object[] {A18PaisId, n28CiudadId, A28CiudadId});
                  pr_default.close(17);
                  pr_default.SmartCacheProvider.SetUpdated("PaisCiudad");
                  if ( AnyError == 0 )
                  {
                     /* Start of After( delete) rules */
                     /* End of After( delete) rules */
                  }
                  else
                  {
                     GX_msglist.addItem(context.GetMessage( "GXM_unexp", ""), 1, "");
                     AnyError = 1;
                  }
               }
            }
         }
         sMode7 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel037( ) ;
         Gx_mode = sMode7;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls037( )
      {
         standaloneModal037( ) ;
         /* No delete mode formulas found. */
         if ( AnyError == 0 )
         {
            /* Using cursor T000320 */
            pr_default.execute(18, new Object[] {A18PaisId, n28CiudadId, A28CiudadId});
            if ( (pr_default.getStatus(18) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"parque Atraccion"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(18);
         }
      }

      protected void EndLevel037( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanStart037( )
      {
         /* Scan By routine */
         /* Using cursor T000321 */
         pr_default.execute(19, new Object[] {A18PaisId});
         RcdFound7 = 0;
         if ( (pr_default.getStatus(19) != 101) )
         {
            RcdFound7 = 1;
            A28CiudadId = T000321_A28CiudadId[0];
            n28CiudadId = T000321_n28CiudadId[0];
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext037( )
      {
         /* Scan next routine */
         pr_default.readNext(19);
         RcdFound7 = 0;
         if ( (pr_default.getStatus(19) != 101) )
         {
            RcdFound7 = 1;
            A28CiudadId = T000321_A28CiudadId[0];
            n28CiudadId = T000321_n28CiudadId[0];
         }
      }

      protected void ScanEnd037( )
      {
         pr_default.close(19);
      }

      protected void AfterConfirm037( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert037( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate037( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete037( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete037( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate037( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes037( )
      {
         edtCiudadId_Enabled = 0;
         AssignProp("", false, edtCiudadId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCiudadId_Enabled), 5, 0), !bGXsfl_48_Refreshing);
         edtCiudadNombre_Enabled = 0;
         AssignProp("", false, edtCiudadNombre_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCiudadNombre_Enabled), 5, 0), !bGXsfl_48_Refreshing);
      }

      protected void send_integrity_lvl_hashes037( )
      {
      }

      protected void send_integrity_lvl_hashes033( )
      {
      }

      protected void SubsflControlProps_487( )
      {
         edtCiudadId_Internalname = "CIUDADID_"+sGXsfl_48_idx;
         edtCiudadNombre_Internalname = "CIUDADNOMBRE_"+sGXsfl_48_idx;
      }

      protected void SubsflControlProps_fel_487( )
      {
         edtCiudadId_Internalname = "CIUDADID_"+sGXsfl_48_fel_idx;
         edtCiudadNombre_Internalname = "CIUDADNOMBRE_"+sGXsfl_48_fel_idx;
      }

      protected void AddRow037( )
      {
         nGXsfl_48_idx = (int)(nGXsfl_48_idx+1);
         sGXsfl_48_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_48_idx), 4, 0), 4, "0");
         SubsflControlProps_487( ) ;
         SendRow037( ) ;
      }

      protected void SendRow037( )
      {
         Gridpais_ciudadRow = GXWebRow.GetNew(context);
         if ( subGridpais_ciudad_Backcolorstyle == 0 )
         {
            /* None style subfile background logic. */
            subGridpais_ciudad_Backstyle = 0;
            if ( StringUtil.StrCmp(subGridpais_ciudad_Class, "") != 0 )
            {
               subGridpais_ciudad_Linesclass = subGridpais_ciudad_Class+"Odd";
            }
         }
         else if ( subGridpais_ciudad_Backcolorstyle == 1 )
         {
            /* Uniform style subfile background logic. */
            subGridpais_ciudad_Backstyle = 0;
            subGridpais_ciudad_Backcolor = subGridpais_ciudad_Allbackcolor;
            if ( StringUtil.StrCmp(subGridpais_ciudad_Class, "") != 0 )
            {
               subGridpais_ciudad_Linesclass = subGridpais_ciudad_Class+"Uniform";
            }
         }
         else if ( subGridpais_ciudad_Backcolorstyle == 2 )
         {
            /* Header style subfile background logic. */
            subGridpais_ciudad_Backstyle = 1;
            if ( StringUtil.StrCmp(subGridpais_ciudad_Class, "") != 0 )
            {
               subGridpais_ciudad_Linesclass = subGridpais_ciudad_Class+"Odd";
            }
            subGridpais_ciudad_Backcolor = (int)(0x0);
         }
         else if ( subGridpais_ciudad_Backcolorstyle == 3 )
         {
            /* Report style subfile background logic. */
            subGridpais_ciudad_Backstyle = 1;
            if ( ((int)((nGXsfl_48_idx) % (2))) == 0 )
            {
               subGridpais_ciudad_Backcolor = (int)(0x0);
               if ( StringUtil.StrCmp(subGridpais_ciudad_Class, "") != 0 )
               {
                  subGridpais_ciudad_Linesclass = subGridpais_ciudad_Class+"Even";
               }
            }
            else
            {
               subGridpais_ciudad_Backcolor = (int)(0x0);
               if ( StringUtil.StrCmp(subGridpais_ciudad_Class, "") != 0 )
               {
                  subGridpais_ciudad_Linesclass = subGridpais_ciudad_Class+"Odd";
               }
            }
         }
         /* Subfile cell */
         /* Single line edit */
         TempTags = " data-gxoch1=\"gx.fn.setControlValue('nIsMod_7_" + sGXsfl_48_idx + "',1);\"  onfocus=\"gx.evt.onfocus(this, 49,'',false,'" + sGXsfl_48_idx + "',48)\"";
         ROClassString = "Attribute";
         Gridpais_ciudadRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtCiudadId_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A28CiudadId), 4, 0, ",", "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A28CiudadId), "ZZZ9"))," dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,49);\"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtCiudadId_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"",(string)"",(short)-1,(int)edtCiudadId_Enabled,(short)1,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)4,(short)0,(short)0,(short)48,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"end",(bool)false,(string)""});
         /* Subfile cell */
         /* Single line edit */
         TempTags = " data-gxoch1=\"gx.fn.setControlValue('nIsMod_7_" + sGXsfl_48_idx + "',1);\"  onfocus=\"gx.evt.onfocus(this, 50,'',false,'" + sGXsfl_48_idx + "',48)\"";
         ROClassString = "Attribute";
         Gridpais_ciudadRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtCiudadNombre_Internalname,(string)A29CiudadNombre,(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,50);\"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtCiudadNombre_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"",(string)"",(short)-1,(int)edtCiudadNombre_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)40,(short)0,(short)0,(short)48,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
         ajax_sending_grid_row(Gridpais_ciudadRow);
         send_integrity_lvl_hashes037( ) ;
         GXCCtl = "Z28CiudadId_" + sGXsfl_48_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(Z28CiudadId), 4, 0, ",", "")));
         GXCCtl = "Z29CiudadNombre_" + sGXsfl_48_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, Z29CiudadNombre);
         GXCCtl = "nRcdDeleted_7_" + sGXsfl_48_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdDeleted_7), 4, 0, ",", "")));
         GXCCtl = "nRcdExists_7_" + sGXsfl_48_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdExists_7), 4, 0, ",", "")));
         GXCCtl = "nIsMod_7_" + sGXsfl_48_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(nIsMod_7), 4, 0, ",", "")));
         GXCCtl = "vMODE_" + sGXsfl_48_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.RTrim( Gx_mode));
         GXCCtl = "vTRNCONTEXT_" + sGXsfl_48_idx;
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, GXCCtl, AV9TrnContext);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(GXCCtl, AV9TrnContext);
         }
         GXCCtl = "vPAISID_" + sGXsfl_48_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV7PaisId), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "CIUDADID_"+sGXsfl_48_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtCiudadId_Enabled), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "CIUDADNOMBRE_"+sGXsfl_48_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtCiudadNombre_Enabled), 5, 0, ".", "")));
         ajax_sending_grid_row(null);
         Gridpais_ciudadContainer.AddRow(Gridpais_ciudadRow);
      }

      protected void ReadRow037( )
      {
         nGXsfl_48_idx = (int)(nGXsfl_48_idx+1);
         sGXsfl_48_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_48_idx), 4, 0), 4, "0");
         SubsflControlProps_487( ) ;
         edtCiudadId_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "CIUDADID_"+sGXsfl_48_idx+"Enabled"), ",", "."), 18, MidpointRounding.ToEven));
         edtCiudadNombre_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "CIUDADNOMBRE_"+sGXsfl_48_idx+"Enabled"), ",", "."), 18, MidpointRounding.ToEven));
         if ( ( ( context.localUtil.CToN( cgiGet( edtCiudadId_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtCiudadId_Internalname), ",", ".") > Convert.ToDecimal( 9999 )) ) )
         {
            GXCCtl = "CIUDADID_" + sGXsfl_48_idx;
            GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, GXCCtl);
            AnyError = 1;
            GX_FocusControl = edtCiudadId_Internalname;
            wbErr = true;
            A28CiudadId = 0;
            n28CiudadId = false;
         }
         else
         {
            A28CiudadId = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtCiudadId_Internalname), ",", "."), 18, MidpointRounding.ToEven));
            n28CiudadId = false;
         }
         A29CiudadNombre = cgiGet( edtCiudadNombre_Internalname);
         GXCCtl = "Z28CiudadId_" + sGXsfl_48_idx;
         Z28CiudadId = (short)(Math.Round(context.localUtil.CToN( cgiGet( GXCCtl), ",", "."), 18, MidpointRounding.ToEven));
         GXCCtl = "Z29CiudadNombre_" + sGXsfl_48_idx;
         Z29CiudadNombre = cgiGet( GXCCtl);
         GXCCtl = "nRcdDeleted_7_" + sGXsfl_48_idx;
         nRcdDeleted_7 = (short)(Math.Round(context.localUtil.CToN( cgiGet( GXCCtl), ",", "."), 18, MidpointRounding.ToEven));
         GXCCtl = "nRcdExists_7_" + sGXsfl_48_idx;
         nRcdExists_7 = (short)(Math.Round(context.localUtil.CToN( cgiGet( GXCCtl), ",", "."), 18, MidpointRounding.ToEven));
         GXCCtl = "nIsMod_7_" + sGXsfl_48_idx;
         nIsMod_7 = (short)(Math.Round(context.localUtil.CToN( cgiGet( GXCCtl), ",", "."), 18, MidpointRounding.ToEven));
      }

      protected void assign_properties_default( )
      {
         defedtCiudadId_Enabled = edtCiudadId_Enabled;
      }

      protected void ConfirmValues030( )
      {
         nGXsfl_48_idx = 0;
         sGXsfl_48_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_48_idx), 4, 0), 4, "0");
         SubsflControlProps_487( ) ;
         while ( nGXsfl_48_idx < nRC_GXsfl_48 )
         {
            nGXsfl_48_idx = (int)(nGXsfl_48_idx+1);
            sGXsfl_48_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_48_idx), 4, 0), 4, "0");
            SubsflControlProps_487( ) ;
            ChangePostValue( "Z28CiudadId_"+sGXsfl_48_idx, cgiGet( "ZT_"+"Z28CiudadId_"+sGXsfl_48_idx)) ;
            DeletePostValue( "ZT_"+"Z28CiudadId_"+sGXsfl_48_idx) ;
            ChangePostValue( "Z29CiudadNombre_"+sGXsfl_48_idx, cgiGet( "ZT_"+"Z29CiudadNombre_"+sGXsfl_48_idx)) ;
            DeletePostValue( "ZT_"+"Z29CiudadNombre_"+sGXsfl_48_idx) ;
         }
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("pais.aspx", new object[] {UrlEncode(StringUtil.RTrim(Gx_mode)),UrlEncode(StringUtil.LTrimStr(AV7PaisId,4,0))}, new string[] {"Gx_mode","PaisId"}) +"\">") ;
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
         forbiddenHiddens.Add("hshsalt", "hsh"+"Pais");
         forbiddenHiddens.Add("PaisId", context.localUtil.Format( (decimal)(A18PaisId), "ZZZ9"));
         forbiddenHiddens.Add("Gx_mode", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")));
         GxWebStd.gx_hidden_field( context, "hsh", GetEncryptedHash( forbiddenHiddens.ToString(), GXKey));
         GXUtil.WriteLogInfo("pais:[ SendSecurityCheck value for]"+forbiddenHiddens.ToJSonString());
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "Z18PaisId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z18PaisId), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "Z19PaisNombre", Z19PaisNombre);
         GxWebStd.gx_hidden_field( context, "IsConfirmed", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsConfirmed), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "IsModified", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsModified), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "Mode", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "gxhash_Mode", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")), context));
         GxWebStd.gx_hidden_field( context, "nRC_GXsfl_48", StringUtil.LTrim( StringUtil.NToC( (decimal)(nGXsfl_48_idx), 8, 0, ",", "")));
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
         GxWebStd.gx_hidden_field( context, "vPAISID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV7PaisId), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vPAISID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV7PaisId), "ZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "vGXBSCREEN", StringUtil.LTrim( StringUtil.NToC( (decimal)(Gx_BScreen), 1, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "vPGMNAME", StringUtil.RTrim( AV11Pgmname));
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
         return formatLink("pais.aspx", new object[] {UrlEncode(StringUtil.RTrim(Gx_mode)),UrlEncode(StringUtil.LTrimStr(AV7PaisId,4,0))}, new string[] {"Gx_mode","PaisId"})  ;
      }

      public override string GetPgmname( )
      {
         return "Pais" ;
      }

      public override string GetPgmdesc( )
      {
         return "Pais" ;
      }

      protected void InitializeNonKey033( )
      {
         A19PaisNombre = "";
         AssignAttri("", false, "A19PaisNombre", A19PaisNombre);
         Z19PaisNombre = "";
      }

      protected void InitAll033( )
      {
         A18PaisId = 1;
         AssignAttri("", false, "A18PaisId", StringUtil.LTrimStr( (decimal)(A18PaisId), 4, 0));
         InitializeNonKey033( ) ;
      }

      protected void StandaloneModalInsert( )
      {
      }

      protected void InitializeNonKey037( )
      {
         A29CiudadNombre = "";
         Z29CiudadNombre = "";
      }

      protected void InitAll037( )
      {
         A28CiudadId = 0;
         n28CiudadId = false;
         InitializeNonKey037( ) ;
      }

      protected void StandaloneModalInsert037( )
      {
      }

      protected void define_styles( )
      {
         AddThemeStyleSheetFile("", context.GetTheme( )+".css", "?"+GetCacheInvalidationToken( ));
         bool outputEnabled = isOutputEnabled( );
         if ( context.isSpaRequest( ) )
         {
            enableOutput();
         }
         idxLst = 1;
         while ( idxLst <= Form.Jscriptsrc.Count )
         {
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?202541223451653", true, true);
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
         context.AddJavascriptSource("pais.js", "?202541223451653", false, true);
         /* End function include_jscripts */
      }

      protected void init_level_properties7( )
      {
         edtCiudadId_Enabled = defedtCiudadId_Enabled;
         AssignProp("", false, edtCiudadId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCiudadId_Enabled), 5, 0), !bGXsfl_48_Refreshing);
      }

      protected void StartGridControl48( )
      {
         Gridpais_ciudadContainer.AddObjectProperty("GridName", "Gridpais_ciudad");
         Gridpais_ciudadContainer.AddObjectProperty("Header", subGridpais_ciudad_Header);
         Gridpais_ciudadContainer.AddObjectProperty("Class", "Grid");
         Gridpais_ciudadContainer.AddObjectProperty("Cellpadding", StringUtil.LTrim( StringUtil.NToC( (decimal)(1), 4, 0, ".", "")));
         Gridpais_ciudadContainer.AddObjectProperty("Cellspacing", StringUtil.LTrim( StringUtil.NToC( (decimal)(2), 4, 0, ".", "")));
         Gridpais_ciudadContainer.AddObjectProperty("Backcolorstyle", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridpais_ciudad_Backcolorstyle), 1, 0, ".", "")));
         Gridpais_ciudadContainer.AddObjectProperty("CmpContext", "");
         Gridpais_ciudadContainer.AddObjectProperty("InMasterPage", "false");
         Gridpais_ciudadColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Gridpais_ciudadColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A28CiudadId), 4, 0, ".", ""))));
         Gridpais_ciudadColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtCiudadId_Enabled), 5, 0, ".", "")));
         Gridpais_ciudadContainer.AddColumnProperties(Gridpais_ciudadColumn);
         Gridpais_ciudadColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Gridpais_ciudadColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A29CiudadNombre));
         Gridpais_ciudadColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtCiudadNombre_Enabled), 5, 0, ".", "")));
         Gridpais_ciudadContainer.AddColumnProperties(Gridpais_ciudadColumn);
         Gridpais_ciudadContainer.AddObjectProperty("Selectedindex", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridpais_ciudad_Selectedindex), 4, 0, ".", "")));
         Gridpais_ciudadContainer.AddObjectProperty("Allowselection", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridpais_ciudad_Allowselection), 1, 0, ".", "")));
         Gridpais_ciudadContainer.AddObjectProperty("Selectioncolor", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridpais_ciudad_Selectioncolor), 9, 0, ".", "")));
         Gridpais_ciudadContainer.AddObjectProperty("Allowhover", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridpais_ciudad_Allowhovering), 1, 0, ".", "")));
         Gridpais_ciudadContainer.AddObjectProperty("Hovercolor", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridpais_ciudad_Hoveringcolor), 9, 0, ".", "")));
         Gridpais_ciudadContainer.AddObjectProperty("Allowcollapsing", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridpais_ciudad_Allowcollapsing), 1, 0, ".", "")));
         Gridpais_ciudadContainer.AddObjectProperty("Collapsed", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridpais_ciudad_Collapsed), 1, 0, ".", "")));
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
         edtPaisId_Internalname = "PAISID";
         edtPaisNombre_Internalname = "PAISNOMBRE";
         lblTitleciudad_Internalname = "TITLECIUDAD";
         edtCiudadId_Internalname = "CIUDADID";
         edtCiudadNombre_Internalname = "CIUDADNOMBRE";
         divCiudadtable_Internalname = "CIUDADTABLE";
         divFormcontainer_Internalname = "FORMCONTAINER";
         bttBtn_enter_Internalname = "BTN_ENTER";
         bttBtn_cancel_Internalname = "BTN_CANCEL";
         bttBtn_delete_Internalname = "BTN_DELETE";
         divMaintable_Internalname = "MAINTABLE";
         Form.Internalname = "FORM";
         subGridpais_ciudad_Internalname = "GRIDPAIS_CIUDAD";
      }

      public override void initialize_properties( )
      {
         context.SetDefaultTheme("parques", true);
         if ( context.isSpaRequest( ) )
         {
            disableJsOutput();
         }
         init_default_properties( ) ;
         subGridpais_ciudad_Allowcollapsing = 0;
         subGridpais_ciudad_Allowselection = 0;
         subGridpais_ciudad_Header = "";
         Form.Headerrawhtml = "";
         Form.Background = "";
         Form.Textcolor = 0;
         Form.Backcolor = (int)(0xFFFFFF);
         Form.Caption = "Pais";
         edtCiudadNombre_Jsonclick = "";
         edtCiudadId_Jsonclick = "";
         subGridpais_ciudad_Class = "Grid";
         subGridpais_ciudad_Backcolorstyle = 0;
         edtCiudadNombre_Enabled = 1;
         edtCiudadId_Enabled = 1;
         bttBtn_delete_Enabled = 0;
         bttBtn_delete_Visible = 1;
         bttBtn_cancel_Visible = 1;
         bttBtn_enter_Tooltiptext = "Confirmar";
         bttBtn_enter_Caption = "Confirmar";
         bttBtn_enter_Enabled = 1;
         bttBtn_enter_Visible = 1;
         edtPaisNombre_Jsonclick = "";
         edtPaisNombre_Enabled = 1;
         edtPaisId_Jsonclick = "";
         edtPaisId_Enabled = 0;
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

      protected void gxnrGridpais_ciudad_newrow( )
      {
         GxWebStd.set_html_headers( context, 0, "", "");
         Gx_mode = "INS";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         SubsflControlProps_487( ) ;
         while ( nGXsfl_48_idx <= nRC_GXsfl_48 )
         {
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            standaloneNotModal037( ) ;
            standaloneModal037( ) ;
            init_web_controls( ) ;
            dynload_actions( ) ;
            SendRow037( ) ;
            nGXsfl_48_idx = (int)(nGXsfl_48_idx+1);
            sGXsfl_48_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_48_idx), 4, 0), 4, "0");
            SubsflControlProps_487( ) ;
         }
         AddString( context.httpAjaxContext.getJSONContainerResponse( Gridpais_ciudadContainer)) ;
         /* End function gxnrGridpais_ciudad_newrow */
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

      public override bool SupportAjaxEvent( )
      {
         return true ;
      }

      public override void InitializeDynEvents( )
      {
         setEventMetadata("ENTER","""{"handler":"UserMainFullajax","iparms":[{"postForm":true},{"av":"Gx_mode","fld":"vMODE","pic":"@!","hsh":true},{"av":"AV7PaisId","fld":"vPAISID","pic":"ZZZ9","hsh":true}]}""");
         setEventMetadata("REFRESH","""{"handler":"Refresh","iparms":[{"av":"Gx_mode","fld":"vMODE","pic":"@!","hsh":true},{"av":"AV9TrnContext","fld":"vTRNCONTEXT","hsh":true},{"av":"AV7PaisId","fld":"vPAISID","pic":"ZZZ9","hsh":true},{"av":"A18PaisId","fld":"PAISID","pic":"ZZZ9"}]}""");
         setEventMetadata("AFTER TRN","""{"handler":"E12032","iparms":[{"av":"Gx_mode","fld":"vMODE","pic":"@!","hsh":true},{"av":"AV9TrnContext","fld":"vTRNCONTEXT","hsh":true}]}""");
         setEventMetadata("VALID_PAISID","""{"handler":"Valid_Paisid","iparms":[]}""");
         setEventMetadata("VALID_CIUDADID","""{"handler":"Valid_Ciudadid","iparms":[]}""");
         setEventMetadata("NULL","""{"handler":"Valid_Ciudadnombre","iparms":[]}""");
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
         pr_default.close(3);
      }

      public override void initialize( )
      {
         sPrefix = "";
         wcpOGx_mode = "";
         Z19PaisNombre = "";
         Z29CiudadNombre = "";
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
         A19PaisNombre = "";
         lblTitleciudad_Jsonclick = "";
         bttBtn_enter_Jsonclick = "";
         bttBtn_cancel_Jsonclick = "";
         bttBtn_delete_Jsonclick = "";
         Gridpais_ciudadContainer = new GXWebGrid( context);
         sMode7 = "";
         sStyleString = "";
         AV11Pgmname = "";
         forbiddenHiddens = new GXProperties();
         hsh = "";
         sMode3 = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         endTrnMsgTxt = "";
         endTrnMsgCod = "";
         GXCCtl = "";
         A29CiudadNombre = "";
         AV9TrnContext = new GeneXus.Programs.general.ui.SdtTransactionContext(context);
         AV10WebSession = context.GetSession();
         T00036_A18PaisId = new short[1] ;
         T00036_A19PaisNombre = new string[] {""} ;
         T00037_A18PaisId = new short[1] ;
         T00035_A18PaisId = new short[1] ;
         T00035_A19PaisNombre = new string[] {""} ;
         T00038_A18PaisId = new short[1] ;
         T00039_A18PaisId = new short[1] ;
         T00034_A18PaisId = new short[1] ;
         T00034_A19PaisNombre = new string[] {""} ;
         T000310_A18PaisId = new short[1] ;
         T000313_A13parqueAtraccionId = new short[1] ;
         T000314_A18PaisId = new short[1] ;
         T000315_A18PaisId = new short[1] ;
         T000315_A28CiudadId = new short[1] ;
         T000315_n28CiudadId = new bool[] {false} ;
         T000315_A29CiudadNombre = new string[] {""} ;
         T000316_A18PaisId = new short[1] ;
         T000316_A28CiudadId = new short[1] ;
         T000316_n28CiudadId = new bool[] {false} ;
         T00033_A18PaisId = new short[1] ;
         T00033_A28CiudadId = new short[1] ;
         T00033_n28CiudadId = new bool[] {false} ;
         T00033_A29CiudadNombre = new string[] {""} ;
         T00032_A18PaisId = new short[1] ;
         T00032_A28CiudadId = new short[1] ;
         T00032_n28CiudadId = new bool[] {false} ;
         T00032_A29CiudadNombre = new string[] {""} ;
         T000320_A13parqueAtraccionId = new short[1] ;
         T000321_A18PaisId = new short[1] ;
         T000321_A28CiudadId = new short[1] ;
         T000321_n28CiudadId = new bool[] {false} ;
         Gridpais_ciudadRow = new GXWebRow();
         subGridpais_ciudad_Linesclass = "";
         ROClassString = "";
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         Gridpais_ciudadColumn = new GXWebColumn();
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.pais__default(),
            new Object[][] {
                new Object[] {
               T00032_A18PaisId, T00032_A28CiudadId, T00032_A29CiudadNombre
               }
               , new Object[] {
               T00033_A18PaisId, T00033_A28CiudadId, T00033_A29CiudadNombre
               }
               , new Object[] {
               T00034_A18PaisId, T00034_A19PaisNombre
               }
               , new Object[] {
               T00035_A18PaisId, T00035_A19PaisNombre
               }
               , new Object[] {
               T00036_A18PaisId, T00036_A19PaisNombre
               }
               , new Object[] {
               T00037_A18PaisId
               }
               , new Object[] {
               T00038_A18PaisId
               }
               , new Object[] {
               T00039_A18PaisId
               }
               , new Object[] {
               T000310_A18PaisId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T000313_A13parqueAtraccionId
               }
               , new Object[] {
               T000314_A18PaisId
               }
               , new Object[] {
               T000315_A18PaisId, T000315_A28CiudadId, T000315_A29CiudadNombre
               }
               , new Object[] {
               T000316_A18PaisId, T000316_A28CiudadId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T000320_A13parqueAtraccionId
               }
               , new Object[] {
               T000321_A18PaisId, T000321_A28CiudadId
               }
            }
         );
         Z18PaisId = 1;
         A18PaisId = 1;
         AV11Pgmname = "Pais";
      }

      private short wcpOAV7PaisId ;
      private short Z18PaisId ;
      private short Z28CiudadId ;
      private short nRcdDeleted_7 ;
      private short nRcdExists_7 ;
      private short nIsMod_7 ;
      private short GxWebError ;
      private short AV7PaisId ;
      private short gxcookieaux ;
      private short AnyError ;
      private short IsModified ;
      private short IsConfirmed ;
      private short nKeyPressed ;
      private short A18PaisId ;
      private short nBlankRcdCount7 ;
      private short RcdFound7 ;
      private short nBlankRcdUsr7 ;
      private short Gx_BScreen ;
      private short RcdFound3 ;
      private short A28CiudadId ;
      private short nIsDirty_7 ;
      private short subGridpais_ciudad_Backcolorstyle ;
      private short subGridpais_ciudad_Backstyle ;
      private short gxajaxcallmode ;
      private short subGridpais_ciudad_Allowselection ;
      private short subGridpais_ciudad_Allowhovering ;
      private short subGridpais_ciudad_Allowcollapsing ;
      private short subGridpais_ciudad_Collapsed ;
      private int nRC_GXsfl_48 ;
      private int nGXsfl_48_idx=1 ;
      private int trnEnded ;
      private int bttBtn_first_Visible ;
      private int bttBtn_previous_Visible ;
      private int bttBtn_next_Visible ;
      private int bttBtn_last_Visible ;
      private int bttBtn_select_Visible ;
      private int edtPaisId_Enabled ;
      private int edtPaisNombre_Enabled ;
      private int bttBtn_enter_Visible ;
      private int bttBtn_enter_Enabled ;
      private int bttBtn_cancel_Visible ;
      private int bttBtn_delete_Visible ;
      private int bttBtn_delete_Enabled ;
      private int edtCiudadId_Enabled ;
      private int edtCiudadNombre_Enabled ;
      private int fRowAdded ;
      private int subGridpais_ciudad_Backcolor ;
      private int subGridpais_ciudad_Allbackcolor ;
      private int defedtCiudadId_Enabled ;
      private int idxLst ;
      private int subGridpais_ciudad_Selectedindex ;
      private int subGridpais_ciudad_Selectioncolor ;
      private int subGridpais_ciudad_Hoveringcolor ;
      private long GRIDPAIS_CIUDAD_nFirstRecordOnPage ;
      private string sPrefix ;
      private string wcpOGx_mode ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string Gx_mode ;
      private string GXKey ;
      private string PreviousTooltip ;
      private string PreviousCaption ;
      private string GX_FocusControl ;
      private string edtPaisNombre_Internalname ;
      private string sGXsfl_48_idx="0001" ;
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
      private string edtPaisId_Internalname ;
      private string edtPaisId_Jsonclick ;
      private string edtPaisNombre_Jsonclick ;
      private string divCiudadtable_Internalname ;
      private string lblTitleciudad_Internalname ;
      private string lblTitleciudad_Jsonclick ;
      private string bttBtn_enter_Internalname ;
      private string bttBtn_enter_Caption ;
      private string bttBtn_enter_Jsonclick ;
      private string bttBtn_enter_Tooltiptext ;
      private string bttBtn_cancel_Internalname ;
      private string bttBtn_cancel_Jsonclick ;
      private string bttBtn_delete_Internalname ;
      private string bttBtn_delete_Jsonclick ;
      private string sMode7 ;
      private string edtCiudadId_Internalname ;
      private string edtCiudadNombre_Internalname ;
      private string sStyleString ;
      private string subGridpais_ciudad_Internalname ;
      private string AV11Pgmname ;
      private string hsh ;
      private string sMode3 ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string endTrnMsgTxt ;
      private string endTrnMsgCod ;
      private string GXCCtl ;
      private string sGXsfl_48_fel_idx="0001" ;
      private string subGridpais_ciudad_Class ;
      private string subGridpais_ciudad_Linesclass ;
      private string ROClassString ;
      private string edtCiudadId_Jsonclick ;
      private string edtCiudadNombre_Jsonclick ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string subGridpais_ciudad_Header ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool wbErr ;
      private bool bGXsfl_48_Refreshing=false ;
      private bool returnInSub ;
      private bool n28CiudadId ;
      private string Z19PaisNombre ;
      private string Z29CiudadNombre ;
      private string A19PaisNombre ;
      private string A29CiudadNombre ;
      private IGxSession AV10WebSession ;
      private GXProperties forbiddenHiddens ;
      private GXWebGrid Gridpais_ciudadContainer ;
      private GXWebRow Gridpais_ciudadRow ;
      private GXWebColumn Gridpais_ciudadColumn ;
      private GXWebForm Form ;
      private IGxDataStore dsDefault ;
      private GeneXus.Programs.general.ui.SdtTransactionContext AV9TrnContext ;
      private IDataStoreProvider pr_default ;
      private short[] T00036_A18PaisId ;
      private string[] T00036_A19PaisNombre ;
      private short[] T00037_A18PaisId ;
      private short[] T00035_A18PaisId ;
      private string[] T00035_A19PaisNombre ;
      private short[] T00038_A18PaisId ;
      private short[] T00039_A18PaisId ;
      private short[] T00034_A18PaisId ;
      private string[] T00034_A19PaisNombre ;
      private short[] T000310_A18PaisId ;
      private short[] T000313_A13parqueAtraccionId ;
      private short[] T000314_A18PaisId ;
      private short[] T000315_A18PaisId ;
      private short[] T000315_A28CiudadId ;
      private bool[] T000315_n28CiudadId ;
      private string[] T000315_A29CiudadNombre ;
      private short[] T000316_A18PaisId ;
      private short[] T000316_A28CiudadId ;
      private bool[] T000316_n28CiudadId ;
      private short[] T00033_A18PaisId ;
      private short[] T00033_A28CiudadId ;
      private bool[] T00033_n28CiudadId ;
      private string[] T00033_A29CiudadNombre ;
      private short[] T00032_A18PaisId ;
      private short[] T00032_A28CiudadId ;
      private bool[] T00032_n28CiudadId ;
      private string[] T00032_A29CiudadNombre ;
      private short[] T000320_A13parqueAtraccionId ;
      private short[] T000321_A18PaisId ;
      private short[] T000321_A28CiudadId ;
      private bool[] T000321_n28CiudadId ;
   }

   public class pais__default : DataStoreHelperBase, IDataStoreHelper
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
         ,new ForEachCursor(def[13])
         ,new ForEachCursor(def[14])
         ,new UpdateCursor(def[15])
         ,new UpdateCursor(def[16])
         ,new UpdateCursor(def[17])
         ,new ForEachCursor(def[18])
         ,new ForEachCursor(def[19])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmT00032;
          prmT00032 = new Object[] {
          new ParDef("@PaisId",GXType.Int16,4,0) ,
          new ParDef("@CiudadId",GXType.Int16,4,0){Nullable=true}
          };
          Object[] prmT00033;
          prmT00033 = new Object[] {
          new ParDef("@PaisId",GXType.Int16,4,0) ,
          new ParDef("@CiudadId",GXType.Int16,4,0){Nullable=true}
          };
          Object[] prmT00034;
          prmT00034 = new Object[] {
          new ParDef("@PaisId",GXType.Int16,4,0)
          };
          Object[] prmT00035;
          prmT00035 = new Object[] {
          new ParDef("@PaisId",GXType.Int16,4,0)
          };
          Object[] prmT00036;
          prmT00036 = new Object[] {
          new ParDef("@PaisId",GXType.Int16,4,0)
          };
          Object[] prmT00037;
          prmT00037 = new Object[] {
          new ParDef("@PaisId",GXType.Int16,4,0)
          };
          Object[] prmT00038;
          prmT00038 = new Object[] {
          new ParDef("@PaisId",GXType.Int16,4,0)
          };
          Object[] prmT00039;
          prmT00039 = new Object[] {
          new ParDef("@PaisId",GXType.Int16,4,0)
          };
          Object[] prmT000310;
          prmT000310 = new Object[] {
          new ParDef("@PaisNombre",GXType.NVarChar,50,0)
          };
          Object[] prmT000311;
          prmT000311 = new Object[] {
          new ParDef("@PaisNombre",GXType.NVarChar,50,0) ,
          new ParDef("@PaisId",GXType.Int16,4,0)
          };
          Object[] prmT000312;
          prmT000312 = new Object[] {
          new ParDef("@PaisId",GXType.Int16,4,0)
          };
          Object[] prmT000313;
          prmT000313 = new Object[] {
          new ParDef("@PaisId",GXType.Int16,4,0)
          };
          Object[] prmT000314;
          prmT000314 = new Object[] {
          };
          Object[] prmT000315;
          prmT000315 = new Object[] {
          new ParDef("@PaisId",GXType.Int16,4,0) ,
          new ParDef("@CiudadId",GXType.Int16,4,0){Nullable=true}
          };
          Object[] prmT000316;
          prmT000316 = new Object[] {
          new ParDef("@PaisId",GXType.Int16,4,0) ,
          new ParDef("@CiudadId",GXType.Int16,4,0){Nullable=true}
          };
          Object[] prmT000317;
          prmT000317 = new Object[] {
          new ParDef("@PaisId",GXType.Int16,4,0) ,
          new ParDef("@CiudadId",GXType.Int16,4,0){Nullable=true} ,
          new ParDef("@CiudadNombre",GXType.NVarChar,40,0)
          };
          Object[] prmT000318;
          prmT000318 = new Object[] {
          new ParDef("@CiudadNombre",GXType.NVarChar,40,0) ,
          new ParDef("@PaisId",GXType.Int16,4,0) ,
          new ParDef("@CiudadId",GXType.Int16,4,0){Nullable=true}
          };
          Object[] prmT000319;
          prmT000319 = new Object[] {
          new ParDef("@PaisId",GXType.Int16,4,0) ,
          new ParDef("@CiudadId",GXType.Int16,4,0){Nullable=true}
          };
          Object[] prmT000320;
          prmT000320 = new Object[] {
          new ParDef("@PaisId",GXType.Int16,4,0) ,
          new ParDef("@CiudadId",GXType.Int16,4,0){Nullable=true}
          };
          Object[] prmT000321;
          prmT000321 = new Object[] {
          new ParDef("@PaisId",GXType.Int16,4,0)
          };
          def= new CursorDef[] {
              new CursorDef("T00032", "SELECT [PaisId], [CiudadId], [CiudadNombre] FROM [PaisCiudad] WITH (UPDLOCK) WHERE [PaisId] = @PaisId AND [CiudadId] = @CiudadId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00032,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00033", "SELECT [PaisId], [CiudadId], [CiudadNombre] FROM [PaisCiudad] WHERE [PaisId] = @PaisId AND [CiudadId] = @CiudadId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00033,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00034", "SELECT [PaisId], [PaisNombre] FROM [Pais] WITH (UPDLOCK) WHERE [PaisId] = @PaisId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00034,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00035", "SELECT [PaisId], [PaisNombre] FROM [Pais] WHERE [PaisId] = @PaisId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00035,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00036", "SELECT TM1.[PaisId], TM1.[PaisNombre] FROM [Pais] TM1 WHERE TM1.[PaisId] = @PaisId ORDER BY TM1.[PaisId]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT00036,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00037", "SELECT [PaisId] FROM [Pais] WHERE [PaisId] = @PaisId  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT00037,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00038", "SELECT TOP 1 [PaisId] FROM [Pais] WHERE ( [PaisId] > @PaisId) ORDER BY [PaisId]  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT00038,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T00039", "SELECT TOP 1 [PaisId] FROM [Pais] WHERE ( [PaisId] < @PaisId) ORDER BY [PaisId] DESC  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT00039,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T000310", "INSERT INTO [Pais]([PaisNombre]) VALUES(@PaisNombre); SELECT SCOPE_IDENTITY()",true, GxErrorMask.GX_NOMASK, false, this,prmT000310,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T000311", "UPDATE [Pais] SET [PaisNombre]=@PaisNombre  WHERE [PaisId] = @PaisId", GxErrorMask.GX_NOMASK,prmT000311)
             ,new CursorDef("T000312", "DELETE FROM [Pais]  WHERE [PaisId] = @PaisId", GxErrorMask.GX_NOMASK,prmT000312)
             ,new CursorDef("T000313", "SELECT TOP 1 [parqueAtraccionId] FROM [parqueAtraccion] WHERE [PaisId] = @PaisId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000313,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T000314", "SELECT [PaisId] FROM [Pais] ORDER BY [PaisId]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT000314,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000315", "SELECT [PaisId], [CiudadId], [CiudadNombre] FROM [PaisCiudad] WHERE [PaisId] = @PaisId and [CiudadId] = @CiudadId ORDER BY [PaisId], [CiudadId] ",true, GxErrorMask.GX_NOMASK, false, this,prmT000315,11, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000316", "SELECT [PaisId], [CiudadId] FROM [PaisCiudad] WHERE [PaisId] = @PaisId AND [CiudadId] = @CiudadId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000316,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000317", "INSERT INTO [PaisCiudad]([PaisId], [CiudadId], [CiudadNombre]) VALUES(@PaisId, @CiudadId, @CiudadNombre)", GxErrorMask.GX_NOMASK,prmT000317)
             ,new CursorDef("T000318", "UPDATE [PaisCiudad] SET [CiudadNombre]=@CiudadNombre  WHERE [PaisId] = @PaisId AND [CiudadId] = @CiudadId", GxErrorMask.GX_NOMASK,prmT000318)
             ,new CursorDef("T000319", "DELETE FROM [PaisCiudad]  WHERE [PaisId] = @PaisId AND [CiudadId] = @CiudadId", GxErrorMask.GX_NOMASK,prmT000319)
             ,new CursorDef("T000320", "SELECT TOP 1 [parqueAtraccionId] FROM [parqueAtraccion] WHERE [PaisId] = @PaisId AND [CiudadId] = @CiudadId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000320,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T000321", "SELECT [PaisId], [CiudadId] FROM [PaisCiudad] WHERE [PaisId] = @PaisId ORDER BY [PaisId], [CiudadId] ",true, GxErrorMask.GX_NOMASK, false, this,prmT000321,11, GxCacheFrequency.OFF ,true,false )
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
                ((string[]) buf[2])[0] = rslt.getVarchar(3);
                return;
             case 1 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((short[]) buf[1])[0] = rslt.getShort(2);
                ((string[]) buf[2])[0] = rslt.getVarchar(3);
                return;
             case 2 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                return;
             case 3 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                return;
             case 4 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
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
                ((short[]) buf[0])[0] = rslt.getShort(1);
                return;
             case 12 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                return;
             case 13 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((short[]) buf[1])[0] = rslt.getShort(2);
                ((string[]) buf[2])[0] = rslt.getVarchar(3);
                return;
             case 14 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((short[]) buf[1])[0] = rslt.getShort(2);
                return;
             case 18 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                return;
             case 19 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((short[]) buf[1])[0] = rslt.getShort(2);
                return;
       }
    }

 }

}
