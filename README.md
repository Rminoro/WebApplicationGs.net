#Projeto GS CRUD API - Cadastro de Usuários

## Integrantes do Grupo

98974 - Ana Júlia Almeida Silva Neves
</br>
552410 - NICOLY OLIVEIRA SANTOS
99988 - Rafael Minoro Itokazo
551831 - Vitor da Silva Pereira

## Arquitetura
Neste projeto, adotamos a arquitetura **Monolítica** para a nossa API.
A escolha pela arquitetura monolítica foi baseada na simplicidade e no escopo reduzido do projeto. 
Em uma arquitetura monolítica, todas as funcionalidades da aplicação são agrupadas em um único projeto. 
Isso facilita o desenvolvimento e a manutenção, especialmente para projetos menores ou para etapas iniciais de desenvolvimento. 
A estrutura monolítica permite uma integração mais simples entre os componentes e facilita a comunicação entre as partes do sistema.

## Design patterns utilizados:
Singleton
Utilizamos o padrão Singleton para gerenciar a configuração centralizada do projeto. 
O Singleton garante que apenas uma instância da classe de configuração seja criada e utilizada em toda a aplicação. 
Isso ajuda a manter a consistência e a integridade dos dados de configuração.


## Instruções para rodar a API 
1- Clonar o repositório
2- Rodar o comando dotnet restore para restaurar os pacotes NuGet
3- Credenciais do ORACLE (User RM99988 SENHA 160698)


## Endpoints CRUD
GET /api/User: Retorna todos os usuários.
GET /api/User/{id}: Retorna um usuário específico pelo ID.
POST /api/User: Cria um novo usuário.
PUT /api/User/{id}: Atualiza um usuário existente.
DELETE /api/User/{id}: Deleta um usuário pelo ID.
