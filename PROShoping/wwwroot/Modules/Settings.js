
var ClsSettings = {
    GetAll: function () {
        Helper.AjaxCallGet("https://localhost:7292/api/Setting", {}, "json",
            function (data) {
                $("#lnkFacebook").attr("href", data.facebookLink);
                $("#lnkTwitter").attr("href", data.twitterLink);
                $("#lnkInstagram").attr("href", data.instgramLink);
                $("#lnkYoutube").attr("href", data.youtubeLink);


               
            }, function () { });

    }

}
ClsSettings.GetAll();