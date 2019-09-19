<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Article.aspx.cs" Inherits="CreateArticle.Article" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
   <script type="text/javascript">
       function DisableButton() {
           document.getElementById("<%=btnCreateArt.ClientID %>").disabled = true;
       }
       window.onbeforeunload = DisableButton;
</script> 
    <style type="text/css">
        .style1
        {
            width: 100%;
        }
        .style8
        {
            width: 127px;
            height: 21px;
            text-align: center;
        }
        .style11
        {
            width: 124px;
        }
        .style17
        {
            width: 300px;
            text-align: left;
        }
        .style18
        {
            font-size: small;
        }
        .style19
        {
            font-size: small;
        }
        .style20
        {
            font-size: medium;
            color: #000000;
        }
        .style21
        {
            color: #000000;
        }
        #I1
        {
            height: 381px;
            width: 360px;
            float: right;
        }
        .style22
        {
            height: 21px;
            width: 285px;
        }
        .style23
        {
            width: 189px;
        }
        .style24
        {
            width: 264px;
            height: 21px;
        }
        .style25
        {
            width: 228px;
        }
        .style26
        {
            height: 21px;
            width: 250px;
        }
        .style27
        {
            width: 285px;
        }
        .style28
        {
            width: 264px;
        }
        .style29
        {
            width: 250px;
        }
        .style30
        {
            font-size: small;
            font-weight: bold;
            text-align:center;
        }
        .style31
        {
            font-size: small;
            font-weight: bold;
            text-align:center;
        }
        .style32
        {
            width: 190px;
        }
        .style33
        {
            width: 190px;
            height: 21px;
        }
        </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
<asp:ScriptManager ID="ScriptManager1" runat="server" 
EnablePageMethods = "true">
</asp:ScriptManager>
    <center>
        <asp:Label ID="Label1" runat="server" 
        style="font-weight: 700; font-size: xx-large; color: #0033CC; text-align: center" 
        Text="Article"></asp:Label>
        <br /><br />
        <asp:Panel ID="Panel1" runat="server" style="text-align: center">
            <asp:Label ID="Label2" runat="server" Text="Customer code" 
                style="font-weight: 700" CssClass="style19"></asp:Label>
            &nbsp;
            <asp:TextBox ID="TextBox1" runat="server" 
                style="font-weight: 700; text-align:center;" CssClass="style19" Height="20px" class="autosuggest" ></asp:TextBox>
                <cc1:AutoCompleteExtender ServiceMethod="SearchCustomers" 
    MinimumPrefixLength="2"
    CompletionInterval="100" EnableCaching="false" CompletionSetCount="10" 
    TargetControlID="TextBox1"
    ID="AutoCompleteExtender1" runat="server" FirstRowSelected = "false">
</cc1:AutoCompleteExtender>
                <!--<input type="text" id="TextBox1" name="CustCode" style="font-weight: 700; text-align:center;" CssClass="style19" Height="20px" class="autosuggest" OnClientClick=" btnSearch_Click()"/>-->
            &nbsp;
            <asp:Button ID="btnSearch" runat="server" style="font-weight: 700" 
                Text="Search" CssClass="style19" Height="25px" onclick="btnSearch_Click" />
            &nbsp;
            <asp:Label ID="Label3" runat="server" style="font-weight: 700" 
                Text="Customer Name" CssClass="style19"></asp:Label>
            &nbsp;
            <asp:TextBox ID="TextBox2" runat="server" 
                style="font-weight: 700; text-align:center;" CssClass="style19" 
                Height="20px" Enabled="False"></asp:TextBox>
            &nbsp;
            <asp:Label ID="Label4" runat="server" style="font-weight: 700" 
                Text="Last Article" CssClass="style19"></asp:Label>
            &nbsp;
            <asp:TextBox ID="TextBox3" runat="server" 
                style="font-weight: 700; text-align:center;" CssClass="style19" 
                Height="20px" Enabled="False"></asp:TextBox>
        </asp:Panel>
        <br />
        <br />
        <asp:Button ID="btnModifyArticle" runat="server" style="font-weight: 700" 
            Text="Modify Article" Height="25px" onclick="btnModifyArticle_Click" />
&nbsp;
        <asp:Button ID="btnCreateNArticle" runat="server" style="font-weight: 700" 
            Text="Create New Article" Height="25px" 
            onclick="btnCreateNArticle_Click" />
        <br />
        <br />
        <asp:Panel ID="Panel2" runat="server" style="text-align: center" DefaultButton="btnSearchArticle">
            <asp:Panel ID="PnlModifyArticle" runat="server" Direction="LeftToRight">
                &nbsp;&nbsp;&nbsp;&nbsp;
                <table align="center" class="style1">
                    <tr>
                        <td class="style32">
                            <br />
                            <asp:TextBox ID="TextBox11" runat="server" Enabled="False" 
                                style="text-align: center" CssClass="style18" Height="20px">Search By :</asp:TextBox>
                            <br />
                            <br />
                        </td>
                        <td class="style11">
                            <asp:Label ID="Label12" runat="server" CssClass="style21" 
                                style="text-align: center; font-size: medium;" Text="Article No."></asp:Label>
                            <br />
                            <asp:TextBox ID="TextBox4" runat="server" CssClass="style30" Height="20px"></asp:TextBox>
                             <cc1:AutoCompleteExtender ServiceMethod="SearchArticles" 
                            MinimumPrefixLength="2"
                            CompletionInterval="100" EnableCaching="false" CompletionSetCount="10" 
                            TargetControlID="TextBox4"
                            ID="AutoCompleteExtender2" runat="server" FirstRowSelected = "false">
                        </cc1:AutoCompleteExtender>
                        </td>
                        <td class="style17">
                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                            <asp:Label ID="Label13" runat="server" CssClass="style20" 
                                style="text-align: justify" Text="Drawing No."></asp:Label>
                            <br />
                            <asp:TextBox ID="TextBox5" runat="server" CssClass="style30" Height="20px"></asp:TextBox>
                            <cc1:AutoCompleteExtender ServiceMethod="SearchMarkings" 
                            MinimumPrefixLength="2"
                            CompletionInterval="100" EnableCaching="false" CompletionSetCount="10" 
                            TargetControlID="TextBox5"
                            ID="AutoCompleteExtender3" runat="server" FirstRowSelected = "false">
                        </cc1:AutoCompleteExtender>
                            &nbsp;<asp:Button ID="btnSearchArticle" runat="server" style="text-align: left; font-weight: 700;" 
                                Text="Search" CssClass="style18" Height="25px" 
                                onclick="btnSearchArticle_Click" />
                            &nbsp;
                            <asp:Button ID="btnModify" runat="server" CssClass="style18" Height="25px" 
                                onclick="btnModify_Click" style="text-align: left; font-weight: 700;" 
                                Text="Modify" />
                            &nbsp; &nbsp;&nbsp;&nbsp;&nbsp;</td>
                    </tr>
                    <tr>
                        <td class="style33">
                            <asp:Label ID="Label7" runat="server" Text="Article No." CssClass="style20"></asp:Label>
                        </td>
                        <td class="style8" rowspan="10" colspan="2">
                        <iframe id="I1" runat="server" height="330px" name="I1"></iframe>
                            </td>
                    </tr>
                    <tr>
                        <td class="style32">
                            <asp:TextBox ID="TextBox6" runat="server" Height="20px" CssClass="style30" 
                                Enabled="False"></asp:TextBox>
                            <br />
                            <br />
                        </td>
                        
                    </tr>
                    <tr>
                        <td class="style32">
                            <asp:Label ID="Label8" runat="server" Text="Description" CssClass="style20"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="style32">
                            <asp:TextBox ID="TextBox7" runat="server" Height="20px" CssClass="style30"></asp:TextBox>
                            <br />
                            <br />
                        </td>
                    </tr>
                    <tr>
                        <td class="style32">
                            <asp:Label ID="Label9" runat="server" Text="Price" CssClass="style20"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="style32">
                            <asp:TextBox ID="TextBox8" runat="server" Height="20px" CssClass="style30"></asp:TextBox>
                            <br />
                            <br />
                        </td>
                    </tr>
                    <tr>
                        <td class="style32">
                            <asp:Label ID="Label10" runat="server" Text="Marking" CssClass="style20"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="style32">
                            <asp:TextBox ID="TextBox9" runat="server" Height="20px" CssClass="style30"></asp:TextBox>
                            <br />
                            <br />
                        </td>
                    </tr>
                    <tr>
                        <td class="style33">
                            <asp:Label ID="Label11" runat="server" Text="Discount" CssClass="style20"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="style32">
                            <asp:TextBox ID="TextBox10" runat="server" Height="20px" CssClass="style30"></asp:TextBox>
                            <br />
                        </td>
                    </tr>
                </table>
            </asp:Panel>
            <br />
        </asp:Panel>
        <br />
        <br />
        <asp:Panel ID="pnlCreateNArticle" runat="server" DefaultButton="btnCreateArt">
            <table class="style1">
                <tr>
                    <td class="style28">
                        <asp:Label ID="Label14" runat="server" Text="Article No." CssClass="style20"></asp:Label>
                    </td>
                    <td class="style29">
                        <asp:Label ID="Label16" runat="server" Text="Description" CssClass="style20"></asp:Label>
                    </td>
                    <td class="style27">
                        <asp:Label ID="Label18" runat="server" Text="Family" CssClass="style20"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="style28">
                        <asp:TextBox ID="TextBox12" runat="server" Height="20px" CssClass="style31" 
                            Enabled="False"></asp:TextBox>
                        <br />
                        <br />
                    </td>
                    <td class="style29">
                        <asp:TextBox ID="TextBox14" runat="server" Height="20px" CssClass="style31" onfocus="this.value=this.value;"></asp:TextBox>
                        <br />
                        <br />
                    </td>
                    <td class="style27">
                        <asp:TextBox ID="TextBox16" runat="server" Height="20px" CssClass="style31" 
                            Enabled="False"></asp:TextBox>
                        <br />
                        <br />
                    </td>
                </tr>
                <tr>
                    <td class="style24">
                        <asp:Label ID="Label15" runat="server" Text="Cust. Reference(Marking)" 
                            CssClass="style20"></asp:Label>
                    </td>
                    <td class="style26">
                        <asp:Label ID="Label17" runat="server" Text="Price" CssClass="style20"></asp:Label>
                    </td>
                    <td class="style22">
                        <asp:Label ID="Label19" runat="server" Text="Discount" CssClass="style20"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="style28">
                        <asp:TextBox ID="TextBox13" runat="server" Height="20px" CssClass="style31"></asp:TextBox>
                    </td>
                    <td class="style29">
                        <asp:TextBox ID="TextBox15" runat="server" Height="20px" CssClass="style31"></asp:TextBox>
                    </td>
                    <td class="style27">
                        <asp:TextBox ID="TextBox17" runat="server" Height="20px" CssClass="style31"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="style23" colspan="3">
                        <br />
                        <asp:Button ID="btnCreateArt" runat="server" Text="Submit" 
                            style="margin-left:560px; font-weight: 700;" onclick="btnCreateArt_Click"/>
                    </td>
                    <td class="style25">
                        &nbsp;</td>
                    <td class="style27">
                        &nbsp;</td>
                </tr>
            </table>

        </asp:Panel>
        <br />
        <asp:GridView ID="GridView1" runat="server" ForeColor="Black">
        </asp:GridView>
        <asp:HiddenField ID="HiddenField1" runat="server" />
        <asp:HiddenField ID="hdnId" runat="server" />
        <br />
        <br />
    </center>
</asp:Content>
