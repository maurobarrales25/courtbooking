# Requisitos Atómicos — PUC-05: Incorporar un complejo al servicio

**Proyecto:** CanchasYa!
**Versión:** 1.0
**Fecha:** 2026-05-08
**PUC origen:** PUC-05 — Incorporar un complejo al servicio
**BUC origen:** BUC-05

---

## Índice

| ID | Descripción breve | Tipo | Prioridad |
|---|---|---|---|
| RF-35 | Crear espacio de gestión aislado para el complejo | Funcional | Must have |
| RF-36 | Crear cuenta de administrador con permisos exclusivos sobre el complejo | Funcional | Must have |
| RF-37 | Registrar canchas del complejo con sus características | Funcional | Must have |
| RF-38 | Configurar horarios de operación y precios por turno | Funcional | Must have |
| RF-39 | Configurar política de cancelación del complejo | Funcional | Should have |
| RF-40 | Rechazar el alta de un complejo ya incorporado | Funcional | Must have |
| RF-41 | Activar el complejo y publicar su oferta de canchas | Funcional | Must have |
| RF-42 | Vincular complejo con intermediario de cobro | Funcional | Should have |

---

## RF-35 — Crear espacio de gestión aislado para el complejo

| Campo | Valor |
|---|---|
| **# Requisito** | RF-35 |
| **Tipo** | Requisito funcional |
| **# Evento / Caso de uso** | PUC-05 (paso 3) |
| **Descripción** | El sistema deberá crear un espacio de gestión independiente para cada complejo incorporado, de modo que sus datos (reservas, canchas, configuración) no sean accesibles por otros complejos. |
| **Justificación** | El modelo multitenant requiere aislamiento total entre complejos competidores que comparten la infraestructura del servicio (BR-13). |
| **Autor** | Equipo CanchasYa! |
| **Criterio de verificación** | Un usuario del complejo A no puede consultar, modificar ni visualizar las reservas o canchas del complejo B. Todas las consultas de recursos del complejo incluyen obligatoriamente el identificador de tenant. |
| **Satisfacción del interesado** | 5 |
| **Insatisfacción del interesado** | 5 |
| **Prioridad** | Must have |
| **Dependencias** | RF-40 |
| **Conflictos** | — |
| **Material de soporte** | BR-13, BR-15, PUC-05 paso 3 |
| **Historial** | 2026-05-08 — Creado |

---

## RF-36 — Crear cuenta de administrador con permisos exclusivos sobre el complejo

| Campo | Valor |
|---|---|
| **# Requisito** | RF-36 |
| **Tipo** | Requisito funcional |
| **# Evento / Caso de uso** | PUC-05 (paso 4) |
| **Descripción** | El sistema deberá crear la cuenta del administrador principal del complejo con permisos de gestión (crear, modificar, cancelar, consultar) exclusivamente sobre los recursos del propio complejo. |
| **Justificación** | El administrador debe poder operar su complejo de forma autónoma sin poder afectar datos de otros complejos (BR-14). |
| **Autor** | Equipo CanchasYa! |
| **Criterio de verificación** | El administrador principal puede crear, modificar y cancelar reservas de su propio complejo. Un intento del mismo administrador de operar sobre recursos de otro complejo es rechazado. |
| **Satisfacción del interesado** | 5 |
| **Insatisfacción del interesado** | 5 |
| **Prioridad** | Must have |
| **Dependencias** | RF-35 |
| **Conflictos** | — |
| **Material de soporte** | BR-14, PUC-05 paso 4 |
| **Historial** | 2026-05-08 — Creado |

---

## RF-37 — Registrar canchas del complejo con sus características

| Campo | Valor |
|---|---|
| **# Requisito** | RF-37 |
| **Tipo** | Requisito funcional |
| **# Evento / Caso de uso** | PUC-05 (paso 5) |
| **Descripción** | El sistema deberá permitir al dueño del complejo registrar una o más canchas con sus características (nombre, tipo de superficie, capacidad de jugadores), asociándolas al espacio de gestión del complejo. |
| **Justificación** | Sin canchas registradas, el complejo no puede ofrecer turnos y los jugadores no pueden reservar. |
| **Autor** | Equipo CanchasYa! |
| **Criterio de verificación** | Tras registrar una cancha, esta aparece en la oferta del complejo y puede ser seleccionada por jugadores para reservas. La cancha no es visible desde la oferta de otro complejo. |
| **Satisfacción del interesado** | 5 |
| **Insatisfacción del interesado** | 5 |
| **Prioridad** | Must have |
| **Dependencias** | RF-35 |
| **Conflictos** | — |
| **Material de soporte** | PUC-05 paso 5 |
| **Historial** | 2026-05-08 — Creado |

---

## RF-38 — Configurar horarios de operación y precios por turno

| Campo | Valor |
|---|---|
| **# Requisito** | RF-38 |
| **Tipo** | Requisito funcional |
| **# Evento / Caso de uso** | PUC-05 (paso 6) |
| **Descripción** | El sistema deberá permitir al dueño del complejo configurar los horarios de operación (días de la semana y rangos horarios) y el precio por hora de turno para cada cancha, de forma independiente para cada complejo. |
| **Justificación** | Cada complejo tiene su propio calendario y modelo de precios; la configuración independiente es requisito del modelo multitenant (BR-08, BR-16). |
| **Autor** | Equipo CanchasYa! |
| **Criterio de verificación** | Los turnos mostrados al consultar disponibilidad (RF-01) corresponden exactamente al horario configurado. Una cancha con precio configurado muestra ese precio al jugador al seleccionar el turno. La configuración de un complejo no afecta la de otro. |
| **Satisfacción del interesado** | 5 |
| **Insatisfacción del interesado** | 5 |
| **Prioridad** | Must have |
| **Dependencias** | RF-37 |
| **Conflictos** | — |
| **Material de soporte** | BR-08, BR-16, PUC-05 paso 6 |
| **Historial** | 2026-05-08 — Creado |

---

## RF-39 — Configurar política de cancelación del complejo

| Campo | Valor |
|---|---|
| **# Requisito** | RF-39 |
| **Tipo** | Requisito funcional |
| **# Evento / Caso de uso** | PUC-05 (paso 7, E7.1) |
| **Descripción** | El sistema deberá permitir al dueño del complejo definir los umbrales de su política de cancelación (horas para cancelación libre, horas para penalización parcial y porcentajes de retención), dentro de los límites mínimos establecidos por el servicio. |
| **Justificación** | Cada complejo tiene su modelo de negocio; la plataforma facilita pero no impone una política única (BR-16, BR-27). |
| **Autor** | Equipo CanchasYa! |
| **Criterio de verificación** | El sistema rechaza una política cuyo umbral de cancelación libre sea inferior a 1 hora (BR-27). Una política válida configurada en el complejo es la que se aplica al calcular devoluciones (RF-13). |
| **Satisfacción del interesado** | 4 |
| **Insatisfacción del interesado** | 3 |
| **Prioridad** | Should have |
| **Dependencias** | RF-35 |
| **Conflictos** | — |
| **Material de soporte** | BR-16, BR-27, PUC-05 paso 7, E7.1 |
| **Historial** | 2026-05-08 — Creado |

---

## RF-40 — Rechazar el alta de un complejo ya incorporado

| Campo | Valor |
|---|---|
| **# Requisito** | RF-40 |
| **Tipo** | Requisito funcional |
| **# Evento / Caso de uso** | PUC-05 (paso 2, E2.1) |
| **Descripción** | El sistema deberá rechazar el alta de un complejo cuando ya exista un complejo registrado con los mismos datos de identificación, informando al solicitante del duplicado. |
| **Justificación** | Un complejo duplicado generaría espacios de gestión inconsistentes y confusión en la oferta visible para los jugadores. |
| **Autor** | Equipo CanchasYa! |
| **Criterio de verificación** | Un intento de registrar un complejo con datos de identificación ya existentes es rechazado. No se crea un espacio de gestión duplicado. |
| **Satisfacción del interesado** | 4 |
| **Insatisfacción del interesado** | 4 |
| **Prioridad** | Must have |
| **Dependencias** | — |
| **Conflictos** | — |
| **Material de soporte** | PUC-05 E2.1 |
| **Historial** | 2026-05-08 — Creado |

---

## RF-41 — Activar el complejo y publicar su oferta de canchas

| Campo | Valor |
|---|---|
| **# Requisito** | RF-41 |
| **Tipo** | Requisito funcional |
| **# Evento / Caso de uso** | PUC-05 (paso 8) |
| **Descripción** | El sistema deberá activar el complejo y hacer visible su oferta de canchas para los jugadores una vez que el dueño haya completado el registro de canchas, horarios y política de cancelación. |
| **Justificación** | El complejo debe estar completamente configurado antes de recibir reservas; la activación es el paso que habilita su visibilidad. |
| **Autor** | Equipo CanchasYa! |
| **Criterio de verificación** | Tras la activación, las canchas del complejo aparecen disponibles en la consulta de disponibilidad de jugadores (RF-01). Un complejo no activado no aparece en la oferta. |
| **Satisfacción del interesado** | 5 |
| **Insatisfacción del interesado** | 5 |
| **Prioridad** | Must have |
| **Dependencias** | RF-35, RF-37, RF-38 |
| **Conflictos** | — |
| **Material de soporte** | PUC-05 paso 8 |
| **Historial** | 2026-05-08 — Creado |

---

## RF-42 — Vincular complejo con intermediario de cobro

| Campo | Valor |
|---|---|
| **# Requisito** | RF-42 |
| **Tipo** | Requisito funcional |
| **# Evento / Caso de uso** | PUC-05 (A7.1) |
| **Descripción** | El sistema deberá permitir al dueño del complejo vincular sus credenciales con el intermediario de cobro para habilitar el procesamiento de pagos por adelantado en las reservas. |
| **Justificación** | Sin esta vinculación el complejo opera sin cobro anticipado; la vinculación es necesaria para el flujo de pago en línea (PUC-06). |
| **Autor** | Equipo CanchasYa! |
| **Criterio de verificación** | Un complejo con vinculación activa al intermediario de cobro habilita el flujo de pago en línea para sus reservas. Un complejo sin vinculación confirma reservas sin pago (RF-10). |
| **Satisfacción del interesado** | 5 |
| **Insatisfacción del interesado** | 4 |
| **Prioridad** | Should have |
| **Dependencias** | RF-35 |
| **Conflictos** | — |
| **Material de soporte** | PUC-05 A7.1, (Should have — Mercado Pago) |
| **Historial** | 2026-05-08 — Creado |
