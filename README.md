# moviesdb-api
Projeto feito com base no teste técnico da Wiz Soluções.

# Principais padrões utilizados no projeto e os motivos que foram utilizados.
 - DDD. Por ser um padrão que força o uso de boas práticas para desenvolver códigos. Além de deixar o projeto mais fácil de entender o que camada faz e a responsabilidade de cada classe.

# Se houver a utilização de qualquer biblioteca externa, explicar o motivo do uso das mesmas.
 - RestSharp. Utilizei para fazer as requisições rest a api do moviesdb.
 - Swagger (Swashbuckle.AspNetCore). Utilizei para realizar testes na API do desafio.
 - Microsoft Open API (Microsoft.OpenApi). Utilizei na configuração do json usado pelo Swagger para mostrar informações sobre a API do desafio.
 - NetCore.AutoRegisterDi. Utilizei na configuração das dependencias. Mais especificamente para procurar arquivos com termos parecidos no assembly (nos projetos Common e Repository).
 
 # Fique a vontade para descrever qualquer outro detalhe que ache relevante no projeto.
  A API_KEY gerada no site moviesdb foi colocada em um arquivo appSettings.json. Criei uma rotina para ler o arquivo e capturar, em uma seção específica que criei, essa informação.
  
