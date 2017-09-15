var lanchesProntos = [];
var ingredientes = [];
var minhaSelecao = [];
var meuIngredienteSelecionado = [];

$(function() {
   
    retornaLanchePadrao();
    retornaIngredientes(); 

    $(document).on("click", ".lanche", function() {
        let nome_lanche = $(this).next('input').val();
        let lancheSelecionado = $.grep(lanchesProntos, function(e){ return e.nome === nome_lanche; })[0];         
        minhaSelecao.push(lancheSelecionado);
        
        let html = '<a class="elementos">'+ lancheSelecionado.nome + '</a><a class="elementos">&nbsp;&nbsp;&nbsp;&nbsp;<b>R$ '+ lancheSelecionado.total.toFixed(2) + '</b></a><br/>';
        $('#carrinho').append(html); 
        atualizaTotal();   
    });

    $(document).on("click", ".ingrediente", function() {
        let nome_ingrediente = $(this).next('input').val();
        let ingredienteSelecionado = $.grep(ingredientes, function(e){ return e.nome === nome_ingrediente; })[0];         
        meuIngredienteSelecionado.push(ingredienteSelecionado);

        const ingrediente = $.map(meuIngredienteSelecionado, function(obj){
            return obj.nome
        }).join(', ');  
        
        if($('#ingredientesSelecionados').length == 0) {
            let html = '<span class="title" id="customizado">Ingredientes Adicionados</span><a class="elementos" id="ingredientesSelecionados">'+ ingrediente +'</a><br/><button type="button"  class="ingrediente-carrinho btn btn-primary btn-sm">Adicionar Carrinho</button>';
            $('#ingredientes').append(html); 
        } else {
            $('#ingredientesSelecionados').html(ingrediente);
        }
    });

    $(document).on("click", ".ingrediente-carrinho", function() {
        retornaLancheCustomizado(meuIngredienteSelecionado);
    });    
});

atualizaTotal = function(){
    let total = 0;
    for(let i=0; i<minhaSelecao.length; i++) {
        total += minhaSelecao[i].total;       
    }
    $('#valor').html('<b>R$' + total.toFixed(2) + '</b>');
}

retornaLanchePadrao = function(){
    $.get("http://localhost:81/api/lanche/padrao/", function( data ) {  
        lanchesProntos = data;   
        let html = "";
        for(let i=0; i<data.length; i++) {
            
            const ingrediente = $.map(data[i].ingredientes, function(obj){
                return obj.nome
            }).join(', ');           
            
            html += '<a class="elementos">'+ data[i].nome + '</a>';
            html += '<a class="elementos">...'+ ingrediente + '</a>';
            html += '<a class="elementos">&nbsp;&nbsp;&nbsp;&nbsp;<b>R$ '+ data[i].total.toFixed(2) + '</b></a> &nbsp;<button type="button"  class="lanche btn btn-primary btn-sm">Adicionar Carrinho</button><input type="hidden" name="lanche" value="'+ data[i].nome + '">';
            html += '<hr/><br/><br/>';
        }

        $('#cardapio').append(html);       
    });
}

retornaIngredientes = function(){
    $.get("http://localhost:81/api/ingrediente/all", function( data ) { 
        ingredientes = data;      
        let html = "";
        for(let i=0; i<data.length; i++) {    
            html += '<a class="elementos">'+ data[i].nome + '</a>';           
            html += '<a class="elementos">&nbsp;&nbsp;&nbsp;&nbsp;<b>R$ '+ data[i].valor.toFixed(2) + '</b></a> &nbsp;<button type="button" class="ingrediente btn btn-primary btn-sm">Adicionar</button><input type="hidden" name="ingrediente" value="'+ data[i].nome + '">';
            html += '<br/><br/>';
        }

        $('#ingredientes').append(html);       
    });
}

retornaLancheCustomizado = function(data){  

    $.ajax({
        url: 'http://localhost:81/api/lanche/customizado',
        type: 'post',
        dataType: 'json',
        success: function (result) {
            meuIngredienteSelecionado = [];
            minhaSelecao.push(result);
            let html = '<a class="elementos">'+ result.nome + '</a><a class="elementos">&nbsp;&nbsp;&nbsp;&nbsp;<b>R$ '+ result.total.toFixed(2) + '</b></a><br/>';
            $('#carrinho').append(html); 
            atualizaTotal();   
            $('#customizado').remove();
            $('#ingredientesSelecionados').remove();
            $('.ingrediente-carrinho').remove();           
        },
        contentType: "application/json; charset=utf-8",
        data: JSON.stringify(data)
    });
}