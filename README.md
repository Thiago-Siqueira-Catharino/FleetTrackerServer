# FleetTracker Server

API REST para rastreamento e gestão de frotas de veículos, construída em .NET 9 seguindo princípios de **Domain-Driven Design** com arquitetura hexagonal (ports & adapters). O sistema cobre autenticação/autorização por papéis, cadastro de veículos e coleta de telemetria (localização e rotas) em tempo real.

## Arquitetura

O projeto é organizado em **bounded contexts** independentes, cada um dividido nas camadas `Domain`, `Application`, `Infrastructure` e `Presentation`:

```
FleetTracker/
├── Contexts/
│   ├── Auth/            # Identidade, papéis e autenticação JWT
│   ├── Fleet/            # Cadastro e consulta de veículos
│   ├── Telemetry/        # Localização, rotas e histórico de trajetos
│   └── Administration/   # Operações administrativas (em construção)
├── Common/                # Value Objects e utilitários compartilhados
└── Program.cs             # Composition root
```

- **Domain**: entidades e regras de negócio, sem dependência de infraestrutura.
- **Application**: casos de uso (use cases) que orquestram o domínio.
- **Infrastructure**: persistência (EF Core), repositórios concretos.
- **Presentation**: controllers HTTP (a porta de entrada da aplicação).

## Stack

| Camada | Tecnologia |
|---|---|
| Runtime | .NET 9 / ASP.NET Core |
| Persistência | Entity Framework Core 9 + Pomelo (MySQL) |
| Autenticação | ASP.NET Identity + JWT Bearer |
| Documentação de API | Swagger / Swashbuckle |
| Banco de dados | MySQL |

## Papéis de usuário

O sistema define três papéis via ASP.NET Identity, criados automaticamente na inicialização:

- **Admin** — consulta veículos, rotas e histórico de localização.
- **Driver** — inicia rotas e envia atualizações de localização.
- **FieldAgent** — cadastra novos veículos na frota.

## Endpoints principais

### Auth (`/api/user`)
| Método | Rota | Descrição |
|---|---|---|
| POST | `/register/driver` | Cadastra um motorista |
| POST | `/register/admin` | Cadastra um administrador |
| POST | `/register/fieldagent` | Cadastra um agente de campo |
| POST | `/login` | Autentica e retorna token JWT |

### Fleet (`/api/car`)
| Método | Rota | Papel exigido | Descrição |
|---|---|---|---|
| POST | `/Cadastrar` | FieldAgent | Registra um novo veículo |
| GET | `/Buscar` | Admin | Lista todos os veículos |
| GET | `/Buscar/id={id}` | Admin | Busca veículo por ID |
| GET | `/Buscar/tag={tag}` | Admin | Busca veículo por tag |
| GET | `/{id}/rotas` | Admin | Histórico de localização de um veículo em um período |

### Telemetry — Paths (`/api/path`)
| Método | Rota | Papel exigido | Descrição |
|---|---|---|---|
| POST | `/` | Driver | Inicia uma nova rota |
| GET | `/search/id={carId}` | Admin | Lista rotas de um veículo |
| GET | `/search/` | Admin | Lista todas as rotas |

### Telemetry — Location (`/api/locationpoint`)
| Método | Rota | Papel exigido | Descrição |
|---|---|---|---|
| POST | `/location/update` | Driver | Envia atualização de localização |
| GET | `/location/search/pathId={pathId}` | — | Lista pontos de localização de uma rota |

## Como rodar localmente

### Pré-requisitos
- .NET 9 SDK
- MySQL em execução localmente (ou acessível via connection string)

### Passos

1. Clone o repositório:
   ```bash
   git clone https://github.com/Thiago-Siqueira-Catharino/FleetTrackerServer.git
   cd FleetTrackerServer
   ```

2. Configure a connection string e os segredos JWT em `appsettings.json` (ou, preferencialmente, via variáveis de ambiente / `dotnet user-secrets`, para não versionar segredos):
   ```json
   {
     "ConnectionStrings": {
       "DefaultConnection": "server=localhost;port=3306;database=FleetTracker;user=root;password=SUA_SENHA"
     },
     "Jwt": {
       "Key": "SUA_CHAVE_SECRETA",
       "Issuer": "FleetTracker",
       "Audience": "FleetTrackerUsers"
     }
   }
   ```

3. Aplique as migrations (se ainda não houver banco criado):
   ```bash
   dotnet ef database update --project FleetTracker
   ```

4. Rode a aplicação:
   ```bash
   dotnet run --project FleetTracker
   ```

5. Acesse a documentação interativa em `/swagger` (ambiente de desenvolvimento).

## Roadmap

- [ ] Finalizar o contexto de Administration
- [ ] Cobertura de testes automatizados
- [ ] CI/CD

---

> ⚠️ **Nota de segurança**: o `appsettings.json` atual contém uma chave JWT de exemplo commitada no repositório. Antes de qualquer deploy, substitua por um segredo gerado e mantido fora do controle de versão (variáveis de ambiente, `dotnet user-secrets`, Key Vault, etc.).
