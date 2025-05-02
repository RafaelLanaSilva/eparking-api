# EParking - Sistema de Gerenciamento de Estacionamento Rotativo

![.NET](https://img.shields.io/badge/.NET-8.0-purple)
![License](https://img.shields.io/badge/license-MIT-green)
![Docker](https://img.shields.io/badge/Docker-Ready-blue)
![Status](https://img.shields.io/badge/status-Em%20Desenvolvimento-yellow)

> Projeto backend desenvolvido com .NET 8 para gerenciar operações de um estacionamento rotativo, abrangendo funcionalidades como controle de movimentações, gestão de vagas, veículos e tarifas.

---

## 📐 Arquitetura

O projeto é dividido em três camadas principais, organizadas para manter a separação de responsabilidades e facilitar a manutenção e evolução do sistema:

🔹 **API** -
Camada responsável por expor os endpoints HTTP da aplicação. É a porta de entrada para as requisições dos clientes e coordena a interação entre os serviços de domínio e a infraestrutura.

🔹 **Domain** -
Camada de domínio onde estão concentradas as entidades, regras de negócio, contratos e validações. Aqui reside a lógica que representa o funcionamento do sistema de estacionamento.

🔹 **Infra.Data** -
Camada de acesso a dados e infraestrutura. Responsável pela implementação dos repositórios, configuração do Entity Framework Core e manipulação do banco de dados.

---

## 🚀 Tecnologias Utilizadas

- ✅ .NET 8

- ✅ Entity Framework Core

- ✅ AutoMapper

- ✅ Swagger (OpenAPI)

- ✅ CORS

- ✅ Docker (Virtualização e containers)

## 📦 Padrões e Boas Práticas

- ✅ Princípios SOLID

- ✅ Injeção de Dependência
  
- ✅ Repositório Genérico

- ✅ Separação de Camadas (API, Domain, Infra.Data)

- ✅ Virtualização com Docker (Dockerfile + docker-compose)

- ✅ Controle de versionamento com Git Flow

## 📚 Funcionalidades

- Cadastro e gerenciamento de:

  - Estacionamentos
  - Vagas (automático por tipo)
  - Veículos
  - Tarifas por tipo de veículo
  - Movimentações (entrada/saída e cobrança por tempo)

- Cálculo automático e valor cobrado configurável com base em:

  - Hora cheia
  - Frações em minutos
  - Tempo de Tolerância

- Integração com Swagger para testes e documentação da API

## 🛠️ Como Executar

1. Clone o repositório:

   ```bash
   git clone https://github.com/RafaelLanaSilva/eparking-api.git
   cd EParking

   ```

2. Configure o arquivo appsettings.json com a string de conexão do seu banco de dados.

3. Execute as migrations através do Consolo do Gerenciador de Pacotes
   ```bash
   Update-Database
   ```

## 🐳 Docker (opcional)

1. Execute com Docker

   ```bash
    docker-compose up --build

   ```

2. Certifique-se de que sua string de conexão use o host do container no arquivo appsettings.json

## 👨‍💻 Autores

<div style="display: flex; gap: 2rem; align-items: center;">

### Rafael Lana

Desenvolvedor Full Stack | .NET Developer |

[![GitHub](https://img.shields.io/badge/GitHub-000?style=for-the-badge&logo=github&logoColor=white)](https://github.com/RafaelLanaSilva)
[![LinkedIn](https://img.shields.io/badge/LinkedIn-0A66C2?style=for-the-badge&logo=linkedin&logoColor=white)](https://www.linkedin.com/in/rafaeldelana/)

---

### Daniel Cid

Desenvolvedor Full Stack | .NET Developer | Graduando em Ciências da Computação

[![GitHub](https://img.shields.io/badge/GitHub-000?style=for-the-badge&logo=github&logoColor=white)](https://github.com/daelcid)
[![LinkedIn](https://img.shields.io/badge/LinkedIn-0A66C2?style=for-the-badge&logo=linkedin&logoColor=white)](https://www.linkedin.com/in/danielmoraescid/)

</div>
