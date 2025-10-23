# SmartLogis API 🚚📦

Una API REST robusta desarrollada en **ASP.NET Core 9.0** para la gestión integral de sistemas logísticos y de envíos. Esta API permite administrar clientes, envíos, rutas, transportistas y el seguimiento completo del estatus de las operaciones logísticas.

## 🎯 **Propósito de la API**

SmartLogis API está diseñada para empresas de logística y transporte que necesitan:

- **Gestión de Clientes**: Registro, actualización y consulta de información de clientes
- **Control de Envíos**: Creación, seguimiento y administración completa de envíos
- **Gestión de Rutas**: Administración de rutas de transporte y entrega
- **Control de Transportistas**: Gestión de la flota de transportistas
- **Seguimiento de Estatus**: Monitoreo en tiempo real del estado de envíos y operaciones
- **Trazabilidad Completa**: Historial detallado de cambios y movimientos

## 🏗️ **Arquitectura y Patrones**

### **Patrón Repository**
La API implementa el **Patrón Repository** para separar la lógica de acceso a datos de la lógica de negocio:

```
┌─────────────────┐    ┌─────────────────┐    ┌─────────────────┐
│   Controllers   │───▶│    Services     │───▶│  Repositories   │
└─────────────────┘    └─────────────────┘    └─────────────────┘
                                                        │
                                               ┌─────────────────┐
                                               │  Entity Framework │
                                               │    DbContext    │
                                               └─────────────────┘
```

### **Capas de la Aplicación**
- **Controllers**: Manejo de peticiones HTTP y respuestas
- **Services**: Lógica de negocio y orquestación
- **Repositories**: Acceso a datos y persistencia
- **Models**: Entidades de dominio y DTOs
- **Data**: Contexto de Entity Framework y configuraciones

## 🛠️ **Tecnologías Utilizadas**

| Tecnología | Versión | Propósito |
|------------|---------|-----------|
| **ASP.NET Core** | 9.0 | Framework principal |
| **Entity Framework Core** | 9.0.9 | ORM y acceso a datos |
| **SQL Server** | 2022 | Base de datos |
| **Swagger/OpenAPI** | 9.0.6 | Documentación de API |
| **Mapster** | 7.4.0 | Mapeo de objetos |
| **Docker** | - | Contenedorización de BD |

## 🚀 **Instalación y Configuración**

### **Prerrequisitos**
- .NET 9.0 SDK
- Docker Desktop
- SQL Server Management Studio (opcional)

### **1. Clonar el Repositorio**
```bash
git clone https://github.com/Fernando196/SmartLogis.API.git
cd SmartLogis.API
```

### **2. Levantar Base de Datos con Docker**
```bash
docker-compose up -d
```

### **3. Restaurar Paquetes**
```bash
dotnet restore
```

### **4. Ejecutar Migraciones**
```bash
cd SmartLogis.API
dotnet ef database update
```

### **5. Ejecutar la Aplicación**
```bash
dotnet run
```

La API estará disponible en: `http://localhost:5172`

## 📚 **Documentación de API - Swagger**

### **Acceso a Swagger UI**
Una vez ejecutada la aplicación, accede a la documentación interactiva:

🌐 **URL**: `http://localhost:5172/swagger`

### **Características de Swagger UI**
- ✅ Documentación visual de todos los endpoints
- ✅ Prueba directa de APIs desde la interfaz
- ✅ Esquemas de modelos de datos (DTOs)
- ✅ Códigos de respuesta documentados
- ✅ Exploración interactiva de la API

## 🛣️ **Endpoints Principales**

### **🧑‍💼 Clientes (`/api/Cliente`)**
| Método | Endpoint | Descripción |
|--------|----------|-------------|
| `GET` | `/api/Cliente` | Obtener todos los clientes con filtros |
| `GET` | `/api/Cliente/{id}` | Obtener cliente por ID |
| `GET` | `/api/Cliente/{id}/envios` | Obtener envíos de un cliente |
| `POST` | `/api/Cliente` | Crear nuevo cliente |
| `PUT` | `/api/Cliente/{id}` | Actualizar cliente |
| `DELETE` | `/api/Cliente/{id}` | Eliminar cliente |

### **📦 Envíos (`/api/Envio`)**
| Método | Endpoint | Descripción |
|--------|----------|-------------|
| `GET` | `/api/Envio` | Obtener todos los envíos con filtros |
| `GET` | `/api/Envio/{id}` | Obtener envío por ID |
| `POST` | `/api/Envio` | Crear nuevo envío |
| `PUT` | `/api/Envio/{id}` | Actualizar envío |
| `DELETE` | `/api/Envio/{id}` | Eliminar envío |

### **🚛 Transportistas (`/api/Transportista`)**
| Método | Endpoint | Descripción |
|--------|----------|-------------|
| `GET` | `/api/Transportista` | Obtener todos los transportistas |
| `GET` | `/api/Transportista/{id}` | Obtener transportista por ID |
| `POST` | `/api/Transportista` | Crear nuevo transportista |
| `PUT` | `/api/Transportista/{id}` | Actualizar transportista |
| `DELETE` | `/api/Transportista/{id}` | Eliminar transportista |

### **🗺️ Rutas (`/api/Rutas`)**
| Método | Endpoint | Descripción |
|--------|----------|-------------|
| `GET` | `/api/Rutas` | Obtener todas las rutas |
| `GET` | `/api/Rutas/{id}` | Obtener ruta por ID |
| `POST` | `/api/Rutas` | Crear nueva ruta |
| `PUT` | `/api/Rutas/{id}` | Actualizar ruta |
| `DELETE` | `/api/Rutas/{id}` | Eliminar ruta |

### **📊 Estatus (`/api/Estatus`)**
| Método | Endpoint | Descripción |
|--------|----------|-------------|
| `GET` | `/api/Estatus` | Obtener todos los estatus |
| `GET` | `/api/Estatus/{id}` | Obtener estatus por ID |
| `POST` | `/api/Estatus` | Crear nuevo estatus |
| `PUT` | `/api/Estatus/{id}` | Actualizar estatus |
| `DELETE` | `/api/Estatus/{id}` | Eliminar estatus |

## 🔍 **Sistema de Filtros**

La API incluye un sistema de filtros dinámicos para consultas avanzadas:

```json
{
  "filters": {
    "nombre": {
      "value": "Juan",
      "operator": "contains"
    },
    "ciudad": {
      "value": "México",
      "operator": "equals"
    }
  }
}
```

### **Operadores Disponibles:**
- `equals` - Igualdad exacta
- `contains` - Contiene texto
- `startswith` - Inicia con
- `endswith` - Termina con
- `greaterthan` - Mayor que
- `lessthan` - Menor que

## 📋 **Modelos de Datos Principales**

### **Cliente**
```json
{
  "idCliente": 1,
  "nombre": "Empresa ABC",
  "rfc": "ABC123456789",
  "direccion": "Calle Principal 123",
  "ciudad": "Ciudad de México",
  "pais": "México",
  "telefono": "5555555555",
  "email": "contacto@empresaabc.com"
}
```

### **Envío**
```json
{
  "idEnvio": 1,
  "numeroGuia": "ENV001",
  "origen": "Ciudad de México",
  "destino": "Guadalajara",
  "peso": 15.50,
  "volumen": 0.75,
  "tipoEnvio": "Express",
  "fechaSalida": "2024-10-22T08:00:00",
  "fechaEntregaEstimada": "2024-10-23T18:00:00"
}
```

## 🛡️ **Características de Seguridad**

- ✅ **Validación de Modelos**: Data Annotations en todos los DTOs
- ✅ **Manejo de Errores**: Middleware personalizado para excepciones
- ✅ **Validaciones de Negocio**: Validaciones en capa de servicios
- ✅ **SQL Server Seguro**: Conexión con TrustServerCertificate

## 📁 **Estructura del Proyecto**

```
SmartLogis.API/
├── Controllers/           # Controladores de API
├── Data/                 # Contexto de Entity Framework
├── Helpers/              # Utilidades y helpers
├── Mapping/              # Configuraciones de Mapster
├── Middlewares/          # Middleware personalizado
├── Migrations/           # Migraciones de EF Core
├── Models/              # Entidades y DTOs
│   ├── Dtos/           # Data Transfer Objects
│   └── Middlewares/    # Modelos para middleware
├── Repository/          # Implementación del patrón Repository
│   └── Interfaces/     # Contratos de repositorios
└── Services/           # Lógica de negocio
    └── Interfaces/     # Contratos de servicios
```

## 🔧 **Configuración**

### **Cadena de Conexión**
Modifica `appsettings.json` para tu entorno:

```json
{
  "ConnectionStrings": {
    "ConexionSql": "Server=localhost,11433;Database=SmartLogis;User ID=sa;Password=TuPassword;TrustServerCertificate=true"
  }
}
```

### **Docker Compose**
La base de datos SQL Server se ejecuta en el puerto `11433` para evitar conflictos.

## 📝 **Próximas Características**

- [ ] Autenticación JWT
- [ ] Rate Limiting
- [ ] Logging avanzado con Serilog
- [ ] Caché con Redis
- [ ] Notificaciones en tiempo real
- [ ] Reportes y analytics
- [ ] API Versioning

## 🤝 **Contribución**

1. Fork el proyecto
2. Crea una rama para tu feature (`git checkout -b feature/AmazingFeature`)
3. Commit tus cambios (`git commit -m 'Add some AmazingFeature'`)
4. Push a la rama (`git push origin feature/AmazingFeature`)
5. Abre un Pull Request

## 📄 **Licencia**

Este proyecto está bajo la Licencia MIT. Ver el archivo `LICENSE` para más detalles.

## 📞 **Contacto**

**Fernando** - [@Fernando196](https://github.com/Fernando196)

**Link del Proyecto**: [https://github.com/Fernando196/SmartLogis.API](https://github.com/Fernando196/SmartLogis.API)

---

⭐ **¡No olvides darle una estrella al proyecto si te fue útil!**