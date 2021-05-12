## Problema

Imagine que você ficou responsável por construir um sistema que seja capaz de receber milhares de eventos por segundo de sensores espalhados pelo Brasil, nas regiões norte, nordeste, sudeste e sul. Seu cliente também deseja que na solução ele possa visualizar esses eventos de forma clara.

Um evento é defino por um JSON com o seguinte formato:

```json
{
   "timestamp": <Unix Timestamp ex: 1539112021301>,
   "tag": "<string separada por '.' ex: brasil.sudeste.sensor01 >",
   "valor" : "<string>"
}
```

Descrição:
 * O campo timestamp é quando o evento ocorreu em UNIX Timestamp.
 * Tag é o identificador do evento, sendo composto de pais.região.nome_sensor.
 * Valor é o dado coletado de um determinado sensor (podendo ser numérico ou string).

## Requisitos

* Sua solução deverá ser capaz de armazenar os eventos recebidos.

* Cada sensor envia um evento a cada segundo independente se seu valor foi alterado, então um sensor pode enviar um evento com o mesmo valor do segundo anterior.

* Cada evento poderá ter o estado processado ou erro, caso o campo valor chegue vazio, o status do evento será erro caso contrário processado.

* Para visualização desses dados, sua solução deve possuir:
    * Uma tabela que mostre todos os eventos recebidos. Essa tabela deve ser atualizada automaticamente.
    * Um gráfico apenas para eventos com valor numérico.

* Para seu cliente, é muito importante que ele saiba o número de eventos que aconteceram por região e por sensor. Como no exemplo abaixo:
    * Região sudeste e sul ambas com dois sensores (sensor01 e sensor02):
        * brasil.sudeste - 1000
        * brasil.sudeste.sensor01 - 700
        * brasil.sudeste.sensor02 - 300
        * brasil.sul - 1500
        * brasil.sul.sensor01 - 1250
        * brasil.sul.sensor02 - 250    

## Resolução do Problema

O que foi criado:
O SensorWebApp é uma aplicação dividida em frontend e backend, cada um localizado em um ambiente separado por containers.
A aplicação se comunica através de uma rede montada pelos docker's.
No frontend temos três telas, sendo a principal a tela onde podemos ver dois gráficos, o de total de sensores, representado pelo gráfico de rosca e o de total de sensores por região, um gráfico de barras.
Também temos uma página que apresenta todos os gráficos listados e outra onde podemos filtrar pela palavra que quisermos, como "sudeste" para ver o total de sensores na região.
No backend temos diversas rotas, que tornam as consultas acima válidas.

Tecnologias utilizadas:
Utilizei .net core 2.1, conforme requisitado para o desenvolvimento em geral do backend, no frontend utilizei React Asp Net, visto que tenho facilidade com tal tecnologia, além de alguns pacotes, como axios, para requisições de banco de dados do backend, chart.js para criar os gráficos e bootstrap para design da aplicação.
Para testes de rotas, eu utilizei a aplicação Insomnia  e para containerização da aplicação, docker.

## Execucao do Projeto

Para executar a aplicação é necessário apenas clicar digitar o comando "docker compose up" dentro da pasta da aplicação "SensorWebApp".
Caso não inicie sozinho, para acessar a página frontend, basta digitar http://localhost:20021/.
