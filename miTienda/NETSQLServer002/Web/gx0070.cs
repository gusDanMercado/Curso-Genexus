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
   public class gx0070 : GXDataArea
   {
      public gx0070( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("miTienda", true);
      }

      public gx0070( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( out int aP0_pProductoID )
      {
         this.AV13pProductoID = 0 ;
         ExecuteImpl();
         aP0_pProductoID=this.AV13pProductoID;
      }

      protected override void ExecutePrivate( )
      {
         isStatic = false;
         webExecute();
      }

      protected override void createObjects( )
      {
      }

      protected void INITWEB( )
      {
         initialize_properties( ) ;
         if ( nGotPars == 0 )
         {
            entryPointCalled = false;
            gxfirstwebparm = GetFirstPar( "pProductoID");
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
               gxfirstwebparm = GetFirstPar( "pProductoID");
            }
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxfullajaxEvt") == 0 )
            {
               if ( ! IsValidAjaxCall( true) )
               {
                  GxWebError = 1;
                  return  ;
               }
               gxfirstwebparm = GetFirstPar( "pProductoID");
            }
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxNewRow_"+"Grid1") == 0 )
            {
               gxnrGrid1_newrow_invoke( ) ;
               return  ;
            }
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxGridRefresh_"+"Grid1") == 0 )
            {
               gxgrGrid1_refresh_invoke( ) ;
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
               AV13pProductoID = (int)(Math.Round(NumberUtil.Val( gxfirstwebparm, "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV13pProductoID", StringUtil.LTrimStr( (decimal)(AV13pProductoID), 6, 0));
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

      protected void gxnrGrid1_newrow_invoke( )
      {
         nRC_GXsfl_84 = (int)(Math.Round(NumberUtil.Val( GetPar( "nRC_GXsfl_84"), "."), 18, MidpointRounding.ToEven));
         nGXsfl_84_idx = (int)(Math.Round(NumberUtil.Val( GetPar( "nGXsfl_84_idx"), "."), 18, MidpointRounding.ToEven));
         sGXsfl_84_idx = GetPar( "sGXsfl_84_idx");
         setAjaxCallMode();
         if ( ! IsValidAjaxCall( true) )
         {
            GxWebError = 1;
            return  ;
         }
         gxnrGrid1_newrow( ) ;
         /* End function gxnrGrid1_newrow_invoke */
      }

      protected void gxgrGrid1_refresh_invoke( )
      {
         subGrid1_Rows = (int)(Math.Round(NumberUtil.Val( GetPar( "subGrid1_Rows"), "."), 18, MidpointRounding.ToEven));
         AV6cProductoID = (int)(Math.Round(NumberUtil.Val( GetPar( "cProductoID"), "."), 18, MidpointRounding.ToEven));
         AV7cProductoNombre = GetPar( "cProductoNombre");
         AV8cProductoDescripcion = GetPar( "cProductoDescripcion");
         AV9cProductoPrecio = NumberUtil.Val( GetPar( "cProductoPrecio"), ".");
         AV10cVendedorID = (int)(Math.Round(NumberUtil.Val( GetPar( "cVendedorID"), "."), 18, MidpointRounding.ToEven));
         AV11cCategoriaID = (int)(Math.Round(NumberUtil.Val( GetPar( "cCategoriaID"), "."), 18, MidpointRounding.ToEven));
         AV12cProductoPaisID = (int)(Math.Round(NumberUtil.Val( GetPar( "cProductoPaisID"), "."), 18, MidpointRounding.ToEven));
         setAjaxCallMode();
         if ( ! IsValidAjaxCall( true) )
         {
            GxWebError = 1;
            return  ;
         }
         gxgrGrid1_refresh( subGrid1_Rows, AV6cProductoID, AV7cProductoNombre, AV8cProductoDescripcion, AV9cProductoPrecio, AV10cVendedorID, AV11cCategoriaID, AV12cProductoPaisID) ;
         AddString( context.getJSONResponse( )) ;
         /* End function gxgrGrid1_refresh_invoke */
      }

      public override void webExecute( )
      {
         createObjects();
         initialize();
         INITWEB( ) ;
         if ( ! isAjaxCallMode( ) )
         {
            MasterPageObj = (GXMasterPage) ClassLoader.GetInstance("general.ui.masterprompt", "GeneXus.Programs.general.ui.masterprompt", new Object[] {context});
            MasterPageObj.setDataArea(this,true);
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
         PA142( ) ;
         gxajaxcallmode = (short)((isAjaxCallMode( ) ? 1 : 0));
         if ( ( gxajaxcallmode == 0 ) && ( GxWebError == 0 ) )
         {
            START142( ) ;
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("gx0070.aspx", new object[] {UrlEncode(StringUtil.LTrimStr(AV13pProductoID,6,0))}, new string[] {"pProductoID"}) +"\">") ;
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
         GxWebStd.gx_hidden_field( context, "GXH_vCPRODUCTOID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV6cProductoID), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "GXH_vCPRODUCTONOMBRE", AV7cProductoNombre);
         GxWebStd.gx_hidden_field( context, "GXH_vCPRODUCTODESCRIPCION", AV8cProductoDescripcion);
         GxWebStd.gx_hidden_field( context, "GXH_vCPRODUCTOPRECIO", StringUtil.LTrim( StringUtil.NToC( AV9cProductoPrecio, 10, 2, ".", "")));
         GxWebStd.gx_hidden_field( context, "GXH_vCVENDEDORID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV10cVendedorID), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "GXH_vCCATEGORIAID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV11cCategoriaID), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "GXH_vCPRODUCTOPAISID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV12cProductoPaisID), 6, 0, ".", "")));
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "nRC_GXsfl_84", StringUtil.LTrim( StringUtil.NToC( (decimal)(nRC_GXsfl_84), 8, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "vPPRODUCTOID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV13pProductoID), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "GRID1_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID1_nFirstRecordOnPage), 15, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "GRID1_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID1_nEOF), 1, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "ADVANCEDCONTAINER_Class", StringUtil.RTrim( divAdvancedcontainer_Class));
         GxWebStd.gx_hidden_field( context, "BTNTOGGLE_Class", StringUtil.RTrim( bttBtntoggle_Class));
         GxWebStd.gx_hidden_field( context, "PRODUCTOIDFILTERCONTAINER_Class", StringUtil.RTrim( divProductoidfiltercontainer_Class));
         GxWebStd.gx_hidden_field( context, "PRODUCTONOMBREFILTERCONTAINER_Class", StringUtil.RTrim( divProductonombrefiltercontainer_Class));
         GxWebStd.gx_hidden_field( context, "PRODUCTODESCRIPCIONFILTERCONTAINER_Class", StringUtil.RTrim( divProductodescripcionfiltercontainer_Class));
         GxWebStd.gx_hidden_field( context, "PRODUCTOPRECIOFILTERCONTAINER_Class", StringUtil.RTrim( divProductopreciofiltercontainer_Class));
         GxWebStd.gx_hidden_field( context, "VENDEDORIDFILTERCONTAINER_Class", StringUtil.RTrim( divVendedoridfiltercontainer_Class));
         GxWebStd.gx_hidden_field( context, "CATEGORIAIDFILTERCONTAINER_Class", StringUtil.RTrim( divCategoriaidfiltercontainer_Class));
         GxWebStd.gx_hidden_field( context, "PRODUCTOPAISIDFILTERCONTAINER_Class", StringUtil.RTrim( divProductopaisidfiltercontainer_Class));
      }

      public override void RenderHtmlCloseForm( )
      {
         SendCloseFormHiddens( ) ;
         GxWebStd.gx_hidden_field( context, "GX_FocusControl", "notset");
         SendAjaxEncryptionKey();
         SendSecurityToken((string)(sPrefix));
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

      public override void RenderHtmlContent( )
      {
         gxajaxcallmode = (short)((isAjaxCallMode( ) ? 1 : 0));
         if ( ( gxajaxcallmode == 0 ) && ( GxWebError == 0 ) )
         {
            context.WriteHtmlText( "<div") ;
            GxWebStd.ClassAttribute( context, "gx-ct-body"+" "+(String.IsNullOrEmpty(StringUtil.RTrim( Form.Class)) ? "form-horizontal Form" : Form.Class)+"-fx");
            context.WriteHtmlText( ">") ;
            WE142( ) ;
            context.WriteHtmlText( "</div>") ;
         }
      }

      public override void DispatchEvents( )
      {
         EVT142( ) ;
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
         return formatLink("gx0070.aspx", new object[] {UrlEncode(StringUtil.LTrimStr(AV13pProductoID,6,0))}, new string[] {"pProductoID"})  ;
      }

      public override string GetPgmname( )
      {
         return "Gx0070" ;
      }

      public override string GetPgmdesc( )
      {
         return "Selection List Producto" ;
      }

      protected void WB140( )
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
            GxWebStd.gx_msg_list( context, "", context.GX_msglist.DisplayMode, "", "", "", "false");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Section", "start", "top", " "+"data-gx-base-lib=\"none\""+" "+"data-abstract-form"+" ", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divMain_Internalname, 1, 0, "px", 0, "px", "ContainerFluid PromptContainer", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-3 PromptAdvancedBarCell", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divAdvancedcontainer_Internalname, 1, 0, "px", 0, "px", divAdvancedcontainer_Class, "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divProductoidfiltercontainer_Internalname, 1, 0, "px", 0, "px", divProductoidfiltercontainer_Class, "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblLblproductoidfilter_Internalname, "Producto ID", "", "", lblLblproductoidfilter_Jsonclick, "'"+""+"'"+",false,"+"'"+"e11141_client"+"'", "", "WWAdvancedLabel WWFilterLabel", 7, "", 1, 1, 0, 1, "HLP_Gx0070.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 WWFiltersCell", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavCproductoid_Internalname, "Producto ID", "col-sm-3 AttributeLabel", 0, true, "");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 16,'',false,'" + sGXsfl_84_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavCproductoid_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV6cProductoID), 6, 0, ".", "")), StringUtil.LTrim( ((edtavCproductoid_Enabled!=0) ? context.localUtil.Format( (decimal)(AV6cProductoID), "ZZZZZ9") : context.localUtil.Format( (decimal)(AV6cProductoID), "ZZZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,16);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCproductoid_Jsonclick, 0, "Attribute", "", "", "", "", edtavCproductoid_Visible, edtavCproductoid_Enabled, 0, "text", "1", 6, "chr", 1, "row", 6, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_Gx0070.htm");
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
            GxWebStd.gx_div_start( context, divProductonombrefiltercontainer_Internalname, 1, 0, "px", 0, "px", divProductonombrefiltercontainer_Class, "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblLblproductonombrefilter_Internalname, "Producto Nombre", "", "", lblLblproductonombrefilter_Jsonclick, "'"+""+"'"+",false,"+"'"+"e12141_client"+"'", "", "WWAdvancedLabel WWFilterLabel", 7, "", 1, 1, 0, 1, "HLP_Gx0070.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 WWFiltersCell", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavCproductonombre_Internalname, "Producto Nombre", "col-sm-3 AttributeLabel", 0, true, "");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 26,'',false,'" + sGXsfl_84_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavCproductonombre_Internalname, AV7cProductoNombre, StringUtil.RTrim( context.localUtil.Format( AV7cProductoNombre, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,26);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCproductonombre_Jsonclick, 0, "Attribute", "", "", "", "", edtavCproductonombre_Visible, edtavCproductonombre_Enabled, 0, "text", "", 80, "chr", 1, "row", 80, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_Gx0070.htm");
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
            GxWebStd.gx_div_start( context, divProductodescripcionfiltercontainer_Internalname, 1, 0, "px", 0, "px", divProductodescripcionfiltercontainer_Class, "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblLblproductodescripcionfilter_Internalname, "Producto Descripcion", "", "", lblLblproductodescripcionfilter_Jsonclick, "'"+""+"'"+",false,"+"'"+"e13141_client"+"'", "", "WWAdvancedLabel WWFilterLabel", 7, "", 1, 1, 0, 1, "HLP_Gx0070.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 WWFiltersCell", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavCproductodescripcion_Internalname, "Producto Descripcion", "col-sm-3 AttributeLabel", 0, true, "");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 36,'',false,'" + sGXsfl_84_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavCproductodescripcion_Internalname, AV8cProductoDescripcion, StringUtil.RTrim( context.localUtil.Format( AV8cProductoDescripcion, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,36);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCproductodescripcion_Jsonclick, 0, "Attribute", "", "", "", "", edtavCproductodescripcion_Visible, edtavCproductodescripcion_Enabled, 0, "text", "", 80, "chr", 1, "row", 80, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_Gx0070.htm");
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
            GxWebStd.gx_div_start( context, divProductopreciofiltercontainer_Internalname, 1, 0, "px", 0, "px", divProductopreciofiltercontainer_Class, "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblLblproductopreciofilter_Internalname, "Producto Precio", "", "", lblLblproductopreciofilter_Jsonclick, "'"+""+"'"+",false,"+"'"+"e14141_client"+"'", "", "WWAdvancedLabel WWFilterLabel", 7, "", 1, 1, 0, 1, "HLP_Gx0070.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 WWFiltersCell", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavCproductoprecio_Internalname, "Producto Precio", "col-sm-3 AttributeLabel", 0, true, "");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 46,'',false,'" + sGXsfl_84_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavCproductoprecio_Internalname, StringUtil.LTrim( StringUtil.NToC( AV9cProductoPrecio, 10, 2, ".", "")), StringUtil.LTrim( ((edtavCproductoprecio_Enabled!=0) ? context.localUtil.Format( AV9cProductoPrecio, "ZZZZZZ9.99") : context.localUtil.Format( AV9cProductoPrecio, "ZZZZZZ9.99"))), TempTags+" onchange=\""+"gx.num.valid_decimal( this, ',','.','2');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, ',','.','2');"+";gx.evt.onblur(this,46);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCproductoprecio_Jsonclick, 0, "Attribute", "", "", "", "", edtavCproductoprecio_Visible, edtavCproductoprecio_Enabled, 0, "text", "", 10, "chr", 1, "row", 10, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_Gx0070.htm");
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
            GxWebStd.gx_div_start( context, divVendedoridfiltercontainer_Internalname, 1, 0, "px", 0, "px", divVendedoridfiltercontainer_Class, "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblLblvendedoridfilter_Internalname, "Vendedor ID", "", "", lblLblvendedoridfilter_Jsonclick, "'"+""+"'"+",false,"+"'"+"e15141_client"+"'", "", "WWAdvancedLabel WWFilterLabel", 7, "", 1, 1, 0, 1, "HLP_Gx0070.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 WWFiltersCell", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavCvendedorid_Internalname, "Vendedor ID", "col-sm-3 AttributeLabel", 0, true, "");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 56,'',false,'" + sGXsfl_84_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavCvendedorid_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV10cVendedorID), 6, 0, ".", "")), StringUtil.LTrim( ((edtavCvendedorid_Enabled!=0) ? context.localUtil.Format( (decimal)(AV10cVendedorID), "ZZZZZ9") : context.localUtil.Format( (decimal)(AV10cVendedorID), "ZZZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,56);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCvendedorid_Jsonclick, 0, "Attribute", "", "", "", "", edtavCvendedorid_Visible, edtavCvendedorid_Enabled, 0, "text", "1", 6, "chr", 1, "row", 6, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_Gx0070.htm");
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
            GxWebStd.gx_div_start( context, divCategoriaidfiltercontainer_Internalname, 1, 0, "px", 0, "px", divCategoriaidfiltercontainer_Class, "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblLblcategoriaidfilter_Internalname, "Categoria ID", "", "", lblLblcategoriaidfilter_Jsonclick, "'"+""+"'"+",false,"+"'"+"e16141_client"+"'", "", "WWAdvancedLabel WWFilterLabel", 7, "", 1, 1, 0, 1, "HLP_Gx0070.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 WWFiltersCell", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavCcategoriaid_Internalname, "Categoria ID", "col-sm-3 AttributeLabel", 0, true, "");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 66,'',false,'" + sGXsfl_84_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavCcategoriaid_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV11cCategoriaID), 6, 0, ".", "")), StringUtil.LTrim( ((edtavCcategoriaid_Enabled!=0) ? context.localUtil.Format( (decimal)(AV11cCategoriaID), "ZZZZZ9") : context.localUtil.Format( (decimal)(AV11cCategoriaID), "ZZZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,66);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCcategoriaid_Jsonclick, 0, "Attribute", "", "", "", "", edtavCcategoriaid_Visible, edtavCcategoriaid_Enabled, 0, "text", "1", 6, "chr", 1, "row", 6, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_Gx0070.htm");
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
            GxWebStd.gx_div_start( context, divProductopaisidfiltercontainer_Internalname, 1, 0, "px", 0, "px", divProductopaisidfiltercontainer_Class, "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblLblproductopaisidfilter_Internalname, "Producto Pais ID", "", "", lblLblproductopaisidfilter_Jsonclick, "'"+""+"'"+",false,"+"'"+"e17141_client"+"'", "", "WWAdvancedLabel WWFilterLabel", 7, "", 1, 1, 0, 1, "HLP_Gx0070.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 WWFiltersCell", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavCproductopaisid_Internalname, "Producto Pais ID", "col-sm-3 AttributeLabel", 0, true, "");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 76,'',false,'" + sGXsfl_84_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavCproductopaisid_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV12cProductoPaisID), 6, 0, ".", "")), StringUtil.LTrim( ((edtavCproductopaisid_Enabled!=0) ? context.localUtil.Format( (decimal)(AV12cProductoPaisID), "ZZZZZ9") : context.localUtil.Format( (decimal)(AV12cProductoPaisID), "ZZZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,76);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCproductopaisid_Jsonclick, 0, "Attribute", "", "", "", "", edtavCproductopaisid_Visible, edtavCproductopaisid_Enabled, 0, "text", "1", 6, "chr", 1, "row", 6, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_Gx0070.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-9 WWGridCell", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divGridtable_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 hidden-sm hidden-md hidden-lg ToggleCell", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 81,'',false,'',0)\"";
            ClassString = bttBtntoggle_Class;
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtntoggle_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(84), 2, 0)+","+"null"+");", "|||", bttBtntoggle_Jsonclick, 7, "|||", "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"e18141_client"+"'", TempTags, "", 2, "HLP_Gx0070.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /*  Grid Control  */
            Grid1Container.SetWrapped(nGXWrapped);
            StartGridControl84( ) ;
         }
         if ( wbEnd == 84 )
         {
            wbEnd = 0;
            nRC_GXsfl_84 = (int)(nGXsfl_84_idx-1);
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "</table>") ;
               context.WriteHtmlText( "</div>") ;
            }
            else
            {
               Grid1Container.AddObjectProperty("GRID1_nEOF", GRID1_nEOF);
               Grid1Container.AddObjectProperty("GRID1_nFirstRecordOnPage", GRID1_nFirstRecordOnPage);
               sStyleString = "";
               context.WriteHtmlText( "<div id=\""+"Grid1Container"+"Div\" "+sStyleString+">"+"</div>") ;
               context.httpAjaxContext.ajax_rsp_assign_grid("_"+"Grid1", Grid1Container, subGrid1_Internalname);
               if ( ! context.isAjaxRequest( ) && ! context.isSpaRequest( ) )
               {
                  GxWebStd.gx_hidden_field( context, "Grid1ContainerData", Grid1Container.ToJavascriptSource());
               }
               if ( context.isAjaxRequest( ) || context.isSpaRequest( ) )
               {
                  GxWebStd.gx_hidden_field( context, "Grid1ContainerData"+"V", Grid1Container.GridValuesHidden());
               }
               else
               {
                  context.WriteHtmlText( "<input type=\"hidden\" "+"name=\""+"Grid1ContainerData"+"V"+"\" value='"+Grid1Container.GridValuesHidden()+"'/>") ;
               }
            }
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 92,'',false,'',0)\"";
            ClassString = "BtnCancel";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtn_cancel_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(84), 2, 0)+","+"null"+");", "Cancel", bttBtn_cancel_Jsonclick, 1, "Cancel", "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_Gx0070.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
         }
         if ( wbEnd == 84 )
         {
            wbEnd = 0;
            if ( isFullAjaxMode( ) )
            {
               if ( Grid1Container.GetWrapped() == 1 )
               {
                  context.WriteHtmlText( "</table>") ;
                  context.WriteHtmlText( "</div>") ;
               }
               else
               {
                  Grid1Container.AddObjectProperty("GRID1_nEOF", GRID1_nEOF);
                  Grid1Container.AddObjectProperty("GRID1_nFirstRecordOnPage", GRID1_nFirstRecordOnPage);
                  sStyleString = "";
                  context.WriteHtmlText( "<div id=\""+"Grid1Container"+"Div\" "+sStyleString+">"+"</div>") ;
                  context.httpAjaxContext.ajax_rsp_assign_grid("_"+"Grid1", Grid1Container, subGrid1_Internalname);
                  if ( ! context.isAjaxRequest( ) && ! context.isSpaRequest( ) )
                  {
                     GxWebStd.gx_hidden_field( context, "Grid1ContainerData", Grid1Container.ToJavascriptSource());
                  }
                  if ( context.isAjaxRequest( ) || context.isSpaRequest( ) )
                  {
                     GxWebStd.gx_hidden_field( context, "Grid1ContainerData"+"V", Grid1Container.GridValuesHidden());
                  }
                  else
                  {
                     context.WriteHtmlText( "<input type=\"hidden\" "+"name=\""+"Grid1ContainerData"+"V"+"\" value='"+Grid1Container.GridValuesHidden()+"'/>") ;
                  }
               }
            }
         }
         wbLoad = true;
      }

      protected void START142( )
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
         Form.Meta.addItem("description", "Selection List Producto", 0) ;
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         wbErr = false;
         STRUP140( ) ;
      }

      protected void WS142( )
      {
         START142( ) ;
         EVT142( ) ;
      }

      protected void EVT142( )
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
                              /* No code required for Cancel button. It is implemented as the Reset button. */
                           }
                           else if ( StringUtil.StrCmp(sEvt, "LSCR") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                           }
                           else if ( StringUtil.StrCmp(sEvt, "GRID1PAGING") == 0 )
                           {
                              context.wbHandled = 1;
                              sEvt = cgiGet( "GRID1PAGING");
                              if ( StringUtil.StrCmp(sEvt, "FIRST") == 0 )
                              {
                                 subgrid1_firstpage( ) ;
                              }
                              else if ( StringUtil.StrCmp(sEvt, "PREV") == 0 )
                              {
                                 subgrid1_previouspage( ) ;
                              }
                              else if ( StringUtil.StrCmp(sEvt, "NEXT") == 0 )
                              {
                                 subgrid1_nextpage( ) ;
                              }
                              else if ( StringUtil.StrCmp(sEvt, "LAST") == 0 )
                              {
                                 subgrid1_lastpage( ) ;
                              }
                              dynload_actions( ) ;
                           }
                        }
                        else
                        {
                           sEvtType = StringUtil.Right( sEvt, 4);
                           sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-4));
                           if ( ( StringUtil.StrCmp(StringUtil.Left( sEvt, 5), "START") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 4), "LOAD") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 5), "ENTER") == 0 ) )
                           {
                              nGXsfl_84_idx = (int)(Math.Round(NumberUtil.Val( sEvtType, "."), 18, MidpointRounding.ToEven));
                              sGXsfl_84_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_84_idx), 4, 0), 4, "0");
                              SubsflControlProps_842( ) ;
                              AV5LinkSelection = cgiGet( edtavLinkselection_Internalname);
                              AssignProp("", false, edtavLinkselection_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( AV5LinkSelection)) ? AV15Linkselection_GXI : context.convertURL( context.PathToRelativeUrl( AV5LinkSelection))), !bGXsfl_84_Refreshing);
                              AssignProp("", false, edtavLinkselection_Internalname, "SrcSet", context.GetImageSrcSet( AV5LinkSelection), true);
                              A19ProductoID = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtProductoID_Internalname), ".", ","), 18, MidpointRounding.ToEven));
                              A20ProductoNombre = cgiGet( edtProductoNombre_Internalname);
                              A22ProductoPrecio = context.localUtil.CToN( cgiGet( edtProductoPrecio_Internalname), ".", ",");
                              A23ProductoImagen = cgiGet( edtProductoImagen_Internalname);
                              AssignProp("", false, edtProductoImagen_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A23ProductoImagen)) ? A40000ProductoImagen_GXI : context.convertURL( context.PathToRelativeUrl( A23ProductoImagen))), !bGXsfl_84_Refreshing);
                              AssignProp("", false, edtProductoImagen_Internalname, "SrcSet", context.GetImageSrcSet( A23ProductoImagen), true);
                              sEvtType = StringUtil.Right( sEvt, 1);
                              if ( StringUtil.StrCmp(sEvtType, ".") == 0 )
                              {
                                 sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-1));
                                 if ( StringUtil.StrCmp(sEvt, "START") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Start */
                                    E19142 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "LOAD") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Load */
                                    E20142 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "ENTER") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    if ( ! wbErr )
                                    {
                                       Rfr0gs = false;
                                       /* Set Refresh If Cproductoid Changed */
                                       if ( ( context.localUtil.CToN( cgiGet( "GXH_vCPRODUCTOID"), ".", ",") != Convert.ToDecimal( AV6cProductoID )) )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Cproductonombre Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vCPRODUCTONOMBRE"), AV7cProductoNombre) != 0 )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Cproductodescripcion Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vCPRODUCTODESCRIPCION"), AV8cProductoDescripcion) != 0 )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Cproductoprecio Changed */
                                       if ( context.localUtil.CToN( cgiGet( "GXH_vCPRODUCTOPRECIO"), ".", ",") != AV9cProductoPrecio )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Cvendedorid Changed */
                                       if ( ( context.localUtil.CToN( cgiGet( "GXH_vCVENDEDORID"), ".", ",") != Convert.ToDecimal( AV10cVendedorID )) )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Ccategoriaid Changed */
                                       if ( ( context.localUtil.CToN( cgiGet( "GXH_vCCATEGORIAID"), ".", ",") != Convert.ToDecimal( AV11cCategoriaID )) )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Cproductopaisid Changed */
                                       if ( ( context.localUtil.CToN( cgiGet( "GXH_vCPRODUCTOPAISID"), ".", ",") != Convert.ToDecimal( AV12cProductoPaisID )) )
                                       {
                                          Rfr0gs = true;
                                       }
                                       if ( ! Rfr0gs )
                                       {
                                          /* Execute user event: Enter */
                                          E21142 ();
                                       }
                                       dynload_actions( ) ;
                                    }
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

      protected void WE142( )
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

      protected void PA142( )
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
            nDonePA = 1;
         }
      }

      protected void dynload_actions( )
      {
         /* End function dynload_actions */
      }

      protected void gxnrGrid1_newrow( )
      {
         GxWebStd.set_html_headers( context, 0, "", "");
         SubsflControlProps_842( ) ;
         while ( nGXsfl_84_idx <= nRC_GXsfl_84 )
         {
            sendrow_842( ) ;
            nGXsfl_84_idx = ((subGrid1_Islastpage==1)&&(nGXsfl_84_idx+1>subGrid1_fnc_Recordsperpage( )) ? 1 : nGXsfl_84_idx+1);
            sGXsfl_84_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_84_idx), 4, 0), 4, "0");
            SubsflControlProps_842( ) ;
         }
         AddString( context.httpAjaxContext.getJSONContainerResponse( Grid1Container)) ;
         /* End function gxnrGrid1_newrow */
      }

      protected void gxgrGrid1_refresh( int subGrid1_Rows ,
                                        int AV6cProductoID ,
                                        string AV7cProductoNombre ,
                                        string AV8cProductoDescripcion ,
                                        decimal AV9cProductoPrecio ,
                                        int AV10cVendedorID ,
                                        int AV11cCategoriaID ,
                                        int AV12cProductoPaisID )
      {
         initialize_formulas( ) ;
         GxWebStd.set_html_headers( context, 0, "", "");
         GRID1_nCurrentRecord = 0;
         RF142( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         send_integrity_footer_hashes( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         /* End function gxgrGrid1_refresh */
      }

      protected void send_integrity_hashes( )
      {
         GxWebStd.gx_hidden_field( context, "gxhash_PRODUCTOID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(A19ProductoID), "ZZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "PRODUCTOID", StringUtil.LTrim( StringUtil.NToC( (decimal)(A19ProductoID), 6, 0, ".", "")));
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
         RF142( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
      }

      protected void RF142( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         if ( isAjaxCallMode( ) )
         {
            Grid1Container.ClearRows();
         }
         wbStart = 84;
         nGXsfl_84_idx = 1;
         sGXsfl_84_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_84_idx), 4, 0), 4, "0");
         SubsflControlProps_842( ) ;
         bGXsfl_84_Refreshing = true;
         Grid1Container.AddObjectProperty("GridName", "Grid1");
         Grid1Container.AddObjectProperty("CmpContext", "");
         Grid1Container.AddObjectProperty("InMasterPage", "false");
         Grid1Container.AddObjectProperty("Class", "PromptGrid");
         Grid1Container.AddObjectProperty("Cellpadding", StringUtil.LTrim( StringUtil.NToC( (decimal)(1), 4, 0, ".", "")));
         Grid1Container.AddObjectProperty("Cellspacing", StringUtil.LTrim( StringUtil.NToC( (decimal)(2), 4, 0, ".", "")));
         Grid1Container.AddObjectProperty("Backcolorstyle", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid1_Backcolorstyle), 1, 0, ".", "")));
         Grid1Container.PageSize = subGrid1_fnc_Recordsperpage( );
         gxdyncontrolsrefreshing = true;
         fix_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = false;
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            SubsflControlProps_842( ) ;
            GXPagingFrom2 = (int)(GRID1_nFirstRecordOnPage);
            GXPagingTo2 = (int)(subGrid1_fnc_Recordsperpage( )+1);
            pr_default.dynParam(0, new Object[]{ new Object[]{
                                                 AV7cProductoNombre ,
                                                 AV8cProductoDescripcion ,
                                                 AV9cProductoPrecio ,
                                                 AV10cVendedorID ,
                                                 AV11cCategoriaID ,
                                                 AV12cProductoPaisID ,
                                                 A20ProductoNombre ,
                                                 A21ProductoDescripcion ,
                                                 A22ProductoPrecio ,
                                                 A6VendedorID ,
                                                 A4CategoriaID ,
                                                 A26ProductoPaisID ,
                                                 AV6cProductoID } ,
                                                 new int[]{
                                                 TypeConstants.DECIMAL, TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.DECIMAL, TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.INT
                                                 }
            });
            lV7cProductoNombre = StringUtil.Concat( StringUtil.RTrim( AV7cProductoNombre), "%", "");
            lV8cProductoDescripcion = StringUtil.Concat( StringUtil.RTrim( AV8cProductoDescripcion), "%", "");
            /* Using cursor H00142 */
            pr_default.execute(0, new Object[] {AV6cProductoID, lV7cProductoNombre, lV8cProductoDescripcion, AV9cProductoPrecio, AV10cVendedorID, AV11cCategoriaID, AV12cProductoPaisID, GXPagingFrom2, GXPagingTo2, GXPagingTo2});
            nGXsfl_84_idx = 1;
            sGXsfl_84_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_84_idx), 4, 0), 4, "0");
            SubsflControlProps_842( ) ;
            while ( ( (pr_default.getStatus(0) != 101) ) && ( ( GRID1_nCurrentRecord < subGrid1_fnc_Recordsperpage( ) ) ) )
            {
               A26ProductoPaisID = H00142_A26ProductoPaisID[0];
               A4CategoriaID = H00142_A4CategoriaID[0];
               A6VendedorID = H00142_A6VendedorID[0];
               A21ProductoDescripcion = H00142_A21ProductoDescripcion[0];
               A40000ProductoImagen_GXI = H00142_A40000ProductoImagen_GXI[0];
               AssignProp("", false, edtProductoImagen_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A23ProductoImagen)) ? A40000ProductoImagen_GXI : context.convertURL( context.PathToRelativeUrl( A23ProductoImagen))), !bGXsfl_84_Refreshing);
               AssignProp("", false, edtProductoImagen_Internalname, "SrcSet", context.GetImageSrcSet( A23ProductoImagen), true);
               A22ProductoPrecio = H00142_A22ProductoPrecio[0];
               A20ProductoNombre = H00142_A20ProductoNombre[0];
               A19ProductoID = H00142_A19ProductoID[0];
               A23ProductoImagen = H00142_A23ProductoImagen[0];
               AssignProp("", false, edtProductoImagen_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A23ProductoImagen)) ? A40000ProductoImagen_GXI : context.convertURL( context.PathToRelativeUrl( A23ProductoImagen))), !bGXsfl_84_Refreshing);
               AssignProp("", false, edtProductoImagen_Internalname, "SrcSet", context.GetImageSrcSet( A23ProductoImagen), true);
               /* Execute user event: Load */
               E20142 ();
               pr_default.readNext(0);
            }
            GRID1_nEOF = (short)(((pr_default.getStatus(0) == 101) ? 1 : 0));
            GxWebStd.gx_hidden_field( context, "GRID1_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID1_nEOF), 1, 0, ".", "")));
            pr_default.close(0);
            wbEnd = 84;
            WB140( ) ;
         }
         bGXsfl_84_Refreshing = true;
      }

      protected void send_integrity_lvl_hashes142( )
      {
         GxWebStd.gx_hidden_field( context, "gxhash_PRODUCTOID"+"_"+sGXsfl_84_idx, GetSecureSignedToken( sGXsfl_84_idx, context.localUtil.Format( (decimal)(A19ProductoID), "ZZZZZ9"), context));
      }

      protected int subGrid1_fnc_Pagecount( )
      {
         GRID1_nRecordCount = subGrid1_fnc_Recordcount( );
         if ( ((int)((GRID1_nRecordCount) % (subGrid1_fnc_Recordsperpage( )))) == 0 )
         {
            return (int)(NumberUtil.Int( (long)(Math.Round(GRID1_nRecordCount/ (decimal)(subGrid1_fnc_Recordsperpage( )), 18, MidpointRounding.ToEven)))) ;
         }
         return (int)(NumberUtil.Int( (long)(Math.Round(GRID1_nRecordCount/ (decimal)(subGrid1_fnc_Recordsperpage( )), 18, MidpointRounding.ToEven)))+1) ;
      }

      protected int subGrid1_fnc_Recordcount( )
      {
         pr_default.dynParam(1, new Object[]{ new Object[]{
                                              AV7cProductoNombre ,
                                              AV8cProductoDescripcion ,
                                              AV9cProductoPrecio ,
                                              AV10cVendedorID ,
                                              AV11cCategoriaID ,
                                              AV12cProductoPaisID ,
                                              A20ProductoNombre ,
                                              A21ProductoDescripcion ,
                                              A22ProductoPrecio ,
                                              A6VendedorID ,
                                              A4CategoriaID ,
                                              A26ProductoPaisID ,
                                              AV6cProductoID } ,
                                              new int[]{
                                              TypeConstants.DECIMAL, TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.DECIMAL, TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.INT
                                              }
         });
         lV7cProductoNombre = StringUtil.Concat( StringUtil.RTrim( AV7cProductoNombre), "%", "");
         lV8cProductoDescripcion = StringUtil.Concat( StringUtil.RTrim( AV8cProductoDescripcion), "%", "");
         /* Using cursor H00143 */
         pr_default.execute(1, new Object[] {AV6cProductoID, lV7cProductoNombre, lV8cProductoDescripcion, AV9cProductoPrecio, AV10cVendedorID, AV11cCategoriaID, AV12cProductoPaisID});
         GRID1_nRecordCount = H00143_AGRID1_nRecordCount[0];
         pr_default.close(1);
         return (int)(GRID1_nRecordCount) ;
      }

      protected int subGrid1_fnc_Recordsperpage( )
      {
         return (int)(10*1) ;
      }

      protected int subGrid1_fnc_Currentpage( )
      {
         return (int)(NumberUtil.Int( (long)(Math.Round(GRID1_nFirstRecordOnPage/ (decimal)(subGrid1_fnc_Recordsperpage( )), 18, MidpointRounding.ToEven)))+1) ;
      }

      protected short subgrid1_firstpage( )
      {
         GRID1_nFirstRecordOnPage = 0;
         GxWebStd.gx_hidden_field( context, "GRID1_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID1_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid1_refresh( subGrid1_Rows, AV6cProductoID, AV7cProductoNombre, AV8cProductoDescripcion, AV9cProductoPrecio, AV10cVendedorID, AV11cCategoriaID, AV12cProductoPaisID) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected short subgrid1_nextpage( )
      {
         GRID1_nRecordCount = subGrid1_fnc_Recordcount( );
         if ( ( GRID1_nRecordCount >= subGrid1_fnc_Recordsperpage( ) ) && ( GRID1_nEOF == 0 ) )
         {
            GRID1_nFirstRecordOnPage = (long)(GRID1_nFirstRecordOnPage+subGrid1_fnc_Recordsperpage( ));
         }
         else
         {
            return 2 ;
         }
         GxWebStd.gx_hidden_field( context, "GRID1_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID1_nFirstRecordOnPage), 15, 0, ".", "")));
         Grid1Container.AddObjectProperty("GRID1_nFirstRecordOnPage", GRID1_nFirstRecordOnPage);
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid1_refresh( subGrid1_Rows, AV6cProductoID, AV7cProductoNombre, AV8cProductoDescripcion, AV9cProductoPrecio, AV10cVendedorID, AV11cCategoriaID, AV12cProductoPaisID) ;
         }
         send_integrity_footer_hashes( ) ;
         return (short)(((GRID1_nEOF==0) ? 0 : 2)) ;
      }

      protected short subgrid1_previouspage( )
      {
         if ( GRID1_nFirstRecordOnPage >= subGrid1_fnc_Recordsperpage( ) )
         {
            GRID1_nFirstRecordOnPage = (long)(GRID1_nFirstRecordOnPage-subGrid1_fnc_Recordsperpage( ));
         }
         else
         {
            return 2 ;
         }
         GxWebStd.gx_hidden_field( context, "GRID1_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID1_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid1_refresh( subGrid1_Rows, AV6cProductoID, AV7cProductoNombre, AV8cProductoDescripcion, AV9cProductoPrecio, AV10cVendedorID, AV11cCategoriaID, AV12cProductoPaisID) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected short subgrid1_lastpage( )
      {
         GRID1_nRecordCount = subGrid1_fnc_Recordcount( );
         if ( GRID1_nRecordCount > subGrid1_fnc_Recordsperpage( ) )
         {
            if ( ((int)((GRID1_nRecordCount) % (subGrid1_fnc_Recordsperpage( )))) == 0 )
            {
               GRID1_nFirstRecordOnPage = (long)(GRID1_nRecordCount-subGrid1_fnc_Recordsperpage( ));
            }
            else
            {
               GRID1_nFirstRecordOnPage = (long)(GRID1_nRecordCount-((int)((GRID1_nRecordCount) % (subGrid1_fnc_Recordsperpage( )))));
            }
         }
         else
         {
            GRID1_nFirstRecordOnPage = 0;
         }
         GxWebStd.gx_hidden_field( context, "GRID1_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID1_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid1_refresh( subGrid1_Rows, AV6cProductoID, AV7cProductoNombre, AV8cProductoDescripcion, AV9cProductoPrecio, AV10cVendedorID, AV11cCategoriaID, AV12cProductoPaisID) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected int subgrid1_gotopage( int nPageNo )
      {
         if ( nPageNo > 0 )
         {
            GRID1_nFirstRecordOnPage = (long)(subGrid1_fnc_Recordsperpage( )*(nPageNo-1));
         }
         else
         {
            GRID1_nFirstRecordOnPage = 0;
         }
         GxWebStd.gx_hidden_field( context, "GRID1_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID1_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid1_refresh( subGrid1_Rows, AV6cProductoID, AV7cProductoNombre, AV8cProductoDescripcion, AV9cProductoPrecio, AV10cVendedorID, AV11cCategoriaID, AV12cProductoPaisID) ;
         }
         send_integrity_footer_hashes( ) ;
         return (int)(0) ;
      }

      protected void before_start_formulas( )
      {
         edtProductoID_Enabled = 0;
         edtProductoNombre_Enabled = 0;
         edtProductoPrecio_Enabled = 0;
         edtProductoImagen_Enabled = 0;
         fix_multi_value_controls( ) ;
      }

      protected void STRUP140( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E19142 ();
         context.wbGlbDoneStart = 1;
         /* After Start, stand alone formulas. */
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
            /* Read saved SDTs. */
            /* Read saved values. */
            nRC_GXsfl_84 = (int)(Math.Round(context.localUtil.CToN( cgiGet( "nRC_GXsfl_84"), ".", ","), 18, MidpointRounding.ToEven));
            GRID1_nFirstRecordOnPage = (long)(Math.Round(context.localUtil.CToN( cgiGet( "GRID1_nFirstRecordOnPage"), ".", ","), 18, MidpointRounding.ToEven));
            GRID1_nEOF = (short)(Math.Round(context.localUtil.CToN( cgiGet( "GRID1_nEOF"), ".", ","), 18, MidpointRounding.ToEven));
            /* Read variables values. */
            if ( ( ( context.localUtil.CToN( cgiGet( edtavCproductoid_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavCproductoid_Internalname), ".", ",") > Convert.ToDecimal( 999999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vCPRODUCTOID");
               GX_FocusControl = edtavCproductoid_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV6cProductoID = 0;
               AssignAttri("", false, "AV6cProductoID", StringUtil.LTrimStr( (decimal)(AV6cProductoID), 6, 0));
            }
            else
            {
               AV6cProductoID = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtavCproductoid_Internalname), ".", ","), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV6cProductoID", StringUtil.LTrimStr( (decimal)(AV6cProductoID), 6, 0));
            }
            AV7cProductoNombre = cgiGet( edtavCproductonombre_Internalname);
            AssignAttri("", false, "AV7cProductoNombre", AV7cProductoNombre);
            AV8cProductoDescripcion = cgiGet( edtavCproductodescripcion_Internalname);
            AssignAttri("", false, "AV8cProductoDescripcion", AV8cProductoDescripcion);
            if ( ( ( context.localUtil.CToN( cgiGet( edtavCproductoprecio_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavCproductoprecio_Internalname), ".", ",") > 9999999.99m ) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vCPRODUCTOPRECIO");
               GX_FocusControl = edtavCproductoprecio_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV9cProductoPrecio = 0;
               AssignAttri("", false, "AV9cProductoPrecio", StringUtil.LTrimStr( AV9cProductoPrecio, 10, 2));
            }
            else
            {
               AV9cProductoPrecio = context.localUtil.CToN( cgiGet( edtavCproductoprecio_Internalname), ".", ",");
               AssignAttri("", false, "AV9cProductoPrecio", StringUtil.LTrimStr( AV9cProductoPrecio, 10, 2));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtavCvendedorid_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavCvendedorid_Internalname), ".", ",") > Convert.ToDecimal( 999999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vCVENDEDORID");
               GX_FocusControl = edtavCvendedorid_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV10cVendedorID = 0;
               AssignAttri("", false, "AV10cVendedorID", StringUtil.LTrimStr( (decimal)(AV10cVendedorID), 6, 0));
            }
            else
            {
               AV10cVendedorID = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtavCvendedorid_Internalname), ".", ","), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV10cVendedorID", StringUtil.LTrimStr( (decimal)(AV10cVendedorID), 6, 0));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtavCcategoriaid_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavCcategoriaid_Internalname), ".", ",") > Convert.ToDecimal( 999999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vCCATEGORIAID");
               GX_FocusControl = edtavCcategoriaid_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV11cCategoriaID = 0;
               AssignAttri("", false, "AV11cCategoriaID", StringUtil.LTrimStr( (decimal)(AV11cCategoriaID), 6, 0));
            }
            else
            {
               AV11cCategoriaID = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtavCcategoriaid_Internalname), ".", ","), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV11cCategoriaID", StringUtil.LTrimStr( (decimal)(AV11cCategoriaID), 6, 0));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtavCproductopaisid_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavCproductopaisid_Internalname), ".", ",") > Convert.ToDecimal( 999999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vCPRODUCTOPAISID");
               GX_FocusControl = edtavCproductopaisid_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV12cProductoPaisID = 0;
               AssignAttri("", false, "AV12cProductoPaisID", StringUtil.LTrimStr( (decimal)(AV12cProductoPaisID), 6, 0));
            }
            else
            {
               AV12cProductoPaisID = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtavCproductopaisid_Internalname), ".", ","), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV12cProductoPaisID", StringUtil.LTrimStr( (decimal)(AV12cProductoPaisID), 6, 0));
            }
            /* Read subfile selected row values. */
            /* Read hidden variables. */
            GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
            /* Check if conditions changed and reset current page numbers */
            if ( ( context.localUtil.CToN( cgiGet( "GXH_vCPRODUCTOID"), ".", ",") != Convert.ToDecimal( AV6cProductoID )) )
            {
               GRID1_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( "GXH_vCPRODUCTONOMBRE"), AV7cProductoNombre) != 0 )
            {
               GRID1_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( "GXH_vCPRODUCTODESCRIPCION"), AV8cProductoDescripcion) != 0 )
            {
               GRID1_nFirstRecordOnPage = 0;
            }
            if ( context.localUtil.CToN( cgiGet( "GXH_vCPRODUCTOPRECIO"), ".", ",") != AV9cProductoPrecio )
            {
               GRID1_nFirstRecordOnPage = 0;
            }
            if ( ( context.localUtil.CToN( cgiGet( "GXH_vCVENDEDORID"), ".", ",") != Convert.ToDecimal( AV10cVendedorID )) )
            {
               GRID1_nFirstRecordOnPage = 0;
            }
            if ( ( context.localUtil.CToN( cgiGet( "GXH_vCCATEGORIAID"), ".", ",") != Convert.ToDecimal( AV11cCategoriaID )) )
            {
               GRID1_nFirstRecordOnPage = 0;
            }
            if ( ( context.localUtil.CToN( cgiGet( "GXH_vCPRODUCTOPAISID"), ".", ",") != Convert.ToDecimal( AV12cProductoPaisID )) )
            {
               GRID1_nFirstRecordOnPage = 0;
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
         E19142 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
      }

      protected void E19142( )
      {
         /* Start Routine */
         returnInSub = false;
         Form.Caption = StringUtil.Format( "Selection List %1", "Producto", "", "", "", "", "", "", "", "");
         AssignProp("", false, "FORM", "Caption", Form.Caption, true);
         AV14ADVANCED_LABEL_TEMPLATE = "%1 <strong>%2</strong>";
      }

      private void E20142( )
      {
         /* Load Routine */
         returnInSub = false;
         edtavLinkselection_gximage = "selectRow";
         AV5LinkSelection = context.GetImagePath( "3914535b-0c03-44c5-9538-906a99cdd2bc", "", context.GetTheme( ));
         AssignAttri("", false, edtavLinkselection_Internalname, AV5LinkSelection);
         AV15Linkselection_GXI = GXDbFile.PathToUrl( context.GetImagePath( "3914535b-0c03-44c5-9538-906a99cdd2bc", "", context.GetTheme( )), context);
         sendrow_842( ) ;
         GRID1_nCurrentRecord = (long)(GRID1_nCurrentRecord+1);
         if ( isFullAjaxMode( ) && ! bGXsfl_84_Refreshing )
         {
            DoAjaxLoad(84, Grid1Row);
         }
      }

      public void GXEnter( )
      {
         /* Execute user event: Enter */
         E21142 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
      }

      protected void E21142( )
      {
         /* Enter Routine */
         returnInSub = false;
         AV13pProductoID = A19ProductoID;
         AssignAttri("", false, "AV13pProductoID", StringUtil.LTrimStr( (decimal)(AV13pProductoID), 6, 0));
         context.setWebReturnParms(new Object[] {(int)AV13pProductoID});
         context.setWebReturnParmsMetadata(new Object[] {"AV13pProductoID"});
         context.wjLocDisableFrm = 1;
         context.nUserReturn = 1;
         returnInSub = true;
         if (true) return;
         /*  Sending Event outputs  */
      }

      public override void setparameters( Object[] obj )
      {
         createObjects();
         initialize();
         AV13pProductoID = Convert.ToInt32(getParm(obj,0));
         AssignAttri("", false, "AV13pProductoID", StringUtil.LTrimStr( (decimal)(AV13pProductoID), 6, 0));
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
         PA142( ) ;
         WS142( ) ;
         WE142( ) ;
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
         AddThemeStyleSheetFile("", context.GetTheme( )+".css", "?"+GetCacheInvalidationToken( ));
         bool outputEnabled = isOutputEnabled( );
         if ( context.isSpaRequest( ) )
         {
            enableOutput();
         }
         idxLst = 1;
         while ( idxLst <= Form.Jscriptsrc.Count )
         {
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?2025522048586", true, true);
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
         context.AddJavascriptSource("messages.eng.js", "?"+GetCacheInvalidationToken( ), false, true);
         context.AddJavascriptSource("gx0070.js", "?2025522048586", false, true);
         /* End function include_jscripts */
      }

      protected void SubsflControlProps_842( )
      {
         edtavLinkselection_Internalname = "vLINKSELECTION_"+sGXsfl_84_idx;
         edtProductoID_Internalname = "PRODUCTOID_"+sGXsfl_84_idx;
         edtProductoNombre_Internalname = "PRODUCTONOMBRE_"+sGXsfl_84_idx;
         edtProductoPrecio_Internalname = "PRODUCTOPRECIO_"+sGXsfl_84_idx;
         edtProductoImagen_Internalname = "PRODUCTOIMAGEN_"+sGXsfl_84_idx;
      }

      protected void SubsflControlProps_fel_842( )
      {
         edtavLinkselection_Internalname = "vLINKSELECTION_"+sGXsfl_84_fel_idx;
         edtProductoID_Internalname = "PRODUCTOID_"+sGXsfl_84_fel_idx;
         edtProductoNombre_Internalname = "PRODUCTONOMBRE_"+sGXsfl_84_fel_idx;
         edtProductoPrecio_Internalname = "PRODUCTOPRECIO_"+sGXsfl_84_fel_idx;
         edtProductoImagen_Internalname = "PRODUCTOIMAGEN_"+sGXsfl_84_fel_idx;
      }

      protected void sendrow_842( )
      {
         sGXsfl_84_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_84_idx), 4, 0), 4, "0");
         SubsflControlProps_842( ) ;
         WB140( ) ;
         if ( ( 10 * 1 == 0 ) || ( nGXsfl_84_idx <= subGrid1_fnc_Recordsperpage( ) * 1 ) )
         {
            Grid1Row = GXWebRow.GetNew(context,Grid1Container);
            if ( subGrid1_Backcolorstyle == 0 )
            {
               /* None style subfile background logic. */
               subGrid1_Backstyle = 0;
               if ( StringUtil.StrCmp(subGrid1_Class, "") != 0 )
               {
                  subGrid1_Linesclass = subGrid1_Class+"Odd";
               }
            }
            else if ( subGrid1_Backcolorstyle == 1 )
            {
               /* Uniform style subfile background logic. */
               subGrid1_Backstyle = 0;
               subGrid1_Backcolor = subGrid1_Allbackcolor;
               if ( StringUtil.StrCmp(subGrid1_Class, "") != 0 )
               {
                  subGrid1_Linesclass = subGrid1_Class+"Uniform";
               }
            }
            else if ( subGrid1_Backcolorstyle == 2 )
            {
               /* Header style subfile background logic. */
               subGrid1_Backstyle = 1;
               if ( StringUtil.StrCmp(subGrid1_Class, "") != 0 )
               {
                  subGrid1_Linesclass = subGrid1_Class+"Odd";
               }
               subGrid1_Backcolor = (int)(0x0);
            }
            else if ( subGrid1_Backcolorstyle == 3 )
            {
               /* Report style subfile background logic. */
               subGrid1_Backstyle = 1;
               if ( ((int)((nGXsfl_84_idx) % (2))) == 0 )
               {
                  subGrid1_Backcolor = (int)(0x0);
                  if ( StringUtil.StrCmp(subGrid1_Class, "") != 0 )
                  {
                     subGrid1_Linesclass = subGrid1_Class+"Even";
                  }
               }
               else
               {
                  subGrid1_Backcolor = (int)(0x0);
                  if ( StringUtil.StrCmp(subGrid1_Class, "") != 0 )
                  {
                     subGrid1_Linesclass = subGrid1_Class+"Odd";
                  }
               }
            }
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<tr ") ;
               context.WriteHtmlText( " class=\""+"PromptGrid"+"\" style=\""+""+"\"") ;
               context.WriteHtmlText( " gxrow=\""+sGXsfl_84_idx+"\">") ;
            }
            /* Subfile cell */
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+""+"\""+" style=\""+""+"\">") ;
            }
            /* Static Bitmap Variable */
            edtavLinkselection_Link = "javascript:gx.popup.gxReturn(["+"'"+GXUtil.EncodeJSConstant( StringUtil.LTrim( StringUtil.NToC( (decimal)(A19ProductoID), 6, 0, ".", "")))+"'"+"]);";
            AssignProp("", false, edtavLinkselection_Internalname, "Link", edtavLinkselection_Link, !bGXsfl_84_Refreshing);
            ClassString = "SelectionAttribute" + " " + ((StringUtil.StrCmp(edtavLinkselection_gximage, "")==0) ? "" : "GX_Image_"+edtavLinkselection_gximage+"_Class");
            StyleString = "";
            AV5LinkSelection_IsBlob = (bool)((String.IsNullOrEmpty(StringUtil.RTrim( AV5LinkSelection))&&String.IsNullOrEmpty(StringUtil.RTrim( AV15Linkselection_GXI)))||!String.IsNullOrEmpty(StringUtil.RTrim( AV5LinkSelection)));
            sImgUrl = (String.IsNullOrEmpty(StringUtil.RTrim( AV5LinkSelection)) ? AV15Linkselection_GXI : context.PathToRelativeUrl( AV5LinkSelection));
            Grid1Row.AddColumnProperties("bitmap", 1, isAjaxCallMode( ), new Object[] {(string)edtavLinkselection_Internalname,(string)sImgUrl,(string)edtavLinkselection_Link,(string)"",(string)"",context.GetTheme( ),(short)-1,(short)1,(string)"",(string)"",(short)0,(short)-1,(short)0,(string)"px",(short)0,(string)"px",(short)0,(short)0,(short)0,(string)"",(string)"",(string)StyleString,(string)ClassString,(string)"WWActionColumn",(string)"",(string)"",(string)"",(string)"",(string)"",(string)"",(short)1,(bool)AV5LinkSelection_IsBlob,(bool)false,context.GetImageSrcSet( sImgUrl)});
            /* Subfile cell */
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            Grid1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtProductoID_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A19ProductoID), 6, 0, ".", "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A19ProductoID), "ZZZZZ9")),(string)" dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtProductoID_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)6,(short)0,(short)0,(short)84,(short)0,(short)-1,(short)0,(bool)true,(string)"ID",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "DescriptionAttribute";
            edtProductoNombre_Link = "javascript:gx.popup.gxReturn(["+"'"+GXUtil.EncodeJSConstant( StringUtil.LTrim( StringUtil.NToC( (decimal)(A19ProductoID), 6, 0, ".", "")))+"'"+"]);";
            AssignProp("", false, edtProductoNombre_Internalname, "Link", edtProductoNombre_Link, !bGXsfl_84_Refreshing);
            Grid1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtProductoNombre_Internalname,(string)A20ProductoNombre,(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)edtProductoNombre_Link,(string)"",(string)"",(string)"",(string)edtProductoNombre_Jsonclick,(short)0,(string)"DescriptionAttribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)80,(short)0,(short)0,(short)84,(short)0,(short)-1,(short)-1,(bool)true,(string)"Descripcion",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            Grid1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtProductoPrecio_Internalname,StringUtil.LTrim( StringUtil.NToC( A22ProductoPrecio, 10, 2, ".", "")),StringUtil.LTrim( context.localUtil.Format( A22ProductoPrecio, "ZZZZZZ9.99")),(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtProductoPrecio_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn OptionalColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)10,(short)0,(short)0,(short)84,(short)0,(short)-1,(short)0,(bool)true,(string)"Precio",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+""+"\""+" style=\""+""+"\">") ;
            }
            /* Static Bitmap Variable */
            ClassString = "Image";
            StyleString = "";
            A23ProductoImagen_IsBlob = (bool)((String.IsNullOrEmpty(StringUtil.RTrim( A23ProductoImagen))&&String.IsNullOrEmpty(StringUtil.RTrim( A40000ProductoImagen_GXI)))||!String.IsNullOrEmpty(StringUtil.RTrim( A23ProductoImagen)));
            sImgUrl = (String.IsNullOrEmpty(StringUtil.RTrim( A23ProductoImagen)) ? A40000ProductoImagen_GXI : context.PathToRelativeUrl( A23ProductoImagen));
            Grid1Row.AddColumnProperties("bitmap", 1, isAjaxCallMode( ), new Object[] {(string)edtProductoImagen_Internalname,(string)sImgUrl,(string)"",(string)"",(string)"",context.GetTheme( ),(short)-1,(short)0,(string)"",(string)"",(short)0,(short)-1,(short)0,(string)"px",(short)0,(string)"px",(short)0,(short)0,(short)0,(string)"",(string)"",(string)StyleString,(string)ClassString,(string)"WWColumn OptionalColumn",(string)"",(string)"",(string)"",(string)"",(string)"",(string)"",(short)1,(bool)A23ProductoImagen_IsBlob,(bool)true,context.GetImageSrcSet( sImgUrl)});
            send_integrity_lvl_hashes142( ) ;
            Grid1Container.AddRow(Grid1Row);
            nGXsfl_84_idx = ((subGrid1_Islastpage==1)&&(nGXsfl_84_idx+1>subGrid1_fnc_Recordsperpage( )) ? 1 : nGXsfl_84_idx+1);
            sGXsfl_84_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_84_idx), 4, 0), 4, "0");
            SubsflControlProps_842( ) ;
         }
         /* End function sendrow_842 */
      }

      protected void init_web_controls( )
      {
         /* End function init_web_controls */
      }

      protected void StartGridControl84( )
      {
         if ( Grid1Container.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<div id=\""+"Grid1Container"+"DivS\" data-gxgridid=\"84\">") ;
            sStyleString = "";
            GxWebStd.gx_table_start( context, subGrid1_Internalname, subGrid1_Internalname, "", "PromptGrid", 0, "", "", 1, 2, sStyleString, "", "", 0);
            /* Subfile titles */
            context.WriteHtmlText( "<tr") ;
            context.WriteHtmlTextNl( ">") ;
            if ( subGrid1_Backcolorstyle == 0 )
            {
               subGrid1_Titlebackstyle = 0;
               if ( StringUtil.Len( subGrid1_Class) > 0 )
               {
                  subGrid1_Linesclass = subGrid1_Class+"Title";
               }
            }
            else
            {
               subGrid1_Titlebackstyle = 1;
               if ( subGrid1_Backcolorstyle == 1 )
               {
                  subGrid1_Titlebackcolor = subGrid1_Allbackcolor;
                  if ( StringUtil.Len( subGrid1_Class) > 0 )
                  {
                     subGrid1_Linesclass = subGrid1_Class+"UniformTitle";
                  }
               }
               else
               {
                  if ( StringUtil.Len( subGrid1_Class) > 0 )
                  {
                     subGrid1_Linesclass = subGrid1_Class+"Title";
                  }
               }
            }
            context.WriteHtmlText( "<th align=\""+""+"\" "+" nowrap=\"nowrap\" "+" class=\""+"SelectionAttribute"+" "+((StringUtil.StrCmp(edtavLinkselection_gximage, "")==0) ? "" : "GX_Image_"+edtavLinkselection_gximage+"_Class")+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "ID") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"DescriptionAttribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "Nombre") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "Precio") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+""+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Image"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "Imagen") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlTextNl( "</tr>") ;
            Grid1Container.AddObjectProperty("GridName", "Grid1");
         }
         else
         {
            if ( isAjaxCallMode( ) )
            {
               Grid1Container = new GXWebGrid( context);
            }
            else
            {
               Grid1Container.Clear();
            }
            Grid1Container.SetWrapped(nGXWrapped);
            Grid1Container.AddObjectProperty("GridName", "Grid1");
            Grid1Container.AddObjectProperty("Header", subGrid1_Header);
            Grid1Container.AddObjectProperty("Class", "PromptGrid");
            Grid1Container.AddObjectProperty("Cellpadding", StringUtil.LTrim( StringUtil.NToC( (decimal)(1), 4, 0, ".", "")));
            Grid1Container.AddObjectProperty("Cellspacing", StringUtil.LTrim( StringUtil.NToC( (decimal)(2), 4, 0, ".", "")));
            Grid1Container.AddObjectProperty("Backcolorstyle", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid1_Backcolorstyle), 1, 0, ".", "")));
            Grid1Container.AddObjectProperty("CmpContext", "");
            Grid1Container.AddObjectProperty("InMasterPage", "false");
            Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Grid1Column.AddObjectProperty("Value", context.convertURL( AV5LinkSelection));
            Grid1Column.AddObjectProperty("Link", StringUtil.RTrim( edtavLinkselection_Link));
            Grid1Container.AddColumnProperties(Grid1Column);
            Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Grid1Column.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A19ProductoID), 6, 0, ".", ""))));
            Grid1Container.AddColumnProperties(Grid1Column);
            Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Grid1Column.AddObjectProperty("Value", GXUtil.ValueEncode( A20ProductoNombre));
            Grid1Column.AddObjectProperty("Link", StringUtil.RTrim( edtProductoNombre_Link));
            Grid1Container.AddColumnProperties(Grid1Column);
            Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Grid1Column.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( A22ProductoPrecio, 10, 2, ".", ""))));
            Grid1Container.AddColumnProperties(Grid1Column);
            Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Grid1Column.AddObjectProperty("Value", context.convertURL( A23ProductoImagen));
            Grid1Container.AddColumnProperties(Grid1Column);
            Grid1Container.AddObjectProperty("Selectedindex", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid1_Selectedindex), 4, 0, ".", "")));
            Grid1Container.AddObjectProperty("Allowselection", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid1_Allowselection), 1, 0, ".", "")));
            Grid1Container.AddObjectProperty("Selectioncolor", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid1_Selectioncolor), 9, 0, ".", "")));
            Grid1Container.AddObjectProperty("Allowhover", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid1_Allowhovering), 1, 0, ".", "")));
            Grid1Container.AddObjectProperty("Hovercolor", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid1_Hoveringcolor), 9, 0, ".", "")));
            Grid1Container.AddObjectProperty("Allowcollapsing", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid1_Allowcollapsing), 1, 0, ".", "")));
            Grid1Container.AddObjectProperty("Collapsed", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid1_Collapsed), 1, 0, ".", "")));
         }
      }

      protected void init_default_properties( )
      {
         lblLblproductoidfilter_Internalname = "LBLPRODUCTOIDFILTER";
         edtavCproductoid_Internalname = "vCPRODUCTOID";
         divProductoidfiltercontainer_Internalname = "PRODUCTOIDFILTERCONTAINER";
         lblLblproductonombrefilter_Internalname = "LBLPRODUCTONOMBREFILTER";
         edtavCproductonombre_Internalname = "vCPRODUCTONOMBRE";
         divProductonombrefiltercontainer_Internalname = "PRODUCTONOMBREFILTERCONTAINER";
         lblLblproductodescripcionfilter_Internalname = "LBLPRODUCTODESCRIPCIONFILTER";
         edtavCproductodescripcion_Internalname = "vCPRODUCTODESCRIPCION";
         divProductodescripcionfiltercontainer_Internalname = "PRODUCTODESCRIPCIONFILTERCONTAINER";
         lblLblproductopreciofilter_Internalname = "LBLPRODUCTOPRECIOFILTER";
         edtavCproductoprecio_Internalname = "vCPRODUCTOPRECIO";
         divProductopreciofiltercontainer_Internalname = "PRODUCTOPRECIOFILTERCONTAINER";
         lblLblvendedoridfilter_Internalname = "LBLVENDEDORIDFILTER";
         edtavCvendedorid_Internalname = "vCVENDEDORID";
         divVendedoridfiltercontainer_Internalname = "VENDEDORIDFILTERCONTAINER";
         lblLblcategoriaidfilter_Internalname = "LBLCATEGORIAIDFILTER";
         edtavCcategoriaid_Internalname = "vCCATEGORIAID";
         divCategoriaidfiltercontainer_Internalname = "CATEGORIAIDFILTERCONTAINER";
         lblLblproductopaisidfilter_Internalname = "LBLPRODUCTOPAISIDFILTER";
         edtavCproductopaisid_Internalname = "vCPRODUCTOPAISID";
         divProductopaisidfiltercontainer_Internalname = "PRODUCTOPAISIDFILTERCONTAINER";
         divAdvancedcontainer_Internalname = "ADVANCEDCONTAINER";
         bttBtntoggle_Internalname = "BTNTOGGLE";
         edtavLinkselection_Internalname = "vLINKSELECTION";
         edtProductoID_Internalname = "PRODUCTOID";
         edtProductoNombre_Internalname = "PRODUCTONOMBRE";
         edtProductoPrecio_Internalname = "PRODUCTOPRECIO";
         edtProductoImagen_Internalname = "PRODUCTOIMAGEN";
         bttBtn_cancel_Internalname = "BTN_CANCEL";
         divGridtable_Internalname = "GRIDTABLE";
         divMain_Internalname = "MAIN";
         Form.Internalname = "FORM";
         subGrid1_Internalname = "GRID1";
      }

      public override void initialize_properties( )
      {
         context.SetDefaultTheme("miTienda", true);
         if ( context.isSpaRequest( ) )
         {
            disableJsOutput();
         }
         init_default_properties( ) ;
         subGrid1_Allowcollapsing = 0;
         subGrid1_Allowselection = 0;
         subGrid1_Header = "";
         edtProductoPrecio_Jsonclick = "";
         edtProductoNombre_Jsonclick = "";
         edtProductoNombre_Link = "";
         edtProductoID_Jsonclick = "";
         edtavLinkselection_gximage = "";
         edtavLinkselection_Link = "";
         subGrid1_Class = "PromptGrid";
         subGrid1_Backcolorstyle = 0;
         edtProductoImagen_Enabled = 0;
         edtProductoPrecio_Enabled = 0;
         edtProductoNombre_Enabled = 0;
         edtProductoID_Enabled = 0;
         edtavCproductopaisid_Jsonclick = "";
         edtavCproductopaisid_Enabled = 1;
         edtavCproductopaisid_Visible = 1;
         edtavCcategoriaid_Jsonclick = "";
         edtavCcategoriaid_Enabled = 1;
         edtavCcategoriaid_Visible = 1;
         edtavCvendedorid_Jsonclick = "";
         edtavCvendedorid_Enabled = 1;
         edtavCvendedorid_Visible = 1;
         edtavCproductoprecio_Jsonclick = "";
         edtavCproductoprecio_Enabled = 1;
         edtavCproductoprecio_Visible = 1;
         edtavCproductodescripcion_Jsonclick = "";
         edtavCproductodescripcion_Enabled = 1;
         edtavCproductodescripcion_Visible = 1;
         edtavCproductonombre_Jsonclick = "";
         edtavCproductonombre_Enabled = 1;
         edtavCproductonombre_Visible = 1;
         edtavCproductoid_Jsonclick = "";
         edtavCproductoid_Enabled = 1;
         edtavCproductoid_Visible = 1;
         divProductopaisidfiltercontainer_Class = "AdvancedContainerItem AdvancedContainerItemExpanded";
         divCategoriaidfiltercontainer_Class = "AdvancedContainerItem AdvancedContainerItemExpanded";
         divVendedoridfiltercontainer_Class = "AdvancedContainerItem AdvancedContainerItemExpanded";
         divProductopreciofiltercontainer_Class = "AdvancedContainerItem AdvancedContainerItemExpanded";
         divProductodescripcionfiltercontainer_Class = "AdvancedContainerItem AdvancedContainerItemExpanded";
         divProductonombrefiltercontainer_Class = "AdvancedContainerItem AdvancedContainerItemExpanded";
         divProductoidfiltercontainer_Class = "AdvancedContainerItem AdvancedContainerItemExpanded";
         bttBtntoggle_Class = "BtnToggle";
         divAdvancedcontainer_Class = "AdvancedContainerVisible";
         Form.Headerrawhtml = "";
         Form.Background = "";
         Form.Textcolor = 0;
         Form.Backcolor = (int)(0xFFFFFF);
         Form.Caption = "Selection List Producto";
         subGrid1_Rows = 10;
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
         setEventMetadata("REFRESH","""{"handler":"Refresh","iparms":[{"av":"GRID1_nFirstRecordOnPage"},{"av":"GRID1_nEOF"},{"av":"subGrid1_Rows","ctrl":"GRID1","prop":"Rows"},{"av":"AV6cProductoID","fld":"vCPRODUCTOID","pic":"ZZZZZ9"},{"av":"AV7cProductoNombre","fld":"vCPRODUCTONOMBRE"},{"av":"AV8cProductoDescripcion","fld":"vCPRODUCTODESCRIPCION"},{"av":"AV9cProductoPrecio","fld":"vCPRODUCTOPRECIO","pic":"ZZZZZZ9.99"},{"av":"AV10cVendedorID","fld":"vCVENDEDORID","pic":"ZZZZZ9"},{"av":"AV11cCategoriaID","fld":"vCCATEGORIAID","pic":"ZZZZZ9"},{"av":"AV12cProductoPaisID","fld":"vCPRODUCTOPAISID","pic":"ZZZZZ9"}]}""");
         setEventMetadata("'TOGGLE'","""{"handler":"E18141","iparms":[{"av":"divAdvancedcontainer_Class","ctrl":"ADVANCEDCONTAINER","prop":"Class"},{"ctrl":"BTNTOGGLE","prop":"Class"}]""");
         setEventMetadata("'TOGGLE'",""","oparms":[{"av":"divAdvancedcontainer_Class","ctrl":"ADVANCEDCONTAINER","prop":"Class"},{"ctrl":"BTNTOGGLE","prop":"Class"}]}""");
         setEventMetadata("LBLPRODUCTOIDFILTER.CLICK","""{"handler":"E11141","iparms":[{"av":"divProductoidfiltercontainer_Class","ctrl":"PRODUCTOIDFILTERCONTAINER","prop":"Class"}]""");
         setEventMetadata("LBLPRODUCTOIDFILTER.CLICK",""","oparms":[{"av":"divProductoidfiltercontainer_Class","ctrl":"PRODUCTOIDFILTERCONTAINER","prop":"Class"},{"av":"edtavCproductoid_Visible","ctrl":"vCPRODUCTOID","prop":"Visible"}]}""");
         setEventMetadata("LBLPRODUCTONOMBREFILTER.CLICK","""{"handler":"E12141","iparms":[{"av":"divProductonombrefiltercontainer_Class","ctrl":"PRODUCTONOMBREFILTERCONTAINER","prop":"Class"}]""");
         setEventMetadata("LBLPRODUCTONOMBREFILTER.CLICK",""","oparms":[{"av":"divProductonombrefiltercontainer_Class","ctrl":"PRODUCTONOMBREFILTERCONTAINER","prop":"Class"},{"av":"edtavCproductonombre_Visible","ctrl":"vCPRODUCTONOMBRE","prop":"Visible"}]}""");
         setEventMetadata("LBLPRODUCTODESCRIPCIONFILTER.CLICK","""{"handler":"E13141","iparms":[{"av":"divProductodescripcionfiltercontainer_Class","ctrl":"PRODUCTODESCRIPCIONFILTERCONTAINER","prop":"Class"}]""");
         setEventMetadata("LBLPRODUCTODESCRIPCIONFILTER.CLICK",""","oparms":[{"av":"divProductodescripcionfiltercontainer_Class","ctrl":"PRODUCTODESCRIPCIONFILTERCONTAINER","prop":"Class"},{"av":"edtavCproductodescripcion_Visible","ctrl":"vCPRODUCTODESCRIPCION","prop":"Visible"}]}""");
         setEventMetadata("LBLPRODUCTOPRECIOFILTER.CLICK","""{"handler":"E14141","iparms":[{"av":"divProductopreciofiltercontainer_Class","ctrl":"PRODUCTOPRECIOFILTERCONTAINER","prop":"Class"}]""");
         setEventMetadata("LBLPRODUCTOPRECIOFILTER.CLICK",""","oparms":[{"av":"divProductopreciofiltercontainer_Class","ctrl":"PRODUCTOPRECIOFILTERCONTAINER","prop":"Class"},{"av":"edtavCproductoprecio_Visible","ctrl":"vCPRODUCTOPRECIO","prop":"Visible"}]}""");
         setEventMetadata("LBLVENDEDORIDFILTER.CLICK","""{"handler":"E15141","iparms":[{"av":"divVendedoridfiltercontainer_Class","ctrl":"VENDEDORIDFILTERCONTAINER","prop":"Class"}]""");
         setEventMetadata("LBLVENDEDORIDFILTER.CLICK",""","oparms":[{"av":"divVendedoridfiltercontainer_Class","ctrl":"VENDEDORIDFILTERCONTAINER","prop":"Class"},{"av":"edtavCvendedorid_Visible","ctrl":"vCVENDEDORID","prop":"Visible"}]}""");
         setEventMetadata("LBLCATEGORIAIDFILTER.CLICK","""{"handler":"E16141","iparms":[{"av":"divCategoriaidfiltercontainer_Class","ctrl":"CATEGORIAIDFILTERCONTAINER","prop":"Class"}]""");
         setEventMetadata("LBLCATEGORIAIDFILTER.CLICK",""","oparms":[{"av":"divCategoriaidfiltercontainer_Class","ctrl":"CATEGORIAIDFILTERCONTAINER","prop":"Class"},{"av":"edtavCcategoriaid_Visible","ctrl":"vCCATEGORIAID","prop":"Visible"}]}""");
         setEventMetadata("LBLPRODUCTOPAISIDFILTER.CLICK","""{"handler":"E17141","iparms":[{"av":"divProductopaisidfiltercontainer_Class","ctrl":"PRODUCTOPAISIDFILTERCONTAINER","prop":"Class"}]""");
         setEventMetadata("LBLPRODUCTOPAISIDFILTER.CLICK",""","oparms":[{"av":"divProductopaisidfiltercontainer_Class","ctrl":"PRODUCTOPAISIDFILTERCONTAINER","prop":"Class"},{"av":"edtavCproductopaisid_Visible","ctrl":"vCPRODUCTOPAISID","prop":"Visible"}]}""");
         setEventMetadata("ENTER","""{"handler":"E21142","iparms":[{"av":"A19ProductoID","fld":"PRODUCTOID","pic":"ZZZZZ9","hsh":true}]""");
         setEventMetadata("ENTER",""","oparms":[{"av":"AV13pProductoID","fld":"vPPRODUCTOID","pic":"ZZZZZ9"}]}""");
         setEventMetadata("GRID1_FIRSTPAGE","""{"handler":"subgrid1_firstpage","iparms":[{"av":"GRID1_nFirstRecordOnPage"},{"av":"GRID1_nEOF"},{"av":"subGrid1_Rows","ctrl":"GRID1","prop":"Rows"},{"av":"AV6cProductoID","fld":"vCPRODUCTOID","pic":"ZZZZZ9"},{"av":"AV7cProductoNombre","fld":"vCPRODUCTONOMBRE"},{"av":"AV8cProductoDescripcion","fld":"vCPRODUCTODESCRIPCION"},{"av":"AV9cProductoPrecio","fld":"vCPRODUCTOPRECIO","pic":"ZZZZZZ9.99"},{"av":"AV10cVendedorID","fld":"vCVENDEDORID","pic":"ZZZZZ9"},{"av":"AV11cCategoriaID","fld":"vCCATEGORIAID","pic":"ZZZZZ9"},{"av":"AV12cProductoPaisID","fld":"vCPRODUCTOPAISID","pic":"ZZZZZ9"}]}""");
         setEventMetadata("GRID1_PREVPAGE","""{"handler":"subgrid1_previouspage","iparms":[{"av":"GRID1_nFirstRecordOnPage"},{"av":"GRID1_nEOF"},{"av":"subGrid1_Rows","ctrl":"GRID1","prop":"Rows"},{"av":"AV6cProductoID","fld":"vCPRODUCTOID","pic":"ZZZZZ9"},{"av":"AV7cProductoNombre","fld":"vCPRODUCTONOMBRE"},{"av":"AV8cProductoDescripcion","fld":"vCPRODUCTODESCRIPCION"},{"av":"AV9cProductoPrecio","fld":"vCPRODUCTOPRECIO","pic":"ZZZZZZ9.99"},{"av":"AV10cVendedorID","fld":"vCVENDEDORID","pic":"ZZZZZ9"},{"av":"AV11cCategoriaID","fld":"vCCATEGORIAID","pic":"ZZZZZ9"},{"av":"AV12cProductoPaisID","fld":"vCPRODUCTOPAISID","pic":"ZZZZZ9"}]}""");
         setEventMetadata("GRID1_NEXTPAGE","""{"handler":"subgrid1_nextpage","iparms":[{"av":"GRID1_nFirstRecordOnPage"},{"av":"GRID1_nEOF"},{"av":"subGrid1_Rows","ctrl":"GRID1","prop":"Rows"},{"av":"AV6cProductoID","fld":"vCPRODUCTOID","pic":"ZZZZZ9"},{"av":"AV7cProductoNombre","fld":"vCPRODUCTONOMBRE"},{"av":"AV8cProductoDescripcion","fld":"vCPRODUCTODESCRIPCION"},{"av":"AV9cProductoPrecio","fld":"vCPRODUCTOPRECIO","pic":"ZZZZZZ9.99"},{"av":"AV10cVendedorID","fld":"vCVENDEDORID","pic":"ZZZZZ9"},{"av":"AV11cCategoriaID","fld":"vCCATEGORIAID","pic":"ZZZZZ9"},{"av":"AV12cProductoPaisID","fld":"vCPRODUCTOPAISID","pic":"ZZZZZ9"}]}""");
         setEventMetadata("GRID1_LASTPAGE","""{"handler":"subgrid1_lastpage","iparms":[{"av":"GRID1_nFirstRecordOnPage"},{"av":"GRID1_nEOF"},{"av":"subGrid1_Rows","ctrl":"GRID1","prop":"Rows"},{"av":"AV6cProductoID","fld":"vCPRODUCTOID","pic":"ZZZZZ9"},{"av":"AV7cProductoNombre","fld":"vCPRODUCTONOMBRE"},{"av":"AV8cProductoDescripcion","fld":"vCPRODUCTODESCRIPCION"},{"av":"AV9cProductoPrecio","fld":"vCPRODUCTOPRECIO","pic":"ZZZZZZ9.99"},{"av":"AV10cVendedorID","fld":"vCVENDEDORID","pic":"ZZZZZ9"},{"av":"AV11cCategoriaID","fld":"vCCATEGORIAID","pic":"ZZZZZ9"},{"av":"AV12cProductoPaisID","fld":"vCPRODUCTOPAISID","pic":"ZZZZZ9"}]}""");
         setEventMetadata("NULL","""{"handler":"Valid_Productoimagen","iparms":[]}""");
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
         AV13pProductoID = 1;
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         AV6cProductoID = 1;
         AV7cProductoNombre = "";
         AV8cProductoDescripcion = "";
         AV10cVendedorID = 1;
         AV11cCategoriaID = 1;
         AV12cProductoPaisID = 1;
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXKey = "";
         GX_FocusControl = "";
         Form = new GXWebForm();
         sPrefix = "";
         lblLblproductoidfilter_Jsonclick = "";
         TempTags = "";
         lblLblproductonombrefilter_Jsonclick = "";
         lblLblproductodescripcionfilter_Jsonclick = "";
         lblLblproductopreciofilter_Jsonclick = "";
         lblLblvendedoridfilter_Jsonclick = "";
         lblLblcategoriaidfilter_Jsonclick = "";
         lblLblproductopaisidfilter_Jsonclick = "";
         ClassString = "";
         StyleString = "";
         bttBtntoggle_Jsonclick = "";
         Grid1Container = new GXWebGrid( context);
         sStyleString = "";
         bttBtn_cancel_Jsonclick = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         AV5LinkSelection = "";
         AV15Linkselection_GXI = "";
         A20ProductoNombre = "";
         A23ProductoImagen = "";
         A40000ProductoImagen_GXI = "";
         lV7cProductoNombre = "";
         lV8cProductoDescripcion = "";
         A21ProductoDescripcion = "";
         H00142_A26ProductoPaisID = new int[1] ;
         H00142_A4CategoriaID = new int[1] ;
         H00142_A6VendedorID = new int[1] ;
         H00142_A21ProductoDescripcion = new string[] {""} ;
         H00142_A40000ProductoImagen_GXI = new string[] {""} ;
         H00142_A22ProductoPrecio = new decimal[1] ;
         H00142_A20ProductoNombre = new string[] {""} ;
         H00142_A19ProductoID = new int[1] ;
         H00142_A23ProductoImagen = new string[] {""} ;
         H00143_AGRID1_nRecordCount = new long[1] ;
         AV14ADVANCED_LABEL_TEMPLATE = "";
         Grid1Row = new GXWebRow();
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         subGrid1_Linesclass = "";
         sImgUrl = "";
         ROClassString = "";
         Grid1Column = new GXWebColumn();
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.gx0070__default(),
            new Object[][] {
                new Object[] {
               H00142_A26ProductoPaisID, H00142_A4CategoriaID, H00142_A6VendedorID, H00142_A21ProductoDescripcion, H00142_A40000ProductoImagen_GXI, H00142_A22ProductoPrecio, H00142_A20ProductoNombre, H00142_A19ProductoID, H00142_A23ProductoImagen
               }
               , new Object[] {
               H00143_AGRID1_nRecordCount
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short GRID1_nEOF ;
      private short nGotPars ;
      private short GxWebError ;
      private short gxajaxcallmode ;
      private short wbEnd ;
      private short wbStart ;
      private short nDonePA ;
      private short gxcookieaux ;
      private short subGrid1_Backcolorstyle ;
      private short nGXWrapped ;
      private short subGrid1_Backstyle ;
      private short subGrid1_Titlebackstyle ;
      private short subGrid1_Allowselection ;
      private short subGrid1_Allowhovering ;
      private short subGrid1_Allowcollapsing ;
      private short subGrid1_Collapsed ;
      private int AV13pProductoID ;
      private int nRC_GXsfl_84 ;
      private int subGrid1_Rows ;
      private int nGXsfl_84_idx=1 ;
      private int AV6cProductoID ;
      private int AV10cVendedorID ;
      private int AV11cCategoriaID ;
      private int AV12cProductoPaisID ;
      private int edtavCproductoid_Enabled ;
      private int edtavCproductoid_Visible ;
      private int edtavCproductonombre_Visible ;
      private int edtavCproductonombre_Enabled ;
      private int edtavCproductodescripcion_Visible ;
      private int edtavCproductodescripcion_Enabled ;
      private int edtavCproductoprecio_Enabled ;
      private int edtavCproductoprecio_Visible ;
      private int edtavCvendedorid_Enabled ;
      private int edtavCvendedorid_Visible ;
      private int edtavCcategoriaid_Enabled ;
      private int edtavCcategoriaid_Visible ;
      private int edtavCproductopaisid_Enabled ;
      private int edtavCproductopaisid_Visible ;
      private int A19ProductoID ;
      private int subGrid1_Islastpage ;
      private int GXPagingFrom2 ;
      private int GXPagingTo2 ;
      private int A6VendedorID ;
      private int A4CategoriaID ;
      private int A26ProductoPaisID ;
      private int edtProductoID_Enabled ;
      private int edtProductoNombre_Enabled ;
      private int edtProductoPrecio_Enabled ;
      private int edtProductoImagen_Enabled ;
      private int idxLst ;
      private int subGrid1_Backcolor ;
      private int subGrid1_Allbackcolor ;
      private int subGrid1_Titlebackcolor ;
      private int subGrid1_Selectedindex ;
      private int subGrid1_Selectioncolor ;
      private int subGrid1_Hoveringcolor ;
      private long GRID1_nFirstRecordOnPage ;
      private long GRID1_nCurrentRecord ;
      private long GRID1_nRecordCount ;
      private decimal AV9cProductoPrecio ;
      private decimal A22ProductoPrecio ;
      private string divAdvancedcontainer_Class ;
      private string bttBtntoggle_Class ;
      private string divProductoidfiltercontainer_Class ;
      private string divProductonombrefiltercontainer_Class ;
      private string divProductodescripcionfiltercontainer_Class ;
      private string divProductopreciofiltercontainer_Class ;
      private string divVendedoridfiltercontainer_Class ;
      private string divCategoriaidfiltercontainer_Class ;
      private string divProductopaisidfiltercontainer_Class ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string sGXsfl_84_idx="0001" ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string GXKey ;
      private string GX_FocusControl ;
      private string sPrefix ;
      private string divMain_Internalname ;
      private string divAdvancedcontainer_Internalname ;
      private string divProductoidfiltercontainer_Internalname ;
      private string lblLblproductoidfilter_Internalname ;
      private string lblLblproductoidfilter_Jsonclick ;
      private string edtavCproductoid_Internalname ;
      private string TempTags ;
      private string edtavCproductoid_Jsonclick ;
      private string divProductonombrefiltercontainer_Internalname ;
      private string lblLblproductonombrefilter_Internalname ;
      private string lblLblproductonombrefilter_Jsonclick ;
      private string edtavCproductonombre_Internalname ;
      private string edtavCproductonombre_Jsonclick ;
      private string divProductodescripcionfiltercontainer_Internalname ;
      private string lblLblproductodescripcionfilter_Internalname ;
      private string lblLblproductodescripcionfilter_Jsonclick ;
      private string edtavCproductodescripcion_Internalname ;
      private string edtavCproductodescripcion_Jsonclick ;
      private string divProductopreciofiltercontainer_Internalname ;
      private string lblLblproductopreciofilter_Internalname ;
      private string lblLblproductopreciofilter_Jsonclick ;
      private string edtavCproductoprecio_Internalname ;
      private string edtavCproductoprecio_Jsonclick ;
      private string divVendedoridfiltercontainer_Internalname ;
      private string lblLblvendedoridfilter_Internalname ;
      private string lblLblvendedoridfilter_Jsonclick ;
      private string edtavCvendedorid_Internalname ;
      private string edtavCvendedorid_Jsonclick ;
      private string divCategoriaidfiltercontainer_Internalname ;
      private string lblLblcategoriaidfilter_Internalname ;
      private string lblLblcategoriaidfilter_Jsonclick ;
      private string edtavCcategoriaid_Internalname ;
      private string edtavCcategoriaid_Jsonclick ;
      private string divProductopaisidfiltercontainer_Internalname ;
      private string lblLblproductopaisidfilter_Internalname ;
      private string lblLblproductopaisidfilter_Jsonclick ;
      private string edtavCproductopaisid_Internalname ;
      private string edtavCproductopaisid_Jsonclick ;
      private string divGridtable_Internalname ;
      private string ClassString ;
      private string StyleString ;
      private string bttBtntoggle_Internalname ;
      private string bttBtntoggle_Jsonclick ;
      private string sStyleString ;
      private string subGrid1_Internalname ;
      private string bttBtn_cancel_Internalname ;
      private string bttBtn_cancel_Jsonclick ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string edtavLinkselection_Internalname ;
      private string edtProductoID_Internalname ;
      private string edtProductoNombre_Internalname ;
      private string edtProductoPrecio_Internalname ;
      private string edtProductoImagen_Internalname ;
      private string AV14ADVANCED_LABEL_TEMPLATE ;
      private string edtavLinkselection_gximage ;
      private string sGXsfl_84_fel_idx="0001" ;
      private string subGrid1_Class ;
      private string subGrid1_Linesclass ;
      private string edtavLinkselection_Link ;
      private string sImgUrl ;
      private string ROClassString ;
      private string edtProductoID_Jsonclick ;
      private string edtProductoNombre_Link ;
      private string edtProductoNombre_Jsonclick ;
      private string edtProductoPrecio_Jsonclick ;
      private string subGrid1_Header ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool wbLoad ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool bGXsfl_84_Refreshing=false ;
      private bool gxdyncontrolsrefreshing ;
      private bool returnInSub ;
      private bool AV5LinkSelection_IsBlob ;
      private bool A23ProductoImagen_IsBlob ;
      private string AV7cProductoNombre ;
      private string AV8cProductoDescripcion ;
      private string AV15Linkselection_GXI ;
      private string A20ProductoNombre ;
      private string A40000ProductoImagen_GXI ;
      private string lV7cProductoNombre ;
      private string lV8cProductoDescripcion ;
      private string A21ProductoDescripcion ;
      private string AV5LinkSelection ;
      private string A23ProductoImagen ;
      private GXWebGrid Grid1Container ;
      private GXWebRow Grid1Row ;
      private GXWebColumn Grid1Column ;
      private GXWebForm Form ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private int[] H00142_A26ProductoPaisID ;
      private int[] H00142_A4CategoriaID ;
      private int[] H00142_A6VendedorID ;
      private string[] H00142_A21ProductoDescripcion ;
      private string[] H00142_A40000ProductoImagen_GXI ;
      private decimal[] H00142_A22ProductoPrecio ;
      private string[] H00142_A20ProductoNombre ;
      private int[] H00142_A19ProductoID ;
      private string[] H00142_A23ProductoImagen ;
      private long[] H00143_AGRID1_nRecordCount ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private int aP0_pProductoID ;
   }

   public class gx0070__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_H00142( IGxContext context ,
                                             string AV7cProductoNombre ,
                                             string AV8cProductoDescripcion ,
                                             decimal AV9cProductoPrecio ,
                                             int AV10cVendedorID ,
                                             int AV11cCategoriaID ,
                                             int AV12cProductoPaisID ,
                                             string A20ProductoNombre ,
                                             string A21ProductoDescripcion ,
                                             decimal A22ProductoPrecio ,
                                             int A6VendedorID ,
                                             int A4CategoriaID ,
                                             int A26ProductoPaisID ,
                                             int AV6cProductoID )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int1 = new short[10];
         Object[] GXv_Object2 = new Object[2];
         string sSelectString;
         string sFromString;
         string sOrderString;
         sSelectString = " [ProductoPaisID], [CategoriaID], [VendedorID], [ProductoDescripcion], [ProductoImagen_GXI], [ProductoPrecio], [ProductoNombre], [ProductoID], [ProductoImagen]";
         sFromString = " FROM [Producto]";
         sOrderString = "";
         AddWhere(sWhereString, "([ProductoID] >= @AV6cProductoID)");
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV7cProductoNombre)) )
         {
            AddWhere(sWhereString, "([ProductoNombre] like @lV7cProductoNombre)");
         }
         else
         {
            GXv_int1[1] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV8cProductoDescripcion)) )
         {
            AddWhere(sWhereString, "([ProductoDescripcion] like @lV8cProductoDescripcion)");
         }
         else
         {
            GXv_int1[2] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV9cProductoPrecio) )
         {
            AddWhere(sWhereString, "([ProductoPrecio] >= @AV9cProductoPrecio)");
         }
         else
         {
            GXv_int1[3] = 1;
         }
         if ( ! (0==AV10cVendedorID) )
         {
            AddWhere(sWhereString, "([VendedorID] >= @AV10cVendedorID)");
         }
         else
         {
            GXv_int1[4] = 1;
         }
         if ( ! (0==AV11cCategoriaID) )
         {
            AddWhere(sWhereString, "([CategoriaID] >= @AV11cCategoriaID)");
         }
         else
         {
            GXv_int1[5] = 1;
         }
         if ( ! (0==AV12cProductoPaisID) )
         {
            AddWhere(sWhereString, "([ProductoPaisID] >= @AV12cProductoPaisID)");
         }
         else
         {
            GXv_int1[6] = 1;
         }
         sOrderString += " ORDER BY [ProductoID]";
         scmdbuf = "SELECT " + sSelectString + sFromString + sWhereString + sOrderString + "" + " OFFSET " + "@GXPagingFrom2" + " ROWS FETCH NEXT CAST((SELECT CASE WHEN " + "@GXPagingTo2" + " > 0 THEN " + "@GXPagingTo2" + " ELSE 1e9 END) AS INTEGER) ROWS ONLY";
         GXv_Object2[0] = scmdbuf;
         GXv_Object2[1] = GXv_int1;
         return GXv_Object2 ;
      }

      protected Object[] conditional_H00143( IGxContext context ,
                                             string AV7cProductoNombre ,
                                             string AV8cProductoDescripcion ,
                                             decimal AV9cProductoPrecio ,
                                             int AV10cVendedorID ,
                                             int AV11cCategoriaID ,
                                             int AV12cProductoPaisID ,
                                             string A20ProductoNombre ,
                                             string A21ProductoDescripcion ,
                                             decimal A22ProductoPrecio ,
                                             int A6VendedorID ,
                                             int A4CategoriaID ,
                                             int A26ProductoPaisID ,
                                             int AV6cProductoID )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int3 = new short[7];
         Object[] GXv_Object4 = new Object[2];
         scmdbuf = "SELECT COUNT(*) FROM [Producto]";
         AddWhere(sWhereString, "([ProductoID] >= @AV6cProductoID)");
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV7cProductoNombre)) )
         {
            AddWhere(sWhereString, "([ProductoNombre] like @lV7cProductoNombre)");
         }
         else
         {
            GXv_int3[1] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV8cProductoDescripcion)) )
         {
            AddWhere(sWhereString, "([ProductoDescripcion] like @lV8cProductoDescripcion)");
         }
         else
         {
            GXv_int3[2] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV9cProductoPrecio) )
         {
            AddWhere(sWhereString, "([ProductoPrecio] >= @AV9cProductoPrecio)");
         }
         else
         {
            GXv_int3[3] = 1;
         }
         if ( ! (0==AV10cVendedorID) )
         {
            AddWhere(sWhereString, "([VendedorID] >= @AV10cVendedorID)");
         }
         else
         {
            GXv_int3[4] = 1;
         }
         if ( ! (0==AV11cCategoriaID) )
         {
            AddWhere(sWhereString, "([CategoriaID] >= @AV11cCategoriaID)");
         }
         else
         {
            GXv_int3[5] = 1;
         }
         if ( ! (0==AV12cProductoPaisID) )
         {
            AddWhere(sWhereString, "([ProductoPaisID] >= @AV12cProductoPaisID)");
         }
         else
         {
            GXv_int3[6] = 1;
         }
         scmdbuf += sWhereString;
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
                     return conditional_H00142(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (decimal)dynConstraints[2] , (int)dynConstraints[3] , (int)dynConstraints[4] , (int)dynConstraints[5] , (string)dynConstraints[6] , (string)dynConstraints[7] , (decimal)dynConstraints[8] , (int)dynConstraints[9] , (int)dynConstraints[10] , (int)dynConstraints[11] , (int)dynConstraints[12] );
               case 1 :
                     return conditional_H00143(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (decimal)dynConstraints[2] , (int)dynConstraints[3] , (int)dynConstraints[4] , (int)dynConstraints[5] , (string)dynConstraints[6] , (string)dynConstraints[7] , (decimal)dynConstraints[8] , (int)dynConstraints[9] , (int)dynConstraints[10] , (int)dynConstraints[11] , (int)dynConstraints[12] );
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
          Object[] prmH00142;
          prmH00142 = new Object[] {
          new ParDef("@AV6cProductoID",GXType.Int32,6,0) ,
          new ParDef("@lV7cProductoNombre",GXType.NVarChar,80,0) ,
          new ParDef("@lV8cProductoDescripcion",GXType.NVarChar,80,0) ,
          new ParDef("@AV9cProductoPrecio",GXType.Decimal,10,2) ,
          new ParDef("@AV10cVendedorID",GXType.Int32,6,0) ,
          new ParDef("@AV11cCategoriaID",GXType.Int32,6,0) ,
          new ParDef("@AV12cProductoPaisID",GXType.Int32,6,0) ,
          new ParDef("@GXPagingFrom2",GXType.Int32,9,0) ,
          new ParDef("@GXPagingTo2",GXType.Int32,9,0) ,
          new ParDef("@GXPagingTo2",GXType.Int32,9,0)
          };
          Object[] prmH00143;
          prmH00143 = new Object[] {
          new ParDef("@AV6cProductoID",GXType.Int32,6,0) ,
          new ParDef("@lV7cProductoNombre",GXType.NVarChar,80,0) ,
          new ParDef("@lV8cProductoDescripcion",GXType.NVarChar,80,0) ,
          new ParDef("@AV9cProductoPrecio",GXType.Decimal,10,2) ,
          new ParDef("@AV10cVendedorID",GXType.Int32,6,0) ,
          new ParDef("@AV11cCategoriaID",GXType.Int32,6,0) ,
          new ParDef("@AV12cProductoPaisID",GXType.Int32,6,0)
          };
          def= new CursorDef[] {
              new CursorDef("H00142", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH00142,11, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("H00143", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH00143,1, GxCacheFrequency.OFF ,false,false )
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
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((int[]) buf[1])[0] = rslt.getInt(2);
                ((int[]) buf[2])[0] = rslt.getInt(3);
                ((string[]) buf[3])[0] = rslt.getVarchar(4);
                ((string[]) buf[4])[0] = rslt.getMultimediaUri(5);
                ((decimal[]) buf[5])[0] = rslt.getDecimal(6);
                ((string[]) buf[6])[0] = rslt.getVarchar(7);
                ((int[]) buf[7])[0] = rslt.getInt(8);
                ((string[]) buf[8])[0] = rslt.getMultimediaFile(9, rslt.getVarchar(5));
                return;
             case 1 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                return;
       }
    }

 }

}
