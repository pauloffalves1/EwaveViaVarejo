# EwaveViaVarejo
Teste

O projeto foi desenvolvido em asp.net core 2.2, .net, framework standard 2.2 e asp.net core web api 2.2, visual studio 2019.

Para Roda o projeto é necessário rodar o script que se encontra na raiz do projeto Scripts ViaVarejo.sql.

Abrir o projeto no visual studio e atualizar dados de login no banco de dados no arquivo appsettings.json no projeto ViaVarejo.Services.Friends.API.

O projeto está utilizando autenticacão JWT, e pode ser visto o dados do usuário no arquivo appsettings.json do projeto ViaVarejo.Services.Friends.WebCoreMVC.

Após os dados do banco de dados serem atualizados devemos rever se a WebApi do projeto está configurada para rodar na porta 58665, configuração esta que está contida no arquivo appsettings.json do projeto ViaVarejo.Services.Friends.WebCoreMVC, caso esteja rodando em outra porta atualizar.

Para se testar o projeto deve-se ter cadastrado alguns amigos, o ideal seria ao menos 4, para que na página da home a pessoa indique em que amigo ela se encontra na combo e na grid é carregado os 3 amigos mais próximos, indicando a distância de cada 1.

No menu Amigos podemos gerenciar nossos amigos. Ao clicar em adicionar um amigo, uma modal será aberta, as validações não foram feitas e nem desabilitar compos mas o projeto foi construído para que a pessoa digite o nome do amigo e em seguida o endereço que a pessoa mora, e quando ela tirar o mouse do campo, evento blur, o mapa será carregado indicando o ponto no mapa e carregando a latitude e longitude do endereço digitado.

Podemos atualizar da mesma forma, digitando o endereço e o mapa é atualizado.

O Swagger pode ser visto na pagina onde roda o webapi, digitando após o endereço /swagger, caso esteja na mesma porta, será a seguinte url:

http://localhost:58665/swagger

A controller de autenticação fica no projeto webapi, e é a LoginController.

# Resultados

O projeto foi desenvolvido utilizando alguns conceitos de arquitetura para modelagem de projetos em DDD, utilizando entity framework core e dapper para rodar a query da distância, simulando querys complexas, que são difíceis de se fazer no entity framework utlizando linq.

Todo projeto tem seu próprio desafio e por mais que seja um teste sempre criamos novas maneiras de implementar variando e melhorando a codificação.

Fazia muito tempo que não utilizava a api do google maps, e teve um pouco de estudo na api para carregar o mapa e localizar o endereço, só não avancei para conseguir pegar a latitude a longitude quando arrasta no mapa, função drag do maps, pelo prazo de entrega do teste, mas deveria criar um listener, que acho bem legal essa função.

Acredito que é uma simples aplicação mas que utiliza de conceitos bem legais e modernos de codificação assincrona e em tarefas.

O tempo gasto para desenvolver o projeto foi de 16 horas.
