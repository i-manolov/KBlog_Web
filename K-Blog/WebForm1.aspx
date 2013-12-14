<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="K_Blog.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
            <script src="js/vendor/jquery-1.10.1.min.js"></script>
    <script type="text/javascript" src="fancybox/jquery.fancybox.js"></script>
    <link rel="stylesheet" type="text/css" href="fancybox/jquery.fancybox.css" media="screen" />
    <script type="text/javascript" src="fancybox/helpers/jquery.fancybox-media.js?v=1.0.6"></script>
    <script>
        $(document).ready(function () {
            $("#single1").fancybox();
            $('#audio-player').fancybox();
            $('#audio-player').click(function () {
                $('#div1').show();
                $("#player")[0].src = "KBlog_Media/1/Audio/0fae4a4c-bc76-470e-95ac-d44e7a1a0adb.wav";
                $('#player')[0].load();
                $('#player')[0].play();
                $("#playerr")[0].autoplay = rue;
            });
        });
        </script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <a href="img/kinect.jpg" id="single1"> LINK MEEEEE</a>
           <a id="audio-player" class="fancybox-media" href="#div1">Audio Maybe?</a>
           <div id="div1" style="display:none">
            <audio id="player"  controls ></audio>
           </div>
    </div>
    </form>
</body>
</html>
