# FIAP.CitySolutions
Projeto desenvolvido durante o Hackathon de City Solutions promovido pela FIAP

# Backend
Essa aplicação foi desenvolvida utilizando as tecnologias C# com .NET 6 e Docker, entre outras tecnologias afins. 

# Executando o projeto
## Docker ou Visual Studio Code
1) Acesse a pasta app/backend/src pelo terminal
2) Execute o comando "docker-compose -f docker-compose.yml -f docker-compose.override.yml up -d"
3) Aguarde os containeres começarem a executar
4) Realizar chamadas HTTPS utilizando um software como Insomnia ou Postman
    URL base: https://localhost:5001    

### Endpoints: 
    /user
    /responsibles
    /incidents

## Visual Studio
1) Abrir o arquivo /app/backend/src/FIAP.CitySolutions.sln com o Visual Studio
2) Selecionar o perfil docker-compose
3) Executar
4) Realizar chamadas HTTPS utilizando um software como Insomnia ou Postman
    URL base: https://localhost:5001    

### Endpoints: 
    /user
    /responsibles
    /incidents

# Frontend