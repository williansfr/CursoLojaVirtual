var app = {};

$(function () {
    app.iniciarlizar();
});


app.iniciarlizar = function () {

    $('#main-menu').smartmenus();
    $('.sidey .nav').navgoco();
    app.ObterEsportes();
    app.ObterMarcas();
    app.ObterClubesNacionais();
    app.ObterClubesInternacionais();
    app.ObterSelecoes();

}

///

//

app.ObterSelecoes = function () {
 
    $.getJSON('menu/obterselecoes', function (data) {

        $(data).each(function () {
            $("#selecoes").append("<li><a href='/nav/times/" + this.LinhaCodigo + "/" + this.LinhaDescricaoSeo + "'>" + this.LinhaDescricao + "</a></li>");
        });

    });

}


app.ObterClubesNacionais = function () {

    $.getJSON('menu/obterclubesnacionais', function (data) {

        $(data).each(function () {
            $("#clubesnacionais").append("<li><a href='/nav/times/" + this.LinhaCodigo + "/" + this.LinhaDescricaoSeo + "'>" + this.LinhaDescricao + "</a></li>");
        });

    });

}



app.ObterClubesInternacionais = function () {

    $.getJSON('menu/obterclubesinternacionais', function (data) {

        $(data).each(function () {
           
            $("#clubesinternacionais").append("<li><a href='/nav/times/" + this.LinhaCodigo + "/" + this.LinhaDescricaoSeo + "'>" + this.LinhaDescricao + "</a></li>");
        });

    });

}




app.ObterEsportes = function () {

    $.getJSON('/menu/obteresportes', function (data) {

        $(data).each(function () {
            $("#esportes").append("<li><a href='#'>" + this.CategoriaDescricao + "</a></li>");
        });

    });

};

app.ObterMarcas = function () {

    $.getJSON('/menu/obtermarcas', function (data) {

        $(data).each(function () {
            $(".marcas").append("<li><a href='#'>" + this.MarcaDescricao + "</a></li>");
        });

    });

};










