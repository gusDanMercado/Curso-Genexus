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
using GeneXus.Http.Server;
using System.Xml.Serialization;
using System.Runtime.Serialization;
namespace GeneXus.Programs {
   public class wwempleado : GXDataArea
   {
      public wwempleado( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("parques", true);
      }

      public wwempleado( IGxContext context )
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
         cmbavOrderedby = new GXCombobox();
      }

      protected void INITWEB( )
      {
         initialize_properties( ) ;
         if ( nGotPars == 0 )
         {
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
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxNewRow_"+"Grid") == 0 )
            {
               gxnrGrid_newrow_invoke( ) ;
               return  ;
            }
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxGridRefresh_"+"Grid") == 0 )
            {
               gxgrGrid_refresh_invoke( ) ;
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
            if ( toggleJsOutput )
            {
               if ( context.isSpaRequest( ) )
               {
                  enableJsOutput();
               }
            }
         }
         if ( ! context.IsLocalStorageSupported( ) )
         {
            context.PushCurrentUrl();
         }
      }

      protected void gxnrGrid_newrow_invoke( )
      {
         nRC_GXsfl_34 = (int)(Math.Round(NumberUtil.Val( GetPar( "nRC_GXsfl_34"), "."), 18, MidpointRounding.ToEven));
         nGXsfl_34_idx = (int)(Math.Round(NumberUtil.Val( GetPar( "nGXsfl_34_idx"), "."), 18, MidpointRounding.ToEven));
         sGXsfl_34_idx = GetPar( "sGXsfl_34_idx");
         AV12Update = GetPar( "Update");
         AV13Delete = GetPar( "Delete");
         setAjaxCallMode();
         if ( ! IsValidAjaxCall( true) )
         {
            GxWebError = 1;
            return  ;
         }
         gxnrGrid_newrow( ) ;
         /* End function gxnrGrid_newrow_invoke */
      }

      protected void gxgrGrid_refresh_invoke( )
      {
         subGrid_Rows = (int)(Math.Round(NumberUtil.Val( GetPar( "subGrid_Rows"), "."), 18, MidpointRounding.ToEven));
         cmbavOrderedby.FromJSonString( GetNextPar( ));
         AV15OrderedBy = (short)(Math.Round(NumberUtil.Val( GetPar( "OrderedBy"), "."), 18, MidpointRounding.ToEven));
         AV11EmpleadoNombre = GetPar( "EmpleadoNombre");
         AV12Update = GetPar( "Update");
         AV13Delete = GetPar( "Delete");
         setAjaxCallMode();
         if ( ! IsValidAjaxCall( true) )
         {
            GxWebError = 1;
            return  ;
         }
         gxgrGrid_refresh( subGrid_Rows, AV15OrderedBy, AV11EmpleadoNombre, AV12Update, AV13Delete) ;
         AddString( context.getJSONResponse( )) ;
         /* End function gxgrGrid_refresh_invoke */
      }

      public override void webExecute( )
      {
         createObjects();
         initialize();
         INITWEB( ) ;
         if ( ! isAjaxCallMode( ) )
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

      public override short ExecuteStartEvent( )
      {
         PA0K2( ) ;
         gxajaxcallmode = (short)((isAjaxCallMode( ) ? 1 : 0));
         if ( ( gxajaxcallmode == 0 ) && ( GxWebError == 0 ) )
         {
            START0K2( ) ;
         }
         return gxajaxcallmode ;
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
         if ( nGXWrapped != 1 )
         {
            MasterPageObj.master_styles();
         }
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
         FormProcess = ((nGXWrapped==0) ? " data-HasEnter=\"false\" data-Skiponenter=\"false\"" : "");
         context.WriteHtmlText( "<body ") ;
         if ( StringUtil.StrCmp(context.GetLanguageProperty( "rtl"), "true") == 0 )
         {
            context.WriteHtmlText( " dir=\"rtl\" ") ;
         }
         bodyStyle = "" + "background-color:" + context.BuildHTMLColor( Form.Backcolor) + ";color:" + context.BuildHTMLColor( Form.Textcolor) + ";";
         if ( nGXWrapped == 0 )
         {
            bodyStyle += "-moz-opacity:0;opacity:0;";
         }
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( Form.Background)) ) )
         {
            bodyStyle += " background-image:url(" + context.convertURL( Form.Background) + ")";
         }
         context.WriteHtmlText( " "+"class=\"form-horizontal Form\""+" "+ "style='"+bodyStyle+"'") ;
         context.WriteHtmlText( FormProcess+">") ;
         context.skipLines(1);
         if ( nGXWrapped != 1 )
         {
            context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("wwempleado.aspx") +"\">") ;
            GxWebStd.gx_hidden_field( context, "_EventName", "");
            GxWebStd.gx_hidden_field( context, "_EventGridId", "");
            GxWebStd.gx_hidden_field( context, "_EventRowId", "");
            context.WriteHtmlText( "<div style=\"height:0;overflow:hidden\"><input type=\"submit\" title=\"submit\"  disabled></div>") ;
            AssignProp("", false, "FORM", "Class", "form-horizontal Form", true);
         }
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
         GxWebStd.gx_hidden_field( context, "GXH_vORDEREDBY", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV15OrderedBy), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "GXH_vEMPLEADONOMBRE", AV11EmpleadoNombre);
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "nRC_GXsfl_34", StringUtil.LTrim( StringUtil.NToC( (decimal)(nRC_GXsfl_34), 8, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "GRID_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nFirstRecordOnPage), 15, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "GRID_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nEOF), 1, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "FILTERSCONTAINER_Class", StringUtil.RTrim( divFilterscontainer_Class));
      }

      public override void RenderHtmlCloseForm( )
      {
         SendCloseFormHiddens( ) ;
         GxWebStd.gx_hidden_field( context, "GX_FocusControl", GX_FocusControl);
         SendAjaxEncryptionKey();
         SendSecurityToken((string)(sPrefix));
         SendComponentObjects();
         SendServerCommands();
         SendState();
         if ( context.isSpaRequest( ) )
         {
            disableOutput();
         }
         if ( nGXWrapped != 1 )
         {
            context.WriteHtmlTextNl( "</form>") ;
         }
         if ( context.isSpaRequest( ) )
         {
            enableOutput();
         }
         include_jscripts( ) ;
      }

      public override void RenderHtmlContent( )
      {
         gxajaxcallmode = (short)((isAjaxCallMode( ) ? 1 : 0));
         if ( ( gxajaxcallmode == 0 ) && ( GxWebError == 0 ) )
         {
            context.WriteHtmlText( "<div") ;
            GxWebStd.ClassAttribute( context, "gx-ct-body"+" "+(String.IsNullOrEmpty(StringUtil.RTrim( Form.Class)) ? "form-horizontal Form" : Form.Class)+"-fx");
            context.WriteHtmlText( ">") ;
            WE0K2( ) ;
            context.WriteHtmlText( "</div>") ;
         }
      }

      public override void DispatchEvents( )
      {
         EVT0K2( ) ;
      }

      public override bool HasEnterEvent( )
      {
         return false ;
      }

      public override GXWebForm GetForm( )
      {
         return Form ;
      }

      public override string GetSelfLink( )
      {
         return formatLink("wwempleado.aspx")  ;
      }

      public override string GetPgmname( )
      {
         return "WWEmpleado" ;
      }

      public override string GetPgmdesc( )
      {
         return "Empleados" ;
      }

      protected void WB0K0( )
      {
         if ( context.isAjaxRequest( ) )
         {
            disableOutput();
         }
         if ( ! wbLoad )
         {
            if ( nGXWrapped == 1 )
            {
               RenderHtmlHeaders( ) ;
               RenderHtmlOpenForm( ) ;
            }
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Section", "start", "top", " "+"data-gx-base-lib=\"none\""+" "+"data-abstract-form"+" ", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divMaintable_Internalname, 1, 0, "px", 0, "px", "body-container", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divGridcell_Internalname, 1, 0, "px", 0, "px", divGridcell_Class, "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divGridtable_Internalname, 1, 0, "px", 0, "px", "container-fluid container-advanced", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTabletop_Internalname, 1, 0, "px", 0, "px", "Flex ww__actions-container", "start", "top", " "+"data-gx-flex"+" ", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "ww__title-cell", "start", "top", "", "flex-grow:1;", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTitletext_Internalname, "Empleados", "", "", lblTitletext_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "heading-01", 0, "", 1, 1, 0, 0, "HLP_WWEmpleado.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "ww__actions-cell", "start", "top", "", "", "div");
            context.WriteHtmlText( "<nav class=\"navbar navbar-default gx-navbar  ActionGroup\" data-gx-actiongroup-type=\"menu\">") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "container-fluid", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "navbar-header", "start", "top", "", "", "div");
            context.WriteHtmlText( "<button type=\"button\" class=\"navbar-toggle collapsed gx-navbar-toggle\" data-toggle=\"collapse\" aria-expanded=\"false\">") ;
            context.WriteHtmlText( "<span class=\"icon-bar\"></span>") ;
            context.WriteHtmlText( "<span class=\"icon-bar\"></span>") ;
            context.WriteHtmlText( "<span class=\"icon-bar\"></span>") ;
            context.WriteHtmlText( "</button>") ;
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lbllbl15_Internalname, "", "", "", lbllbl15_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "navbar-brand", 0, "", 1, 1, 0, 0, "HLP_WWEmpleado.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divActions_inner_Internalname, 1, 0, "px", 0, "px", "collapse navbar-collapse gx-navbar-inner", "start", "top", "", "", "div");
            context.WriteHtmlText( "<ul class=\"nav navbar-nav\">") ;
            context.WriteHtmlText( "<li>") ;
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 17,'',false,'',0)\"";
            ClassString = "Button button-primary";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtninsert_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(34), 2, 0)+","+"null"+");", "Agregar", bttBtninsert_Jsonclick, 5, "Agregar", "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"E\\'DOINSERT\\'."+"'", TempTags, "", context.GetButtonType( ), "HLP_WWEmpleado.htm");
            context.WriteHtmlText( "</li>") ;
            context.WriteHtmlText( "<li>") ;
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 18,'',false,'',0)\"";
            ClassString = "Button button-tertiary";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtnreporteempleado_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(34), 2, 0)+","+"null"+");", "Reporte de Empleados", bttBtnreporteempleado_Jsonclick, 5, "Reporte de Empleados", "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"E\\'DOREPORTEEMPLEADO\\'."+"'", TempTags, "", context.GetButtonType( ), "HLP_WWEmpleado.htm");
            context.WriteHtmlText( "</li>") ;
            context.WriteHtmlText( "<li class=\"dropdown\">") ;
            context.WriteHtmlText( "<a href=\"#\" data-toggle=\"dropdown\" role=\"button\" aria-haspopup=\"true\" aria-expanded=\"false\" class=\"dropdown-toggle\">") ;
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lbllbl19_Internalname, "MORE", "", "", lbllbl19_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_WWEmpleado.htm");
            context.WriteHtmlText( "<span class=\"caret\"></span>") ;
            context.WriteHtmlText( "</a>") ;
            context.WriteHtmlText( "<ul class=\"gx-dropdown-menu dropdown-menu Submenu\">") ;
            context.WriteHtmlText( "<li>") ;
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 20,'',false,'',0)\"";
            ClassString = "Button button-tertiary";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtnreporteempleadoexcel_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(34), 2, 0)+","+"null"+");", "Reporte Excel de Empleados", bttBtnreporteempleadoexcel_Jsonclick, 5, "Reporte Excel de Empleados", "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"E\\'DOREPORTEEMPLEADOEXCEL\\'."+"'", TempTags, "", context.GetButtonType( ), "HLP_WWEmpleado.htm");
            context.WriteHtmlText( "</li>") ;
            context.WriteHtmlText( "</ul>") ;
            context.WriteHtmlText( "</li>") ;
            context.WriteHtmlText( "</ul>") ;
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</nav>") ;
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "ww__filter-cell", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavEmpleadonombre_Internalname, "Empleado Nombre", "gx-form-item attribute-searchLabel", 0, true, "width: 25%;");
            /* Multiple line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 23,'',false,'" + sGXsfl_34_idx + "',0)\"";
            ClassString = "attribute-search";
            StyleString = "";
            ClassString = "attribute-search";
            StyleString = "";
            GxWebStd.gx_html_textarea( context, edtavEmpleadonombre_Internalname, AV11EmpleadoNombre, "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,23);\"", 0, 1, edtavEmpleadonombre_Enabled, 0, 80, "chr", 10, "row", 0, StyleString, ClassString, "", "", "1024", -1, 0, "", "Nombre", -1, true, "", "'"+""+"'"+",false,"+"'"+""+"'", 0, "", "HLP_WWEmpleado.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "ww__toggle-cell", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 25,'',false,'',0)\"";
            ClassString = "ww__button-filters--hide";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtntoggle_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(34), 2, 0)+","+"null"+");", "Show Filters", bttBtntoggle_Jsonclick, 7, bttBtntoggle_Tooltiptext, "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"e110k1_client"+"'", TempTags, "", 2, "HLP_WWEmpleado.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
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
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divGridcontainer_Internalname, 1, 0, "px", 0, "px", "ww__grid-container", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /*  Grid Control  */
            GridContainer.SetWrapped(nGXWrapped);
            StartGridControl34( ) ;
         }
         if ( wbEnd == 34 )
         {
            wbEnd = 0;
            nRC_GXsfl_34 = (int)(nGXsfl_34_idx-1);
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "</table>") ;
               context.WriteHtmlText( "</div>") ;
            }
            else
            {
               GridContainer.AddObjectProperty("GRID_nEOF", GRID_nEOF);
               GridContainer.AddObjectProperty("GRID_nFirstRecordOnPage", GRID_nFirstRecordOnPage);
               sStyleString = "";
               context.WriteHtmlText( "<div id=\""+"GridContainer"+"Div\" "+sStyleString+">"+"</div>") ;
               context.httpAjaxContext.ajax_rsp_assign_grid("_"+"Grid", GridContainer, subGrid_Internalname);
               if ( ! context.isAjaxRequest( ) && ! context.isSpaRequest( ) )
               {
                  GxWebStd.gx_hidden_field( context, "GridContainerData", GridContainer.ToJavascriptSource());
               }
               if ( context.isAjaxRequest( ) || context.isSpaRequest( ) )
               {
                  GxWebStd.gx_hidden_field( context, "GridContainerData"+"V", GridContainer.GridValuesHidden());
               }
               else
               {
                  context.WriteHtmlText( "<input type=\"hidden\" "+"name=\""+"GridContainerData"+"V"+"\" value='"+GridContainer.GridValuesHidden()+"'/>") ;
               }
            }
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-3 col-md-2 ww__filters-cell", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divFilterscontainer_Internalname, 1, 0, "px", 0, "px", divFilterscontainer_Class, "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "end", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 55,'',false,'',0)\"";
            ClassString = "filters-container__close";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtntoggleontable_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(34), 2, 0)+","+"null"+");", "Hide Filters", bttBtntoggleontable_Jsonclick, 7, "Hide Filters", "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"e110k1_client"+"'", TempTags, "", 2, "HLP_WWEmpleado.htm");
            GxWebStd.gx_div_end( context, "end", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+cmbavOrderedby_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, cmbavOrderedby_Internalname, "Ordered By", "col-xs-12 attribute-comboLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 gx-attribute", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 60,'',false,'" + sGXsfl_34_idx + "',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavOrderedby, cmbavOrderedby_Internalname, StringUtil.Trim( StringUtil.Str( (decimal)(AV15OrderedBy), 4, 0)), 1, cmbavOrderedby_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "int", "", 1, cmbavOrderedby.Enabled, 0, 0, 0, "em", 0, "", "", "attribute-combo", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,60);\"", "", true, 0, "HLP_WWEmpleado.htm");
            cmbavOrderedby.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV15OrderedBy), 4, 0));
            AssignProp("", false, cmbavOrderedby_Internalname, "Values", (string)(cmbavOrderedby.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
         }
         if ( wbEnd == 34 )
         {
            wbEnd = 0;
            if ( isFullAjaxMode( ) )
            {
               if ( GridContainer.GetWrapped() == 1 )
               {
                  context.WriteHtmlText( "</table>") ;
                  context.WriteHtmlText( "</div>") ;
               }
               else
               {
                  GridContainer.AddObjectProperty("GRID_nEOF", GRID_nEOF);
                  GridContainer.AddObjectProperty("GRID_nFirstRecordOnPage", GRID_nFirstRecordOnPage);
                  sStyleString = "";
                  context.WriteHtmlText( "<div id=\""+"GridContainer"+"Div\" "+sStyleString+">"+"</div>") ;
                  context.httpAjaxContext.ajax_rsp_assign_grid("_"+"Grid", GridContainer, subGrid_Internalname);
                  if ( ! context.isAjaxRequest( ) && ! context.isSpaRequest( ) )
                  {
                     GxWebStd.gx_hidden_field( context, "GridContainerData", GridContainer.ToJavascriptSource());
                  }
                  if ( context.isAjaxRequest( ) || context.isSpaRequest( ) )
                  {
                     GxWebStd.gx_hidden_field( context, "GridContainerData"+"V", GridContainer.GridValuesHidden());
                  }
                  else
                  {
                     context.WriteHtmlText( "<input type=\"hidden\" "+"name=\""+"GridContainerData"+"V"+"\" value='"+GridContainer.GridValuesHidden()+"'/>") ;
                  }
               }
            }
         }
         wbLoad = true;
      }

      protected void START0K2( )
      {
         wbLoad = false;
         wbEnd = 0;
         wbStart = 0;
         if ( ! context.isSpaRequest( ) )
         {
            if ( context.ExposeMetadata( ) )
            {
               Form.Meta.addItem("generator", "GeneXus .NET 18_0_10-184260", 0) ;
            }
         }
         Form.Meta.addItem("description", "Empleados", 0) ;
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         wbErr = false;
         STRUP0K0( ) ;
      }

      protected void WS0K2( )
      {
         START0K2( ) ;
         EVT0K2( ) ;
      }

      protected void EVT0K2( )
      {
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
            if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) && ! wbErr )
            {
               /* Read Web Panel buttons. */
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
                           if ( StringUtil.StrCmp(sEvt, "RFR") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'DOINSERT'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'DoInsert' */
                              E120K2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'DOREPORTEEMPLEADO'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'DoReporteEmpleado' */
                              E130K2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'DOREPORTEEMPLEADOEXCEL'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'DoReporteEmpleadoExcel' */
                              E140K2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "LSCR") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                           }
                           else if ( StringUtil.StrCmp(sEvt, "GRIDPAGING") == 0 )
                           {
                              context.wbHandled = 1;
                              sEvt = cgiGet( "GRIDPAGING");
                              if ( StringUtil.StrCmp(sEvt, "FIRST") == 0 )
                              {
                                 subgrid_firstpage( ) ;
                              }
                              else if ( StringUtil.StrCmp(sEvt, "PREV") == 0 )
                              {
                                 subgrid_previouspage( ) ;
                              }
                              else if ( StringUtil.StrCmp(sEvt, "NEXT") == 0 )
                              {
                                 subgrid_nextpage( ) ;
                              }
                              else if ( StringUtil.StrCmp(sEvt, "LAST") == 0 )
                              {
                                 subgrid_lastpage( ) ;
                              }
                              dynload_actions( ) ;
                           }
                        }
                        else
                        {
                           sEvtType = StringUtil.Right( sEvt, 4);
                           sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-4));
                           if ( ( StringUtil.StrCmp(StringUtil.Left( sEvt, 5), "START") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 7), "REFRESH") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 9), "GRID.LOAD") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 5), "ENTER") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 6), "CANCEL") == 0 ) )
                           {
                              nGXsfl_34_idx = (int)(Math.Round(NumberUtil.Val( sEvtType, "."), 18, MidpointRounding.ToEven));
                              sGXsfl_34_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_34_idx), 4, 0), 4, "0");
                              SubsflControlProps_342( ) ;
                              A1EmpleadoId = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtEmpleadoId_Internalname), ",", "."), 18, MidpointRounding.ToEven));
                              A2EmpleadoNombre = cgiGet( edtEmpleadoNombre_Internalname);
                              A3EmpleadoApellido = cgiGet( edtEmpleadoApellido_Internalname);
                              A4EmpleadoDireccion = cgiGet( edtEmpleadoDireccion_Internalname);
                              n4EmpleadoDireccion = false;
                              A5EmpleadoTelefono = cgiGet( edtEmpleadoTelefono_Internalname);
                              n5EmpleadoTelefono = false;
                              A6EmpleadoEmail = cgiGet( edtEmpleadoEmail_Internalname);
                              n6EmpleadoEmail = false;
                              A7EmpleadoFch_Alta = context.localUtil.CToT( cgiGet( edtEmpleadoFch_Alta_Internalname), 0);
                              n7EmpleadoFch_Alta = false;
                              A8EmpleadoFcha_Mod = context.localUtil.CToT( cgiGet( edtEmpleadoFcha_Mod_Internalname), 0);
                              n8EmpleadoFcha_Mod = false;
                              A9EmpleadoFch_Cad = context.localUtil.CToT( cgiGet( edtEmpleadoFch_Cad_Internalname), 0);
                              n9EmpleadoFch_Cad = false;
                              A10EmpleadoUsu_Alta = cgiGet( edtEmpleadoUsu_Alta_Internalname);
                              n10EmpleadoUsu_Alta = false;
                              A11EmpleadoUsu_Mod = cgiGet( edtEmpleadoUsu_Mod_Internalname);
                              n11EmpleadoUsu_Mod = false;
                              A12EmpleadoUso_Cad = cgiGet( edtEmpleadoUso_Cad_Internalname);
                              n12EmpleadoUso_Cad = false;
                              A13parqueAtraccionId = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtparqueAtraccionId_Internalname), ",", "."), 18, MidpointRounding.ToEven));
                              n13parqueAtraccionId = false;
                              A14parqueAtraccionNombre = cgiGet( edtparqueAtraccionNombre_Internalname);
                              AV12Update = cgiGet( edtavUpdate_Internalname);
                              AssignAttri("", false, edtavUpdate_Internalname, AV12Update);
                              AV13Delete = cgiGet( edtavDelete_Internalname);
                              AssignAttri("", false, edtavDelete_Internalname, AV13Delete);
                              sEvtType = StringUtil.Right( sEvt, 1);
                              if ( StringUtil.StrCmp(sEvtType, ".") == 0 )
                              {
                                 sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-1));
                                 if ( StringUtil.StrCmp(sEvt, "START") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Start */
                                    E150K2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "REFRESH") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Refresh */
                                    E160K2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "GRID.LOAD") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Grid.Load */
                                    E170K2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "ENTER") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    if ( ! wbErr )
                                    {
                                       Rfr0gs = false;
                                       /* Set Refresh If Orderedby Changed */
                                       if ( ( context.localUtil.CToN( cgiGet( "GXH_vORDEREDBY"), ",", ".") != Convert.ToDecimal( AV15OrderedBy )) )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Empleadonombre Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vEMPLEADONOMBRE"), AV11EmpleadoNombre) != 0 )
                                       {
                                          Rfr0gs = true;
                                       }
                                       if ( ! Rfr0gs )
                                       {
                                       }
                                       dynload_actions( ) ;
                                    }
                                    /* No code required for Cancel button. It is implemented as the Reset button. */
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "LSCR") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                 }
                              }
                              else
                              {
                              }
                           }
                        }
                     }
                     context.wbHandled = 1;
                  }
               }
            }
         }
      }

      protected void WE0K2( )
      {
         if ( ! GxWebStd.gx_redirect( context) )
         {
            Rfr0gs = true;
            Refresh( ) ;
            if ( ! GxWebStd.gx_redirect( context) )
            {
               if ( nGXWrapped == 1 )
               {
                  RenderHtmlCloseForm( ) ;
               }
            }
         }
      }

      protected void PA0K2( )
      {
         if ( nDonePA == 0 )
         {
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
            if ( ! context.isAjaxRequest( ) )
            {
               GX_FocusControl = edtavEmpleadonombre_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
            nDonePA = 1;
         }
      }

      protected void dynload_actions( )
      {
         /* End function dynload_actions */
      }

      protected void gxnrGrid_newrow( )
      {
         GxWebStd.set_html_headers( context, 0, "", "");
         SubsflControlProps_342( ) ;
         while ( nGXsfl_34_idx <= nRC_GXsfl_34 )
         {
            sendrow_342( ) ;
            nGXsfl_34_idx = ((subGrid_Islastpage==1)&&(nGXsfl_34_idx+1>subGrid_fnc_Recordsperpage( )) ? 1 : nGXsfl_34_idx+1);
            sGXsfl_34_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_34_idx), 4, 0), 4, "0");
            SubsflControlProps_342( ) ;
         }
         AddString( context.httpAjaxContext.getJSONContainerResponse( GridContainer)) ;
         /* End function gxnrGrid_newrow */
      }

      protected void gxgrGrid_refresh( int subGrid_Rows ,
                                       short AV15OrderedBy ,
                                       string AV11EmpleadoNombre ,
                                       string AV12Update ,
                                       string AV13Delete )
      {
         initialize_formulas( ) ;
         GxWebStd.set_html_headers( context, 0, "", "");
         GRID_nCurrentRecord = 0;
         RF0K2( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         send_integrity_footer_hashes( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         /* End function gxgrGrid_refresh */
      }

      protected void send_integrity_hashes( )
      {
         GxWebStd.gx_hidden_field( context, "gxhash_EMPLEADOID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(A1EmpleadoId), "ZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "EMPLEADOID", StringUtil.LTrim( StringUtil.NToC( (decimal)(A1EmpleadoId), 4, 0, ".", "")));
      }

      protected void clear_multi_value_controls( )
      {
         if ( context.isAjaxRequest( ) )
         {
            dynload_actions( ) ;
            before_start_formulas( ) ;
         }
      }

      protected void fix_multi_value_controls( )
      {
         if ( cmbavOrderedby.ItemCount > 0 )
         {
            AV15OrderedBy = (short)(Math.Round(NumberUtil.Val( cmbavOrderedby.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV15OrderedBy), 4, 0))), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "AV15OrderedBy", StringUtil.LTrimStr( (decimal)(AV15OrderedBy), 4, 0));
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbavOrderedby.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV15OrderedBy), 4, 0));
            AssignProp("", false, cmbavOrderedby_Internalname, "Values", cmbavOrderedby.ToJavascriptSource(), true);
         }
      }

      public void Refresh( )
      {
         send_integrity_hashes( ) ;
         RF0K2( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
         AV16Pgmname = "WWEmpleado";
         edtavUpdate_Enabled = 0;
         edtavDelete_Enabled = 0;
      }

      protected void RF0K2( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         if ( isAjaxCallMode( ) )
         {
            GridContainer.ClearRows();
         }
         wbStart = 34;
         /* Execute user event: Refresh */
         E160K2 ();
         nGXsfl_34_idx = 1;
         sGXsfl_34_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_34_idx), 4, 0), 4, "0");
         SubsflControlProps_342( ) ;
         bGXsfl_34_Refreshing = true;
         GridContainer.AddObjectProperty("GridName", "Grid");
         GridContainer.AddObjectProperty("CmpContext", "");
         GridContainer.AddObjectProperty("InMasterPage", "false");
         GridContainer.AddObjectProperty("Class", "ww__grid");
         GridContainer.AddObjectProperty("Cellpadding", StringUtil.LTrim( StringUtil.NToC( (decimal)(1), 4, 0, ".", "")));
         GridContainer.AddObjectProperty("Cellspacing", StringUtil.LTrim( StringUtil.NToC( (decimal)(2), 4, 0, ".", "")));
         GridContainer.AddObjectProperty("Backcolorstyle", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Backcolorstyle), 1, 0, ".", "")));
         GridContainer.PageSize = subGrid_fnc_Recordsperpage( );
         gxdyncontrolsrefreshing = true;
         fix_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = false;
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            SubsflControlProps_342( ) ;
            GXPagingFrom2 = (int)(((subGrid_Rows==0) ? 0 : GRID_nFirstRecordOnPage));
            GXPagingTo2 = ((subGrid_Rows==0) ? 10000 : subGrid_fnc_Recordsperpage( )+1);
            pr_default.dynParam(0, new Object[]{ new Object[]{
                                                 AV11EmpleadoNombre ,
                                                 A2EmpleadoNombre ,
                                                 AV15OrderedBy } ,
                                                 new int[]{
                                                 TypeConstants.SHORT
                                                 }
            });
            lV11EmpleadoNombre = StringUtil.Concat( StringUtil.RTrim( AV11EmpleadoNombre), "%", "");
            /* Using cursor H000K2 */
            pr_default.execute(0, new Object[] {lV11EmpleadoNombre, GXPagingFrom2, GXPagingTo2, GXPagingTo2});
            nGXsfl_34_idx = 1;
            sGXsfl_34_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_34_idx), 4, 0), 4, "0");
            SubsflControlProps_342( ) ;
            while ( ( (pr_default.getStatus(0) != 101) ) && ( ( ( subGrid_Rows == 0 ) || ( GRID_nCurrentRecord < subGrid_fnc_Recordsperpage( ) ) ) ) )
            {
               A14parqueAtraccionNombre = H000K2_A14parqueAtraccionNombre[0];
               A13parqueAtraccionId = H000K2_A13parqueAtraccionId[0];
               n13parqueAtraccionId = H000K2_n13parqueAtraccionId[0];
               A12EmpleadoUso_Cad = H000K2_A12EmpleadoUso_Cad[0];
               n12EmpleadoUso_Cad = H000K2_n12EmpleadoUso_Cad[0];
               A11EmpleadoUsu_Mod = H000K2_A11EmpleadoUsu_Mod[0];
               n11EmpleadoUsu_Mod = H000K2_n11EmpleadoUsu_Mod[0];
               A10EmpleadoUsu_Alta = H000K2_A10EmpleadoUsu_Alta[0];
               n10EmpleadoUsu_Alta = H000K2_n10EmpleadoUsu_Alta[0];
               A9EmpleadoFch_Cad = H000K2_A9EmpleadoFch_Cad[0];
               n9EmpleadoFch_Cad = H000K2_n9EmpleadoFch_Cad[0];
               A8EmpleadoFcha_Mod = H000K2_A8EmpleadoFcha_Mod[0];
               n8EmpleadoFcha_Mod = H000K2_n8EmpleadoFcha_Mod[0];
               A7EmpleadoFch_Alta = H000K2_A7EmpleadoFch_Alta[0];
               n7EmpleadoFch_Alta = H000K2_n7EmpleadoFch_Alta[0];
               A6EmpleadoEmail = H000K2_A6EmpleadoEmail[0];
               n6EmpleadoEmail = H000K2_n6EmpleadoEmail[0];
               A5EmpleadoTelefono = H000K2_A5EmpleadoTelefono[0];
               n5EmpleadoTelefono = H000K2_n5EmpleadoTelefono[0];
               A4EmpleadoDireccion = H000K2_A4EmpleadoDireccion[0];
               n4EmpleadoDireccion = H000K2_n4EmpleadoDireccion[0];
               A3EmpleadoApellido = H000K2_A3EmpleadoApellido[0];
               A2EmpleadoNombre = H000K2_A2EmpleadoNombre[0];
               A1EmpleadoId = H000K2_A1EmpleadoId[0];
               A14parqueAtraccionNombre = H000K2_A14parqueAtraccionNombre[0];
               /* Execute user event: Grid.Load */
               E170K2 ();
               pr_default.readNext(0);
            }
            GRID_nEOF = (short)(((pr_default.getStatus(0) == 101) ? 1 : 0));
            GxWebStd.gx_hidden_field( context, "GRID_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nEOF), 1, 0, ".", "")));
            pr_default.close(0);
            wbEnd = 34;
            WB0K0( ) ;
         }
         bGXsfl_34_Refreshing = true;
      }

      protected void send_integrity_lvl_hashes0K2( )
      {
         GxWebStd.gx_hidden_field( context, "gxhash_EMPLEADOID"+"_"+sGXsfl_34_idx, GetSecureSignedToken( sGXsfl_34_idx, context.localUtil.Format( (decimal)(A1EmpleadoId), "ZZZ9"), context));
      }

      protected int subGrid_fnc_Pagecount( )
      {
         GRID_nRecordCount = subGrid_fnc_Recordcount( );
         if ( ((int)((GRID_nRecordCount) % (subGrid_fnc_Recordsperpage( )))) == 0 )
         {
            return (int)(NumberUtil.Int( (long)(Math.Round(GRID_nRecordCount/ (decimal)(subGrid_fnc_Recordsperpage( )), 18, MidpointRounding.ToEven)))) ;
         }
         return (int)(NumberUtil.Int( (long)(Math.Round(GRID_nRecordCount/ (decimal)(subGrid_fnc_Recordsperpage( )), 18, MidpointRounding.ToEven)))+1) ;
      }

      protected int subGrid_fnc_Recordcount( )
      {
         pr_default.dynParam(1, new Object[]{ new Object[]{
                                              AV11EmpleadoNombre ,
                                              A2EmpleadoNombre ,
                                              AV15OrderedBy } ,
                                              new int[]{
                                              TypeConstants.SHORT
                                              }
         });
         lV11EmpleadoNombre = StringUtil.Concat( StringUtil.RTrim( AV11EmpleadoNombre), "%", "");
         /* Using cursor H000K3 */
         pr_default.execute(1, new Object[] {lV11EmpleadoNombre});
         GRID_nRecordCount = H000K3_AGRID_nRecordCount[0];
         pr_default.close(1);
         return (int)(GRID_nRecordCount) ;
      }

      protected int subGrid_fnc_Recordsperpage( )
      {
         if ( subGrid_Rows > 0 )
         {
            return subGrid_Rows*1 ;
         }
         else
         {
            return (int)(-1) ;
         }
      }

      protected int subGrid_fnc_Currentpage( )
      {
         return (int)(NumberUtil.Int( (long)(Math.Round(GRID_nFirstRecordOnPage/ (decimal)(subGrid_fnc_Recordsperpage( )), 18, MidpointRounding.ToEven)))+1) ;
      }

      protected short subgrid_firstpage( )
      {
         GRID_nFirstRecordOnPage = 0;
         GxWebStd.gx_hidden_field( context, "GRID_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid_refresh( subGrid_Rows, AV15OrderedBy, AV11EmpleadoNombre, AV12Update, AV13Delete) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected short subgrid_nextpage( )
      {
         GRID_nRecordCount = subGrid_fnc_Recordcount( );
         if ( ( GRID_nRecordCount >= subGrid_fnc_Recordsperpage( ) ) && ( GRID_nEOF == 0 ) )
         {
            GRID_nFirstRecordOnPage = (long)(GRID_nFirstRecordOnPage+subGrid_fnc_Recordsperpage( ));
         }
         else
         {
            return 2 ;
         }
         GxWebStd.gx_hidden_field( context, "GRID_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nFirstRecordOnPage), 15, 0, ".", "")));
         GridContainer.AddObjectProperty("GRID_nFirstRecordOnPage", GRID_nFirstRecordOnPage);
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid_refresh( subGrid_Rows, AV15OrderedBy, AV11EmpleadoNombre, AV12Update, AV13Delete) ;
         }
         send_integrity_footer_hashes( ) ;
         return (short)(((GRID_nEOF==0) ? 0 : 2)) ;
      }

      protected short subgrid_previouspage( )
      {
         if ( GRID_nFirstRecordOnPage >= subGrid_fnc_Recordsperpage( ) )
         {
            GRID_nFirstRecordOnPage = (long)(GRID_nFirstRecordOnPage-subGrid_fnc_Recordsperpage( ));
         }
         else
         {
            return 2 ;
         }
         GxWebStd.gx_hidden_field( context, "GRID_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid_refresh( subGrid_Rows, AV15OrderedBy, AV11EmpleadoNombre, AV12Update, AV13Delete) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected short subgrid_lastpage( )
      {
         GRID_nRecordCount = subGrid_fnc_Recordcount( );
         if ( GRID_nRecordCount > subGrid_fnc_Recordsperpage( ) )
         {
            if ( ((int)((GRID_nRecordCount) % (subGrid_fnc_Recordsperpage( )))) == 0 )
            {
               GRID_nFirstRecordOnPage = (long)(GRID_nRecordCount-subGrid_fnc_Recordsperpage( ));
            }
            else
            {
               GRID_nFirstRecordOnPage = (long)(GRID_nRecordCount-((int)((GRID_nRecordCount) % (subGrid_fnc_Recordsperpage( )))));
            }
         }
         else
         {
            GRID_nFirstRecordOnPage = 0;
         }
         GxWebStd.gx_hidden_field( context, "GRID_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid_refresh( subGrid_Rows, AV15OrderedBy, AV11EmpleadoNombre, AV12Update, AV13Delete) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected int subgrid_gotopage( int nPageNo )
      {
         if ( nPageNo > 0 )
         {
            GRID_nFirstRecordOnPage = (long)(subGrid_fnc_Recordsperpage( )*(nPageNo-1));
         }
         else
         {
            GRID_nFirstRecordOnPage = 0;
         }
         GxWebStd.gx_hidden_field( context, "GRID_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid_refresh( subGrid_Rows, AV15OrderedBy, AV11EmpleadoNombre, AV12Update, AV13Delete) ;
         }
         send_integrity_footer_hashes( ) ;
         return (int)(0) ;
      }

      protected void subgrid_varsfromstate( )
      {
         if ( GridState.FilterCount >= 1 )
         {
            AV11EmpleadoNombre = GridState.FilterValues("Empleadonombre");
            AssignAttri("", false, "AV11EmpleadoNombre", AV11EmpleadoNombre);
         }
         if ( GridState.OrderedBy != 0 )
         {
            AV15OrderedBy = GridState.OrderedBy;
            AssignAttri("", false, "AV15OrderedBy", StringUtil.LTrimStr( (decimal)(AV15OrderedBy), 4, 0));
         }
         if ( GridState.CurrentPage > 0 )
         {
            GridPageCount = subGrid_fnc_Pagecount( );
            if ( ( GridPageCount > 0 ) && ( GridPageCount < GridState.CurrentPage ) )
            {
               subgrid_gotopage( GridPageCount) ;
            }
            else
            {
               subgrid_gotopage( ((GridPageCount<0) ? 0 : GridState.CurrentPage)) ;
            }
         }
      }

      protected void subgrid_varstostate( )
      {
         GridState.CurrentPage = subGrid_fnc_Currentpage( );
         GridState.OrderedBy = AV15OrderedBy;
         GridState.ClearFilterValues();
         GridState.AddFilterValue("EmpleadoNombre", AV11EmpleadoNombre);
      }

      protected void before_start_formulas( )
      {
         AV16Pgmname = "WWEmpleado";
         edtavUpdate_Enabled = 0;
         edtavDelete_Enabled = 0;
         edtEmpleadoId_Enabled = 0;
         edtEmpleadoNombre_Enabled = 0;
         edtEmpleadoApellido_Enabled = 0;
         edtEmpleadoDireccion_Enabled = 0;
         edtEmpleadoTelefono_Enabled = 0;
         edtEmpleadoEmail_Enabled = 0;
         edtEmpleadoFch_Alta_Enabled = 0;
         edtEmpleadoFcha_Mod_Enabled = 0;
         edtEmpleadoFch_Cad_Enabled = 0;
         edtEmpleadoUsu_Alta_Enabled = 0;
         edtEmpleadoUsu_Mod_Enabled = 0;
         edtEmpleadoUso_Cad_Enabled = 0;
         edtparqueAtraccionId_Enabled = 0;
         edtparqueAtraccionNombre_Enabled = 0;
         fix_multi_value_controls( ) ;
      }

      protected void STRUP0K0( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E150K2 ();
         context.wbGlbDoneStart = 1;
         /* After Start, stand alone formulas. */
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
            /* Read saved SDTs. */
            /* Read saved values. */
            nRC_GXsfl_34 = (int)(Math.Round(context.localUtil.CToN( cgiGet( "nRC_GXsfl_34"), ",", "."), 18, MidpointRounding.ToEven));
            GRID_nFirstRecordOnPage = (long)(Math.Round(context.localUtil.CToN( cgiGet( "GRID_nFirstRecordOnPage"), ",", "."), 18, MidpointRounding.ToEven));
            GRID_nEOF = (short)(Math.Round(context.localUtil.CToN( cgiGet( "GRID_nEOF"), ",", "."), 18, MidpointRounding.ToEven));
            subGrid_Rows = (int)(Math.Round(context.localUtil.CToN( cgiGet( "GRID_Rows"), ",", "."), 18, MidpointRounding.ToEven));
            GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
            /* Read variables values. */
            AV11EmpleadoNombre = cgiGet( edtavEmpleadonombre_Internalname);
            AssignAttri("", false, "AV11EmpleadoNombre", AV11EmpleadoNombre);
            cmbavOrderedby.Name = cmbavOrderedby_Internalname;
            cmbavOrderedby.CurrentValue = cgiGet( cmbavOrderedby_Internalname);
            AV15OrderedBy = (short)(Math.Round(NumberUtil.Val( cgiGet( cmbavOrderedby_Internalname), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "AV15OrderedBy", StringUtil.LTrimStr( (decimal)(AV15OrderedBy), 4, 0));
            /* Read subfile selected row values. */
            /* Read hidden variables. */
            GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
            /* Check if conditions changed and reset current page numbers */
            if ( ( context.localUtil.CToN( cgiGet( "GXH_vORDEREDBY"), ",", ".") != Convert.ToDecimal( AV15OrderedBy )) )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( "GXH_vEMPLEADONOMBRE"), AV11EmpleadoNombre) != 0 )
            {
               GRID_nFirstRecordOnPage = 0;
            }
         }
         else
         {
            dynload_actions( ) ;
         }
      }

      protected void GXStart( )
      {
         /* Execute user event: Start */
         E150K2 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
      }

      protected void E150K2( )
      {
         /* Start Routine */
         returnInSub = false;
         if ( ! new GeneXus.Programs.general.security.isauthorized(context).executeUdp(  AV16Pgmname) )
         {
            CallWebObject(formatLink("general.security.notauthorized.aspx", new object[] {UrlEncode(StringUtil.RTrim(AV16Pgmname))}, new string[] {"GxObject"}) );
            context.wjLocDisableFrm = 1;
         }
         subGrid_Rows = 10;
         GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         AV12Update = "Modificar";
         AssignAttri("", false, edtavUpdate_Internalname, AV12Update);
         AV13Delete = "Eliminar";
         AssignAttri("", false, edtavDelete_Internalname, AV13Delete);
         AV15OrderedBy = 1;
         AssignAttri("", false, "AV15OrderedBy", StringUtil.LTrimStr( (decimal)(AV15OrderedBy), 4, 0));
         Form.Caption = "Empleados";
         AssignProp("", false, "FORM", "Caption", Form.Caption, true);
         AV14ADVANCED_LABEL_TEMPLATE = "%1 <strong>%2</strong>";
         /* Execute user subroutine: 'PREPARETRANSACTION' */
         S112 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         GridState.LoadGridState();
      }

      protected void E160K2( )
      {
         if ( gx_refresh_fired )
         {
            return  ;
         }
         gx_refresh_fired = true;
         /* Refresh Routine */
         returnInSub = false;
         GridState.SaveGridState();
      }

      private void E170K2( )
      {
         /* Grid_Load Routine */
         returnInSub = false;
         edtavUpdate_Link = formatLink("empleado.aspx", new object[] {UrlEncode(StringUtil.RTrim("UPD")),UrlEncode(StringUtil.LTrimStr(A1EmpleadoId,4,0))}, new string[] {"Mode","EmpleadoId"}) ;
         edtavDelete_Link = formatLink("empleado.aspx", new object[] {UrlEncode(StringUtil.RTrim("DLT")),UrlEncode(StringUtil.LTrimStr(A1EmpleadoId,4,0))}, new string[] {"Mode","EmpleadoId"}) ;
         edtEmpleadoNombre_Link = formatLink("viewempleado.aspx", new object[] {UrlEncode(StringUtil.LTrimStr(A1EmpleadoId,4,0)),UrlEncode(StringUtil.RTrim(""))}, new string[] {"EmpleadoId","TabCode"}) ;
         edtparqueAtraccionNombre_Link = formatLink("viewparqueatraccion.aspx", new object[] {UrlEncode(StringUtil.LTrimStr(A13parqueAtraccionId,4,0)),UrlEncode(StringUtil.RTrim(""))}, new string[] {"parqueAtraccionId","TabCode"}) ;
         /* Load Method */
         if ( wbStart != -1 )
         {
            wbStart = 34;
         }
         sendrow_342( ) ;
         GRID_nCurrentRecord = (long)(GRID_nCurrentRecord+1);
         if ( isFullAjaxMode( ) && ! bGXsfl_34_Refreshing )
         {
            DoAjaxLoad(34, GridRow);
         }
         /*  Sending Event outputs  */
      }

      protected void E120K2( )
      {
         /* 'DoInsert' Routine */
         returnInSub = false;
         CallWebObject(formatLink("empleado.aspx", new object[] {UrlEncode(StringUtil.RTrim("INS")),UrlEncode(StringUtil.LTrimStr(0,1,0))}, new string[] {"Mode","EmpleadoId"}) );
         context.wjLocDisableFrm = 1;
      }

      protected void E130K2( )
      {
         /* 'DoReporteEmpleado' Routine */
         returnInSub = false;
         CallWebObject(formatLink("areporteempleado.aspx") );
         context.wjLocDisableFrm = 2;
      }

      protected void E140K2( )
      {
         /* 'DoReporteEmpleadoExcel' Routine */
         returnInSub = false;
         CallWebObject(formatLink("areporteempleadoexcel.aspx") );
         context.wjLocDisableFrm = 2;
      }

      protected void S112( )
      {
         /* 'PREPARETRANSACTION' Routine */
         returnInSub = false;
         AV9TrnContext = new GeneXus.Programs.general.ui.SdtTransactionContext(context);
         AV9TrnContext.gxTpr_Callerobject = AV16Pgmname;
         AV9TrnContext.gxTpr_Callerondelete = true;
         AV9TrnContext.gxTpr_Callerurl = AV7HTTPRequest.ScriptName+"?"+AV7HTTPRequest.QueryString;
         AV9TrnContext.gxTpr_Transactionname = "Empleado";
         AV6Session.Set("TrnContext", AV9TrnContext.ToXml(false, true, "", ""));
      }

      public override void setparameters( Object[] obj )
      {
         createObjects();
         initialize();
      }

      public override string getresponse( string sGXDynURL )
      {
         initialize_properties( ) ;
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         sDynURL = sGXDynURL;
         nGotPars = (short)(1);
         nGXWrapped = (short)(1);
         context.SetWrapped(true);
         PA0K2( ) ;
         WS0K2( ) ;
         WE0K2( ) ;
         cleanup();
         context.SetWrapped(false);
         context.GX_msglist = BackMsgLst;
         return "";
      }

      public void responsestatic( string sGXDynURL )
      {
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?202542616524322", true, true);
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
         if ( nGXWrapped != 1 )
         {
            context.AddJavascriptSource("messages.spa.js", "?"+GetCacheInvalidationToken( ), false, true);
            context.AddJavascriptSource("wwempleado.js", "?202542616524323", false, true);
         }
         /* End function include_jscripts */
      }

      protected void SubsflControlProps_342( )
      {
         edtEmpleadoId_Internalname = "EMPLEADOID_"+sGXsfl_34_idx;
         edtEmpleadoNombre_Internalname = "EMPLEADONOMBRE_"+sGXsfl_34_idx;
         edtEmpleadoApellido_Internalname = "EMPLEADOAPELLIDO_"+sGXsfl_34_idx;
         edtEmpleadoDireccion_Internalname = "EMPLEADODIRECCION_"+sGXsfl_34_idx;
         edtEmpleadoTelefono_Internalname = "EMPLEADOTELEFONO_"+sGXsfl_34_idx;
         edtEmpleadoEmail_Internalname = "EMPLEADOEMAIL_"+sGXsfl_34_idx;
         edtEmpleadoFch_Alta_Internalname = "EMPLEADOFCH_ALTA_"+sGXsfl_34_idx;
         edtEmpleadoFcha_Mod_Internalname = "EMPLEADOFCHA_MOD_"+sGXsfl_34_idx;
         edtEmpleadoFch_Cad_Internalname = "EMPLEADOFCH_CAD_"+sGXsfl_34_idx;
         edtEmpleadoUsu_Alta_Internalname = "EMPLEADOUSU_ALTA_"+sGXsfl_34_idx;
         edtEmpleadoUsu_Mod_Internalname = "EMPLEADOUSU_MOD_"+sGXsfl_34_idx;
         edtEmpleadoUso_Cad_Internalname = "EMPLEADOUSO_CAD_"+sGXsfl_34_idx;
         edtparqueAtraccionId_Internalname = "PARQUEATRACCIONID_"+sGXsfl_34_idx;
         edtparqueAtraccionNombre_Internalname = "PARQUEATRACCIONNOMBRE_"+sGXsfl_34_idx;
         edtavUpdate_Internalname = "vUPDATE_"+sGXsfl_34_idx;
         edtavDelete_Internalname = "vDELETE_"+sGXsfl_34_idx;
      }

      protected void SubsflControlProps_fel_342( )
      {
         edtEmpleadoId_Internalname = "EMPLEADOID_"+sGXsfl_34_fel_idx;
         edtEmpleadoNombre_Internalname = "EMPLEADONOMBRE_"+sGXsfl_34_fel_idx;
         edtEmpleadoApellido_Internalname = "EMPLEADOAPELLIDO_"+sGXsfl_34_fel_idx;
         edtEmpleadoDireccion_Internalname = "EMPLEADODIRECCION_"+sGXsfl_34_fel_idx;
         edtEmpleadoTelefono_Internalname = "EMPLEADOTELEFONO_"+sGXsfl_34_fel_idx;
         edtEmpleadoEmail_Internalname = "EMPLEADOEMAIL_"+sGXsfl_34_fel_idx;
         edtEmpleadoFch_Alta_Internalname = "EMPLEADOFCH_ALTA_"+sGXsfl_34_fel_idx;
         edtEmpleadoFcha_Mod_Internalname = "EMPLEADOFCHA_MOD_"+sGXsfl_34_fel_idx;
         edtEmpleadoFch_Cad_Internalname = "EMPLEADOFCH_CAD_"+sGXsfl_34_fel_idx;
         edtEmpleadoUsu_Alta_Internalname = "EMPLEADOUSU_ALTA_"+sGXsfl_34_fel_idx;
         edtEmpleadoUsu_Mod_Internalname = "EMPLEADOUSU_MOD_"+sGXsfl_34_fel_idx;
         edtEmpleadoUso_Cad_Internalname = "EMPLEADOUSO_CAD_"+sGXsfl_34_fel_idx;
         edtparqueAtraccionId_Internalname = "PARQUEATRACCIONID_"+sGXsfl_34_fel_idx;
         edtparqueAtraccionNombre_Internalname = "PARQUEATRACCIONNOMBRE_"+sGXsfl_34_fel_idx;
         edtavUpdate_Internalname = "vUPDATE_"+sGXsfl_34_fel_idx;
         edtavDelete_Internalname = "vDELETE_"+sGXsfl_34_fel_idx;
      }

      protected void sendrow_342( )
      {
         sGXsfl_34_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_34_idx), 4, 0), 4, "0");
         SubsflControlProps_342( ) ;
         WB0K0( ) ;
         if ( ( subGrid_Rows * 1 == 0 ) || ( nGXsfl_34_idx <= subGrid_fnc_Recordsperpage( ) * 1 ) )
         {
            GridRow = GXWebRow.GetNew(context,GridContainer);
            if ( subGrid_Backcolorstyle == 0 )
            {
               /* None style subfile background logic. */
               subGrid_Backstyle = 0;
               if ( StringUtil.StrCmp(subGrid_Class, "") != 0 )
               {
                  subGrid_Linesclass = subGrid_Class+"Odd";
               }
            }
            else if ( subGrid_Backcolorstyle == 1 )
            {
               /* Uniform style subfile background logic. */
               subGrid_Backstyle = 0;
               subGrid_Backcolor = subGrid_Allbackcolor;
               if ( StringUtil.StrCmp(subGrid_Class, "") != 0 )
               {
                  subGrid_Linesclass = subGrid_Class+"Uniform";
               }
            }
            else if ( subGrid_Backcolorstyle == 2 )
            {
               /* Header style subfile background logic. */
               subGrid_Backstyle = 1;
               if ( StringUtil.StrCmp(subGrid_Class, "") != 0 )
               {
                  subGrid_Linesclass = subGrid_Class+"Odd";
               }
               subGrid_Backcolor = (int)(0x0);
            }
            else if ( subGrid_Backcolorstyle == 3 )
            {
               /* Report style subfile background logic. */
               subGrid_Backstyle = 1;
               if ( ((int)((nGXsfl_34_idx) % (2))) == 0 )
               {
                  subGrid_Backcolor = (int)(0x0);
                  if ( StringUtil.StrCmp(subGrid_Class, "") != 0 )
                  {
                     subGrid_Linesclass = subGrid_Class+"Even";
                  }
               }
               else
               {
                  subGrid_Backcolor = (int)(0x0);
                  if ( StringUtil.StrCmp(subGrid_Class, "") != 0 )
                  {
                     subGrid_Linesclass = subGrid_Class+"Odd";
                  }
               }
            }
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<tr ") ;
               context.WriteHtmlText( " class=\""+"ww__grid"+"\" style=\""+""+"\"") ;
               context.WriteHtmlText( " gxrow=\""+sGXsfl_34_idx+"\">") ;
            }
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtEmpleadoId_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A1EmpleadoId), 4, 0, ",", "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A1EmpleadoId), "ZZZ9")),(string)" dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtEmpleadoId_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"column column-optional",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)4,(short)0,(short)0,(short)34,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "attribute-description";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtEmpleadoNombre_Internalname,(string)A2EmpleadoNombre,(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)edtEmpleadoNombre_Link,(string)"",(string)"",(string)"",(string)edtEmpleadoNombre_Jsonclick,(short)0,(string)"attribute-description",(string)"",(string)ROClassString,(string)"column",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)1024,(short)0,(short)0,(short)34,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtEmpleadoApellido_Internalname,(string)A3EmpleadoApellido,(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtEmpleadoApellido_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"column column-optional",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)1024,(short)0,(short)0,(short)34,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtEmpleadoDireccion_Internalname,(string)A4EmpleadoDireccion,(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'","http://maps.google.com/maps?q="+GXUtil.UrlEncode( A4EmpleadoDireccion),(string)"_blank",(string)"",(string)"",(string)edtEmpleadoDireccion_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"column column-optional",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)1024,(short)0,(short)0,(short)34,(short)0,(short)-1,(short)0,(bool)true,(string)"GeneXus\\Address",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            if ( context.isSmartDevice( ) )
            {
               gxphoneLink = "tel:" + StringUtil.RTrim( A5EmpleadoTelefono);
            }
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtEmpleadoTelefono_Internalname,StringUtil.RTrim( A5EmpleadoTelefono),(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)gxphoneLink,(string)"",(string)"",(string)"",(string)edtEmpleadoTelefono_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"column column-optional",(string)"",(short)-1,(short)0,(short)0,(string)"tel",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)20,(short)0,(short)0,(short)34,(short)0,(short)-1,(short)0,(bool)true,(string)"GeneXus\\Phone",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtEmpleadoEmail_Internalname,(string)A6EmpleadoEmail,(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"mailto:"+A6EmpleadoEmail,(string)"",(string)"",(string)"",(string)edtEmpleadoEmail_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"column column-optional",(string)"",(short)-1,(short)0,(short)0,(string)"email",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)100,(short)0,(short)0,(short)34,(short)0,(short)-1,(short)0,(bool)true,(string)"GeneXus\\Email",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtEmpleadoFch_Alta_Internalname,context.localUtil.TToC( A7EmpleadoFch_Alta, 10, 8, 0, 3, "/", ":", " "),context.localUtil.Format( A7EmpleadoFch_Alta, "99/99/99 99:99"),(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtEmpleadoFch_Alta_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"column column-optional",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)14,(short)0,(short)0,(short)34,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtEmpleadoFcha_Mod_Internalname,context.localUtil.TToC( A8EmpleadoFcha_Mod, 10, 8, 0, 3, "/", ":", " "),context.localUtil.Format( A8EmpleadoFcha_Mod, "99/99/99 99:99"),(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtEmpleadoFcha_Mod_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"column column-optional",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)14,(short)0,(short)0,(short)34,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtEmpleadoFch_Cad_Internalname,context.localUtil.TToC( A9EmpleadoFch_Cad, 10, 8, 0, 3, "/", ":", " "),context.localUtil.Format( A9EmpleadoFch_Cad, "99/99/99 99:99"),(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtEmpleadoFch_Cad_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"column column-optional",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)14,(short)0,(short)0,(short)34,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtEmpleadoUsu_Alta_Internalname,(string)A10EmpleadoUsu_Alta,(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtEmpleadoUsu_Alta_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"column column-optional",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)40,(short)0,(short)0,(short)34,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtEmpleadoUsu_Mod_Internalname,(string)A11EmpleadoUsu_Mod,(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtEmpleadoUsu_Mod_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"column column-optional",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)40,(short)0,(short)0,(short)34,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtEmpleadoUso_Cad_Internalname,(string)A12EmpleadoUso_Cad,(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtEmpleadoUso_Cad_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"column column-optional",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)40,(short)0,(short)0,(short)34,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtparqueAtraccionId_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A13parqueAtraccionId), 4, 0, ",", "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A13parqueAtraccionId), "ZZZ9")),(string)" dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtparqueAtraccionId_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"column column-optional",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)4,(short)0,(short)0,(short)34,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtparqueAtraccionNombre_Internalname,(string)A14parqueAtraccionNombre,(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)edtparqueAtraccionNombre_Link,(string)"",(string)"",(string)"",(string)edtparqueAtraccionNombre_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"column column-optional",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)20,(short)0,(short)0,(short)34,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 49,'',false,'" + sGXsfl_34_idx + "',34)\"";
            ROClassString = "TextActionAttribute TextLikeLink";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavUpdate_Internalname,StringUtil.RTrim( AV12Update),(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,49);\"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)edtavUpdate_Link,(string)"",(string)"",(string)"",(string)edtavUpdate_Jsonclick,(short)0,(string)"TextActionAttribute TextLikeLink",(string)"",(string)ROClassString,(string)"WWTextActionColumn",(string)"",(short)-1,(int)edtavUpdate_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)20,(short)0,(short)0,(short)34,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 50,'',false,'" + sGXsfl_34_idx + "',34)\"";
            ROClassString = "TextActionAttribute TextLikeLink";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavDelete_Internalname,StringUtil.RTrim( AV13Delete),(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,50);\"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)edtavDelete_Link,(string)"",(string)"",(string)"",(string)edtavDelete_Jsonclick,(short)0,(string)"TextActionAttribute TextLikeLink",(string)"",(string)ROClassString,(string)"WWTextActionColumn",(string)"",(short)-1,(int)edtavDelete_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)20,(short)0,(short)0,(short)34,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            send_integrity_lvl_hashes0K2( ) ;
            GridContainer.AddRow(GridRow);
            nGXsfl_34_idx = ((subGrid_Islastpage==1)&&(nGXsfl_34_idx+1>subGrid_fnc_Recordsperpage( )) ? 1 : nGXsfl_34_idx+1);
            sGXsfl_34_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_34_idx), 4, 0), 4, "0");
            SubsflControlProps_342( ) ;
         }
         /* End function sendrow_342 */
      }

      protected void init_web_controls( )
      {
         cmbavOrderedby.Name = "vORDEREDBY";
         cmbavOrderedby.WebTags = "";
         cmbavOrderedby.addItem("1", "Apellido", 0);
         cmbavOrderedby.addItem("2", "Nombre", 0);
         if ( cmbavOrderedby.ItemCount > 0 )
         {
            AV15OrderedBy = (short)(Math.Round(NumberUtil.Val( cmbavOrderedby.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV15OrderedBy), 4, 0))), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "AV15OrderedBy", StringUtil.LTrimStr( (decimal)(AV15OrderedBy), 4, 0));
         }
         /* End function init_web_controls */
      }

      protected void StartGridControl34( )
      {
         if ( GridContainer.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<div id=\""+"GridContainer"+"DivS\" data-gxgridid=\"34\">") ;
            sStyleString = "";
            GxWebStd.gx_table_start( context, subGrid_Internalname, subGrid_Internalname, "", "ww__grid", 0, "", "", 1, 2, sStyleString, "", "", 0);
            /* Subfile titles */
            context.WriteHtmlText( "<tr") ;
            context.WriteHtmlTextNl( ">") ;
            if ( subGrid_Backcolorstyle == 0 )
            {
               subGrid_Titlebackstyle = 0;
               if ( StringUtil.Len( subGrid_Class) > 0 )
               {
                  subGrid_Linesclass = subGrid_Class+"Title";
               }
            }
            else
            {
               subGrid_Titlebackstyle = 1;
               if ( subGrid_Backcolorstyle == 1 )
               {
                  subGrid_Titlebackcolor = subGrid_Allbackcolor;
                  if ( StringUtil.Len( subGrid_Class) > 0 )
                  {
                     subGrid_Linesclass = subGrid_Class+"UniformTitle";
                  }
               }
               else
               {
                  if ( StringUtil.Len( subGrid_Class) > 0 )
                  {
                     subGrid_Linesclass = subGrid_Class+"Title";
                  }
               }
            }
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "Id") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"attribute-description"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "Nombre") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "Apellido") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "Direccion") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "Telefono") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "Email") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( "Fch_Alta") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( "Fcha_Mod") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( "Fch_Cad") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( "Usu_Alta") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( "Usu_Mod") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( "Uso_Cad") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "parque Atraccion Id") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "parque Atraccion Nombre") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"TextActionAttribute TextLikeLink"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"TextActionAttribute TextLikeLink"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlTextNl( "</tr>") ;
            GridContainer.AddObjectProperty("GridName", "Grid");
         }
         else
         {
            if ( isAjaxCallMode( ) )
            {
               GridContainer = new GXWebGrid( context);
            }
            else
            {
               GridContainer.Clear();
            }
            GridContainer.SetWrapped(nGXWrapped);
            GridContainer.AddObjectProperty("GridName", "Grid");
            GridContainer.AddObjectProperty("Header", subGrid_Header);
            GridContainer.AddObjectProperty("Class", "ww__grid");
            GridContainer.AddObjectProperty("Cellpadding", StringUtil.LTrim( StringUtil.NToC( (decimal)(1), 4, 0, ".", "")));
            GridContainer.AddObjectProperty("Cellspacing", StringUtil.LTrim( StringUtil.NToC( (decimal)(2), 4, 0, ".", "")));
            GridContainer.AddObjectProperty("Backcolorstyle", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Backcolorstyle), 1, 0, ".", "")));
            GridContainer.AddObjectProperty("CmpContext", "");
            GridContainer.AddObjectProperty("InMasterPage", "false");
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A1EmpleadoId), 4, 0, ".", ""))));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A2EmpleadoNombre));
            GridColumn.AddObjectProperty("Link", StringUtil.RTrim( edtEmpleadoNombre_Link));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A3EmpleadoApellido));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A4EmpleadoDireccion));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( A5EmpleadoTelefono)));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A6EmpleadoEmail));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( context.localUtil.TToC( A7EmpleadoFch_Alta, 10, 8, 0, 3, "/", ":", " ")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( context.localUtil.TToC( A8EmpleadoFcha_Mod, 10, 8, 0, 3, "/", ":", " ")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( context.localUtil.TToC( A9EmpleadoFch_Cad, 10, 8, 0, 3, "/", ":", " ")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A10EmpleadoUsu_Alta));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A11EmpleadoUsu_Mod));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A12EmpleadoUso_Cad));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A13parqueAtraccionId), 4, 0, ".", ""))));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A14parqueAtraccionNombre));
            GridColumn.AddObjectProperty("Link", StringUtil.RTrim( edtparqueAtraccionNombre_Link));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( AV12Update)));
            GridColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavUpdate_Enabled), 5, 0, ".", "")));
            GridColumn.AddObjectProperty("Link", StringUtil.RTrim( edtavUpdate_Link));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( AV13Delete)));
            GridColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavDelete_Enabled), 5, 0, ".", "")));
            GridColumn.AddObjectProperty("Link", StringUtil.RTrim( edtavDelete_Link));
            GridContainer.AddColumnProperties(GridColumn);
            GridContainer.AddObjectProperty("Selectedindex", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Selectedindex), 4, 0, ".", "")));
            GridContainer.AddObjectProperty("Allowselection", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Allowselection), 1, 0, ".", "")));
            GridContainer.AddObjectProperty("Selectioncolor", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Selectioncolor), 9, 0, ".", "")));
            GridContainer.AddObjectProperty("Allowhover", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Allowhovering), 1, 0, ".", "")));
            GridContainer.AddObjectProperty("Hovercolor", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Hoveringcolor), 9, 0, ".", "")));
            GridContainer.AddObjectProperty("Allowcollapsing", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Allowcollapsing), 1, 0, ".", "")));
            GridContainer.AddObjectProperty("Collapsed", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Collapsed), 1, 0, ".", "")));
         }
      }

      protected void init_default_properties( )
      {
         lblTitletext_Internalname = "TITLETEXT";
         lbllbl15_Internalname = "LBL15";
         bttBtninsert_Internalname = "BTNINSERT";
         bttBtnreporteempleado_Internalname = "BTNREPORTEEMPLEADO";
         lbllbl19_Internalname = "LBL19";
         bttBtnreporteempleadoexcel_Internalname = "BTNREPORTEEMPLEADOEXCEL";
         divActions_inner_Internalname = "ACTIONS_INNER";
         edtavEmpleadonombre_Internalname = "vEMPLEADONOMBRE";
         bttBtntoggle_Internalname = "BTNTOGGLE";
         divTabletop_Internalname = "TABLETOP";
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
         edtavUpdate_Internalname = "vUPDATE";
         edtavDelete_Internalname = "vDELETE";
         divGridcontainer_Internalname = "GRIDCONTAINER";
         divGridtable_Internalname = "GRIDTABLE";
         divGridcell_Internalname = "GRIDCELL";
         bttBtntoggleontable_Internalname = "BTNTOGGLEONTABLE";
         cmbavOrderedby_Internalname = "vORDEREDBY";
         divFilterscontainer_Internalname = "FILTERSCONTAINER";
         divMaintable_Internalname = "MAINTABLE";
         Form.Internalname = "FORM";
         subGrid_Internalname = "GRID";
      }

      public override void initialize_properties( )
      {
         context.SetDefaultTheme("parques", true);
         if ( context.isSpaRequest( ) )
         {
            disableJsOutput();
         }
         init_default_properties( ) ;
         subGrid_Allowcollapsing = 0;
         subGrid_Allowselection = 0;
         subGrid_Header = "";
         edtavDelete_Jsonclick = "";
         edtavDelete_Link = "";
         edtavDelete_Enabled = 0;
         edtavUpdate_Jsonclick = "";
         edtavUpdate_Link = "";
         edtavUpdate_Enabled = 0;
         edtparqueAtraccionNombre_Jsonclick = "";
         edtparqueAtraccionNombre_Link = "";
         edtparqueAtraccionId_Jsonclick = "";
         edtEmpleadoUso_Cad_Jsonclick = "";
         edtEmpleadoUsu_Mod_Jsonclick = "";
         edtEmpleadoUsu_Alta_Jsonclick = "";
         edtEmpleadoFch_Cad_Jsonclick = "";
         edtEmpleadoFcha_Mod_Jsonclick = "";
         edtEmpleadoFch_Alta_Jsonclick = "";
         edtEmpleadoEmail_Jsonclick = "";
         edtEmpleadoTelefono_Jsonclick = "";
         edtEmpleadoDireccion_Jsonclick = "";
         edtEmpleadoApellido_Jsonclick = "";
         edtEmpleadoNombre_Jsonclick = "";
         edtEmpleadoNombre_Link = "";
         edtEmpleadoId_Jsonclick = "";
         subGrid_Class = "ww__grid";
         subGrid_Backcolorstyle = 0;
         edtparqueAtraccionNombre_Enabled = 0;
         edtparqueAtraccionId_Enabled = 0;
         edtEmpleadoUso_Cad_Enabled = 0;
         edtEmpleadoUsu_Mod_Enabled = 0;
         edtEmpleadoUsu_Alta_Enabled = 0;
         edtEmpleadoFch_Cad_Enabled = 0;
         edtEmpleadoFcha_Mod_Enabled = 0;
         edtEmpleadoFch_Alta_Enabled = 0;
         edtEmpleadoEmail_Enabled = 0;
         edtEmpleadoTelefono_Enabled = 0;
         edtEmpleadoDireccion_Enabled = 0;
         edtEmpleadoApellido_Enabled = 0;
         edtEmpleadoNombre_Enabled = 0;
         edtEmpleadoId_Enabled = 0;
         cmbavOrderedby_Jsonclick = "";
         cmbavOrderedby.Enabled = 1;
         bttBtntoggle_Tooltiptext = "Show Filters";
         edtavEmpleadonombre_Enabled = 1;
         divGridcell_Class = "col-xs-12 col-sm-9 col-md-10 ww__grid-cell--expanded";
         divFilterscontainer_Class = "filters-container";
         Form.Headerrawhtml = "";
         Form.Background = "";
         Form.Textcolor = 0;
         Form.Backcolor = (int)(0xFFFFFF);
         Form.Caption = "Empleados";
         subGrid_Rows = 10;
         context.GX_msglist.DisplayMode = 1;
         if ( context.isSpaRequest( ) )
         {
            enableJsOutput();
         }
      }

      public override bool SupportAjaxEvent( )
      {
         return true ;
      }

      public override void InitializeDynEvents( )
      {
         setEventMetadata("REFRESH","""{"handler":"Refresh","iparms":[{"av":"GRID_nFirstRecordOnPage"},{"av":"GRID_nEOF"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"cmbavOrderedby"},{"av":"AV15OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9"},{"av":"AV11EmpleadoNombre","fld":"vEMPLEADONOMBRE"},{"av":"AV12Update","fld":"vUPDATE"},{"av":"AV13Delete","fld":"vDELETE"}]}""");
         setEventMetadata("'TOGGLE'","""{"handler":"E110K1","iparms":[{"av":"divFilterscontainer_Class","ctrl":"FILTERSCONTAINER","prop":"Class"}]""");
         setEventMetadata("'TOGGLE'",""","oparms":[{"av":"divFilterscontainer_Class","ctrl":"FILTERSCONTAINER","prop":"Class"},{"av":"divGridcell_Class","ctrl":"GRIDCELL","prop":"Class"},{"ctrl":"BTNTOGGLE","prop":"Tooltiptext"}]}""");
         setEventMetadata("GRID.LOAD","""{"handler":"E170K2","iparms":[{"av":"A1EmpleadoId","fld":"EMPLEADOID","pic":"ZZZ9","hsh":true},{"av":"A13parqueAtraccionId","fld":"PARQUEATRACCIONID","pic":"ZZZ9"}]""");
         setEventMetadata("GRID.LOAD",""","oparms":[{"av":"edtavUpdate_Link","ctrl":"vUPDATE","prop":"Link"},{"av":"edtavDelete_Link","ctrl":"vDELETE","prop":"Link"},{"av":"edtEmpleadoNombre_Link","ctrl":"EMPLEADONOMBRE","prop":"Link"},{"av":"edtparqueAtraccionNombre_Link","ctrl":"PARQUEATRACCIONNOMBRE","prop":"Link"}]}""");
         setEventMetadata("'DOINSERT'","""{"handler":"E120K2","iparms":[{"av":"A1EmpleadoId","fld":"EMPLEADOID","pic":"ZZZ9","hsh":true}]}""");
         setEventMetadata("'DOREPORTEEMPLEADO'","""{"handler":"E130K2","iparms":[]}""");
         setEventMetadata("'DOREPORTEEMPLEADOEXCEL'","""{"handler":"E140K2","iparms":[]}""");
         setEventMetadata("GRID_FIRSTPAGE","""{"handler":"subgrid_firstpage","iparms":[{"av":"GRID_nFirstRecordOnPage"},{"av":"GRID_nEOF"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"cmbavOrderedby"},{"av":"AV15OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9"},{"av":"AV11EmpleadoNombre","fld":"vEMPLEADONOMBRE"},{"av":"AV12Update","fld":"vUPDATE"},{"av":"AV13Delete","fld":"vDELETE"}]}""");
         setEventMetadata("GRID_PREVPAGE","""{"handler":"subgrid_previouspage","iparms":[{"av":"GRID_nFirstRecordOnPage"},{"av":"GRID_nEOF"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"cmbavOrderedby"},{"av":"AV15OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9"},{"av":"AV11EmpleadoNombre","fld":"vEMPLEADONOMBRE"},{"av":"AV12Update","fld":"vUPDATE"},{"av":"AV13Delete","fld":"vDELETE"}]}""");
         setEventMetadata("GRID_NEXTPAGE","""{"handler":"subgrid_nextpage","iparms":[{"av":"GRID_nFirstRecordOnPage"},{"av":"GRID_nEOF"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"cmbavOrderedby"},{"av":"AV15OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9"},{"av":"AV11EmpleadoNombre","fld":"vEMPLEADONOMBRE"},{"av":"AV12Update","fld":"vUPDATE"},{"av":"AV13Delete","fld":"vDELETE"}]}""");
         setEventMetadata("GRID_LASTPAGE","""{"handler":"subgrid_lastpage","iparms":[{"av":"GRID_nFirstRecordOnPage"},{"av":"GRID_nEOF"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"cmbavOrderedby"},{"av":"AV15OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9"},{"av":"AV11EmpleadoNombre","fld":"vEMPLEADONOMBRE"},{"av":"AV12Update","fld":"vUPDATE"},{"av":"AV13Delete","fld":"vDELETE"}]}""");
         setEventMetadata("VALID_PARQUEATRACCIONID","""{"handler":"Valid_Parqueatraccionid","iparms":[]}""");
         setEventMetadata("NULL","""{"handler":"Validv_Delete","iparms":[]}""");
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

      public override void initialize( )
      {
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         AV12Update = "";
         AV13Delete = "";
         AV11EmpleadoNombre = "";
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXKey = "";
         GX_FocusControl = "";
         Form = new GXWebForm();
         sPrefix = "";
         lblTitletext_Jsonclick = "";
         lbllbl15_Jsonclick = "";
         TempTags = "";
         ClassString = "";
         StyleString = "";
         bttBtninsert_Jsonclick = "";
         bttBtnreporteempleado_Jsonclick = "";
         lbllbl19_Jsonclick = "";
         bttBtnreporteempleadoexcel_Jsonclick = "";
         bttBtntoggle_Jsonclick = "";
         GridContainer = new GXWebGrid( context);
         sStyleString = "";
         bttBtntoggleontable_Jsonclick = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         A2EmpleadoNombre = "";
         A3EmpleadoApellido = "";
         A4EmpleadoDireccion = "";
         A5EmpleadoTelefono = "";
         A6EmpleadoEmail = "";
         A7EmpleadoFch_Alta = (DateTime)(DateTime.MinValue);
         A8EmpleadoFcha_Mod = (DateTime)(DateTime.MinValue);
         A9EmpleadoFch_Cad = (DateTime)(DateTime.MinValue);
         A10EmpleadoUsu_Alta = "";
         A11EmpleadoUsu_Mod = "";
         A12EmpleadoUso_Cad = "";
         A14parqueAtraccionNombre = "";
         AV16Pgmname = "";
         GridState = new GXGridStateHandler(context,"Grid",GetPgmname(),subgrid_varsfromstate,subgrid_varstostate);
         lV11EmpleadoNombre = "";
         H000K2_A14parqueAtraccionNombre = new string[] {""} ;
         H000K2_A13parqueAtraccionId = new short[1] ;
         H000K2_n13parqueAtraccionId = new bool[] {false} ;
         H000K2_A12EmpleadoUso_Cad = new string[] {""} ;
         H000K2_n12EmpleadoUso_Cad = new bool[] {false} ;
         H000K2_A11EmpleadoUsu_Mod = new string[] {""} ;
         H000K2_n11EmpleadoUsu_Mod = new bool[] {false} ;
         H000K2_A10EmpleadoUsu_Alta = new string[] {""} ;
         H000K2_n10EmpleadoUsu_Alta = new bool[] {false} ;
         H000K2_A9EmpleadoFch_Cad = new DateTime[] {DateTime.MinValue} ;
         H000K2_n9EmpleadoFch_Cad = new bool[] {false} ;
         H000K2_A8EmpleadoFcha_Mod = new DateTime[] {DateTime.MinValue} ;
         H000K2_n8EmpleadoFcha_Mod = new bool[] {false} ;
         H000K2_A7EmpleadoFch_Alta = new DateTime[] {DateTime.MinValue} ;
         H000K2_n7EmpleadoFch_Alta = new bool[] {false} ;
         H000K2_A6EmpleadoEmail = new string[] {""} ;
         H000K2_n6EmpleadoEmail = new bool[] {false} ;
         H000K2_A5EmpleadoTelefono = new string[] {""} ;
         H000K2_n5EmpleadoTelefono = new bool[] {false} ;
         H000K2_A4EmpleadoDireccion = new string[] {""} ;
         H000K2_n4EmpleadoDireccion = new bool[] {false} ;
         H000K2_A3EmpleadoApellido = new string[] {""} ;
         H000K2_A2EmpleadoNombre = new string[] {""} ;
         H000K2_A1EmpleadoId = new short[1] ;
         H000K3_AGRID_nRecordCount = new long[1] ;
         AV14ADVANCED_LABEL_TEMPLATE = "";
         GridRow = new GXWebRow();
         AV9TrnContext = new GeneXus.Programs.general.ui.SdtTransactionContext(context);
         AV7HTTPRequest = new GxHttpRequest( context);
         AV6Session = context.GetSession();
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         subGrid_Linesclass = "";
         ROClassString = "";
         gxphoneLink = "";
         GridColumn = new GXWebColumn();
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.wwempleado__default(),
            new Object[][] {
                new Object[] {
               H000K2_A14parqueAtraccionNombre, H000K2_A13parqueAtraccionId, H000K2_n13parqueAtraccionId, H000K2_A12EmpleadoUso_Cad, H000K2_n12EmpleadoUso_Cad, H000K2_A11EmpleadoUsu_Mod, H000K2_n11EmpleadoUsu_Mod, H000K2_A10EmpleadoUsu_Alta, H000K2_n10EmpleadoUsu_Alta, H000K2_A9EmpleadoFch_Cad,
               H000K2_n9EmpleadoFch_Cad, H000K2_A8EmpleadoFcha_Mod, H000K2_n8EmpleadoFcha_Mod, H000K2_A7EmpleadoFch_Alta, H000K2_n7EmpleadoFch_Alta, H000K2_A6EmpleadoEmail, H000K2_n6EmpleadoEmail, H000K2_A5EmpleadoTelefono, H000K2_n5EmpleadoTelefono, H000K2_A4EmpleadoDireccion,
               H000K2_n4EmpleadoDireccion, H000K2_A3EmpleadoApellido, H000K2_A2EmpleadoNombre, H000K2_A1EmpleadoId
               }
               , new Object[] {
               H000K3_AGRID_nRecordCount
               }
            }
         );
         AV16Pgmname = "WWEmpleado";
         /* GeneXus formulas. */
         AV16Pgmname = "WWEmpleado";
         edtavUpdate_Enabled = 0;
         edtavDelete_Enabled = 0;
      }

      private short GRID_nEOF ;
      private short nGotPars ;
      private short GxWebError ;
      private short AV15OrderedBy ;
      private short gxajaxcallmode ;
      private short nGXWrapped ;
      private short wbEnd ;
      private short wbStart ;
      private short A1EmpleadoId ;
      private short A13parqueAtraccionId ;
      private short nDonePA ;
      private short gxcookieaux ;
      private short subGrid_Backcolorstyle ;
      private short subGrid_Backstyle ;
      private short subGrid_Titlebackstyle ;
      private short subGrid_Allowselection ;
      private short subGrid_Allowhovering ;
      private short subGrid_Allowcollapsing ;
      private short subGrid_Collapsed ;
      private int nRC_GXsfl_34 ;
      private int subGrid_Rows ;
      private int nGXsfl_34_idx=1 ;
      private int edtavEmpleadonombre_Enabled ;
      private int subGrid_Islastpage ;
      private int edtavUpdate_Enabled ;
      private int edtavDelete_Enabled ;
      private int GXPagingFrom2 ;
      private int GXPagingTo2 ;
      private int GridPageCount ;
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
      private int edtparqueAtraccionNombre_Enabled ;
      private int idxLst ;
      private int subGrid_Backcolor ;
      private int subGrid_Allbackcolor ;
      private int subGrid_Titlebackcolor ;
      private int subGrid_Selectedindex ;
      private int subGrid_Selectioncolor ;
      private int subGrid_Hoveringcolor ;
      private long GRID_nFirstRecordOnPage ;
      private long GRID_nCurrentRecord ;
      private long GRID_nRecordCount ;
      private string divFilterscontainer_Class ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string sGXsfl_34_idx="0001" ;
      private string AV12Update ;
      private string AV13Delete ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string GXKey ;
      private string GX_FocusControl ;
      private string sPrefix ;
      private string divMaintable_Internalname ;
      private string divGridcell_Internalname ;
      private string divGridcell_Class ;
      private string divGridtable_Internalname ;
      private string divTabletop_Internalname ;
      private string lblTitletext_Internalname ;
      private string lblTitletext_Jsonclick ;
      private string lbllbl15_Internalname ;
      private string lbllbl15_Jsonclick ;
      private string divActions_inner_Internalname ;
      private string TempTags ;
      private string ClassString ;
      private string StyleString ;
      private string bttBtninsert_Internalname ;
      private string bttBtninsert_Jsonclick ;
      private string bttBtnreporteempleado_Internalname ;
      private string bttBtnreporteempleado_Jsonclick ;
      private string lbllbl19_Internalname ;
      private string lbllbl19_Jsonclick ;
      private string bttBtnreporteempleadoexcel_Internalname ;
      private string bttBtnreporteempleadoexcel_Jsonclick ;
      private string edtavEmpleadonombre_Internalname ;
      private string bttBtntoggle_Internalname ;
      private string bttBtntoggle_Jsonclick ;
      private string bttBtntoggle_Tooltiptext ;
      private string divGridcontainer_Internalname ;
      private string sStyleString ;
      private string subGrid_Internalname ;
      private string divFilterscontainer_Internalname ;
      private string bttBtntoggleontable_Internalname ;
      private string bttBtntoggleontable_Jsonclick ;
      private string cmbavOrderedby_Internalname ;
      private string cmbavOrderedby_Jsonclick ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string edtEmpleadoId_Internalname ;
      private string edtEmpleadoNombre_Internalname ;
      private string edtEmpleadoApellido_Internalname ;
      private string edtEmpleadoDireccion_Internalname ;
      private string A5EmpleadoTelefono ;
      private string edtEmpleadoTelefono_Internalname ;
      private string edtEmpleadoEmail_Internalname ;
      private string edtEmpleadoFch_Alta_Internalname ;
      private string edtEmpleadoFcha_Mod_Internalname ;
      private string edtEmpleadoFch_Cad_Internalname ;
      private string edtEmpleadoUsu_Alta_Internalname ;
      private string edtEmpleadoUsu_Mod_Internalname ;
      private string edtEmpleadoUso_Cad_Internalname ;
      private string edtparqueAtraccionId_Internalname ;
      private string edtparqueAtraccionNombre_Internalname ;
      private string edtavUpdate_Internalname ;
      private string edtavDelete_Internalname ;
      private string AV16Pgmname ;
      private string AV14ADVANCED_LABEL_TEMPLATE ;
      private string edtavUpdate_Link ;
      private string edtavDelete_Link ;
      private string edtEmpleadoNombre_Link ;
      private string edtparqueAtraccionNombre_Link ;
      private string sGXsfl_34_fel_idx="0001" ;
      private string subGrid_Class ;
      private string subGrid_Linesclass ;
      private string ROClassString ;
      private string edtEmpleadoId_Jsonclick ;
      private string edtEmpleadoNombre_Jsonclick ;
      private string edtEmpleadoApellido_Jsonclick ;
      private string edtEmpleadoDireccion_Jsonclick ;
      private string gxphoneLink ;
      private string edtEmpleadoTelefono_Jsonclick ;
      private string edtEmpleadoEmail_Jsonclick ;
      private string edtEmpleadoFch_Alta_Jsonclick ;
      private string edtEmpleadoFcha_Mod_Jsonclick ;
      private string edtEmpleadoFch_Cad_Jsonclick ;
      private string edtEmpleadoUsu_Alta_Jsonclick ;
      private string edtEmpleadoUsu_Mod_Jsonclick ;
      private string edtEmpleadoUso_Cad_Jsonclick ;
      private string edtparqueAtraccionId_Jsonclick ;
      private string edtparqueAtraccionNombre_Jsonclick ;
      private string edtavUpdate_Jsonclick ;
      private string edtavDelete_Jsonclick ;
      private string subGrid_Header ;
      private DateTime A7EmpleadoFch_Alta ;
      private DateTime A8EmpleadoFcha_Mod ;
      private DateTime A9EmpleadoFch_Cad ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool wbLoad ;
      private bool Rfr0gs ;
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
      private bool n13parqueAtraccionId ;
      private bool bGXsfl_34_Refreshing=false ;
      private bool gxdyncontrolsrefreshing ;
      private bool returnInSub ;
      private bool gx_refresh_fired ;
      private string AV11EmpleadoNombre ;
      private string A2EmpleadoNombre ;
      private string A3EmpleadoApellido ;
      private string A4EmpleadoDireccion ;
      private string A6EmpleadoEmail ;
      private string A10EmpleadoUsu_Alta ;
      private string A11EmpleadoUsu_Mod ;
      private string A12EmpleadoUso_Cad ;
      private string A14parqueAtraccionNombre ;
      private string lV11EmpleadoNombre ;
      private GXWebGrid GridContainer ;
      private GXGridStateHandler GridState ;
      private GXWebRow GridRow ;
      private GXWebColumn GridColumn ;
      private GxHttpRequest AV7HTTPRequest ;
      private IGxSession AV6Session ;
      private GXWebForm Form ;
      private IGxDataStore dsDefault ;
      private GXCombobox cmbavOrderedby ;
      private IDataStoreProvider pr_default ;
      private string[] H000K2_A14parqueAtraccionNombre ;
      private short[] H000K2_A13parqueAtraccionId ;
      private bool[] H000K2_n13parqueAtraccionId ;
      private string[] H000K2_A12EmpleadoUso_Cad ;
      private bool[] H000K2_n12EmpleadoUso_Cad ;
      private string[] H000K2_A11EmpleadoUsu_Mod ;
      private bool[] H000K2_n11EmpleadoUsu_Mod ;
      private string[] H000K2_A10EmpleadoUsu_Alta ;
      private bool[] H000K2_n10EmpleadoUsu_Alta ;
      private DateTime[] H000K2_A9EmpleadoFch_Cad ;
      private bool[] H000K2_n9EmpleadoFch_Cad ;
      private DateTime[] H000K2_A8EmpleadoFcha_Mod ;
      private bool[] H000K2_n8EmpleadoFcha_Mod ;
      private DateTime[] H000K2_A7EmpleadoFch_Alta ;
      private bool[] H000K2_n7EmpleadoFch_Alta ;
      private string[] H000K2_A6EmpleadoEmail ;
      private bool[] H000K2_n6EmpleadoEmail ;
      private string[] H000K2_A5EmpleadoTelefono ;
      private bool[] H000K2_n5EmpleadoTelefono ;
      private string[] H000K2_A4EmpleadoDireccion ;
      private bool[] H000K2_n4EmpleadoDireccion ;
      private string[] H000K2_A3EmpleadoApellido ;
      private string[] H000K2_A2EmpleadoNombre ;
      private short[] H000K2_A1EmpleadoId ;
      private long[] H000K3_AGRID_nRecordCount ;
      private GeneXus.Programs.general.ui.SdtTransactionContext AV9TrnContext ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
   }

   public class wwempleado__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_H000K2( IGxContext context ,
                                             string AV11EmpleadoNombre ,
                                             string A2EmpleadoNombre ,
                                             short AV15OrderedBy )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int1 = new short[4];
         Object[] GXv_Object2 = new Object[2];
         string sSelectString;
         string sFromString;
         string sOrderString;
         sSelectString = " T2.[parqueAtraccionNombre], T1.[parqueAtraccionId], T1.[EmpleadoUso_Cad], T1.[EmpleadoUsu_Mod], T1.[EmpleadoUsu_Alta], T1.[EmpleadoFch_Cad], T1.[EmpleadoFcha_Mod], T1.[EmpleadoFch_Alta], T1.[EmpleadoEmail], T1.[EmpleadoTelefono], T1.[EmpleadoDireccion], T1.[EmpleadoApellido], T1.[EmpleadoNombre], T1.[EmpleadoId]";
         sFromString = " FROM ([Empleado] T1 LEFT JOIN [parqueAtraccion] T2 ON T2.[parqueAtraccionId] = T1.[parqueAtraccionId])";
         sOrderString = "";
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV11EmpleadoNombre)) )
         {
            AddWhere(sWhereString, "(T1.[EmpleadoNombre] like @lV11EmpleadoNombre)");
         }
         else
         {
            GXv_int1[0] = 1;
         }
         if ( AV15OrderedBy == 1 )
         {
            sOrderString += " ORDER BY T1.[EmpleadoApellido]";
         }
         else if ( AV15OrderedBy == 2 )
         {
            sOrderString += " ORDER BY T1.[EmpleadoNombre]";
         }
         else if ( true )
         {
            sOrderString += " ORDER BY T1.[EmpleadoId]";
         }
         scmdbuf = "SELECT " + sSelectString + sFromString + sWhereString + sOrderString + "" + " OFFSET " + "@GXPagingFrom2" + " ROWS FETCH NEXT CAST((SELECT CASE WHEN " + "@GXPagingTo2" + " > 0 THEN " + "@GXPagingTo2" + " ELSE 1e9 END) AS INTEGER) ROWS ONLY";
         GXv_Object2[0] = scmdbuf;
         GXv_Object2[1] = GXv_int1;
         return GXv_Object2 ;
      }

      protected Object[] conditional_H000K3( IGxContext context ,
                                             string AV11EmpleadoNombre ,
                                             string A2EmpleadoNombre ,
                                             short AV15OrderedBy )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int3 = new short[1];
         Object[] GXv_Object4 = new Object[2];
         scmdbuf = "SELECT COUNT(*) FROM ([Empleado] T1 LEFT JOIN [parqueAtraccion] T2 ON T2.[parqueAtraccionId] = T1.[parqueAtraccionId])";
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV11EmpleadoNombre)) )
         {
            AddWhere(sWhereString, "(T1.[EmpleadoNombre] like @lV11EmpleadoNombre)");
         }
         else
         {
            GXv_int3[0] = 1;
         }
         scmdbuf += sWhereString;
         if ( AV15OrderedBy == 1 )
         {
            scmdbuf += "";
         }
         else if ( AV15OrderedBy == 2 )
         {
            scmdbuf += "";
         }
         else if ( true )
         {
            scmdbuf += "";
         }
         GXv_Object4[0] = scmdbuf;
         GXv_Object4[1] = GXv_int3;
         return GXv_Object4 ;
      }

      public override Object [] getDynamicStatement( int cursor ,
                                                     IGxContext context ,
                                                     Object [] dynConstraints )
      {
         switch ( cursor )
         {
               case 0 :
                     return conditional_H000K2(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (short)dynConstraints[2] );
               case 1 :
                     return conditional_H000K3(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (short)dynConstraints[2] );
         }
         return base.getDynamicStatement(cursor, context, dynConstraints);
      }

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
          Object[] prmH000K2;
          prmH000K2 = new Object[] {
          new ParDef("@lV11EmpleadoNombre",GXType.NVarChar,1024,0) ,
          new ParDef("@GXPagingFrom2",GXType.Int32,9,0) ,
          new ParDef("@GXPagingTo2",GXType.Int32,9,0) ,
          new ParDef("@GXPagingTo2",GXType.Int32,9,0)
          };
          Object[] prmH000K3;
          prmH000K3 = new Object[] {
          new ParDef("@lV11EmpleadoNombre",GXType.NVarChar,1024,0)
          };
          def= new CursorDef[] {
              new CursorDef("H000K2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH000K2,11, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("H000K3", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH000K3,1, GxCacheFrequency.OFF ,true,false )
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
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((short[]) buf[1])[0] = rslt.getShort(2);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((string[]) buf[3])[0] = rslt.getVarchar(3);
                ((bool[]) buf[4])[0] = rslt.wasNull(3);
                ((string[]) buf[5])[0] = rslt.getVarchar(4);
                ((bool[]) buf[6])[0] = rslt.wasNull(4);
                ((string[]) buf[7])[0] = rslt.getVarchar(5);
                ((bool[]) buf[8])[0] = rslt.wasNull(5);
                ((DateTime[]) buf[9])[0] = rslt.getGXDateTime(6);
                ((bool[]) buf[10])[0] = rslt.wasNull(6);
                ((DateTime[]) buf[11])[0] = rslt.getGXDateTime(7);
                ((bool[]) buf[12])[0] = rslt.wasNull(7);
                ((DateTime[]) buf[13])[0] = rslt.getGXDateTime(8);
                ((bool[]) buf[14])[0] = rslt.wasNull(8);
                ((string[]) buf[15])[0] = rslt.getVarchar(9);
                ((bool[]) buf[16])[0] = rslt.wasNull(9);
                ((string[]) buf[17])[0] = rslt.getString(10, 20);
                ((bool[]) buf[18])[0] = rslt.wasNull(10);
                ((string[]) buf[19])[0] = rslt.getVarchar(11);
                ((bool[]) buf[20])[0] = rslt.wasNull(11);
                ((string[]) buf[21])[0] = rslt.getVarchar(12);
                ((string[]) buf[22])[0] = rslt.getVarchar(13);
                ((short[]) buf[23])[0] = rslt.getShort(14);
                return;
             case 1 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                return;
       }
    }

 }

}
