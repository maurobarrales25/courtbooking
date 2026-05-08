# Requisitos Atómicos — PUC-03: Cancelar una reserva por el complejo

**Proyecto:** CanchasYa!
**Versión:** 1.0
**Fecha:** 2026-05-08
**PUC origen:** PUC-03 — Cancelar una reserva por el complejo
**BUC origen:** BUC-03

---

## Índice

| ID | Descripción breve | Tipo | Prioridad |
|---|---|---|---|
| RF-24 | Validar permisos del administrador sobre la reserva | Funcional | Must have |
| RF-25 | Registrar cancelación por complejo y cambiar estado a Cancelada | Funcional | Must have |
| RF-26 | Liberar turno de reserva cancelada por el complejo | Funcional | Must have |
| RF-27 | Instruir devolución completa al jugador cuando el complejo cancela | Funcional | Must have |
| RF-28 | Cancelar sin devolución si la reserva no fue pagada | Funcional | Must have |
| RF-29 | Notificar al jugador la cancelación por el complejo | Funcional | Must have |

---

## RF-24 — Validar permisos del administrador sobre la reserva

| Campo | Valor |
|---|---|
| **# Requisito** | RF-24 |
| **Tipo** | Requisito funcional |
| **# Evento / Caso de uso** | PUC-03 (paso 1, E1.1) |
| **Descripción** | El sistema deberá rechazar toda cancelación iniciada por un administrador sobre una reserva que no pertenezca al complejo que ese administrador gestiona. |
| **Justificación** | El aislamiento de datos multitenant exige que un administrador solo pueda operar sobre las reservas de su propio complejo (BR-14). |
| **Autor** | Equipo CanchasYa! |
| **Criterio de verificación** | Un administrador del complejo A que intente cancelar una reserva del complejo B recibe un rechazo. Un administrador del complejo A que cancele una reserva del complejo A no recibe rechazo por este criterio. |
| **Satisfacción del interesado** | 5 |
| **Insatisfacción del interesado** | 5 |
| **Prioridad** | Must have |
| **Dependencias** | RF-36 |
| **Conflictos** | — |
| **Material de soporte** | BR-14, PUC-03 E1.1 |
| **Historial** | 2026-05-08 — Creado |

---

## RF-25 — Registrar cancelación por complejo y cambiar estado a Cancelada

| Campo | Valor |
|---|---|
| **# Requisito** | RF-25 |
| **Tipo** | Requisito funcional |
| **# Evento / Caso de uso** | PUC-03 (paso 2) |
| **Descripción** | El sistema deberá cambiar el estado de la reserva a Cancelada y registrar el evento de cancelación indicando el administrador que la inició, la marca de tiempo y el motivo informado, cuando el administrador del complejo cancele una reserva confirmada. |
| **Justificación** | El cambio de estado y el registro del motivo son necesarios para trazabilidad operativa y para la posterior devolución al jugador (BR-17, BR-18, BR-30). |
| **Autor** | Equipo CanchasYa! |
| **Criterio de verificación** | Tras la cancelación por el complejo, la reserva tiene estado "Cancelada" y el log de auditoría contiene el administrador, la marca de tiempo, el estado anterior y el motivo registrado. |
| **Satisfacción del interesado** | 5 |
| **Insatisfacción del interesado** | 5 |
| **Prioridad** | Must have |
| **Dependencias** | RF-24 |
| **Conflictos** | — |
| **Material de soporte** | BR-17, BR-18, BR-30, PUC-03 paso 2 |
| **Historial** | 2026-05-08 — Creado |

---

## RF-26 — Liberar turno de reserva cancelada por el complejo

| Campo | Valor |
|---|---|
| **# Requisito** | RF-26 |
| **Tipo** | Requisito funcional |
| **# Evento / Caso de uso** | PUC-03 (paso 2) |
| **Descripción** | El sistema deberá hacer disponible para nuevas reservas el turno de una reserva cancelada por el complejo, inmediatamente después de registrar la cancelación. |
| **Justificación** | El complejo cancela generalmente para reasignar el turno por mantenimiento u otras causas; el turno debe quedar libre de inmediato. |
| **Autor** | Equipo CanchasYa! |
| **Criterio de verificación** | Inmediatamente después de que el complejo cancele una reserva, el turno correspondiente aparece disponible al consultar la disponibilidad de la cancha. |
| **Satisfacción del interesado** | 5 |
| **Insatisfacción del interesado** | 5 |
| **Prioridad** | Must have |
| **Dependencias** | RF-25 |
| **Conflictos** | — |
| **Material de soporte** | PUC-03 paso 2 |
| **Historial** | 2026-05-08 — Creado |

---

## RF-27 — Instruir devolución completa al jugador cuando el complejo cancela

| Campo | Valor |
|---|---|
| **# Requisito** | RF-27 |
| **Tipo** | Requisito funcional |
| **# Evento / Caso de uso** | PUC-03 (paso 3) |
| **Descripción** | El sistema deberá enviar al intermediario de cobro una instrucción de devolución del 100% del monto pagado por el jugador cuando el administrador del complejo cancele una reserva confirmada, independientemente del tiempo restante hasta el turno. |
| **Justificación** | El incumplimiento es del complejo; el jugador no puede ser penalizado y debe recibir reembolso total (BR-24). |
| **Autor** | Equipo CanchasYa! |
| **Criterio de verificación** | Al cancelar una reserva confirmada y pagada por un administrador, el intermediario de cobro recibe una instrucción de devolución igual al 100% del monto pagado, sin importar cuánto tiempo falta para el turno. |
| **Satisfacción del interesado** | 5 |
| **Insatisfacción del interesado** | 5 |
| **Prioridad** | Must have |
| **Dependencias** | RF-25 |
| **Conflictos** | — |
| **Material de soporte** | BR-24, PUC-03 paso 3 |
| **Historial** | 2026-05-08 — Creado |

---

## RF-28 — Cancelar sin devolución si la reserva no fue pagada

| Campo | Valor |
|---|---|
| **# Requisito** | RF-28 |
| **Tipo** | Requisito funcional |
| **# Evento / Caso de uso** | PUC-03 (A1.1) |
| **Descripción** | El sistema deberá cancelar una reserva en estado Pendiente iniciada por el administrador del complejo sin generar ninguna instrucción de devolución al intermediario de cobro. |
| **Justificación** | Si no hubo pago, no existe monto a devolver; la cancelación es solo administrativa. |
| **Autor** | Equipo CanchasYa! |
| **Criterio de verificación** | Al cancelar una reserva Pendiente (sin pago) por el administrador, el estado pasa a Cancelada y el turno queda libre sin que se genere instrucción de devolución. |
| **Satisfacción del interesado** | 4 |
| **Insatisfacción del interesado** | 4 |
| **Prioridad** | Must have |
| **Dependencias** | RF-25, RF-26 |
| **Conflictos** | — |
| **Material de soporte** | PUC-03 A1.1 |
| **Historial** | 2026-05-08 — Creado |

---

## RF-29 — Notificar al jugador la cancelación por el complejo

| Campo | Valor |
|---|---|
| **# Requisito** | RF-29 |
| **Tipo** | Requisito funcional |
| **# Evento / Caso de uso** | PUC-03 (paso 4) |
| **Descripción** | El sistema deberá notificar al jugador cuando su reserva sea cancelada por el complejo, incluyendo el motivo informado por el administrador y el detalle de la devolución gestionada. |
| **Justificación** | El jugador necesita conocer la cancelación con tiempo suficiente para reorganizar sus planes y saber que recibirá la devolución. |
| **Autor** | Equipo CanchasYa! |
| **Criterio de verificación** | Tras la cancelación por el complejo, el jugador recibe una notificación con los datos del turno cancelado, el motivo y el monto de devolución. |
| **Satisfacción del interesado** | 5 |
| **Insatisfacción del interesado** | 4 |
| **Prioridad** | Must have |
| **Dependencias** | RF-25, RF-27 |
| **Conflictos** | — |
| **Material de soporte** | PUC-03 paso 4 |
| **Historial** | 2026-05-08 — Creado |
