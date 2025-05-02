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
   public class carritogeneral : GXWebComponent
   {
      public carritogeneral( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         if ( StringUtil.Len( (string)(sPrefix)) == 0 )
         {
            context.SetDefaultTheme("miTienda", true);
         }
      }

      public carritogeneral( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( int aP0_CarritoID )
      {
         this.A33CarritoID = aP0_CarritoID;
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
               gxfirstwebparm = GetFirstPar( "CarritoID");
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
                  A33CarritoID = (int)(Math.Round(NumberUtil.Val( GetPar( "CarritoID"), "."), 18, MidpointRounding.ToEven));
                  AssignAttri(sPrefix, false, "A33CarritoID", StringUtil.LTrimStr( (decimal)(A33CarritoID), 6, 0));
                  setjustcreated();
                  componentprepare(new Object[] {(string)sCompPrefix,(string)sSFPrefix,(int)A33CarritoID});
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
                  gxfirstwebparm = GetFirstPar( "CarritoID");
               }
               else if ( StringUtil.StrCmp(gxfirstwebparm, "gxfullajaxEvt") == 0 )
               {
                  if ( ! IsValidAjaxCall( true) )
                  {
                     GxWebError = 1;
                     return  ;
                  }
                  gxfirstwebparm = GetFirstPar( "CarritoID");
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
            PA192( ) ;
            if ( ( GxWebError == 0 ) && ! isAjaxCallMode( ) )
            {
               /* GeneXus formulas. */
               AV11Pgmname = "CarritoGeneral";
               /* Using cursor H00193 */
               pr_default.execute(0, new Object[] {A33CarritoID});
               if ( (pr_default.getStatus(0) != 101) )
               {
                  A36CarritoCostoTotalCompra = H00193_A36CarritoCostoTotalCompra[0];
                  n36CarritoCostoTotalCompra = H00193_n36CarritoCostoTotalCompra[0];
                  AssignAttri(sPrefix, false, "A36CarritoCostoTotalCompra", StringUtil.LTrimStr( A36CarritoCostoTotalCompra, 10, 2));
               }
               else
               {
                  A36CarritoCostoTotalCompra = 0;
                  n36CarritoCostoTotalCompra = false;
                  AssignAttri(sPrefix, false, "A36CarritoCostoTotalCompra", StringUtil.LTrimStr( A36CarritoCostoTotalCompra, 10, 2));
               }
               pr_default.close(0);
               WS192( ) ;
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
            context.SendWebValue( "Carrito General") ;
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
         context.AddJavascriptSource("calendar-en.js", "?"+context.GetBuildNumber( 239440), false, true);
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
            context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("carritogeneral.aspx", new object[] {UrlEncode(StringUtil.LTrimStr(A33CarritoID,6,0))}, new string[] {"CarritoID"}) +"\">") ;
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
         forbiddenHiddens.Add("hshsalt", sPrefix+"hsh"+"CarritoGeneral");
         forbiddenHiddens.Add("ClienteID", context.localUtil.Format( (decimal)(A9ClienteID), "ZZZZZ9"));
         GxWebStd.gx_hidden_field( context, sPrefix+"hsh", GetEncryptedHash( forbiddenHiddens.ToString(), GXKey));
         GXUtil.WriteLogInfo("carritogeneral:[ SendSecurityCheck value for]"+forbiddenHiddens.ToJSonString());
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, sPrefix+"wcpOA33CarritoID", StringUtil.LTrim( StringUtil.NToC( (decimal)(wcpOA33CarritoID), 6, 0, ".", "")));
      }

      protected void RenderHtmlCloseForm192( )
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
         return "CarritoGeneral" ;
      }

      public override string GetPgmdesc( )
      {
         return "Carrito General" ;
      }

      protected void WB190( )
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
               GxWebStd.gx_hidden_field( context, sPrefix+"_CMPPGM", "carritogeneral.aspx");
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
            GxWebStd.gx_button_ctrl( context, bttBtnupdate_Internalname, "", "Update", bttBtnupdate_Jsonclick, 7, "Update", "", StyleString, ClassString, 1, 1, "standard", "'"+sPrefix+"'"+",false,"+"'"+"e11191_client"+"'", TempTags, "", 2, "HLP_CarritoGeneral.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 10,'" + sPrefix + "',false,'',0)\"";
            ClassString = "Button button-tertiary";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtndelete_Internalname, "", "Delete", bttBtndelete_Jsonclick, 7, "Delete", "", StyleString, ClassString, 1, 1, "standard", "'"+sPrefix+"'"+",false,"+"'"+"e12191_client"+"'", TempTags, "", 2, "HLP_CarritoGeneral.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 12,'" + sPrefix + "',false,'',0)\"";
            ClassString = "Button button-tertiary";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtnreportepdf_Internalname, "", "Reporte", bttBtnreportepdf_Jsonclick, 5, "Reporte", "", StyleString, ClassString, 1, 1, "standard", "'"+sPrefix+"'"+",false,"+"'"+sPrefix+"E\\'DOREPORTEPDF\\'."+"'", TempTags, "", context.GetButtonType( ), "HLP_CarritoGeneral.htm");
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
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtCarritoFchCompra_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtCarritoFchCompra_Internalname, "Fch Compra", "col-sm-3 ReadonlyAttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 20,'" + sPrefix + "',false,'',0)\"";
            context.WriteHtmlText( "<div id=\""+edtCarritoFchCompra_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
            GxWebStd.gx_single_line_edit( context, edtCarritoFchCompra_Internalname, context.localUtil.Format(A34CarritoFchCompra, "99/99/9999"), context.localUtil.Format( A34CarritoFchCompra, "99/99/9999"), TempTags+" onchange=\""+"gx.date.valid_date(this, 10,'MDY',0,12,'eng',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 10,'MDY',0,12,'eng',false,0);"+";gx.evt.onblur(this,20);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCarritoFchCompra_Jsonclick, 0, "ReadonlyAttribute", "", "", "", "", 1, edtCarritoFchCompra_Enabled, 0, "text", "", 10, "chr", 1, "row", 10, 0, 0, 0, 0, -1, 0, true, "Fecha", "end", false, "", "HLP_CarritoGeneral.htm");
            GxWebStd.gx_bitmap( context, edtCarritoFchCompra_Internalname+"_dp_trigger", context.GetImagePath( "", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtCarritoFchCompra_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_CarritoGeneral.htm");
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
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtCarritoFchEntrega_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtCarritoFchEntrega_Internalname, "Fch Entrega", "col-sm-3 ReadonlyAttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 25,'" + sPrefix + "',false,'',0)\"";
            context.WriteHtmlText( "<div id=\""+edtCarritoFchEntrega_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
            GxWebStd.gx_single_line_edit( context, edtCarritoFchEntrega_Internalname, context.localUtil.Format(A35CarritoFchEntrega, "99/99/9999"), context.localUtil.Format( A35CarritoFchEntrega, "99/99/9999"), TempTags+" onchange=\""+"gx.date.valid_date(this, 10,'MDY',0,12,'eng',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 10,'MDY',0,12,'eng',false,0);"+";gx.evt.onblur(this,25);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCarritoFchEntrega_Jsonclick, 0, "ReadonlyAttribute", "", "", "", "", 1, edtCarritoFchEntrega_Enabled, 0, "text", "", 10, "chr", 1, "row", 10, 0, 0, 0, 0, -1, 0, true, "Fecha", "end", false, "", "HLP_CarritoGeneral.htm");
            GxWebStd.gx_bitmap( context, edtCarritoFchEntrega_Internalname+"_dp_trigger", context.GetImagePath( "", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtCarritoFchEntrega_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_CarritoGeneral.htm");
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
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtClienteID_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtClienteID_Internalname, "Cliente ID", "col-sm-3 ReadonlyAttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 30,'" + sPrefix + "',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtClienteID_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A9ClienteID), 6, 0, ".", "")), StringUtil.LTrim( ((edtClienteID_Enabled!=0) ? context.localUtil.Format( (decimal)(A9ClienteID), "ZZZZZ9") : context.localUtil.Format( (decimal)(A9ClienteID), "ZZZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,30);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtClienteID_Jsonclick, 0, "ReadonlyAttribute", "", "", "", "", 1, edtClienteID_Enabled, 0, "text", "1", 6, "chr", 1, "row", 6, 0, 0, 0, 0, -1, 0, true, "ID", "end", false, "", "HLP_CarritoGeneral.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtClienteNombre_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtClienteNombre_Internalname, "Cliente Nombre", "col-sm-3 ReadonlyAttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 35,'" + sPrefix + "',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtClienteNombre_Internalname, A10ClienteNombre, StringUtil.RTrim( context.localUtil.Format( A10ClienteNombre, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,35);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", edtClienteNombre_Link, "", "", "", edtClienteNombre_Jsonclick, 0, "ReadonlyAttribute", "", "", "", "", 1, edtClienteNombre_Enabled, 0, "text", "", 80, "chr", 1, "row", 80, 0, 0, 0, 0, -1, -1, true, "Descripcion", "start", true, "", "HLP_CarritoGeneral.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtCarritoCostoTotalCompra_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtCarritoCostoTotalCompra_Internalname, "Total Compra", "col-sm-3 ReadonlyAttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 40,'" + sPrefix + "',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtCarritoCostoTotalCompra_Internalname, StringUtil.LTrim( StringUtil.NToC( A36CarritoCostoTotalCompra, 10, 2, ".", "")), StringUtil.LTrim( ((edtCarritoCostoTotalCompra_Enabled!=0) ? context.localUtil.Format( A36CarritoCostoTotalCompra, "ZZZZZZ9.99") : context.localUtil.Format( A36CarritoCostoTotalCompra, "ZZZZZZ9.99"))), TempTags+" onchange=\""+"gx.num.valid_decimal( this, ',','.','2');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, ',','.','2');"+";gx.evt.onblur(this,40);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCarritoCostoTotalCompra_Jsonclick, 0, "ReadonlyAttribute", "", "", "", "", 1, edtCarritoCostoTotalCompra_Enabled, 0, "text", "", 10, "chr", 1, "row", 10, 0, 0, 0, 0, -1, 0, true, "Importe", "end", false, "", "HLP_CarritoGeneral.htm");
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
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtCarritoID_Internalname, "Carrito ID", "col-sm-3 AttributeLabel", 0, true, "");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 44,'" + sPrefix + "',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtCarritoID_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A33CarritoID), 6, 0, ".", "")), StringUtil.LTrim( ((edtCarritoID_Enabled!=0) ? context.localUtil.Format( (decimal)(A33CarritoID), "ZZZZZ9") : context.localUtil.Format( (decimal)(A33CarritoID), "ZZZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,44);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCarritoID_Jsonclick, 0, "Attribute", "", "", "", "", edtCarritoID_Visible, edtCarritoID_Enabled, 0, "text", "1", 6, "chr", 1, "row", 6, 0, 0, 0, 0, -1, 0, true, "ID", "end", false, "", "HLP_CarritoGeneral.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
         }
         wbLoad = true;
      }

      protected void START192( )
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
            Form.Meta.addItem("description", "Carrito General", 0) ;
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
               STRUP190( ) ;
            }
         }
      }

      protected void WS192( )
      {
         START192( ) ;
         EVT192( ) ;
      }

      protected void EVT192( )
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
                                 STRUP190( ) ;
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
                                 STRUP190( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: Start */
                                    E13192 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "LOAD") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP190( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: Load */
                                    E14192 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'DOREPORTEPDF'") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP190( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: 'DoReportePDF' */
                                    E15192 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "ENTER") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP190( ) ;
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
                                 STRUP190( ) ;
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

      protected void WE192( )
      {
         if ( ! GxWebStd.gx_redirect( context) )
         {
            Rfr0gs = true;
            Refresh( ) ;
            if ( ! GxWebStd.gx_redirect( context) )
            {
               RenderHtmlCloseForm192( ) ;
            }
         }
      }

      protected void PA192( )
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
         RF192( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
         AV11Pgmname = "CarritoGeneral";
      }

      protected void RF192( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = true;
         fix_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = false;
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            /* Using cursor H00195 */
            pr_default.execute(1, new Object[] {A33CarritoID});
            while ( (pr_default.getStatus(1) != 101) )
            {
               A10ClienteNombre = H00195_A10ClienteNombre[0];
               AssignAttri(sPrefix, false, "A10ClienteNombre", A10ClienteNombre);
               A9ClienteID = H00195_A9ClienteID[0];
               AssignAttri(sPrefix, false, "A9ClienteID", StringUtil.LTrimStr( (decimal)(A9ClienteID), 6, 0));
               A36CarritoCostoTotalCompra = H00195_A36CarritoCostoTotalCompra[0];
               n36CarritoCostoTotalCompra = H00195_n36CarritoCostoTotalCompra[0];
               AssignAttri(sPrefix, false, "A36CarritoCostoTotalCompra", StringUtil.LTrimStr( A36CarritoCostoTotalCompra, 10, 2));
               A34CarritoFchCompra = H00195_A34CarritoFchCompra[0];
               AssignAttri(sPrefix, false, "A34CarritoFchCompra", context.localUtil.Format(A34CarritoFchCompra, "99/99/9999"));
               A10ClienteNombre = H00195_A10ClienteNombre[0];
               AssignAttri(sPrefix, false, "A10ClienteNombre", A10ClienteNombre);
               A36CarritoCostoTotalCompra = H00195_A36CarritoCostoTotalCompra[0];
               n36CarritoCostoTotalCompra = H00195_n36CarritoCostoTotalCompra[0];
               AssignAttri(sPrefix, false, "A36CarritoCostoTotalCompra", StringUtil.LTrimStr( A36CarritoCostoTotalCompra, 10, 2));
               A35CarritoFchEntrega = DateTimeUtil.DAdd( A34CarritoFchCompra, (5));
               AssignAttri(sPrefix, false, "A35CarritoFchEntrega", context.localUtil.Format(A35CarritoFchEntrega, "99/99/9999"));
               /* Execute user event: Load */
               E14192 ();
               /* Exiting from a For First loop. */
               if (true) break;
            }
            pr_default.close(1);
            WB190( ) ;
         }
      }

      protected void send_integrity_lvl_hashes192( )
      {
      }

      protected void before_start_formulas( )
      {
         AV11Pgmname = "CarritoGeneral";
         /* Using cursor H00197 */
         pr_default.execute(2, new Object[] {A33CarritoID});
         if ( (pr_default.getStatus(2) != 101) )
         {
            A36CarritoCostoTotalCompra = H00197_A36CarritoCostoTotalCompra[0];
            n36CarritoCostoTotalCompra = H00197_n36CarritoCostoTotalCompra[0];
            AssignAttri(sPrefix, false, "A36CarritoCostoTotalCompra", StringUtil.LTrimStr( A36CarritoCostoTotalCompra, 10, 2));
         }
         else
         {
            A36CarritoCostoTotalCompra = 0;
            n36CarritoCostoTotalCompra = false;
            AssignAttri(sPrefix, false, "A36CarritoCostoTotalCompra", StringUtil.LTrimStr( A36CarritoCostoTotalCompra, 10, 2));
         }
         pr_default.close(2);
         edtCarritoFchCompra_Enabled = 0;
         AssignProp(sPrefix, false, edtCarritoFchCompra_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCarritoFchCompra_Enabled), 5, 0), true);
         edtCarritoFchEntrega_Enabled = 0;
         AssignProp(sPrefix, false, edtCarritoFchEntrega_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCarritoFchEntrega_Enabled), 5, 0), true);
         edtClienteID_Enabled = 0;
         AssignProp(sPrefix, false, edtClienteID_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtClienteID_Enabled), 5, 0), true);
         edtClienteNombre_Enabled = 0;
         AssignProp(sPrefix, false, edtClienteNombre_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtClienteNombre_Enabled), 5, 0), true);
         edtCarritoCostoTotalCompra_Enabled = 0;
         AssignProp(sPrefix, false, edtCarritoCostoTotalCompra_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCarritoCostoTotalCompra_Enabled), 5, 0), true);
         edtCarritoID_Enabled = 0;
         AssignProp(sPrefix, false, edtCarritoID_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCarritoID_Enabled), 5, 0), true);
         fix_multi_value_controls( ) ;
      }

      protected void STRUP190( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E13192 ();
         context.wbGlbDoneStart = 1;
         nDoneStart = 1;
         /* After Start, stand alone formulas. */
         sXEvt = cgiGet( "_EventName");
         if ( ! GetJustCreated( ) && ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 ) )
         {
            /* Read saved SDTs. */
            /* Read saved values. */
            wcpOA33CarritoID = (int)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"wcpOA33CarritoID"), ".", ","), 18, MidpointRounding.ToEven));
            /* Read variables values. */
            A34CarritoFchCompra = context.localUtil.CToD( cgiGet( edtCarritoFchCompra_Internalname), 1);
            AssignAttri(sPrefix, false, "A34CarritoFchCompra", context.localUtil.Format(A34CarritoFchCompra, "99/99/9999"));
            A35CarritoFchEntrega = context.localUtil.CToD( cgiGet( edtCarritoFchEntrega_Internalname), 1);
            AssignAttri(sPrefix, false, "A35CarritoFchEntrega", context.localUtil.Format(A35CarritoFchEntrega, "99/99/9999"));
            A9ClienteID = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtClienteID_Internalname), ".", ","), 18, MidpointRounding.ToEven));
            AssignAttri(sPrefix, false, "A9ClienteID", StringUtil.LTrimStr( (decimal)(A9ClienteID), 6, 0));
            A10ClienteNombre = cgiGet( edtClienteNombre_Internalname);
            AssignAttri(sPrefix, false, "A10ClienteNombre", A10ClienteNombre);
            A36CarritoCostoTotalCompra = context.localUtil.CToN( cgiGet( edtCarritoCostoTotalCompra_Internalname), ".", ",");
            n36CarritoCostoTotalCompra = false;
            AssignAttri(sPrefix, false, "A36CarritoCostoTotalCompra", StringUtil.LTrimStr( A36CarritoCostoTotalCompra, 10, 2));
            /* Read subfile selected row values. */
            /* Read hidden variables. */
            GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
            forbiddenHiddens = new GXProperties();
            forbiddenHiddens.Add("hshsalt", sPrefix+"hsh"+"CarritoGeneral");
            A9ClienteID = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtClienteID_Internalname), ".", ","), 18, MidpointRounding.ToEven));
            AssignAttri(sPrefix, false, "A9ClienteID", StringUtil.LTrimStr( (decimal)(A9ClienteID), 6, 0));
            forbiddenHiddens.Add("ClienteID", context.localUtil.Format( (decimal)(A9ClienteID), "ZZZZZ9"));
            hsh = cgiGet( sPrefix+"hsh");
            if ( ! GXUtil.CheckEncryptedHash( forbiddenHiddens.ToString(), hsh, GXKey) )
            {
               GXUtil.WriteLogError("carritogeneral:[ SecurityCheckFailed (403 Forbidden) value for]"+forbiddenHiddens.ToJSonString());
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
         E13192 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
      }

      protected void E13192( )
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

      protected void E14192( )
      {
         /* Load Routine */
         returnInSub = false;
         edtClienteNombre_Link = formatLink("viewcliente.aspx", new object[] {UrlEncode(StringUtil.LTrimStr(A9ClienteID,6,0)),UrlEncode(StringUtil.RTrim(""))}, new string[] {"ClienteID","TabCode"}) ;
         AssignProp(sPrefix, false, edtClienteNombre_Internalname, "Link", edtClienteNombre_Link, true);
         edtCarritoID_Visible = 0;
         AssignProp(sPrefix, false, edtCarritoID_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtCarritoID_Visible), 5, 0), true);
      }

      protected void E15192( )
      {
         /* 'DoReportePDF' Routine */
         returnInSub = false;
         CallWebObject(formatLink("adetallecompra.aspx", new object[] {UrlEncode(StringUtil.LTrimStr(A33CarritoID,6,0))}, new string[] {"carritoID"}) );
         context.wjLocDisableFrm = 2;
      }

      protected void S112( )
      {
         /* 'PREPARETRANSACTION' Routine */
         returnInSub = false;
         AV7TrnContext = new GeneXus.Programs.general.ui.SdtTransactionContext(context);
         AV7TrnContext.gxTpr_Callerobject = AV11Pgmname;
         AV7TrnContext.gxTpr_Callerondelete = false;
         AV7TrnContext.gxTpr_Callerurl = AV10HTTPRequest.ScriptName+"?"+AV10HTTPRequest.QueryString;
         AV7TrnContext.gxTpr_Transactionname = "Carrito";
         AV8TrnContextAtt = new GeneXus.Programs.general.ui.SdtTransactionContext_Attribute(context);
         AV8TrnContextAtt.gxTpr_Attributename = "CarritoID";
         AV8TrnContextAtt.gxTpr_Attributevalue = StringUtil.Str( (decimal)(AV6CarritoID), 6, 0);
         AV7TrnContext.gxTpr_Attributes.Add(AV8TrnContextAtt, 0);
         AV9Session.Set("TrnContext", AV7TrnContext.ToXml(false, true, "", ""));
      }

      public override void setparameters( Object[] obj )
      {
         createObjects();
         initialize();
         A33CarritoID = Convert.ToInt32(getParm(obj,0));
         AssignAttri(sPrefix, false, "A33CarritoID", StringUtil.LTrimStr( (decimal)(A33CarritoID), 6, 0));
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
         PA192( ) ;
         WS192( ) ;
         WE192( ) ;
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
         sCtrlA33CarritoID = (string)((string)getParm(obj,0));
      }

      public override void componentrestorestate( string sPPrefix ,
                                                  string sPSFPrefix )
      {
         sPrefix = sPPrefix + sPSFPrefix;
         PA192( ) ;
         WCParametersGet( ) ;
      }

      public override void componentprepare( Object[] obj )
      {
         wbLoad = false;
         sCompPrefix = (string)getParm(obj,0);
         sSFPrefix = (string)getParm(obj,1);
         sPrefix = sCompPrefix + sSFPrefix;
         AddComponentObject(sPrefix, "carritogeneral", GetJustCreated( ));
         if ( ( nDoneStart == 0 ) && ( nDynComponent == 0 ) )
         {
            INITWEB( ) ;
         }
         else
         {
            init_default_properties( ) ;
            init_web_controls( ) ;
         }
         PA192( ) ;
         if ( ! GetJustCreated( ) && ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 ) && ( context.wbGlbDoneStart == 0 ) )
         {
            WCParametersGet( ) ;
         }
         else
         {
            A33CarritoID = Convert.ToInt32(getParm(obj,2));
            AssignAttri(sPrefix, false, "A33CarritoID", StringUtil.LTrimStr( (decimal)(A33CarritoID), 6, 0));
         }
         wcpOA33CarritoID = (int)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"wcpOA33CarritoID"), ".", ","), 18, MidpointRounding.ToEven));
         if ( ! GetJustCreated( ) && ( ( A33CarritoID != wcpOA33CarritoID ) ) )
         {
            setjustcreated();
         }
         wcpOA33CarritoID = A33CarritoID;
      }

      protected void WCParametersGet( )
      {
         /* Read Component Parameters. */
         sCtrlA33CarritoID = cgiGet( sPrefix+"A33CarritoID_CTRL");
         if ( StringUtil.Len( sCtrlA33CarritoID) > 0 )
         {
            A33CarritoID = (int)(Math.Round(context.localUtil.CToN( cgiGet( sCtrlA33CarritoID), ".", ","), 18, MidpointRounding.ToEven));
            AssignAttri(sPrefix, false, "A33CarritoID", StringUtil.LTrimStr( (decimal)(A33CarritoID), 6, 0));
         }
         else
         {
            A33CarritoID = (int)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"A33CarritoID_PARM"), ".", ","), 18, MidpointRounding.ToEven));
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
         PA192( ) ;
         sEvt = sCompEvt;
         WCParametersGet( ) ;
         WS192( ) ;
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
         WS192( ) ;
         SaveComponentMsgList(sPrefix);
         context.GX_msglist = BackMsgLst;
      }

      protected void WCParametersSet( )
      {
         GxWebStd.gx_hidden_field( context, sPrefix+"A33CarritoID_PARM", StringUtil.LTrim( StringUtil.NToC( (decimal)(A33CarritoID), 6, 0, ".", "")));
         if ( StringUtil.Len( StringUtil.RTrim( sCtrlA33CarritoID)) > 0 )
         {
            GxWebStd.gx_hidden_field( context, sPrefix+"A33CarritoID_CTRL", StringUtil.RTrim( sCtrlA33CarritoID));
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
         WE192( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?202552012432", true, true);
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
         context.AddJavascriptSource("carritogeneral.js", "?202552012432", false, true);
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
         bttBtnreportepdf_Internalname = sPrefix+"BTNREPORTEPDF";
         edtCarritoFchCompra_Internalname = sPrefix+"CARRITOFCHCOMPRA";
         edtCarritoFchEntrega_Internalname = sPrefix+"CARRITOFCHENTREGA";
         edtClienteID_Internalname = sPrefix+"CLIENTEID";
         edtClienteNombre_Internalname = sPrefix+"CLIENTENOMBRE";
         edtCarritoCostoTotalCompra_Internalname = sPrefix+"CARRITOCOSTOTOTALCOMPRA";
         divAttributestable_Internalname = sPrefix+"ATTRIBUTESTABLE";
         edtCarritoID_Internalname = sPrefix+"CARRITOID";
         divMaintable_Internalname = sPrefix+"MAINTABLE";
         Form.Internalname = sPrefix+"FORM";
      }

      public override void initialize_properties( )
      {
         if ( StringUtil.Len( sPrefix) == 0 )
         {
            context.SetDefaultTheme("miTienda", true);
         }
         if ( StringUtil.Len( sPrefix) == 0 )
         {
            if ( context.isSpaRequest( ) )
            {
               disableJsOutput();
            }
         }
         init_default_properties( ) ;
         edtCarritoID_Jsonclick = "";
         edtCarritoID_Enabled = 0;
         edtCarritoID_Visible = 1;
         edtCarritoCostoTotalCompra_Jsonclick = "";
         edtCarritoCostoTotalCompra_Enabled = 0;
         edtClienteNombre_Jsonclick = "";
         edtClienteNombre_Link = "";
         edtClienteNombre_Enabled = 0;
         edtClienteID_Jsonclick = "";
         edtClienteID_Enabled = 0;
         edtCarritoFchEntrega_Jsonclick = "";
         edtCarritoFchEntrega_Enabled = 0;
         edtCarritoFchCompra_Jsonclick = "";
         edtCarritoFchCompra_Enabled = 0;
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
         setEventMetadata("REFRESH","""{"handler":"Refresh","iparms":[{"av":"A33CarritoID","fld":"CARRITOID","pic":"ZZZZZ9"},{"av":"A9ClienteID","fld":"CLIENTEID","pic":"ZZZZZ9"}]}""");
         setEventMetadata("'DOUPDATE'","""{"handler":"E11191","iparms":[{"av":"A33CarritoID","fld":"CARRITOID","pic":"ZZZZZ9"}]}""");
         setEventMetadata("'DODELETE'","""{"handler":"E12191","iparms":[{"av":"A33CarritoID","fld":"CARRITOID","pic":"ZZZZZ9"}]}""");
         setEventMetadata("'DOREPORTEPDF'","""{"handler":"E15192","iparms":[{"av":"A33CarritoID","fld":"CARRITOID","pic":"ZZZZZ9"}]}""");
         setEventMetadata("VALID_CARRITOFCHCOMPRA","""{"handler":"Valid_Carritofchcompra","iparms":[]}""");
         setEventMetadata("VALID_CLIENTEID","""{"handler":"Valid_Clienteid","iparms":[]}""");
         setEventMetadata("VALID_CARRITOID","""{"handler":"Valid_Carritoid","iparms":[]}""");
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
         H00193_A36CarritoCostoTotalCompra = new decimal[1] ;
         H00193_n36CarritoCostoTotalCompra = new bool[] {false} ;
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
         bttBtnreportepdf_Jsonclick = "";
         A34CarritoFchCompra = DateTime.MinValue;
         A35CarritoFchEntrega = DateTime.MinValue;
         A10ClienteNombre = "";
         Form = new GXWebForm();
         sXEvt = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         H00195_A33CarritoID = new int[1] ;
         H00195_A10ClienteNombre = new string[] {""} ;
         H00195_A9ClienteID = new int[1] ;
         H00195_A36CarritoCostoTotalCompra = new decimal[1] ;
         H00195_n36CarritoCostoTotalCompra = new bool[] {false} ;
         H00195_A34CarritoFchCompra = new DateTime[] {DateTime.MinValue} ;
         H00197_A36CarritoCostoTotalCompra = new decimal[1] ;
         H00197_n36CarritoCostoTotalCompra = new bool[] {false} ;
         hsh = "";
         AV7TrnContext = new GeneXus.Programs.general.ui.SdtTransactionContext(context);
         AV10HTTPRequest = new GxHttpRequest( context);
         AV8TrnContextAtt = new GeneXus.Programs.general.ui.SdtTransactionContext_Attribute(context);
         AV6CarritoID = 1;
         AV9Session = context.GetSession();
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         sCtrlA33CarritoID = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.carritogeneral__default(),
            new Object[][] {
                new Object[] {
               H00193_A36CarritoCostoTotalCompra, H00193_n36CarritoCostoTotalCompra
               }
               , new Object[] {
               H00195_A33CarritoID, H00195_A10ClienteNombre, H00195_A9ClienteID, H00195_A36CarritoCostoTotalCompra, H00195_n36CarritoCostoTotalCompra, H00195_A34CarritoFchCompra
               }
               , new Object[] {
               H00197_A36CarritoCostoTotalCompra, H00197_n36CarritoCostoTotalCompra
               }
            }
         );
         AV11Pgmname = "CarritoGeneral";
         /* GeneXus formulas. */
         AV11Pgmname = "CarritoGeneral";
      }

      private short nGotPars ;
      private short GxWebError ;
      private short nDynComponent ;
      private short wbEnd ;
      private short wbStart ;
      private short nDraw ;
      private short nDoneStart ;
      private short nDonePA ;
      private short gxcookieaux ;
      private short nGXWrapped ;
      private int A33CarritoID ;
      private int wcpOA33CarritoID ;
      private int A9ClienteID ;
      private int edtCarritoFchCompra_Enabled ;
      private int edtCarritoFchEntrega_Enabled ;
      private int edtClienteID_Enabled ;
      private int edtClienteNombre_Enabled ;
      private int edtCarritoCostoTotalCompra_Enabled ;
      private int edtCarritoID_Enabled ;
      private int edtCarritoID_Visible ;
      private int AV6CarritoID ;
      private int idxLst ;
      private decimal A36CarritoCostoTotalCompra ;
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
      private string bttBtnreportepdf_Internalname ;
      private string bttBtnreportepdf_Jsonclick ;
      private string divAttributestable_Internalname ;
      private string edtCarritoFchCompra_Internalname ;
      private string edtCarritoFchCompra_Jsonclick ;
      private string edtCarritoFchEntrega_Internalname ;
      private string edtCarritoFchEntrega_Jsonclick ;
      private string edtClienteID_Internalname ;
      private string edtClienteID_Jsonclick ;
      private string edtClienteNombre_Internalname ;
      private string edtClienteNombre_Link ;
      private string edtClienteNombre_Jsonclick ;
      private string edtCarritoCostoTotalCompra_Internalname ;
      private string edtCarritoCostoTotalCompra_Jsonclick ;
      private string edtCarritoID_Internalname ;
      private string edtCarritoID_Jsonclick ;
      private string sXEvt ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string hsh ;
      private string sCtrlA33CarritoID ;
      private DateTime A34CarritoFchCompra ;
      private DateTime A35CarritoFchEntrega ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool n36CarritoCostoTotalCompra ;
      private bool wbLoad ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool gxdyncontrolsrefreshing ;
      private bool returnInSub ;
      private string A10ClienteNombre ;
      private GXProperties forbiddenHiddens ;
      private GXWebForm Form ;
      private GxHttpRequest AV10HTTPRequest ;
      private IGxSession AV9Session ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private decimal[] H00193_A36CarritoCostoTotalCompra ;
      private bool[] H00193_n36CarritoCostoTotalCompra ;
      private int[] H00195_A33CarritoID ;
      private string[] H00195_A10ClienteNombre ;
      private int[] H00195_A9ClienteID ;
      private decimal[] H00195_A36CarritoCostoTotalCompra ;
      private bool[] H00195_n36CarritoCostoTotalCompra ;
      private DateTime[] H00195_A34CarritoFchCompra ;
      private decimal[] H00197_A36CarritoCostoTotalCompra ;
      private bool[] H00197_n36CarritoCostoTotalCompra ;
      private GeneXus.Programs.general.ui.SdtTransactionContext AV7TrnContext ;
      private GeneXus.Programs.general.ui.SdtTransactionContext_Attribute AV8TrnContextAtt ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
   }

   public class carritogeneral__default : DataStoreHelperBase, IDataStoreHelper
   {
      public ICursor[] getCursors( )
      {
         cursorDefinitions();
         return new Cursor[] {
          new ForEachCursor(def[0])
         ,new ForEachCursor(def[1])
         ,new ForEachCursor(def[2])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmH00193;
          prmH00193 = new Object[] {
          new ParDef("@CarritoID",GXType.Int32,6,0)
          };
          Object[] prmH00195;
          prmH00195 = new Object[] {
          new ParDef("@CarritoID",GXType.Int32,6,0)
          };
          Object[] prmH00197;
          prmH00197 = new Object[] {
          new ParDef("@CarritoID",GXType.Int32,6,0)
          };
          def= new CursorDef[] {
              new CursorDef("H00193", "SELECT COALESCE( T1.[CarritoCostoTotalCompra], 0) AS CarritoCostoTotalCompra FROM (SELECT SUM(T3.[ProductoPrecio] * CAST(T2.[CarritoDetalleCompraCantidadUn] AS decimal( 20, 10))) AS CarritoCostoTotalCompra, T2.[CarritoID] FROM ([CarritoDetalleCompra] T2 INNER JOIN [Producto] T3 ON T3.[ProductoID] = T2.[ProductoID]) GROUP BY T2.[CarritoID] ) T1 WHERE T1.[CarritoID] = @CarritoID ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH00193,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("H00195", "SELECT T1.[CarritoID], T2.[ClienteNombre], T1.[ClienteID], COALESCE( T3.[CarritoCostoTotalCompra], 0) AS CarritoCostoTotalCompra, T1.[CarritoFchCompra] FROM (([Carrito] T1 INNER JOIN [Cliente] T2 ON T2.[ClienteID] = T1.[ClienteID]) LEFT JOIN (SELECT SUM(T5.[ProductoPrecio] * CAST(T4.[CarritoDetalleCompraCantidadUn] AS decimal( 20, 10))) AS CarritoCostoTotalCompra, T4.[CarritoID] FROM ([CarritoDetalleCompra] T4 INNER JOIN [Producto] T5 ON T5.[ProductoID] = T4.[ProductoID]) GROUP BY T4.[CarritoID] ) T3 ON T3.[CarritoID] = T1.[CarritoID]) WHERE T1.[CarritoID] = @CarritoID ORDER BY T1.[CarritoID] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH00195,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("H00197", "SELECT COALESCE( T1.[CarritoCostoTotalCompra], 0) AS CarritoCostoTotalCompra FROM (SELECT SUM(T3.[ProductoPrecio] * CAST(T2.[CarritoDetalleCompraCantidadUn] AS decimal( 20, 10))) AS CarritoCostoTotalCompra, T2.[CarritoID] FROM ([CarritoDetalleCompra] T2 INNER JOIN [Producto] T3 ON T3.[ProductoID] = T2.[ProductoID]) GROUP BY T2.[CarritoID] ) T1 WHERE T1.[CarritoID] = @CarritoID ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH00197,1, GxCacheFrequency.OFF ,true,true )
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
                ((decimal[]) buf[0])[0] = rslt.getDecimal(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                return;
             case 1 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((int[]) buf[2])[0] = rslt.getInt(3);
                ((decimal[]) buf[3])[0] = rslt.getDecimal(4);
                ((bool[]) buf[4])[0] = rslt.wasNull(4);
                ((DateTime[]) buf[5])[0] = rslt.getGXDate(5);
                return;
             case 2 :
                ((decimal[]) buf[0])[0] = rslt.getDecimal(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                return;
       }
    }

 }

}
