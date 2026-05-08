# Requisitos No Funcionales Transversales — CanchasYa!

**Proyecto:** CanchasYa!
**Versión:** 1.0
**Fecha:** 2026-05-08
**Alcance:** Aplican a todos los PUCs
**BRs de referencia:** BR-10, BR-13, BR-15, BR-17, BR-18, BR-19, BR-29, BR-30

---

## Índice

| ID | Descripción breve | Tipo | Prioridad |
|---|---|---|---|
| RNF-01 | Aislamiento de datos por tenant en todas las consultas | No funcional | Must have |
| RNF-02 | Registro de auditoría inmutable por toda operación de reserva | No funcional | Must have |
| RNF-03 | Identificador único global por reserva | No funcional | Must have |
| RNF-04 | Máquina de estados: rechazar transiciones inválidas | No funcional | Must have |
| RNF-05 | Expiración automática de reservas temporales vencidas | No funcional | Must have |

---

## RNF-01 — Aislamiento de datos por tenant en todas las consultas

| Campo | Valor |
|---|---|
| **# Requisito** | RNF-01 |
| **Tipo** | Requisito no funcional — seguridad / multitenancy |
| **# Evento / Caso de uso** | PUC-01, PUC-02, PUC-03, PUC-05, PUC-06, PUC-07 |
| **Descripción** | El sistema deberá filtrar obligatoriamente todas las consultas y operaciones sobre reservas, canchas y configuración por el identificador de tenant del complejo, impidiendo que cualquier usuario acceda a datos de un complejo al que no pertenezca. |
| **Justificación** | El modelo multitenant exige privacidad total entre complejos competidores que comparten la infraestructura del servicio (BR-13, BR-15). |
| **Autor** | Equipo CanchasYa! |
| **Criterio de verificación** | No existe ninguna consulta de recursos de complejo que devuelva datos de más de un tenant sin autorización explícita de superadmin. Un usuario autenticado del complejo A que realice una consulta recibe únicamente datos de ese complejo, incluso si manipula los identificadores de la solicitud. |
| **Satisfacción del interesado** | 5 |
| **Insatisfacción del interesado** | 5 |
| **Prioridad** | Must have |
| **Dependencias** | RF-35 |
| **Conflictos** | — |
| **Material de soporte** | BR-13, BR-15, PUC-05 paso 3 |
| **Historial** | 2026-05-08 — Creado |

---

## RNF-02 — Registro de auditoría inmutable por toda operación de reserva

| Campo | Valor |
|---|---|
| **# Requisito** | RNF-02 |
| **Tipo** | Requisito no funcional — trazabilidad |
| **# Evento / Caso de uso** | PUC-01, PUC-02, PUC-03, PUC-06, PUC-07 |
| **Descripción** | El sistema deberá registrar un evento de auditoría por cada creación, cambio de estado o cancelación de reserva, incluyendo el identificador del actor responsable, la marca de tiempo en UTC, el estado anterior y el estado nuevo. Los registros de auditoría no podrán ser modificados ni eliminados. |
| **Justificación** | La trazabilidad completa de las operaciones sobre reservas es necesaria para resolver disputas entre jugadores y complejos (BR-30). |
| **Autor** | Equipo CanchasYa! |
| **Criterio de verificación** | Tras cualquier creación, cambio de estado o cancelación de reserva, existe en el log de auditoría un registro con el actor, la marca de tiempo UTC, el estado anterior y el estado nuevo. No existe ningún endpoint que permita eliminar o modificar entradas del log. |
| **Satisfacción del interesado** | 4 |
| **Insatisfacción del interesado** | 5 |
| **Prioridad** | Must have |
| **Dependencias** | RNF-03 |
| **Conflictos** | — |
| **Material de soporte** | BR-30, PUC-01 paso 8, PUC-02 paso 5, PUC-03 paso 2 |
| **Historial** | 2026-05-08 — Creado |

---

## RNF-03 — Identificador único global por reserva

| Campo | Valor |
|---|---|
| **# Requisito** | RNF-03 |
| **Tipo** | Requisito no funcional — integridad de datos |
| **# Evento / Caso de uso** | PUC-01 (paso 5) |
| **Descripción** | El sistema deberá asignar a cada reserva un identificador único global en el momento de su creación. Este identificador no podrá ser reutilizado ni modificado en ningún momento posterior. |
| **Justificación** | Sin un identificador único garantizado, la trazabilidad de auditoría, las referencias de pago y la resolución de disputas no son confiables (BR-29). |
| **Autor** | Equipo CanchasYa! |
| **Criterio de verificación** | No existen dos reservas con el mismo identificador en el sistema. Una reserva cancelada o expirada no libera su identificador para ser reasignado. |
| **Satisfacción del interesado** | 5 |
| **Insatisfacción del interesado** | 5 |
| **Prioridad** | Must have |
| **Dependencias** | — |
| **Conflictos** | — |
| **Material de soporte** | BR-29, PUC-01 paso 5 |
| **Historial** | 2026-05-08 — Creado |

---

## RNF-04 — Máquina de estados: rechazar transiciones inválidas

| Campo | Valor |
|---|---|
| **# Requisito** | RNF-04 |
| **Tipo** | Requisito no funcional — integridad de negocio |
| **# Evento / Caso de uso** | PUC-01, PUC-02, PUC-03, PUC-06, PUC-07 |
| **Descripción** | El sistema deberá rechazar toda operación que intente llevar una reserva a un estado no permitido desde su estado actual, según el modelo de transiciones válidas definido en las reglas de negocio. |
| **Justificación** | Las transiciones inválidas generarían inconsistencias entre el estado de la reserva y el estado financiero (pagos, devoluciones), así como problemas de disponibilidad de turnos (BR-17, BR-18, BR-19). |
| **Autor** | Equipo CanchasYa! |
| **Criterio de verificación** | Un intento de realizar una transición no contemplada en BR-18 (ej. `Expirada → Confirmada`, `Finalizada → Cancelada`) es rechazado. Las transiciones válidas (ej. `Pendiente → Confirmada`, `Confirmada → Cancelada`) son aceptadas. |
| **Satisfacción del interesado** | 5 |
| **Insatisfacción del interesado** | 5 |
| **Prioridad** | Must have |
| **Dependencias** | RNF-03 |
| **Conflictos** | — |
| **Material de soporte** | BR-17, BR-18, BR-19 |
| **Historial** | 2026-05-08 — Creado |

---

## RNF-05 — Expiración automática de reservas temporales vencidas

| Campo | Valor |
|---|---|
| **# Requisito** | RNF-05 |
| **Tipo** | Requisito no funcional — comportamiento del sistema |
| **# Evento / Caso de uso** | PUC-01 (E7.1), PUC-06 (E3.1) |
| **Descripción** | El sistema deberá evaluar periódicamente (al menos cada minuto) el estado de todas las reservas en estado Pendiente y cambiar a Expirada aquellas cuyo tiempo límite de 10 minutos haya vencido sin que el pago haya sido completado, liberando el turno correspondiente. |
| **Justificación** | Sin expiración automática, los turnos de reservas abandonadas quedarían bloqueados indefinidamente, degradando la disponibilidad real del sistema (BR-09, BR-10). |
| **Autor** | Equipo CanchasYa! |
| **Criterio de verificación** | Una reserva en estado Pendiente cuyo tiempo de bloqueo superó los 10 minutos pasa a estado Expirada en el siguiente ciclo de evaluación (máximo 1 minuto después). El turno vuelve a estar disponible para nuevas reservas. El log de auditoría registra la transición como expiración automática. |
| **Satisfacción del interesado** | 5 |
| **Insatisfacción del interesado** | 5 |
| **Prioridad** | Must have |
| **Dependencias** | RNF-04, RF-12 |
| **Conflictos** | — |
| **Material de soporte** | BR-09, BR-10, PUC-01 E7.1 |
| **Historial** | 2026-05-08 — Creado |
