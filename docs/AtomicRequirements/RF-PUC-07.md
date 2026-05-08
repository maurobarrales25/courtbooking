# Requisitos Atómicos — PUC-07: Registrar la inasistencia de un jugador

**Proyecto:** CanchasYa!
**Versión:** 1.0
**Fecha:** 2026-05-08
**PUC origen:** PUC-07 — Registrar la inasistencia de un jugador
**BUC origen:** BUC-07

---

## Índice

| ID | Descripción breve | Tipo | Prioridad |
|---|---|---|---|
| RF-48 | Validar que el turno ya inició antes de registrar inasistencia | Funcional | Must have |
| RF-49 | Validar permisos del administrador sobre la reserva | Funcional | Must have |
| RF-50 | Cambiar estado a No-show y retener el pago | Funcional | Must have |
| RF-51 | Registrar inasistencia en el historial del jugador | Funcional | Must have |

---

## RF-48 — Validar que el turno ya inició antes de registrar inasistencia

| Campo | Valor |
|---|---|
| **# Requisito** | RF-48 |
| **Tipo** | Requisito funcional |
| **# Evento / Caso de uso** | PUC-07 (E2.2) |
| **Descripción** | El sistema deberá rechazar el registro de inasistencia sobre una reserva cuyo turno aún no haya comenzado, informando al administrador que el jugador todavía puede presentarse. |
| **Justificación** | Registrar una inasistencia antes de que inicie el turno sería prematuro e injusto para el jugador; la inasistencia solo es un hecho comprobable una vez iniciado el turno. |
| **Autor** | Equipo CanchasYa! |
| **Criterio de verificación** | Un intento de registrar inasistencia con `horaInicio > ahora` es rechazado con el mensaje "El turno aún no ha comenzado". Un registro con `horaInicio ≤ ahora` no es rechazado por este criterio. |
| **Satisfacción del interesado** | 4 |
| **Insatisfacción del interesado** | 4 |
| **Prioridad** | Must have |
| **Dependencias** | — |
| **Conflictos** | — |
| **Material de soporte** | PUC-07 E2.2 |
| **Historial** | 2026-05-08 — Creado |

---

## RF-49 — Validar permisos del administrador sobre la reserva de inasistencia

| Campo | Valor |
|---|---|
| **# Requisito** | RF-49 |
| **Tipo** | Requisito funcional |
| **# Evento / Caso de uso** | PUC-07 (E2.1) |
| **Descripción** | El sistema deberá rechazar el registro de inasistencia cuando el administrador que lo solicita no tenga permisos de gestión sobre el complejo al que pertenece la reserva. |
| **Justificación** | El aislamiento multitenant exige que cada administrador opere exclusivamente sobre los recursos de su propio complejo (BR-14). |
| **Autor** | Equipo CanchasYa! |
| **Criterio de verificación** | Un administrador del complejo A que intente registrar inasistencia en una reserva del complejo B recibe un rechazo. Un administrador del complejo A que registre inasistencia en una reserva del complejo A no recibe rechazo por este criterio. |
| **Satisfacción del interesado** | 5 |
| **Insatisfacción del interesado** | 5 |
| **Prioridad** | Must have |
| **Dependencias** | RF-36 |
| **Conflictos** | — |
| **Material de soporte** | BR-14, PUC-07 E2.1 |
| **Historial** | 2026-05-08 — Creado |

---

## RF-50 — Cambiar estado a No-show y retener el pago

| Campo | Valor |
|---|---|
| **# Requisito** | RF-50 |
| **Tipo** | Requisito funcional |
| **# Evento / Caso de uso** | PUC-07 (paso 3) |
| **Descripción** | El sistema deberá cambiar el estado de la reserva a No-show y retener el pago a favor del complejo, sin generar ninguna instrucción de devolución al jugador, cuando el administrador confirme la inasistencia. |
| **Justificación** | El jugador se comprometió con el turno y no se presentó; el complejo tiene derecho a conservar el pago como penalización (BR-25). |
| **Autor** | Equipo CanchasYa! |
| **Criterio de verificación** | Tras registrar la inasistencia, la reserva tiene estado "No-show". No se genera ninguna instrucción de devolución al intermediario de cobro. El log de auditoría registra la transición con el administrador y la marca de tiempo. |
| **Satisfacción del interesado** | 5 |
| **Insatisfacción del interesado** | 5 |
| **Prioridad** | Must have |
| **Dependencias** | RF-48, RF-49 |
| **Conflictos** | — |
| **Material de soporte** | BR-25, BR-18, PUC-07 paso 3 |
| **Historial** | 2026-05-08 — Creado |

---

## RF-51 — Registrar inasistencia en el historial del jugador

| Campo | Valor |
|---|---|
| **# Requisito** | RF-51 |
| **Tipo** | Requisito funcional |
| **# Evento / Caso de uso** | PUC-07 (paso 4) |
| **Descripción** | El sistema deberá agregar un registro de inasistencia en el historial del jugador asociado a la reserva marcada como No-show, con la fecha y el complejo correspondientes. |
| **Justificación** | El historial de inasistencias es necesario para que los complejos evalúen la confiabilidad de los jugadores y como base para futuras políticas de penalización. |
| **Autor** | Equipo CanchasYa! |
| **Criterio de verificación** | Tras registrar la inasistencia, el historial del jugador contiene una entrada con el tipo "No-show", la fecha del turno y el nombre del complejo. |
| **Satisfacción del interesado** | 4 |
| **Insatisfacción del interesado** | 3 |
| **Prioridad** | Must have |
| **Dependencias** | RF-50 |
| **Conflictos** | — |
| **Material de soporte** | PUC-07 paso 4 |
| **Historial** | 2026-05-08 — Creado |
