$(function () {
    var baseUrl = "https://localhost:44300/";

    $("#balkonModelSecin").change(function () {
        var value = $("#balkonModelSecin").val();
        window.location = baseUrl + value;
    });
    //------------------------------------
    $("[tabindex='2']").focus();
    //------------------------------------
    var profilBoyInput = document.getElementById("profilBoyInput");
    var camAdetInput = document.getElementById("camAdetInput");
    var profilAciInput = document.getElementById("profilAciInput");

    $("#profilBoyButton").click(function () {
        let txt = $("#profilBoyInput").val().toString();
        if (txt == "") {
            alert("Boş değer girilemez");
            $("#profilBoyInput").focus();
            return;
        }
        let nmbr = parseInt(txt);
        if (nmbr < 100 || nmbr > 15, 000) {
            alert("Profil boyu 100 mm ila 15.000 mm arasında olmalıdır");
            $("#profilBoyInput").focus();
            return;
        }
        let opt = "<option value=" + txt.toString() + ">" + txt.toString() + "</option>";
        $("#profilBoySelect").append(opt);
        $("#profilBoyInput").val("");
    });
    profilBoyInput.addEventListener("keydown", function (event) {
        if (event.keyCode === 13) {
            event.preventDefault();
            document.getElementById("profilBoyButton").click();
            return;
        }
    });
    //------------------------------------
    $("#camAdetButton").click(function () {
        let txt = $("#camAdetInput").val().toString();
        let opt = "<option value=" + txt.toString() + ">" + txt.toString() + "</option>";
        if (txt == "") {
            alert("Boş değer girilemez");
            $("#camAdetInput").focus();
            return;
        }
        let nmbr = parseInt(txt);
        if (nmbr < 1 || nmbr > 30) {
            alert("Cam adedi 1 ila 30 arasında olmalıdır");
            $("#camAdetInput").focus();
            return;
        }
        $("#camAdetSelect").append(opt);
        $("#camAdetInput").val("");
        checkBoxOlustur();
    });
    camAdetInput.addEventListener("keydown", function (event) {
        if (event.keyCode === 13) {
            event.preventDefault();
            document.getElementById("camAdetButton").click();
            return;
        }
    });
    //------------------------------------
    $("#profilAciButton").click(function () {
        let txt = $("#profilAciInput").val().toString();
        let opt = "<option value=" + txt.toString() + ">" + txt.toString() + "</option>";
        if (txt == "") {
            alert("Boş değer girilemez");
            $("#profilAciInput").focus();
            return;
        }
        let nmbr = parseInt(txt);
        if (nmbr < -360 || nmbr > 360) {
            alert("Profil açısı -360 ila 360 arasında olmalıdır");
            $("#profilAciInput").focus();
            return;
        }
        $("#profilAciSelect").append(opt);
        $("#profilAciInput").val("");
        GetLeaderLine();
    });
    profilAciInput.addEventListener("keydown", function (event) {
        if (event.keyCode === 13) {
            event.preventDefault();
            document.getElementById("profilAciButton").click();
            return;
        }
    });
    //------------------------------------
    $("#hesapla").click(function (event) {
        let balkonYukseklik = parseInt($("#balkonYukseklik").val());

        if (balkonYukseklik < 500 || balkonYukseklik > 4000) {
            alert("Balkon yükseklik 500 ila 4000 arası olmalıdır");
            $("#balkonYukseklik").focus();
            event.preventDefault();
            return;
        }

        let profilSayisi = $("#profilBoySelect option").length;
        let camAdetSayisi = $("#camAdetSelect option").length;
        let profilAciSayisi = $("#profilAciSelect option").length;

        if (profilSayisi != camAdetSayisi) {
            alert("Profil sayısı ile girilen cam adet sayısı eşit olmalıdır");
            $("#camAdetInput").focus();
            event.preventDefault();
            return;
        }
        if ((profilSayisi - 1) != profilAciSayisi) {
            alert("Profil aci sayısı, profil adedinden 1(bir) eksik olmalıdır");
            $("#profilAciInput").focus();
            event.preventDefault();
            return;
        }

        var myyArray = [];
        $(".checkboxKapsayici input").each(function (i, e) {
            if ($(this).prop('checked')) {
                myyArray.push(i - 1);//index 0 dan başlıyacak
                $("[name='indexList']").val(myyArray);
            }
        });
    });// hesapla
    //------------------------------------
});//document.ready

function checkBoxOlustur() {
    let toplamCamAdet = 0;
    let camAdetler = [];
    $("#camAdetSelect option").each(function (i, e) {
        camAdetler[i] = parseInt(e.value);
        toplamCamAdet = toplamCamAdet + parseInt(e.value);
    });

    let cepheSayisi = camAdetler.length;
    $(".checkboxKapsayici").empty();
    let indx = 0;
    for (var i = 0; i < cepheSayisi; i++) {
        $(".checkboxKapsayici").append("<div class='col cephe" + i + "'>" +
            "<h5>" +
            (i + 1) + ". Profil Cephe" +
            "</h5>" +
            "<div id='checkGrup" + i + "' class='checkGrup'></div>" +
            "</div> ");

        let cephedekiCamSayisi = camAdetler[i];

        for (var j = 0; j < cephedekiCamSayisi; j++) {
            indx++;
            let deger = "";
            let disabled = "disabled";

            if (i == j && j == 0) {
                deger = "Başlangıç Noktası";
            } else if (indx == toplamCamAdet + 1 && (i + 1) == cepheSayisi) {
                deger = "Sonlama Noktası";
            } else if (j == 0 && i != 0) {
                deger = i + ". Açı Köşesi";
            } else {
                deger = (indx - 1) + ". ara";
                disabled = "";
            }

            $('#checkGrup' + i + '').append("<div class='form-check'>" +
                "<label></label>" +
                "<input class='form-check-input' type='checkbox' " + disabled + " id='chk" + indx + "'  name='chk[" + indx + "]'>" +
                "<label class='form-check-label'  for='chk" + indx + "' >" +
                deger +
                "</label>" +
                "</div>");

            if (j != toplamCamAdet) {
                $('#checkGrup' + i + '').append("<img src='/img/window_blue_horizantal.jpg' class='yatayKucukPencere' />");
            }
        }
    }
    $('.checkGrup').last().append("<div class= 'form-check'>" +
        "<label></label>" +
        "<input class='form-check-input' type='checkbox' disabled id='chk" + indx + 1 + "'  name='chk[" + indx + 1 + "]'>" +
        "<label class='form-check-label'  for='chk" + indx + 1 + "' >" +
        "Sonlama Noktası" +
        "</label>" +
        "</div>");
}

function selectAll() {
    options = document.getElementsByTagName("option");
    for (i = 0; i < options.length; i++) {
        options[i].selected = "true";
    }
}

function GetLeaderLine() {
    let toplamCamAdet = 0;
    let camAdetler = [];
    $("#camAdetSelect option").each(function (i, e) {
        camAdetler[i] = parseInt(e.value);
        toplamCamAdet = toplamCamAdet + parseInt(e.value);
    });

    let indx = 0;
    for (var i = 0; i < camAdetler.length; i++) {
        let cephedekiCamSayisi = camAdetler[i];
        for (var j = 0; j < cephedekiCamSayisi; j++) {
            indx++;
            var line = new LeaderLine(
                document.getElementById("chk" + indx + ""),
                document.getElementById("chk" + (indx + 1) + ""),
                {
                    dash: { animation: true }
                });
        }
    }
}