<%@ Page Title="" Language="C#" MasterPageFile="~/UserMaster.Master" AutoEventWireup="true"
    CodeBehind="UserHome.aspx.cs" Inherits="K_Blog.UserHome" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <link rel="stylesheet" href="jquery-ui/css/black-tie/jquery-ui-1.10.3.custom.min.css">
    <script src="js/vendor/jquery-1.10.1.min.js"></script>
    <script src="jquery-ui/js/jquery-ui-1.10.3.custom.min.js"></script>
    <link rel="Stylesheet" href="css/gridview.css" />
    <script>
        $(function () {
            $("#accordion").accordion({
                heightStyle: "content",
                collapsible: true,
                active: false
            });

        });
    </script>
    <div class="page-header">
        <h1>
            Most Recent Media</h1>
    </div>
    <div id="accordion" style="left: 20%; width: 50%;">
        <h3>
            Color Photos &nbsp;<span runat="server" id="csBadge" class="badge" style="background-color: Red">
            </span>
        </h3>
        <div>
            <p>
                <asp:GridView runat="server" ID="colorGV" AutoGenerateColumns="False" GridLines="None"
                    CssClass="mGrid" EmptyDataText="No Recent Color Photos Taken." PagerStyle-CssClass="pgr"
                    AlternatingRowStyle-CssClass="alt" Width="70%">
                    <Columns>
                        <asp:BoundField DataField="media_id" Visible="false" HeaderText="" />
                        <asp:BoundField DataField="dir_path" Visible="false" HeaderText="" />
                        <asp:TemplateField HeaderText="Date Taken">
                            <ItemTemplate>
                                <asp:LinkButton ID="dateLinkCsBtn" OnClick="dateLinkCsBtn_Click" CommandArgument='<%#Eval("dir_path") %>'
                                    runat="server" Text='<%# Bind("date") %>'></asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>
                       <asp:TemplateField HeaderText="Alias File Name">
                        <ItemTemplate>
                            <asp:Label runat="server" id="aliasFileNameLbl" Text='<%# Bind("alias_file_name") %>'></asp:Label>
                        </ItemTemplate>
                       </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </p>
        </div>
        <h3>
            Infrared Photos &nbsp;<span runat="server" id="irBadge" class="badge" style="background-color: Red"></span></h3>
        <div>
            <p>
                <asp:GridView runat="server" ID="infraredGV" AutoGenerateColumns="False" GridLines="None"
                    CssClass="mGrid" EmptyDataText="No Recent Infrared Photos taken" PagerStyle-CssClass="pgr"
                    AlternatingRowStyle-CssClass="alt" Width="70%">
                    <Columns>
                        <asp:BoundField DataField="media_id" Visible="false" HeaderText="" />
                        <asp:BoundField DataField="dir_path" Visible="false" HeaderText="" />
                        <asp:TemplateField HeaderText="Date Taken">
                            <ItemTemplate>
                                <asp:LinkButton ID="dateLinkCsBtn" OnClick="dateLinkCsBtn_Click" CommandArgument='<%#Eval("dir_path") %>'
                                    runat="server" Text='<%# Bind("date") %>'></asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="alias_file_name" runat="server" HeaderText="Alias File Name" />
                    </Columns>
                </asp:GridView>
            </p>
        </div>
        <h3>
            Black & White Photos&nbsp;<span runat="server" id="bwBadge" class="badge" style="background-color: Red"></span></h3>
        <div>
            <p>
                <asp:GridView runat="server" ID="bwGV" AutoGenerateColumns="False" GridLines="None"
                    CssClass="mGrid" EmptyDataText="No Recent Black And White Photos Captured" PagerStyle-CssClass="pgr"
                    AlternatingRowStyle-CssClass="alt" Width="70%">
                    <Columns>
                        <asp:BoundField DataField="media_id" Visible="false" HeaderText="" />
                        <asp:BoundField DataField="dir_path" Visible="false" HeaderText="" />
                        <asp:TemplateField HeaderText="Date Taken">
                            <ItemTemplate>
                                <asp:LinkButton ID="dateLinkCsBtn" OnClick="dateLinkCsBtn_Click" CommandArgument='<%#Eval("dir_path") %>'
                                    runat="server" Text='<%# Bind("date") %>'></asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="alias_file_name" runat="server" HeaderText="Alias File Name" />
                    </Columns>
                </asp:GridView>
            </p>
        </div>
        <h3>
            Audio Recorded &nbsp;<span runat="server" id="audioBadge" class="badge" style="background-color: Red"></span></h3>
        <div>
            <p>
                <asp:GridView runat="server" ID="audioGV" AutoGenerateColumns="False" GridLines="None"
                    CssClass="mGrid" EmptyDataText="No Recent Audio Recorded" PagerStyle-CssClass="pgr"
                    AlternatingRowStyle-CssClass="alt" Width="70%">
                    <Columns>
                        <asp:BoundField DataField="media_id" Visible="false" HeaderText="" />
                        <asp:BoundField DataField="dir_path" Visible="false" HeaderText="" />
                        <asp:TemplateField HeaderText="Date Taken">
                            <ItemTemplate>
                                <asp:LinkButton ID="dateLinkAudioBtn" OnClick="dateLinkAudioBtn_Click" CommandArgument='<%#Eval("dir_path") %>'
                                    runat="server" Text='<%# Bind("date") %>'></asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="alias_file_name" runat="server" HeaderText="Alias File Name" />
                    </Columns>
                </asp:GridView>
            </p>
        </div>
    </div>
    <div  style="float: right; position: absolute; right: 10%;
        top: 30%;">
        <img id="previewImg" runat="server" visible="false" style=" width: 461px; height: 346px;" />
        <div id="divPreview" runat="server">
        </div>
        <div style="">
            <asp:TextBox runat="server" ID="aliasFileNameTxt" Visible=false Height="25px" Width="200px"></asp:TextBox>
            <asp:Button runat="server" ID="aliasFileNameBtn" Visible=false Width="200px" 
                Height="25px" Text="Save Alias File Name" onclick="aliasFileNameBtn_Click" />
        </div>
    </div>
</asp:Content>
