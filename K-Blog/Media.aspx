<%@ Page Title="" Language="C#" MasterPageFile="~/UserMaster.Master" AutoEventWireup="true"
    CodeBehind="Media.aspx.cs" Inherits="K_Blog.Media" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <link rel="stylesheet" href="jquery-ui/css/black-tie/jquery-ui-1.10.3.custom.min.css">
    <script src="js/vendor/jquery-1.10.1.min.js"></script>
    <script src="jquery-ui/js/jquery-ui-1.10.3.custom.min.js"></script>
    <link rel="Stylesheet" href="css/gridview.css" />
    <script type="text/javascript" src="fancybox/jquery.fancybox.js"></script>
    <link rel="stylesheet" type="text/css" href="fancybox/jquery.fancybox.css" media="screen" />
    <script type="text/javascript" src="fancybox/helpers/jquery.fancybox-media.js"></script>
    <style>
        div.ui-datepicker
        {
            font-size: 12px;
        }
    </style>
    <script>
        $(function () {
            $("#<%= from_date_txt.ClientID %>").datepicker();
            $("#<%= to_date_txt.ClientID %>").datepicker();
            $('#imagePreview').fancybox();
            $('#audio-player').fancybox();
        });
    </script>
    <script>
        function test(dir_path, event) {
            var array = dir_path.split("\u005c");
            var user_id = array[2];
            var media_type = array[3];
            var file_name = array[4];
            var media_root = "KBlog_Media";
            var media_path = media_root + '/' + user_id + '/' + media_type + '/' + file_name;
            console.log(media_path);

            if (media_type != "Audio") {
                alert(media_type);
                $('#imagePreview').prop("href", media_path);
                var link = $('#imagePreview').attr('href');
                console.log(link);
                $("#imagePreview").trigger("click");
                event.preventDefault();
            }
            else {
                $('#div1').show();
                $("#player")[0].src = "KBlog_Media/1/Audio/0fae4a4c-bc76-470e-95ac-d44e7a1a0adb.wav";
                $('#player')[0].load();
                $('#player')[0].play();
                $("#playerr")[0].autoplay = true;
                alert(media_type);
                $("#audio-player").trigger("click");

            }

        };
        
    </script>
    <div class="page-header">
        <h2>
            Media Library</h2>
    </div>
    <div class="container" style="margin: 10px;" runat="server">
        <br />
        <div class="form-group">
            <div class="col-md-3">
                <asp:TextBox runat="server" class="form-control" ID="alias_file_name_txt" placeholder="Alias File Name"></asp:TextBox>
            </div>
            <div class="col-md-3">
                <asp:DropDownList runat="server" ID="mediaTypeDDL" class="form-control">
                    <asp:ListItem Value="0">Media Type</asp:ListItem>
                    <asp:ListItem Value="1">Color Snapshot</asp:ListItem>
                    <asp:ListItem Value="2">Infrared Snapshot</asp:ListItem>
                    <asp:ListItem Value="4">Black and White Snapshot</asp:ListItem>
                    <asp:ListItem Value="3">Audio Recorded</asp:ListItem>
                </asp:DropDownList>
            </div>
            <div class="col-md-2">
                <asp:TextBox runat="server" type="text" class="form-control" ID="from_date_txt" placeholder="From Date Taken"></asp:TextBox>
            </div>
            <div class="col-md-2">
                <asp:TextBox runat="server" class="form-control" ID="to_date_txt" placeholder="To Date Taken"></asp:TextBox>
            </div>
            <div class="left-inner-addon col-md-2 ">
                <asp:LinkButton ID="searchBtn" runat="server" Text="<i class='glyphicon glyphicon-search'></i>&nbsp;Search"
                    CssClass="btn btn-primary" OnClick="searchBtn_Click" />
            </div>
        </div>
        <br />
        <asp:GridView runat="server" ID="searchGV" AutoGenerateColumns="False" GridLines="None"
            CssClass="mGrid" EmptyDataText="The Search Did Not Return Any Results" PagerStyle-CssClass="pgr"
            AlternatingRowStyle-CssClass="alt" Width="100%" OnRowCancelingEdit="searchGV_RowCancelingEdit"
            OnRowEditing="searchGV_RowEditing" DataKeyNames="media_id" OnRowUpdating="searchGV_RowUpdating">
            <Columns>
                <asp:BoundField DataField="media_id" Visible="false" HeaderText="" />
                <asp:BoundField DataField="dir_path" Visible="false" HeaderText="Dir" />
                <asp:TemplateField HeaderText="Date Taken">
                    <ItemTemplate>
                        <asp:LinkButton ID="dateLinkCsBtn" OnClientClick='<%#Eval("dir_path","Javascript:return test(\"{0}\",event);")%>'
                            runat="server" Text='<%# Bind("date") %>'></asp:LinkButton>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Media Type">
                    <ItemTemplate>
                        <asp:Label runat="server" ID="mediaTypeLbl" Text='<%#Eval("description") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Alias File Name">
                    <ItemTemplate>
                        <asp:Label runat="server" ID="aliasFileName" Text='<%#Bind("alias_file_name") %>'></asp:Label>
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:TextBox runat="server" Text='<%#Bind("alias_file_name") %>' ID="updateAliasTxt"></asp:TextBox>
                    </EditItemTemplate>
                </asp:TemplateField>
                <asp:CommandField ShowEditButton="True" />
            </Columns>
        </asp:GridView>
    </div>
    <div>
    </div>
    <br />
    <a id="imagePreview"></a>
    <a id="audio-player" class="fancybox-media" href="#div1">Click me</a>
    <div id="div1" style="display: none">
        <audio id="player" controls></audio>
    </div>
</asp:Content>
