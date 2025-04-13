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
   public class empleadogeneral : GXWebComponent
   {
      public empleadogeneral( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         if ( StringUtil.Len( (string)(sPrefix)) == 0 )
         {
            context.SetDefaultTheme("parques", true);
         }
      }

      public empleadogeneral( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( short aP0_EmpleadoId )
      {
         this.A1EmpleadoId = aP0_EmpleadoId;
         ExecuteImpl();
      }

      protected override void ExecutePrivate( )
      {
         isStatic = false;
         webExecute();
      }

      public override void SetPrefix( string sPPrefix )
      {
         sPrefix = sPPrefix;
      }

      protected override void createObjects( )
      {
      }

      protected void INITWEB( )
      {
         initialize_properties( ) ;
         if ( StringUtil.Len( (string)(sPrefix)) == 0 )
         {
            if ( nGotPars == 0 )
            {
               entryPointCalled = false;
               gxfirstwebparm = GetFirstPar( "EmpleadoId");
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
               else if ( StringUtil.StrCmp(gxfirstwebparm, "dyncomponent") == 0 )
               {
                  setAjaxEventMode();
                  if ( ! IsValidAjaxCall( true) )
                  {
                     GxWebError = 1;
                     return  ;
                  }
                  nDynComponent = 1;
                  sCompPrefix = GetPar( "sCompPrefix");
                  sSFPrefix = GetPar( "sSFPrefix");
                  A1EmpleadoId = (short)(Math.Round(NumberUtil.Val( GetPar( "EmpleadoId"), "."), 18, MidpointRounding.ToEven));
                  AssignAttri(sPrefix, false, "A1EmpleadoId", StringUtil.LTrimStr( (decimal)(A1EmpleadoId), 4, 0));
                  setjustcreated();
                  componentprepare(new Object[] {(string)sCompPrefix,(string)sSFPrefix,(short)A1EmpleadoId});
                  componentstart();
                  context.httpAjaxContext.ajax_rspStartCmp(sPrefix);
                  componentdraw();
                  context.httpAjaxContext.ajax_rspEndCmp();
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
                  gxfirstwebparm = GetFirstPar( "EmpleadoId");
               }
               else if ( StringUtil.StrCmp(gxfirstwebparm, "gxfullajaxEvt") == 0 )
               {
                  if ( ! IsValidAjaxCall( true) )
                  {
                     GxWebError = 1;
                     return  ;
                  }
                  gxfirstwebparm = GetFirstPar( "EmpleadoId");
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
         }
         if ( StringUtil.Len( sPrefix) == 0 )
         {
            if ( ! context.IsLocalStorageSupported( ) )
            {
               context.PushCurrentUrl();
            }
         }
      }

      public override void webExecute( )
      {
         createObjects();
         initialize();
         INITWEB( ) ;
         if ( ! isAjaxCallMode( ) )
         {
            if ( StringUtil.Len( sPrefix) == 0 )
            {
               ValidateSpaRequest();
            }
            PA0L2( ) ;
            if ( ( GxWebError == 0 ) && ! isAjaxCallMode( ) )
            {
               /* GeneXus formulas. */
               AV11Pgmname = "EmpleadoGeneral";
               WS0L2( ) ;
               if ( ! isAjaxCallMode( ) )
               {
                  if ( nDynComponent == 0 )
                  {
                     throw new System.Net.WebException("WebComponent is not allowed to run") ;
                  }
               }
            }
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

      protected void RenderHtmlHeaders( )
      {
         GxWebStd.gx_html_headers( context, 0, "", "", Form.Meta, Form.Metaequiv, true);
      }

      protected void RenderHtmlOpenForm( )
      {
         if ( StringUtil.Len( sPrefix) == 0 )
         {
            if ( context.isSpaRequest( ) )
            {
               enableOutput();
            }
            context.WriteHtmlText( "<title>") ;
            context.SendWebValue( "Empleado General") ;
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
         }
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
         if ( StringUtil.Len( sPrefix) == 0 )
         {
            context.CloseHtmlHeader();
            if ( context.isSpaRequest( ) )
            {
               disableOutput();
            }
            FormProcess = " data-HasEnter=\"false\" data-Skiponenter=\"false\"";
            context.WriteHtmlText( "<body ") ;
            if ( StringUtil.StrCmp(context.GetLanguageProperty( "rtl"), "true") == 0 )
            {
               context.WriteHtmlText( " dir=\"rtl\" ") ;
            }
            bodyStyle = "";
            if ( nGXWrapped == 0 )
            {
               bodyStyle += "-moz-opacity:0;opacity:0;";
            }
            context.WriteHtmlText( " "+"class=\"form-horizontal Form\""+" "+ "style='"+bodyStyle+"'") ;
            context.WriteHtmlText( FormProcess+">") ;
            context.skipLines(1);
            context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("empleadogeneral.aspx", new object[] {UrlEncode(StringUtil.LTrimStr(A1EmpleadoId,4,0))}, new string[] {"EmpleadoId"}) +"\">") ;
            GxWebStd.gx_hidden_field( context, "_EventName", "");
            GxWebStd.gx_hidden_field( context, "_EventGridId", "");
            GxWebStd.gx_hidden_field( context, "_EventRowId", "");
            context.WriteHtmlText( "<div style=\"height:0;overflow:hidden\"><input type=\"submit\" title=\"submit\"  disabled></div>") ;
            AssignProp(sPrefix, false, "FORM", "Class", "form-horizontal Form", true);
         }
         else
         {
            bool toggleHtmlOutput = isOutputEnabled( );
            if ( StringUtil.StringSearch( sPrefix, "MP", 1) == 1 )
            {
               if ( context.isSpaRequest( ) )
               {
                  disableOutput();
               }
            }
            context.WriteHtmlText( "<div") ;
            GxWebStd.ClassAttribute( context, "gxwebcomponent-body"+" "+(String.IsNullOrEmpty(StringUtil.RTrim( Form.Class)) ? "form-horizontal Form" : Form.Class)+"-fx");
            context.WriteHtmlText( ">") ;
            if ( toggleHtmlOutput )
            {
               if ( StringUtil.StringSearch( sPrefix, "MP", 1) == 1 )
               {
                  if ( context.isSpaRequest( ) )
                  {
                     enableOutput();
                  }
               }
            }
            toggleJsOutput = isJsOutputEnabled( );
            if ( context.isSpaRequest( ) )
            {
               disableJsOutput();
            }
         }
         if ( StringUtil.StringSearch( sPrefix, "MP", 1) == 1 )
         {
            if ( context.isSpaRequest( ) )
            {
               disableOutput();
            }
         }
      }

      protected void send_integrity_footer_hashes( )
      {
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         forbiddenHiddens = new GXProperties();
         forbiddenHiddens.Add("hshsalt", sPrefix+"hsh"+"EmpleadoGeneral");
         forbiddenHiddens.Add("parqueAtraccionId", context.localUtil.Format( (decimal)(A13parqueAtraccionId), "ZZZ9"));
         GxWebStd.gx_hidden_field( context, sPrefix+"hsh", GetEncryptedHash( forbiddenHiddens.ToString(), GXKey));
         GXUtil.WriteLogInfo("empleadogeneral:[ SendSecurityCheck value for]"+forbiddenHiddens.ToJSonString());
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, sPrefix+"wcpOA1EmpleadoId", StringUtil.LTrim( StringUtil.NToC( (decimal)(wcpOA1EmpleadoId), 4, 0, ",", "")));
      }

      protected void RenderHtmlCloseForm0L2( )
      {
         SendCloseFormHiddens( ) ;
         if ( ( StringUtil.Len( sPrefix) != 0 ) && ( context.isAjaxRequest( ) || context.isSpaRequest( ) ) )
         {
            componentjscripts();
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"GX_FocusControl", GX_FocusControl);
         define_styles( ) ;
         SendSecurityToken(sPrefix);
         if ( StringUtil.Len( sPrefix) == 0 )
         {
            SendAjaxEncryptionKey();
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
            context.WriteHtmlTextNl( "</body>") ;
            context.WriteHtmlTextNl( "</html>") ;
            if ( context.isSpaRequest( ) )
            {
               enableOutput();
            }
         }
         else
         {
            SendWebComponentState();
            context.WriteHtmlText( "</div>") ;
            if ( toggleJsOutput )
            {
               if ( context.isSpaRequest( ) )
               {
                  enableJsOutput();
               }
            }
         }
      }

      public override string GetPgmname( )
      {
         return "EmpleadoGeneral" ;
      }

      public override string GetPgmdesc( )
      {
         return "Empleado General" ;
      }

      protected void WB0L0( )
      {
         if ( context.isAjaxRequest( ) )
         {
            disableOutput();
         }
         if ( ! wbLoad )
         {
            if ( StringUtil.Len( sPrefix) == 0 )
            {
               RenderHtmlHeaders( ) ;
            }
            RenderHtmlOpenForm( ) ;
            if ( StringUtil.Len( sPrefix) != 0 )
            {
               GxWebStd.gx_hidden_field( context, sPrefix+"_CMPPGM", "empleadogeneral.aspx");
            }
            GxWebStd.gx_msg_list( context, "", context.GX_msglist.DisplayMode, "", "", sPrefix, "false");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Section", "start", "top", " "+"data-gx-base-lib=\"none\""+" "+"data-abstract-form"+" ", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divMaintable_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 ww__view__actions-cell", "end", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-action-group ww__view__actions", "start", "top", " "+"data-gx-actiongroup-type=\"toolbar\""+" ", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 8,'" + sPrefix + "',false,'',0)\"";
            ClassString = "Button button-primary";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtnupdate_Internalname, "", "Modificar", bttBtnupdate_Jsonclick, 7, "Modificar", "", StyleString, ClassString, 1, 1, "standard", "'"+sPrefix+"'"+",false,"+"'"+"e110l1_client"+"'", TempTags, "", 2, "HLP_EmpleadoGeneral.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 10,'" + sPrefix + "',false,'',0)\"";
            ClassString = "Button button-tertiary";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtndelete_Internalname, "", "Eliminar", bttBtndelete_Jsonclick, 7, "Eliminar", "", StyleString, ClassString, 1, 1, "standard", "'"+sPrefix+"'"+",false,"+"'"+"e120l1_client"+"'", TempTags, "", 2, "HLP_EmpleadoGeneral.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "end", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divAttributestable_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtEmpleadoId_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtEmpleadoId_Internalname, "Id", "col-sm-3 ReadonlyAttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 18,'" + sPrefix + "',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtEmpleadoId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A1EmpleadoId), 4, 0, ",", "")), StringUtil.LTrim( ((edtEmpleadoId_Enabled!=0) ? context.localUtil.Format( (decimal)(A1EmpleadoId), "ZZZ9") : context.localUtil.Format( (decimal)(A1EmpleadoId), "ZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,18);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtEmpleadoId_Jsonclick, 0, "ReadonlyAttribute", "", "", "", "", 1, edtEmpleadoId_Enabled, 0, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_EmpleadoGeneral.htm");
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
            GxWebStd.gx_label_element( context, edtEmpleadoNombre_Internalname, "Nombre", "col-sm-3 ReadonlyAttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Multiple line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 23,'" + sPrefix + "',false,'',0)\"";
            ClassString = "ReadonlyAttribute";
            StyleString = "";
            ClassString = "ReadonlyAttribute";
            StyleString = "";
            GxWebStd.gx_html_textarea( context, edtEmpleadoNombre_Internalname, A2EmpleadoNombre, "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,23);\"", 0, 1, edtEmpleadoNombre_Enabled, 0, 80, "chr", 10, "row", 0, StyleString, ClassString, "", "", "1024", -1, 0, "", "", -1, true, "", "'"+sPrefix+"'"+",false,"+"'"+""+"'", 0, "", "HLP_EmpleadoGeneral.htm");
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
            GxWebStd.gx_label_element( context, edtEmpleadoApellido_Internalname, "Apellido", "col-sm-3 ReadonlyAttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Multiple line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 28,'" + sPrefix + "',false,'',0)\"";
            ClassString = "ReadonlyAttribute";
            StyleString = "";
            ClassString = "ReadonlyAttribute";
            StyleString = "";
            GxWebStd.gx_html_textarea( context, edtEmpleadoApellido_Internalname, A3EmpleadoApellido, "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,28);\"", 0, 1, edtEmpleadoApellido_Enabled, 0, 80, "chr", 10, "row", 0, StyleString, ClassString, "", "", "1024", -1, 0, "", "", -1, true, "", "'"+sPrefix+"'"+",false,"+"'"+""+"'", 0, "", "HLP_EmpleadoGeneral.htm");
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
            GxWebStd.gx_label_element( context, edtEmpleadoDireccion_Internalname, "Direccion", "col-sm-3 ReadonlyAttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Multiple line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 33,'" + sPrefix + "',false,'',0)\"";
            ClassString = "ReadonlyAttribute";
            StyleString = "";
            ClassString = "ReadonlyAttribute";
            StyleString = "";
            GxWebStd.gx_html_textarea( context, edtEmpleadoDireccion_Internalname, A4EmpleadoDireccion, "http://maps.google.com/maps?q="+GXUtil.UrlEncode( A4EmpleadoDireccion), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,33);\"", 0, 1, edtEmpleadoDireccion_Enabled, 0, 80, "chr", 10, "row", 0, StyleString, ClassString, "", "", "1024", -1, 0, "_blank", "", 0, true, "GeneXus\\Address", "'"+sPrefix+"'"+",false,"+"'"+""+"'", 0, "", "HLP_EmpleadoGeneral.htm");
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
            GxWebStd.gx_label_element( context, edtEmpleadoTelefono_Internalname, "Telefono", "col-sm-3 ReadonlyAttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            if ( context.isSmartDevice( ) )
            {
               gxphoneLink = "tel:" + StringUtil.RTrim( A5EmpleadoTelefono);
            }
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 38,'" + sPrefix + "',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtEmpleadoTelefono_Internalname, StringUtil.RTrim( A5EmpleadoTelefono), StringUtil.RTrim( context.localUtil.Format( A5EmpleadoTelefono, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,38);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", gxphoneLink, "", "", "", edtEmpleadoTelefono_Jsonclick, 0, "ReadonlyAttribute", "", "", "", "", 1, edtEmpleadoTelefono_Enabled, 0, "tel", "", 20, "chr", 1, "row", 20, 0, 0, 0, 0, -1, 0, true, "GeneXus\\Phone", "start", true, "", "HLP_EmpleadoGeneral.htm");
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
            GxWebStd.gx_label_element( context, edtEmpleadoEmail_Internalname, "Email", "col-sm-3 ReadonlyAttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 43,'" + sPrefix + "',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtEmpleadoEmail_Internalname, A6EmpleadoEmail, StringUtil.RTrim( context.localUtil.Format( A6EmpleadoEmail, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,43);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "mailto:"+A6EmpleadoEmail, "", "", "", edtEmpleadoEmail_Jsonclick, 0, "ReadonlyAttribute", "", "", "", "", 1, edtEmpleadoEmail_Enabled, 0, "email", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, 0, true, "GeneXus\\Email", "start", true, "", "HLP_EmpleadoGeneral.htm");
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
            GxWebStd.gx_label_element( context, edtEmpleadoFch_Alta_Internalname, "Fch_Alta", "col-sm-3 ReadonlyAttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 48,'" + sPrefix + "',false,'',0)\"";
            context.WriteHtmlText( "<div id=\""+edtEmpleadoFch_Alta_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
            GxWebStd.gx_single_line_edit( context, edtEmpleadoFch_Alta_Internalname, context.localUtil.TToC( A7EmpleadoFch_Alta, 10, 8, 0, 3, "/", ":", " "), context.localUtil.Format( A7EmpleadoFch_Alta, "99/99/99 99:99"), TempTags+" onchange=\""+"gx.date.valid_date(this, 8,'DMY',5,24,'spa',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 8,'DMY',5,24,'spa',false,0);"+";gx.evt.onblur(this,48);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtEmpleadoFch_Alta_Jsonclick, 0, "ReadonlyAttribute", "", "", "", "", 1, edtEmpleadoFch_Alta_Enabled, 0, "text", "", 14, "chr", 1, "row", 14, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_EmpleadoGeneral.htm");
            GxWebStd.gx_bitmap( context, edtEmpleadoFch_Alta_Internalname+"_dp_trigger", context.GetImagePath( "", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtEmpleadoFch_Alta_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_EmpleadoGeneral.htm");
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
            GxWebStd.gx_label_element( context, edtEmpleadoFcha_Mod_Internalname, "Fcha_Mod", "col-sm-3 ReadonlyAttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 53,'" + sPrefix + "',false,'',0)\"";
            context.WriteHtmlText( "<div id=\""+edtEmpleadoFcha_Mod_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
            GxWebStd.gx_single_line_edit( context, edtEmpleadoFcha_Mod_Internalname, context.localUtil.TToC( A8EmpleadoFcha_Mod, 10, 8, 0, 3, "/", ":", " "), context.localUtil.Format( A8EmpleadoFcha_Mod, "99/99/99 99:99"), TempTags+" onchange=\""+"gx.date.valid_date(this, 8,'DMY',5,24,'spa',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 8,'DMY',5,24,'spa',false,0);"+";gx.evt.onblur(this,53);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtEmpleadoFcha_Mod_Jsonclick, 0, "ReadonlyAttribute", "", "", "", "", 1, edtEmpleadoFcha_Mod_Enabled, 0, "text", "", 14, "chr", 1, "row", 14, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_EmpleadoGeneral.htm");
            GxWebStd.gx_bitmap( context, edtEmpleadoFcha_Mod_Internalname+"_dp_trigger", context.GetImagePath( "", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtEmpleadoFcha_Mod_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_EmpleadoGeneral.htm");
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
            GxWebStd.gx_label_element( context, edtEmpleadoFch_Cad_Internalname, "Fch_Cad", "col-sm-3 ReadonlyAttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 58,'" + sPrefix + "',false,'',0)\"";
            context.WriteHtmlText( "<div id=\""+edtEmpleadoFch_Cad_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
            GxWebStd.gx_single_line_edit( context, edtEmpleadoFch_Cad_Internalname, context.localUtil.TToC( A9EmpleadoFch_Cad, 10, 8, 0, 3, "/", ":", " "), context.localUtil.Format( A9EmpleadoFch_Cad, "99/99/99 99:99"), TempTags+" onchange=\""+"gx.date.valid_date(this, 8,'DMY',5,24,'spa',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 8,'DMY',5,24,'spa',false,0);"+";gx.evt.onblur(this,58);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtEmpleadoFch_Cad_Jsonclick, 0, "ReadonlyAttribute", "", "", "", "", 1, edtEmpleadoFch_Cad_Enabled, 0, "text", "", 14, "chr", 1, "row", 14, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_EmpleadoGeneral.htm");
            GxWebStd.gx_bitmap( context, edtEmpleadoFch_Cad_Internalname+"_dp_trigger", context.GetImagePath( "", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtEmpleadoFch_Cad_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_EmpleadoGeneral.htm");
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
            GxWebStd.gx_label_element( context, edtEmpleadoUsu_Alta_Internalname, "Usu_Alta", "col-sm-3 ReadonlyAttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 63,'" + sPrefix + "',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtEmpleadoUsu_Alta_Internalname, A10EmpleadoUsu_Alta, StringUtil.RTrim( context.localUtil.Format( A10EmpleadoUsu_Alta, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,63);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtEmpleadoUsu_Alta_Jsonclick, 0, "ReadonlyAttribute", "", "", "", "", 1, edtEmpleadoUsu_Alta_Enabled, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_EmpleadoGeneral.htm");
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
            GxWebStd.gx_label_element( context, edtEmpleadoUsu_Mod_Internalname, "Usu_Mod", "col-sm-3 ReadonlyAttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 68,'" + sPrefix + "',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtEmpleadoUsu_Mod_Internalname, A11EmpleadoUsu_Mod, StringUtil.RTrim( context.localUtil.Format( A11EmpleadoUsu_Mod, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,68);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtEmpleadoUsu_Mod_Jsonclick, 0, "ReadonlyAttribute", "", "", "", "", 1, edtEmpleadoUsu_Mod_Enabled, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_EmpleadoGeneral.htm");
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
            GxWebStd.gx_label_element( context, edtEmpleadoUso_Cad_Internalname, "Uso_Cad", "col-sm-3 ReadonlyAttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 73,'" + sPrefix + "',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtEmpleadoUso_Cad_Internalname, A12EmpleadoUso_Cad, StringUtil.RTrim( context.localUtil.Format( A12EmpleadoUso_Cad, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,73);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtEmpleadoUso_Cad_Jsonclick, 0, "ReadonlyAttribute", "", "", "", "", 1, edtEmpleadoUso_Cad_Enabled, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_EmpleadoGeneral.htm");
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
            GxWebStd.gx_label_element( context, edtparqueAtraccionId_Internalname, "parque Atraccion Id", "col-sm-3 ReadonlyAttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 78,'" + sPrefix + "',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtparqueAtraccionId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A13parqueAtraccionId), 4, 0, ",", "")), StringUtil.LTrim( ((edtparqueAtraccionId_Enabled!=0) ? context.localUtil.Format( (decimal)(A13parqueAtraccionId), "ZZZ9") : context.localUtil.Format( (decimal)(A13parqueAtraccionId), "ZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,78);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtparqueAtraccionId_Jsonclick, 0, "ReadonlyAttribute", "", "", "", "", 1, edtparqueAtraccionId_Enabled, 0, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_EmpleadoGeneral.htm");
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
            GxWebStd.gx_label_element( context, edtparqueAtraccionNombre_Internalname, "parque Atraccion Nombre", "col-sm-3 ReadonlyAttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 83,'" + sPrefix + "',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtparqueAtraccionNombre_Internalname, A14parqueAtraccionNombre, StringUtil.RTrim( context.localUtil.Format( A14parqueAtraccionNombre, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,83);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", edtparqueAtraccionNombre_Link, "", "", "", edtparqueAtraccionNombre_Jsonclick, 0, "ReadonlyAttribute", "", "", "", "", 1, edtparqueAtraccionNombre_Enabled, 0, "text", "", 20, "chr", 1, "row", 20, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_EmpleadoGeneral.htm");
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
         wbLoad = true;
      }

      protected void START0L2( )
      {
         wbLoad = false;
         wbEnd = 0;
         wbStart = 0;
         if ( StringUtil.Len( sPrefix) == 0 )
         {
            if ( ! context.isSpaRequest( ) )
            {
               if ( context.ExposeMetadata( ) )
               {
                  Form.Meta.addItem("generator", "GeneXus .NET 18_0_10-184260", 0) ;
               }
            }
            Form.Meta.addItem("description", "Empleado General", 0) ;
            context.wjLoc = "";
            context.nUserReturn = 0;
            context.wbHandled = 0;
            if ( StringUtil.Len( sPrefix) == 0 )
            {
               sXEvt = cgiGet( "_EventName");
               if ( ! GetJustCreated( ) && ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 ) )
               {
               }
            }
         }
         wbErr = false;
         if ( ( StringUtil.Len( sPrefix) == 0 ) || ( nDraw == 1 ) )
         {
            if ( nDoneStart == 0 )
            {
               STRUP0L0( ) ;
            }
         }
      }

      protected void WS0L2( )
      {
         START0L2( ) ;
         EVT0L2( ) ;
      }

      protected void EVT0L2( )
      {
         sXEvt = cgiGet( "_EventName");
         if ( ( ( ( StringUtil.Len( sPrefix) == 0 ) ) || ( StringUtil.StringSearch( sXEvt, sPrefix, 1) > 0 ) ) && ! GetJustCreated( ) && ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 ) )
         {
            if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) && ! wbErr )
            {
               /* Read Web Panel buttons. */
               if ( context.wbHandled == 0 )
               {
                  if ( StringUtil.Len( sPrefix) == 0 )
                  {
                     sEvt = cgiGet( "_EventName");
                     EvtGridId = cgiGet( "_EventGridId");
                     EvtRowId = cgiGet( "_EventRowId");
                  }
                  if ( StringUtil.Len( sEvt) > 0 )
                  {
                     sEvtType = StringUtil.Left( sEvt, 1);
                     sEvt = StringUtil.Right( sEvt, (short)(StringUtil.Len( sEvt)-1));
                     if ( StringUtil.StrCmp(sEvtType, "E") == 0 )
                     {
                        sEvtType = StringUtil.Right( sEvt, 1);
                        if ( StringUtil.StrCmp(sEvtType, ".") == 0 )
                        {
                           sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-1));
                           if ( StringUtil.StrCmp(sEvt, "RFR") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP0L0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "START") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP0L0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: Start */
                                    E130L2 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "LOAD") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP0L0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: Load */
                                    E140L2 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "ENTER") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP0L0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    if ( ! wbErr )
                                    {
                                       Rfr0gs = false;
                                       if ( ! Rfr0gs )
                                       {
                                       }
                                       dynload_actions( ) ;
                                    }
                                 }
                              }
                              /* No code required for Cancel button. It is implemented as the Reset button. */
                           }
                           else if ( StringUtil.StrCmp(sEvt, "LSCR") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP0L0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                 }
                              }
                              dynload_actions( ) ;
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
      }

      protected void WE0L2( )
      {
         if ( ! GxWebStd.gx_redirect( context) )
         {
            Rfr0gs = true;
            Refresh( ) ;
            if ( ! GxWebStd.gx_redirect( context) )
            {
               RenderHtmlCloseForm0L2( ) ;
            }
         }
      }

      protected void PA0L2( )
      {
         if ( nDonePA == 0 )
         {
            if ( StringUtil.Len( sPrefix) != 0 )
            {
               initialize_properties( ) ;
            }
            if ( StringUtil.Len( sPrefix) == 0 )
            {
               if ( String.IsNullOrEmpty(StringUtil.RTrim( context.GetCookie( "GX_SESSION_ID"))) )
               {
                  gxcookieaux = context.SetCookie( "GX_SESSION_ID", Encrypt64( Crypto.GetEncryptionKey( ), Crypto.GetServerKey( )), "", (DateTime)(DateTime.MinValue), "", (short)(context.GetHttpSecure( )));
               }
            }
            GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
            toggleJsOutput = isJsOutputEnabled( );
            if ( StringUtil.Len( sPrefix) == 0 )
            {
               if ( context.isSpaRequest( ) )
               {
                  disableJsOutput();
               }
            }
            init_web_controls( ) ;
            if ( StringUtil.Len( sPrefix) == 0 )
            {
               if ( toggleJsOutput )
               {
                  if ( context.isSpaRequest( ) )
                  {
                     enableJsOutput();
                  }
               }
            }
            if ( ! context.isAjaxRequest( ) )
            {
            }
            nDonePA = 1;
         }
      }

      protected void dynload_actions( )
      {
         /* End function dynload_actions */
      }

      protected void send_integrity_hashes( )
      {
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
      }

      public void Refresh( )
      {
         send_integrity_hashes( ) ;
         RF0L2( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
         AV11Pgmname = "EmpleadoGeneral";
      }

      protected void RF0L2( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = true;
         fix_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = false;
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            /* Using cursor H000L2 */
            pr_default.execute(0, new Object[] {A1EmpleadoId});
            while ( (pr_default.getStatus(0) != 101) )
            {
               A14parqueAtraccionNombre = H000L2_A14parqueAtraccionNombre[0];
               AssignAttri(sPrefix, false, "A14parqueAtraccionNombre", A14parqueAtraccionNombre);
               A13parqueAtraccionId = H000L2_A13parqueAtraccionId[0];
               AssignAttri(sPrefix, false, "A13parqueAtraccionId", StringUtil.LTrimStr( (decimal)(A13parqueAtraccionId), 4, 0));
               A12EmpleadoUso_Cad = H000L2_A12EmpleadoUso_Cad[0];
               n12EmpleadoUso_Cad = H000L2_n12EmpleadoUso_Cad[0];
               AssignAttri(sPrefix, false, "A12EmpleadoUso_Cad", A12EmpleadoUso_Cad);
               A11EmpleadoUsu_Mod = H000L2_A11EmpleadoUsu_Mod[0];
               n11EmpleadoUsu_Mod = H000L2_n11EmpleadoUsu_Mod[0];
               AssignAttri(sPrefix, false, "A11EmpleadoUsu_Mod", A11EmpleadoUsu_Mod);
               A10EmpleadoUsu_Alta = H000L2_A10EmpleadoUsu_Alta[0];
               n10EmpleadoUsu_Alta = H000L2_n10EmpleadoUsu_Alta[0];
               AssignAttri(sPrefix, false, "A10EmpleadoUsu_Alta", A10EmpleadoUsu_Alta);
               A9EmpleadoFch_Cad = H000L2_A9EmpleadoFch_Cad[0];
               n9EmpleadoFch_Cad = H000L2_n9EmpleadoFch_Cad[0];
               AssignAttri(sPrefix, false, "A9EmpleadoFch_Cad", context.localUtil.TToC( A9EmpleadoFch_Cad, 8, 5, 0, 3, "/", ":", " "));
               A8EmpleadoFcha_Mod = H000L2_A8EmpleadoFcha_Mod[0];
               n8EmpleadoFcha_Mod = H000L2_n8EmpleadoFcha_Mod[0];
               AssignAttri(sPrefix, false, "A8EmpleadoFcha_Mod", context.localUtil.TToC( A8EmpleadoFcha_Mod, 8, 5, 0, 3, "/", ":", " "));
               A7EmpleadoFch_Alta = H000L2_A7EmpleadoFch_Alta[0];
               n7EmpleadoFch_Alta = H000L2_n7EmpleadoFch_Alta[0];
               AssignAttri(sPrefix, false, "A7EmpleadoFch_Alta", context.localUtil.TToC( A7EmpleadoFch_Alta, 8, 5, 0, 3, "/", ":", " "));
               A6EmpleadoEmail = H000L2_A6EmpleadoEmail[0];
               n6EmpleadoEmail = H000L2_n6EmpleadoEmail[0];
               AssignAttri(sPrefix, false, "A6EmpleadoEmail", A6EmpleadoEmail);
               A5EmpleadoTelefono = H000L2_A5EmpleadoTelefono[0];
               n5EmpleadoTelefono = H000L2_n5EmpleadoTelefono[0];
               AssignAttri(sPrefix, false, "A5EmpleadoTelefono", A5EmpleadoTelefono);
               A4EmpleadoDireccion = H000L2_A4EmpleadoDireccion[0];
               n4EmpleadoDireccion = H000L2_n4EmpleadoDireccion[0];
               AssignAttri(sPrefix, false, "A4EmpleadoDireccion", A4EmpleadoDireccion);
               A3EmpleadoApellido = H000L2_A3EmpleadoApellido[0];
               AssignAttri(sPrefix, false, "A3EmpleadoApellido", A3EmpleadoApellido);
               A2EmpleadoNombre = H000L2_A2EmpleadoNombre[0];
               AssignAttri(sPrefix, false, "A2EmpleadoNombre", A2EmpleadoNombre);
               A14parqueAtraccionNombre = H000L2_A14parqueAtraccionNombre[0];
               AssignAttri(sPrefix, false, "A14parqueAtraccionNombre", A14parqueAtraccionNombre);
               /* Execute user event: Load */
               E140L2 ();
               /* Exiting from a For First loop. */
               if (true) break;
            }
            pr_default.close(0);
            WB0L0( ) ;
         }
      }

      protected void send_integrity_lvl_hashes0L2( )
      {
      }

      protected void before_start_formulas( )
      {
         AV11Pgmname = "EmpleadoGeneral";
         edtEmpleadoId_Enabled = 0;
         AssignProp(sPrefix, false, edtEmpleadoId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtEmpleadoId_Enabled), 5, 0), true);
         edtEmpleadoNombre_Enabled = 0;
         AssignProp(sPrefix, false, edtEmpleadoNombre_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtEmpleadoNombre_Enabled), 5, 0), true);
         edtEmpleadoApellido_Enabled = 0;
         AssignProp(sPrefix, false, edtEmpleadoApellido_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtEmpleadoApellido_Enabled), 5, 0), true);
         edtEmpleadoDireccion_Enabled = 0;
         AssignProp(sPrefix, false, edtEmpleadoDireccion_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtEmpleadoDireccion_Enabled), 5, 0), true);
         edtEmpleadoTelefono_Enabled = 0;
         AssignProp(sPrefix, false, edtEmpleadoTelefono_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtEmpleadoTelefono_Enabled), 5, 0), true);
         edtEmpleadoEmail_Enabled = 0;
         AssignProp(sPrefix, false, edtEmpleadoEmail_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtEmpleadoEmail_Enabled), 5, 0), true);
         edtEmpleadoFch_Alta_Enabled = 0;
         AssignProp(sPrefix, false, edtEmpleadoFch_Alta_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtEmpleadoFch_Alta_Enabled), 5, 0), true);
         edtEmpleadoFcha_Mod_Enabled = 0;
         AssignProp(sPrefix, false, edtEmpleadoFcha_Mod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtEmpleadoFcha_Mod_Enabled), 5, 0), true);
         edtEmpleadoFch_Cad_Enabled = 0;
         AssignProp(sPrefix, false, edtEmpleadoFch_Cad_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtEmpleadoFch_Cad_Enabled), 5, 0), true);
         edtEmpleadoUsu_Alta_Enabled = 0;
         AssignProp(sPrefix, false, edtEmpleadoUsu_Alta_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtEmpleadoUsu_Alta_Enabled), 5, 0), true);
         edtEmpleadoUsu_Mod_Enabled = 0;
         AssignProp(sPrefix, false, edtEmpleadoUsu_Mod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtEmpleadoUsu_Mod_Enabled), 5, 0), true);
         edtEmpleadoUso_Cad_Enabled = 0;
         AssignProp(sPrefix, false, edtEmpleadoUso_Cad_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtEmpleadoUso_Cad_Enabled), 5, 0), true);
         edtparqueAtraccionId_Enabled = 0;
         AssignProp(sPrefix, false, edtparqueAtraccionId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtparqueAtraccionId_Enabled), 5, 0), true);
         edtparqueAtraccionNombre_Enabled = 0;
         AssignProp(sPrefix, false, edtparqueAtraccionNombre_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtparqueAtraccionNombre_Enabled), 5, 0), true);
         fix_multi_value_controls( ) ;
      }

      protected void STRUP0L0( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E130L2 ();
         context.wbGlbDoneStart = 1;
         nDoneStart = 1;
         /* After Start, stand alone formulas. */
         sXEvt = cgiGet( "_EventName");
         if ( ! GetJustCreated( ) && ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 ) )
         {
            /* Read saved SDTs. */
            /* Read saved values. */
            wcpOA1EmpleadoId = (short)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"wcpOA1EmpleadoId"), ",", "."), 18, MidpointRounding.ToEven));
            /* Read variables values. */
            A2EmpleadoNombre = cgiGet( edtEmpleadoNombre_Internalname);
            AssignAttri(sPrefix, false, "A2EmpleadoNombre", A2EmpleadoNombre);
            A3EmpleadoApellido = cgiGet( edtEmpleadoApellido_Internalname);
            AssignAttri(sPrefix, false, "A3EmpleadoApellido", A3EmpleadoApellido);
            A4EmpleadoDireccion = cgiGet( edtEmpleadoDireccion_Internalname);
            n4EmpleadoDireccion = false;
            AssignAttri(sPrefix, false, "A4EmpleadoDireccion", A4EmpleadoDireccion);
            A5EmpleadoTelefono = cgiGet( edtEmpleadoTelefono_Internalname);
            n5EmpleadoTelefono = false;
            AssignAttri(sPrefix, false, "A5EmpleadoTelefono", A5EmpleadoTelefono);
            A6EmpleadoEmail = cgiGet( edtEmpleadoEmail_Internalname);
            n6EmpleadoEmail = false;
            AssignAttri(sPrefix, false, "A6EmpleadoEmail", A6EmpleadoEmail);
            A7EmpleadoFch_Alta = context.localUtil.CToT( cgiGet( edtEmpleadoFch_Alta_Internalname));
            n7EmpleadoFch_Alta = false;
            AssignAttri(sPrefix, false, "A7EmpleadoFch_Alta", context.localUtil.TToC( A7EmpleadoFch_Alta, 8, 5, 0, 3, "/", ":", " "));
            A8EmpleadoFcha_Mod = context.localUtil.CToT( cgiGet( edtEmpleadoFcha_Mod_Internalname));
            n8EmpleadoFcha_Mod = false;
            AssignAttri(sPrefix, false, "A8EmpleadoFcha_Mod", context.localUtil.TToC( A8EmpleadoFcha_Mod, 8, 5, 0, 3, "/", ":", " "));
            A9EmpleadoFch_Cad = context.localUtil.CToT( cgiGet( edtEmpleadoFch_Cad_Internalname));
            n9EmpleadoFch_Cad = false;
            AssignAttri(sPrefix, false, "A9EmpleadoFch_Cad", context.localUtil.TToC( A9EmpleadoFch_Cad, 8, 5, 0, 3, "/", ":", " "));
            A10EmpleadoUsu_Alta = cgiGet( edtEmpleadoUsu_Alta_Internalname);
            n10EmpleadoUsu_Alta = false;
            AssignAttri(sPrefix, false, "A10EmpleadoUsu_Alta", A10EmpleadoUsu_Alta);
            A11EmpleadoUsu_Mod = cgiGet( edtEmpleadoUsu_Mod_Internalname);
            n11EmpleadoUsu_Mod = false;
            AssignAttri(sPrefix, false, "A11EmpleadoUsu_Mod", A11EmpleadoUsu_Mod);
            A12EmpleadoUso_Cad = cgiGet( edtEmpleadoUso_Cad_Internalname);
            n12EmpleadoUso_Cad = false;
            AssignAttri(sPrefix, false, "A12EmpleadoUso_Cad", A12EmpleadoUso_Cad);
            A13parqueAtraccionId = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtparqueAtraccionId_Internalname), ",", "."), 18, MidpointRounding.ToEven));
            AssignAttri(sPrefix, false, "A13parqueAtraccionId", StringUtil.LTrimStr( (decimal)(A13parqueAtraccionId), 4, 0));
            A14parqueAtraccionNombre = cgiGet( edtparqueAtraccionNombre_Internalname);
            AssignAttri(sPrefix, false, "A14parqueAtraccionNombre", A14parqueAtraccionNombre);
            /* Read subfile selected row values. */
            /* Read hidden variables. */
            GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
            forbiddenHiddens = new GXProperties();
            forbiddenHiddens.Add("hshsalt", sPrefix+"hsh"+"EmpleadoGeneral");
            A13parqueAtraccionId = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtparqueAtraccionId_Internalname), ",", "."), 18, MidpointRounding.ToEven));
            AssignAttri(sPrefix, false, "A13parqueAtraccionId", StringUtil.LTrimStr( (decimal)(A13parqueAtraccionId), 4, 0));
            forbiddenHiddens.Add("parqueAtraccionId", context.localUtil.Format( (decimal)(A13parqueAtraccionId), "ZZZ9"));
            hsh = cgiGet( sPrefix+"hsh");
            if ( ! GXUtil.CheckEncryptedHash( forbiddenHiddens.ToString(), hsh, GXKey) )
            {
               GXUtil.WriteLogError("empleadogeneral:[ SecurityCheckFailed (403 Forbidden) value for]"+forbiddenHiddens.ToJSonString());
               GxWebError = 1;
               context.HttpContext.Response.StatusCode = 403;
               context.WriteHtmlText( "<title>403 Forbidden</title>") ;
               context.WriteHtmlText( "<h1>403 Forbidden</h1>") ;
               context.WriteHtmlText( "<p /><hr />") ;
               GXUtil.WriteLog("send_http_error_code " + 403.ToString());
               return  ;
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
         E130L2 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
      }

      protected void E130L2( )
      {
         /* Start Routine */
         returnInSub = false;
         if ( ! new GeneXus.Programs.general.security.isauthorized(context).executeUdp(  AV11Pgmname) )
         {
            CallWebObject(formatLink("general.security.notauthorized.aspx", new object[] {UrlEncode(StringUtil.RTrim(AV11Pgmname))}, new string[] {"GxObject"}) );
            context.wjLocDisableFrm = 1;
         }
         /* Execute user subroutine: 'PREPARETRANSACTION' */
         S112 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
      }

      protected void nextLoad( )
      {
      }

      protected void E140L2( )
      {
         /* Load Routine */
         returnInSub = false;
         edtparqueAtraccionNombre_Link = formatLink("viewparqueatraccion.aspx", new object[] {UrlEncode(StringUtil.LTrimStr(A13parqueAtraccionId,4,0)),UrlEncode(StringUtil.RTrim(""))}, new string[] {"parqueAtraccionId","TabCode"}) ;
         AssignProp(sPrefix, false, edtparqueAtraccionNombre_Internalname, "Link", edtparqueAtraccionNombre_Link, true);
      }

      protected void S112( )
      {
         /* 'PREPARETRANSACTION' Routine */
         returnInSub = false;
         AV7TrnContext = new GeneXus.Programs.general.ui.SdtTransactionContext(context);
         AV7TrnContext.gxTpr_Callerobject = AV11Pgmname;
         AV7TrnContext.gxTpr_Callerondelete = false;
         AV7TrnContext.gxTpr_Callerurl = AV10HTTPRequest.ScriptName+"?"+AV10HTTPRequest.QueryString;
         AV7TrnContext.gxTpr_Transactionname = "Empleado";
         AV8TrnContextAtt = new GeneXus.Programs.general.ui.SdtTransactionContext_Attribute(context);
         AV8TrnContextAtt.gxTpr_Attributename = "EmpleadoId";
         AV8TrnContextAtt.gxTpr_Attributevalue = StringUtil.Str( (decimal)(AV6EmpleadoId), 4, 0);
         AV7TrnContext.gxTpr_Attributes.Add(AV8TrnContextAtt, 0);
         AV9Session.Set("TrnContext", AV7TrnContext.ToXml(false, true, "", ""));
      }

      public override void setparameters( Object[] obj )
      {
         createObjects();
         initialize();
         A1EmpleadoId = Convert.ToInt16(getParm(obj,0));
         AssignAttri(sPrefix, false, "A1EmpleadoId", StringUtil.LTrimStr( (decimal)(A1EmpleadoId), 4, 0));
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
         PA0L2( ) ;
         WS0L2( ) ;
         WE0L2( ) ;
         cleanup();
         context.SetWrapped(false);
         SaveComponentMsgList(sPrefix);
         context.GX_msglist = BackMsgLst;
         return "";
      }

      public void responsestatic( string sGXDynURL )
      {
      }

      public override void componentbind( Object[] obj )
      {
         if ( IsUrlCreated( ) )
         {
            return  ;
         }
         sCtrlA1EmpleadoId = (string)((string)getParm(obj,0));
      }

      public override void componentrestorestate( string sPPrefix ,
                                                  string sPSFPrefix )
      {
         sPrefix = sPPrefix + sPSFPrefix;
         PA0L2( ) ;
         WCParametersGet( ) ;
      }

      public override void componentprepare( Object[] obj )
      {
         wbLoad = false;
         sCompPrefix = (string)getParm(obj,0);
         sSFPrefix = (string)getParm(obj,1);
         sPrefix = sCompPrefix + sSFPrefix;
         AddComponentObject(sPrefix, "empleadogeneral", GetJustCreated( ));
         if ( ( nDoneStart == 0 ) && ( nDynComponent == 0 ) )
         {
            INITWEB( ) ;
         }
         else
         {
            init_default_properties( ) ;
            init_web_controls( ) ;
         }
         PA0L2( ) ;
         if ( ! GetJustCreated( ) && ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 ) && ( context.wbGlbDoneStart == 0 ) )
         {
            WCParametersGet( ) ;
         }
         else
         {
            A1EmpleadoId = Convert.ToInt16(getParm(obj,2));
            AssignAttri(sPrefix, false, "A1EmpleadoId", StringUtil.LTrimStr( (decimal)(A1EmpleadoId), 4, 0));
         }
         wcpOA1EmpleadoId = (short)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"wcpOA1EmpleadoId"), ",", "."), 18, MidpointRounding.ToEven));
         if ( ! GetJustCreated( ) && ( ( A1EmpleadoId != wcpOA1EmpleadoId ) ) )
         {
            setjustcreated();
         }
         wcpOA1EmpleadoId = A1EmpleadoId;
      }

      protected void WCParametersGet( )
      {
         /* Read Component Parameters. */
         sCtrlA1EmpleadoId = cgiGet( sPrefix+"A1EmpleadoId_CTRL");
         if ( StringUtil.Len( sCtrlA1EmpleadoId) > 0 )
         {
            A1EmpleadoId = (short)(Math.Round(context.localUtil.CToN( cgiGet( sCtrlA1EmpleadoId), ",", "."), 18, MidpointRounding.ToEven));
            AssignAttri(sPrefix, false, "A1EmpleadoId", StringUtil.LTrimStr( (decimal)(A1EmpleadoId), 4, 0));
         }
         else
         {
            A1EmpleadoId = (short)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"A1EmpleadoId_PARM"), ",", "."), 18, MidpointRounding.ToEven));
         }
      }

      public override void componentprocess( string sPPrefix ,
                                             string sPSFPrefix ,
                                             string sCompEvt )
      {
         sCompPrefix = sPPrefix;
         sSFPrefix = sPSFPrefix;
         sPrefix = sCompPrefix + sSFPrefix;
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         INITWEB( ) ;
         nDraw = 0;
         PA0L2( ) ;
         sEvt = sCompEvt;
         WCParametersGet( ) ;
         WS0L2( ) ;
         if ( isFullAjaxMode( ) )
         {
            componentdraw();
         }
         SaveComponentMsgList(sPrefix);
         context.GX_msglist = BackMsgLst;
      }

      public override void componentstart( )
      {
         if ( nDoneStart == 0 )
         {
            WCStart( ) ;
         }
      }

      protected void WCStart( )
      {
         nDraw = 1;
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         WS0L2( ) ;
         SaveComponentMsgList(sPrefix);
         context.GX_msglist = BackMsgLst;
      }

      protected void WCParametersSet( )
      {
         GxWebStd.gx_hidden_field( context, sPrefix+"A1EmpleadoId_PARM", StringUtil.LTrim( StringUtil.NToC( (decimal)(A1EmpleadoId), 4, 0, ",", "")));
         if ( StringUtil.Len( StringUtil.RTrim( sCtrlA1EmpleadoId)) > 0 )
         {
            GxWebStd.gx_hidden_field( context, sPrefix+"A1EmpleadoId_CTRL", StringUtil.RTrim( sCtrlA1EmpleadoId));
         }
      }

      public override void componentdraw( )
      {
         if ( nDoneStart == 0 )
         {
            WCStart( ) ;
         }
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         WCParametersSet( ) ;
         WE0L2( ) ;
         SaveComponentMsgList(sPrefix);
         context.GX_msglist = BackMsgLst;
      }

      public override string getstring( string sGXControl )
      {
         string sCtrlName;
         if ( StringUtil.StrCmp(StringUtil.Substring( sGXControl, 1, 1), "&") == 0 )
         {
            sCtrlName = StringUtil.Substring( sGXControl, 2, StringUtil.Len( sGXControl)-1);
         }
         else
         {
            sCtrlName = sGXControl;
         }
         return cgiGet( sPrefix+"v"+StringUtil.Upper( sCtrlName)) ;
      }

      public override void componentjscripts( )
      {
         include_jscripts( ) ;
      }

      public override void componentthemes( )
      {
         define_styles( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?202541223451580", true, true);
            idxLst = (int)(idxLst+1);
         }
         if ( ! outputEnabled )
         {
            if ( context.isSpaRequest( ) )
            {
               disableOutput();
            }
         }
         CloseStyles();
         /* End function define_styles */
      }

      protected void include_jscripts( )
      {
         context.AddJavascriptSource("empleadogeneral.js", "?202541223451580", false, true);
         /* End function include_jscripts */
      }

      protected void init_web_controls( )
      {
         /* End function init_web_controls */
      }

      protected void init_default_properties( )
      {
         bttBtnupdate_Internalname = sPrefix+"BTNUPDATE";
         bttBtndelete_Internalname = sPrefix+"BTNDELETE";
         edtEmpleadoId_Internalname = sPrefix+"EMPLEADOID";
         edtEmpleadoNombre_Internalname = sPrefix+"EMPLEADONOMBRE";
         edtEmpleadoApellido_Internalname = sPrefix+"EMPLEADOAPELLIDO";
         edtEmpleadoDireccion_Internalname = sPrefix+"EMPLEADODIRECCION";
         edtEmpleadoTelefono_Internalname = sPrefix+"EMPLEADOTELEFONO";
         edtEmpleadoEmail_Internalname = sPrefix+"EMPLEADOEMAIL";
         edtEmpleadoFch_Alta_Internalname = sPrefix+"EMPLEADOFCH_ALTA";
         edtEmpleadoFcha_Mod_Internalname = sPrefix+"EMPLEADOFCHA_MOD";
         edtEmpleadoFch_Cad_Internalname = sPrefix+"EMPLEADOFCH_CAD";
         edtEmpleadoUsu_Alta_Internalname = sPrefix+"EMPLEADOUSU_ALTA";
         edtEmpleadoUsu_Mod_Internalname = sPrefix+"EMPLEADOUSU_MOD";
         edtEmpleadoUso_Cad_Internalname = sPrefix+"EMPLEADOUSO_CAD";
         edtparqueAtraccionId_Internalname = sPrefix+"PARQUEATRACCIONID";
         edtparqueAtraccionNombre_Internalname = sPrefix+"PARQUEATRACCIONNOMBRE";
         divAttributestable_Internalname = sPrefix+"ATTRIBUTESTABLE";
         divMaintable_Internalname = sPrefix+"MAINTABLE";
         Form.Internalname = sPrefix+"FORM";
      }

      public override void initialize_properties( )
      {
         if ( StringUtil.Len( sPrefix) == 0 )
         {
            context.SetDefaultTheme("parques", true);
         }
         if ( StringUtil.Len( sPrefix) == 0 )
         {
            if ( context.isSpaRequest( ) )
            {
               disableJsOutput();
            }
         }
         init_default_properties( ) ;
         edtparqueAtraccionNombre_Jsonclick = "";
         edtparqueAtraccionNombre_Link = "";
         edtparqueAtraccionNombre_Enabled = 0;
         edtparqueAtraccionId_Jsonclick = "";
         edtparqueAtraccionId_Enabled = 0;
         edtEmpleadoUso_Cad_Jsonclick = "";
         edtEmpleadoUso_Cad_Enabled = 0;
         edtEmpleadoUsu_Mod_Jsonclick = "";
         edtEmpleadoUsu_Mod_Enabled = 0;
         edtEmpleadoUsu_Alta_Jsonclick = "";
         edtEmpleadoUsu_Alta_Enabled = 0;
         edtEmpleadoFch_Cad_Jsonclick = "";
         edtEmpleadoFch_Cad_Enabled = 0;
         edtEmpleadoFcha_Mod_Jsonclick = "";
         edtEmpleadoFcha_Mod_Enabled = 0;
         edtEmpleadoFch_Alta_Jsonclick = "";
         edtEmpleadoFch_Alta_Enabled = 0;
         edtEmpleadoEmail_Jsonclick = "";
         edtEmpleadoEmail_Enabled = 0;
         edtEmpleadoTelefono_Jsonclick = "";
         edtEmpleadoTelefono_Enabled = 0;
         edtEmpleadoDireccion_Enabled = 0;
         edtEmpleadoApellido_Enabled = 0;
         edtEmpleadoNombre_Enabled = 0;
         edtEmpleadoId_Jsonclick = "";
         edtEmpleadoId_Enabled = 0;
         if ( StringUtil.Len( sPrefix) == 0 )
         {
            if ( context.isSpaRequest( ) )
            {
               enableJsOutput();
            }
         }
      }

      public override bool SupportAjaxEvent( )
      {
         return true ;
      }

      public override void InitializeDynEvents( )
      {
         setEventMetadata("REFRESH","""{"handler":"Refresh","iparms":[{"av":"A1EmpleadoId","fld":"EMPLEADOID","pic":"ZZZ9"},{"av":"A13parqueAtraccionId","fld":"PARQUEATRACCIONID","pic":"ZZZ9"}]}""");
         setEventMetadata("'DOUPDATE'","""{"handler":"E110L1","iparms":[{"av":"A1EmpleadoId","fld":"EMPLEADOID","pic":"ZZZ9"}]}""");
         setEventMetadata("'DODELETE'","""{"handler":"E120L1","iparms":[{"av":"A1EmpleadoId","fld":"EMPLEADOID","pic":"ZZZ9"}]}""");
         setEventMetadata("VALID_EMPLEADOID","""{"handler":"Valid_Empleadoid","iparms":[]}""");
         setEventMetadata("VALID_PARQUEATRACCIONID","""{"handler":"Valid_Parqueatraccionid","iparms":[]}""");
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
         sPrefix = "";
         AV11Pgmname = "";
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXKey = "";
         forbiddenHiddens = new GXProperties();
         GX_FocusControl = "";
         TempTags = "";
         ClassString = "";
         StyleString = "";
         bttBtnupdate_Jsonclick = "";
         bttBtndelete_Jsonclick = "";
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
         A14parqueAtraccionNombre = "";
         Form = new GXWebForm();
         sXEvt = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         H000L2_A1EmpleadoId = new short[1] ;
         H000L2_A14parqueAtraccionNombre = new string[] {""} ;
         H000L2_A13parqueAtraccionId = new short[1] ;
         H000L2_A12EmpleadoUso_Cad = new string[] {""} ;
         H000L2_n12EmpleadoUso_Cad = new bool[] {false} ;
         H000L2_A11EmpleadoUsu_Mod = new string[] {""} ;
         H000L2_n11EmpleadoUsu_Mod = new bool[] {false} ;
         H000L2_A10EmpleadoUsu_Alta = new string[] {""} ;
         H000L2_n10EmpleadoUsu_Alta = new bool[] {false} ;
         H000L2_A9EmpleadoFch_Cad = new DateTime[] {DateTime.MinValue} ;
         H000L2_n9EmpleadoFch_Cad = new bool[] {false} ;
         H000L2_A8EmpleadoFcha_Mod = new DateTime[] {DateTime.MinValue} ;
         H000L2_n8EmpleadoFcha_Mod = new bool[] {false} ;
         H000L2_A7EmpleadoFch_Alta = new DateTime[] {DateTime.MinValue} ;
         H000L2_n7EmpleadoFch_Alta = new bool[] {false} ;
         H000L2_A6EmpleadoEmail = new string[] {""} ;
         H000L2_n6EmpleadoEmail = new bool[] {false} ;
         H000L2_A5EmpleadoTelefono = new string[] {""} ;
         H000L2_n5EmpleadoTelefono = new bool[] {false} ;
         H000L2_A4EmpleadoDireccion = new string[] {""} ;
         H000L2_n4EmpleadoDireccion = new bool[] {false} ;
         H000L2_A3EmpleadoApellido = new string[] {""} ;
         H000L2_A2EmpleadoNombre = new string[] {""} ;
         hsh = "";
         AV7TrnContext = new GeneXus.Programs.general.ui.SdtTransactionContext(context);
         AV10HTTPRequest = new GxHttpRequest( context);
         AV8TrnContextAtt = new GeneXus.Programs.general.ui.SdtTransactionContext_Attribute(context);
         AV6EmpleadoId = 1;
         AV9Session = context.GetSession();
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         sCtrlA1EmpleadoId = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.empleadogeneral__default(),
            new Object[][] {
                new Object[] {
               H000L2_A1EmpleadoId, H000L2_A14parqueAtraccionNombre, H000L2_A13parqueAtraccionId, H000L2_A12EmpleadoUso_Cad, H000L2_n12EmpleadoUso_Cad, H000L2_A11EmpleadoUsu_Mod, H000L2_n11EmpleadoUsu_Mod, H000L2_A10EmpleadoUsu_Alta, H000L2_n10EmpleadoUsu_Alta, H000L2_A9EmpleadoFch_Cad,
               H000L2_n9EmpleadoFch_Cad, H000L2_A8EmpleadoFcha_Mod, H000L2_n8EmpleadoFcha_Mod, H000L2_A7EmpleadoFch_Alta, H000L2_n7EmpleadoFch_Alta, H000L2_A6EmpleadoEmail, H000L2_n6EmpleadoEmail, H000L2_A5EmpleadoTelefono, H000L2_n5EmpleadoTelefono, H000L2_A4EmpleadoDireccion,
               H000L2_n4EmpleadoDireccion, H000L2_A3EmpleadoApellido, H000L2_A2EmpleadoNombre
               }
            }
         );
         AV11Pgmname = "EmpleadoGeneral";
         /* GeneXus formulas. */
         AV11Pgmname = "EmpleadoGeneral";
      }

      private short A1EmpleadoId ;
      private short wcpOA1EmpleadoId ;
      private short nGotPars ;
      private short GxWebError ;
      private short nDynComponent ;
      private short A13parqueAtraccionId ;
      private short wbEnd ;
      private short wbStart ;
      private short nDraw ;
      private short nDoneStart ;
      private short nDonePA ;
      private short gxcookieaux ;
      private short AV6EmpleadoId ;
      private short nGXWrapped ;
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
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string sPrefix ;
      private string sCompPrefix ;
      private string sSFPrefix ;
      private string AV11Pgmname ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string GXKey ;
      private string GX_FocusControl ;
      private string divMaintable_Internalname ;
      private string TempTags ;
      private string ClassString ;
      private string StyleString ;
      private string bttBtnupdate_Internalname ;
      private string bttBtnupdate_Jsonclick ;
      private string bttBtndelete_Internalname ;
      private string bttBtndelete_Jsonclick ;
      private string divAttributestable_Internalname ;
      private string edtEmpleadoId_Internalname ;
      private string edtEmpleadoId_Jsonclick ;
      private string edtEmpleadoNombre_Internalname ;
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
      private string edtparqueAtraccionNombre_Internalname ;
      private string edtparqueAtraccionNombre_Link ;
      private string edtparqueAtraccionNombre_Jsonclick ;
      private string sXEvt ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string hsh ;
      private string sCtrlA1EmpleadoId ;
      private DateTime A7EmpleadoFch_Alta ;
      private DateTime A8EmpleadoFcha_Mod ;
      private DateTime A9EmpleadoFch_Cad ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool wbLoad ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool gxdyncontrolsrefreshing ;
      private bool n12EmpleadoUso_Cad ;
      private bool n11EmpleadoUsu_Mod ;
      private bool n10EmpleadoUsu_Alta ;
      private bool n9EmpleadoFch_Cad ;
      private bool n8EmpleadoFcha_Mod ;
      private bool n7EmpleadoFch_Alta ;
      private bool n6EmpleadoEmail ;
      private bool n5EmpleadoTelefono ;
      private bool n4EmpleadoDireccion ;
      private bool returnInSub ;
      private string A2EmpleadoNombre ;
      private string A3EmpleadoApellido ;
      private string A4EmpleadoDireccion ;
      private string A6EmpleadoEmail ;
      private string A10EmpleadoUsu_Alta ;
      private string A11EmpleadoUsu_Mod ;
      private string A12EmpleadoUso_Cad ;
      private string A14parqueAtraccionNombre ;
      private GXProperties forbiddenHiddens ;
      private GXWebForm Form ;
      private GxHttpRequest AV10HTTPRequest ;
      private IGxSession AV9Session ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private short[] H000L2_A1EmpleadoId ;
      private string[] H000L2_A14parqueAtraccionNombre ;
      private short[] H000L2_A13parqueAtraccionId ;
      private string[] H000L2_A12EmpleadoUso_Cad ;
      private bool[] H000L2_n12EmpleadoUso_Cad ;
      private string[] H000L2_A11EmpleadoUsu_Mod ;
      private bool[] H000L2_n11EmpleadoUsu_Mod ;
      private string[] H000L2_A10EmpleadoUsu_Alta ;
      private bool[] H000L2_n10EmpleadoUsu_Alta ;
      private DateTime[] H000L2_A9EmpleadoFch_Cad ;
      private bool[] H000L2_n9EmpleadoFch_Cad ;
      private DateTime[] H000L2_A8EmpleadoFcha_Mod ;
      private bool[] H000L2_n8EmpleadoFcha_Mod ;
      private DateTime[] H000L2_A7EmpleadoFch_Alta ;
      private bool[] H000L2_n7EmpleadoFch_Alta ;
      private string[] H000L2_A6EmpleadoEmail ;
      private bool[] H000L2_n6EmpleadoEmail ;
      private string[] H000L2_A5EmpleadoTelefono ;
      private bool[] H000L2_n5EmpleadoTelefono ;
      private string[] H000L2_A4EmpleadoDireccion ;
      private bool[] H000L2_n4EmpleadoDireccion ;
      private string[] H000L2_A3EmpleadoApellido ;
      private string[] H000L2_A2EmpleadoNombre ;
      private GeneXus.Programs.general.ui.SdtTransactionContext AV7TrnContext ;
      private GeneXus.Programs.general.ui.SdtTransactionContext_Attribute AV8TrnContextAtt ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
   }

   public class empleadogeneral__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmH000L2;
          prmH000L2 = new Object[] {
          new ParDef("@EmpleadoId",GXType.Int16,4,0)
          };
          def= new CursorDef[] {
              new CursorDef("H000L2", "SELECT T1.[EmpleadoId], T2.[parqueAtraccionNombre], T1.[parqueAtraccionId], T1.[EmpleadoUso_Cad], T1.[EmpleadoUsu_Mod], T1.[EmpleadoUsu_Alta], T1.[EmpleadoFch_Cad], T1.[EmpleadoFcha_Mod], T1.[EmpleadoFch_Alta], T1.[EmpleadoEmail], T1.[EmpleadoTelefono], T1.[EmpleadoDireccion], T1.[EmpleadoApellido], T1.[EmpleadoNombre] FROM ([Empleado] T1 INNER JOIN [parqueAtraccion] T2 ON T2.[parqueAtraccionId] = T1.[parqueAtraccionId]) WHERE T1.[EmpleadoId] = @EmpleadoId ORDER BY T1.[EmpleadoId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH000L2,1, GxCacheFrequency.OFF ,true,true )
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
                ((short[]) buf[2])[0] = rslt.getShort(3);
                ((string[]) buf[3])[0] = rslt.getVarchar(4);
                ((bool[]) buf[4])[0] = rslt.wasNull(4);
                ((string[]) buf[5])[0] = rslt.getVarchar(5);
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
                ((string[]) buf[17])[0] = rslt.getString(11, 20);
                ((bool[]) buf[18])[0] = rslt.wasNull(11);
                ((string[]) buf[19])[0] = rslt.getVarchar(12);
                ((bool[]) buf[20])[0] = rslt.wasNull(12);
                ((string[]) buf[21])[0] = rslt.getVarchar(13);
                ((string[]) buf[22])[0] = rslt.getVarchar(14);
                return;
       }
    }

 }

}
