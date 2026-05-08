# Requisitos Atómicos — PUC-04: Registrar un jugador

**Proyecto:** CanchasYa!
**Versión:** 1.0
**Fecha:** 2026-05-08
**PUC origen:** PUC-04 — Registrar un jugador
**BUC origen:** BUC-04

---

## Índice

| ID | Descripción breve | Tipo | Prioridad |
|---|---|---|---|
| RF-30 | Registrar jugador con datos de contacto | Funcional | Must have |
| RF-31 | Verificar unicidad de cuenta antes de registrar | Funcional | Must have |
| RF-32 | Registrar jugador mediante proveedor de identidad externo | Funcional | Must have |
| RF-33 | Rechazar datos de registro incompletos o inválidos | Funcional | Must have |
| RF-34 | Notificar confirmación del registro al jugador | Funcional | Must have |

---

## RF-30 — Registrar jugador con datos de contacto

| Campo | Valor |
|---|---|
| **# Requisito** | RF-30 |
| **Tipo** | Requisito funcional |
| **# Evento / Caso de uso** | PUC-04 (paso 3) |
| **Descripción** | El sistema deberá crear una cuenta de jugador con perfil activo a partir de los datos de contacto proporcionados por el solicitante. |
| **Justificación** | Sin registro, el solicitante no puede reservar canchas ni acceder a ninguna funcionalidad del servicio. |
| **Autor** | Equipo CanchasYa! |
| **Criterio de verificación** | Tras el registro exitoso, existe una cuenta de jugador con estado activo asociada a los datos ingresados, y el jugador puede iniciar sesión y hacer reservas. |
| **Satisfacción del interesado** | 5 |
| **Insatisfacción del interesado** | 5 |
| **Prioridad** | Must have |
| **Dependencias** | RF-31, RF-33 |
| **Conflictos** | — |
| **Material de soporte** | PUC-04 paso 3 |
| **Historial** | 2026-05-08 — Creado |

---

## RF-31 — Verificar unicidad de cuenta antes de registrar

| Campo | Valor |
|---|---|
| **# Requisito** | RF-31 |
| **Tipo** | Requisito funcional |
| **# Evento / Caso de uso** | PUC-04 (paso 2, E2.1) |
| **Descripción** | El sistema deberá rechazar el registro de un jugador cuando ya exista una cuenta activa con los mismos datos de identificación, informando al solicitante que ya tiene una cuenta registrada. |
| **Justificación** | Las cuentas duplicadas generan confusión y pueden comprometer la integridad del historial de reservas del jugador. |
| **Autor** | Equipo CanchasYa! |
| **Criterio de verificación** | Un intento de registro con datos de identificación ya existentes es rechazado con el mensaje "Ya existe una cuenta con estos datos". No se crea una cuenta duplicada. |
| **Satisfacción del interesado** | 4 |
| **Insatisfacción del interesado** | 5 |
| **Prioridad** | Must have |
| **Dependencias** | — |
| **Conflictos** | — |
| **Material de soporte** | PUC-04 paso 2, E2.1 |
| **Historial** | 2026-05-08 — Creado |

---

## RF-32 — Registrar jugador mediante proveedor de identidad externo

| Campo | Valor |
|---|---|
| **# Requisito** | RF-32 |
| **Tipo** | Requisito funcional |
| **# Evento / Caso de uso** | PUC-04 (A1.1) |
| **Descripción** | El sistema deberá permitir registrar un jugador utilizando los datos de identificación obtenidos de un proveedor de identidad externo, sin requerir que el solicitante ingrese manualmente sus datos de contacto. |
| **Justificación** | La autenticación federada reduce la fricción del registro y elimina la necesidad de gestionar credenciales propias, lo que mejora la conversión de nuevos jugadores. |
| **Autor** | Equipo CanchasYa! |
| **Criterio de verificación** | Un solicitante que inicia el registro mediante un proveedor de identidad externo queda registrado como jugador activo sin necesidad de ingresar nombre o contraseña manualmente. |
| **Satisfacción del interesado** | 4 |
| **Insatisfacción del interesado** | 3 |
| **Prioridad** | Must have |
| **Dependencias** | RF-31 |
| **Conflictos** | — |
| **Material de soporte** | PUC-04 A1.1, (Authentication TBD — ADR-001) |
| **Historial** | 2026-05-08 — Creado |

---

## RF-33 — Rechazar datos de registro incompletos o inválidos

| Campo | Valor |
|---|---|
| **# Requisito** | RF-33 |
| **Tipo** | Requisito funcional |
| **# Evento / Caso de uso** | PUC-04 (E1.1) |
| **Descripción** | El sistema deberá rechazar una solicitud de registro cuando los datos proporcionados sean incompletos o tengan formato inválido, indicando al solicitante qué campos deben corregirse. |
| **Justificación** | Los datos de contacto deben ser válidos para que las notificaciones lleguen al jugador y para garantizar la integridad del registro. |
| **Autor** | Equipo CanchasYa! |
| **Criterio de verificación** | Un registro con campo de nombre vacío o con formato inválido es rechazado y el sistema indica qué campos deben corregirse. No se crea ninguna cuenta. |
| **Satisfacción del interesado** | 4 |
| **Insatisfacción del interesado** | 4 |
| **Prioridad** | Must have |
| **Dependencias** | — |
| **Conflictos** | — |
| **Material de soporte** | PUC-04 E1.1 |
| **Historial** | 2026-05-08 — Creado |

---

## RF-34 — Notificar confirmación del registro al jugador

| Campo | Valor |
|---|---|
| **# Requisito** | RF-34 |
| **Tipo** | Requisito funcional |
| **# Evento / Caso de uso** | PUC-04 (paso 4) |
| **Descripción** | El sistema deberá enviar una notificación de confirmación al jugador recién registrado, indicando que su cuenta está activa y que puede comenzar a reservar canchas. |
| **Justificación** | La confirmación explícita da seguridad al jugador de que su registro fue exitoso y lo orienta sobre qué puede hacer a continuación. |
| **Autor** | Equipo CanchasYa! |
| **Criterio de verificación** | Tras el registro exitoso, el jugador recibe una notificación de bienvenida en el canal de contacto registrado. |
| **Satisfacción del interesado** | 4 |
| **Insatisfacción del interesado** | 3 |
| **Prioridad** | Must have |
| **Dependencias** | RF-30 |
| **Conflictos** | — |
| **Material de soporte** | PUC-04 paso 4 |
| **Historial** | 2026-05-08 — Creado |
